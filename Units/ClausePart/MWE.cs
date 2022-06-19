using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace CorpusDraftCSharp
{
    public class MWE : IUnitGroup<IClausePart>
    {
        [JsonProperty]
        public string Id { get; set; }
        [JsonProperty]
        public string text { get; set; }
        [JsonProperty]
        public List<Dictionary<string, List<Value>>> tagging { get; set; }
        [JsonProperty]
        public List<IClausePart> subunits { get; set; }
        public string Jsonize()
        {
            string jsonedClause = JsonConvert.SerializeObject(this, Formatting.Indented);
            return jsonedClause;
        }

        public string Output()
        {
            throw new NotImplementedException();
        }
    }
}
