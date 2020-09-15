using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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

            // 1 - e
            bool? nullableBoolVar = boolVar;
            Nullable<int> nullableIntVar = intVar;

            Console.WriteLine();
            if (nullableBoolVar.HasValue) Console.WriteLine("Nullable<bool> value is " + nullableBoolVar.Value);
            Console.WriteLine("Nullable<int> value is " + nullableIntVar.ToString() ?? "null");

            // 2 - a
            string firstName    = "Dmitriy";
            string secondName   = "Khudnitskiy";
            Console.WriteLine();
            Console.WriteLine("firstName is equal to secondName ? " + firstName.Equals(secondName).ToString());

            // 2 - b
            string firstString      = "First String";
            string secondString     = "Second String";
            string thirdString      = "Third String";
            Console.WriteLine();
            Console.WriteLine("Input string:\t{0}\t{1}\t{2}\n", firstString, secondString, thirdString);
            Console.WriteLine("\tConcat()\t " + String.Concat(firstString, secondString));
            Console.WriteLine("\tCopy()\t\t " + String.Copy(thirdString));
            Console.WriteLine("\tSubstring()\t " + thirdString.Substring(3, 6));
            Console.Write("\tSplit()\t  ");
            foreach (var word in (firstString + secondString + thirdString).Split(' '))
            {
                Console.Write("\t{0}", word);
            }
            Console.WriteLine("\n\tInsert()\t " + firstString.Insert(3, thirdString));
            Console.WriteLine("\tRemove()\t " + secondString.Remove(3, 6));

            // 2 - c
            string emptyString = String.Empty;
            string nullString = null;
            Console.WriteLine("\n\tEmpty - {0}\tNull - {1}", emptyString, nullString);
            Console.WriteLine("\tLength:\t {0}\t\t{1}", emptyString?.Length ?? -1, nullString?.Length ?? -1);
            Console.WriteLine("\tConcat:\t " + emptyString + nullString);
            Console.WriteLine("\tEqual:\t " + emptyString.Equals(nullString).ToString());

            // 2 - d
            StringBuilder builderString = new StringBuilder("We are free to create miracles###");
            builderString.Remove(builderString.Length - 3, 3);
            builderString.Insert(0, "Winx - only together we are strong\n");
            builderString.Append("\nAnd always strive for VICTORY!\n");
            Console.WriteLine("\n{0}", builderString);
            Console.WriteLine("\n\tLength:\t {0}\tCapacity:\t {1}\n", builderString.Length, builderString.Capacity);

            // 3 - a
            Random rand = new Random(System.DateTime.Now.Millisecond);
            int[,] matrix = new int[10, 10];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rand.Next(-10, 10);
                    Console.Write("\t{0}", matrix[i, j].ToString());
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
