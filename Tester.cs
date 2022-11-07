using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanEncoder
{
    public class Tester
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Your string: ");
            string input = Console.ReadLine();

            HuffTree huffTree = new HuffTree(input);

            BitArray huffCode = huffTree.Encode();

            Console.WriteLine("Huffman encoded: ");
            foreach (bool bit in huffCode)
                Console.Write((bit ? 1 : 0) + "");

            Console.WriteLine();

            Console.WriteLine(huffTree.Decode(huffCode));

            Console.ReadLine();
        }
    }
}
