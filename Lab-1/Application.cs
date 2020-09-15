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
            bool boolVar            = true;                     // System.Boolean;
            char charVar            = char.MaxValue;            // System.Char

            sbyte sbyteVar          = sbyte.MinValue;           // System.SByte (s8-bit)
            byte byteVar            = byte.MaxValue;            // Systen.Byte (u8-bit)
            short shortVar          = short.MinValue;           // System.Int16 (s16-bit)
            ushort ushortVar        = ushort.MaxValue;          // System.UInt16 (u16-bit)
            int intVar              = int.MinValue;             // System.Int32 (s32-bit)
            uint uintVar            = uint.MaxValue;            // System.UInt32 (u32-bit)
            long longVar            = long.MinValue;            // System.Int64 (s64-bit)
            ulong ulongVar          = ulong.MaxValue;           // System.UInt64 (u64-bit)

            float floatVar          = float.MinValue;           // System.Single (4-bytes)
            double doubleVar        = double.MaxValue;          // System.Double (8-bytes)
            decimal decimalVar      = decimal.MinValue;         // System.Decimal (16-bytes)

            // - References Types
            object objectVar        = new object();             // System.Object
            string stringVar        = new string(new char[1]);  // System.String
            dynamic dynamicVar      = new object();             // System.Object

            // 1 - b
            // - Неявное преобразование (возможна потеря данных)
            intVar = shortVar;
            ushortVar = byteVar;
            doubleVar = floatVar;
            longVar = intVar;
            objectVar = stringVar;

            // - Явное преобразование (нет потери данных)
            charVar = (char)intVar;
            floatVar = (float)decimalVar;
            sbyteVar = (sbyte)ulongVar;
            ushortVar = (ushort)doubleVar;
            stringVar = (string)objectVar;

            // 1 - c 
            // Упаковка 
            objectVar = intVar;
            dynamicVar = sbyteVar;
            // Распаковка
            longVar = (int)objectVar;
            byteVar = (byte)dynamicVar;

            // 1 - d
            var autoInt = intVar;
            var autoFloat = floatVar;
            var autoString = stringVar;

            Console.WriteLine("\tvar\t\tType");
            Console.WriteLine("\t autoInt\t " + autoInt.GetType());
            Console.WriteLine("\t autoFloat\t " + autoFloat.GetType());
            Console.WriteLine("\t autoString\t " + autoString.GetType());

            Console.Read();

        }
    }
}
