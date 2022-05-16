using System;
using BenchmarkDotNet.Running;

namespace Benchmark
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var result = BenchmarkRunner.Run<Demo>();

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}