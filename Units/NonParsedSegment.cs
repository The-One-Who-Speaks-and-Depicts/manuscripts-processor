using System.Collections.Generic;
using Newtonsoft.Json;
using ManuscriptsProcessor.Values;

namespace ManuscriptsProcessor.Units
{
	public class NonParsedSegment : Segment
	{
		[JsonProperty]
		public List<Token> tokens;

		[JsonConstructor]
		public NonParsedSegment(string _segmentID, string _segmentText, List<Tagging> _segmentFields, List<Token> _tokens, string _placeInRow)
		{
			Id = _segmentID;
			name = _segmentText;
			tagging = _segmentFields;
			tokens = _tokens;
			placeInRow = _placeInRow;
		}

		public NonParsedSegment(string _segmentID, string _segmentText)
		{
			Id = _segmentID;
			name = _segmentText;
		}

		public NonParsedSegment()
		{

		}
	}
}


