using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            User user = new User(name);

            user.OnFireAlarm += User_OnFireAlarm;

            user.EnterAUsername(user.Name);
        }

        private static void User_OnFireAlarm(string username)
        {
            Console.WriteLine($"{username} is banned for the organization");
        }
    }
}
