using System.Collections.Generic;
using Newtonsoft.Json;
using ManuscriptsProcessor.Values;

namespace ManuscriptsProcessor.Units
{
	public abstract class Segment : Unit, ISequenced
	{
		public string placeInRow {get; set;}
	}
}