using System.Collections.Generic;
using ManuscriptsProcessor.Units;

namespace ManuscriptsProcessor.Values
{
	public class Value 
	{
		public string name {get; set;}
		public List<Unit> connectedUnits {get; set;}
	}
}