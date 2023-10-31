using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GymManagement
{
    internal class GymTraffic
    {
        private readonly List<Customer> visitors = new List<Customer>();
        private readonly HashSet<string> currentVisitors = new HashSet<string>();
        private readonly ListBox logListBox;

        public IReadOnlyCollection<string> CurrentVisitors => currentVisitors;

        public GymTraffic(ListBox logListBox)
        {
            this.logListBox = logListBox;
        }

        public void RecordVisit(Customer customer)
        {
            if (currentVisitors.Contains(customer.Name))
            {
                logListBox.Items.Add($"{customer.Name} is already in the gym.");
                return;
            }

            customer.VisitGym();
            visitors.Add(customer);
            currentVisitors.Add(customer.Name);
        }

        public void CustomerLeaves(Customer customer)
        {
            if (currentVisitors.Contains(customer.Name))
            {
                currentVisitors.Remove(customer.Name);
                logListBox.Items.Add($"{customer.Name} has left the gym.");
            }
        }

        public void ShowVisitors()
        {
            Console.WriteLine("Visitors");
            foreach (var visitor in visitors)
            {
                Console.WriteLine($"{visitor.Name} visited at {visitor.LastVisit}");
            }
        }
    }
}
