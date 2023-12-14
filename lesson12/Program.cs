using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lesson12
{
    internal class Program
    {
        static void CountNumbers()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
        }
        static long Factorial(int number)
        {
            long result = 1;
            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }

        static int Square(int number)
        {;
            return number * number;
        }
        static async Task CalculateAsync(int number)
        {
            Console.WriteLine($"Квадрат числа: {Square(number)}");
            Thread.Sleep(8000);
            Console.WriteLine($"Факториал числа: {await Task.Run(() => Factorial(number))}.\n");
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Задача 1. В программе реализовано три потока, каждый из которых выводит числа от 1 до 10.\n");
            Thread thread1 = new Thread(CountNumbers);
            Thread thread2 = new Thread(CountNumbers);
            Thread thread3 = new Thread(CountNumbers);
            thread1.Start();
            thread2.Start();
            thread3.Start();
            Console.ReadKey();


            Console.WriteLine("Задача 2. Вычисление факториала асинхронно, вычисление возведения в квадрат синхронно.\n");
            Console.WriteLine("Введите число: ");
            string input = Console.ReadLine();
            int number;
            bool result = int.TryParse(input, out number);
            if (!result)
            {
                Console.WriteLine("Введите число!");
            }
            CalculateAsync(number);
            Console.ReadKey();

            Console.WriteLine("Задача 3. Возвращение названия всех методов, котрые были найдены для объекта.\n");
            Type type = typeof(Refl);
            MethodInfo[] methods = type.GetMethods();
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
            }
            Console.ReadKey();
        }
    }
}
