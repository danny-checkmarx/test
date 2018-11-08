using System;
using System.Reflection;

namespace Test
{

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(Assembly.GetExecutingAssembly().GetName().Version);
        }
    }
}
