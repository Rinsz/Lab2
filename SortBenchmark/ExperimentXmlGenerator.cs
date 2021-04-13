using System;
using System.IO;
using System.Xml.Serialization;

namespace SortBenchmark
{
    public class ExperimentXmlGenerator
    {
        public static void GenerateExperimentXml(string filename)
        {
            Console.WriteLine("Generating arithmetic experiment data...");
            Console.WriteLine();
            var arithmetic = (ArithmeticProgressionExperiment)GenerateExperimentData(ExperimentType.Arithmetic);
            
            Console.WriteLine("Done...");
            Console.WriteLine();
            
            Console.WriteLine("Generating arithmetic experiment data...");
            Console.WriteLine();
            var geometric = (GeometricProgressionExperiment)GenerateExperimentData(ExperimentType.Geometric);
            
            Console.WriteLine("Done...");
            Console.WriteLine("Creating xml data file...");
            CreateExperimentDataXmlFile(filename, new Experiment {Arithmetic = arithmetic, Geometric = geometric});
            Console.WriteLine($"Experiment data \"{filename}.xml\" file generated. Now you can run experiment.");
        }

        private static IExperiment GenerateExperimentData(ExperimentType type)
        {
            Console.WriteLine("Enter minimal element length: ");
            var minElemLength = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter maximal element length: ");
            var maxElemLength = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter start collection length: ");
            var minCollectionLength = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter maximal collection length: ");
            var maxCollectionLength = int.Parse(Console.ReadLine());

            Console.WriteLine($"Enter {type.ToString()} increment: ");
            var increment = type == ExperimentType.Arithmetic
                ? int.Parse(Console.ReadLine())
                : double.Parse(Console.ReadLine());

            Console.WriteLine("Enter repeats amount: ");
            var repeats = int.Parse(Console.ReadLine());

            return type == ExperimentType.Geometric
                ? new GeometricProgressionExperiment()
                {
                    MinimalElementLength = minElemLength,
                    MaximalElementLength = maxElemLength,
                    StartCollectionLength = minCollectionLength,
                    MaximalCollectionLength = maxCollectionLength,
                    LengthIncrement = increment,
                    Repeats = repeats
                }
                : new ArithmeticProgressionExperiment()
                {
                    MinimalElementLength = minElemLength,
                    MaximalElementLength = maxElemLength,
                    StartCollectionLength = minCollectionLength,
                    MaximalCollectionLength = maxCollectionLength,
                    LengthIncrement = (int)increment,
                    Repeats = repeats
                };
        }

        private static void CreateExperimentDataXmlFile(string filename, Experiment experiment)
        {
            var formatter = new XmlSerializer(typeof(Experiment));

            using var fs = new FileStream($"{filename}.xml", FileMode.OpenOrCreate);
            formatter.Serialize(fs, experiment);

        }
    }
}