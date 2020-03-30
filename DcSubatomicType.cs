namespace DcSharp
{
    public enum DcSubatomicType
    {
        Int8,
        Int16,
        Int32,
        Int64,

        UInt8,
        UInt16,
        UInt32,
        UInt64,

        Float64,

        String,      // a human-printable string
        Blob,        // any variable length message, stored as a string
        Blob32,      // a blob with a 32-bit length, up to 4.2 GB long
        Int16Array,
        Int32Array,
        UInt16Array,
        UInt32Array,

        Int8Array,
        UInt8Array,

        // A special-purpose array: a list of alternating uint32 and uint8 values.
        // In Python, this becomes a list of 2-tuples.
        UInt32UInt8Array,

        // Equivalent to uint8, except that it suggests a pack_type of PT_string.
        Char,

        // New additions should be added at the end to prevent the file hash code
        // from changing.

        Invalid 
    }
}