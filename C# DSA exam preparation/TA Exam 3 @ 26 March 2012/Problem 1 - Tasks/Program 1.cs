﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;


    class Programmm 
    {
        static void Main(string[] args)
        {
            IDictionary<int, OrderedBag<string>> dict = new SortedDictionary<int, OrderedBag<string>>();

            StringBuilder sb = new StringBuilder();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string inputCmd = Console.ReadLine();
                if (inputCmd.StartsWith("N"))
                {
                    string[] input = inputCmd.Split(new char[]{' '}, 3);
                    string cmd = input[0].Trim();
                    int complexity = int.Parse(input[1].Trim());
                    string name = input[2].Trim();

                    if (!dict.ContainsKey(complexity))
                    {
                        dict.Add(complexity, new OrderedBag<string>());
                    }

                    dict[complexity].Add(name);
                }
                else
                {
                    if (dict.Count == 0)
                    {
                        sb.AppendLine("Rest");
                    }
                    else
                    {
                        //int key = dict.Keys.First(); //90
                        //int key = dict.First().Key; // 80
                        //int key = dict.Keys.First(); // 90

                        int key = 0;
                        foreach (var item in dict.Keys)
                        {
                            key = item;
                            break;
                        }

                        OrderedBag<string> list = dict[key];
                        sb.AppendLine(list.GetFirst());

                        if (list.Count <= 1)
                        {
                            dict.Remove(key);
                        }
                        else
                        {
                            list.RemoveFirst();
                        }
                    }
                }
            }

            Console.Write(sb.ToString());
        }
    }
