using System.Collections.Generic;
using ManuscriptsProcessor.Values;
using Newtonsoft.Json;

namespace ManuscriptsProcessor.Units
{
	public class Token : Unit, ISequenced
	{
		[JsonProperty]
		public List<Grapheme> graphemes {get; set;}
		[JsonProperty]
		public string shownToken {get; set;}
        [JsonProperty]
        public string placeInRow {get; set;}

		[JsonConstructor]
        public Token(List<Tagging> _fields, string _tokenID, string _lexemeOne, string _lexemeTwo, List<Grapheme> _letters, string _placeInRow)
        {            
            tagging = _fields;
            Id = _tokenID;
            name = _lexemeOne;
            shownToken = _lexemeTwo;
            graphemes = _letters;
            placeInRow = _placeInRow;
        }
        


        public Token(string _tokenID, string _lexemeOne, string _lexemeTwo)
        {            
            Id = _tokenID;
            name = _lexemeOne;
            shownToken = _lexemeTwo;
        }

        public Token()
        {

        }

	}
}