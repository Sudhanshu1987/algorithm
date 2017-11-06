using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree();
            int[] arr = { 30, 15, 24, 28, 12, 9, 8, 2, 14, 11, 21, 45};
            binaryTree.createTree(arr);
            binaryTree.preOrder(binaryTree.Root);
            binaryTree.inOrder(binaryTree.Root);
            binaryTree.postOrder(binaryTree.Root);
            binaryTree.levelOrderTraversalReverse(binaryTree.Root);
        }
    }
}
