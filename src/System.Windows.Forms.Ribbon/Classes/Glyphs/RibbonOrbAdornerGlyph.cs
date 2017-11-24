using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms.Design.Behavior;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace System.Windows.Forms
{
    public class RibbonOrbAdornerGlyph
        : Glyph
    {
        #region Fields
        private bool _menuVisible;
        private BehaviorService _behaviorService;
        private Ribbon _ribbon;
        private RibbonDesigner _componentDesigner;
        #endregion

        #region Ctor

        public RibbonOrbAdornerGlyph(BehaviorService behaviorService, RibbonDesigner designer, Ribbon ribbon)
            : base(new RibbonOrbAdornerGlyphBehavior())
        {
            _behaviorService = behaviorService;
            _componentDesigner = designer;
            _ribbon = ribbon;
        }

        #endregion

        #region Props

        /// <summary>
        /// Gets or sets if the orb menu is visible on the desginer
        /// </summary>
        public bool MenuVisible
        {
            get { return _menuVisible; }
            set { _menuVisible = value; }
        }

        #endregion

        #region Methods

        public override Rectangle Bounds
        {
            get
            {
                Point edge = _behaviorService.ControlToAdornerWindow(_ribbon);
                return new Rectangle(
                    edge.X + _ribbon.OrbBounds.Left,
                    edge.Y + _ribbon.OrbBounds.Top, 
                    _ribbon.OrbBounds.Height, 
                    _ribbon.OrbBounds.Height);
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
            //SmoothingMode smbuff = pe.Graphics.SmoothingMode;
            //pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //using (SolidBrush b = new SolidBrush(Color.FromArgb(50, Color.Blue)))
            //{
            //    pe.Graphics.FillEllipse(b, Bounds);
            //}
            
        }
        #endregion
    }

    public class RibbonOrbAdornerGlyphBehavior
        : Behavior
	{

	}
}
