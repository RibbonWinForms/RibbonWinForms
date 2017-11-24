using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace System.Windows.Forms
{
    public class RibbonTextEventArgs
        : RibbonItemBoundsEventArgs
    {
        #region Fields
        private string _text;
        private StringFormat _format;
        private FontStyle _style;
        private Color _color;
        #endregion

        #region Ctor



        public RibbonTextEventArgs(Ribbon owner, Graphics g, Rectangle clip, RibbonItem item, Rectangle bounds, string text)
            : base(owner, g, clip, item, bounds)
        {
            Text = text;
            Style =  FontStyle.Regular;
            Format = new StringFormat();
            Color = Color.Empty;
        }

        public RibbonTextEventArgs(Ribbon owner, Graphics g, Rectangle clip, RibbonItem item, Rectangle bounds, string text, FontStyle style)
            : base(owner, g, clip, item, bounds)
        {
            Text = text;
            Style = style;
            Format = new StringFormat();
            Color = Color.Empty;
        }

        public RibbonTextEventArgs(Ribbon owner, Graphics g, Rectangle clip, RibbonItem item, Rectangle bounds, string text, StringFormat format)
            : base(owner, g, clip, item, bounds)
        {
            Text = text;
            Style = FontStyle.Regular;
            Format = format;
            Color = Color.Empty;
        }

        public RibbonTextEventArgs(Ribbon owner, Graphics g, Rectangle clip, RibbonItem item, Rectangle bounds, 
            string text, Color color, FontStyle style,  StringFormat format)
            : base(owner, g, clip, item, bounds)
        {
            Text = text;
            Style = style;
            Format = format;
            Color = color;
        }

        #endregion

        #region Props


        /// <summary>
        /// Gets or sets the color of the text to render
        /// </summary>
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }


        /// <summary>
        /// Gets or sets the text to render
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        /// <summary>
        /// Gets or sets the format of the text
        /// </summary>
        public StringFormat Format
        {
            get { return _format; }
            set { _format = value; }
        }

        /// <summary>
        /// Gets or sets the font style of the text
        /// </summary>
        public FontStyle Style
        {
            get { return _style; }
            set { _style = value; }
        }



        #endregion
    }
}
