using System;
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
         ControlBox = false;
         WindowState = FormWindowState.Maximized;
         BringToFront();
      }
   }
}
