using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace LockWindows
{
    class Program
    {
        [DllImport("user32")]
        public static extern bool LockWorkStation();//这个是调用windows的系统锁定

        static void Main(string[] args)
        {

            var time = DateTime.Now;

            if (time.Hour >= 18 || time.Hour < 9)
                return;
            if (time.DayOfWeek < DayOfWeek.Monday || time.DayOfWeek > DayOfWeek.Friday)
                return;

            Console.SetWindowSize(40, 5);
            Console.SetBufferSize(40, 5);
            for (var n = 8; n > 0; n--)
            {
                Console.Write($"系统将在{n}秒后锁屏");
                Thread.Sleep(1000);
                Console.Write("\b \b");
                Console.Clear();
            }
            LockWorkStation();
            System.Environment.Exit(0);
        }
    }
}
