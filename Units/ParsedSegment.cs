using System.Collections.Generic;
using Newtonsoft.Json;
using ManuscriptsProcessor.Values;

namespace ManuscriptsProcessor.Units
{
	public class ParsedSegment : Segment
	{
		[JsonProperty]
		public List<Clause> clauses;

		[JsonConstructor]
		public ParsedSegment(string _segmentID, string _segmentText, List<Tagging> _segmentFields, List<Clause> _clauses)
		{
			Id = _segmentID;
			name = _segmentText;
			tagging = _segmentFields;
			clauses = _clauses;
		}

		public ParsedSegment(string _segmentID, string _segmentText)
		{
			Id = _segmentID;
			name = _segmentText;
		}

		public ParsedSegment()
		{

		}
	}
}