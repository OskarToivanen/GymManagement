using Xunit;

namespace GymManagement.Tests
{
    public class FinancialDataTests
    {
        [Fact]
        public void FinancialData_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var expenses = new Expenses();
            var balance = new Balance(expenses);
            balance.AddSubscription(); // Adding a subscription to set some values in balance

            // Act
            var financialData = new FinancialData(balance);

            // Assert
            Assert.InRange(financialData.Machines, 1, 49);
            Assert.InRange(financialData.TotalMaintenanceCost, 10, 2000); // Assuming maximum possible value
            Assert.Equal(32.99f, financialData.CurrentBalance);
            Assert.Equal(32.99f, financialData.MonthlyIncome);
            Assert.Equal(32.99 - expenses.TotalCost(), financialData.EndOfMonthBalance, 2);
        }

        [Fact]
        public void GenerateMachines_ReturnsValueInRange()
        {
            // Arrange
            var financialData = new FinancialData(new Balance(new Expenses()));

            // Act
            var machines = financialData.GenerateMachines();

            // Assert
            Assert.InRange(machines, 1, 49);
        }

        [Fact]
        public void TotalMachineMaintenanceCost_ReturnsValueInRange()
        {
            // Arrange
            var financialData = new FinancialData(new Balance(new Expenses()));

            // Act
            var cost = financialData.TotalMachineMaintenanceCost();

            // Assert
            Assert.InRange(cost, 10, 20);
        }
    }
}
