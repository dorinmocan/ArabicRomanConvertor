using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Endava.Internship2018.RomanArabicConverter;

namespace RomanArabicConversionTest
{
    [TestClass]
    public class ArabicToRomanTest
    {
        [TestMethod]
        public void ZeroConverted()
        {
            uint arabic = 0;

            string roman = ToRoman(arabic);

            Assert.AreEqual("", roman);
        }

        [TestMethod]
        public void PositiveNumberConverted()
        {
            uint arabic = 2479;

            string roman = ToRoman(arabic);

            Assert.AreEqual("MMCDLXXIX", roman);
        }

        [TestMethod]
        public void MaxPositiveNumberConverted()
        {
            uint arabic = uint.MaxValue;

            string roman = ToRoman(arabic);
            bool isRoman = IsRoman(roman);

            Assert.AreEqual(isRoman, true);
        }

        [TestMethod]
        public void MinPositiveNumberConverted()
        {
            uint arabic = uint.MinValue;

            string roman = ToRoman(arabic);
            bool isRoman = IsRoman(roman);

            Assert.AreEqual(isRoman, true);
        }
    }
}
