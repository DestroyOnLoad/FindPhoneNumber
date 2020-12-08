using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace FindPhoneNumber
{
    class Program
    {
        static readonly string readablePath = @"C:\Users\PCMiner1\Desktop\Dietary Supplements\All Products\id-url_Lookup.csv";
        static string writablePath = @"C:\Users\PCMiner1\Desktop\Dietary Supplements\All Products\phoneList.csv";

        static Regex phoneNumRg = new Regex(@"\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})");

        //temp variables
        static List<string> values = new List<string>();  //will store full strings read and be rewritten with phone number value;

        static void Main(string[] args)
        {
            //take in a list of strings possibly containing phone numbers from csv file
            using (StreamReader sr = File.OpenText(readablePath))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }

            //replace each element in the list with the result of find phone number

            //export the list to a new csv file [or new row in original csv file];
        }

        static string FindPhoneNumber(string s)
        {
            if (String.IsNullOrWhiteSpace(s)) return "";

            Match result = phoneNumRg.Match(s.Contains(" ") ? RemoveWhiteSpace(s): s);

            return result.Value;
        }

        static string RemoveWhiteSpace(string s)
        {
            return Regex.Replace(s, @"\s+", "");
        }
    }
}
