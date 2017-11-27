using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
                Button button1 = new Button();

                button1.Name = s;
                button1.Text = s;

                button1.BackColor = System.Drawing.Color.Black;
                button1.FlatAppearance.BorderSize = 0;
                button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
                button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                button1.Margin = new System.Windows.Forms.Padding(0);
                button1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
                button1.Size = new System.Drawing.Size(160, 40);
                button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                button1.UseVisualStyleBackColor = false;

                flowLayoutPanel1.Controls.Add(button1);
            }
        }
    }
}
