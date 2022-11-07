using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        private String Input;

        public HuffTree(String input)
        {
            Input = input;
            Nodes = new List<Node>();

            foreach (char c in Input)
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

            Console.WriteLine("Node list:");
            foreach (Node node in Nodes)
            {
                Console.Write("[" + node.Character_ + " " + node.Frequency_ + "] ");
            }

            Console.WriteLine('\n');
            
            while (Nodes.Count is not 1)
            {
                List<Node> nodes = Nodes.OrderBy(node => node.Frequency_).ToList<Node>();
                Nodes.Add(new Node()
                {
                    Character_ = '~',
                    Frequency_ = nodes[0].Frequency_ + nodes[1].Frequency_,
                    Left_ = nodes[0],
                    Right_ = nodes[1]
                });

                Nodes.Remove(nodes[0]);
                Nodes.Remove(nodes[1]);
                Root = Nodes.First();
            }

            Console.WriteLine("Root is: " + Root.Character_ + " " + Root.Frequency_);
            Console.WriteLine("Ordered nodes:");
            inorder(Root);
        }

        private void inorder(Node node)
        {
            if (node is not null)
            {
                inorder(node.Left_);
                Console.WriteLine("Node " + node.Character_ + " with frequency " + node.Frequency_);
                inorder(node.Right_);
            }
        }

        public BitArray Encode()
        {
            List<Boolean> bits = new List<Boolean>();
            Console.WriteLine("Encoding starting...");
            foreach (char c in Input)
            {
                List<Boolean> character_path = rootPathing(Root, c, new List<Boolean>());
                bits.AddRange(character_path);
            }
            Console.WriteLine("Done!");
            return new BitArray(bits.ToArray());
        }

        private List<Boolean> rootPathing(Node node, char character, List<Boolean> path)
        {
            if (node.Left_ is null && node.Right_ is null) // reached leaf
                return (node.Character_.Equals(character)) ? path : null;

            List<Boolean> leftPath = new List<Boolean>();
            List<Boolean> rightPath = new List<Boolean>();

            if (node.Left_ is not null)
            {
                path.Add(false);
                leftPath = rootPathing(node.Left_, character, path);
                if (leftPath is null)
                    path.RemoveAt(path.Count - 1);
                else
                    return leftPath;
            }

            if (node.Right_ is not null)
            {
                path.Add(true);
                rightPath = rootPathing(node.Right_, character, path);
                if (rightPath is null)
                    path.RemoveAt(path.Count - 1);
                else
                    return rightPath;
            }

            return (leftPath is not null) ? leftPath : rightPath;
        }

        public String Decode(BitArray bitPath)
        {
            List<Boolean> path = new List<Boolean>();
            foreach (Boolean bit in bitPath)
                path.Add(bit);

            Node node = Root;
            List<char> message = new List<char>();

            while (path.Count is not 0)
            {
                if (!node.Character_.Equals('~'))
                {
                    message.Add(node.Character_);
                    node = Root;
                }

                node = (path[0] ? node.Right_ : node.Left_);
                path.RemoveAt(0);
            }
            message.Add(node.Character_);

            return new string(message.ToArray());
        }
    }
}
