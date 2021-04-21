using System;
using System.Collections.Generic;


namespace ManuscriptsProcessor.Fields
{
	public class Field
	{
		public string id {get; set;}
		public string name {get; set;}
		public bool isMultiple {get; set;}
		public bool isRestricted {get; set;}
		public Type host {get; set;}
		public Type possessed {get; set;}
		public Dictionary<string, List<string>> connectedFields { get; set; }
	}
}