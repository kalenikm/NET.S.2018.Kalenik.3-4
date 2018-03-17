using System;
using NUnit.Framework;

namespace Logic.Tests
{
    [TestFixture]
    public class GreaterCommonDivisorTests
    {
        [TestCase(new[] { 3, 743, 75, 3, 4, 85, 7, 65, 4, 94, 3, 6, 68, 4, 6, 372, 46 }, ExpectedResult = 1)]
        [TestCase(new[] { 3, 12, 48, 9, 18 }, ExpectedResult = 3)]
        [TestCase(new[] { 25, 5, 4, 8, 3246, 1, 8, 568, 56 }, ExpectedResult = 1)]
        [TestCase(new[] { 25, 5, 100, 10, 125, 35, 15, 75, 55 }, ExpectedResult = 5)]
        public int NormalGcdTestWithManyNumbers(int[] arr)
        {
            return GreaterCommonDivisor.NormalGcd(arr);
        }

        [TestCase(35, 28, ExpectedResult = 7)]
        [TestCase(28, 13, ExpectedResult = 1)]
        [TestCase(12, 48, ExpectedResult = 12)]
        [TestCase(0, 48, ExpectedResult = 48)]
        [TestCase(1, 48, ExpectedResult = 1)]
        public int NormalGcdTestWithTwoNumbers(int a, int b)
        {
            return GreaterCommonDivisor.NormalGcd(a, b);
        }

        [TestCase]
        public void NormalGcd_ThrowArgumentException_NegativeNumber()
        {
            Assert.Throws<ArgumentException>(() => GreaterCommonDivisor.NormalGcd(-35, 28));
        }
    }
}
