using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            AccessDemo demo = new AccessDemo();

            //demo.

            BadClass bad = new BadClass();

            bad.Age = 150;
            bad._age = 150;

            demo.PublicDemo();
        }

        private static void SayHello()
        {
            Console.WriteLine("Hello user");
        }
    }
}
