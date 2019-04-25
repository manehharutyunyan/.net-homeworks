using System;

namespace Exercise1
{
    class User
    {
        public string Name { get; set; }

        public User(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Event which is triggered if user  user enters Jack, Steven,
        /// and Mathew as username. They are banned for the organization.
        /// </summary>
        public event Action<string> OnFireAlarm;

        /// <summary>
        /// User provides their name as Input and then application show 
        /// message to “Welcome to [name of the user]” if user 
        /// doesnt enter Jack, Steven and Mathew as username.
        /// </summary>
        /// <param name="username"></param>
        public void EnterAUsername(string username)
        {
            if ( username.Equals("Jack") || username.Equals("Steven") || username.Equals("Mathew"))
            {
                if (this.OnFireAlarm != null)
                {
                    this.OnFireAlarm(username);
                }
            }
            else
            {
                Console.WriteLine($"Welcome to {username}");
            }
        }

    }
}
