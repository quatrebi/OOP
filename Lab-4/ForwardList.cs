using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public class ForwardList : ICloneable
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
                Iterator cur = First;
                while (cur != null)
                {
                    cur = cur.Next;
                    pos++;
                }
                return pos;
            }
        }

        public Iterator First { get; set; }

        public ForwardList()
        {
            creationDate = new Date();
            owner = new Owner(creationDate.Now.Millisecond);
            First = new Iterator(Application.rand.Next(-999, 999));
        }
        
        public ForwardList(int amount) : this()
        {
            Iterator cur = First;
            while (amount > 0)
            {
                cur.Next = new Iterator(Application.rand.Next(-999, 999));
                cur = cur.Next;
                amount--;
            }
        }

        public Iterator GetLast()
        {
            Iterator last = First;
            while (last.Next != null)
            {
                last = last.Next;
            }
            return last;
        }

        public static ForwardList operator !(ForwardList obj)
        {
            ForwardList result = (ForwardList)obj.Clone();

            Iterator cur = result.First;
            while (cur != null)
            {
                cur.Value = -cur.Value;
                cur = cur.Next;
            }

            return result;
        }
        public static ForwardList operator +(ForwardList left, ForwardList right)
        {
            ForwardList result = (ForwardList)left.Clone();
            Iterator cur = result.First, rightCur = right.First;

            while (cur != null && rightCur != null)
            {
                cur.Next = new Iterator(rightCur.Value, cur.Next);
                rightCur = rightCur.Next;
                cur = cur.Next.Next;
            }

            cur = result.GetLast();
            while (rightCur != null)
            {
                cur.Next = new Iterator(rightCur.Value);
                rightCur = rightCur.Next;
                cur = cur.Next;
            }

            return result;
        }

        public static ForwardList operator <(ForwardList left, ForwardList right)
        {
            ForwardList result = (ForwardList)left.Clone();
            result.GetLast().Next = ((ForwardList)right.Clone()).First;
            return result;
        }

        public static ForwardList operator >(ForwardList left, ForwardList right)
        {
            ForwardList result = (ForwardList)right.Clone();
            result.GetLast().Next = ((ForwardList)left.Clone()).First;
            return result;
        }


        public static bool operator ==(ForwardList left, ForwardList right)
        {
            if (left.Length != right.Length) return false;

            Iterator leftCur = left.First, rightCur = right.First;
            while (leftCur != null && rightCur != null)
            {
                if (leftCur.Value != rightCur.Value) return false;

                leftCur = leftCur.Next;
                rightCur = rightCur.Next;
            }
            return true;
        }

        public static bool operator !=(ForwardList left, ForwardList right)
        {
            return !(left == right);
        }

        public object Clone()
        {
            ForwardList cloned = new ForwardList();
            Iterator clonedCur = cloned.First, cur = First;
            while (cur != null)
            {
                clonedCur.Value = cur.Value;
                if (cur.Next != null) clonedCur.Next = new Iterator(cur.Next.Value);
                clonedCur = clonedCur.Next;
                cur = cur.Next;
            }
            return cloned;
        }

        public override bool Equals(object obj)
        {
            return (this == obj as ForwardList);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            string result = string.Empty;
            Iterator cur = First;
            while (cur != null)
            {
                result += '\t' + cur.Value.ToString();
                cur = cur.Next;
            }
            return result;
        }
    }
}
