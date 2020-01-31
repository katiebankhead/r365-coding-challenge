using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/************Requirement #2**************/

namespace BankheadKatie_R365
{
    class Requirement1
    {
        static void Main(string[] args)
        {
            //declare vars
            double sum;

            //reset vars
            sum = 0;

            //get inputs and separate into array
            Console.WriteLine("Enter numbers separated by commas (ex '5,6'): ");
            string[] sAddends = Console.ReadLine().Split(',');

            //Requirement 1 error handling
            //iterate through string array
            for (int i = 0; i < sAddends.Length; i++)
            {
                //empty or missing numbers
                if (sAddends[i] == "" || sAddends[i] == ".")
                {
                    sAddends[i] = "0";
                }

                //invalid numbers (ex. entering letters or punctuation)
                string sInput = sAddends[i];

                foreach (char character in sInput)
                {
                    if ((!Char.IsNumber(character)) && (character != '.'))
                    {
                        sAddends[i] = "0";
                    }
                }
            }

            //convert from string to double
            double[] dAddends = Array.ConvertAll(sAddends, new Converter<string, double>(stringToDouble));

            //do the addition
            foreach (double addend in dAddends)
            {
                sum += addend;
            }

            Console.WriteLine("Sum: " + sum);

            Console.ReadKey();
        }

        public static double stringToDouble(string input)
        {
            double dResult = Convert.ToDouble(input);

            return dResult;
        }
    }
}