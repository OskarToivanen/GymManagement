using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GymManagement
{
    public partial class Form1 : Form
    {

        static readonly Random random = new Random();
        static GymTraffic gymTraffic;
        private readonly Expenses expenses = new Expenses();
        private readonly Balance balance;
        private readonly Timer simulationTimer = new Timer();
        private readonly BindingList<FinancialData> financialDataList = new BindingList<FinancialData>();
        private readonly BindingSource financialDataSource = new BindingSource();

        static readonly List<Customer> customers = new List<Customer>()
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

        public Form1()
        {
            InitializeComponent();
            balance = new Balance(expenses);
            simulationTimer.Interval = 100; // Adjust as needed to control simulation speed
            gymTraffic = new GymTraffic(listBox1);
            customers.ForEach(c => balance.AddSubscription());
            // Set up the data source for the DataGridView
            financialDataSource.DataSource = financialDataList;
            dataGridView1.DataSource = financialDataSource;
            FinancialData data = new FinancialData(balance);
            financialDataList.Add(data);
        }


        private void StartSimulationButton_Click(object sender, EventArgs e)
        {
            simulationTimer.Start();
        }

        private void SimulateBtn_Click(object sender, EventArgs e)
        {
            timer1.Start();
            listBox1.Items.Add("---GYM IS OPEN---");
        }

        private int ticks = 0;
        private int hoursPassed = 0;
        private readonly int ticksPerHour = 60;
        private void Timer1_Tick(object sender, EventArgs e)
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
    }
}
