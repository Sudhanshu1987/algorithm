using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Node
    {
        public Node(int val, Node left, Node right)
        {
            value = val;
            this.left = left;
            this.right = right;
        }

        public int value { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }
    }

    class BinaryTree
    {
        Node root = null;

        public Node Root
        {
            get
            {
                return root;
            }
        }

        public void createTree(int[] val)
        {
            foreach (int v in val)
            {
                root = createNode(root, v);
            }
        }

        private Node createNode(Node root, int v)
        {
            if(root == null)
            {
                Node node = new Node(v,null,null);
                return node;
            }

            if(root.value > v)
            {
                root.left =  createNode(root.left, v);
            }
            else
            {
                root.right = createNode(root.right, v);
            }

            return root;
        }

        public void postOrder(Node node)
        {
            Node rootNode = node;

            Stack<Node> stack = new Stack<Node>();

            while (true)
            {
                while (rootNode != null)
                {
                    stack.Push(rootNode);
                    rootNode = rootNode.left;                    
                }

                if(stack.Count == 0)
                {
                    break;
                }
                else
                {
                    var nd = stack.Pop();
                    if (stack.Count != 0 && nd == stack.Peek())
                    {
                        Console.Write(nd.value + " ");
                        stack.Pop();
                    }
                    else
                    {                        
                        if (nd.right != null)
                        {
                            rootNode = nd.right;
                            stack.Push(nd);
                            stack.Push(nd);
                        }
                        else
                        {
                            Console.Write(nd.value + " ");
                        }
                    }
                }
            }
        }

        public void preOrder(Node node)
        {
            if (node == null)
                return;
            Console.Write(node.value + "\n");
            preOrder(node.left);
            preOrder(node.right);
        }

        public void inOrder(Node node)
        {
            if (node == null)
                return;
            inOrder(node.left);
            Console.Write(node.value + "\n");
            inOrder(node.right);
        }
    }
}
