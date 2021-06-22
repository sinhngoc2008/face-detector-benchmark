using System;
using System.Threading.Tasks;

namespace OtherTests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Testing code");

            var t = Task<int>.Run(() => {
                // making a loop

                int max = 1000000;
                int ctr = 0;
                for (ctr = 0; ctr <= max; ctr++)
                {
                    if (ctr == max / 2 && DateTime.Now.Hour >= 12)
                    {
                        ctr++;
                        break;
                    }
                }
                return ctr;
            });

            Console.WriteLine("Finished {0:N0} iterations.", t.Result);
            _ = Console.ReadLine();
        }
    }
}
