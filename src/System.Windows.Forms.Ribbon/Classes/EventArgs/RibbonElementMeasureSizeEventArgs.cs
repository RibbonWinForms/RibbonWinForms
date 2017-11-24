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
using System.Drawing;

namespace System.Windows.Forms
{
    /// <summary>
    /// Holds data and tools to measure the size
    /// </summary>
    public class RibbonElementMeasureSizeEventArgs
        : EventArgs
    {
        private RibbonElementSizeMode _sizeMode;
        private System.Drawing.Graphics _graphics;

        /// <summary>
        /// Creates a new RibbonElementMeasureSizeEventArgs object
        /// </summary>
        /// <param name="graphics">Device info to draw and measure</param>
        /// <param name="sizeMode">Size mode to measure</param>
        internal RibbonElementMeasureSizeEventArgs(System.Drawing.Graphics graphics, RibbonElementSizeMode sizeMode)
        {
            _graphics = graphics;
            _sizeMode = sizeMode;
        }

        /// <summary>
        /// Gets the size mode to measure
        /// </summary>
        public RibbonElementSizeMode SizeMode
        {
            get
            {
                return _sizeMode;
            }
        }

        /// <summary>
        /// Gets the device to measure objects
        /// </summary>
        public Graphics Graphics
        {
            get
            {
                return _graphics;
            }
        }
    }
}
