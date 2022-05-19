using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;

namespace Benchmark
{
    public class Demo
    {
        private static string path = Path.Combine(AppContext.BaseDirectory, "JSON\\data.json");
        private static List<BenchmarkModel> _json = getJson(path);
        private const string IdKeyOrValue = "8957_958";
        private Dictionary<string, BenchmarkModel> _dic;
        private List<BenchmarkModel> _list;
        private int _count = 1000;

        public Demo()
        {
            _list = AddToList();
            _dic = AddToDictionary();
        }

        [Benchmark]
        public List<BenchmarkModel> AddToList()
        {
            List<BenchmarkModel> benchList = new List<BenchmarkModel>();

            for (int j = 0; j < _count; j++)
            {
                int i = 0;
                foreach (var benc in _json)
                {
                    benchList.Add(new BenchmarkModel()
                    {
                        Id = $"{j}_{i}",
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
                    i++;
                }
            }
            return benchList;
        }

        [Benchmark]
        public Dictionary<string, BenchmarkModel> AddToDictionary()
        {
            var benchDictionary = new Dictionary<string, BenchmarkModel>();

            for (int j = 0; j < _count; j++)
            {
                for (int i = 0; i < _json.Count; i++)
                {
                    benchDictionary.Add($"{j}_{i}", new BenchmarkModel()
                    {
                        Id = $"{j}_{i}",
                        Choices = _json[i].Choices,
                        Code = $"{_json[i].Code}",
                        Dimensions = _json[i].Dimensions,
                        Images = _json[i].Images,
                        IsInOutage = _json[i].IsInOutage,
                        Names = _json[i].Names,
                        PriceTags = _json[i].PriceTags,
                        SelectedGrill = _json[i].SelectedGrill,
                        ShouldShow = _json[i].ShouldShow
                    });
                }
            }

            return benchDictionary;
        }

        [Benchmark]
        public BenchmarkModel findOnList()
        {
            BenchmarkModel di = _list.FirstOrDefault(c => c.Id == IdKeyOrValue);

            return di;
        }

        [Benchmark]
        public BenchmarkModel findOnDictionaryByKey()
        {
            var di = _dic[IdKeyOrValue];

            return di;
        }

        [Benchmark]
        public BenchmarkModel findOnDictionaryByValue()
        {
            var di = _dic.FirstOrDefault(d => d.Value.Id == IdKeyOrValue).Value;

            return di;
        }

        public static List<BenchmarkModel> getJson(string path)
        {
            List<BenchmarkModel> json = JsonConvert.DeserializeObject<List<BenchmarkModel>>(File.ReadAllText(path));
            return json;
        }
    }
}