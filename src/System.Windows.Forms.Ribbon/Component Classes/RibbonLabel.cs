using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms
{
   public class RibbonLabel : RibbonItem
   {
      #region Fields

      private int _labelWidth;
      private const int spacing = 3;

      #endregion

      #region Methods
      protected virtual int MeasureHeight()
      {
         if (Owner != null)
            return 16 + Owner.ItemMargin.Vertical;
         else
            return 16 + 4;
      }

      /// <summary>
      /// Measures the size of the panel on the mode specified by the event object
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      /// <returns></returns>
      public override Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
      {
         if (!this.Visible && ((this.Site == null) || !this.Site.DesignMode))
         {
            return new Size(0, 0);
         }
         Font f = new Font("Microsoft Sans Serif", 8);
         if (Owner != null)
            f = Owner.Font;

         int w = string.IsNullOrEmpty(this.Text) ? 0 : ((this._labelWidth > 0) ? this._labelWidth : (e.Graphics.MeasureString(this.Text, f).ToSize().Width + 6));
         base.SetLastMeasuredSize(new Size(w, this.MeasureHeight()));
         return base.LastMeasuredSize;
      }

      /// <summary>
      /// Raises the paint event and draws the
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      public override void OnPaint(object sender, RibbonElementPaintEventArgs e)
      {
         if (Owner != null)
         {
            base.Owner.Renderer.OnRenderRibbonItem(new RibbonItemRenderEventArgs(base.Owner, e.Graphics, base.Bounds, this));
            StringFormat f = StringFormatFactory.CenterNoWrap(StringTrimming.None);
            f.Alignment = (StringAlignment)TextAlignment;
            Rectangle clipBounds = Rectangle.FromLTRB(Bounds.Left + 3, Bounds.Top + Owner.ItemMargin.Top, Bounds.Right - 3, Bounds.Bottom - Owner.ItemMargin.Bottom);
            base.Owner.Renderer.OnRenderRibbonItemText(new RibbonTextEventArgs(Owner, e.Graphics, Bounds, this, clipBounds, this.Text, f));
         }
      }

      /// <summary>
      /// Sets the bounds of the panel
      /// </summary>
      /// <param name="bounds"></param>
      public override void SetBounds(Rectangle bounds)
      {
         base.SetBounds(bounds);
      }
      #endregion

      #region Properties
      [Description("Sets the width of the label portion of the control")]
      [Category("Appearance")]
      [DefaultValue(0)]
      public int LabelWidth
      {
         get
         {
            return this._labelWidth;
         }
         set
         {
             if (this._labelWidth != value)
             {
                 this._labelWidth = value;
                 base.NotifyOwnerRegionsChanged();
             }
         }
      }
      #endregion
   }
}
