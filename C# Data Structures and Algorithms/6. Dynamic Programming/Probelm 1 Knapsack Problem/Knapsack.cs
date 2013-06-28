using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probelm_1_Knapsack_Problem
{
    class Knapsack
    {
        static void Main(string[] args)
        {
            const int KnapsackWeight = 10;
            //const int KnapsackWeight = 5;

            Item[] itemCatalog = {
                null,
                new Item(3, 2, "beer"),
                new Item(8, 12, "vodka"),
                new Item(4, 5, "cheese"),
                new Item(1, 4, "nuts"),
                new Item(2, 3, "ham"),
                new Item(8, 13, "whiskey")
                //new Item(3, 5, "first"),
                //new Item(2, 3, "second"),
                //new Item(1, 4, "third"),
            };

            int itemsCount = itemCatalog.Length;

            int[,] benefit = new int[itemsCount, KnapsackWeight + 1];
            bool[,] keep = new bool[itemsCount, KnapsackWeight + 1];

            for (int item = 1; item < itemsCount; item++)
            {
                for (int weight = 1; weight <= KnapsackWeight; weight++)
                {
                    GetBenefit(item, weight, benefit, keep, itemCatalog);
                }
            }

            int w = KnapsackWeight;
            int i = itemCatalog.Length - 1;

            while (w > 0 && i > 0)
            {
                if (keep[i, w])
                {
                    Console.WriteLine(itemCatalog[i]);
                    w -= itemCatalog[i].Weight;
                    i--;
                }
                else
                {
                    i--;
                }
            }
        }

        private static void GetBenefit(int item, int weight, int[,] benefit, bool[,] keep, Item[] itemCatalog)
        {
            int previousItemCost = benefit[item - 1, weight];

            if (itemCatalog[item].Weight <= weight)
            {
                int currentItemCost = itemCatalog[item].Cost;
                int avaliableWeight = weight - itemCatalog[item].Weight;
                int previousItemCostWeight = benefit[item - 1, avaliableWeight];

                currentItemCost += previousItemCostWeight;
                if (currentItemCost > previousItemCost)
                {
                    benefit[item, weight] = currentItemCost;
                    keep[item, weight] = true;
                }
                else
                {
                    benefit[item, weight] = previousItemCost;
                }
            }
            else
            {
                benefit[item, weight] = previousItemCost;
            }
        }
    }

    class Item
    {
        public Item(int weight, int cost, string name)
        {
            this.Weight = weight;
            this.Cost = cost;
            this.Name = name;
        }

        public int Weight { get; set; }
        public int Cost { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return String.Format("{0} cost {1} and weight {2}", this.Name, this.Cost, this.Weight);
        } 

    }
}
