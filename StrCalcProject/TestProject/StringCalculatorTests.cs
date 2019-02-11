using System;
using System.Collections.Generic;
using StrCalcProject;
using NUnit.Framework;

namespace TestProject
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("3", 3)]
        [TestCase("7", 7)]
        [TestCase("34", 34)]
        public void Test1_OneNumberInput_Success(string numbers, int expected)
        {
            var calc = new StringCalculator();
            var result = calc.CalcResult(numbers);
            Assert.True(result == expected);
        }

        [TestCase("3,3", 6)]
        [TestCase("7,12", 19)]
        [TestCase("34,7", 41)]
        public void Test2_TwoNumbersInput_Success(string numbers, int expected)
        {
            var calc = new StringCalculator();
            var result = calc.CalcResult(numbers);
            Assert.True(result == expected);
        }

        [TestCase("3,1", 4)]
        [TestCase("7,5,12", 24)]
        [TestCase("34,7,2,7", 50)]
        public void Test3_FewNumbersInput_Success(string numbers, int expected)
        {
            var calc = new StringCalculator();
            var result = calc.CalcResult(numbers);
            Assert.True(result == expected);
        }

        [TestCase("3,-1", -1)]
        [TestCase("-7,5,12", -1)]
        [TestCase("34,7,-2,7", -1)]
        public void Test4_NegativeInputReturnsBelowZero_Success(string numbers, int expected)
        {
            var calc = new StringCalculator();
            var result = calc.CalcResult(numbers);
            Assert.True(result == expected);
        }

        [TestCase("3,1,94501", 4)]
        [TestCase("7,5,12,1234", 24)]
        [TestCase("34,7,2,7,1000", 50)]
        public void Test5_IgnoreBiggerThan1000InInput_Success(string numbers, int expected)
        {
            var calc = new StringCalculator();
            var result = calc.CalcResult(numbers);
            Assert.True(result == expected);
        }

        [Test]
        public void Test6_EmptyInputReturns0_Success()
        {
            var calc = new StringCalculator();
            var result = calc.CalcResult(string.Empty);
            Assert.True(result == 0);
        }

        [TestCase("/f", "3f1", 4)]
        [TestCase("/c", "7,5c12", 24)]
        [TestCase("/;", "34;7,2,7", 50)]
        public void Test7_FewNumbersInputComplexSeparator_Success(String command, string numbers, int expected)
        {
            var calc = new StringCalculator();
            calc.Set(command);
            var result = calc.CalcResult(numbers);
            Assert.True(result == expected);
        }

        [TestCase(2, 4)]
        [TestCase(10, 20)]
        [TestCase(178, 356)]
        public void Test8_ReplaceDividingByTwo_Success(List<int> numbers, List<int> expected)
        {
            var calc = new StringCalculator();
            var result = calc.ReplaceDividingByTwo(numbers);
            Assert.True(result == expected);
        }
    }
}
