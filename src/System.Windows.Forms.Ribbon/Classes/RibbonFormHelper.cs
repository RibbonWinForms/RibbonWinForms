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
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Windows.Forms.RibbonHelpers;

namespace System.Windows.Forms
{
    /// <summary>
    /// This class is used to make a form able to contain a ribbon on the non-client area.
    /// For further instrucions search "ribbon non-client" on www.menendezpoo.com
    /// </summary>
    public class RibbonFormHelper
    {
        #region Subclasses
        /// <summary>
        /// Possible results of a hit test on the non client area of a form
        /// </summary>
        public enum NonClientHitTestResult
        {
            Nowhere = 0,
            Client = 1,
            Caption = 2,
            GrowBox = 4,
            MinimizeButton = 8,
            MaximizeButton = 9,
            Left = 10,
            Right = 11,
            Top = 12,
            TopLeft = 13,
            TopRight = 14,
            Bottom = 15,
            BottomLeft = 16,
            BottomRight = 17
        }
        #endregion

        #region Fields
        private FormWindowState _lastState;
        private Form _form;
        private Padding _margins;
        private bool _marginsChecked;
        private int _capionHeight;
        private bool _frameExtended;
        private Ribbon _ribbon;
        private Size _storeSize;
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new helper for the specified form
        /// </summary>
        /// <param name="f"></param>
        public RibbonFormHelper(Form f)
        {
            _form = f;
            _form.Load += new EventHandler(Form_Load);
            _form.ResizeEnd += new EventHandler(_form_ResizeEnd);
            _form.Layout += new LayoutEventHandler(_form_Layout);
        }

        void _form_Layout(object sender, LayoutEventArgs e)
        {
            if (_lastState == _form.WindowState)
            {
                return;
            }

            // in case the RibbonForm is started in WindowState.Maximized and the WindowState changes to normal
            // the size of the RibbonForm is set to the values of _storeSize - which has not been set yet!
            if (_storeSize.IsEmpty)
               _storeSize = _form.Size;

            if (WinApi.IsGlassEnabled)
                Form.Invalidate();
            else  // on XP systems Invalidate is not sufficient in case the Form contains a control with DockStyle.Fill
                Form.Refresh();

            _lastState = _form.WindowState;
        }

        void _form_ResizeEnd(object sender, EventArgs e)
        {
            UpdateRibbonConditions();
            Form.Refresh();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Ribbon related with the form
        /// </summary>
        public Ribbon Ribbon
        {
            get { return _ribbon; }
            set { _ribbon = value; UpdateRibbonConditions(); }
        }

        /// <summary>
        /// Gets or sets the height of the caption bar relative to the form
        /// </summary>
        public int CaptionHeight
        {
            get { return _capionHeight; }
            set { _capionHeight = value; }
        }

        /// <summary>
        /// Gets the form this class is helping
        /// </summary>   
        public Form Form
        {
            get { return _form; }
        }

        /// <summary>
        /// Gets the margins of the non-client area
        /// </summary>
        public Padding Margins
        {
            get { return _margins; }
        }

        /// <summary>
        /// Gets or sets if the margins are already checked by WndProc
        /// </summary>
        private bool MarginsChecked
        {
            get { return _marginsChecked; }
            set { _marginsChecked = value; }
        }

        /// <summary>
        /// Gets if the <see cref="Form"/> is currently in Designer mode
        /// </summary>
        private bool DesignMode
        {
            get { return Form != null && Form.Site != null && Form.Site.DesignMode; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Checks if ribbon should be docked or floating and updates its size
        /// </summary>
        private void UpdateRibbonConditions()
        {
            if (Ribbon == null) return;

            if (Ribbon.Dock != DockStyle.Top)
            {
                Ribbon.Dock = DockStyle.Top;
            }
        }

        /// <summary>
        /// Called when helped form is activated
        /// </summary>
        /// <param name="sender">Object that raised the event</param>
        /// <param name="e">Event data</param>
        public void Form_Paint(object sender, PaintEventArgs e)
        {
            if (DesignMode) return;

            if (WinApi.IsGlassEnabled)
            {
                WinApi.FillForGlass(e.Graphics, new Rectangle(0, 0, Form.Width, Form.Height));

                using (Brush b = new SolidBrush(Form.BackColor))
                {
                    e.Graphics.FillRectangle(b,
                        Rectangle.FromLTRB(
                            Margins.Left - 0,
                            Margins.Top + 0,
                            Form.Width - Margins.Right - 0,
                            Form.Height - Margins.Bottom - 0));
                }

            }
            else
            {
                PaintTitleBar(e);
            }

        }

        /// <summary>
        /// Draws the title bar of the form when not in glass
        /// </summary>
        /// <param name="e"></param>
        private void PaintTitleBar(PaintEventArgs e)
        {
            int radius1 = 4, radius2 = radius1 - 0;
            Rectangle rPath = new Rectangle(Point.Empty, Form.Size);
            Rectangle rInner = new Rectangle(Point.Empty, new Size(rPath.Width - 1, rPath.Height - 1));

            using (GraphicsPath path = RibbonProfessionalRenderer.RoundRectangle(rPath, radius1))
            {
                using (GraphicsPath innerPath = RibbonProfessionalRenderer.RoundRectangle(rInner, radius2))
                {
                    if (Ribbon != null && Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaCustomDrawn)
                    {
                        RibbonProfessionalRenderer renderer = Ribbon.Renderer as RibbonProfessionalRenderer;

                        if (renderer != null)
                        {
                            e.Graphics.Clear(renderer.ColorTable.RibbonBackground);  // draw the Form border explicitly, otherwise problems as MDI parent occur
                            using (SolidBrush p = new SolidBrush(renderer.ColorTable.Caption1))
                            {
                                e.Graphics.FillRectangle(p, new Rectangle(0, 0, Form.Width, Ribbon.CaptionBarSize));
                            }
                            renderer.DrawCaptionBarBackground(new Rectangle(0, Margins.Bottom - 1, Form.Width, Ribbon.CaptionBarSize), e.Graphics);

                            using (Region rgn = new Region(path))
                            {
                                //Set Window Region
                                Form.Region = rgn;
                                SmoothingMode smbuf = e.Graphics.SmoothingMode;
                                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                using (Pen p = new Pen(renderer.ColorTable.FormBorder, 1))
                                {
                                    e.Graphics.DrawPath(p, innerPath);
                                }
                                e.Graphics.SmoothingMode = smbuf;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Called when helped form is activated
        /// </summary>
        /// <param name="sender">Object that raised the event</param>
        /// <param name="e">Event data</param>
        protected virtual void Form_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            WinApi.MARGINS dwmMargins = new WinApi.MARGINS(
                Margins.Left,
                Margins.Right,
                Margins.Bottom + ((Ribbon.OrbStyle == RibbonOrbStyle.Office_2007) ? Ribbon.CaptionBarHeight : Ribbon.CaptionBarHeight + Ribbon.TabsMargin.Top),
                Margins.Bottom);

            if (WinApi.IsVista && !_frameExtended)
            {
                WinApi.DwmExtendFrameIntoClientArea(Form.Handle, ref dwmMargins);
                _frameExtended = true;
            }
        }

        /// <summary>
        /// Reapply Glass to the form (used after changing Orb style)
        /// </summary>
        public virtual void ReapplyGlass()
        {
            _frameExtended = false;
            Form_Load(this, null);
        }

        /// <summary>
        /// Processes the WndProc for a form with a Ribbbon. Returns true if message has been handled
        /// </summary>
        /// <param name="m">Message to process</param>
        /// <returns><c>true</c> if message has been handled. <c>false</c> otherwise</returns>
        public virtual bool WndProc(ref Message m)
        {
            if (DesignMode) return false;

            bool handled = false;

            if (WinApi.IsVista)
            {
                #region Checks if DWM processes the message
                IntPtr result;
                int dwmHandled = WinApi.DwmDefWindowProc(m.HWnd, m.Msg, m.WParam, m.LParam, out result);

                if (dwmHandled == 1)
                {
                    m.Result = result;
                    handled = true;
                }
                #endregion
            }

            //if (m.Msg == WinApi.WM_NCLBUTTONUP)
            //{
            //    UpdateRibbonConditions();
            //}

            if (!handled)
            {
                if (m.Msg == WinApi.WM_NCCALCSIZE && (int)m.WParam == 1) //0x83
                {
                    #region Catch the margins of what the client area would be
                    WinApi.NCCALCSIZE_PARAMS nccsp = (WinApi.NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(WinApi.NCCALCSIZE_PARAMS));

                    if (!MarginsChecked)
                    {
                        //Set what client area would be for passing to DwmExtendIntoClientArea
                        SetMargins(new Padding(
                             nccsp.rect2.Left - nccsp.rect1.Left,
                             nccsp.rect2.Top - nccsp.rect1.Top,
                             nccsp.rect1.Right - nccsp.rect2.Right,
                             nccsp.rect1.Bottom - nccsp.rect2.Bottom));

                        MarginsChecked = true;
                    }

                    #region Hack to get rid of the black caption bar when form is maximized on multi-monitor setups with DWM enabled
                    // toATwork: on multi-monitor setups the caption bar when the form is maximized the caption bar is black instead of glass
                    //             * set handled to false and let the base implementation handle it, will work but then the default caption bar
                    //               is also visible - not desired
                    //             * setting the client area to some other value, e.g. descrease the size of the client area by one pixel will
                    //               cause windows to render the caption bar a glass - not correct but the lesser of the two evils
                    if (Screen.AllScreens.Length > 1 && WinApi.IsGlassEnabled)
                        nccsp.rect0.Bottom -= 1;
                    #endregion

                    Marshal.StructureToPtr(nccsp, m.LParam, false);

                    m.Result = IntPtr.Zero;
                    handled = true;
                    #endregion
                }
                else if (m.Msg == WinApi.WM_NCACTIVATE && Ribbon != null && Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaCustomDrawn)
                {
                    Ribbon.Invalidate(); handled = true;
                    if (m.WParam == IntPtr.Zero)  // if could be removed because result is ignored if WParam is TRUE
                        m.Result = (IntPtr)1;
                }
                else if ((m.Msg == WinApi.WM_ACTIVATE || m.Msg == WinApi.WM_PAINT) && WinApi.IsVista) //0x06 - 0x000F
                {
                    m.Result = (IntPtr)1; handled = false;
                }
                else if (m.Msg == WinApi.WM_NCHITTEST && (int)m.Result == 0) //0x84
                {
                    m.Result = new IntPtr(Convert.ToInt32(NonClientHitTest(new Point(WinApi.LoWord((int)m.LParam), WinApi.HiWord((int)m.LParam)))));
                    handled = true;
                }
                else if (m.Msg == WinApi.WM_SYSCOMMAND)
                {
                    uint param = IntPtr.Size == 4 ? (uint)m.WParam.ToInt32() : (uint)m.WParam.ToInt64();
                    if ((param & 0xFFF0) == WinApi.SC_RESTORE)
                    {
                        Form.Size = _storeSize;
                    }
                    else if (Form.WindowState == FormWindowState.Normal)
                    {
                        _storeSize = Form.Size;
                    }
                }
                else if (m.Msg == WinApi.WM_WINDOWPOSCHANGING || m.Msg == WinApi.WM_WINDOWPOSCHANGED)  // needed to update the title of MDI parent (at least)
                {
                    if (Ribbon != null)
                        Ribbon.Invalidate();
                }
            }
            return handled;
        }

        /// <summary>
        /// Performs hit test for mouse on the non client area of the form
        /// </summary>
        /// <param name="form">Form to check bounds</param>
        /// <param name="dwmMargins">Margins of non client area</param>
        /// <param name="lparam">Lparam of</param>
        /// <returns></returns>
        public virtual NonClientHitTestResult NonClientHitTest(Point hitPoint)
        {

            Rectangle topleft = Form.RectangleToScreen(new Rectangle(0, 0, Margins.Left, Margins.Left));

            if (topleft.Contains(hitPoint))
                return NonClientHitTestResult.TopLeft;

            Rectangle topright = Form.RectangleToScreen(new Rectangle(Form.Width - Margins.Right, 0, Margins.Right, Margins.Right));

            if (topright.Contains(hitPoint))
                return NonClientHitTestResult.TopRight;

            Rectangle botleft = Form.RectangleToScreen(new Rectangle(0, Form.Height - Margins.Bottom, Margins.Left, Margins.Bottom));

            if (botleft.Contains(hitPoint))
                return NonClientHitTestResult.BottomLeft;

            Rectangle botright = Form.RectangleToScreen(new Rectangle(Form.Width - Margins.Right, Form.Height - Margins.Bottom, Margins.Right, Margins.Bottom));

            if (botright.Contains(hitPoint))
                return NonClientHitTestResult.BottomRight;

            Rectangle top = Form.RectangleToScreen(new Rectangle(0, 0, Form.Width, Margins.Left));

            if (top.Contains(hitPoint))
                return NonClientHitTestResult.Top;

            Rectangle cap = Form.RectangleToScreen(new Rectangle(0, Margins.Left, Form.Width, Margins.Top - Margins.Left));

            if (cap.Contains(hitPoint))
                return NonClientHitTestResult.Caption;

            Rectangle left = Form.RectangleToScreen(new Rectangle(0, 0, Margins.Left, Form.Height));

            if (left.Contains(hitPoint))
                return NonClientHitTestResult.Left;

            Rectangle right = Form.RectangleToScreen(new Rectangle(Form.Width - Margins.Right, 0, Margins.Right, Form.Height));

            if (right.Contains(hitPoint))
                return NonClientHitTestResult.Right;

            Rectangle bottom = Form.RectangleToScreen(new Rectangle(0, Form.Height - Margins.Bottom, Form.Width, Margins.Bottom));

            if (bottom.Contains(hitPoint))
                return NonClientHitTestResult.Bottom;

            return NonClientHitTestResult.Client;
        }

        /// <summary>
        /// Sets the value of the <see cref="Margins"/> property;
        /// </summary>
        /// <param name="p"></param>
        private void SetMargins(Padding p)
        {
            _margins = p;

            Padding formPadding = p;
            formPadding.Top = p.Bottom - 1;

            if (!DesignMode)
                Form.Padding = formPadding;
        }

        #endregion
    }
}