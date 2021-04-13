using System;

namespace SortBenchmark
{
    [Serializable]
    public class Experiment
    {
        public ArithmeticProgressionExperiment Arithmetic { get; set; }
        public GeometricProgressionExperiment Geometric { get; set; }
    }
}