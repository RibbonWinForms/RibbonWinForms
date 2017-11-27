using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RibbonDemo2
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();

            Theme.StandardThemeIsGlobal = false;

            foreach (object value in Enum.GetValues(typeof(RibbonOrbStyle)))
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

        private void ApplySelectedTheme(Control c)
        {
            if (c == null)
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

        private void btMainDemo_Click(object sender, EventArgs e)
        {
            frmMainDemo f = new frmMainDemo();
            ApplySelectedTheme(f);
            f.ShowDialog();
        }
    }
}
