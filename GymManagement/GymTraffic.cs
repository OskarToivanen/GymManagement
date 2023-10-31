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
                AddLog($"{customer.Name} is already in the gym.");
                return;
            }

            customer.VisitGym();
            visitors.Add(customer);
            currentVisitors.Add(customer.Name);
            AddLog($"{customer.Name} has entered the gym.");
        }

        public void CustomerLeaves(Customer customer)
        {
            if (currentVisitors.Contains(customer.Name))
            {
                currentVisitors.Remove(customer.Name);
                AddLog($"{customer.Name} has left the gym.");
            }
        }

        private void AddLog(string message)
        {
            if (logListBox.InvokeRequired)
            {
                logListBox.Invoke(new Action<string>(AddLog), message);
            }
            else
            {
                logListBox.Items.Add(message);
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
