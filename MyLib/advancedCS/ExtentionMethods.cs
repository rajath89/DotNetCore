using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyLib.advancedCS
{
    public static class IntegerExtension
    {
        public static bool CheckEvenNumber(this int number)
        {
            if (number % 2 == 0)
                return true;
            else
                return false;
        }
    }

    public static class StringExtension
    {
        public static string ConvertToPascalCase(this string name)
        {
            string[] splittedProduct = name.Split(' ');
            var sb = new StringBuilder();
            char[] splittedProductChars;
            foreach (String s in splittedProduct)
            {
                splittedProductChars = s.ToCharArray();
                if (splittedProductChars.Length > 0)
                {
                    splittedProductChars[0] = ((new String(splittedProductChars[0], 1)).ToUpper().ToCharArray())[0];
                }
                sb.Append(new String(splittedProductChars));
                sb.Append(" ");
            }
            return sb.ToString().TrimEnd();
        }



        public static bool ValidatePassword(this string password) /* extension method defined to validate a password's format */
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
            if (hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMiniMaxChars.IsMatch(password) && hasLowerChar.IsMatch(password) && hasSymbols.IsMatch(password))
            {
                return true;
            }
            return false;
        }

        public static string CapitalizeLetter(this string input)
        {
            string[] words = input.Split(new char[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                {
                    char firstChar = char.ToUpper(words[i][0]);
                    string restOfWord = words[i].Substring(1).ToLower();
                    words[i] = firstChar + restOfWord;
                }
            }

            return string.Join(" ", words);
        }

        public static string UrlEncode(this string input)
        {
            return Regex.Replace(input, @"\s", "%20");
        }
    }

    public class Formatter
    {
        public Formatter() { }

        public string CapitalizeLetter(string input)
        {
            return input.CapitalizeLetter();
        }

        public string UrlEncode(string input)
        {
            return input.UrlEncode();
        }
    }

    public class Interview
    {
        public Interview(string name, string jobProfile, string suggestion, string portfolioUrl, int age, long phoneNumber)
        {
            Name = new Formatter().CapitalizeLetter(name);
            JobProfile = new Formatter().CapitalizeLetter(jobProfile);
            Suggestion = suggestion;
            PortfolioUrl = new Formatter().UrlEncode(portfolioUrl);
            Age = age;
            PhoneNumber = phoneNumber;
        }

        public int Age { get; set; }
        public string JobProfile { get; set; }
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string PortfolioUrl { get; set; }
        public string Suggestion { get; set; }
    }


    public class ExtentionMethods
    {
        public void TestEM()
        {

            //--example 1--
            int number = 234543;

            bool result = number.CheckEvenNumber();
            Console.WriteLine("Result = " + result);


            //--example2--
            string customerName = "julianna moore";
            string nameInPascalCase = customerName.ConvertToPascalCase();
            Console.WriteLine("Name in Pascal Case = " + nameInPascalCase);


            //--example3--
            string password = "Mark10@asdf";
            //After executing, comment above line and uncomment the line given below and then execute the code 
            //string password=" Mark";
            bool result2 = password.ValidatePassword();
            if (result2)
            {
                Console.WriteLine("Password is in proper format");
            }
            else
            {
                Console.WriteLine("Invalid password format");
            }

            //--example3--
            // Test case
            Interview interview = new Interview("ajaY malik. k", "developer", "Good interview.", "http://www.google.com/this is my sample", 30, 9876543210);

            Console.WriteLine("Formatted Name: " + interview.Name);
            Console.WriteLine("Formatted Job Profile: " + interview.JobProfile);
            Console.WriteLine("Formatted Portfolio URL: " + interview.PortfolioUrl);
            Console.WriteLine("Age: " + interview.Age);
            Console.WriteLine("Phone Number: " + interview.PhoneNumber);
            Console.WriteLine("Suggestion: " + interview.Suggestion);


        }
    }
}
