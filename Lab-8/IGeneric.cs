using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    interface IGeneric<T>
    {
        void Insert(T value);
        void Extract(T value);
        void View();

        void InputFromFile(FileStream fin);
        void OutputToFile(FileStream fout);
    }
}
