using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using CorpusDraftCSharp;

namespace CorpusDraftCSharp {
    [Serializable]
    public class ParallelDocument : ICorpusUnit
    {
        [JsonProperty]
        public string Id { get; set; }
        [JsonProperty]
        public string text { get; set; }
        [JsonProperty]
        public List<Dictionary<string, List<Value>>> tagging { get; set; }
        [JsonProperty]
        public ParallelClause[,] parallelClauses { get; set; }
        public List<ParallelToken> parallelTokens { get; set; }
        public string Jsonize()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            return json;
        }
    }
}
