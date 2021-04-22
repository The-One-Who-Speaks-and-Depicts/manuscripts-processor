using Newtonsoft.Json;

namespace ManuscriptsProcessor.Values
{
	public class Node
	{
		[JsonProperty]
		public string content {get; set;}
		[JsonProperty]
		public string type {get; set;}

		[JsonConstructor]
		public Node (string _content, string _type)
		{
			content = _content;
			type = _type;
		}

		public Node()
		{

		}
	}
}