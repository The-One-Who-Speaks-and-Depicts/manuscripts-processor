using System.Collections.Generic;

namespace CorpusDraftCSharp
{
    public interface ICorpusUnit
    {
        public string Id {get; set;}
        public string text { get; set; }
        public List<Dictionary<string, List<Value>>> tagging { get; set; }
    }
}
