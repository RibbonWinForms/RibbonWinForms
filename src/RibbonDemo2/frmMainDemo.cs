using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RibbonDemo2
{
    public partial class frmMainDemo : Form
    {
        public frmMainDemo()
        {
            InitializeComponent();

            foreach (object value in Enum.GetValues(typeof(RibbonOrbStyle)))
            {
                RibbonButton rb = new RibbonButton();
                rb.Style = RibbonButtonStyle.Normal;
                rb.MinSizeMode = RibbonElementSizeMode.Large;
                rb.Text = value + "";
                rb.LargeImage = global::RibbonDemo2.Properties.Resources.newdocument32;
                rb.Click += rbOrbStyle_Click;
                ribbonPanel_OrbStyle.Items.Add(rb);
            }

            foreach (object value in Enum.GetValues(typeof(RibbonTheme)))
            {
                RibbonButton rb = new RibbonButton();
                rb.Style = RibbonButtonStyle.Normal;
                rb.MinSizeMode = RibbonElementSizeMode.Large;
                rb.Text = value + "";
                rb.LargeImage = global::RibbonDemo2.Properties.Resources.addons32;
                rb.Click += rbTheme_Click;
                ribbonPanel_Theme.Items.Add(rb);
            }
        }

        private void frmMainDemo_Load(object sender, EventArgs e)
        {
            btForm1_Click(null, null);
        }

        private void rbTheme_Click(object sender, EventArgs e)
        {
            this.ribbon1.ThemeColor = (RibbonTheme)Enum.Parse(typeof(RibbonTheme), ((RibbonButton)sender).Text);
            this.ribbon1.Refresh();
            this.Refresh();
        }

        private void rbOrbStyle_Click(object sender, EventArgs e)
        {
            this.ribbon1.OrbStyle = (RibbonOrbStyle)Enum.Parse(typeof(RibbonOrbStyle), ((RibbonButton)sender).Text);
            this.ribbon1.Refresh();
            this.Refresh();
        }

        private void btForm1_Click(object sender, EventArgs e)
        {
            OpenForm(typeof(frmForm1));
        }

        private void btForm2_Click(object sender, EventArgs e)
        {
            OpenForm(typeof(frmForm2));
        }

        private void btForm3_Click(object sender, EventArgs e)
        {
            OpenForm(typeof(frmForm3));
        }

        void OpenForm(Type t)
        {
            foreach(var c in panel1.Controls)
            {
                if (c is Form)
                {
                    ((Form)c).Close();
                    ((Form)c).Dispose();
                }
            }

            Form f = (Form)Activator.CreateInstance(t);
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            f.TopLevel = false;
            f.Parent = panel1;
            f.WindowState = FormWindowState.Maximized;
            f.Show();

            GC.Collect();
        }

    }
}
