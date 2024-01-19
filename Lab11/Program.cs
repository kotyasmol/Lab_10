using System.Diagnostics;
using System.Net;
using PersonLibrary;

namespace Lab11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 1000;
            TestCollections testCollections = new TestCollections(n);
            Console.WriteLine($"\nКоличество элементов в каждой коллекции: {n}\n");
            testCollections.MeasureSearchTime();
        }
    }
}
