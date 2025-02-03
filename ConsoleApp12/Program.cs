using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
namespace ThreadSample
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1 Task
            //int[] numbers = new int[4] { 1, 2, 3, 5 };

            //Thread thread = new Thread(() =>
            //{
            //    foreach (int item in numbers)
            //    {
            //        Console.WriteLine("From num to string: " + item.ToString());

            //    }
            //});
            //thread.Start();
            #endregion

            #region 2 Task
            //Bank myBank = new Bank("UniverseBank", 10000, 2);
            //myBank.Name = "BankUniverse";
            //myBank.Money = 100;
            //myBank.Percent = 1;
            //Console.WriteLine("Свойства изменены. Данные записываются в файл...");
            //Console.ReadLine();
            #endregion

            #region 3 Task
            Stopwatch stopwatch = new Stopwatch();
            Thread game = new Thread(Game);
            game.Start();
            do
            {
                stopwatch.Start();
                Console.ReadKey();
                game.Suspend();
                stopwatch.Stop();
                Console.WriteLine($"Время выполнения: {stopwatch.Elapsed.TotalMilliseconds} миллисекунд");
                game.Resume();
            } while (Console.ReadKey().Key != ConsoleKey.Enter);
            #endregion


        }

        static void Game()
        {
            Random random = new Random();  

            for (int i = 0; i < 100; i++)
            {
                char randomLetter = (char)random.Next('A', 'Z' + 1);
                Console.WriteLine(randomLetter);
                Thread.Sleep(3000);
            }

        }


        class Bank
        {
            private int money;
            private string name;
            private int percent;

            public int Money
            {
                get => money;
                set
                {
                    money = value;
                    ThreadLog();
                }
            }

            public string Name
            {
                get => name;
                set
                {
                    name = value;
                    ThreadLog();
                }
            }

            public int Percent
            {
                get => percent;
                set
                {
                    percent = value;
                    ThreadLog();
                }
            }

            public Bank(string name, int money, int percent)
            {
                this.name = name;
                this.money = money;
                this.percent = percent;
                ShowInf();
            }

            private void ShowInf()
            {
                Console.WriteLine($"Bank name: {Name} | Money: {Money} | Percent:{Percent}%");
            }

            private void WriteToFile()
            {
                string path = "dataBank.txt";
                string data = $"Bank name: {Name} | Money: {Money} | Percent:{Percent}%";

                File.WriteAllText(path, data);

            }

            private void ThreadLog() { 

                Thread log = new Thread(WriteToFile);
                int num = 100;
                Thread.Sleep(num);
                log.Start();
                num *= 3;
               
            }

        }
    }

}
