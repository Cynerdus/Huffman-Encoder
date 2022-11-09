# HuffmanEncoder

Huffman Coding represents of one the basic ways to encode information, which may be used for further applications such as compressing data packages.

## How does it work?

The algorithm will determine the frequency of each individual character in the parsed data block, asigning it in a dictionary's entry. Based on this dictionary, a list will be created. By taking the first two nodes by frequency value, a new parent node will be formed and added in the list. The 2 initials nodes will be deleted afterwards, and the process wil be repeated until the list has the size of one. This is called the Huffman Tree.

### Encoding

