using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAKA_9
{
    public static class SLUSHI
    {
        public static void Inform()
        {
            arrow strelki = new arrow();  //вызов стрелок

            //для position будет -1
            Process[] newlist = Process.GetProcesses();
            int max = newlist.Length;
            Console.WriteLine("Названние процесса:                           Приоритет:                                Объем памяти:");
            int i = 0;
            double MB = Math.Pow(1024, 2);
            foreach (Process s in newlist)
            {
                Console.SetCursorPosition(1, 1 + i);
                Console.WriteLine("  " + s.ProcessName);
                Console.SetCursorPosition(50, 1 + i);
                Console.WriteLine(s.BasePriority);
                Console.SetCursorPosition(90, 1 + i);
                Console.WriteLine(Math.Round(s.WorkingSet64 / MB, 2) + " Мб");
                i++;

            }

            strelki.ARROWS(max, newlist);
        }
    }
}
