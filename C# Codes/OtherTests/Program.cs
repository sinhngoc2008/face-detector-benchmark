using System;
using System.Threading.Tasks;

namespace OtherTests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Processing(1000);

            _ = Console.ReadLine();
        }


        public static async Task Processing(int i)
        {
            var t = Task.Run(() => 
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.WriteLine("processing {0}",j);
                }
            });

            return;
        }

    }
}
