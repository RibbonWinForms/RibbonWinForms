/*
 
 2011 Thomas Koglbauer
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace System.Windows.Forms
{
    public class RibbonDropDownRenderEventArgs
        : EventArgs
    {
        #region ctor

        public RibbonDropDownRenderEventArgs(
            Graphics g, RibbonDropDown dropDown
            )
        {
            Graphics = g;
            DropDown = dropDown;
        }

        #endregion

        #region Props

        private Graphics _Graphics;

        /// <summary>
        /// Gets or sets the graphics to paint
        /// </summary>
        public Graphics Graphics
        {
            get { return _Graphics; }
            set { _Graphics = value; }
        }

        private RibbonDropDown _dropDown;

        /// <summary>
        /// Gets or sets the Ribbon DropDown
        /// </summary>
        public RibbonDropDown DropDown
        {
            get { return _dropDown; }
            set { _dropDown = value; }
        }

        #endregion
    }
}
