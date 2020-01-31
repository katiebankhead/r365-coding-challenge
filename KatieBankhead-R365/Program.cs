using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/************Requirement #6**************/
/**********and Stretch Goal 1************/

namespace BankheadKatie_R365
{
    class Requirement1
    {
        static void Main(string[] args)
        {
            //declare vars
            double sum = 0;
            List<double> dNegatives = new List<double>();
            string sFormula = ""; //for stretch goal 1
            string[] sDelimiters = { ",", "\\n", "," };

            //get inputs and separate into array
            Console.WriteLine("Enter numbers: ");

            //Step 6: determine custom char delimiter
            string sFullEntry = Console.ReadLine();

            //previous formats or requirement 6?
            if (sFullEntry.Substring(0, 2) == "//")
            {
                string sCustDelimiter = sFullEntry.Substring(2, 1);

                //replace third array value with the custom delimiter
                sDelimiters[2] = sCustDelimiter;

                //cut off string prefix
                //only numeric inputs remain
                sFullEntry = sFullEntry.Substring(5);
            }

            string[] sAddends = sFullEntry.Split(sDelimiters, System.StringSplitOptions.RemoveEmptyEntries);

            //Requirement 1 error handling
            //iterate through string array
            for (
                int i = 0; i < sAddends.Length; i++)
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
                    if ((!Char.IsNumber(character)) && (character != '.') && (character != '-'))
                    {
                        sAddends[i] = "0";
                    }
                }
            }

            //convert from string to double
            double[] dAddends = Array.ConvertAll(sAddends, new Converter<string, double>(stringToDouble));

            //Step 4: find negative numbers and deny
            //Step 5: make any value greater than 1000 an invalid number
            for (int i = 0; i < dAddends.Length; i++)
            {
                if (dAddends[i] < 0)
                {
                    //add to list of negative numbers
                    dNegatives.Add(dAddends[i]);
                }
                else if (dAddends[i] > 1000)
                {
                    dAddends[i] = 0;
                }
            }

            //if there are no negative numbers
            if (dNegatives.Count <= 0)
            {
                for (int i = 0; i < dAddends.Length; i++)
                {
                    //sum the numbers together
                    sum += dAddends[i];

                    //Stretch goal 1
                    if (i == (dAddends.Length - 1))
                    {
                        sFormula += Convert.ToString(dAddends[i]) + " = ";
                    }
                    else
                    {
                        sFormula += Convert.ToString(dAddends[i]) + " + ";
                    }
                }

                Console.WriteLine(sFormula + sum);
            }
            else
            {
                Console.WriteLine("You entered the following negative numbers:");

                foreach (double negative in dNegatives)
                {
                    Console.WriteLine(negative);
                }

                Console.WriteLine("No negative numbers are allowed.");
            }

            Console.ReadKey();
        }

        public static double stringToDouble(string input)
        {
            double dResult = Convert.ToDouble(input);

            return dResult;
        }
    }
}