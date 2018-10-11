using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Endava.Internship2018;
using static Endava.Internship2018.RomanArabicConverter;

namespace RomanArabicConversionTest
{
    [TestClass]
    public class IsRomanTest
    {
        [TestMethod]
        public void NullValueThrowsException()
        {
            Assert.ThrowsException<RomanArabicConversionException>(() => IsRoman(null));
        }

        [TestMethod]
        public void VXNotRoman()
        {
            Assert.AreEqual(IsRoman("VX"), false);
        }

        [TestMethod]
        public void IXXNotRoman()
        {
            Assert.AreEqual(IsRoman("IXX"), false);
        }

        [TestMethod]
        public void CVIVNotRoman()
        {
            Assert.AreEqual(IsRoman("CVIV"), false);
        }

        [TestMethod]
        public void MCCVIXVIINotRoman()
        {
            Assert.AreEqual(IsRoman("MCCVIXVII"), false);
        }

        [TestMethod]
        public void EmptyStringIsRoman()
        {
            string roman = "";

            bool isRoman = IsRoman(roman);

            Assert.AreEqual(isRoman, true);
        }

        [TestMethod]
        public void VIsRoman()
        {
            string roman = "V";

            bool isRoman = IsRoman(roman);

            Assert.AreEqual(isRoman, true);
        }

        [TestMethod]
        public void IVIsRoman()
        {
            string roman = "IV";

            bool isRoman = IsRoman(roman);

            Assert.AreEqual(isRoman, true);
        }

        [TestMethod]
        public void XXIsRoman()
        {
            string roman = "XX";

            bool isRoman = IsRoman(roman);

            Assert.AreEqual(isRoman, true);
        }

        [TestMethod]
        public void MMXCIXIsRoman()
        {
            string roman = "MMXCIX";

            bool isRoman = IsRoman(roman);

            Assert.AreEqual(isRoman, true);
        }

        [TestMethod]
        public void MCCLXVIIIIsRoman()
        {
            string roman = "MCCLXVIII";

            bool isRoman = IsRoman(roman);

            Assert.AreEqual(isRoman, true);
        }

        [TestMethod]
        public void MMMCMXLIVIsRoman()
        {
            string roman = "MMMCMXLIV";

            bool isRoman = IsRoman(roman);

            Assert.AreEqual(isRoman, true);
        }
    }
}
