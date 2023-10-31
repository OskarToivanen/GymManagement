using System;

namespace GymManagement
{
    internal class FinancialData
    {
        private readonly Random rand = new Random();
        public int Machines { get; set; }
        public double TotalMaintenanceCost { get; set; }
        public float CurrentBalance { get; set; }
        public float MonthlyIncome { get; set; }
        public double EndOfMonthBalance { get; set; }

        public FinancialData(Balance balance)
        {
            Machines = GenerateMachines();
            TotalMaintenanceCost = TotalMachineMaintenanceCost() * GenerateMachines();
            CurrentBalance = (float)Math.Round(balance.CurrentBalance, 2);
            MonthlyIncome = (float)Math.Round(balance.MonthlyIncome, 2);
            EndOfMonthBalance = balance.EndOfMonthBalance();
        }

        public int GenerateMachines()
        {
            int machines = rand.Next(1, 50);
            return machines;
        }

        public double TotalMachineMaintenanceCost()
        {
            double totalMachineMaintenanceCost = rand.NextDouble() * (20 - 10) + 10;
            return Math.Round(totalMachineMaintenanceCost, 2);
        }

    }


}
