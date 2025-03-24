using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KnapsackProblemApp
{
    public partial class Form1 : Form
    {
        private KnapsackProblem knapsackProblem;

        public Form1()
        {
            InitializeComponent();
            button1.Text = "Rozwi¹¿ Problem";
            button1.Click += button1_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            string errorMessage = "";

            if (!int.TryParse(textBox1.Text, out int itemCount) || itemCount <= 0)
            {
                errorMessage += "Error dla 1\n";
                isValid = false;
            }

            if (!int.TryParse(textBox2.Text, out int seed) || seed < 0)
            {
                errorMessage += "Error dla 2\n";
                isValid = false;
            }

            if (!int.TryParse(textBox3.Text, out int maxCapacity) || maxCapacity <= 0)
            {
                errorMessage += "Error dla 3\n";
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show(errorMessage, "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            listBox2.Items.Add($"£¹czna wartoœæ: {result.BestValue}");
            listBox2.Items.Add($"£¹czna waga: {result.TotalWeight}");
        }


    }
}
