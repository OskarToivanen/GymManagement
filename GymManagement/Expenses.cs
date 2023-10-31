using System;

namespace GymManagement
{
    internal class Expenses
    {
        public int Machines { get; private set; }
        public int MaxMachines { get; private set; }


        private const double MachineMaintenanceCost = 5.50;

        public Expenses()
        {
            Machines = 0;
            MaxMachines = 0;
        }

        public void AddMachine(int numberOFMachines)
        {
            if (numberOFMachines < 0)
            {
                Console.WriteLine("Cannot add a negative number of machines.");
                return;
            }
            Machines += numberOFMachines;
            if (Machines > MaxMachines)
            {
                MaxMachines += Machines;
            }
        }

        public void RemoveMachine()
        {
            if (Machines > 0) { Machines--; }
        }

        public double TotalCost()
        {
            return Machines * MachineMaintenanceCost;
        }

        public override string ToString()
        {
            return $"Total cost of maintenance for {Machines} machines is ${TotalCost():F2}. Maximum machines ever: {MaxMachines}.";
        }

    }
}
