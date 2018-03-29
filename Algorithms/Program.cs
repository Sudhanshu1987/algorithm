using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {

        private static long[] nodeWeights;

        public static void Main(string[] args)
        {
            var numOfNodes = Int64.Parse(Console.ReadLine());

            var nodeWeightsString = Console.ReadLine().Split(' ');

            nodeWeights = new long[numOfNodes];

            List<long>[] adjacencyList = new List<long>[numOfNodes];

            int i = 0;

            foreach(var weight in nodeWeightsString)
            {
                nodeWeights[i++] = Int64.Parse(weight);
            }

            for(int j = 0; j < numOfNodes - 1; j++)
            {
                var edge = Console.ReadLine();
                var edgeArrayString = edge.Split(' ');
                var source = Int64.Parse(edgeArrayString[0]);
                var target = Int64.Parse(edgeArrayString[1]);

                var list = adjacencyList[source - 1];

                if(list == null)
                {
                    list = new List<long>();
                    adjacencyList[source - 1] = list;
                }

                list.Add(target - 1);

                list = adjacencyList[target - 1];

                if (list == null)
                {
                    list = new List<long>();
                    adjacencyList[target - 1] = list;
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
                    if(vertex < source)
                        continue;
                    if(EqualTreeOR(adjacencyList,source, vertex))
                    {
                        choosenEdges++;
                    }
                }
            }

            Console.WriteLine(choosenEdges);
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
                    treeOr = treeOr | CalculateTreeOr(adjacencyList, node, startingVertex, vertexToAvoid, visitedNodes);
                }
            }

            treeOr = treeOr | nodeWeights[source];
            return treeOr;
        }
    }
}