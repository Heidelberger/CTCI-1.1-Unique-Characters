using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTCI_1._1_Unique_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cracking the Coding Interview");
            Console.WriteLine("Chapter 1, Problem 1.1");
            Console.WriteLine("Implement an algorithm to determine if a string has all unique characters");
            Console.WriteLine();

            //string with duplicates
            string string1_nonunique = "For example, the Mohawk word sahonwanhotónkwahse conveys as much";

            //string without duplicates (note the two double-quotes together to escape that character)
            string string2_unique = @"abcdefghijklmnopqrstuvwxyz0123456789 !@#$%^&*()[{]}|\+=?/-_;:'"",<.>";

            print_results(string1_nonunique);

            print_results(string2_unique);

            Console.ReadLine();
        }

        private static void print_results(string passed_string)
        {
            Console.WriteLine("string: " + passed_string);
            Console.WriteLine();

            //first, do it the .NET way:
            if (isunique_dotnet(passed_string))
                Console.WriteLine("Unique (.NET)");
            else
                Console.WriteLine("Non-unique (.NET)");

            //...and now manually
            if (isunique_bitArray(passed_string))
                Console.WriteLine("Unique (BitArray)");
            else
                Console.WriteLine("Non-unique (BitArray)");

            Console.WriteLine();
        }

        private static bool isunique_dotnet(string passed_string)
        {
            if (passed_string.Distinct().Count() == passed_string.Count())
            {
                return true;
            }

            return false;
        }

        private static bool isunique_bitArray(string passed_string)
        {
            // create look-up table for each possible character.  

            // Assuming UTF-16 = 1,112,064 possible characters
            BitArray bitArray = new BitArray(1112064, false);

            foreach (char thischar in passed_string)
            {
                // check if bit has been set in lookup table                
                if (bitArray[Convert.ToInt32(thischar)] == true)
                    return false;

                bitArray[Convert.ToInt32(thischar)] = true;
            }

            // no duplicate chars found
            return true;
        }
    }
}
