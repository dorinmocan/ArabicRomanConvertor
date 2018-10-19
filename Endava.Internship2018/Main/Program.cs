using System;
using System.Text;
using static System.Console;
using static Endava.Internship2018.RomanArabicConverter;

namespace Main 
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Export();     
        }

        private static void Export()
        {
            string outputFilePath = @"..\..\ArabicRomanMap.txt";
            uint maxNumber = 3999;
            string numberSeparator = ":";

            WriteLine("Exporting arabic-roman map to file " + System.IO.Path.GetFullPath(outputFilePath));
            ExportArabicToRomanMap(outputFilePath, maxNumber, numberSeparator);
            Write("Press any key to continue...");
            ReadLine();
        }

        private static void ExportArabicToRomanMap(string outputFilePath,
                                                   uint maxNumber,
                                                   string numberSeparator)
        {
            StringBuilder output = new StringBuilder("");

            string maxDigits = maxNumber.ToString().Length.ToString();

            for (uint param = 0; param <= maxNumber; param++)
            {
                output.Append(string.Format($"{{0, {maxDigits}}}", ToArabic(ToRoman(param))) + 
                              numberSeparator + 
                              ToRoman(param) +
                              Environment.NewLine);
            }
            
            System.IO.File.WriteAllText(outputFilePath, output.ToString());
        }
    }
}
