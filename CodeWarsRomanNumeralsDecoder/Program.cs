using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarsRomanNumeralsDecoder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution("XXI"));
            Console.WriteLine(Solution2("XIX"));
            Console.ReadKey();
        }

        public static int Solution(string rim)
        {
            int summa = 0;
            for (int i = 0; i < rim.Length; i++)
            {
                if (i < rim.Length - 1 && rim[i] == 'I' && rim[i + 1] != 'I') continue;
                else if (rim[i] == 'I')
                    summa += 1;
                else if (rim[i] == 'V')
                {
                    if (i > 0 && rim[i - 1] == 'I') summa += 4;
                    else summa += 5;
                }
                else if (rim[i] == 'X')
                {
                    if (i > 0 && rim[i - 1] == 'I') summa += 9;
                    else if (i < rim.Length - 1 && (rim[i + 1] == 'L' || rim[i + 1] == 'C')) continue;
                    else summa += 10;
                }
                else if (rim[i] == 'L')
                {
                    if (i > 0 && rim[i - 1] == 'X') summa += 40;
                    else summa += 50;
                }
                else if (rim[i] == 'C')
                {
                    if (i > 0 && rim[i - 1] == 'X') summa += 90;
                    else if (i < rim.Length - 1 && (rim[i + 1] == 'D' || rim[i + 1] == 'M')) continue;
                    else summa += 100;
                }
                else if (rim[i] == 'D')
                {
                    if (i > 0 && rim[i - 1] == 'C') summa += 400;
                    else summa += 500;
                }
                else if (rim[i] == 'M')
                {
                    if (i > 0 && rim[i - 1] == 'C') summa += 900;
                    else summa += 1000;
                }
            }
            return summa;
        }

        public static int Solution2(string roman)
        {
            Dictionary<string, int> ra = new Dictionary<string, int>
            {
                { "M", 1000 },        
                { "D", 500 },         
                { "C", 100 },        
                { "L" , 50 },         
                { "X" , 10 },            
                { "V" , 5 },           
                { "I" , 1 }
            };
            roman = roman.Replace("CM", "DCCCC")
                     .Replace("CD", "CCCC")
                     .Replace("XC", "LXXXX")
                     .Replace("XL", "XXXX")
                     .Replace("IX", "VIIII")
                     .Replace("IV", "IIII");
            int result = 0;
            foreach (var letter in roman)
            {
                result += ra[letter.ToString()];
            }
            return result;
        }
    }
}
