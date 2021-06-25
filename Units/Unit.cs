using System.Collections.Generic;
using ManuscriptsProcessor.Values;
using Newtonsoft.Json;

namespace ManuscriptsProcessor.Units
{
	public abstract class Unit
	{
		[JsonProperty]
		public string name {get; set;}
		[JsonProperty]
		public string Id {get; set;}
		[JsonProperty]
		public List<Tagging> tagging {get; set;}
	}
}
