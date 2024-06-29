//#define WPFApp
#define ConsoleApp

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Validator
{
    static class Validator
    {

        #region One Or Two

#if ConsoleApp
        public static int OneOrTwo(string message1, string message2, string message3 = "", bool cancelable = true)
        {
            string questionString = $@"1. {message1}
2. {message2}";
            if (message3 != "")
            {
                questionString = $"{message3}\n{questionString}";
            }
            if (cancelable) 
            {
                questionString += "\n3. Cancel";
            }

            string? input = null;
            int output = -1;
            while (input == null || !int.TryParse(input, out output) || output > 2 || output < 1)
            {
				if (output == 3 && cancelable) 
				{
					return 3;
				}
                Console.Clear();
                Console.WriteLine(questionString);
                input = Console.ReadLine();
            }

            return output;
        }
#elif WPFApp

        public static int OneOrTwo(string message1, string message2, string message3 = "", bool cancelable = true)
        {

            Validator_OneOrTwo v = new Validator_OneOrTwo(message1, message2, message3, cancelable);
            v.ShowDialog();
            int output = v.Output;

            return output;
        }

#endif

        #endregion

        #region Basic String

        public static bool CheckString(string? input)
        {

            if (CheckString == null || !input.Any(Char.IsLetterOrDigit))
            {
                return false;
            }

            return true;
        }

        public static string GetString(string message)
        {
            string? input = null;

            while (!Validator.CheckString(input))
            {
                Console.Clear();
                Console.Write($"{message} (string): ");
                input = Console.ReadLine();
            }

            return input;
        }

        #endregion

        #region Basic Int

        public static Tuple<bool, int> CheckInt(string? input, int Min = 0, int Max = 0)
        {
            int outputInt = -1;
            bool outputBool = true;

            bool test1 = Max != 0;
            bool test2 = int.Parse(input) <= Max;
            bool test3 = (Max != 0 && int.Parse(input) <= Max);
            bool test4 = !(Max != 0 && int.Parse(input) <= Max);

            if (input == null || !int.TryParse(input, out outputInt) || outputInt < Min || (Max != 0 && outputInt <= Max))
            {
                outputBool = false;
            }
            return new Tuple<bool, int>(outputBool, outputInt);
        }

#if ConsoleApp
        public static int GetInt(string message, int Max, int Min = 0)
        {
            string? input = null;
            Tuple<bool, int> output = new Tuple<bool, int>(false, -1);

            string localMessage = Max == 0 ? $"{message} (int)" : $"{message} ({Max}, int)";

            while (!output.Item1)
            {
                Console.Clear();
                Console.Write($"{localMessage}: ");
                input = Console.ReadLine();

                output = Validator.CheckInt(input, Min: Min, Max: Max);
            }

            return output.Item2;
        }
#elif WPFApp
        public static int GetInt(string message, int Min=0, int Max = 0)
        {

            int output = -1;

            Validator_GetInt v = new Validator_GetInt(message, Min, Max);
            v.ShowDialog();
            output = v.Output;

            return output;
            
        }
#endif

        #endregion

        #region Date Stuff

        public static DateOnly GetDate()
        {
            int CurrentOrCustom = Validator.OneOrTwo("Set Date Time to Current", "Custom Date Time", cancelable: false);

            if (CurrentOrCustom == 1) 
            {
                return DateOnly.FromDateTime(DateTime.Now);
            }

            string? outTime = null;
            DateOnly OutTime;

            while (outTime == null || !DateOnly.TryParse(outTime, out OutTime))
            {
                Console.Clear();
                Console.Write("Give Date and Time (MM-DD-YYYY HH:MM:SS): ");
                outTime = Console.ReadLine();
            }

            return OutTime;
        }

        public static DateTime GetDateTime()
        {
            int CurrentOrCustom = Validator.OneOrTwo("Set Date Time to Current", "Custom Date Time", cancelable: false);

            if (CurrentOrCustom == 1) 
            {
                return DateTime.Now;
            }

            DateTime OutTime;
            string? outTime = null;

            while (outTime == null || !DateTime.TryParse(outTime, out OutTime))
            {
                Console.Clear();
                Console.Write("Give Date and Time (MM-DD-YYYY HH:MM:SS): ");
                outTime = Console.ReadLine();
            }

            return OutTime;
        }

        #endregion

        #region Double Stuff

        public static Tuple<bool, double> CheckDouble(string? input, double Min = 0, double Max = 0)
        {
            double outputDouble = -1;
            bool outputBool = true;

            if (input == null || !double.TryParse(input, out outputDouble) || outputDouble < Min || !(Max != 0 && outputDouble <= Max))
            {
                outputBool = false;
            }
            return new Tuple<bool, double>(outputBool, outputDouble);
        }
        

        public static double GetDouble(string message, double Min = 0, double Max = 0)
        {
            string? input = null;
            double output = -1;
            Tuple<bool, double> t = new Tuple<bool, double>(false, -1);

            while (t.Item1)
            {
                Console.Clear();
                Console.Write($"{message} (int): ");
                input = Console.ReadLine();

                t = Validator.CheckDouble(input);
            }

            return output;
        }

        #endregion

        #region Email Stuff

        public static bool CheckEmail(string? input)
        {

            if (input == null || !input.Contains("@") || !input.Contains("."))
            {
                return false;
            }

            return true;
        }

        public static String GetEmail()
        {
            string? input = null;

            while (!Validator.CheckEmail(input))
            {
                input = Validator.GetString("Email");
            }

            return input;
        }

        #endregion
    }
}
