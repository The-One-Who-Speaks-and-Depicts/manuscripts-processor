using System.Collections.Generic;
using Newtonsoft.Json;
using ManuscriptsProcessor.Values;

namespace ManuscriptsProcessor.Fields
{
	public class Tree
	{
		[JsonProperty]
		public List<Node> nodes {get; set;}
		[JsonProperty]
		public List<Connection> connections {get; set;}

		[JsonConstructor]
		public Tree(List<Node> _nodes, List<Connection> _connections)
		{
			nodes = _nodes;
			connections = _connections;
		}

		public Tree()
		{
			nodes.Add(new Node() { content = "S", type = "Root"});
		}
	}
}