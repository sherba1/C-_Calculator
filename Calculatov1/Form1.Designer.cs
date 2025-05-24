using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Calculatov1
{
    partial class Form1
    {
        private IContainer components;
        private Label lblAnswer;
        private TextBox txtDisplay;
        private Button btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9;
        private Button btnDecimal, btnDivide, btnMultiply, btnSubtract, btnAdd, btnEquals, btnClear;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();

            lblAnswer = new Label()
            {
                Name = "lblAnswer",
                Text = "Answer",
                Location = new Point(20, 20),
                AutoSize = true
            };

            txtDisplay = new TextBox()
            {
                Name = "txtDisplay",
                ReadOnly = true,
                Text = "0",
                TextAlign = HorizontalAlignment.Right,
                Location = new Point(20, 50),
                Size = new Size(260, 24)
            };

            // Buttons
            int x = 20, y = 100, s = 60, p = 10;
            btn7 = CreateButton("btn7", "7", x, y, s);
            btn8 = CreateButton("btn8", "8", x + s + p, y, s);
            btn9 = CreateButton("btn9", "9", x + 2 * (s + p), y, s);
            btnDivide = CreateButton("btnDivide", "/", x + 3 * (s + p), y, s);

            y += s + p;
            btn4 = CreateButton("btn4", "4", x, y, s);
            btn5 = CreateButton("btn5", "5", x + s + p, y, s);
            btn6 = CreateButton("btn6", "6", x + 2 * (s + p), y, s);
            btnMultiply = CreateButton("btnMultiply", "*", x + 3 * (s + p), y, s);

            y += s + p;
            btn1 = CreateButton("btn1", "1", x, y, s);
            btn2 = CreateButton("btn2", "2", x + s + p, y, s);
            btn3 = CreateButton("btn3", "3", x + 2 * (s + p), y, s);
            btnSubtract = CreateButton("btnSubtract", "-", x + 3 * (s + p), y, s);

            y += s + p;
            btnClear = CreateButton("btnClear", "C", x, y, s);
            btn0 = CreateButton("btn0", "0", x + s + p, y, s);
            btnDecimal = CreateButton("btnDecimal", ".", x + 2 * (s + p), y, s);
            btnAdd = CreateButton("btnAdd", "+", x + 3 * (s + p), y, s);

            y += s + p;
            btnEquals = CreateButton("btnEquals", "=", x + 3 * (s + p), y, s);


            Controls.AddRange(new Control[]
            {
                lblAnswer, txtDisplay,
                btn7, btn8, btn9, btnDivide,
                btn4, btn5, btn6, btnMultiply,
                btn1, btn2, btn3, btnSubtract,
                btnClear, btn0, btnDecimal, btnAdd,
                btnEquals
            });

            ClientSize = new Size(350, y + s + p);
            Text = "Simple Calculator";
        }

        private Button CreateButton(string name, string text, int x, int y, int size)
        {
            var btn = new Button()
            {
                Name = name,
                Text = text,
                Location = new Point(x, y),
                Size = new Size(size, size)
            };
            if (text == "+" || text == "-" || text == "*" || text == "/")
                btn.Click += Operator_Click;
            else if (text == "=")
                btn.Click += btnEquals_Click;
            else if (text == "C")
                btn.Click += btnClear_Click;
            else
                btn.Click += Number_Click;
            return btn;
        }
    }
}