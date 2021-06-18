using System;
using Tensorflow;
namespace TensorflowTests
{
    public class Program
    {
        private static string PbFile = @"C:\Users\user\Dataset\wider_face_yolo\face-detector-benchmark\XOR_models\frozen_graph_xor\xor_model.pb";
        public static void Main(string[] args)
        {
            var graph = Program.ImportGraph(Program.PbFile);

            Console.WriteLine(graph._nodes_by_name.Values.ToString());
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
