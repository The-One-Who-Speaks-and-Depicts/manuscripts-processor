using System.Collections.Generic;
using ManuscriptsProcessor.Values;
using Newtonsoft.Json;

namespace ManuscriptsProcessor.Units
{
	public class Realization : Unit 
	{
		[JsonProperty]
		public List<Grapheme> graphemes {get; set;}
		[JsonProperty]
		public string shownRealization {get; set;}

		[JsonConstructor]
        public Realization(List<Dictionary<string, List<Value>>> _fields, string _realizationID, string _lexemeOne, string _lexemeTwo, List<Grapheme> _letters)
        {            
            tagging = _fields;
            id = _realizationID;
            name = _lexemeOne;
            shownRealization = _lexemeTwo;
            graphemes = _letters;
        }
        


        public Realization(string _realizationID, string _lexemeOne, string _lexemeTwo)
        {            
            id = _realizationID;
            name = _lexemeOne;
            shownRealization = _lexemeTwo;
        }

        public Realization()
        {

        }

	}
}