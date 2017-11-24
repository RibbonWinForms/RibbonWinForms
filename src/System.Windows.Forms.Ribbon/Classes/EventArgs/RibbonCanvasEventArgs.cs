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
    public class RibbonCanvasEventArgs
        : EventArgs
    {
        #region ctor

        public RibbonCanvasEventArgs(
            Ribbon owner, Graphics g, Rectangle bounds, Control canvas, object relatedObject
            )
        {
            Owner = owner;
            Graphics = g;
            Bounds = bounds;
            Canvas = canvas;
            RelatedObject = relatedObject;
        }

        #endregion

        #region Props

        private object _relatedObject;

        public object RelatedObject
        {
            get { return _relatedObject; }
            set { _relatedObject = value; }
        }


        private Ribbon _owner;

        /// <summary>
        /// Gets or sets the Ribbon that raised the event
        /// </summary>
        public Ribbon Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        private Graphics _Graphics;

        /// <summary>
        /// Gets or sets the graphics to paint
        /// </summary>
        public Graphics Graphics
        {
            get { return _Graphics; }
            set { _Graphics = value; }
        }

        private Rectangle _bounds;

        /// <summary>
        /// Gets or sets the bounds that should be painted
        /// </summary>
        public Rectangle Bounds
        {
            get { return _bounds; }
            set { _bounds = value; }
        }

        private Control _canvas;

        /// <summary>
        /// Gets or sets the control where to be painted
        /// </summary>
        public Control Canvas
        {
            get { return _canvas; }
            set { _canvas = value; }
        }


        #endregion
    }
}
