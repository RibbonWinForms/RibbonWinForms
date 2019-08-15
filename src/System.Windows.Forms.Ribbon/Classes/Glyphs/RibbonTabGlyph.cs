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

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms.Design.Behavior;

namespace System.Windows.Forms
{
    public class RibbonTabGlyph
      : System.Windows.Forms.Design.Behavior.Glyph
    {
        private readonly BehaviorService _behaviorService;
        private readonly Ribbon _ribbon;
        private readonly RibbonDesigner _componentDesigner;
        private readonly Size size = new Size(120, 16);      // TODO: HACK: Size is hard-coded (tajbender)
        private const string _strAddTab = "Add Tab";         // TODO: i18n (tajbender)

        public RibbonTabGlyph(BehaviorService behaviorService,
                              RibbonDesigner designer,
                              Ribbon ribbon)
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
                var _bounds = new Rectangle(5, _ribbon.OrbBounds.Bottom + 5, 120, 16);

                //If ribbon has tabs
                if (_ribbon.Tabs.Count > 0)
                {
                    //Place glyph next to the last tab
                    RibbonTab t = _ribbon.Tabs[_ribbon.Tabs.Count - 1];
                    _bounds = _ribbon.LayoutHelper.CalcNewPosition(t.Bounds, _bounds, LayoutHelper.RTLLayoutPosition.Far, 5);
                    _bounds.Y = t.Bounds.Top + 2;
                }

                //If ribbon has contexts
                foreach (RibbonContext item in _ribbon.Contexts)
                {
                    // Contexts not used on a RibbonTab will appear at the end of the tabs
                    if (item.ContextualTabsCount == 0)
                    {
                        //Place glyph next to the last tab
                        _bounds = _ribbon.LayoutHelper.CalcNewPosition(item.Bounds, _bounds, LayoutHelper.RTLLayoutPosition.Far, 5);
                    }
                }

                _bounds.Offset(edge);
                return _bounds;
            }
        }

        public override Cursor GetHitTest(Point p)
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
            pe.Graphics.DrawString(_strAddTab, SystemFonts.DefaultFont, Brushes.White, Bounds, sf);
            pe.Graphics.SmoothingMode = smbuff;
        }
    }

    public class RibbonTabGlyphBehavior
        : Behavior
    {
        private readonly RibbonDesigner _designer;

        public RibbonTabGlyphBehavior(RibbonDesigner designer, Ribbon ribbon)
        {
            _designer = designer;
        }

        public override bool OnMouseUp(Glyph g, MouseButtons button)
        {
            _designer.AddTabVerb(this, EventArgs.Empty);
            return base.OnMouseUp(g, button);
        }
    }
}
