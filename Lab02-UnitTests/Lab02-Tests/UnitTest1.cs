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
            Balance = balance;
            Withdraw(amount);
            Assert.Equal(expected, Balance);
        }

        [Theory]
        [InlineData(2000, 1000, 500)]
        [InlineData(20, 19.9, 0.01)]
        [InlineData(400, 200, 0)]
        public void IncorrectWithdrawAmounts(decimal balance, decimal amount, decimal expected)
        {
            Balance = balance;
            Withdraw(amount);
            Assert.NotEqual(expected, Balance);
        }

        [Theory]
        [InlineData(2000, 2500)]
        [InlineData(20, 20.01)]
        [InlineData(20, -10)]
        public void CantOverdraftOrWithdrawNegative(decimal balance, decimal amount)
        {
            Balance = balance;
            Assert.Equal(-1, Withdraw(amount));
        }

        [Theory]
        [InlineData(2000, 500, 2500)]
        [InlineData(0, 0.01, 0.01)]
        [InlineData(200, 200, 400)]
        public void CanDepositAmounts(decimal balance, decimal amount, decimal expected)
        {
            Balance = balance;
            Deposit(amount);
            Assert.Equal(expected, Balance);
        }

        [Theory]
        [InlineData(2000, 300, 2500)]
        [InlineData(0, 0.01, 0.11)]
        [InlineData(100, 200, 400)]
        public void IncorrectDepositAmounts(decimal balance, decimal amount, decimal expected)
        {
            Balance = balance;
            Deposit(amount);
            Assert.NotEqual(expected, Balance);
        }

        [Theory]
        [InlineData(20, -10)]
        public void CantDepositNegative(decimal balance, decimal amount)
        {
            Balance = balance;
            Assert.Equal(-1, Deposit(amount));
        }

        [Theory]
        [InlineData(1500, 500)]
        [InlineData(2000, 0)]
        [InlineData(0.01, 1999.99)]
        public void ViewBalanceAfterWithdraw(decimal amount, decimal expected)
        {
            Balance = 2000;
            Withdraw(amount);
            Assert.Equal(expected, Balance);
        }

        [Theory]
        [InlineData(2000, 4000)]
        [InlineData(10, 2010)]
        [InlineData(0.01, 2000.01)]
        public void ViewBalanceAfterDeposit(decimal amount, decimal expected)
        {
            Balance = 2000;
            Deposit(amount);
            Assert.Equal(expected, Balance);
        }

        [Theory]
        [InlineData(1500, 800)]
        public void ViewBalanceAfterWithdrawFail(decimal amount, decimal expected)
        {
            Balance = 2000;
            Withdraw(amount);
            Assert.NotEqual(expected, Balance);
        }

        [Theory]
        [InlineData(2000, 3000)]
        public void ViewBalanceAfterDepositFail(decimal amount, decimal expected)
        {
            Balance = 2000;
            Deposit(amount);
            Assert.NotEqual(expected, Balance);
        }

    }
}
