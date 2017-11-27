using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace RibbonDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {           
           InitializeComponent();
           Theme.StandardThemeIsGlobal = false;

           foreach(object value in Enum.GetValues(typeof(RibbonOrbStyle)))
           {
              cmbOrbStyle.Items.Add(value);
           }
           cmbOrbStyle.SelectedIndex = cmbOrbStyle.Items.Count - 1;

           foreach (object value in Enum.GetValues(typeof(RibbonTheme)))
           {
              cmbColor.Items.Add(value);
           }
           cmbColor.SelectedIndex = cmbOrbStyle.Items.Count - 1;
        }

        private void btBlackForm_Click(object sender, EventArgs e)
        {
            BlackForm f = new BlackForm();
            f.Show();
        }

        private void btHostForm_Click(object sender, EventArgs e)
        {
            HostForm f = new HostForm();
            ApplySelectedTheme(f);
            f.Show();
        }

        private void btTestForm_Click(object sender, EventArgs e)
        {
            TestForm f = new TestForm();
            ApplySelectedTheme(f);
            f.Show();
        }

        private void btMainForm_Click(object sender, EventArgs e)
        {
            MainForm f = new MainForm();
            ApplySelectedTheme(f);
            f.Show();
        }

        private void btnMDIForm_Click(object sender, EventArgs e)
        {
           Form f = new MDIForm();
           ApplySelectedTheme(f);
           f.Show();
        }

        private void btRightToLeft_Click(object sender, EventArgs e)
        {
            RightToLeftForm f = new RightToLeftForm();
            ApplySelectedTheme(f);
            f.Show();
        }

        private void btThemeBuilderForm_Click(object sender, EventArgs e)
        {
            ThemeBuilderForm f = new ThemeBuilderForm();
            f.Show();
        }

        private void ApplySelectedTheme(Control c)
        {
           if(c == null)
              return;
           Ribbon ribbon = null;
           foreach (Control child in c.Controls)
           {
              ribbon = child as Ribbon;
              if (ribbon != null)
                 break;
           }
           if (ribbon == null)
              return;
           try
           {
              ribbon.OrbStyle = (RibbonOrbStyle)Enum.Parse(typeof(RibbonOrbStyle), cmbOrbStyle.Text);
           }
           catch { /* don't care */ }
           try
           {
              ribbon.ThemeColor = (RibbonTheme)Enum.Parse(typeof(RibbonTheme), cmbColor.Text);
           }
           catch { /* don't care */ }
        }
    }
}
