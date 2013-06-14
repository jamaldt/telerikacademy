using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Problem2_Shoping_Center
{
    public class Program
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            string[] inputCommands = ReadInputCommands();

            StringBuilder result = new StringBuilder();
            ShoppingCenterManager manager = new ShoppingCenterManager();

            for (int i = 0; i < inputCommands.Length; i++)
            {
                Command command = new Command(inputCommands[i]);
                string output = manager.Process(command);
                result.AppendLine(output);
            }

            Console.Write(result.ToString());
        }

        private static string[] ReadInputCommands()
        {
            int linesCount = int.Parse(Console.ReadLine());
            string[] commandsInput = new string[linesCount];
            for (int i = 0; i < linesCount; i++)
            {
                commandsInput[i] = Console.ReadLine();
            }

            return commandsInput;
        }
    }

    internal class Product// : IComparable<Product>
    {
        public Product(string name, decimal price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }

        public string Name { get; set;}
        public decimal Price { get; set;}
        public string Producer { get; set;}

        /*
        public int CompareTo(Product other)
        {
            int compareResult = this.Name.CompareTo(other.Name);
            if (compareResult == 0)
            {
                compareResult = this.Producer.CompareTo(other.Producer);
            }
            //if (compareResult == 0)
            //{
            //    compareResult = this.Price.CompareTo(other.Price);
            //}
            return compareResult;
        }
        */
        public override string ToString()
        {
            string output = String.Format("{{{0};{1};{2:0.00}}}", this.Name, this.Producer, this.Price);
            return output;
        }
    }

    internal class Command
    {
        public Command(string inputCommand)
        {
            int cmdLastIndex = inputCommand.IndexOf(' ');
            if (cmdLastIndex == -1)
            {
                throw new ArgumentException("Invalid command: " + inputCommand);
            }

            this.Name = inputCommand.Substring(0, cmdLastIndex);

            string argumentsString = inputCommand.Substring(cmdLastIndex + 1);
            string[] commandArguments = argumentsString.Split(';');
            for (int i = 0; i < commandArguments.Length; i++)
            {
                string argument = commandArguments[i].Trim();
                commandArguments[i] = argument;
            }

            this.Arguments = commandArguments;
        }

        public string Name { get; set; }
        public string[] Arguments { get; set; }
    }

    internal class ShoppingCenterManager
    {
        private const string cmdAddProduct = "AddProduct";
        private const string cmdDeleteProducts = "DeleteProducts";
        private const string cmdFindProductsByName = "FindProductsByName";
        private const string cmdFindProductsByPriceRange = "FindProductsByPriceRange";
        private const string cmdFindProductsByProducer = "FindProductsByProducer";
        private const string noProductFound = "No products found";

        private ProductsCatalog catalog;

        public ShoppingCenterManager()
        {
            this.catalog = new ProductsCatalog();
        }

        internal string Process(Command command)
        {
            string output;
            switch (command.Name)
            {
                case cmdAddProduct:
                    output = AddProduct(command.Arguments);
                    break;
                case cmdDeleteProducts:
                    output = DeleteProducts(command.Arguments);
                    break;
                case cmdFindProductsByName:
                    output = FindProductsByName(command.Arguments[0]);
                    break;
                case cmdFindProductsByPriceRange:
                    output = FindProductsByPriceRange(command.Arguments);
                    break;
                case cmdFindProductsByProducer:
                    output = FindProductsByProducer(command.Arguments[0]);
                    break;
                default:
                    throw new ArgumentException("No such command: " + command);
            }

            return output;
        }

        private string FindProductsByProducer(string producer)
        {
            List<Product> products = catalog.FindByProducer(producer);
            return FindProductFormatResult(products);
        }

        private string FindProductsByPriceRange(string[] args)
        {
            decimal fromPrice = decimal.Parse(args[0]);
            decimal toPrice = decimal.Parse(args[1]);
            List<Product> products = catalog.FindByPriceRange(fromPrice, toPrice);
            return FindProductFormatResult(products);
        }

        private string FindProductsByName(string name)
        {
            List<Product> products = catalog.FindByName(name);
            return FindProductFormatResult(products);

        }

        private static string FindProductFormatResult(List<Product> products)
        {
            if (products.Count == 0)
            {
                return noProductFound;
            }
            else
            {
                StringBuilder output = new StringBuilder();
                foreach (var product in products)
                {
                    output.AppendLine(product.ToString());
                }

                output.Length -= 2;
                return output.ToString();
            }
        }

        private string DeleteProducts(string[] args)
        {
            int deletedProductsCount;
            if (args.Length == 1)
            {
                string producer = args[0];
                deletedProductsCount = catalog.Delete(producer);
            }
            else if (args.Length == 2)
            {
                string name = args[0];
                string producer = args[1];
                deletedProductsCount = catalog.Delete(name, producer);
            }
            else
            {
                throw new ArgumentException(cmdDeleteProducts + " command arguments length wrong: " + args.Length);
            }

            if (deletedProductsCount == 0)
            {
                return noProductFound;
            }
            else
            {
                return deletedProductsCount + " products deleted";
            }
        }

        private string AddProduct(string[] args)
        {
            string name = args[0];
            decimal price = decimal.Parse(args[1]);
            string producer = args[2];
            Product product = new Product(name, price, producer);
            this.catalog.Add(product);
            return "Product added";
        }
    }

    internal class ProductsCatalogSlow2
    {
        IDictionary<String, List<Product>> productsByProducer = new Dictionary<String, List<Product>>();
        IDictionary<String, List<Product>> productsByName = new Dictionary<String, List<Product>>();

        internal void Add(Product product)
        {
            if (!this.productsByProducer.ContainsKey(product.Producer))
            {
                this.productsByProducer[product.Producer] = new List<Product>();
            }

            this.productsByProducer[product.Producer].Add(product);

            if (!this.productsByName.ContainsKey(product.Name))
            {
                this.productsByName[product.Name] = new List<Product>();
            }

            this.productsByName[product.Name].Add(product);

        }

        internal int Delete(string producer)
        {
            if (this.productsByProducer.ContainsKey(producer))
            {
                List<Product> productsToBeRemoved = this.productsByProducer[producer];
                int removedItemsCount = productsToBeRemoved.Count;
                foreach (var product in productsToBeRemoved)
                {
                    this.productsByName.Remove(product.Name);
                }
                
                this.productsByProducer.Remove(producer);
                return removedItemsCount;
            }

            return 0;
        }

        internal int Delete(string name, string producer)
        {
            if (this.productsByProducer.ContainsKey(producer))
            {
                var products = this.productsByProducer[producer];
                int removedItemsCount = products.RemoveAll(product => product.Name == name);

                if (this.productsByName.ContainsKey(name))
                {
                    products = this.productsByName[name];
                    products.RemoveAll(product => product.Producer == producer);
                }

                return removedItemsCount;
            }

            return 0;
        }

        internal List<Product> FindByName(string name)
        {
            if (this.productsByName.ContainsKey(name))
            {
                List<Product> foundItems = this.productsByName[name];
                return SortAlphabeticaly(foundItems);
            }

            return new List<Product>();
        }

        internal List<Product> FindByPriceRange(decimal fromPrice, decimal toPrice)
        {
            List<Product> foundItems = new List<Product>();
            foreach (var product in productsByProducer)
            {
                foreach (var p in product.Value)
                {
                    if (p.Price >= fromPrice && p.Price <= toPrice)
                    {
                        foundItems.Add(p);
                    }
                }
            }

            return SortAlphabeticaly(foundItems);
        }

        internal List<Product> FindByProducer(string producer)
        {
            if (this.productsByProducer.ContainsKey(producer))
            {
                List<Product> foundItems = this.productsByProducer[producer];
                return SortAlphabeticaly(foundItems);
            }

            return new List<Product>();
        }

        private List<Product> SortAlphabeticaly(List<Product> foundItems)
        {
            var products = foundItems.OrderBy(x => x.Name).ThenBy(x => x.Producer).ThenBy(x => x.Price).ToList();
            return products;
        }

        private static List<Product> SortAlphabeticaly1(List<Product> foundItems)
        {
            foundItems.Sort();
            List<Product> newl = foundItems;
            return newl;
        }
    }

    internal class ProductsCatalog
    {
        IDictionary<String, List<Product>> productsByProducer = new Dictionary<String, List<Product>>();
        IDictionary<String, List<Product>> productsByName = new Dictionary<String, List<Product>>();
        IDictionary<decimal, List<Product>> productsByPrice = new SortedDictionary<decimal, List<Product>>();

        internal void Add(Product product)
        {
            if (!this.productsByProducer.ContainsKey(product.Producer))
            {
                this.productsByProducer[product.Producer] = new List<Product>();
            }

            this.productsByProducer[product.Producer].Add(product);

            if (!this.productsByName.ContainsKey(product.Name))
            {
                this.productsByName[product.Name] = new List<Product>();
            }

            this.productsByName[product.Name].Add(product);

            if (!this.productsByPrice.ContainsKey(product.Price))
            {
                this.productsByPrice[product.Price] = new List<Product>();
            }

            this.productsByPrice[product.Price].Add(product);

        }

        internal int Delete(string producer)
        {
            if (this.productsByProducer.ContainsKey(producer))
            {
                List<Product> productsToBeRemoved = this.productsByProducer[producer];
                int removedItemsCount = productsToBeRemoved.Count;
                foreach (var product in productsToBeRemoved)
                {
                    this.productsByName.Remove(product.Name);

                    if (this.productsByPrice.ContainsKey(product.Price))
                    {
                        List<Product> productsFromPriceDictionary = this.productsByPrice[product.Price];
                        foreach (var item in productsFromPriceDictionary)
                        {
                            if (item.Producer == producer)
                            {
                                productsFromPriceDictionary.Remove(item);
                            }
                        }
                    }
                    
                }

                this.productsByProducer.Remove(producer);
                return removedItemsCount;
            }

            return 0;
        }

        internal int Delete(string name, string producer)
        {
            if (this.productsByProducer.ContainsKey(producer))
            {
                int removedItemsCount = 0;
                List<Product> productsToEvaluate = this.productsByProducer[producer];
                foreach (var product in productsToEvaluate)
                {
                    if (product.Name.Equals(name))
                    {
                        removedItemsCount++;
                        this.productsByName.Remove(product.Name)
                    }
                }

                return removedItemsCount;
            }

            return 0;
        }

        internal List<Product> FindByName(string name)
        {
            if (this.productsByName.ContainsKey(name))
            {
                List<Product> foundItems = this.productsByName[name];
                return SortAlphabeticaly(foundItems);
            }

            return new List<Product>();
        }

        internal List<Product> FindByPriceRange(decimal fromPrice, decimal toPrice)
        {
            List<Product> foundItems = new List<Product>();
            foreach (var product in productsByProducer)
            {
                foreach (var p in product.Value)
                {
                    if (p.Price >= fromPrice && p.Price <= toPrice)
                    {
                        foundItems.Add(p);
                    }
                }
            }

            return SortAlphabeticaly(foundItems);
        }

        internal List<Product> FindByProducer(string producer)
        {
            if (this.productsByProducer.ContainsKey(producer))
            {
                List<Product> foundItems = this.productsByProducer[producer];
                return SortAlphabeticaly(foundItems);
            }

            return new List<Product>();
        }

        private List<Product> SortAlphabeticaly(List<Product> foundItems)
        {
            var products = foundItems.OrderBy(x => x.Name).ThenBy(x => x.Producer).ThenBy(x => x.Price).ToList();
            return products;
        }

        private static List<Product> SortAlphabeticaly1(List<Product> foundItems)
        {
            foundItems.Sort();
            List<Product> newl = foundItems;
            return newl;
        }
    }
}
