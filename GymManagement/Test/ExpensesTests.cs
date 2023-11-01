using Xunit;

namespace GymManagement.Tests
{
    public class ExpensesTests
    {
        [Fact]
        public void AddMachine_IncreasesMachineCount()
        {
            // Arrange
            var expenses = new Expenses();
            var initialMachineCount = expenses.Machines;
            var machinesToAdd = 5;

            // Act
            expenses.AddMachine(machinesToAdd);

            // Assert
            Assert.Equal(initialMachineCount + machinesToAdd, expenses.Machines);
        }

        [Fact]
        public void AddMachine_NegativeNumber_DoesNotChangeMachineCount()
        {
            // Arrange
            var expenses = new Expenses();
            var initialMachineCount = expenses.Machines;
            var machinesToAdd = -5;

            // Act
            expenses.AddMachine(machinesToAdd);

            // Assert
            Assert.Equal(initialMachineCount, expenses.Machines);
        }

        [Fact]
        public void RemoveMachine_DecreasesMachineCount()
        {
            // Arrange
            var expenses = new Expenses();
            expenses.AddMachine(5);
            var initialMachineCount = expenses.Machines;

            // Act
            expenses.RemoveMachine();

            // Assert
            Assert.Equal(initialMachineCount - 1, expenses.Machines);
        }

        [Fact]
        public void RemoveMachine_NoMachines_DoesNotChangeMachineCount()
        {
            // Arrange
            var expenses = new Expenses();
            var initialMachineCount = expenses.Machines;

            // Act
            expenses.RemoveMachine();

            // Assert
            Assert.Equal(initialMachineCount, expenses.Machines);
        }

        [Fact]
        public void TotalCost_ReturnsCorrectAmount()
        {
            // Arrange
            var expenses = new Expenses();
            expenses.AddMachine(5);
            var expectedTotalCost = 5 * 5.50;

            // Act
            var totalCost = expenses.TotalCost();

            // Assert
            Assert.Equal(expectedTotalCost, totalCost);
        }

        [Fact]
        public void ToString_ReturnsCorrectFormat()
        {
            // Arrange
            var expenses = new Expenses();
            expenses.AddMachine(5);
            var expectedString = $"Total cost of maintenance for {expenses.Machines} machines is ${expenses.TotalCost():F2}. Maximum machines ever: {expenses.MaxMachines}.";

            // Act
            var result = expenses.ToString();

            // Assert
            Assert.Equal(expectedString, result);
        }
    }
}
