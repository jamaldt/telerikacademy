using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using Wintellect.PowerCollections;

namespace ShoppingCenter
{
    class Product : IComparable<Product>
    {
        public string Name { get; set; }
        public string Producer { get; set; }
        public double Price { get; set; }

        public Product(string name, string producer, double price)
        {
            this.Name = name;
            this.Producer = producer;
            this.Price = price;
        }
      
        public int CompareTo(Product obj)
        {
            return this.Price.CompareTo(obj.Price);
        }

        public override string ToString()
        {
            return String.Format("{{{0};{1};{2:0.00}}}", this.Name, this.Producer, this.Price);
        }
    }

    class ProductsCollection
    {
        private readonly MultiDictionary<string, Product> collectionByProducer;
        private readonly MultiDictionary<string, Product> collectionByName;
        private readonly OrderedBag<Product> collectionByPrice;

        public ProductsCollection()
        {
            this.collectionByProducer = new MultiDictionary<string, Product>(true);
            this.collectionByName = new MultiDictionary<string, Product>(true);
            this.collectionByPrice = new OrderedBag<Product>();
        }

        public string AddProduct(string[] values)
        {
            string result = string.Empty;
            string name = values[0];
            string producer = values[2];
            double price = double.Parse(values[1]);

            Product newProduct = new Product(name, producer, price);

            //Add in products
            if (collectionByName.ContainsKey(name))
            {
                this.collectionByName[name].Add(newProduct);
            }
            else
            {
                this.collectionByName.Add(name, newProduct);
            }

            // Add in producers
            if (this.collectionByProducer.ContainsKey(producer))
            {
                this.collectionByProducer[producer].Add(newProduct);
            }
            else
            {
                this.collectionByProducer.Add(producer, newProduct);
            }

            this.collectionByPrice.Add(newProduct);

            result = "Product added";

            return result;
        }

        public int DeleteProductByName(string name, string producer)
        {
            List<Product> prodsToBeDeleted = new List<Product>();
            int deleted = 0;

            foreach (var prod in this.collectionByName[name])
            {
                if (prod.Producer == producer)
                {
                    prodsToBeDeleted.Add(prod);
                    deleted++;
                }
            }

            foreach (var forDelete in prodsToBeDeleted)
            {
                this.collectionByName[name].Remove(forDelete);
                //this.collectionByProducer[name].Remove(forDelete);
                this.collectionByProducer[forDelete.Producer].Remove(forDelete);
                this.collectionByPrice.Remove(forDelete);
            }

            return deleted;
        }

        public int DeleteProductByProducer(string producer)
        {
            List<Product> prodsToBeDeleted = new List<Product>();

            int deleted = 0;
            foreach (var prod in this.collectionByProducer[producer])
            {
                prodsToBeDeleted.Add(prod);
                deleted++;
            }

            foreach (var forDelete in prodsToBeDeleted)
            {
                this.collectionByProducer[producer].Remove(forDelete);
                this.collectionByName[forDelete.Name].Remove(forDelete);
                this.collectionByPrice.Remove(forDelete);
            }

            return deleted;
        }

        //public List<Product> FindProductsByName(string name)
        public ICollection<Product> FindProductsByName(string name)
        {
            //List<Product> result = new List<Product>();

            //var resultCollection = this.collectionByName.FindAll(product => product.Key == name);
            ICollection<Product> resultCollection = this.collectionByName[name];
            return resultCollection;

            //foreach (var res in resultCollection)
            //{
            //    foreach (var prod in res.Value)
            //    {
            //        result.Add(prod);
            //    }
            //}
            //result.Sort((x, y) => (x.Producer.CompareTo(y.Producer)));
            //return result;
        }

        //public List<Product> FindProductsByProducer(string producer)
        public ICollection<Product> FindProductsByProducer(string producer)
        {
            //List<Product> result = new List<Product>();

            //var resultCollection = this.collectionByProducer.FindAll(product => product.Key == producer);
            ICollection<Product> resultCollection = this.collectionByProducer[producer];
            return resultCollection;

            //foreach (var res in resultCollection)
            //{
            //    foreach (var prod in res.Value)
            //    {
            //        result.Add(prod);
            //    }
            //}

            //result.Sort((x, y) => (x.Name.CompareTo(y.Name)));
            //return result;
            //var products = result.OrderBy(x => x.Name).ThenBy(x => x.Producer).ThenBy(x => x.Price).ToList();
            //return products;
        }

        public ICollection<Product> FindProductsByPriceRange(double from, double to)
        {
            List<Product> result = new List<Product>();

            var resultCollection = this.collectionByPrice.Range(new Product("", "", from), true, new Product("", "", to), true);

            foreach (var item in resultCollection)
            {
                result.Add(item);
            }

            return result;
        }
    }

    class ShoppingCenter
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            int commandsNum = int.Parse(Console.ReadLine());
            int currCommandNum = 0;
            StringBuilder results = new StringBuilder();

            ProductsCollection collection = new ProductsCollection();
            StringBuilder input = new StringBuilder();

            while (currCommandNum < commandsNum)
            {
                string commandInput = Console.ReadLine();
                input.Append(commandInput);
                string[] command = ParseCommand(commandInput);
                string result = ExecuteCommand(command[0], command, collection);

                //results.Append(String.Format("{0}\n", result));
                results.AppendLine(result);
                currCommandNum++;
            }

            Console.WriteLine(results.ToString());
        }

        private static string[] ParseCommand(string commandInput)
        {
            int commandNameIndex = commandInput.IndexOf(' ');

            string commandName = commandInput.Substring(0, commandNameIndex);
            string commandValuesString = commandInput.Substring(commandNameIndex + 1, commandInput.Length - commandNameIndex - 1);
            string[] commandValues = commandValuesString.Split(';');

            string[] command = new string[commandValues.Length + 1];
            command[0] = commandName;

            int cmdIndex = 1;
            foreach (var cmdValue in commandValues)
            {
                command[cmdIndex] = cmdValue.Trim();
                //command[cmdIndex] = cmdValue;
                cmdIndex++;
            }

            return command;
        }

        private static string ExecuteCommand(string commandName, string[] command, ProductsCollection collection)
        {
            string[] cmdValues = new string[command.Length - 1];
            for (int i = 0; i < cmdValues.Length; i++)
            {
                cmdValues[i] = command[i + 1];
            }
            string result = string.Empty;

            switch (commandName)
            {
                case "AddProduct":
                    result = collection.AddProduct(cmdValues);
                    break;
                case "DeleteProducts":
                    int deleted = 0;

                    if (cmdValues.Length == 1)
                    {
                        deleted = collection.DeleteProductByProducer(cmdValues[0]);
                    }
                    else
                    {
                        deleted = collection.DeleteProductByName(cmdValues[0], cmdValues[1]);
                    }

                    if (deleted == 0)
                    {
                        result = "No products found";
                    }
                    else
                    {
                        result = String.Format("{0} products deleted", deleted);
                    }
                    break;
                case "FindProductsByName":
                    ICollection<Product> foundProductsName = collection.FindProductsByName(cmdValues[0]);
                    result = ConvertResultsToString(foundProductsName);
                    break;
                case "FindProductsByProducer":
                    ICollection<Product> foundProductsProducer = collection.FindProductsByProducer(cmdValues[0]);
                    result = ConvertResultsToString(foundProductsProducer);
                    break;
                case "FindProductsByPriceRange":
                    double from = double.Parse(cmdValues[0]);
                    double to = double.Parse(cmdValues[1]);
                    ICollection<Product> foundProductsRange = collection.FindProductsByPriceRange(from, to);
                    result = ConvertResultsToString(foundProductsRange);
                    break;
                default:
                    break;
            }

            return result;
        }

        private static string ConvertResultsToString(ICollection<Product> foundProducts)
        {
            string result = string.Empty;
            StringBuilder productsStr = new StringBuilder();

            //foundProducts.Sort();
            var products = foundProducts.OrderBy(x => x.Name).ThenBy(x => x.Producer).ThenBy(x => x.Price).ToList();

            if (foundProducts.Count > 0)
            {
                //productsStr.Append("{");
                //productsStr.Append(foundProducts[0].ToString());
                //productsStr.Append("}");

                //for (int i = 1; i < foundProducts.Count; i++)
                //{
                //    productsStr.Append("\n{");
                //    productsStr.Append(foundProducts[i].ToString());
                //    productsStr.Append("}");
                //}
                foreach (var item in products)
                {
                    productsStr.AppendLine(item.ToString());
                }

                // this is usually bad hack 
                productsStr.Length -= 2;
            }
            else
            {
                productsStr.Append("No products found");
            }

            result = productsStr.ToString();
            return result;
        }
    }
}