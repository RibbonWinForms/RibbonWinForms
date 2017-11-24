using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RibbonDemo
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         //Application.Run(new BlackForm());
         //Application.Run(new MainForm());
         //Application.Run(new TestForm());
         //Application.Run(new HostForm());

         //Kevin Carbis - this form is excluded from the project so it will compile but is included in the sample code
         //Simply add this form to the project once you have downloaded the Qios controls and add a reference to it
         //Application.Run(new QiosCaptionTest());

         Application.Run(new Form1());
      }
   }
}