using System;

namespace GymManagement
{

    internal class Customer
    {

        private static readonly Random rand = new Random();
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int MembershipID { get; private set; }

        public DateTime? LastVisit { get; private set; }

        public Customer(string name, string address, string city)
        {
            Name = name;
            Address = address;
            City = city;
            MembershipID = GenerateID();
        }

        public static int GenerateID()
        {
            int id = rand.Next(1, 999);
            return id;
        }

        public void VisitGym()
        {
            LastVisit = DateTime.Now;
            Console.WriteLine($"{Name} visited your gym");
        }

        public override string ToString()
        {
            return $"Name: {Name}, Address: {Address}, City: {City}, Membership ID: {MembershipID}";
        }
    }
}
