using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Endava.Internship2018
{
    public static class RomanArabicConverter
    {
        private static readonly Dictionary<string, ushort> RomanToArabicMap;
        private static readonly Dictionary<ushort, string> ArabicToRomanMap;

        static RomanArabicConverter()
        {
            RomanToArabicMap = new Dictionary<string, ushort>
            {
                { "M", 1000 },
                { "CM", 900 },
                { "D", 500 },
                { "CD", 400 },
                { "C", 100 },
                { "XC", 90 },
                { "L", 50 },
                { "XL", 40 },
                { "X", 10 },
                { "IX", 9 },
                { "V", 5 },
                { "IV", 4 },
                { "I", 1 },
            };

            ArabicToRomanMap = new Dictionary<ushort, string>
            {
                { 1000, "M" },
                { 900, "CM" },
                { 500, "D" },
                { 400, "CD" },
                { 100, "C" },
                { 90, "XC" },
                { 50, "L" },
                { 40, "XL" },
                { 10, "X" },
                { 9, "IX" },
                { 5, "V" },
                { 4, "IV" },
                { 1, "I" },
            };
        }

        public static bool IsRoman(string roman)
        {
            if (roman == null)
            {
                throw new RomanArabicConversionException("Null value passed to method '" +
                                                         System.Reflection.MethodBase.GetCurrentMethod().Name + "'");
            }

            if (Regex.Replace(roman, "[MDCLXVI]", string.Empty) != "") return false;

            int romanLength = roman.Length;
            if (romanLength < 2) return true;

            if (roman.Contains("IIII") || roman.Contains("XXXX") || roman.Contains("CCCC") ||
                roman.Contains("VV") || roman.Contains("LL") || roman.Contains("DD")) return false;

            uint priorToPrevious;
            uint previous;
            uint current;
            ushort dummy;

            for (int i = 1; i < romanLength; i++)
            {
                previous = RomanToArabicMap[roman[i - 1].ToString()];
                current = RomanToArabicMap[roman[i].ToString()];

                if (current > previous)
                {
                    if (!RomanToArabicMap.TryGetValue(roman[i-1] + "" + roman[i], out dummy)) return false;

                    if (i >= 2)
                    {
                        priorToPrevious = RomanToArabicMap[roman[i - 2].ToString()];

                        // detecting VIX and similar cases
                        if (current > priorToPrevious) return false;

                        // detecting VIV and similar cases
                        if (current == priorToPrevious)
                        {
                            if (roman[i] == 'D' || roman[i] == 'L' || roman[i] == 'V') return false;
                        }
                    }

                    // detecting VXX and similar cases
                    for (int j = i + 1; j < romanLength; j++)
                    {
                        if (RomanToArabicMap[roman[j].ToString()] >= current) return false;
                    }
                }
            }

            return true;
        }

        public static uint ToArabic(string roman)
        {
            if(!IsRoman(roman))
            {
                throw new RomanArabicConversionException("Invalid roman number passed to method '" +
                                                         System.Reflection.MethodBase.GetCurrentMethod().Name + "'");
            }
            
            uint arabic;
            int romanLength = roman.Length;

            switch (romanLength)
            {
                case 0:
                    arabic = 0;
                    break;

                case 1:
                    arabic = RomanToArabicMap[roman[0].ToString()];
                    break;

                default:
                    arabic = 0;

                    for (int i = 0; i < romanLength; i++)
                    {
                        if (i < romanLength - 1 && 
                            RomanToArabicMap[roman[i].ToString()] < RomanToArabicMap[roman[i + 1].ToString()])
                        {
                            checked
                            {
                                arabic += RomanToArabicMap[roman[i] + "" + roman[i + 1]];
                            }

                            i++;
                        }
                        else
                        {
                            checked
                            {
                                arabic += RomanToArabicMap[roman[i].ToString()];
                            }
                        }
                    }

                    break;
            }
            
            return arabic;
        }

        public static string ToRoman(uint arabic)
        {
            StringBuilder roman = new StringBuilder();

            foreach (var item in ArabicToRomanMap)
            {
                while (arabic >= item.Key)
                {
                    roman.Append(item.Value);
                    arabic -= item.Key;
                }
            }

            return roman.ToString();
        }
    }
}