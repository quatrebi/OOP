using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.ObjectModel;

namespace Lab_10
{
    public class Application
    {
        public static Random rand;
        const int initCount = 5;
        static void Main(string[] args)
        {
            rand = new Random(DateTime.Now.Millisecond);
            ArrayList aList = new ArrayList();
            for (byte i = 0; i < initCount; i++)
                aList.Add(rand.Next(100));
            aList.Add("Sample string");
            aList.Add(new Student("Dmitriy", 2));

            Console.WriteLine($"\nArrayList[{aList.Count}] Output:\n");
            CollectionOutput(aList);
            Console.Write("\nEnter the sequence number of the item to be removed: ");
            int rem = Convert.ToInt32(Console.ReadLine());
            aList.RemoveAt(rem);
            CollectionOutput(aList);

            Console.Write("Enter the value of the item to search: ");
            int obj = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"The item you were searching for was found - {(aList.Contains(obj) ? bool.TrueString : bool.FalseString)}");


            int size = rand.Next(4, 10);
            Stack<double> st = new Stack<double>();
            for (int i = 0; i < size; i++)
                st.Push(rand.Next(100));

            Console.WriteLine("\nStack<double> output: ");
            CollectionOutput(st);

            int nRem = rand.Next(st.Count - 2);
            var dtemp = st.Pop();
            while (nRem-- > 0) st.Pop();

            st.Push(dtemp);
            size = st.Count;

            Console.WriteLine("\nStack<double> output: ");
            CollectionOutput(st);

            Console.WriteLine("\nLinkedList<double> output: ");
            LinkedList<double> ll = new LinkedList<double>();
            for (int i = 0; i < size; i++)
            {
                var item = st.Pop();
                Console.Write($"{item}[{i}] ");
                ll.AddLast(item);
            }
            Console.WriteLine();
            int fnd = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"The item you were searching for was found - {(ll.Find(fnd) != null ? bool.TrueString : bool.FalseString)}\n\n");

            size = rand.Next(4, 10);
            Stack<Equipment> est = new Stack<Equipment>();
            for (int i = 0; i < size; i++)
                est.Push(new Equipment()
                {
                    somethingField = -rand.Next(100)
                });
            Console.WriteLine("\nStack<Equipment> output: ");
            CollectionOutput(est);

            nRem = rand.Next(est.Count - 2);
            var etemp = est.Pop();
            while (nRem-- > 0) est.Pop();

            est.Push(etemp);
            size = est.Count;

            Console.WriteLine("\nStack<Equipment> output: ");
            CollectionOutput(est);

            Console.WriteLine("\nLinkedList<Equipment> output: ");
            LinkedList<Equipment> ell = new LinkedList<Equipment>();
            for (int i = 0; i < size; i++)
            {
                var item = est.Pop();
                Console.Write($"[{i}] {item}");
                ell.AddLast(item);
            }
            Equipment efnd = new Equipment()
            {
                somethingField = Convert.ToInt32(Console.ReadLine())
            };
            Console.WriteLine($"The item you were searching for was found - {(ell.Find(efnd) != null ? bool.TrueString : bool.FalseString)}\n\n");

            ObservableCollection<char> obs = new ObservableCollection<char>
            {
                'a', 'b', 'c'
            };
            obs.CollectionChanged += Obs_CollectionChanged;

            obs.Clear();
            obs.Add('d'); obs.Add('a'); obs.Add('e');
            obs.Remove('a');
            obs[0] = 'e'; 

            Console.ReadKey();
        }

        private static void Obs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var nItem in e.NewItems)
                {
                    Console.WriteLine($"{nItem} was added in {sender.GetType().Name}");
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var oItem in e.OldItems)
                {
                    Console.WriteLine($"{oItem} was removed from {sender.GetType().Name}");
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                Console.Write("That's items was: ");
                foreach (var rped in e.OldItems) Console.Write($"{rped} | ");
                Console.Write("\n... was replaced by this items: ");
                foreach (var rping in e.NewItems) Console.Write($"{rping} | ");
            }
        }

        static void CollectionOutput(IEnumerable obj)
        {
            foreach (var i in obj)
                Console.Write(i.ToString() + " | ");
            Console.WriteLine();
        }
    }

    public struct Student
    {
        public string name;
        public int course;

        public Student(string _name, int _course)
        {
            name = _name;
            course = _course;
        }

        public override string ToString()
        {
            return $"Name: {name} Course: {course}";
        }
    }
}
