using System;

namespace GymManagement
{
    internal class CreateGym
    {
        public string GymName { get; private set; }
        public int GymSize { get; private set; }
        public CreateGym(string name, int size)
        {
            GymName = name;
            GymSize = size;
        }

        public void DisplayGymInfo()
        {
            Console.WriteLine($"Welcome to {GymName}");
            Console.WriteLine($"Our gym size is {GymSize} square meters");
        }
    }
}
