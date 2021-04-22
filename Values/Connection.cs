using Newtonsoft.Json;

namespace ManuscriptsProcessor.Values
{
	public class Connection
	{
		[JsonProperty]
		public Node mainNode {get; set;}
		[JsonProperty]
		public Node dependentNode {get; set;}
		[JsonProperty]
		public string relation {get; set;}

		[JsonConstructor]
		public Connection(Node _mainNode, Node _dependentNode, string _relation)
		{
			mainNode = _mainNode;
			dependentNode = _dependentNode;
			relation = _relation;
		}

		public Connection()
		{
			
		}
	}
}