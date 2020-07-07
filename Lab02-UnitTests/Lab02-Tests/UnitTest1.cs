using Lab02_UnitTests;
using System;
using Xunit;
using static Lab02_UnitTests.Program;

namespace Lab02_Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(2000, 1500, 500)]
        [InlineData(20, 19.99, 0.01)]
        [InlineData(200, 200, 0)]
        public void CanWithdrawAmounts(decimal balance, decimal amount, decimal expected)
        {
            Program.Balance = balance;
            Program.Withdraw(amount);
            Assert.Equal(expected, Program.Balance);
        }

        [Theory]
        [InlineData(2000, 2500)]
        [InlineData(20, 20.01)]
        public void CantOverdraft(decimal balance, decimal amount)
        {
            Program.Balance = balance;
            Assert.Equal(-1, Program.Withdraw(amount));
        }
    }
}
