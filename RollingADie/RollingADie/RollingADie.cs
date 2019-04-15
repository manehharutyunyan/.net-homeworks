using System;

namespace RollingADie
{
    /// <summary>
    /// Class that performs a simulation of a rolling die.
    /// </summary>
    class RollingADie
    {
        public delegate void TwoFoursInRAowDelegae(int Count);
        public event TwoFoursInRAowDelegae OnTwoFoursInRAow;

        public delegate void SumOfFiveTossesDelegae();
        public event SumOfFiveTossesDelegae OnSumOfFiveTosses;

        //ctor
        public RollingADie()
        {

        }

        /// <summary>
        /// This method rolls a die,for instance, 50times and print out
        /// appropriate messages for getting mentioned events
        /// </summary>
        public void RollADie()
        {
            Random rnd = new Random();
            int[] rollinDieArr = new int[50];
            for (int i = 0; i < 50; ++i)
            {
                int num = rnd.Next(1, 7);
                rollinDieArr[i] = num;
                Console.WriteLine(num);
            }

            int sum = rollinDieArr[0];
            bool isSumGreatherThan20 = false;
            int count = 0;

            for (int i = 1; i < rollinDieArr.Length; ++i)
            {
                //checking if die shows two fours in a row or no
                if (rollinDieArr[i - 1] == 2 && rollinDieArr[i] == 2)
                {
                    ++count;
                }

                //checking if in the consequent 5 tosses the sum of
                //all numbers is greater than or equal to 20.
                if (sum >= 20 && isSumGreatherThan20 == false)
                {
                    isSumGreatherThan20 = true;
                }
                if(i > 4)
                {
                    sum -= rollinDieArr[i - 5];
                }
                sum += rollinDieArr[i];
            }

            //Event which is triggered if die showstwo foursin a row
            //and count the number of times ‘two foursin a row’appear.
            if (this.OnTwoFoursInRAow != null)
            {
                this.OnTwoFoursInRAow(count);
            }

            //Event which is triggered if in the consequent 5tosses the
            //sum of all numbers is greater than or equal to 20.
            if (this.OnSumOfFiveTosses != null && isSumGreatherThan20 == true)
            {
                this.OnSumOfFiveTosses();
            }
        }
    }
}
