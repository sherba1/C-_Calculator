using System;
using System.Linq;
using System.Windows.Forms;

namespace Calculatov1
{
    public partial class Form1 : Form
    {
        private string currentInput = "";
        private double storedValue;
        private char currentOperator;

        public Form1()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, EventArgs e)
        {
            var b = (Button)sender;
            if (b.Text == "." && currentInput.Contains('.')) return;
            if (currentInput == "0" && b.Text != ".") currentInput = b.Text;
            else currentInput += b.Text;
            txtDisplay.Text = currentInput;
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            var b = (Button)sender;
            if (double.TryParse(currentInput, out double val))
            {
                storedValue = val;
                currentOperator = b.Text[0];
                currentInput = string.Empty;
                txtDisplay.Text = storedValue + " " + currentOperator;
            }
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(currentInput, out double second)) return;
            double result = 0;
            switch (currentOperator)
            {
                case '+': result = storedValue + second; break;
                case '-': result = storedValue - second; break;
                case '*': result = storedValue * second; break;
                case '/': result = second != 0 ? storedValue / second : double.NaN; break;
            }
            currentInput = result.ToString();
            txtDisplay.Text = currentInput;
            storedValue = result;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            currentInput = string.Empty;
            storedValue = 0;
            currentOperator = '\0';
            txtDisplay.Text = "0";
        }
    }
}
