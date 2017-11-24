/*
 * 2011 Kevin Carbis
 * Implements Super Tooltip style
*/

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System;
using System.Diagnostics;
using System.ComponentModel;

namespace System.Windows.Forms
{
	/// <summary>
	/// CustomizedToolTip to create tooltips with Image.
	/// </summary>
	public class RibbonToolTip : ToolTip
	{
		#region Constants

		private const int DEFAULT_WIDTH = 200;

		#endregion

		#region Fields
		private IRibbonElement _RibbonElement = null;
		private Image _ToolTipImage = null;

		private static Color _BorderColor = Color.Red;
		private Font _Font = new Font("Segoe UI", 8);
		private Padding TipPadding = new Padding(5, 5, 5, 5);

		private Rectangle _ImageRectangle = new Rectangle();
		private Rectangle _TitleRectangle = new Rectangle();
		private Rectangle _TextRectangle = new Rectangle();
		private Rectangle _ToolTipRectangle = new Rectangle();

		private Size _Size = new Size(200, 60);

		private int _ImageWidth = 15;
		private bool _AutoSize = true;
		#endregion

		/// <summary>
		/// New Popup Eventhandler. Is handled before <see cref="System.Windows.Forms.ToolTip.Popup"/>.
		/// </summary>
		public new event PopupEventHandler Popup;

		#region Properties

		private Ribbon Owner { get { return _RibbonElement.Owner; } }

		/// <summary>
		/// Gets or sets a value indicating whether the ToolTip is drawn by the operating
		/// system or by code that you provide.
		/// If true, the properties 'ToolTipIcon' and 'ToolTipTitle' will set to their default values
		/// and the image will display in ToolTip otherwise only text will display.
		/// </summary>
		[CategoryAttribute("Custom Settings"), DescriptionAttribute(@"Gets or sets a value indicating whether the ToolTip is drawn by the operating system or by code that you provide. If true, the properties 'ToolTipIcon' and 'ToolTipTitle' will set to their default values and the image will display in ToolTip otherwise only text will display.")]
		public new bool OwnerDraw
		{
			get
			{
				return base.OwnerDraw;
			}
			set
			{
				if (value)
				{
					this.ToolTipIcon = ToolTipIcon.None;
					this.ToolTipTitle = string.Empty;
				}
				base.OwnerDraw = value;
			}
		}

		/// <summary>
		/// Gets or sets a value that defines the type of icon to be displayed alongside
		/// the ToolTip text.
		/// Cannot set if the property 'OwnerDraw' is true.
		/// </summary>
		[CategoryAttribute("Custom Settings"), DescriptionAttribute(@"Gets or sets a value that defines the type of icon to be displayed alongside the ToolTip text. Cannot set if the property 'OwnerDraw' is true.")]
		public new ToolTipIcon ToolTipIcon
		{
			get
			{
				return base.ToolTipIcon;
			}
			set
			{
				//if (!OwnerDraw)
				//{
				base.ToolTipIcon = value;
				//}
			}
		}

		/// <summary>
		/// Gets or sets a title for the ToolTip window.
		/// Cannot set if the property 'OwnerDraw' is true.
		/// </summary>
		[CategoryAttribute("Custom Settings"), DescriptionAttribute(@"Gets or sets a title for the ToolTip window. Cannot set if the property 'OwnerDraw' is true.")]
		public new string ToolTipTitle
		{
			get
			{
				return base.ToolTipTitle;
			}
			set
			{
				//if (!OwnerDraw)
				//{
				base.ToolTipTitle = value;
				//}
			}
		}

		/// <summary>
		/// Gets or sets the image for the ToolTip window.
		/// Cannot set if the property 'OwnerDraw' is true.
		/// </summary>
		[CategoryAttribute("Custom Settings"), DescriptionAttribute(@"Gets or sets an Image for the ToolTip window. Cannot set if the property 'OwnerDraw' is true.")]
		public Image ToolTipImage
		{
			get
			{
				return _ToolTipImage;
			}
			set
			{
				_ToolTipImage = value;
			}
		}

		///// <summary>
		///// Gets or sets the text for the ToolTip window.
		///// Cannot set if the property 'OwnerDraw' is true.
		///// </summary>
		//[CategoryAttribute("Custom Settings"), DescriptionAttribute(@"Gets or sets the Text for the ToolTip window. Cannot set if the property 'OwnerDraw' is true.")]
		//public string ToolTipText
		//{
		//   get
		//   {
		//      return _ToolTipText;
		//   }
		//   set
		//   {
		//      if (!OwnerDraw)
		//      {
		//         _ToolTipText = value;
		//      }
		//   }
		//}

		/// <summary>
		/// Gets or sets the background color for the ToolTip.
		/// </summary>
		[CategoryAttribute("Custom Settings"), DescriptionAttribute(@"Gets or sets the background color for the ToolTip.")]
		public new Color BackColor
		{
			get { return base.BackColor; }
			set { base.BackColor = value; }
		}

		/// <summary>
		/// Gets or sets the foreground color for the ToolTip.
		/// </summary>
		[CategoryAttribute("Custom Settings"), DescriptionAttribute(@"Gets or sets the foreground color for the ToolTip.")]
		public new Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		/// <summary>
		/// Gets or sets a value that indicates whether the ToolTip resizes based on its text.
		/// true if the ToolTip automatically resizes based on its text; otherwise, false. The default is true.
		/// </summary>
		[CategoryAttribute("Custom Settings"), DescriptionAttribute(@"Gets or sets a value that indicates whether the ToolTip resizes based on its text. true if the ToolTip automatically resizes based on its text; otherwise, false. The default is true.")]
		public bool AutoSize
		{
			get { return _AutoSize; }
			set
			{
				_AutoSize = value;
				if (_AutoSize)
				{
					//_TextFormat.Trimming = StringTrimming.None;
				}
				else
				{
					//_TextFormat.Trimming = StringTrimming.EllipsisCharacter;
				}
			}
		}

		/// <summary>
		/// Gets or sets the size of the ToolTip.
		/// Valid only if the Property 'AutoSize' is false.
		/// </summary>
		[CategoryAttribute("Custom Settings"), DescriptionAttribute(@"Gets or sets the size of the ToolTip. Valid only if the Property 'AutoSize' is false.")]
		public Size Size
		{
			get { return _Size; }
			set
			{
				if (!_AutoSize)
				{
					_Size = value;
					_ToolTipRectangle.Size = _Size;
				}
			}
		}

		/// <summary>
		/// Gets or sets the border color for the ToolTip.
		/// </summary>
		[CategoryAttribute("Custom Settings"), DescriptionAttribute(@"Gets or sets the border color for the ToolTip.")]
		public Color BorderColor
		{
			get { return _BorderColor; }
			set { _BorderColor = value; }
		}

		#endregion

		#region Constructor

		/// <summary>
		/// Constructor to create instance of RibbonToolTip.
		/// </summary>
		public RibbonToolTip(IRibbonElement ribbonElement)
		{
			try
			{
				this._RibbonElement = ribbonElement;
				this.OwnerDraw = true;
				this.AutoSize = false;

				base.Popup += new PopupEventHandler(ToolTip_Popup);
				this.Draw += new DrawToolTipEventHandler(ToolTip_Draw);
			}
			catch (Exception ex)
			{
				string logMessage = "Exception in RibbonToolTip.RibbonToolTip() " + ex.ToString();
				Trace.TraceError(logMessage);
				throw;
			}
		}

		#endregion

		#region Methods

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			try
			{
				//Dispose of the disposable objects.
				try
				{
					if (disposing)
					{
						if (_Font != null)
						{
							_Font.Dispose();
						}

                        // ADDED
                        base.Popup -= new PopupEventHandler(ToolTip_Popup);
                        this.Draw -= new DrawToolTipEventHandler(ToolTip_Draw);
					}
				}
				finally
				{
					base.Dispose(disposing);
				}
			}

			catch (Exception ex)
			{
				string logMessage = "Exception in CustomizedToolTip.Dispose (bool) " + ex.ToString();
				Trace.TraceError(logMessage);
				throw;
			}
		}

		/// <summary>
		/// CustomizedToolTip_Draw raised when tooltip is drawn.
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		void ToolTip_Draw(object sender, DrawToolTipEventArgs e)
		{
			try
			{
				e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
				//Get the tooltip text
				string TipText = base.GetToolTip(e.AssociatedControl);

				RibbonToolTipRenderEventArgs eTip = new RibbonToolTipRenderEventArgs(Owner, e.Graphics, e.Bounds, TipText);
				eTip.Color = Color.Black;
				eTip.Font = _Font;

				Owner.Renderer.OnRenderToolTipBackground(eTip);
				//e.DrawBackground();

				StringFormat sf = new StringFormat();
				sf.Trimming = StringTrimming.None;
				eTip.Format = sf;

				//draw the image
				if (_ImageRectangle.Width > 0 && _ImageRectangle.Height > 0)
				{
					//_Owner.Renderer.OnRenderToolTipImage(eTip);
					e.Graphics.DrawImage(_ToolTipImage, _ImageRectangle);
				}

				//draw the tooltip text
				if (_TextRectangle.Width > 0 && _TextRectangle.Height > 0)
				{
					sf.Alignment = StringAlignment.Near;
					sf.LineAlignment = StringAlignment.Near;
					eTip.ClipRectangle = _TextRectangle;
					eTip.Text = TipText;
					Owner.Renderer.OnRenderToolTipText(eTip);
				}

				// Draw the Title
				if (_TitleRectangle.Width > 0 && _TitleRectangle.Height > 0)
				{
					Font f = new Font(_Font, FontStyle.Bold);
					eTip.ClipRectangle = _TitleRectangle;
					eTip.Text = ToolTipTitle;
					eTip.Font = f;
					Owner.Renderer.OnRenderToolTipText(eTip);
					f.Dispose();
				}
			}

			catch (Exception ex)
			{
				string logMessage = "Exception in RibbonToolTip_Draw (object, DrawToolTipEventArgs) " + ex.ToString();
				Trace.TraceError(logMessage);
				throw;
			}
		}

		/// <summary>
		/// CustomizedToolTip_Popup raised when tooltip pops up.
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		void ToolTip_Popup(object sender, PopupEventArgs e)
		{
			if (this.Popup != null)
			{
				this.Popup(sender, e);
				if (e.Cancel)  // it cancel return ASAP
					return;
			}

			//here we measure the size requirements of the tooltip
			try
			{
				if (OwnerDraw)
				{
					if (!_AutoSize)
					{
						//manually determine the tip size based on the visible components
						Graphics g = e.AssociatedControl.CreateGraphics();
						Size sSize;

						int CurLeft = TipPadding.Left;
						int CurTop = TipPadding.Top;

						if (!string.IsNullOrEmpty(base.ToolTipTitle))
						{
							Font fTitle = new Font(_Font, FontStyle.Bold);
							sSize = g.MeasureString(base.ToolTipTitle, fTitle, DEFAULT_WIDTH).ToSize();
							sSize.Width = Math.Max(sSize.Width + 5, DEFAULT_WIDTH);
							_TitleRectangle = new Rectangle(CurLeft, CurTop, sSize.Width, sSize.Height);
							//_TitleRectangle = Rectangle.FromLTRB(CurLeft, CurTop, sSize.Width + CurLeft, CurTop + sSize.Height);
							CurTop = _TitleRectangle.Bottom + 5;
							fTitle.Dispose();
						}

						if (_ToolTipImage != null)
						{
							_ImageRectangle = new Rectangle(CurLeft, CurTop, _ToolTipImage.Width + 2, _ToolTipImage.Height + 2);

							CurLeft = _ImageRectangle.Right + 10;
						}
						else if (!string.IsNullOrEmpty(base.ToolTipTitle))
						{
							CurLeft += 15; //indent the text from the title
						}

						sSize = g.MeasureString(base.GetToolTip(e.AssociatedControl), _Font, DEFAULT_WIDTH).ToSize();
						_TextRectangle = Rectangle.FromLTRB(CurLeft, CurTop, sSize.Width + CurLeft + 4, CurTop + sSize.Height);
						CurLeft = _TextRectangle.Right;

						//now calculate the total size of the tooltip and set the size
						Size TSize = new Size(Math.Max(_TextRectangle.Right, _TitleRectangle.Right) + TipPadding.Right, Math.Max(_TextRectangle.Bottom, _ImageRectangle.Bottom) + TipPadding.Bottom);
						e.ToolTipSize = TSize;
					}
					else
					{
						Size oldSize = e.ToolTipSize;
						Control parent = e.AssociatedControl;
						Image toolTipImage = parent.Tag as Image;
						if (toolTipImage != null)
						{
							_ImageWidth = oldSize.Height;
							oldSize.Width += _ImageWidth + TipPadding.Left;
						}
						else
						{
							oldSize.Width += TipPadding.Left;
						}
						e.ToolTipSize = oldSize;
					}
				}
			}
			catch (Exception ex)
			{
				string logMessage = "Exception in RibbonToolTip_Popup (object, PopupEventArgs) " + ex.ToString();
				Trace.TraceError(logMessage);
				throw;
			}
		}

		#endregion
	}
}