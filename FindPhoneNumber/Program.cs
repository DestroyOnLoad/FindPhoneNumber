using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace FindPhoneNumber
{
    class Program
    {
        //EDIT THESE FILES PATHS FOR YOUR USAGE
        static readonly string readablePath = @"C:\Users\User\Desktop\someFile.csv";
        static string writablePath = @"C:\Users\User\Desktop\phoneNumberLookup.csv";


        static readonly Regex phoneNumRg = new Regex(@"\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})");

        //temp variable(s)
        static List<record> values = new List<record>();

        public class record
        {
            public string ProductId { get; set; }
            public string Url { get; set; }
            public string PhoneNumber { get; set; }
        }

        static void Main(string[] args)
        {
            ReadValuesFromFile();
            WritePhoneNumbersToFile();
            Console.WriteLine("Complete");
        }

        private static void WritePhoneNumbersToFile()
        {
            using (StreamWriter sw = File.CreateText(writablePath))
            {
                foreach (record v in values)
                {
                    sw.WriteLine($"{v.ProductId},{v.Url},{v.PhoneNumber}");
                    Console.WriteLine($"Writing {v.ProductId}");
                }
            }
        }

        private static void ReadValuesFromFile()
        {
            using (StreamReader sr = File.OpenText(readablePath))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    values.Add(new record {
                        ProductId = s.Split(',')[0],
                        Url = s.Substring(s.IndexOf(',')),
                        PhoneNumber = FindPhoneNumber(s)
                    });
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
