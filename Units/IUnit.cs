using System.Collections.Generic;

namespace ManuscriptsProcessor
{
	public interface IUnit
	{
		public string value {get; set;}
		public string id {get; set;}
		public List<Dictionary<string, List<IValue>>> tagging {get; set;}
		public List<IUnit> lesserUnits {get; set;}
	}
}
