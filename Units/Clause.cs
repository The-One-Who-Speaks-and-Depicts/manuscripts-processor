using System.Collections.Generic;
using ManuscriptsProcessor.Values;
using Newtonsoft.Json;

namespace ManuscriptsProcessor.Units 
{
	public class Clause : Unit
	{
		[JsonProperty]
		public List<Realization> realizations {get; set;}

		[JsonConstructor]
        public Clause(string _clauseID, string _clauseText, List<Dictionary<string, List<Value>>> _clauseFields, List<Realization> _realizations)
        {
            id = _clauseID;
            name = _clauseText;
            tagging = _clauseFields;
            realizations = _realizations;
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