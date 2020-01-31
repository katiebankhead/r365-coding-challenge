using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/***************************************
 * Name: Katie Bankhead
 * Date: 1/31/2020
 * Desc: This is a calculator console program for the Restaurant365 coding challenge.
 * ************************************/

/************Requirement #1**************/

namespace BankheadKatie_R365
{
    class Program
    {
        static void Main(string[] args)
        {
            //declare vars
            bool loop;
            double sum;

            do
            {
                //reset vars
                loop = false;
                sum = 0;

                //get inputs and separate into array
                Console.WriteLine("Enter up to two numbers to add, separated by commas (ex '5,6'): ");
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

                //throw an exception when more than 2 numbers are provided
                //if inputs > 2, the user will be re-prompted
                if (dAddends.Length > 2)
                {
                    loop = true;
                }

                if (loop == true)
                {
                    Console.WriteLine("Too many inputs. Please try again.");
                }

            }
            while (loop == true);

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
