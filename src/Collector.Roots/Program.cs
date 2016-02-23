using System;

namespace Collector.Roots
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstMethod();
            SecondMethod();
        }

        private static void FirstMethod()
        {
            Console.WriteLine("About to create stuff. Take first snapshot and press enter");
            Console.ReadKey();
            var regularProperty = new ClassWithRegularProperty();

            var byte1 = ClassWithStaticProperty.StaticProperty;
            var byte2 = regularProperty.RegularProperty;

            var name = ClassWithStaticMethod.GetName();
            Console.WriteLine("This is my name {0}", name);
            Console.WriteLine("Take another snapshot and press enter");
            Console.ReadKey();
        }

        private static void SecondMethod()
        {
            GC.Collect();
            Console.WriteLine("GC.Collect just ran. Take another snapshot");
            Console.ReadKey();
        }


    }
}
