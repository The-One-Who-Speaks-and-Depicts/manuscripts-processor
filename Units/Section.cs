using System.Collections.Generic;
using ManuscriptsProcessor.Values;
using Newtonsoft.Json;

namespace ManuscriptsProcessor.Units 
{
    // TODO: think about name of this. Ask to be precise. Think about the paragraph layer. Segment? Section? Part?
	public class Section : Unit
	{
		[JsonProperty]
		public List<Clause> clauses {get; set;}

		[JsonConstructor]
        public Section(string _sectionID, string _sectionName, List<Dictionary<string, List<Value>>> _sectionMetaData, List<Clause> _clauses)
        {
            id = _sectionID;
            name = _sectionName;
            tagging = _sectionMetaData;
            clauses = _clauses;
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