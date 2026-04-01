using System;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            //1
            Console.WriteLine("Введіть цільові кроки (0-30000):");
            string targetInput = Console.ReadLine();

            Console.WriteLine("Введіть фактичні кроки (0-30000):");
            string actualInput = Console.ReadLine();


            bool targetOk = int.TryParse(targetInput, out int targetSteps);
            bool actualOk = int.TryParse(actualInput, out int actualSteps);

            if (!targetOk || !actualOk)
            {
                Console.WriteLine("💥 Помилка: введено не число!");
                return;
            }


            if (targetSteps > 50000 || actualSteps > 50000)
            {
                Console.WriteLine("💥 Помилка,щось піййшло не так");
                return;
            }

            int percent = actualSteps * 100 / targetSteps;

            if (percent >= 100)
                Console.WriteLine("Ціль досягнута! Ви молодець!");
            else
                Console.WriteLine("Ще трохи порухайтесь!");
            //2

            Console.WriteLine("Вітаємо у магазині електроніки!");
            Console.WriteLine("Введіть суму покупки в грн:");
            bool ok = decimal.TryParse(Console.ReadLine(), out decimal totalAmount);

            if (!ok || totalAmount <= 0)
            {
                Console.WriteLine("Невірна сума. Програма завершена.");
                return;
            }


            decimal cashback = 0;
            if (totalAmount > 2000 && totalAmount <= 10000)
                cashback = totalAmount * 0.01m;
            else if (totalAmount > 10000)
                cashback = totalAmount * 0.05m;


            Console.WriteLine("Ви використовуєте карту лояльності? (так/ні)");
            string loyaltyInput = Console.ReadLine()?.ToLower();// Робимо всі літери маленькими, щоб незалежно від того, як користувач написав "Так" чи "ТАК".

            decimal loyaltyDiscount = 0;

            if (loyaltyInput == "так")
            {
                if (totalAmount > 20000)
                    loyaltyDiscount = totalAmount * 0.05m;
                else
                    loyaltyDiscount = totalAmount * 0.03m;
            }


            decimal totalDiscount = cashback + loyaltyDiscount;
            if (totalDiscount > totalAmount * 0.10m)
                totalDiscount = totalAmount * 0.10m;

            decimal finalAmount = totalAmount - totalDiscount;

            Console.WriteLine("\n--- Рахунок ---");
            Console.WriteLine($"Сума покупки: {totalAmount:F2} грн");
            Console.WriteLine($"Кешбек: {cashback:F2} грн");
            Console.WriteLine($"Знижка по картці лояльності: {loyaltyDiscount:F2} грн");
            Console.WriteLine($"Загальна знижка: {totalDiscount:F2} грн");
            Console.WriteLine($"До сплати: {finalAmount:F2} грн");
            Console.WriteLine("-------------------");

            //3 
            Console.WriteLine("Введіть кількість спожитих кіловат-годин (кВт·год):");
            string input = Console.ReadLine();

          
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    Console.WriteLine("💥 Помилка: введено некоректне значення!");
                    return;
                }
            }

            
            double kWh = Convert.ToDouble(input);

            if (kWh < 0)
            {
                Console.WriteLine("💥 Помилка: кількість кВт·год не може бути від’ємною!");
                return;
            }

            double cost = 0;

           
            double firstTier = Math.Min(kWh, 100);
            cost += firstTier * 1.44;

           
            if (kWh > 100)
            {
                double secondTier = Math.Min(kWh - 100, 500);
                cost += secondTier * 1.68;
            }

           
            if (kWh > 600)
            {
                double thirdTier = kWh - 600;
                cost += thirdTier * 1.92;
            }

            Console.WriteLine($"Загальна вартість електроенергії: {cost:F2} грн");
        }
    }
}