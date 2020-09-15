using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class Application
    {
        static void Main(string[] args)
        {
            // 1 - a
            // - Value Types
            bool boolVar;           // System.Boolean;
            char charVar;           // System.Char

            sbyte sbyteVar;         // System.SByte (s8-bit)
            byte byteVar;           // Systen.Byte (u8-bit)
            short shortVar;         // System.Int16 (s16-bit)
            ushort ushortVar;       // System.UInt16 (u16-bit)
            int intVar;             // System.Int32 (s32-bit)
            uint uintVar;           // System.UInt32 (u32-bit)
            long longVar;           // System.Int64 (s64-bit)
            ulong ulongVar;         // System.UInt64 (u64-bit)

            float floatVar;         // System.Single (4-bytes)
            double doubleVar;       // System.Double (8-bytes)
            decimal decimalVar;     // System.Decimal (16-bytes)

            // - References Types
            object objectVar;       // System.Object
            string stringVar;       // System.String
            dynamic dynamicVar;     // System.Object
        }
    }
}
