using System;

namespace SortBenchmark
{
    [Serializable]
    public class GeometricProgressionExperiment : IExperiment
    {
        public double LengthIncrement { get; set; }
        public int MinimalElementLength { get; set; }
        public int MaximalElementLength { get; set; }
        public int StartCollectionLength { get; set; }
        public int MaximalCollectionLength { get; set; }
        public int Repeats { get; set; }
    }
}