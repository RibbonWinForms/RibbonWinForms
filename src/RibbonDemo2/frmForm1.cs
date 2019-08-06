using System.Drawing;
using System.Windows.Forms;

namespace RibbonDemo2
{
    public partial class frmForm1 : Form
    {
        public frmForm1()
        {
            InitializeComponent();

            string b = "Save|Open|New|Close|Print|Print Preview|Template";
            string[] sa = b.Split('|');

            foreach(string s in sa)
            {
                Button button1 = new Button
                {
                    Name = s,
                    Text = s,

                    BackColor = Color.Black
                };
                button1.FlatAppearance.BorderSize = 0;
                button1.FlatAppearance.MouseDownBackColor = Color.Gray;
                button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
                button1.FlatStyle = FlatStyle.Flat;
                button1.ForeColor = Color.FromArgb(224, 224, 224);
                button1.Margin = new Padding(0);
                button1.Padding = new Padding(10, 0, 0, 0);
                button1.Size = new Size(160, 40);
                button1.TextAlign = ContentAlignment.MiddleLeft;
                button1.UseVisualStyleBackColor = false;

                flowLayoutPanel1.Controls.Add(button1);
            }
        }
    }
}