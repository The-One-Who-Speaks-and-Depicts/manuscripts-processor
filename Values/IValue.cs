using System.Collections.Generic;
using ManuscriptsProcessor.Units;

namespace ManuscriptsProcessor.Values
{
	public interface IValue 
	{
		public string name {get; set;}
		public List<IUnit> connectedUnits {get; set;}
	}
}