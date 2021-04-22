using System.Collections.Generic;
using ManuscriptsProcessor.Values;
using ManuscriptsProcessor.Fields;
using Newtonsoft.Json;

namespace ManuscriptsProcessor.Units 
{    
	public class Clause : Unit
	{
		[JsonProperty]
		public List<Token> tokens {get; set;}
        [JsonProperty]
        public Tree parsing {get; set;}

		[JsonConstructor]
        public Clause(string _clauseID, string _clauseText, List<Dictionary<string, List<Value>>> _clauseFields, List<Token> _tokens, Tree _parsing)
        {
            id = _clauseID;
            name = _clauseText;
            tagging = _clauseFields;
            tokens = _tokens;
            parsing = _parsing;
        }
        public Clause(string _clauseID, string _clauseText)
        {
            id = _clauseID;
            name = _clauseText;
        }

        public Clause()
        {

        }
	}
}