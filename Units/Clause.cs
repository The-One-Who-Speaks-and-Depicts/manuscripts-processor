using System.Collections.Generic;
using ManuscriptsProcessor.Values;
using Newtonsoft.Json;

namespace ManuscriptsProcessor.Units 
{
	public class Clause : Unit
	{
		[JsonProperty]
		public List<Token> tokens {get; set;}

		[JsonConstructor]
        public Clause(string _clauseID, string _clauseText, List<Dictionary<string, List<Value>>> _clauseFields, List<Token> _tokens)
        {
            id = _clauseID;
            name = _clauseText;
            tagging = _clauseFields;
            tokens = _tokens;
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