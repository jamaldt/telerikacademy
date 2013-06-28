using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2_3D_Labyrinth
{
    public class Graph
    {
        private int verticesCount; // number of verices
        private int edgesCount; // number of edges
        private List<int>[] adj; // adjacency lists

        // create a  V -vertex graph with no edges
        public Graph(int verticesCount)
        {
            this.verticesCount = verticesCount;
            this.edgesCount = 0;
            adj = new List<int>[verticesCount]; // Create array of lists.

            // Initialize all lists to empty
            for (int v = 0; v < verticesCount; v++)
            {
                adj[v] = new List<int>();
            }
        }

        // read a graph from input stream  in
        public Graph(int verticesCount, string[] input)
            : this(verticesCount)
        {
            for (int i = 0; i < verticesCount; i++)
            {
                // Add an edge.
                string[] vertices = input[i].Split(' ');
                int v = int.Parse(vertices[0]); // Read a vertex,
                int w = int.Parse(vertices[1]); // read another vertex,
                this.AddEdge(v, w); // and add edge connecting them.
            }
        }

        // get number of vertices
        public int V { get { return this.verticesCount; } }

        // get number of edges
        public int E { get { return this.edgesCount; } }

        // add edge  v-w to this graph
        public void AddEdge(int v, int w)
        {
            this.adj[v].Add(w); // Add w to v’s list.
            this.adj[w].Add(v); // Add v to w’s list.
            this.edgesCount++;
        }

        // vertices adjacent to  v
        public IEnumerable<int> Adj(int v)
        {
            return this.adj[v];
        }

        // compute the degree of v (with hove many vertexes current vertex is connected
        public static int Degree(Graph G, int v)
        {
            int degree = 0;
            foreach (var vertex in G.Adj(v))
            {
                degree += 1;
            }

            return degree;
        }

        // compute maximum degree
        public static int MaxDegree(Graph G)
        {
            int max = 0;
            for (int v = 0; v < G.V; v++)
            {
                if (Graph.Degree(G, v) > max)
                {
                    max = Graph.Degree(G, v);
                }
            }

            return max;
        }

        // compute average degree
        public static int AvgDegree(Graph G)
        {
            return 2 * G.E / G.V;
        }

        // count self-loops
        public static int numberOfSelfLoops(Graph G)
        {
            int count = 0;
            for (int v = 0; v < G.V; v++)
            {
                foreach (int w in G.Adj(v))
                {
                    if (v == w)
                    {
                        count++;
                    }
                }
            }

            return count / 2; // each edge counted twice
        }

        //  string representation of the graph’s adjacency lists (instance method in  Graph )
        public override string ToString()
        {
            String s = this.V + " vertices, " + E + " edges\n";
            for (int v = 0; v < V; v++)
            {
                s += v + ": ";
                foreach (int w in this.Adj(v))
                {
                    s += w + " ";
                }

                s += "\n";
            }

            return s;
        }

    }
}
