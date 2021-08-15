using System.Collections.Generic;
using ManuscriptsProcessor.Values;
using Newtonsoft.Json;

namespace ManuscriptsProcessor.Units 
{
    
	public class Section : Unit, ISequenced
	{
		[JsonProperty]
		public List<Segment> segments {get; set;}
        [JsonProperty]
        public string placeInRow {get; set;}

		[JsonConstructor]
        public Section(string _sectionID, string _sectionName, List<Tagging> _sectionMetaData, List<Segment> _segments, string _placeInRow)
        {
            Id = _sectionID;
            name = _sectionName;
            tagging = _sectionMetaData;
            segments = _segments;
            placeInRow = _placeInRow;
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