using System.Linq;

namespace Lab_8
{
    public class Iterator<T>
        where T: struct
    {
        public T Value { get; set; }
        public Iterator<T> Next { get; set; }
        public Iterator<T> Prev { get; set; }

        public Iterator()
        {
            Value = default;
            Next = null;
            Prev = null;
        }

        public Iterator(T value, Iterator<T> next = null, Iterator<T> prev = null) : this()
        {
            Value = value;
            Next = next;
            Prev = prev;
        }

        public static Iterator<T> operator -(Iterator<T> obj) 
        {
            Iterator<T> result = (Iterator<T>)obj.MemberwiseClone();
            long _value = (long)(object)result.Value;
            result.Value = (T)(object)(-_value);
            return result;
        }
    }
}
