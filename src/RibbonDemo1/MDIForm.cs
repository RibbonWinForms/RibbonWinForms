using System;
using System.Windows.Forms;

namespace RibbonDemo
{
    public partial class MDIForm : RibbonForm
    {
        public MDIForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            //if (this.ActiveMdiChild != null)
            while (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
        }

        private void ribbonButton2_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                if (f.GetType() == typeof(MDIChild1))
                {
                    f.Activate();
                    return;
                }
            }
            Form form = new MDIChild1
            {
                MdiParent = this
            };
            form.Show();
        }

        private void ribbonButton3_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                if (f.GetType() == typeof(MDIChild2))
                {
                    f.Activate();
                    return;
                }
            }
            Form form = new MDIChild2
            {
                MdiParent = this
            };
            form.Show();
        }
    }
}