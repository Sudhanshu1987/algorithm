using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        public static void Main(string[] args)
        {
            var numOfInputs = Int64.Parse(Console.ReadLine());

            var nodeWeightsString = Console.ReadLine().Split(' ');

            long[] nodeWeights = new long[numOfInputs];

            List<long>[] adjacencyList = new List<long>[numOfInputs];

            int i = 0;

            foreach(var weight in nodeWeightsString)
            {
                nodeWeights[i++] = Int64.Parse(weight);
            }

            for(int j = 0; j < numOfInputs; j++)
            {
                var edge = Console.ReadLine();
                var edgeArrayString = edge.Split(' ');
                var source = Int64.Parse(edgeArrayString[0]);
                var target = Int64.Parse(edgeArrayString[1]);

                var list = adjacencyList[source - 1];

                if(list == null)
                {
                    list = new List<long>();
                }

                list.Add(target - 1);

                list = adjacencyList[target - 1];

                if (list == null)
                {
                    list = new List<long>();
                }

                list.Add(source - 1);
            }

            int choosenEdges = 0;

            for(long j = 0; j < adjacencyList.Length; j++)
            {
                var source = j;
                var list = adjacencyList[source];
                foreach(var vertex in list)
                {
                    if(EqualTreeOR(adjacencyList,source, vertex))
                    {
                        choosenEdges++;
                    }
                }
            }
        }

        private static bool EqualTreeOR(List<long>[] adjacencyList, long source, long target)
        {
            var visitedNodes = new bool[adjacencyList.Length];
            visitedNodes[source] = true;
            var treeOr1 = CalculateTreeOr(adjacencyList,source,source,target, visitedNodes);
            var treeOr2 = CalculateTreeOr(adjacencyList, target, target, source, visitedNodes);
            return treeOr1 == treeOr2;
        }

        private static long CalculateTreeOr(List<long>[] adjacencyList, long source, long startingVertex, long vertexToAvoid, bool[] visitedNodes)
        {
            var treeOr = 0l;
            var list = adjacencyList[source];
            if(list != null)
            {
                foreach(var node in list)
                {
                    if (node == vertexToAvoid && startingVertex == source || visitedNodes[node] == true)
                        continue;
                    visitedNodes[node] = true;
                    treeOr = treeOr | node;
                    treeOr = treeOr | CalculateTreeOr(adjacencyList, node, startingVertex, vertexToAvoid, visitedNodes);
                }
            }

            return treeOr;
        }
    }
}