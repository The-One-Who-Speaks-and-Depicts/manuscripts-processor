using System.Collections.Generic;
using ManuscriptsProcessor.Values;
using Newtonsoft.Json;

namespace ManuscriptsProcessor.Units
{
	public class Grapheme : Unit 
	{

		[JsonConstructor]
        public Grapheme(List<Dictionary<string, List<Value>>> _fields, string _graphemeID, string _grapheme)
        {
        	tagging = _fields;
            id = _graphemeID;
            name = _grapheme;
        }        
        
        public Grapheme(string _graphemeID, string _grapheme)
        {           
            id = _graphemeID;
            name = _grapheme;
        }

        public Grapheme()
        {

        }

	}
}