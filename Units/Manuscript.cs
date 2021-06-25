using System.Collections.Generic;
using ManuscriptsProcessor.Values;
using Newtonsoft.Json;

namespace ManuscriptsProcessor.Units
{
	public class Manuscript : Unit
	{
		[JsonProperty]
		public List<Section> sections {get; set;}
		[JsonProperty]
		public string filePath {get; set;}
		[JsonProperty]
		public string googleDocPath {get; set;}

		[JsonConstructor]
        public Manuscript(string _id, string _value, string _filePath, string _googleDocPath, List<Tagging> _tagging, List<Section> _sections)
        {
            Id = _id;
            name = _value;
            filePath = _filePath;
            googleDocPath = _googleDocPath;
            tagging = _tagging;
            sections = _sections;
        }

        public Manuscript(string _id, string _value, string _filePath, string _googleDocPath)
        {
            Id = _id;
            name = _value;
            filePath = _filePath;
            googleDocPath = _googleDocPath;
        }

        public Manuscript()
        {

        }

	}
}