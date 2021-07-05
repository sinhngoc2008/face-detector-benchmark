using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleThreadPractises
{
    public class Program
    {
        private static SafeQueue<int> q = new SafeQueue<int>();
        private static int threadsRunning = 0;
        private static int[][] results = new int[3][];

        public static void Main(string[] args)
        {
            Console.WriteLine("Working...");

            for (int i = 0; i < 3; i++)
            {
                Thread t = new Thread(ThreadProc);
                t.Start(i);
                Interlocked.Increment(ref threadsRunning);
            }
            _ = Console.ReadLine();
        }

        private static void ThreadProc(object state)
        {
            DateTime finish = DateTime.Now.AddSeconds(10);
            Random rand = new Random();
            int[] result = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int threadNum = (int)state;

            while (DateTime.Now < finish)

            {
                int what = rand.Next(250);
                int how = rand.Next(100);

                if (how < 16)
                {
                    q.Enqueue(what);
                    result[(int)ThreadResultIndex.EnqueueCt] += 1;
                }
                else if (how < 32)
                {
                    if (q.TryEnqueue(what,how))
                    {
                        result[(int)ThreadResultIndex.TryEnqueueSucceedCt] += 1;
                    }
                    else
                    {
                        result[(int)ThreadResultIndex.TryEnqueueFailCt] += 1;
                    }
                }
                else if (how < 48)
                {
                    // Even a very small wait significantly increases the success
                    // rate of the conditional enqueue operation.
                    if (q.TryEnqueue(what,how))
                    {
                        result[(int)ThreadResultIndex.TryEnqueueWaitSucceedCt] += 1;
                    }
                    else
                    {
                        result[(int)ThreadResultIndex.TryEnqueueWaitFailCt] += 1;
                    }
                }
                else if (how < 96)
                {
                    result[(int)ThreadResultIndex.DequeueCt] += 1;
                    try
                    {
                        q.Dequeue();
                    }
                    catch
                    {
                        result[(int)ThreadResultIndex.DequeueExCt] += 1;
                    }
                }
                else
                {
                    result[(int)ThreadResultIndex.RemoveCt] += 1;
                    result[(int)ThreadResultIndex.RemovedCt] += q.Remove(what);
                }
            }

            results[threadNum] = result;

            if (0 == Interlocked.Decrement(ref threadsRunning))
            {
                StringBuilder sb = new StringBuilder("                        Thread 1 Thread 2 Thread 3    Total\n");

                for (int row = 0; row < 9; row++)
                {
                    int total = 0;
                    sb.Append(titles[row]);

                    for (int col = 0; col < 3; col++)
                    {
                        sb.Append(String.Format("{0,9}", results[col][row]));
                        total += results[col][row];
                    }

                    sb.AppendLine(String.Format("{0,9}", total));
                }

                Console.WriteLine(sb.ToString());
            }
        }

        private static string[] titles = {
      "Enqueue                       ",
      "TryEnqueue succeeded          ",
      "TryEnqueue failed             ",
      "TryEnqueue(T, wait) succeeded ",
      "TryEnqueue(T, wait) failed    ",
      "Dequeue attempts              ",
      "Dequeue exceptions            ",
      "Remove operations             ",
      "Queue elements removed        "};

        private enum ThreadResultIndex
        {
            EnqueueCt,
            TryEnqueueSucceedCt,
            TryEnqueueFailCt,
            TryEnqueueWaitSucceedCt,
            TryEnqueueWaitFailCt,
            DequeueCt,
            DequeueExCt,
            RemoveCt,
            RemovedCt
        };


    }
}
