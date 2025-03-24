using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KnapsackProblem kp = new KnapsackProblem();
            kp.PrintArrays();

            Result result = kp.Solve(kp.MaxCapacity);
            Console.WriteLine(result);
        }
    }


    public class KnapsackProblem
    {
        public int[] Weights { get; set; }
        public int[] Values { get; set; }
        public int MaxCapacity { get; set; }
        public int ItemCount { get; set; }

        public KnapsackProblem()
        {
            Console.WriteLine("Enter number of items:");
            int nItems = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the seed:");
            int seed = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the maxCapacity:");
            MaxCapacity = int.Parse(Console.ReadLine());

            Initialize(nItems, seed);
        }

        public KnapsackProblem(int itemCount, int seed, int maxCapacity)
        {
            MaxCapacity = maxCapacity;
            Initialize(itemCount, seed);
        }

        private void Initialize(int itemCount, int seed)
        {
            Random rand = new Random(seed);
            ItemCount = itemCount;
            Weights = new int[itemCount];
            Values = new int[itemCount];

            for (int i = 0; i < itemCount; i++)
            {
                Weights[i] = rand.Next(1, 11);
                Values[i] = rand.Next(1, 11);
            }
        }

        public void PrintArrays()
        {
            Console.WriteLine("Weights: " + string.Join(", ", Weights));
            Console.WriteLine("Values: " + string.Join(", ", Values));
        }

        public Result Solve(int capacity)
        {
            List<Item> items = new List<Item>();
            for (int i = 0; i < ItemCount; i++)
            {
                items.Add(new Item(i, Values[i], Weights[i]));
            }

            items = items.OrderByDescending(item => item.Ratio).ToList();

            List<int> chosenItems = new List<int>();
            int totalValue = 0;
            int totalWeight = 0;

            foreach (var item in items)
            {
                if (totalWeight + item.Weight <= capacity)
                {
                    chosenItems.Add(item.Index);
                    totalWeight += item.Weight;
                    totalValue += item.Value;
                }
            }

            return new Result(chosenItems, totalValue, totalWeight);
        }
    }

    public class Item
    {
        public int Index { get; }
        public int Value { get; }
        public int Weight { get; }
        public double Ratio => (double)Value / Weight;

        public Item(int index, int value, int weight)
        {
            Index = index;
            Value = value;
            Weight = weight;
        }
    }

    public class Result
    {
        public List<int> ChosenItems { get; }
        public int BestValue { get; }
        public int TotalWeight { get; }

        public Result(List<int> chosenItems, int bestValue, int totalWeight)
        {
            ChosenItems = chosenItems;
            BestValue = bestValue;
            TotalWeight = totalWeight;
        }

        public override string ToString()
        {
            return $"Selected items: {string.Join(", ", ChosenItems)}\n" +
                   $"Knapsack value: {BestValue}\n" +
                   $"Knapsack total weight: {TotalWeight}";
        }
    }
}
