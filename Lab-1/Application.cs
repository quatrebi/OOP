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
            // Value Types
            bool booleanVar = true; // System.Boolean;

            /*  System.
            *           SByte (sbyte) s8-bit
            *           Byte (byte) u8-bit
            *           Int16 (short) s16-bit
            *           UInt16 (ushort) u16-bit
            *           Int32 (int) s32-bit
            *           UInt32 (uint) u32-bit
            *           Int64 (long) s64-bit
            *           UInt64 (ulong) u64-bit
            */
            int integerVar = 123;
            char charVar = 'a'; // System.Char

            /* System.
             *          Single (float) 4-bytes
             *          Double (double) 8-bytes
             *          Decimal (decimal) 16-bytes
             */
            double floatingVar = 123.345;

            // References Types
            object obj = 234; // System.Object
            string str = "beautifull string"; // System.String
            dynamic dobj = 345; // System.Object

            Console.Read();
        }
    }
}
