using System.Collections.Generic;
using ManuscriptsProcessor.Values;
using Newtonsoft.Json;

namespace ManuscriptsProcessor.Units 
{
    // TODO: think about name of this. Ask to be precise. Think about the paragraph layer. Segment? Section? Part?
	public class Text : Unit
	{
		[JsonProperty]
		public List<Clause> clauses {get; set;}

		[JsonConstructor]
        public Text(string _textID, string _textName, List<Dictionary<string, List<Value>>> _textMetaData, List<Clause> _clauses)
        {
            id = _textID;
            name = _textName;
            tagging = _textMetaData;
            clauses = _clauses;
        }

        public Text(string _textID, string _textName)
        {
            id = _textID;
            name = _textName;
        }

        public Text()
        {
        	
        }
	}
}