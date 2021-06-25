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
        public Section(string _sectionID, string _sectionName, List<Tagging> _sectionMetaData, List<Segment> _segments)
        {
            Id = _sectionID;
            name = _sectionName;
            tagging = _sectionMetaData;
            segments = _segments;
        }

        public Section(string _sectionID, string _sectionName)
        {
            Id = _sectionID;
            name = _sectionName;
        }

        public Section()
        {
        	
        }
	}
}