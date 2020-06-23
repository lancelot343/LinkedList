using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList<int>();
            list.Add(5);
            list.Add(13);
            list.Add(66);
            list.Delete(13);
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
