using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanEncoder
{
    public class HuffTree
    {
        private List<Node> Nodes;
        private Node Root;
        private Dictionary<char, int> Frequencies = new Dictionary<char, int>();

        public HuffTree(String input)
        {
            Nodes = new List<Node>();
            foreach (char c in input)
            {
                if (!Frequencies.ContainsKey(c))
                    Frequencies.Add(c, 0);
                Frequencies[c]++;
            }

            foreach (KeyValuePair<char, int> entry in Frequencies)
            {
                Node node = new Node(entry.Key, entry.Value);
                Nodes.Add(node);
            }

            while (Nodes.Count > 1)
            {
                List<Node> nodes = Nodes.OrderBy(node => node.Frequency_).ToList<Node>();
                if (nodes.Count > 1)
                {
                    Node left = nodes[0];
                    Node right = nodes[1];

                    Node new_node = new Node('~', left.Frequency_ + right.Frequency_);
                    new_node.Right_ = right;
                    new_node.Left_ = left;

                    Nodes.Add(new_node);
                }

                Root = Nodes.FirstOrDefault();
            }
        }
    }
}
