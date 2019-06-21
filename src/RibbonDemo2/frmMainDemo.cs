using System;
using System.Windows.Forms;
using RibbonDemo2.Properties;

namespace RibbonDemo2
{
    public partial class frmMainDemo : RibbonForm
    {
        public frmMainDemo()
        {
            InitializeComponent();

            foreach (object value in Enum.GetValues(typeof(RibbonOrbStyle)))
            {
                RibbonButton rb = new RibbonButton
                {
                    Style = RibbonButtonStyle.Normal,
                    MinSizeMode = RibbonElementSizeMode.Large,
                    Text = value + "",
                    LargeImage = Resources.newdocument32
                };
                rb.Click += rbOrbStyle_Click;
                ribbonPanel_OrbStyle.Items.Add(rb);
            }

            foreach (object value in Enum.GetValues(typeof(RibbonTheme)))
            {
                RibbonButton rb = new RibbonButton
                {
                    Style = RibbonButtonStyle.Normal,
                    MinSizeMode = RibbonElementSizeMode.Large,
                    Text = value + "",
                    LargeImage = Resources.addons32
                };
                rb.Click += rbTheme_Click;
                ribbonPanel_Theme.Items.Add(rb);
            }
        }
        private void Ribbon1_OrbStyleChanged(object sender, EventArgs e)
        {

        }

        private void frmMainDemo_Load(object sender, EventArgs e)
        {
            btForm1_Click(null, null);
        }

        private void rbTheme_Click(object sender, EventArgs e)
        {
            ribbon1.ThemeColor = (RibbonTheme)Enum.Parse(typeof(RibbonTheme), ((RibbonButton)sender).Text);
            ribbon1.Refresh();
            Refresh();
        }

        private void rbOrbStyle_Click(object sender, EventArgs e)
        {
            var style = (RibbonOrbStyle)Enum.Parse(typeof(RibbonOrbStyle), ((RibbonButton)sender).Text);
            if (style == RibbonOrbStyle.Office_2007)
            {
                ribbon1.ContextSpace = 23;
            }
            else if (style == RibbonOrbStyle.Office_2010_Extended)
            {
                ribbon1.ContextSpace = 10;
            }
            else
            {
                ribbon1.ContextSpace = 18;
            }
            ribbon1.OrbStyle = style;
            ribbon1.Refresh();
            Refresh();
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

        private void OpenForm(Type t)
        {
            foreach(var c in panel1.Controls)
            {
                if (c is Form form)
                {
                    form.Close();
                    form.Dispose();
                }
            }

            Form f = (Form)Activator.CreateInstance(t);
            f.FormBorderStyle = FormBorderStyle.None;
            f.TopLevel = false;
            f.Parent = panel1;
            f.WindowState = FormWindowState.Maximized;
            f.Show();

            GC.Collect();
        }
    }
}