using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class ForwardList<T> : ICloneable, IGeneric<T>
        where T : struct
    {
        public struct Owner
        {
            public readonly long id;
            public string author;
            public string company;

            public Owner(long ID)
            {
                id = ID.GetHashCode();
                author = "Dmitriy Khudnitskiy";
                company = "BSTU";
            }

            public override string ToString()
            {
                return $"[{id}] {author} from {company}";
            }
        }

        public class Date
        {
            public DateTime Now { get; }

            public Date()
            {
                Now = DateTime.Now.Date;
            }

            public override string ToString()
            {
                return $"Date of creation - {Now.ToShortDateString()}";
            }
        }

        public Owner owner;
        public Date creationDate;

        public int Length
        {
            get
            {
                int pos = 0;
                Iterator<T> cur = First;
                while (cur != null)
                {
                    cur = cur.Next;
                    pos++;
                }
                return pos;
            }
        }

        public Iterator<T> First { get; set; }

        public ForwardList()
        {
            creationDate = new Date();
            owner = new Owner(creationDate.Now.Millisecond);
            First = new Iterator<T>(default(T));
        }
        
        public ForwardList(int amount) : this()
        {
            Iterator<T> cur = First;
            while (amount > 0)
            {
                cur.Next = new Iterator<T>((T)(object) Application.rand.Next(-999, 999));
                cur = cur.Next;
                amount--;
            }
        }

        public void Insert(T value)
        {
            GetLast().Next = new Iterator<T>(value);
        }

        public void Extract(T value)
        {
            Iterator<T> cur = First, prev = null;

            while (cur != null)
            {
                if (cur.Value.GetHashCode() == value.GetHashCode())
                {
                    if (prev != null)
                        prev.Next = cur.Next;
                    else
                        First = First.Next;
                }
                prev = cur;
                cur = cur.Next;
            }
        }

        public void View()
        {
            Console.WriteLine($"\tViewing ForwardList:\n\t{ToString()}");
        }

        public void InputFromFile(FileStream fin)
        {
            byte[] data = new byte[fin.Length];
            fin.Read(data, 0, data.Length);
            string[] values = Encoding.Default.GetString(data).Split('\t');
            First = new Iterator<T>((T)(object)Convert.ToInt32(values[1]));
            int pos = 1; Iterator<T> cur = First;
            while (pos != values.Length - 1)
            {
                cur.Next = new Iterator<T>((T)(object)Convert.ToInt32(values[++pos]));
                cur = cur.Next;
            }
            fin.Close();
        }

        public void OutputToFile(FileStream fout)
        {
            byte[] data = Encoding.Default.GetBytes(ToString());
            fout.Write(data, 0, data.Length);
            fout.Close();
        }

        public Iterator<T> GetLast()
        {
            Iterator<T> last = First;
            while (last.Next != null)
            {
                last = last.Next;
            }
            return last;
        }

        public static ForwardList<T> operator !(ForwardList<T> obj)
        {
            ForwardList<T> result = (ForwardList<T>)obj.Clone();

            Iterator<T> cur = result.First;
            while (cur != null)
            {
                cur = -cur;
                cur = cur.Next;
            }

            return result;
        }
        public static ForwardList<T> operator +(ForwardList<T> left, ForwardList<T> right)
        {
            ForwardList<T> result = (ForwardList<T>)left.Clone();
            Iterator<T> cur = result.First, rightCur = right.First;

            while (cur != null && rightCur != null)
            {
                cur.Next = new Iterator<T>(rightCur.Value, cur.Next);
                rightCur = rightCur.Next;
                cur = cur.Next.Next;
            }

            cur = result.GetLast();
            while (rightCur != null)
            {
                cur.Next = new Iterator<T>(rightCur.Value);
                rightCur = rightCur.Next;
                cur = cur.Next;
            }

            return result;
        }

        public static ForwardList<T> operator <(ForwardList<T> left, ForwardList<T> right)
        {
            ForwardList<T> result = (ForwardList<T>)left.Clone();
            result.GetLast().Next = ((ForwardList<T>)right.Clone()).First;
            return result;
        }

        public static ForwardList<T> operator >(ForwardList<T> left, ForwardList<T> right)
        {
            ForwardList<T> result = (ForwardList<T>)right.Clone();
            result.GetLast().Next = ((ForwardList<T>)left.Clone()).First;
            return result;
        }

        public static bool operator ==(ForwardList<T> left, ForwardList<T> right)
        {
            if (left.Length != right.Length) return false;

            Iterator<T> leftCur = left.First, rightCur = right.First;
            while (leftCur != null && rightCur != null)
            {
                if ((object)leftCur.Value != (object)rightCur.Value) return false;

                leftCur = leftCur.Next;
                rightCur = rightCur.Next;
            }
            return true;
        }

        public static bool operator !=(ForwardList<T> left, ForwardList<T> right)
        {
            return !(left == right);
        }

        public object Clone()
        {
            ForwardList<T> cloned = new ForwardList<T>();
            Iterator<T> clonedCur = cloned.First, cur = First;
            while (cur != null)
            {
                clonedCur.Value = cur.Value;
                if (cur.Next != null) clonedCur.Next = new Iterator<T>(cur.Next.Value);
                clonedCur = clonedCur.Next;
                cur = cur.Next;
            }
            return cloned;
        }

        public override bool Equals(object obj)
        {
            return (this == obj as ForwardList<T>);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            string result = string.Empty;
            Iterator<T> cur = First;
            while (cur != null)
            {
                result += '\t' + cur.Value.ToString();
                cur = cur.Next;
            }
            return result;
        }
    }
}
