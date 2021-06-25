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
        public Clause(string _clauseID, string _clauseText, List<Tagging> _clauseFields, List<Token> _tokens, Tree _parsing)
        {
            Id = _clauseID;
            name = _clauseText;
            tagging = _clauseFields;
            tokens = _tokens;
            parsing = _parsing;
        }
        public Clause(string _clauseID, string _clauseText)
        {
            Id = _clauseID;
            name = _clauseText;
        }

        public Clause()
        {

        }
	}
}