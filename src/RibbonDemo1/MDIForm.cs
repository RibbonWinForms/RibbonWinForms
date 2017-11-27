using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

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
            while (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
        }

        private void ribbonButton2_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(MDIChild1))
                {
                    f.Activate();
                    return;
                }
            }
            Form form = new MDIChild1();
            form.MdiParent = this;
            form.Show();
        }

        private void ribbonButton3_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(MDIChild2))
                {
                    f.Activate();
                    return;
                }
            }
            Form form = new MDIChild2();
            form.MdiParent = this;
            form.Show();
        }
    }
}