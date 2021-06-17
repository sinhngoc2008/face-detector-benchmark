using System;
using static Tensorflow.Binding;
namespace TensorflowTests
{
    public class Program
    {

        static void Main(string[] args)
        {

            var hello = tf.constant("Hello, TensorFlow!");
            Console.WriteLine(hello);

            _ = Console.ReadLine();
        
        }

    }
}
