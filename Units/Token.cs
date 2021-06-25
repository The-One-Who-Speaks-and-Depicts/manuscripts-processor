using System.Collections.Generic;
using ManuscriptsProcessor.Values;
using Newtonsoft.Json;

namespace ManuscriptsProcessor.Units
{
	public class Token : Unit 
	{
		[JsonProperty]
		public List<Grapheme> graphemes {get; set;}
		[JsonProperty]
		public string shownToken {get; set;}

		[JsonConstructor]
        public Token(List<Tagging> _fields, string _tokenID, string _lexemeOne, string _lexemeTwo, List<Grapheme> _letters)
        {            
            tagging = _fields;
            Id = _tokenID;
            name = _lexemeOne;
            shownToken = _lexemeTwo;
            graphemes = _letters;
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