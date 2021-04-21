using System.Collections.Generic;
using ManuscriptsProcessor.Values;

namespace ManuscriptsProcessor.Units
{
	public interface IUnit
	{
		public string value {get; set;}
		public string id {get; set;}
		public List<Dictionary<string, List<Value>>> tagging {get; set;}
		public List<IUnit> lesserUnits {get; set;}
	}
}
