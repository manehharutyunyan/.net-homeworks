using System;

namespace RollingADie
{
    class Program
    {
        static void Main(string[] args)
        {
            RollingADie rollingDie = new RollingADie();
            rollingDie.OnTwoFoursInRAow += RollingDie_OnTwoFoursInRAow;
            rollingDie.OnSumOfFiveTosses += RollingDie_OnSumOfFiveTosses;
            rollingDie.RollADie();
        }

        private static void RollingDie_OnSumOfFiveTosses()
        {
            Console.WriteLine("SumOfFiveTosses event has occoured");
        }

        private static void RollingDie_OnTwoFoursInRAow(int count)
        {
            Console.WriteLine("TwoFoursInRAow event has occoured {0} times", count) ;
        }
    }
}
