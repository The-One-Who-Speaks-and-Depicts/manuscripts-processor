using System.Collections.Generic;
using ManuscriptsProcessor.Values;
using Newtonsoft.Json;

namespace ManuscriptsProcessor.Units
{
	public class Grapheme : Unit, ISequenced
	{
        [JsonProperty]
        public string placeInRow {get; set;}

		[JsonConstructor]
        public Grapheme(List<Tagging> _fields, string _graphemeID, string _grapheme, string _placeInRow)
        {
        	tagging = _fields;
            Id = _graphemeID;
            name = _grapheme;
            placeInRow = _placeInRow;
        }        
        
        public Grapheme(string _graphemeID, string _grapheme)
        {           
            Id = _graphemeID;
            name = _grapheme;
        }

        public Grapheme()
        {

        }

	}
}