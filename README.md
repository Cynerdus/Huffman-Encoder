# HuffmanEncoder

Huffman Coding represents of one the basic ways to encode information, which may be used for further applications such as compressing data packages.

## How does it work?

The algorithm will determine the frequency of each individual character in the parsed data block, asigning it in a dictionary's entry. Based on this dictionary, a list will be created. By taking the first two nodes by frequency value, a new parent node will be formed and added in the list. The 2 initials nodes will be deleted afterwards, and the process wil be repeated until the list has the size of one. This is called the Huffman Tree. In the Huffman Tree, the leafs represent the target character.

### Encoding

To find the specific code of one character, the inorder search will be used. Following the graph down the lane, a list of bools will be constructed to store the path. For every level withing the tree a label will be added into the list as it follows:
- Value 0 if the direction goes left;
- Value 1 otherwise.

The returned value of the list will represent the path to reach the character in the HuffmanTree.

### Decoding

Decoding a character goes the exact opposite way: Going through the list, the algorithm will go either left or right down in the tree, depending on the path generated previously. If the encoding was done correctly, the decoding function will never return another value than what is expected. 
