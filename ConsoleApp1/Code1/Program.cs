using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
        //а
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            DateTime now = DateTime.Now;

            Console.WriteLine(now.ToString("dddd, dd, MMMM, yy, mm"));


        //b  

            Console.Write("Введіть рік народження: ");
            int year = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введіть місяць народження: ");
            int month = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введіть день народження: ");
            int day = Convert.ToInt32(Console.ReadLine());

            DateTime birthDate = new DateTime(year, month, day);


            int ageYears = now.Year - birthDate.Year;
            if (now < birthDate.AddYears(ageYears))
            {
                ageYears--;
            }


            int ageMonths = ageYears * 12 + (now.Month - birthDate.Month);
            if (now.Day < birthDate.Day)
            {
                ageMonths--;
            }

            // c

            DateTime birthDatesecondlife = new DateTime(2010, 12, 6);

            TimeSpan livedTime = now - birthDate;


            Console.WriteLine($"Ви прожили приблизно {livedTime.TotalSeconds} секунд.");

            //d

            Console.WriteLine($"Вік: {ageYears} років");
            Console.WriteLine($"Прожито місяців: {ageMonths}");
            Console.Write("Введіть рік: ");

            int yearlife = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введіть місяць: ");
            int monthlife = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введіть день: ");
            int daylife = Convert.ToInt32(Console.ReadLine());


            DateTime date = new DateTime(year, month, day);


            string dayOfWeek = date.ToString("dddd");
      
            Console.WriteLine($"Це був день тижня: {dayOfWeek}");

            //e
            
            int hour = 8;
            int minute = 30;

            Console.WriteLine("Навчання починається о 8:30");

            for (int lesson = 1; lesson <= 7; lesson++)
            {
                Console.WriteLine($"{lesson} урок - {hour:D2}:{minute:D2}");

              
                minute += 45;

                if (lesson == 4)
                    minute += 40; 
                else
                    minute += 15; 

              
                hour += minute / 60;
                minute %= 60;
            }
        }





    }
    }

