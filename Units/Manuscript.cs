using System.Collections.Generic;
using ManuscriptsProcessor.Values;
using Newtonsoft.Json;

namespace ManuscriptsProcessor.Units
{
	public class Manuscript : Unit
	{
		[JsonProperty]
		public List<Text> texts {get; set;}
		[JsonProperty]
		public string filePath {get; set;}
		[JsonProperty]
		public string googleDocPath {get; set;}

		[JsonConstructor]
        public Manuscript(string _id, string _value, string _filePath, string _googleDocPath, List<Dictionary<string, List<Value>>> _tagging, List<Text> _texts)
        {
            id = _id;
            name = _value;
            filePath = _filePath;
            googleDocPath = _googleDocPath;
            tagging = _tagging;
            texts = _texts;
        }

        public Manuscript(string _id, string _value, string _filePath, string _googleDocPath)
        {
            id = _id;
            name = _value;
            filePath = _filePath;
            googleDocPath = _googleDocPath;
        }

        public Manuscript()
        {

        }

	}
}