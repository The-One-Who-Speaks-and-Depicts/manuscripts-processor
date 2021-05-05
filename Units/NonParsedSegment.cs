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
		public NonParsedSegment(string _segmentID, string _segmentText, List<Dictionary<string, List<Value>>> _segmentFields, List<Token> _tokens)
		{
			Id = _segmentID;
			name = _segmentText;
			tagging = _segmentFields;
			tokens = _tokens;
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


