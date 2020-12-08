using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace FindPhoneNumber
{
    class Program
    {
        //EDIT THESE FILES PATHS FOR YOUR USAGE
        static readonly string readablePath = @"C:\Desktop\someFile.csv";
        static string writablePath = @"C:\Desktop\phoneList.csv";


        static readonly Regex phoneNumRg = new Regex(@"\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})");

        //temp variable(s)
        static List<string> values = new List<string>();

        static void Main(string[] args)
        {
            ReadValuesFromFile();
            ReplaceValuesWithPhoneNumbers();
            WritePhoneNumbersToFile();
            Console.WriteLine("Complete");
        }

        private static void WritePhoneNumbersToFile()
        {
            using (StreamWriter sw = File.CreateText(writablePath))
            {
                foreach (string v in values)
                {
                    sw.WriteLine(v);
                    Console.WriteLine($"Writing {v}");
                }
            }
        }

        private static void ReplaceValuesWithPhoneNumbers()
        {
            for (int i = 0; i < values.Count; i++)
            {
                values[i] = FindPhoneNumber(values[i]);
            }
        }

        private static void ReadValuesFromFile()
        {
            using (StreamReader sr = File.OpenText(readablePath))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    values.Add(s);
                }
            }
        }

        private static string FindPhoneNumber(string s)
        {
            if (String.IsNullOrWhiteSpace(s)) return "";

            Match result = phoneNumRg.Match(s.Contains(" ") ? RemoveWhiteSpace(s): s);

            return result.Value;
        }

        private static string RemoveWhiteSpace(string s)
        {
            return Regex.Replace(s, @"\s+", "");
        }
    }
}
