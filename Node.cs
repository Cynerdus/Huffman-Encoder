using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanEncoder
{
    public class Node
    {
        private Node Left;
        private Node Right;

        private char Character;
        private int Frequency;

        public char Character_ { get => Character; set => Character = value; }
        public int Frequency_ { get => Frequency; set => Frequency = value; }
        public Node Left_ { get => Left; set => Left = value; }
        public Node Right_ { get => Right; set => Right = value; }

        public Node() {}

        public Node(char character, int frequency)
        {
            Character = character;  
            Frequency = frequency;
        }
    }
}
