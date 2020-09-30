using System;

namespace Lab_4
{
    public class Iterator
    {
        public long Value { get; set; }
        public Iterator Next { get; set; }
        public Iterator Prev { get; set; }

        public Iterator()
        {
            Value = default;
            Next = null;
            Prev = null;
        }

        public Iterator(long value, Iterator next = null, Iterator prev = null) : this()
        {
            Value = value;
            Next = next;
            Prev = prev;
        }

        public static Iterator operator -(Iterator obj) 
        {
            Iterator result = (Iterator)obj.MemberwiseClone();
            result.Value = -result.Value;
            return result;
        }
    }
}
