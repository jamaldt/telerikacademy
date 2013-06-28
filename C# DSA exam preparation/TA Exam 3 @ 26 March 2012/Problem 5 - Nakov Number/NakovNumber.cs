using System;
using System.Collections.Generic;

class NakovNumber
{
    private static IDictionary<string, int> nakovScore = new SortedDictionary<string, int>();

    static void Main(string[] args)
    {

            string input = Console.ReadLine();
            string[] input1 = input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            ISet<Publication> publications = new HashSet<Publication>();
            for (int i = 0; i < input1.Length; i++)
            {
                string[] authors = input1[i].Split(new char[] { '"', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Publication pub = new Publication(authors);
                publications.Add(pub);
            }

            Tree<string> nakovTree = GenerateNakovTree(publications);


            // Add all authors without nakov score
            foreach (var publication in publications)
            {
                foreach (var author in publication)
                {
                    nakovScore.Add(author, -1);
                }
            }

            // Add all other authors
            int score = 0;
            nakovScore.Add(nakovTree.Value, score);

        try
        {
            //TraverseTree(nakovTree, score, nakovScore);
            TraverseTree(nakovTree, score);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            throw new ExecutionEngineException(ex.Message);
        }
            PrintOutput(nakovScore);
    }

    private static void TraverseTree(Tree<string> root, int score)
    {
        score += 1;
        if (root.Leafs.Count == 0)
        {
            return;
        }

        foreach (var leaf in root.Leafs)
        {
            nakovScore.Add(leaf.Value, score);
            TraverseTree(leaf, score);
        }
    }

    private static void PrintOutput(IDictionary<string, int> nakovScore)
    {
        foreach (var item in nakovScore)
        {
            Console.WriteLine(item.Key + " " + item.Value);
        }
    }

    private static Tree<string> GenerateNakovTree(ISet<Publication> publications)
    {
        Tree<string> tree = new Tree<string>("NAKOV");
        Queue<Tree<string>> queue = new Queue<Tree<string>>();
        queue.Enqueue(tree);

        IList<Publication> publicationsToDel = new List<Publication>();
        while (queue.Count > 0)
        {
            Tree<string> node = queue.Dequeue();
            foreach (var publication in publications)
            {
                if (publication.ContainsAuthor(node.Value))
                {
                    publicationsToDel.Add(publication);
                    publication.RemoveAuthor(node.Value);

                    foreach (var author in publication)
                    {
                        if (!node.LeafsContainsValue(author))
                        {
                            Tree<string> leaf = node.Add(author);
                            queue.Enqueue(leaf);
                        }
                    }
                }
            }

            // now delete evaluated publications from list;
            foreach (var publication in publicationsToDel)
            {
                publications.Remove(publication);
            }
            publicationsToDel.Clear();
        }

        return tree;
    }
}

class Publication : IEnumerable<string>
{
    private ISet<string> authors;

    public Publication(string[] authors)
    {
        this.authors = new HashSet<string>();
        foreach (var author in authors)
        {
            this.authors.Add(author);
        }
    }

    public bool ContainsAuthor(string author)
    {
        if (this.authors.Contains(author))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool RemoveAuthor(string author)
    {
        return this.authors.Remove(author);
    }

    public IEnumerator<string> GetEnumerator()
    {
        return new AuthorsEnumerator(this.authors);
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class AuthorsEnumerator : IEnumerator<string>
    {
        private string[] values;
        private int position = -1;

        public AuthorsEnumerator(ISet<string> set)
        {
            this.values = new string[set.Count];
            int index = 0;
            foreach (var item in set)
            {
                this.values[index] = item;
                index++;
            }
        }
        public string Current
        {
            get { return this.values[position]; }
        }

        public void Dispose()
        {
        }

        object System.Collections.IEnumerator.Current
        {
            get { return this.Current; }
        }

        public bool MoveNext()
        {
            this.position++;
            return (this.position < this.values.Length);
        }

        public void Reset()
        {
            this.position = 0;
        }
    }
}

class Tree<T>
{
    private T value;
    private IList<Tree<T>> leafs;
    private ISet<T> leafsValues;

    public Tree(T value)
    {
        this.value = value;
        this.leafs = new List<Tree<T>>();
        this.leafsValues = new HashSet<T>();
    }

    public Tree<T> Add(T value)
    {
        var leaf = new Tree<T>(value);
        this.leafs.Add(leaf);
        this.leafsValues.Add(value);
        return leaf;
    }

    public bool LeafsContainsValue(T value)
    {
        return this.leafsValues.Contains(value);
    }

    public T Value { get { return this.value; }  }
    public IList<Tree<T>> Leafs
    {
        get
        {
            return this.leafs;
        }
    }
}




