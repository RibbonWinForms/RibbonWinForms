// *********************************
// Message from Original Author:
//
// 2008 Jose Menendez Poo
// Please give me credit if you use this code. It's all I ask.
// Contact me for more info: menendezpoo@gmail.com
// *********************************
//
// Original project from http://ribbon.codeplex.com/
// Continue to support and maintain by http://officeribbon.codeplex.com/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms.RibbonHelpers;
using System.Windows.Forms;

namespace System.Windows.Forms
{
    public class RibbonForm
        : Form, IRibbonForm
    {

        #region Fields

        private RibbonFormHelper _helper;

        #endregion

        #region Ctor

        public RibbonForm()
        {
           if (WinApi.IsWindows && !WinApi.IsGlassEnabled)
           {
              FormBorderStyle = FormBorderStyle.None;
              SetStyle(ControlStyles.ResizeRedraw, true);
              SetStyle(ControlStyles.Opaque, WinApi.IsGlassEnabled);
              SetStyle(ControlStyles.AllPaintingInWmPaint, true);
              DoubleBuffered = true;
           }
           _helper = new RibbonFormHelper(this);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Just for debugging messages
        /// </summary>
        /// <param name="m"></param>
        protected override void OnNotifyMessage(Message m)
        {
            base.OnNotifyMessage(m);
        }

        /// <summary>
        /// Overrides the WndProc funciton
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
           if (!Helper.WndProc(ref m))
            {
                base.WndProc(ref m);
            }
        }

        protected override CreateParams CreateParams
        {
           get
           {
              CreateParams cp = base.CreateParams;
              if (WinApi.IsWindows && !WinApi.IsGlassEnabled)
              {
                 cp.Style |= 0x20000 | 0x80000 | 0x40000; //WS_MINIMIZEBOX | WS_SYSMENU | WS_SIZEBOX;
                 //cp.ClassStyle |= 0x8 | 0x20000; //CS_DBLCLKS | CS_DROPSHADOW;
              }
              return cp;
           }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
           // override OnPaint and do NOT call base, otherwise problems as MDI parent occur
           _helper.Form_Paint(this, e);
        }

        #endregion

        #region IRibbonForm Members

        /// <summary>
        /// Gets the helper for making the form a ribbon form
        /// </summary>
        public RibbonFormHelper Helper
        {
            get { return _helper; }
        }

        #endregion
    }
}
