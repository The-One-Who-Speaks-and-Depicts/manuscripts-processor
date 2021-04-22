using System.Collections.Generic;
using ManuscriptsProcessor.Values;
using Newtonsoft.Json;

namespace ManuscriptsProcessor.Units 
{
    
	public class Section : Unit
	{
		[JsonProperty]
		public List<Segment> segments {get; set;}

		[JsonConstructor]
        public Section(string _sectionID, string _sectionName, List<Dictionary<string, List<Value>>> _sectionMetaData, List<Segment> _segments)
        {
            id = _sectionID;
            name = _sectionName;
            tagging = _sectionMetaData;
            segments = _segments;
        }

        public Section(string _sectionID, string _sectionName)
        {
            id = _sectionID;
            name = _sectionName;
        }

        public Section()
        {
        	
        }
	}
}