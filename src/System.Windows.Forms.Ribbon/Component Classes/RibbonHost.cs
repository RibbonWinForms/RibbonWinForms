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

using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms
{
    public class RibbonHost : RibbonItem
    {
        #region private variables
        private Control _ctl;
        private Control _ctlParent;
        private Font _ctlFont;
        private Size _ctlSize;
        private Point _ctlLocation;
        private bool _ctlVisible;
        private RibbonElementSizeMode _lastSizeMode;
        #endregion

        #region private methods
        private void DoCtlMouseMove(object sender, MouseEventArgs e)
        {
            // Note: Unlike all other Ribbon components, e.X and e.Y coordinates are based on the controls Top and Left, not the Ribbons.
            //Console.WriteLine(e.Location.ToString());

            /* If control is on the Ribbon send the mouse move event to the Ribbon directly, converting from
             * control coordinates to Ribbon coordinates. */
            if (OwnerItem == null)
            {
                var eRibbonArgs = new MouseEventArgs(e.Button, e.Clicks,
                    Owner.PointToClient(_ctl.PointToScreen(e.Location)).X,
                    Owner.PointToClient(_ctl.PointToScreen(e.Location)).Y, e.Delta);

                /* This should probably raise an event, however there is no reference to hosted controls on the Ribbon.
                 * In the future, probably better to have a control collection for hosted controls on the Ribbon and monitor the
                 * mousemove there and filter down. */
                Owner.OnRibbonHostMouseMove(eRibbonArgs);
            }
            else
            {
                // Raise MouseMove event to any container (i.e. containing DropDown).
                ClientMouseMove?.Invoke(this, new MouseEventArgs(e.Button, e.Clicks, Bounds.Left + e.X, Bounds.Top + e.Y, e.Delta));
            }
            OnMouseMove(e);
        }
        private void Owner_ActiveTabChanged(object sender, EventArgs e)
        {
            //hide this control if our tab is not the active tab
            if ((_ctl != null) &&
                (OwnerTab != null) &&
                (Owner.ActiveTab != OwnerTab))
            {
                _ctl.Visible = false;
            }
        }
        private void RibbonHost_CanvasChanged(object sender, EventArgs e)
        {
            if ((_ctl == null) ||
                (Canvas == null))
            {
                return;
            }
            _ctlParent = _ctl.Parent;
            _ctlLocation = _ctl.Location;
            _ctlSize = _ctl.Size;
            _ctlVisible = _ctl.Visible;
            Canvas.Controls.Add(_ctl);
            _ctl.Font = _ctlFont;
        }
        internal override void SetSizeMode(RibbonElementSizeMode sizeMode)
        {
            base.SetSizeMode(sizeMode);
            if ((_ctl != null) &&
                (OwnerPanel != null) &&
                (OwnerPanel.SizeMode == RibbonElementSizeMode.Overflow))
            {
                _ctl.Visible = false;
            }
        }
        #endregion

        #region public methods
        public override void OnPaint(object sender, RibbonElementPaintEventArgs e)
        {
            if (Owner == null)
            {
                return;
            }
            var f = StringFormatFactory.CenterNoWrap(StringTrimming.None);
            var design = ((Site?.DesignMode ?? false) ||
                              IsOpenInVisualStudioDesigner());
            var args = new RibbonTextEventArgs(Owner, e.Graphics, Bounds, this, Bounds, design ? Site.Name : Text, f);
            Owner.Renderer.OnRenderRibbonItemText(args);
            if (design)
            {
                return;
            }
            if (_ctl == null)
            {
                return;
            }
            if ((_ctl.Parent != Canvas) &&
                (Canvas != null))
            {
                _ctlParent = _ctl.Parent;
                _ctlLocation = _ctl.Location;
                _ctlSize = _ctl.Size;
                Canvas.Controls.Add(_ctl);
                _ctl.Location = new Point(Bounds.Left, Bounds.Top);
                _ctl.Visible = true;
                _ctl.BringToFront();
            }
            else
            {
                if ((_ctl.Location.X != Bounds.Left) ||
                    (_ctl.Location.Y != Bounds.Top))
                {
                    _ctl.Location = new Point(Bounds.Left, Bounds.Top);
                }
                if (_ctl.Visible)
                {
                    return;
                }
                _ctl.Visible = true;
                _ctl.BringToFront();
            }
        }
        public override Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
        {
            var design = ((Site?.DesignMode ?? false) ||
                             IsOpenInVisualStudioDesigner());
            if (design && (Owner != null))
            {
                var width = Convert.ToInt32(e.Graphics.MeasureString(Site.Name, Owner.Font).Width);
                const int height = 20;
                if ((width == LastMeasuredSize.Width) &&
                    (height == LastMeasuredSize.Height))
                {
                    return LastMeasuredSize;
                }
                SetLastMeasuredSize(new Size(width, height));
            }
            else if ((_ctl == null) || !Visible)
            {
                SetLastMeasuredSize(new Size(0, 0));
            }
            else
            {
                if ((_lastSizeMode == e.SizeMode) &&
                    (_ctl.Size.Width == LastMeasuredSize.Width) &&
                    (_ctl.Size.Height == LastMeasuredSize.Height))
                {
                    return LastMeasuredSize;
                }
                _ctl.Visible = false;
                if (_lastSizeMode != e.SizeMode)
                {
                    _lastSizeMode = e.SizeMode;
                    var hev = new RibbonHostSizeModeHandledEventArgs(e.Graphics, e.SizeMode);
                    OnSizeModeChanging(ref hev);
                }
                SetLastMeasuredSize(new Size(_ctl.Size.Width, _ctl.Size.Height));
            }
            return LastMeasuredSize;
        }
        public void HostCompleted()
        {
            //Kevin Carbis - Clear everything by simulating the click event on the parent item
            //just in case we are in a popup window
            OnClick(new MouseEventArgs(MouseButtons.Left, 1, Cursor.Position.X, Cursor.Position.Y, 0));
        }
        public virtual void OnSizeModeChanging(ref RibbonHostSizeModeHandledEventArgs e)
        {
            SizeModeChanging?.Invoke(this, e);
        }
        #endregion

        #region public variables
        public event MouseEventHandler ClientMouseMove;

        [Description("Occurs when the SizeMode of the Controls container is changing. if you manually set the size of the control you need to set the Handled flag to true.")]
        public event RibbonHostSizeModeHandledEventHandler SizeModeChanging;

        public Control HostedControl
        {
            get => _ctl;
            set
            {
                if (_ctl != null)
                {
                    _ctl.MouseMove -= DoCtlMouseMove;
                    CanvasChanged -= RibbonHost_CanvasChanged;
                    _ctlParent?.Controls?.Add(_ctl);
                    _ctl.Location = _ctlLocation;
                    _ctl.Size = _ctlSize;
                    _ctl.Visible = _ctlVisible;
                    _ctlParent = null;
                }
                _ctl = value;
                NotifyOwnerRegionsChanged();
                if ((_ctl == null) ||
                    (Site != null))
                {
                    return;
                }

                //changing the owner changes the font so let save it for future use
                _ctlParent = _ctl.Parent;
                _ctlFont = _ctl.Font;
                _ctlSize = _ctl.Size;
                _ctlLocation = _ctl.Location;
                _ctlVisible = _ctl.Visible;

                //hook into some needed events
                _ctl.MouseMove -= DoCtlMouseMove;
                _ctl.MouseMove += DoCtlMouseMove;
                CanvasChanged -= RibbonHost_CanvasChanged;
                CanvasChanged += RibbonHost_CanvasChanged;

                //we must know when our tab changes so we can hide the control
                if ((OwnerTab != null) &&
                    (Owner != null))
                {
                    Owner.ActiveTabChanged -= Owner_ActiveTabChanged;
                    Owner.ActiveTabChanged += Owner_ActiveTabChanged;
                }

                //the control must always have the same parent as the host item so set it here.
                Owner?.Controls?.Add(_ctl);
                _ctl.Font = _ctlFont;

                /*Initially set the control to be hidden. If it needs to be displayed immediately it will get set in the
                     * placecontrol function. This was located at the top of the function, however it caused the control 
                     * if located on a dropdown to not appear the correct size. A second showing fixed the issue. Seems to
                     * because the control is added to the ribbon while invisible??? */
                _ctl.Visible = false;
            }
        }
        #endregion

        #region public handler
        public delegate void RibbonHostSizeModeHandledEventHandler(object sender, RibbonHostSizeModeHandledEventArgs e);
        #endregion
    }
}
