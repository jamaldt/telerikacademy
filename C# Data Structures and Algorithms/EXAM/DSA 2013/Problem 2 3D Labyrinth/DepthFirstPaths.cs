using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2_3D_Labyrinth
{
    class DepthFirstPaths
    {
        // marked[v] = true if v conected to s
        private bool[] marked;
        // last vertex on known path to this vertex
        private int[] edgeTo;
        // source
        private int s;

        public DepthFirstPaths(Graph G, int s)
        {
            // initialize data structures
            this.marked = new bool[G.V];
            this.edgeTo = new int[G.V];
            this.s = s;
            // find verices connected to s
            this.Dfs(G, s);
        }

        private void Dfs(Graph G, int v)
        {
            this.marked[v] = true;
            foreach (var w in G.Adj(v))
            {
                if (!marked[w])
                {
                    this.Dfs(G, w);
                    this.edgeTo[w] = v;
                }
            }
        }

        public bool HasPathTo(int v)
        {
            return marked[v];
        }

        public IEnumerable<int> PathTo(int v)
        {
            if (!this.HasPathTo(v))
            {
                return null;
            }

            Stack<int> path = new Stack<int>();
            for (int x = v; x != this.s; x = this.edgeTo[x])
            {
                path.Push(x);
            }

            path.Push(this.s);
            return path;
        }

    }
}
