using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RibbonDemo
{
   public partial class HostForm : Form //Qios.DevSuite.Components.Ribbon.QRibbonForm 
   {
      public HostForm()
      {
         InitializeComponent();
         FillGrid();
      }
      private void FillGrid()
      {
         for (int i = 0; i < 10; i++)
         {
            dataGridView1.Rows.Add("Col 1 Row " + i, "Col 2" + "Row " + i);
         }
      }

      private void ribbonCalendar1_DateSelected(object sender, EventArgs e)
      {
         //Console.WriteLine("Date Selected " + ribbonCalendar1.Calendar.SelectionStart.ToShortDateString());
      }

      private void month1_DateSelected(object sender, DateRangeEventArgs e)
      {
         //we must set the text of the host control so it will get copied to the combobox text.
         //This is done automatically by the combo box
         ribbonHost2.Text = month1.SelectionStart.ToShortDateString();
         ribbonHost2.HostCompleted();
      }

      private void ribbonHost3_SizeModeChanging(object sender, RibbonHostSizeModeHandledEventArgs e)
      {
         //This is where you set the size of the control for each sizemode.  This is really important when
         //the control resides directly in a panel.  This is not needed if the control is hosted in a dropdown
         //like the month calendar example.
         switch (e.SizeMode)
         {
            case RibbonElementSizeMode.Large:
               {
                  dataGridView1.Width = 250;
                  break;
               }
            case RibbonElementSizeMode.Medium:
               {
                  dataGridView1.Width = 75;
                  break;
               }
            case RibbonElementSizeMode.Compact:
               {
                  dataGridView1.Visible = false;
                  break;
               }
            default:
               {
                  break;
               }
         }
      }

      private void ribbon1_OrbDoubleClick(object sender, EventArgs e)
      {
         MessageBox.Show("Orb Double CLicked");
      }
   }
}
