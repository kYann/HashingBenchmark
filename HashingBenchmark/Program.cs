using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashingBenchmark
{
    public class HashingBenchmark
    {
        private const int N = 10;
        private readonly byte[] data;
        private readonly string sData;

        private readonly SHA256 sha256 = SHA256.Create();
        private readonly SHA1 sha1 = SHA1.Create();
        private readonly MD5 md5 = MD5.Create();
        private readonly PasswordHasher identityHasher = new PasswordHasher();

        public HashingBenchmark()
        {
            data = new byte[N];
            new Random(42).NextBytes(data);
            sData = UTF8Encoding.UTF8.GetString(data);
        }

        [Benchmark]
        public byte[] Sha256() => sha256.ComputeHash(data);

        //[Benchmark]
        //public byte[] Sha1() => sha1.ComputeHash(data);

        //[Benchmark]
        //public byte[] Md5() => md5.ComputeHash(data);

        [Benchmark]
        public string PasswordHasher() => identityHasher.HashPassword(sData);

        [Benchmark]
        public string BCryptHasher() => BCrypt.Net.BCrypt.HashPassword(sData);
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(System.Web.Security.Membership.HashAlgorithmType);
            var summary = BenchmarkRunner.Run<HashingBenchmark>();
            Console.ReadLine();
        }
    }
}
