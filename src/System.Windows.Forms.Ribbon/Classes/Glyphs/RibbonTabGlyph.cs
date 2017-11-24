using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms.Design.Behavior;

namespace System.Windows.Forms
{
   public class RibbonTabGlyph
       : Glyph
   {
      BehaviorService _behaviorService;
      Ribbon _ribbon;
      RibbonDesigner _componentDesigner;
      Rectangle bounds;

      public RibbonTabGlyph(BehaviorService behaviorService, RibbonDesigner designer, Ribbon ribbon)
         : base(new RibbonTabGlyphBehavior(designer, ribbon))
      {
         _behaviorService = behaviorService;
         _componentDesigner = designer;
         _ribbon = ribbon;
      }

      public override Rectangle Bounds
      {
         get
         {
            Point edge = _behaviorService.ControlToAdornerWindow(_ribbon);
            bounds = new Rectangle(5, _ribbon.OrbBounds.Bottom + 5, 60, 16);

            //If ribbon has tabs
            if (_ribbon.Tabs.Count > 0)
            {
               //Place glyph next to the last tab
               RibbonTab t = _ribbon.Tabs[_ribbon.Tabs.Count - 1];
               bounds = _ribbon.LayoutHelper.CalcNewPosition(t.Bounds, bounds, LayoutHelper.RTLLayoutPosition.Far, 5);
               bounds.Y = t.Bounds.Top + 2;
            }

             //If ribbon has contexts
            foreach (RibbonContext item in _ribbon.Contexts)
            {
                // Contexts not used on a RibbonTab will appear at the end of the tabs
                if (item.ContextualTabsCount == 0)
                {
                    //Place glyph next to the last tab
                    bounds = _ribbon.LayoutHelper.CalcNewPosition(item.Bounds, bounds, LayoutHelper.RTLLayoutPosition.Far, 5);
                }
            }

             bounds.Offset(edge);
                return bounds;
         }
      }

      public override Cursor GetHitTest(System.Drawing.Point p)
      {
         if (Bounds.Contains(p))
         {
            return Cursors.Hand;
         }

         return null;
      }


      public override void Paint(PaintEventArgs pe)
      {
         SmoothingMode smbuff = pe.Graphics.SmoothingMode;
         pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
         using (GraphicsPath p = RibbonProfessionalRenderer.RoundRectangle(Bounds, 2))
         {
            using (SolidBrush b = new SolidBrush(Color.FromArgb(50, Color.Blue)))
            {
               pe.Graphics.FillPath(b, p);
            }
         }
         StringFormat sf = StringFormatFactory.Center();
         pe.Graphics.DrawString("Add Tab", SystemFonts.DefaultFont, Brushes.White, Bounds, sf);
         pe.Graphics.SmoothingMode = smbuff;
      }
   }

   public class RibbonTabGlyphBehavior
       : Behavior
   {
      Ribbon _ribbon;
      RibbonDesigner _designer;

      public RibbonTabGlyphBehavior(RibbonDesigner designer, Ribbon ribbon)
      {
         _designer = designer;
         _ribbon = ribbon;
      }



      public override bool OnMouseUp(Glyph g, MouseButtons button)
      {
         _designer.AddTabVerb(this, EventArgs.Empty);
         return base.OnMouseUp(g, button);
      }
   }
}
