using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter numbers: ");
            string[] inputNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            char symbol = inputNumbers[0].First(x => x == ',' || x == '.');

            Regex regex = new Regex(@"^\d+(\.|\,)\d+$");
            List<double> numbersToBeFiltered = new List<double>();
            foreach (var number in inputNumbers)
            {
                if (regex.IsMatch(number))
                {
                    string temp = number.Replace(',', '.');
                    numbersToBeFiltered.Add(double.Parse(temp));
                }                                   
            }
            Console.WriteLine("Numerical system: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbersToBeFiltered.Count; i++)
            {
                Console.WriteLine($"In {n} numeric system: {inputNumbers[i]} -> {SetCorrectSymbol(ConvertNumber(n, numbersToBeFiltered[i].ToString(),symbol),symbol)}");
            }



        }
        private static string SetCorrectSymbol(string number, char sym)
        {
            return number.Replace('.' , sym);
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private static string ConvertNumber(int n, string number, char sym)
        {
            string[] numberParts = number.ToString().Split('.');
            string part1 = string.Empty;
            string part2 = string.Empty;

            switch (n)
            {
                case 2:
                case 16:
                case 8:
                    part1 = Convert.ToString(int.Parse(numberParts[0]), n);
                    part2 = Convert.ToString(int.Parse(numberParts[1]), n);
                    return $"{part1}{sym}{part2}";
                    break;
                case 10:
                    return number;
                case 5:
                    
                    int number1 = int.Parse(numberParts[0]);
                    int number2 = int.Parse(numberParts[1]);
                    string result1 = string.Empty;
                    string result2 = string.Empty;
                    
                    while (number1 != 0)
                    {
                        result1 += number1 % 5;
                        number1 = number1 / 5;
                    
                    }
                    while (number2 != 0)
                    {
                        result2 += number2 % 5;
                        number2 = number2 / 5;

                    }

                     result1 = Reverse(result1);
                     result2 = Reverse(result2);


                    return $"{result1}{sym}{result2}";

                    break;
            }
            return "Numerical system not supported";

        }

        
    }
}
