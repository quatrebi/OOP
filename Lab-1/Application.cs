using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Lab_1
{
    class Application
    {
        static void Main(string[] args)
        {
            // 1 - a
            // - Value Types
            bool boolVar             = true;                     // System.Boolean;
            char charVar             = char.MaxValue;            // System.Char

            sbyte sbyteVar           = sbyte.MinValue;           // System.SByte (s8-bit)
            byte byteVar             = byte.MaxValue;            // Systen.Byte (u8-bit)
            short shortVar           = short.MinValue;           // System.Int16 (s16-bit)
            ushort ushortVar         = ushort.MaxValue;          // System.UInt16 (u16-bit)
            int intVar               = int.MinValue;             // System.Int32 (s32-bit)
            uint uintVar             = uint.MaxValue;            // System.UInt32 (u32-bit)
            long longVar             = long.MinValue;            // System.Int64 (s64-bit)
            ulong ulongVar           = ulong.MaxValue;           // System.UInt64 (u64-bit)

            float floatVar           = float.MinValue;           // System.Single (4-bytes)
            double doubleVar         = double.MaxValue;          // System.Double (8-bytes)
            decimal decimalVar       = decimal.MinValue;         // System.Decimal (16-bytes)

            // - References Types
            object objectVar         = new object();             // System.Object
            string stringVar         = new string(new char[1]);  // System.String
            dynamic dynamicVar       = new object();             // System.Object

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
            string firstName = "Dmitriy";
            string secondName = "Khudnitskiy";
            Console.WriteLine();
            Console.WriteLine("firstName is equal to secondName ? " + firstName.Equals(secondName).ToString());

            // 2 - b
            string firstString = "First String";
            string secondString = "Second String";
            string thirdString = "Third String";
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
            Console.WriteLine();

            // 3 - b
            string[] stringArray = { "Blum", "Trix", "Stella", "Flora", "Muza" };
            Console.WriteLine("Array Length - {0}", stringArray.Length);
            foreach (var str in stringArray)
            {
                Console.WriteLine("\t{0}\t{1} symbols", str, str.Length);
            }
            Console.Write("Введите позицию изменяего слова и значение: ");
            var inputArgs = Console.ReadLine().Split(' ');
            stringArray[Convert.ToInt32(inputArgs[0])] = inputArgs[1];
            for (int i = 0; i < stringArray.Length; i++)
            {
                Console.WriteLine("\t[{0}] {1}\t{2} symbols", i, stringArray[i], stringArray[i].Length);
            }

            // 3 - c
            float[][] floatArray = { new float[2], new float[4], new float[3] };
            for (int i = 0; i < floatArray.Length; i++)
            {
                Console.Write("Введите {0} значений через пробел: ", floatArray[i].Length);
                inputArgs = Console.ReadLine().Split(' ');
                for (int j = 0; j < floatArray[i].Length; j++)
                {
                    floatArray[i][j] = (float)Convert.ToDouble(inputArgs[j]);
                }
            }
            foreach (var line in floatArray)
            {
                foreach (var item in line)
                {
                    Console.Write("\t{0}", item.ToString());
                }
                Console.WriteLine();
            }

            // 3 - d
            var intArray = new int[] { 3, 1, 4 };
            var boolArray = new bool[] { true, false };
            var doubleArray = new double[] { 3.14, 3.14, 3.14 };
            var charArray = new char[] { 'W', 'i', 'n', 'x' };
            Console.WriteLine("\n\tvar\t\tType");
            Console.WriteLine("\t intArray\t " + intArray.GetType());
            Console.WriteLine("\t boolArray\t " + boolArray.GetType());
            Console.WriteLine("\t doubleArray\t " + doubleArray.GetType());
            Console.WriteLine("\t charArray\t " + charArray.GetType());

            // 4 - a
            (int, string, char, string, ulong) winx = (0, "ENCHANTIX", 'e', "MAGIC DUST!", 0xFF);
            var fakeWinx = Tuple.Create<int, string, char, string, ulong>(1, "ENCHANTIX", 'f', "MAGIC DIST!", 0xFF);
            // 4 - b
            Console.WriteLine("\tWinx:");
            Console.Write($"\t\t{winx.Item1}");
            Console.Write($"\t{winx.Item2}");
            Console.Write($"\t{winx.Item3}");
            Console.Write($"\t{winx.Item4}");
            Console.Write($"\t{winx.Item5}\n");
            Console.WriteLine("\tFakeWinx:");
            Console.Write($"\t\t{fakeWinx.Item1}");
            Console.Write($"\t{fakeWinx.Item3}");

            int intTuple = (int)winx.Item1;
            string stringTuple1 = winx.Item2;
            char charTuple = (char)winx.Item3;
            string stringTuple2 = (string)winx.Item4;
            ulong ulongTuple = winx.Item5;

            Console.WriteLine($"\nTuples is equal ? {(winx.ToTuple() == fakeWinx ? bool.TrueString : bool.FalseString)}");

            // 5
            Console.WriteLine($"Input: {intArray[0]}, {intArray[1]}, {intArray[2]}, {firstName}");
            var answer = new Application().MakeFunctionGreateAgain(intArray, firstName);
            Console.WriteLine($"Output: {answer}");
            Console.ReadKey();
        }

        public (int max, int min, long sum, char firstLetter) MakeFunctionGreateAgain(int[] intArray, string str)
        {
            return (intArray.Max(), intArray.Min(), intArray.Sum(), str[0]);
        }
    }
}
