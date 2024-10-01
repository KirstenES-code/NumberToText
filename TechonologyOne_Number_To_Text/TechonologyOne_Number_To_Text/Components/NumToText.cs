using static System.Net.Mime.MediaTypeNames;

namespace TechonologyOne_Number_To_Text.Components
{
    public class NumToText
    {
        //Define dictionaries with text data
        private static readonly Dictionary<UInt128, string> SingleDigitText = new Dictionary<UInt128, string>
        {
            { 1, "ONE" },
            { 2, "TWO" },
            { 3, "THREE" },
            { 4, "FOUR" },
            { 5, "FIVE" },
            { 6, "SIX" },
            { 7, "SEVEN" },
            { 8, "EIGHT" },
            { 9, "NINE" }
        };

        private static readonly Dictionary<UInt128, string> DoubleDigitText = new Dictionary<UInt128, string>
        {
            { 2, "TWENTY" },
            { 3, "THIRTY" },
            { 4, "FOURTY" },
            { 5, "FIFTY" },
            { 6, "SIXTY" },
            { 7, "SEVENTY" },
            { 8, "EIGHTY" },
            { 9, "NINETY" },
        };

        private static readonly Dictionary<UInt128, string> TeenDigitText = new Dictionary<UInt128, string>
        {
            { 10, "TEN" },
            { 11, "ELEVEN" },
            { 12, "TWELVE" },
            { 13, "THIRTEEN" },
            { 14, "FOURTEEN" },
            { 15, "FIFTEEN" },
            { 16, "SIXTEEN" },
            { 17, "SEVENTEEN" },
            { 18, "EIGHTEEN" },
            { 19, "NINETEEN" }
        };

        private static readonly Dictionary<UInt128, string> DigitCountText = new Dictionary<UInt128, string>
        {
            { 1, "THOUSAND" },
            { 2, "MILLION" },
            { 3, "BILLION" },
            { 4, "TRILLION" },
            { 5, "QUADRILLION" },
            { 6, "QUINTILLION" },
            { 7, "SEXTILLION" },
            { 8, "SEPTILLION" },
            { 9, "OCTILLION" },
            { 10, "NONILLION" }
        };

        //Determines English words for 2 digit number
        private static string DoubleDigitToString(UInt128 number)
        {
            string output = "";
            if(number < 20) //Special case for teen numbers
            {
                output = TeenDigitText[number];
            }
            else
            {
                output += DoubleDigitText[number / 10];
                if(number % 10 != 0) { output += "-" + SingleDigitText[number % 10]; }
            }
            return output;
        }

        //Determines English words for 1-3 digit number
        private static string TripleDigitToString(UInt128 number, bool last)
        {
            string output = "";

            if( number > 99) //To allow for inputs to be any value
            {
                output += SingleDigitText[number / 100] + " HUNDRED";
            }
            if(number % 100 != 0) 
            {
                if(number > 99 || last)
                {
                    output += " AND ";
                }
                if (number % 100 < 10)
                {
                    output += SingleDigitText[number % 100];
                }
                else
                {
                    output += DoubleDigitToString(number % 100);
                }
            }

            return output;
        }

        //Splits inputted number into 3-digit segments to determine string
        private static string NumberToText(UInt128 number)
        {
            string output = "";
            UInt128 hold_num = number;
            uint comma_count = 0; //Used to determine thousands/millions etc

            //Create list for three digit segments of numbers. Virtually adds commas so it can be read same as English speech pattern
            List<UInt128> segments = new List<UInt128>();
            while (hold_num > 0)
            {
                segments.Add(hold_num % 1000);
                hold_num /= 1000;
            }

            //Reverse list to be in correct order
            segments.Reverse();

            comma_count = (uint) segments.Count() - 1; //Determines magnitude

            for(int i = 0; i < segments.Count(); i++)
            {
                if (segments[i] > 0)
                {
                    //Appends triple digit string of segment
                    //Conditional statement determines if this is the last of many segments
                    output += TripleDigitToString(segments[i], (i == segments.Count()-1 && segments.Count() > 1)) + " "; 
                    if (comma_count > 0) //If there are remaining segments, ie is some magnitude (thousand, million etc) Appends magnitude
                    {
                        output += DigitCountText[comma_count] + " ";
                    }
                }
                comma_count -= 1;
            }
            return output.Replace("  "," ");
        }

        public static string DollarsToText(decimal number)
        {
            string output = "";

            if (number == 0)
            {
                return "ZERO DOLLARS";
            }
            else if (number < 0)
            {
                return "NUMBER MUST BE ZERO OR GREATER";
            }

            UInt128 dollars = (UInt128)number; //Cast to int to remove cents
            UInt128 cents = (UInt128)((number%100)*100)%100; //Calculate cents (always 2 digits), % 100 to prevent number being too large for type

            if (dollars > 0)
            {
                output += NumberToText(dollars) + "DOLLAR";
                if (dollars > 1) { output += "S"; }
                if (cents > 0)
                {
                    output += " AND ";
                }
            }
            if(cents > 0)
            {
                output += NumberToText(cents) + "CENT";
                if (cents > 1) { output += "S"; }
            }

            return output;
        }
    }
}
