using System;
using Xunit;

namespace GymManagement.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var name = "John Doe";
            var address = "123 Main St";
            var city = "Anytown";

            // Act
            var customer = new Customer(name, address, city);

            // Assert
            Assert.Equal(name, customer.Name);
            Assert.Equal(address, customer.Address);
            Assert.Equal(city, customer.City);
            Assert.InRange(customer.MembershipID, 1, 999);
        }

        [Fact]
        public void VisitGym_SetsLastVisitToNow()
        {
            // Arrange
            var customer = new Customer("John Doe", "123 Main St", "Anytown");

            // Act
            customer.VisitGym();

            // Assert
            Assert.True((DateTime.Now - customer.LastVisit.Value).TotalSeconds < 1);
        }

        [Fact]
        public void ToString_ReturnsCorrectFormat()
        {
            // Arrange
            var customer = new Customer("John Doe", "123 Main St", "Anytown");
            var expectedString = $"Name: {customer.Name}, Address: {customer.Address}, City: {customer.City}, Membership ID: {customer.MembershipID}";

            // Act
            var result = customer.ToString();

            // Assert
            Assert.Equal(expectedString, result);
        }
    }
}
