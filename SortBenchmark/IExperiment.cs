namespace SortBenchmark
{
    public interface IExperiment
    {
        public int MinimalElementLength { get; set; }
        
        public int MaximalElementLength { get; set; }
        
        public int StartCollectionLength { get; set; }
        
        public int MaximalCollectionLength { get; set; }
        
        public int Repeats { get; set; }
        
        public double LengthIncrement { get; set; }
    }
}