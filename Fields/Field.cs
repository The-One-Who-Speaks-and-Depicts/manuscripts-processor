using System;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace ManuscriptsProcessor.Fields
{
	public class Field
	{
		[JsonProperty]
		public string Id {get; set;}
		[JsonProperty]
		public string description {get; set;}
		[JsonProperty]
		public bool isMultiple {get; set;}
		[JsonProperty]
		public bool isUserFilled {get; set;}
		[JsonProperty]
		public string host {get; set;}
		[JsonProperty]
		public string possessed {get; set;}
		[JsonProperty]
		public Dictionary<string, List<string>> connectedFields { get; set; }
		[JsonProperty]
		public List<object> values {get; set;}

		[JsonConstructor]
        public Field(string _id, List<object> _values, string _description,  bool _isUserFilled, bool _isMultiple, string _host, string _possessed, Dictionary<string, List<string>> _connectedFields)
        {
            Id = _id;
            values = _values;
            description = _description;
            isUserFilled = _isUserFilled;
            isMultiple = _isMultiple;
            host = _host;
            possessed = _possessed;
            connectedFields = _connectedFields;
            values = _values;
        }

        public Field()
        {

        }
	}
}