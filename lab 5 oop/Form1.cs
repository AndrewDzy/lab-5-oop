using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_5_oop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ProcessButton_Click(object sender, EventArgs e)
        {
            string inputText = InputTextBox.Text;

            if (string.IsNullOrWhiteSpace(inputText))
            {
                MessageBox.Show("Введіть текст!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] words = inputText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var wordCounts = words.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            string wordToRemove = "Завдання";
            string resultText = inputText.Replace(wordToRemove, "");
            ResultsLabel.Text = "Кількість однакових слів:";
            foreach (var kvp in wordCounts)
            {
                ResultsLabel.Text += $"\nСлово '{kvp.Key}' зустрічається {kvp.Value} раз(и)";
            }
            ResultsLabel.Text += $"\n\nРядок після видалення слова '{wordToRemove}':\n{resultText}";
        }

        private void InputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Дозволені тільки букви та пробіл!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
