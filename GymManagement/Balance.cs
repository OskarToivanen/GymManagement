namespace GymManagement
{
    internal class Balance
    {
        public float CurrentBalance { get; private set; }
        public float MonthlyIncome { get; private set; }
        private const double MonthlySubscription = 32.99;

        private Expenses expenses;

        public Balance(Expenses expenses)
        {
            CurrentBalance = 0;
            MonthlyIncome = 0;
            this.expenses = expenses;
        }

        public void AddSubscription()
        {
            MonthlyIncome += (float)MonthlySubscription;
            CurrentBalance += (float)MonthlySubscription;
        }

        public void UpdateBalance(float amount)
        {
            CurrentBalance += amount;
        }

        public void UpdateMonthlyIncome(float amount)
        {
            MonthlyIncome += amount;
        }

        public double EndOfMonthBalance()
        {
            return MonthlyIncome - expenses.TotalCost();
        }

        public override string ToString()
        {
            return $"Current balance is ${CurrentBalance:F2} and monthly income is ${MonthlyIncome:F2}, end-of-month balance is ${EndOfMonthBalance():F2}";
        }
    }
}
