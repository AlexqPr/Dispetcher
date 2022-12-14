using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAKA_9
{
    internal class arrow
    {
        public void ARROWS(int max, Process[] list)
        {
            
            int min = 1;
            int position = 1;

            Console.SetCursorPosition(0, position);
            Console.WriteLine("->");
            ConsoleKeyInfo key = Console.ReadKey();
            while (key.Key != (ConsoleKey)Klavishi.Enter)
            {

                if (key.Key == (ConsoleKey)Klavishi.Up)
                {
                    position--;
                    Console.SetCursorPosition(0, position + 1);


                }
                if (key.Key == (ConsoleKey)Klavishi.Down)
                {
                    position++;
                    Console.SetCursorPosition(0, position - 1);

                }
                if (position > max)
                {
                    position--;
                    Console.SetCursorPosition(0, position);
                }
                if (position < min)
                {
                    position++;
                    Console.SetCursorPosition(0, position);
                }

                Console.WriteLine("  ");
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");
                key = Console.ReadKey();
            }
            ConsoleKeyInfo keyfor;
            keyfor = Menu(list, position);
            try
            {
                if (keyfor.Key == (ConsoleKey)Klavishi.D)
                {
                    list[position - 1].Kill();
                }
                else if (keyfor.Key == (ConsoleKey)Klavishi.Backspace)
                {
                    Console.Clear();
                    SLUSHI.Inform();
                }
                else if (keyfor.Key == (ConsoleKey)Klavishi.Delete)
                {
                    Process[] p1 = System.Diagnostics.Process.GetProcessesByName(list[position - 1].ProcessName);
                    foreach (Process p in p1)
                    {
                        p.Kill();
                    }
                }
            }
            catch
            {
                Console.WriteLine("У консоли нет прав для завершения данного процесса");
            }
            finally
            {
                Console.Clear();
                SLUSHI.Inform();
            }

          
           
        }
        public static ConsoleKeyInfo Menu(Process[] list, int position)
        {
            try
            {
                Console.Clear();
                Console.WriteLine(list[position - 1]);
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("  Использование диска:");
                Console.SetCursorPosition(40, 2);
                Console.WriteLine(list[position - 1].PagedMemorySize64);
                Console.WriteLine("  Приоритет:");
                Console.SetCursorPosition(40, 3);
                Console.WriteLine(list[position - 1].BasePriority);
                Console.WriteLine("  Класс приоритета:");
                Console.SetCursorPosition(40, 4);
                Console.WriteLine(list[position - 1].PriorityClass);
                Console.WriteLine("  Использование оперативной памяти:");
                Console.SetCursorPosition(40, 5);
                Console.WriteLine(list[position - 1].WorkingSet64);
                Console.WriteLine("  Все время использования:");
                Console.SetCursorPosition(40, 6);
                Console.WriteLine(list[position - 1].TotalProcessorTime);
                Console.SetCursorPosition(0, 7);
                Console.WriteLine("Остановить данный процесс - D\nОстановить процессы с этим именем - Delete");
                
            }
            catch (System.ComponentModel.Win32Exception)
            {
                Console.Clear();
                Console.WriteLine(list[position - 1]);
                Console.WriteLine("Вам отказано в доступе");
               
               

            }
            finally
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Backspace - Вернуться в прошлое меню\nEscape - выход из программы");

            }
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == (ConsoleKey)Klavishi.Escape)
            {
                Environment.Exit(0);
            }
            return key;
        }
    }
}
