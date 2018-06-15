using System.Drawing;

namespace System.Windows.Forms
{
	public class RibbonToolTipRenderEventArgs : RibbonRenderEventArgs
	{
	    public RibbonToolTipRenderEventArgs(Ribbon owner, Graphics g, Rectangle clip, string text)
			: base(owner, g, clip)
		{
			Text = text;
		}

		public RibbonToolTipRenderEventArgs(Ribbon owner, Graphics g, Rectangle clip, string Text, Image tipImage)
			: base(owner, g, clip)
		{
			this.Text = Text;
			TipImage = tipImage;
		}

		public RibbonToolTipRenderEventArgs(Ribbon owner, Graphics g, Rectangle clip, string Text, Image tipImage, Color color, FontStyle style, StringFormat format, Font font)
			: base(owner, g, clip)
		{
			this.Text = Text;
			Color = Color;
			Style = style;
			Format = format;
			TipImage = tipImage;
			Font = font;
		}

		/// <summary>
		/// Gets the Text
		/// </summary>
		public string Text { get; set; }

	    /// <summary>
		/// Gets or sets the color of the text to render
		/// </summary>
		public Color Color { get; set; }

	    /// <summary>
		/// Gets or sets the format of the text
		/// </summary>
		public StringFormat Format { get; set; }

	    /// <summary>
		/// Gets or sets the font style of the text
		/// </summary>
		public FontStyle Style { get; set; }

	    /// <summary>
		/// Gets or sets the font
		/// </summary>
		public Font Font { get; set; } = new Font("Arial", 8);

	    /// <summary>
		/// Gets or sets the tip image
		/// </summary>
		public Image TipImage { get; set; }
	}
}
