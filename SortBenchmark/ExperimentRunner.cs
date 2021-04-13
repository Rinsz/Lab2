using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using BubbleSort;

namespace SortBenchmark
{
    public static class ExperimentRunner
    {
        public static void RunExperiment(string filename)
        {
            if (!File.Exists($"{filename}.xml")) throw new FileNotFoundException("experiment.xml is not found");

            var formatter = new XmlSerializer(typeof(Experiment));

            if (File.Exists($"{filename}_Result.csv"))
                File.Delete($"{filename}_Result.csv");
            
            using var fs = new FileStream($"{filename}.xml", FileMode.Open);
            var experiment = (Experiment) formatter.Deserialize(fs);
            
            RunExperiment(experiment.Arithmetic, filename, ExperimentType.Arithmetic);
            RunExperiment(experiment.Geometric, filename, ExperimentType.Geometric);
        }

        private static void RunExperiment(IExperiment expData, string filename, ExperimentType expType)
        {
            var data = new List<string>();

            for (var i = 0; i < expData.Repeats; i++)
            {
                var elementsAmount = expData.StartCollectionLength;
                while (elementsAmount <= expData.MaximalCollectionLength)
                {
                    data.Clear();
                    FillListRandomly(data, elementsAmount, expData.MinimalElementLength, expData.MaximalElementLength);
                    var operations = Sort<string>.ByBubble(data).totalOperations;
                    File.AppendAllText($"{filename}_Result.csv", $"{elementsAmount};{operations}\n");
                    elementsAmount = expType == ExperimentType.Arithmetic
                        ? elementsAmount + (int) expData.LengthIncrement
                        : (int) (elementsAmount * expData.LengthIncrement);
                }
            }
        }

        private static void FillListRandomly(List<string> list, int elementsAmount, int minElementLength,
            int maxElementLength)
        {
            var rnd = new Random();
            for (var i = 0; i < elementsAmount; i++)
                list.Add(new string('a', rnd.Next(minElementLength, maxElementLength)));
        }
    }
}