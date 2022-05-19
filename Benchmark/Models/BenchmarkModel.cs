using Benchmark.Models;

namespace Benchmark
{
    public class BenchmarkModel
    {
        public string Id { get; set; }
        public List<Dimension> Dimensions { get; set; }

        public PriceTags PriceTags { get; set; }

        public Images Images { get; set; }

        public Names Names { get; set; }

        public List<object> Choices { get; set; }

        public string Code { get; set; }

        public SelectedGrill SelectedGrill { get; set; }

        public bool ShouldShow { get; set; }

        public bool IsInOutage { get; set; }
    }
}