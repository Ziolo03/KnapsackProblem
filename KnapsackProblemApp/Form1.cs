using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KnapsackProblemApp
{
    public partial class Form1 : Form
    {
        private KnapsackProblem knapsackProblem;

        public Form1()
        {
            InitializeComponent();
            button1.Text = "Rozwiπø Problem";
            button1.Click += button1_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int itemCount) ||
                !int.TryParse(textBox2.Text, out int seed) ||
                !int.TryParse(textBox3.Text, out int maxCapacity))
            {
                MessageBox.Show("Wprowadü poprawne liczby!", "B≥πd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            knapsackProblem = new KnapsackProblem(itemCount, seed, maxCapacity);

            listBox1.Items.Clear();
            for (int i = 0; i < knapsackProblem.ItemCount; i++)
            {
                listBox1.Items.Add($"Item {i}: Value={knapsackProblem.Values[i]}, Weight={knapsackProblem.Weights[i]}");
            }

            Result result = knapsackProblem.Solve(maxCapacity);

            listBox2.Items.Clear();
            listBox2.Items.Add($"Wybrane przedmioty: {string.Join(", ", result.ChosenItems)}");
            listBox2.Items.Add($"£πczna wartoúÊ: {result.BestValue}");
            listBox2.Items.Add($"£πczna waga: {result.TotalWeight}");
        }
    }
}
