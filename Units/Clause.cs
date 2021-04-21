using System.Collections.Generic;
using ManuscriptsProcessor.Values;
using Newtonsoft.Json;

namespace ManuscriptsProcessor.Units 
{
	public class Clause : Unit
	{
		[JsonProperty]
		public List<Unit> lesserUnits {get; set;}
	}
}