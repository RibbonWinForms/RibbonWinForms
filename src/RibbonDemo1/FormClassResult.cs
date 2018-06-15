using System;
using System.Windows.Forms;

namespace RibbonDemo
{
    public partial class FormClassResult : Form
    {
        public FormClassResult(string text)
        {
            InitializeComponent();
            Height = Screen.PrimaryScreen.WorkingArea.Height;
            StartPosition = FormStartPosition.CenterScreen;
            textBox1.Text = text;
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
