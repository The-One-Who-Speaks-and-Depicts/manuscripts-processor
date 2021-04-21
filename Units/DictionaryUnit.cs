using System.Collections.Generic;
using Newtonsoft.Json;

namespace ManuscriptsProcessor.Units
{
	public class DictionaryUnit 
	{
        [JsonProperty]
        public string id {get ; set;}
        [JsonProperty]
        public string lemma {get; set;}
        [JsonProperty]
        public List<Realization> realizations {get; set;}

        [JsonConstructor]
        public DictionaryUnit(string _ID, string _lemma, List<Realization> _realizations)
        {
            id = _ID;
            lemma = _lemma;
            realizations = _realizations;
        }

        public DictionaryUnit()
        {
            
        }		
	}
}