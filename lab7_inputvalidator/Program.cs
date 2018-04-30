using System;
using System.Text.RegularExpressions;

namespace lab7_inputvalidator
{
    class Program
    {
        /* Contains a method that will validate names.
         * Names can only have alphabetical characters, should start with a cap.
         * letter and can only have a max length of 30.
         * 
         * A method that will validate emails. {alphanumeric characters, length
         * between 5 and 30, no special characters} @ {combination of alphanumeric
         * characters, between 5 and 10 chars, no spec. characters. .domain can
         * be alphanumeric characters with a length of two or three.
         * 
         * A method that will valid phone numbers.  A phone number should be in
         * the format of {area code 3 digits}-{3 digits}-{4 digits}.
         * 
         * Method that will validate date based on the format of dd/mm/yyyy.
         * 
         * use regexr.com
         * 
         * ex challenges: method for validating html elements.  (<p> and </p>
         * are valid element formats.  <h1 <h1> are not,  dont worry about 
         * special cases.
         * 
         * God speed. */

        static void Main(string[] args)
        {
            NameChecker();
            EmailChecker();
            PhoneNumberChecker();
            DateChecker();

        }


        /* checks for valid name */
        static bool NameChecker()
        {
            Console.WriteLine("Please enter a valid name containing only letters:  ");

            while (true)
            {
                string userinput = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(userinput) == true)
                {
                    Console.WriteLine("Sorry, that name is invalid!");
                    Console.WriteLine("Please enter a valid name:  ");
                    continue;
                }
                else
                { }

                string firstletterofinput = userinput.Substring(0, 1);

                if (String.IsNullOrWhiteSpace(userinput) == false
                    && Regex.IsMatch(userinput, @"^[a-zA-Z]+$")
                    && userinput.Length <= 30
                    && firstletterofinput.ToUpper() == firstletterofinput)
                {
                    Console.WriteLine("Valid Name Accepted.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Sorry, that name is invalid!");
                    Console.WriteLine("Please enter a valid name:  ");
                    continue;
                }
            }
        }

        static bool EmailChecker()
        {
            Console.WriteLine("Please enter a valid email in the following format:  example@example.com ");
            while (true)
            {
                string useremail = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(useremail) == true 
                    || useremail.Length < 14)
                {
                    Console.WriteLine("Sorry, that email is invalid!");
                    Console.WriteLine("Please enter a valid email:  ");
                    continue;
                }
                else
                {}

                string username = useremail.Split('@')[0];
                string dompreformat = useremail.Split('@')[1];
                string dompostformat = dompreformat.Split('.')[0];
                string suffix = useremail.Split('.')[1];

                if (useremail.Contains("@")
                    && Regex.IsMatch(username, @"^[\p{L}\p{N}]+$")
                    && username.Length > 4 && username.Length < 31
                    && Regex.IsMatch(dompostformat, @"^[\p{L}\p{N}]+$")
                    && dompostformat.Length > 4 && username.Length < 11
                    && Regex.IsMatch(suffix, @"^[\p{L}\p{N}]+$")
                    && suffix.Length > 1 && suffix.Length < 4)
                {
                    Console.WriteLine("Valid Email Accepted.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Sorry, that email is invalid!");
                    Console.WriteLine("Please enter a valid email:  ");
                    continue;
                }
            }
        }

        static bool PhoneNumberChecker()
        {
            Console.WriteLine("Please enter a valid phone number in the following format:  555-555-5555");
            while (true)
            {
                string usernumber = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(usernumber) == true
                    || usernumber.Length != 12)
                {
                    Console.WriteLine("Sorry, that phone number is invalid!");
                    Console.WriteLine("Please enter a valid phone number:  ");
                    continue;
                }
                else{}

                string phonep0 = usernumber.Split("-")[0];
                string phonep1 = usernumber.Split("-")[1];
                string phonep2 = usernumber.Split("-")[2];

                if (phonep0.Length == 3 
                    && phonep1.Length == 3
                    && phonep2.Length == 4
                    && Regex.IsMatch(phonep0, "^[0-9]+$")
                    && Regex.IsMatch(phonep1, "^[0-9]+$")
                    && Regex.IsMatch(phonep2, "^[0-9]+$"))
                {
                    Console.WriteLine("Valid Number Accepted.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Sorry, that phone number is invalid!");
                    Console.WriteLine("Please enter a valid phone number:  ");
                    continue;  
                }

            }
        }

        static bool DateChecker()
        {
            Console.WriteLine("Please enter a valid date in the following format:  mm/mm/mmmm");
            while (true)
            {
                string userdate = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(userdate) == true
                    || userdate.Length != 10)
                {
                    Console.WriteLine("Sorry, that date is invalid!");
                    Console.WriteLine("Please enter a valid date:  ");
                    continue;
                }
                else { }

                string date0 = userdate.Split("/")[0];
                string date1 = userdate.Split("/")[1];
                string date2 = userdate.Split("/")[2];

                if (date0.Length == 2
                    && date1.Length == 2
                    && date2.Length == 4
                    && Regex.IsMatch(date0, "^[0-9]+$")
                    && Regex.IsMatch(date1, "^[0-9]+$")
                    && Regex.IsMatch(date2, "^[0-9]+$"))
                {
                    Console.WriteLine("Valid Date Accepted.");
                    return true;   
                }
                else
                {
                    Console.WriteLine("Sorry, that date is invalid!");
                    Console.WriteLine("Please enter a valid date:  ");
                    continue;  
                }

 
            }
        }
    }
}
