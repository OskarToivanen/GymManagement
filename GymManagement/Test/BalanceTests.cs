using System;
using Xunit;

namespace GymManagement.Tests
{
    public class BalanceTests
    {
        [Fact]
        public void AddSubscription_IncreasesCurrentBalanceAndMonthlyIncome()
        {
            // Arrange
            var expenses = new Expenses();
            var balance = new Balance(expenses);
            var expectedCurrentBalance = 32.99f;
            var expectedMonthlyIncome = 32.99f;

            // Act
            balance.AddSubscription();

            // Assert
            Assert.Equal(expectedCurrentBalance, balance.CurrentBalance);
            Assert.Equal(expectedMonthlyIncome, balance.MonthlyIncome);
        }

        [Fact]
        public void UpdateBalance_UpdatesCurrentBalance()
        {
            // Arrange
            var expenses = new Expenses();
            var balance = new Balance(expenses);
            var amountToUpdate = 50.0f;
            var expectedCurrentBalance = 50.0f;

            // Act
            balance.UpdateBalance(amountToUpdate);

            // Assert
            Assert.Equal(expectedCurrentBalance, balance.CurrentBalance);
        }

        [Fact]
        public void UpdateMonthlyIncome_UpdatesMonthlyIncome()
        {
            // Arrange
            var expenses = new Expenses();
            var balance = new Balance(expenses);
            var amountToUpdate = 50.0f;
            var expectedMonthlyIncome = 50.0f;

            // Act
            balance.UpdateMonthlyIncome(amountToUpdate);

            // Assert
            Assert.Equal(expectedMonthlyIncome, balance.MonthlyIncome);
        }

        [Fact]
        public void EndOfMonthBalance_CalculatesCorrectly()
        {
            // Arrange
            var expenses = new Expenses();
            var balance = new Balance(expenses);
            balance.AddSubscription(); // MonthlyIncome = 32.99, CurrentBalance = 32.99
            balance.UpdateBalance(-10.0f); // CurrentBalance = 22.99
            var expectedEndOfMonthBalance = Math.Round(32.99 - expenses.TotalCost(), 2);

            // Act
            var endOfMonthBalance = balance.EndOfMonthBalance();

            // Assert
            Assert.Equal(expectedEndOfMonthBalance, endOfMonthBalance, 2);
        }
    }
}
