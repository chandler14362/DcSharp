using System;
using System.Buffers.Binary;
using Krypton.Buffers;

namespace DcSharp
{
    internal static class BufferParserExtensions
    {
        internal static void WriteValueConstant(this ref SpanBufferWriter writer, DcPackerInterface pi, DcParser.Value_constantContext value)
        {
            switch (pi.PackType)
            {
                case DcPackType.Int:
                case DcPackType.Int64:
                {
                    // TODO: verify result range
                    long result = 0;
                    
                    if (!value.number_constant()?.TryParseInt64(out result) ?? false)
                        throw new Exception($"{value.Start.Line}:{value.Start.Column} invalid value constant value: {value.GetText()} ");

                    switch (pi.FixedByteSize)
                    {
                        case 1:
                            writer.WriteInt8((sbyte) result);
                            return;
                        case 2:
                            writer.WriteInt16((short) result);
                            return;
                        case 4:
                            writer.WriteInt32((int) result);
                            return;
                        case 8:
                            writer.WriteInt64(result);
                            return;
                    }
                    return;
                }
                case DcPackType.UInt:
                case DcPackType.UInt64:
                {
                    // TODO: Verify result range
                    ulong result = 0;
                    
                    if (!value.number_constant()?.TryParseUInt64(out result) ?? false)
                        throw new Exception($"{value.Start.Line}:{value.Start.Column} invalid value constant: {value.GetText()} ");

                    switch (pi.FixedByteSize)
                    {
                        case 1:
                            writer.WriteUInt8((byte) result);
                            return;
                        case 2:
                            writer.WriteUInt16((ushort) result);
                            return;
                        case 4:
                            writer.WriteUInt32((uint) result);
                            return;
                        case 8:
                            writer.WriteUInt64(result);
                            return;
                    }
                    return;
                }
                case DcPackType.Blob:
                {
                    // blob can either be a string value or array value
                    if (value.string_constant() != null)
                    {
                        // TODO: blob32 support here
                        if (pi.NumLengthBytes == 4)
                            throw new NotImplementedException();

                        string result = string.Empty;
                        if (!value.string_constant().TryParseString(out result))
                            throw new Exception($"{value.Start.Line}:{value.Start.Column} Invalid value constant: {value.GetText()}");

                        writer.WriteUTF8String(result);
                    }
                    else if (value.array_constant() != null)
                    {
                        var nestedType = pi.GetNestedField(0);
                        
                        SpanBufferWriter.Bookmark bookmark = default;
                        if (!pi.HasFixedByteSize)
                            bookmark = writer.ReserveBookmark(pi.NumLengthBytes);

                        var startSize = writer.Size;
                    
                        var arrayValues = value.array_constant().array_value_list();
                        while (arrayValues != null)
                        {
                            var v = arrayValues.array_value_constant();
                            if (v.t != null) 
                            {
                                if (!uint.TryParse(v.t.Text, out var times))
                                    throw new Exception($"{v.t.Line}:{v.t.Column} Invalid repeater: {v.t.Text}");

                                for (var i = 0; i < times; i++)
                                    writer.WriteValueConstant(nestedType, v.value_constant());
                            }
                            else
                            {
                                writer.WriteValueConstant(nestedType, v.value_constant());
                            }
                            arrayValues = arrayValues.next;
                        }

                        if (!pi.HasFixedByteSize)
                        {
                            var arraySize = writer.Size - startSize;
                            if (pi.NumLengthBytes == 2)
                                writer.WriteBookmark(bookmark, (ushort) arraySize, BinaryPrimitives.WriteUInt16LittleEndian);
                            else if (pi.NumLengthBytes == 4)
                                writer.WriteBookmark(bookmark, (uint) arraySize, BinaryPrimitives.WriteUInt32LittleEndian);
                            else
                                throw new Exception($"Invalid blob header length: {pi.NumLengthBytes}");
                        }
                    }
                    else
                    {
                        throw new Exception($"{value.Start.Line}:{value.Start.Column} Invalid value constant: {value.GetText()}");
                    }
                    return;
                }
                case DcPackType.String:
                {
                    // TODO: fixed length strings

                    // single byte char
                    if (pi.HasFixedByteSize && pi.FixedByteSize == 1)
                    {
                        char result = ' ';
                        if (!value.string_constant()?.TryParseChar(out result) ?? false)
                            throw new Exception($"{value.Start.Line}:{value.Start.Column} Invalid value constant: {value.GetText()}");

                        writer.WriteUInt8((byte) result);
                        return;
                    }

                    string res = string.Empty;
                    if (!value.string_constant()?.TryParseString(out res) ?? false)
                        throw new Exception($"{value.Start.Line}:{value.Start.Column} Invalid value constant: {value.GetText()}");

                    // dynamic length string
                    writer.WriteUTF8String(res);
                    return;
                }
                case DcPackType.Array:
                {
                    if (value.array_constant() == null)
                        throw new Exception($"{value.Start.Line}:{value.Start.Column} Invalid value constant: {value.GetText()}");

                    var nestedType = pi.GetNestedField(0);
                    
                    SpanBufferWriter.Bookmark bookmark = default;
                    if (!pi.HasFixedByteSize)
                        bookmark = writer.ReserveBookmark(2);

                    var startSize = writer.Size;
                    
                    var arrayValues = value.array_constant().array_value_list();
                    while (arrayValues != null)
                    {
                        var v = arrayValues.array_value_constant();
                        if (v.t != null) 
                        {
                            if (!uint.TryParse(v.t.Text, out var times))
                                throw new Exception($"{v.t.Line}:{v.t.Column} Invalid repeater: {v.t.Text}");

                            for (var i = 0; i < times; i++)
                                writer.WriteValueConstant(nestedType, v.value_constant());
                        }
                        else
                        {
                            writer.WriteValueConstant(nestedType, v.value_constant());
                        }
                        arrayValues = arrayValues.next;
                    }

                    if (!pi.HasFixedByteSize)
                    {
                        var arraySize = writer.Size - startSize;
                        writer.WriteBookmark(bookmark, (ushort) arraySize, BinaryPrimitives.WriteUInt16LittleEndian);
                    }

                    return;
                }
                case DcPackType.Field:
                {
                    if (value.struct_constant() == null)
                        throw new Exception($"{value.Start.Line}:{value.Start.Column} Invalid value constant: {value.GetText()}");

                    var structValues = value.struct_constant().struct_value_list();
                    for (var i = 0; i < pi.NumNestedFields; i++)
                    {
                        if (structValues == null)
                            throw new Exception($"{value.Start.Line}:{value.Start.Column} missing field data.");
                        
                        var field = pi.GetNestedField(i);
                        writer.WriteValueConstant(field, structValues.value_constant());
                        
                        structValues = structValues.next;
                    }
                    
                    if (structValues != null)
                        throw new Exception($"{structValues.Start.Line}:{structValues.Start.Column} excess field data.");
                    
                    return;
                }
                default:
                    throw new Exception($"Don't know how to pack {pi.PackType}");
            }
        }

        internal static bool TryParseInt64(this DcParser.Number_constantContext number, out long result)
        {
            // TODO: more long types
            return long.TryParse(number.GetText(), out result);
        }
        
        internal static bool TryParseUInt64(this DcParser.Number_constantContext number, out ulong result)
        {
            // TODO: more ulong types
            return ulong.TryParse(number.GetText(), out result);
        }
        
        internal static bool TryParseString(this DcParser.String_constantContext str, out string result)
        {
            result = str.GetText()[1..^1];
            return true;
        }

        internal static bool TryParseChar(this DcParser.String_constantContext str, out char result)
        {
            // TODO: more char types
            var text = str.GetText();
            if (text.Length != 3)
            {
                result = ' ';
                return false;
            }

            result = text[1];
            return true;
        }
    }
}
