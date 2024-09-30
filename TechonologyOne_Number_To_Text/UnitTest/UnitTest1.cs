using TechonologyOne_Number_To_Text.Components;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        //Used for initial testing, functions are now private
        /*[TestMethod]
        public void TestDoubleDigits()
        {
            for(int i = 10; i < 100; i++)
            {
                Console.WriteLine(NumToText.DoubleDigitToString(i));
            }
        }
        [TestMethod]
        public void TestTripleDigits()
        {
            for (int i = 100; i < 1000; i++)
            {
                Console.WriteLine(NumToText.TripleDigitToString(i, true));
            }
        }
        [TestMethod]
        public void TestTotalNum()
        {
            Console.WriteLine(NumToText.NumberToText(111000033));
        }*/
        [TestMethod]
        public void TestDollarsCents()
        {
            string test1 = NumToText.DollarsToText(1000);
            Assert.AreEqual("ONE THOUSAND DOLLARS", test1);

            string test2 = NumToText.DollarsToText((decimal)99876.10);
            Assert.AreEqual("NINETY NINE THOUSAND EIGHT HUNDRED AND SEVENTY SIX DOLLARS AND TEN CENTS", test2);

            string test3 = NumToText.DollarsToText((decimal)0.99);
            Assert.AreEqual("NINETY NINE CENTS", test3);

            string test4 = NumToText.DollarsToText(-10);
            Assert.AreEqual("NUMBER MUST BE ZERO OR GREATER", test4);

        }

    }
}