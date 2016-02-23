using System;
using System.Diagnostics;
using System.Runtime;

namespace Collector.API
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSpeedForLargeByteArray();
        }

        static void TestSpeedForLargeByteArray()
        {
            Stopwatch sw = new Stopwatch();

            Console.Write("GC.GetTotalMemory before creating array: {0:N0}. ", GC.GetTotalMemory(true));
            Console.WriteLine("Press any key to create array...");
            Console.ReadKey();

            byte[] array = new byte[1000 * 1000 * 1000]; // About 1 GB

            sw.Start();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 1; // Touch array elements to fill working set              
            }
            Console.WriteLine("Setup time: " + sw.Elapsed);

            Console.WriteLine("GC.GetTotalMemory after creating array: {0:N0}.", GC.GetTotalMemory(true));
            Console.WriteLine(" Press Enter to set array to null and call GC.Collect()...");

            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.WriteLine("Setting array to null");
                array = null;
            }

            sw.Restart();

            //GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
            GC.Collect();
            Console.WriteLine("Collection time: " + sw.Elapsed);
            Console.WriteLine("GC.GetTotalMemory after GC.Collect: {0:N0}.", GC.GetTotalMemory(true));
            Console.WriteLine("Press any key to finish...");

            Console.WriteLine(array); // To avoid compiler optimization...
            Console.ReadKey();
        }
    }
}
