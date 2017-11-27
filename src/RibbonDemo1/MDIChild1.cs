using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace RibbonDemo
{
   public partial class MDIChild1 : Form
   {
      public MDIChild1()
      {
         InitializeComponent();
      }

      protected override void OnLoad(EventArgs e)
      {
         base.OnLoad(e);
         this.ControlBox = false;
         this.WindowState = FormWindowState.Maximized;
         this.BringToFront();
      }
   }
}
