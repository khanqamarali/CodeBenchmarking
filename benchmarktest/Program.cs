using System;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;
using System.Security.Cryptography;
using BenchmarkDotNet.Order;
using System.Collections.Generic;
using System.Linq;

namespace benchmarktest
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class Customers
    {
        private List<string> names = new List<string>() { "A","B","C"};
        

        [Benchmark(Baseline =true)]
        public string ReturnbySingle()
        {
            return names.Single(x=>x=="C") ;
        }

        [Benchmark]
        public string ReturnByforEachLoop()
        {
            foreach (var x in names)
            {
                if (x == "C")
                {
                    return x;
                }

            }
            return "Not found";
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Customers>();
        }
    }


}
