using System.Collections.Generic;
using Newtonsoft.Json;
using ManuscriptsProcessor.Values;

namespace ManuscriptsProcessor.Units
{
	public class ParsedSegment : Unit
	{
		[JsonProperty]
		public List<Clause> clauses;

		[JsonConstructor]
		public ParsedSegment(string _segmentID, string _segmentText, List<Dictionary<string, List<Value>>> _segmentFields, List<Clause> _clauses)
		{
			id = _segmentID;
			name = _segmentText;
			tagging = _segmentFields;
			clauses = _clauses;
		}

		public ParsedSegment(string _segmentID, string _segmentText)
		{
			id = _segmentID;
			name = _segmentText;
		}

		public ParsedSegment()
		{

		}
	}
}