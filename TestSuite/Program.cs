using System;
using System.Buffers.Binary;
using DcSharp;

namespace TestSuite
{
    class Program
    {
        static void Main(string[] args)
        {
            // setFriendsList(uint32uint8array)
            // [[100001, 1], [100002, 2]]
            var data = new byte[]
            {
                10, 0, 161, 134, 1, 0, 1, 162, 134, 1, 0, 2
            };

            // setBarrierData(BarrierData[])
            // [[1, "name", [0]], [2, "secondName", [1, 2]]    
            var data2 = new byte[]
            {
                38, 0, 1, 0, 4, 0, 110, 97, 109, 101, 4, 0, 0, 0, 0, 0, 2, 0, 10, 0, 115, 101, 99, 111, 110, 100, 78,
                97, 109, 101, 8, 0, 1, 0, 0, 0, 2, 0, 0, 0
            };

            Console.WriteLine("Hello World!");
            
            var dcFile = new DcFile(DcMode.Modern);
            dcFile.Load("../../../sample.dc");

            var dclass = dcFile.GetClassByName("DistributedPlayer");
            Console.WriteLine(dclass);
            var field = dclass.GetFieldByName("setFriendsList");

            var p = DcPacker.UnpackBytes(field, data);
            Console.WriteLine(p.Length);

            dclass = dcFile.GetClassByName("DistributedToon");
            field = dclass.GetFieldByName("setEmoteAccess");
            byte[] defaultValue = ((DcField)field.GetNestedField(0)).DefaultValue.ToArray();
            Console.WriteLine("size:" + defaultValue.Length);
            Console.WriteLine(BitConverter.ToString(defaultValue));
        }
    }
}
