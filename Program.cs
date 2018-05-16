using MissingNumbers.Model;
using MissingNumbers.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MissingNumbers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            NumberService numerService = new NumberService();
            List<Numbers> n = new List<Numbers>();
            List<Numbers> m = new List<Numbers>();
            try
            {
                Console.WriteLine("Out number of fisrt list");
                int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));

                Console.WriteLine("Out number of second list");
                int[] brr = Array.ConvertAll(Console.ReadLine().Split(' '), brrTemp => Convert.ToInt32(brrTemp));
                if (brr.Length <= arr.Length)
                {
                    Console.WriteLine("firt arr is higher second brr");

                    Console.WriteLine("esc para salir");
                    if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                        Environment.Exit(0);
                    Console.ReadLine();
                }

                Console.WriteLine("enter to process...");
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    foreach (int numberA in arr)
                    {
                        numerService.Add(numberA, n);
                    }
                    foreach (int numberB in brr)
                    {
                        numerService.Add(numberB, m);
                    }
                    List<int> validArr = numerService.ValidateRangeNumber(n, 0, 10000);
                    if (validArr.Count > 0)
                    {
                        string number = string.Join(" ", validArr.ToList());
                        Console.WriteLine($"this number not is valid {number} of first list");
                        Console.ReadLine();
                    }
                    List<int> validbrr = numerService.ValidateRangeNumber(m, 0, 10000);
                    if (validbrr.Count > 0)
                    {
                        string number = string.Join(" ", validbrr.ToList());
                        Console.WriteLine($"this number not is valid {number} of second list");
                        Console.ReadLine();
                    }
                    if (numerService.ValidateMinMax(m, 101))
                    {
                        Console.WriteLine("the operation max - min is > 101");
                        Console.ReadLine();
                    }
                    else
                    {
                        List<int> numbers = numerService.MissingNumber(n, m);
                        if (numbers.Count == 0)
                        {
                            Console.WriteLine("No found number");
                            Console.ReadLine();
                        }

                        string listNumber = string.Join(" ", numbers.ToList());
                        Console.WriteLine($"number: {listNumber}");
                        Console.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}