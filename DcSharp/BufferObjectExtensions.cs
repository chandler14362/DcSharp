using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using Krypton.Buffers;

namespace DcSharp
{
    public static class BufferObjectExtensions
    {
        public static object ReadObject(this MemoryBufferReader reader, DcPackerInterface pi)
        {
            var spanReader = new SpanBufferReader(reader.RemainingData.Span);
            var value = spanReader.ReadObject(pi);
            reader.SkipBytes(spanReader.Offset);
            return value;
        }
        
        public static object ReadObject(this ref SpanBufferReader reader, DcPackerInterface pi)
        {
            switch (pi.PackType)
            {
                case DcPackType.Int:
                case DcPackType.Int64:
                {
                    return pi.FixedByteSize switch
                    {
                        1 => (object) reader.ReadInt8(),
                        2 => (object) reader.ReadInt16(),
                        4 => (object) reader.ReadInt32(),
                        8 => (object) reader.ReadInt64(),
                        _ => throw new NotImplementedException()
                    };
                }
                case DcPackType.UInt:
                case DcPackType.UInt64:
                {
                    return pi.FixedByteSize switch
                    {
                        1 => (object) reader.ReadUInt8(),
                        2 => (object) reader.ReadUInt16(),
                        4 => (object) reader.ReadUInt32(),
                        8 => (object) reader.ReadUInt64(),
                        _ => throw new NotImplementedException()
                    };
                }
                case DcPackType.Blob:
                {
                    var length = ReadArrayHeader(ref reader, pi);
                    var bytes = reader.ReadBytes((int)length);
                    return bytes.ToArray();
                }
                case DcPackType.String:
                {
                    // TODO: fixed length strings
                    
                    // single byte char
                    if (pi.HasFixedByteSize && pi.FixedByteSize == 1)
                        return (char) reader.ReadUInt8();
                    
                    // dynamic length string
                    return reader.ReadString8();
                }
                case DcPackType.Array:
                {
                    var nestedType = pi.GetNestedField(0);
                    var values = new List<object>();
                    var length = ReadArrayHeader(ref reader, pi);
                    var readTill = reader.RemainingSize - length;
                    while (reader.RemainingSize != readTill)
                        values.Add(reader.ReadObject(nestedType));
                    return values;
                }
                case DcPackType.Field:
                {
                    var values = new object[pi.NumNestedFields];
                    for (var i = 0; i < pi.NumNestedFields; i++)
                        values[i] = reader.ReadObject(pi.GetNestedField(i));
                    return values;
                }
                default:
                    throw new Exception($"Don't know how to unpack {pi.PackType}");
            }
        }

        private static uint ReadArrayHeader(ref SpanBufferReader reader, DcPackerInterface pi)
        {
            if (pi.HasFixedByteSize)
                return (uint)pi.FixedByteSize;

            return pi.NumLengthBytes switch
            {
                2 => reader.ReadUInt16(),
                4 => reader.ReadUInt32(),
                _ => throw new NotImplementedException()
            };
        }
        
        public static void WriteObject(this GrowingMemoryBuffer writer, DcPackerInterface pi, object obj)
        {
            var spanWriter = new GrowingSpanBuffer(stackalloc byte[512]);
            spanWriter.WriteObject(pi, obj);
            writer.WriteBytes(spanWriter.Data);
        }
        
        public static void WriteObject(this ref GrowingSpanBuffer writer, DcPackerInterface pi, object obj)
        {
            switch (pi.PackType)
            {
                case DcPackType.Int:
                case DcPackType.Int64:
                {
                    switch (pi.FixedByteSize)
                    {
                        case 1:
                            writer.WriteInt8((sbyte) obj);
                            return;
                        case 2:
                            writer.WriteInt16((short) obj);
                            return;
                        case 4:
                            writer.WriteInt32((int) obj);
                            return;
                        case 8:
                            writer.WriteInt64((long) obj);
                            return;
                    }
                    return;
                }
                case DcPackType.UInt:
                case DcPackType.UInt64:
                {
                    switch (pi.FixedByteSize)
                    {
                        case 1:
                            writer.WriteUInt8((byte) obj);
                            return;
                        case 2:
                            writer.WriteUInt16((ushort) obj);
                            return;
                        case 4:
                            writer.WriteUInt32((uint) obj);
                            return;
                        case 8:
                            writer.WriteUInt64((ulong) obj);
                            return;
                    }
                    return;
                }
                case DcPackType.Blob:
                {
                    // TODO: fixed length blobs
                    var binaryData = (byte[])obj;
                    if (pi.NumLengthBytes == 2)
                        writer.WriteUInt16((ushort)binaryData.Length);
                    else if (pi.NumLengthBytes == 4)
                        writer.WriteUInt32((uint)binaryData.Length);
                    else
                        throw new Exception($"Invalid blob length bytes value: {pi.NumLengthBytes}");
                    
                    writer.WriteBytes(binaryData);
                    return;
                }
                case DcPackType.String:
                {
                    // TODO: fixed length strings
                    
                    // single byte char
                    if (pi.HasFixedByteSize && pi.FixedByteSize == 1)
                    {
                        writer.WriteUInt8((byte) (char) obj);
                        return;
                    }
                    
                    // dynamic length string
                    writer.WriteString8((string) obj);
                    return;
                }
                case DcPackType.Array:
                {
                    var nestedType = pi.GetNestedField(0);
                    var arrayValue = (IEnumerable<object>) obj;
                    
                    GrowingSpanBuffer.Bookmark bookmark = default;
                    if (!pi.HasFixedByteSize)
                        bookmark = writer.ReserveBookmark(2);

                    var startSize = writer.Size;
                    foreach (var value in arrayValue)
                        writer.WriteObject(nestedType, value);

                    if (!pi.HasFixedByteSize)
                    {
                        var arraySize = writer.Size - startSize;
                        writer.WriteBookmark(bookmark, (ushort)arraySize, BinaryPrimitives.WriteUInt16LittleEndian);
                    }
                    return;
                }
                case DcPackType.Field:
                {
                    var arrayValue = (object[]) obj;
                    for (var i = 0; i < pi.NumNestedFields; i++)
                        writer.WriteObject(pi.GetNestedField(i), arrayValue[i]);
                    return;
                }
                default:
                    throw new Exception($"Don't know how to pack {pi.PackType}");
            }
        }
    }
}