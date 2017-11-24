using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace System.Windows.Forms
{
	public class RibbonToolTipRenderEventArgs : RibbonRenderEventArgs
	{
		private StringFormat _format;
		private Font _font = new Font("Arial", 8);
		private FontStyle _style;
		private Color _color;
		private string _text;
		private Image _image;

		public RibbonToolTipRenderEventArgs(Ribbon owner, Graphics g, Rectangle clip, string text)
			: base(owner, g, clip)
		{
			_text = text;
		}

		public RibbonToolTipRenderEventArgs(Ribbon owner, Graphics g, Rectangle clip, string Text, Image tipImage)
			: base(owner, g, clip)
		{
			_text = Text;
			_image = tipImage;
		}

		public RibbonToolTipRenderEventArgs(Ribbon owner, Graphics g, Rectangle clip, string Text, Image tipImage, Color color, FontStyle style, StringFormat format, Font font)
			: base(owner, g, clip)
		{
			_text = Text;
			_color = Color;
			_style = style;
			_format = format;
			_image = tipImage;
			_font = font;
		}

		/// <summary>
		/// Gets the Text
		/// </summary>
		public string Text
		{
			get { return _text; }
			set { _text = value; }
		}

		/// <summary>
		/// Gets or sets the color of the text to render
		/// </summary>
		public Color Color
		{
			get { return _color; }
			set { _color = value; }
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

		/// <summary>
		/// Gets or sets the font
		/// </summary>
		public Font Font
		{
			get { return _font ; }
			set { _font = value; }
		}

		/// <summary>
		/// Gets or sets the tip image
		/// </summary>
		public Image TipImage
		{
			get { return _image; }
			set { _image = value; }
		}
	}
}
