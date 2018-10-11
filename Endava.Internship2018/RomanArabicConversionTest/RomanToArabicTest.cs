using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Endava.Internship2018;
using static Endava.Internship2018.RomanArabicConverter;

namespace RomanArabicConversionTest
{
    [TestClass]
    public class RomanToArabicTest
    {
        [TestMethod]
        public void NullValueThrowsException()
        {
            Assert.ThrowsException<RomanArabicConversionException>(() => ToArabic(null));
        }

        [TestMethod]
        public void VXThrowsException()
        {
            Assert.ThrowsException<RomanArabicConversionException>(() => ToArabic("VX"));
        }

        [TestMethod]
        public void IXXThrowsException()
        {
            Assert.ThrowsException<RomanArabicConversionException>(() => ToArabic("IXX"));
        }

        [TestMethod]
        public void CVIVThrowsException()
        {
            Assert.ThrowsException<RomanArabicConversionException>(() => ToArabic("CVIV"));
        }

        [TestMethod]
        public void MCCVIXVIIThrowsException()
        {
            Assert.ThrowsException<RomanArabicConversionException>(() => ToArabic("MCCVIXVII"));
        }

        [TestMethod]
        public void EmptyStringIsZero()
        {
            string roman = "";

            uint arabic = ToArabic(roman);

            Assert.AreEqual(arabic, (uint)0);
        }

        [TestMethod]
        public void VIsFive()
        {
            string roman = "V";

            uint arabic = ToArabic(roman);

            Assert.AreEqual(arabic, (uint)5);
        }

        [TestMethod]
        public void IVIsFour()
        {
            string roman = "IV";

            uint arabic = ToArabic(roman);

            Assert.AreEqual(arabic, (uint)4);
        }

        [TestMethod]
        public void XXIsTwenty()
        {
            string roman = "XX";

            uint arabic = ToArabic(roman);

            Assert.AreEqual(arabic, (uint)20);
        }

        [TestMethod]
        public void MMXCIXIs2099()
        {
            string roman = "MMXCIX";

            uint arabic = ToArabic(roman);

            Assert.AreEqual(arabic, (uint)2099);
        }

        [TestMethod]
        public void MCCLXVIIIIs1268()
        {
            string roman = "MCCLXVIII";

            uint arabic = ToArabic(roman);

            Assert.AreEqual(arabic, (uint)1268);
        }

        [TestMethod]
        public void MMMCMXLIVIs3944()
        {
            string roman = "MMMCMXLIV";

            uint arabic = ToArabic(roman);

            Assert.AreEqual(arabic, (uint)3944);
        }
    }
}
