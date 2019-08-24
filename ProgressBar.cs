using System;

namespace ConsoleProgressTest
{
    //进度条样式
    public enum ProgressType
    {
        //字符样式
        Character,
        //彩色样式
        Multicolor
    }

    //光标所在位置
    internal struct Position
    {
        public int left;
        public int top;
    }

    public class ProgressBar
    {
        //加载进度条前光标所在位置
        private Position lastCursorPosition;

        //进度条所在行
        private int progressTop;

        //进度条最大值
        private int maxValue;

        //进度条宽度
        private int progressWidth;

        private ProgressType progressType;

        //最大值默认为100
        //如果进度打到最大值提示 'done'
        public ProgressBar(int max=100,int width=40,ProgressType type=ProgressType.Character)
        {
            maxValue = max;
            progressWidth = width;
            progressType = type;
            InitProgressBar();
        }

        //记录当前光标位置
        private void GetCursorPosition()
        {
            lastCursorPosition.left = Console.CursorLeft;
            lastCursorPosition.top = Console.CursorTop;
        }

        //恢复之前的光标位置
        private void ResetCursorPosition() => Console.SetCursorPosition(lastCursorPosition.left,lastCursorPosition.top);

        private void InitProgressBar()
        {
            GetCursorPosition();

            //设定进度条所在行
            if(lastCursorPosition.top<Console.WindowHeight-1)
            {
                Console.SetCursorPosition(0,Console.WindowHeight-1);
            }
            else
            {
                Console.SetCursorPosition(0,lastCursorPosition.top);
            }

            //清空进度条区域
            Console.Write(new string(' ',Console.WindowWidth-1));

            //记录进度条所在行，用于绘制进度时使用
            progressTop = Console.CursorTop;

            //绘制进度条
            if(progressType == ProgressType.Multicolor)
            {
                Console.SetCursorPosition(0,progressTop);
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.Write(new string(' ',progressWidth));
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            { 
                Console.SetCursorPosition(0,progressTop);
                Console.Write('[');
                Console.Write(new string(' ',progressWidth));
                Console.Write(']');
            }
            
            //恢复光标位置
            ResetCursorPosition();
        }


        public void Display(int value)
        {
            GetCursorPosition();

            if(value<maxValue)
            {
                //计算显示的进度的字符数量
                int num = Convert.ToInt32((double)value/maxValue*progressWidth);

                if(progressType == ProgressType.Multicolor)
                {
                    Console.SetCursorPosition(0,progressTop);
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write(new string(' ',num));
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.SetCursorPosition(1,progressTop);
                    Console.Write(new string('#',num));
                }

                //显示百分比数值
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(progressWidth+2,progressTop);
                Console.Write(Convert.ToInt32((double)value/maxValue*100)+"%");
                Console.ForegroundColor = ConsoleColor.White;

                ResetCursorPosition();
            }
            else
            {
                //清除进度条
                Console.SetCursorPosition(0,progressTop);
                Console.Write(new string(' ',Console.WindowWidth-1));

                //恢复光标位置
                ResetCursorPosition();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("done!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

    }
}
