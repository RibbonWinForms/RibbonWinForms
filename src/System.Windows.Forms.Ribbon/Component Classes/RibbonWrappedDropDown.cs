using System;
using System.Collections.Generic;
using System.Text;

namespace System.Windows.Forms
{
    internal class RibbonWrappedDropDown
        : ToolStripDropDown
    {
        public RibbonWrappedDropDown()
            : base()
        {
            DoubleBuffered = false;
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.Selectable, false);
            SetStyle(ControlStyles.ResizeRedraw, false);
            AutoSize = false;
        }
    }
}
