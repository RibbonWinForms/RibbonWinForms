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
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace System.Windows.Forms
{
    /// <summary>
    /// A RibbonButton that incorporates a <see cref="Color"/> property and
    /// draws this color below the displaying <see cref="Image"/> or <see cref="SmallImage"/>
    /// </summary>
    public class RibbonColorChooser
        : RibbonButton
    {
        #region Fields

        private Color _color;
        private int _imageColorHeight;
        private int _smallImageColorHeight;

        #endregion

        #region Events

        /// <summary>
        /// Raised when the <see cref="Color"/> property has been changed
        /// </summary>
        public event EventHandler ColorChanged;

        #endregion

        #region Ctor

        public RibbonColorChooser()
        {
            _color = Color.Transparent;
            _imageColorHeight = 8;
            _smallImageColorHeight = 4;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the height of the color preview on the <see cref="Image"/>
        /// </summary>
        [Description("Height of the color preview on the large image")]
        [Category("Appearance")]
        [DefaultValue(8)]
        public int ImageColorHeight
        {
            get { return _imageColorHeight; }
            set { _imageColorHeight = value; }
        }

        /// <summary>
        /// Gets or sets the height of the color preview on the <see cref="SmallImage"/>
        /// </summary>
        [Description("Height of the color preview on the small image")]
        [Category("Appearance")]
        [DefaultValue(4)]
        public int SmallImageColorHeight
        {
            get { return _smallImageColorHeight; }
            set { _smallImageColorHeight = value; }
        }


        /// <summary>
        /// Gets or sets the currently chosen color
        /// </summary>
        [Category("Appearance")]
        public Color Color
        {
            get { return _color; }
            set { _color = value; RedrawItem(); OnColorChanged(EventArgs.Empty); }
        }

        #endregion

        #region Methods

        private Image CreateColorBmp(Color c)
        {
            Bitmap b = new Bitmap(16, 16);

            using (Graphics g = Graphics.FromImage(b))
            {
                using (SolidBrush br = new SolidBrush(c))
                {
                    g.FillRectangle(br, new Rectangle(0, 0, 15, 15));
                }

                g.DrawRectangle(Pens.DimGray, new Rectangle(0, 0, 15, 15));
            }

            return b;
        }

        /// <summary>
        /// Raises the <see cref="ColorChanged"/>
        /// </summary>
        /// <param name="e"></param>
        protected void OnColorChanged(EventArgs e)
        {
            if (ColorChanged != null)
            {
                ColorChanged(this, e);
            }
        }

        #endregion

        #region Overrides

        public override void OnPaint(object sender, RibbonElementPaintEventArgs e)
        {
            base.OnPaint(sender, e);

            Color c = this.Color.Equals(Color.Transparent) ? Color.White : Color;

            int h = e.Mode == RibbonElementSizeMode.Large ? ImageColorHeight : SmallImageColorHeight;

            Rectangle colorFill = Rectangle.FromLTRB(
                    ImageBounds.Left,
                    ImageBounds.Bottom - h,
                    ImageBounds.Right, 
                    ImageBounds.Bottom
                    );
            SmoothingMode sm = e.Graphics.SmoothingMode;
            e.Graphics.SmoothingMode = SmoothingMode.None;
            using (SolidBrush b = new SolidBrush(c))
            {

                e.Graphics.FillRectangle(b, colorFill);
            }

            if (this.Color.Equals(Color.Transparent))
            {
                e.Graphics.DrawRectangle(Pens.DimGray, colorFill);
            }

            e.Graphics.SmoothingMode = sm;
        }

        #endregion
    }
}
