using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication12
{
    class Program
    {
        static void Main(string[] args)
        {
            // создал стрингу которая читает файл, и рандомизатор чисел.
            StreamReader objReader = new StreamReader("e:\\dps.txt");
            string dpsLine = ""; ArrayList arrText = new ArrayList();
            Random rnd = new Random();

            // Описание считаных параметров с файла в консоль
            dpsLine = objReader.ReadLine();
            double dmg = double.Parse(dpsLine);
            Console.WriteLine("Урон оружия: {0}", dmg);

            dpsLine = objReader.ReadLine();
            int cc = int.Parse(dpsLine);
            Console.WriteLine("Шанс крита: {0}", cc);

            dpsLine = objReader.ReadLine();
            double cdmg = double.Parse(dpsLine);
            Console.WriteLine("Критический урон: {0}", cdmg);

            dpsLine = objReader.ReadLine();
            double speed = double.Parse(dpsLine);
            Console.WriteLine("Скорость атаки: {0}", speed);

            dpsLine = objReader.ReadLine();
            int AmmoSize = int.Parse(dpsLine);
            Console.WriteLine("Обойма: {0}", AmmoSize);

            dpsLine = objReader.ReadLine();
            double Reloadspeed = double.Parse(dpsLine);
            Console.WriteLine("Скорость перезарядки: {0} \n", Reloadspeed);

            // умножение скорости атаки и обоймы, потому что дробные числа это хуёво.
            speed *= 100;
            AmmoSize *= 100;
            double mid_dps = 0;
            int AmmoSpend = 0;

            // повторить атаки в течении 1000 секунд 100 раз для большей точности.
            for (int y = 0; y < 100; y++)
            {
                double total = 0;
                double dps = 0;
                // атаковать в течении 1000 секунд
                for (double i = 0; i < 1000; i++)
                {
                    // если кол-во потраченых пуль превышает обойму - прибавить к времени атаки, время перезарядки с нулевым уроном.
                    if (AmmoSize < AmmoSpend)
                    {
                        i += Reloadspeed;
                        AmmoSpend -= AmmoSize;
                    }
                    // выполнить количество атак в секунду равное скорости атаки
                    else for (int j = 0; j < speed; j++)
                        {// проверка на срабатывание крита, если крит сработал прибавить к урону критический урон, если не сработал - обычный урон.
                            total += (rnd.Next(0, 101) <= cc && cc != 0)? (dmg * cdmg): dmg;
                            // прибавить кол-во потраченых пуль.
                                AmmoSpend++;
                        }
                }
                // общий урон разделить на 1000 , потому что атаки проводились 1000 секунд, и еще на 100, потому что умножали скорость.
                dps = (total / 1000) / 100;
                mid_dps += dps;
            }
           // вычисляем и выводим на экран средний дпс путём деления на 100, так как проводили атаки 100 раз.
            mid_dps /= 100;
            Console.WriteLine("ДПС = {0}", mid_dps);





        }
    }
}