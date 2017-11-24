using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RibbonDemo
{
    public partial class FormClassResult : Form
    {
        public FormClassResult(string text)
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.textBox1.Text = text;
        }

        private void FormClassResult_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.A))
            {
                ((TextBox)sender).SelectAll();

                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
    }
}
