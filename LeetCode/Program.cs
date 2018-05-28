using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Code code = new Code();
            ////code.FindPoisonedDuration()
            //code.FindDuplicates(new int[] { 5,4,6,7,9,3,10,9,5,6});

            //code.ConstructArray(10, 9);

            //Stopwatch stopwatch = new Stopwatch();
            //Random random = new Random();

            //int[] nums1000 = new int[1000];
            //for (int i = 0; i < nums1000.Length; i++)
            //{
            //    nums1000[i] = 1;
            //}

            //int[] nums5000 = new int[10000000];
            //for (int i = 0; i < nums5000.Length; i++)
            //{
            //    nums5000[i] = 1;
            //}

            //stopwatch.Start();
            //code.ProductExceptSelf(nums1000);
            //stopwatch.Stop();
            //Console.WriteLine(stopwatch.Elapsed);

            //stopwatch.Reset();
            //stopwatch.Start();
            //code.ProductExceptSelf(nums5000);
            //stopwatch.Stop();
            //Console.WriteLine(stopwatch.Elapsed);


            int[] ta = new int[2333];
            for (int i = 0; i < 1166; i++)
            {
                ta[i] = 1;
            }

            for (int i = 1166; i < 2333; i++)
            {
                ta[i] = 1;
            }

            Console.WriteLine(code.MajorityElement(ta));
            Console.ReadLine();


        }
    }
}
