using System;
using System.Threading;

namespace ConsoleProgressTest
{
    class Program
    {
        static void Main(string[] args)
        {
            for(var i=0;i<20;i++)
            {
                Console.WriteLine($"第{i+1}次测试");

                Console.WriteLine("字符进度条");

                ProgressBar progressBar1 = new ProgressBar();

                for(var j=0;j<=100;j++)
                {
                    progressBar1.Display(j);
                    Thread.Sleep(10);
                }

                Console.WriteLine("彩色进度条");

                ProgressBar progressBar2 = new ProgressBar(100,ProgressType.Multicolor);

                for(var j=0;j<=100;j++)
                {
                    progressBar2.Display(j);
                    Thread.Sleep(10);
                }

                Console.WriteLine();

            }

            Console.WriteLine("测试全部完成");
            Console.Read();
        }
    }
}
