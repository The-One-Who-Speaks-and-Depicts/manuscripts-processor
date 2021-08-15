using System.Collections.Generic;
using ManuscriptsProcessor.Values;
using ManuscriptsProcessor.Fields;
using Newtonsoft.Json;

namespace ManuscriptsProcessor.Units 
{    
	public class Clause : Unit, ISequenced
	{
		[JsonProperty]
		public List<Token> tokens {get; set;}
        [JsonProperty]
        public Tree parsing {get; set;}
        [JsonProperty]
        public string placeInRow {get; set;}

		[JsonConstructor]
        public Clause(string _clauseID, string _clauseText, List<Tagging> _clauseFields, List<Token> _tokens, Tree _parsing, string _placeInRow)
        {
            Id = _clauseID;
            name = _clauseText;
            tagging = _clauseFields;
            tokens = _tokens;
            parsing = _parsing;
            placeInRow = _placeInRow;
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