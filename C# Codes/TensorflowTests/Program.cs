using System;
using Tensorflow;
using static Tensorflow.Binding;
using static Tensorflow.keras;
using NumSharp;

namespace TensorflowTests
{
    public class Program
    {
        private static string PbFile = @"C:\Users\user\Dataset\wider_face_yolo\face-detector-benchmark\XOR_models\frozen_graph_xor\xor_model.pb";
        public static void Main(string[] args)
        {
            Console.WriteLine("THIS");

            _ = Console.ReadLine();
        
        }

        public static Graph ImportGraph(string pbFile)
        {
            var graph = new Graph().as_default();
            graph.Import(pbFile);

            return graph;
        }

    }
}
