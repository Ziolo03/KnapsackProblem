namespace UnitTests
{
    using NUnit.Framework;
    using ConsoleApp1;
    using System.Collections.Generic;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void KnapsackSolver_PoprawneRozwiazanieDlaInstancji()
        {
            KnapsackProblem problem = new KnapsackProblem(5, 42, 15);
            Result result = problem.Solve(problem.MaxCapacity);

            Assert.IsTrue(result.BestValue == 21);
        }
        [Test]
        public void KnapsackProblem_DlaBrakuPasujacych()
        {
            int itemCount = 5;
            int seed = 42;
            int maxCapacity = 1;

            KnapsackProblem problem = new KnapsackProblem(itemCount, seed, maxCapacity);
            for (int i = 0; i < problem.ItemCount; i++)
            {
                problem.Weights[i] = maxCapacity + 1;
            }
            Result result = problem.Solve(maxCapacity);

            Assert.IsEmpty(result.ChosenItems);
        }

        [Test]
        public void KnapsackProblem_DlaJednegoPasujacego()
        {
            int itemCount = 1;
            int seed = 1;
            int maxCapacity = 3;

            KnapsackProblem problem = new KnapsackProblem(itemCount, seed, maxCapacity);
            Result result = problem.Solve(maxCapacity);

            Assert.IsTrue(result.TotalWeight == problem.Weights[0]);
        }

        [Test]
        public void KnapsackProblem_WszystkiePrzedmiotyMieszczaSie()
        {
            int itemCount = 4;
            int seed = 10;
            int maxCapacity = 100;

            KnapsackProblem problem = new KnapsackProblem(itemCount, seed, maxCapacity);

            problem.Weights = new int[] { 10, 20, 30, 40 };
            problem.Values = new int[] { 60, 100, 120, 140 };

            Result result = problem.Solve(maxCapacity);

            Assert.AreEqual(itemCount, result.ChosenItems.Count);
        }

        [Test]
        public void KnapsackProblem_PoprawneLosowanie()
        {
            List<int> sizes = new List<int>() { 10, 20, 30, 40, 50 };
            foreach (int n in sizes)
            {
                KnapsackProblem problem = new KnapsackProblem(n, 42, 50);
                Assert.AreEqual(n, problem.Values.Length);
            }
            Assert.Pass();
        }
    }

}
