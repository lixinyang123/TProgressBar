using System;
using System.Threading;

namespace ConsoleProgressTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("第一轮测试开始");

            for(var i=0;i<20;i++)
            {
                Console.WriteLine($"第{i+1}次测试");

                ProgressBar progressBar = new ProgressBar();

                for(var j=0;j<=100;j++)
                {
                    progressBar.Display(j);
                    Thread.Sleep(10);
                }

            }

            Console.WriteLine("测试全部完成");
            Console.Read();
        }
    }
}
