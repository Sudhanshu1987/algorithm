using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program2
    {
        static void Main2(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree();
            int[] arr = { 30, 15, 24, 28, 12, 9, 8, 2, 14, 11, 21, 45};
            binaryTree.createTree(arr);
            Console.Write("\n");
            binaryTree.preOrder(binaryTree.Root);
            Console.Write("\n");
            binaryTree.inOrder(binaryTree.Root);
            Console.Write("\n");
            binaryTree.postOrder(binaryTree.Root);
            Console.Write("\n");
            binaryTree.levelOrderTraversalReverse(binaryTree.Root);

            int[] preOrder = { 30, 15, 12, 9, 8, 2, 11, 14, 24, 21, 28, 45 };
            int[] inOrder = { 2, 8, 9, 11, 12, 14, 15, 21, 24, 28, 30, 45 };
            int[] postOrder = { 2, 8, 11, 9, 14, 12, 21, 28, 24, 15, 45, 30 };


            int preOrderStart = 0;
            var tree = binaryTree.CreateBinaryTree(preOrder, inOrder, 0, preOrder.Length, ref preOrderStart);
            Console.Write("\n");
            binaryTree.postOrder(tree);
        }
    }
}
