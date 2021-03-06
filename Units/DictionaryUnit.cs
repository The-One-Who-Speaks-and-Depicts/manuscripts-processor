using System.Collections.Generic;
using Newtonsoft.Json;

namespace ManuscriptsProcessor.Units
{
	public class DictionaryUnit 
	{
        [JsonProperty]
        public string Id {get ; set;}
        [JsonProperty]
        public string lemma {get; set;}
        [JsonProperty]
        public List<Token> realizations {get; set;}

        [JsonConstructor]
        public DictionaryUnit(string _ID, string _lemma, List<Token> _realizations)
        {
            Id = _ID;
            lemma = _lemma;
            realizations = _realizations;
        }

        public DictionaryUnit()
        {
            
        }		
	}
}