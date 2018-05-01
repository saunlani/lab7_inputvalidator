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
         * a method for validating html elements.  (<p> and </p>
         * are valid element formats.  <h1 <h1> are not,  dont worry about 
         * special cases. */

        static void Main(string[] args)
        {
            Chooser();
        }

        // menu for the various checkers.
        static void Chooser()
        {
            bool keepgoing = true;
            while (keepgoing == true)
            {
                Console.WriteLine("1.) NameChecker");
                Console.WriteLine("2.) EmailChecker");
                Console.WriteLine("3.) PhoneNumberChecker");
                Console.WriteLine("4.) DateChecker");
                Console.WriteLine("5.) EmailChecker");
                Console.WriteLine("6.) HtmlChecker");
                Console.WriteLine("Enter anything else to quit.");


                string userchoice = Console.ReadLine();

                if (userchoice == "1")
                {
                    do
                    {
                        NameChecker();
                    } while (AskToInputAgain());
                }

                else if (userchoice == "2")
                {
                    do
                    {
                        EmailChecker();
                    } while (AskToInputAgain());
                }

                else if (userchoice == "3")
                {
                    do
                    {
                        PhoneNumberChecker();
                    } while (AskToInputAgain());
                }

                else if (userchoice == "4")
                {
                    do
                    {
                        DateChecker();
                    } while (AskToInputAgain());
                }

                else if (userchoice == "5")
                {
                    do
                    {
                        EmailChecker();
                    } while (AskToInputAgain());
                }
                else if (userchoice == "6")
                {
                    do
                    {
                        HtmlChecker();
                    } while (AskToInputAgain());
                }
                else
                {
                    keepgoing = false;
                }
            }
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

        //checks for valid email.
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
                { }

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

        //checks for valid phone number.
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
                else { }

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

        //checks for valid date.
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

        //checks for valid html.
        static bool HtmlChecker()
        {
            while (true)
            {
                Console.WriteLine("Please enter a valid HTML element which follows the format of <ex> or </ex>:  ");
                string userhtml = Console.ReadLine();
                string[] indichunks = userhtml.Split(' ');
                int validinputs = 0;
                int numchunks = indichunks.Length;
                /* checks the length of each chunk to verify it's at least 
              * 3 charcters */
                if (numchunks != 2 
                    || indichunks[0].Length < 3
                    || indichunks[1].Length < 3)
                {
                    continue;
                }
                else
                {
                    numchunks += 1; 
                    // matches content of the start and end tags
                    string trimmed1 = indichunks[0].TrimStart('<').TrimEnd('>');
                    string trimmed2 = indichunks[1].TrimStart('<').TrimStart('/').TrimEnd('>');

                    bool Matcher = true;
                    if (trimmed1 == trimmed2)
                    {
                        Matcher = true;
                    }
                    else
                    {
                        Matcher = false;
                    }

                    /* collects info on first and last place of the chunk */
                    string firstplaceofinput = indichunks[0].Substring(0, 1);
                    string lastplaceofinput = indichunks[0].Substring(indichunks[0].Length - 1);
                    string secondplaceinput = indichunks[0].Substring(1, 1);

                    if (firstplaceofinput != "<" || lastplaceofinput != ">" || Matcher == false)
                    {
                        continue;
                    }
                    else
                    {
                        validinputs += 1;
                        string firstplaceofinput2 = indichunks[1].Substring(0, 1);
                        string lastplaceofinput2 = indichunks[1].Substring(indichunks[1].Length - 1);
                        string secondplaceinput2 = indichunks[1].Substring(1, 1);

                        if (firstplaceofinput2 != "<" || lastplaceofinput2 != ">"
                            || secondplaceinput2 !="/")

                        {
                            continue;
                        }
                        else
                        {
                            validinputs += 1;
                        }
                            if (validinputs == 2)
                        {
                            Console.WriteLine("Valid elements accepted.");
                            return false;
                        }
                        else
                        {
                        }
                    }


                }
            }

        }

        //asks for another input from user.
        static bool AskToInputAgain()
        {
            do
            {
                Console.Write("\nEnter another input? (y/n):  ");
                string userresponse = Console.ReadLine().ToLower();
                Console.WriteLine("");


                if (userresponse == "y")
                {
                    return true;
                }
                else if (userresponse == "n")
                {
                    return false;
                }
                else if (userresponse != "y" && userresponse != "n")
                {
                    Console.Write("You did not enter a valid response.\n");
                    continue;
                }
                else
                {
                    return false;
                }
            } while (true);
        }
    }
}

