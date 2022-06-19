using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace CorpusDraftCSharp
{
    public class SectionGroup : IUnitGroup<IManuscriptPart>
    {
        public string Id { get; set; }
        public string text { get; set; }
        public List<Dictionary<string, List<Value>>> tagging { get; set; }
        public List<IManuscriptPart> subunits { get; set; }
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
