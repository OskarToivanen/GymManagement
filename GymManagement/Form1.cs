using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GymManagement
{
    public partial class Form1 : Form
    {

        static Random random = new Random();
        static GymTraffic gymTraffic;
        private readonly Expenses expenses = new Expenses();
        private readonly Balance balance;
        private readonly Timer simulationTimer = new Timer();

        static List<Customer> customers = new List<Customer>()
        {
            CreateCustomer("Oskar", "Apinakuja", "Kuopio"),
            CreateCustomer("Jane Doe", "Keskuskatu", "Helsinki"),
            CreateCustomer("John Smith", "Main Street", "Tampere"),
            CreateCustomer("Mary Johnson", "Elm Street", "Espoo"),
            CreateCustomer("James Brown", "Oak Avenue", "Vantaa"),
            CreateCustomer("Linda White", "Pine Lane", "Oulu"),
            CreateCustomer("Michael Taylor", "Birch Road", "Turku")
        };

        static Customer CreateCustomer(string name, string address, string city)
        {
            return new Customer(name, address, city);
        }

        static void Simulate()
        {
            Console.WriteLine("Starting gym visit simulation for 8 hours...");

            int hoursPassed = 0;
            int ticksPerHour = 60; // You can adjust this based on your simulation speed
            int totalTicks = 1 * ticksPerHour;

            for (int tick = 0; tick < totalTicks; tick++)
            {
                if (random.NextDouble() < 0.1) // 10% chance of a visit each tick
                {
                    if (gymTraffic.CurrentVisitors.Count > 0)
                    {
                        int randomIndex = random.Next(gymTraffic.CurrentVisitors.Count);
                        string randomCustomerName = gymTraffic.CurrentVisitors.ElementAt(randomIndex);
                        Customer leavingCustomer = customers.First(c => c.Name == randomCustomerName);
                        gymTraffic.CustomerLeaves(leavingCustomer);
                    }
                    Customer randomCustomer = customers[random.Next(customers.Count)];
                    gymTraffic.RecordVisit(randomCustomer);
                }

                if (tick % ticksPerHour == 0 && tick != 0)
                {
                    hoursPassed++;
                    Console.WriteLine($"Simulation: {hoursPassed} hours passed.");
                }

                System.Threading.Thread.Sleep(100); // Adjust as needed to control simulation speed
            }

            Console.WriteLine("Simulation complete. Showing gym visitors:");
            gymTraffic.ShowVisitors();
        }

        public Form1()
        {
            InitializeComponent();
            balance = new Balance(expenses);
            simulationTimer.Interval = 100; // Adjust as needed to control simulation speed
            simulationTimer.Tick += SimulationTimer_Tick;
            gymTraffic = new GymTraffic(listBox1);
        }


        private void startSimulationButton_Click(object sender, EventArgs e)
        {
            simulationTimer.Start();
        }

        private void SimulationTimer_Tick(object sender, EventArgs e)
        {
            // Your simulation logic here
            // Update the UI as needed

            if (random.NextDouble() < 0.1) // 10% chance of a visit each tick
            {
                // Your logic for handling a gym visit
            }

            // Other simulation logic as needed
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void ShowBalance_Click(object sender, EventArgs e)
        {

        }

        private void SimulateBtn_Click(object sender, EventArgs e)
        {
            timer1.Start();
            listBox1.Items.Add("---GYM IS OPEN---");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private int ticks = 0;
        private int hoursPassed = 0;
        private int ticksPerHour = 60;
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Chance of a customer visiting the gym
            if (random.NextDouble() < 0.1) // 10% chance
            {
                Customer randomCustomer = customers[random.Next(customers.Count)];
                gymTraffic.RecordVisit(randomCustomer);
            }

            // Chance of a customer leaving the gym
            if (random.NextDouble() < 0.05) // 5% chance
            {
                if (gymTraffic.CurrentVisitors.Count > 0)
                {
                    int randomIndex = random.Next(gymTraffic.CurrentVisitors.Count);
                    string randomCustomerName = gymTraffic.CurrentVisitors.ElementAt(randomIndex);
                    Customer leavingCustomer = customers.First(c => c.Name == randomCustomerName);
                    gymTraffic.CustomerLeaves(leavingCustomer);
                }
            }

            labelVisitors.Text = $"Current Visitors: {gymTraffic.CurrentVisitors.Count}";

            ticks++;
            progressBar1.Value = ticks;
            if (ticks % ticksPerHour == 0)
            {
                hoursPassed++;
            }

            if (hoursPassed >= 1)
            {
                timer1.Stop();
                listBox1.Items.Add("---GYM CLOSED---");
                MessageBox.Show("Simulation complete. Showing gym visitors:");
                // Code to show gym visitors
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
