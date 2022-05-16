using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;

namespace Benchmark
{
    public class Demo
    {
        private readonly string path = @"Path";

        public Demo()
        {
        }

        [Benchmark]
        public void AddToList()
        {
            List<BenchmarkModel> benchList = new List<BenchmarkModel>();

            List<BenchmarkModel> gm = getJson(path);

            foreach (var benc in gm)
            {
                benchList.Add(new BenchmarkModel()
                {
                    Choices = benc.Choices,
                    Code = benc.Code,
                    Dimensions = benc.Dimensions,
                    Images = benc.Images,
                    IsInOutage = benc.IsInOutage,
                    Names = benc.Names,
                    PriceTags = benc.PriceTags,
                    SelectedGrill = benc.SelectedGrill,
                    ShouldShow = benc.ShouldShow
                });
            }
        }

        [Benchmark]
        public void AddToDictionary()
        {
            var benchDictionary = new Dictionary<int, BenchmarkModel>();

            var gm = getJson(path);

            for (int i = 0; i < gm.Count; i++)
            {
                benchDictionary.Add(i, new BenchmarkModel()
                {
                    Choices = gm[i].Choices,
                    Code = gm[i].Code,
                    Dimensions = gm[i].Dimensions,
                    Images = gm[i].Images,
                    IsInOutage = gm[i].IsInOutage,
                    Names = gm[i].Names,
                    PriceTags = gm[i].PriceTags,
                    SelectedGrill = gm[i].SelectedGrill,
                    ShouldShow = gm[i].ShouldShow
                });
            }
        }

        public List<BenchmarkModel> getJson(string path)
        {
            List<BenchmarkModel> gm = JsonConvert.DeserializeObject<List<BenchmarkModel>>(File.ReadAllText(path));
            return gm;
        }
    }
}