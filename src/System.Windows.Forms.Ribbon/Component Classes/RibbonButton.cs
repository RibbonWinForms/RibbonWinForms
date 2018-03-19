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


using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Text.RegularExpressions;

namespace System.Windows.Forms
{
    [Designer(typeof(RibbonButtonDesigner))]
    public class RibbonButton : RibbonItem, IContainsRibbonComponents
    {
        #region Fields

        private const int arrowWidth = 5;
        private RibbonButtonStyle _style = RibbonButtonStyle.Normal;
        private Rectangle _dropDownBounds;
        private Rectangle _buttonFaceBounds;
        private RibbonItemCollection _dropDownItems;
        private bool _dropDownPressed;
        private bool _dropDownSelected;
        private Image _smallImage;
        private Image _flashSmallImage;
        private Size _dropDownArrowSize;
        private Padding _dropDownMargin;
        private bool _dropDownVisible;
        private RibbonDropDown _dropDown;
        private Rectangle _imageBounds;
        private Rectangle _textBounds;
        private bool _dropDownResizable;
        private bool _checkOnClick;
        private Point _lastMousePos;
        private RibbonArrowDirection _DropDownArrowDirection = RibbonArrowDirection.Down;
        private bool _iconsBar;

        //Kevin - Tracks the selected item when it has dropdownitems assigned
        private RibbonItem _selectedItem;

        private Set<RibbonItem> _assignedHandlers = new Set<RibbonItem>();

        private Size _MinimumSize;
        private Size _MaximumSize;

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the dropdown is about to be displayed
        /// </summary>
        public event EventHandler DropDownShowing;

        public event RibbonItemEventHandler DropDownItemClicked;
        public delegate void RibbonItemEventHandler(object sender, RibbonItemEventArgs e);

        public virtual void OnDropDownItemClicked(ref RibbonItemEventArgs e)
        {
            if (DropDownItemClicked != null)
            {
                DropDownItemClicked(this, e);
            }
        }

        #endregion

        #region Ctors

        /// <summary>
        /// Creates a new button
        /// </summary>
        /// <param name="image">Image of the button (32 x 32 suggested)</param>
        /// <param name="smallImage">Image of the button when in medium of compact mode (16 x 16 suggested)</param>
        /// <param name="style">Style of the button</param>
        /// <param name="text">Text of the button</param>
        public RibbonButton()
        {
            _dropDownItems = new RibbonItemCollection();
            _dropDownItems.SetOwnerItem(this);
            _dropDownArrowSize = new Size(5, 3);
            _dropDownMargin = new Padding(6);
            Image = CreateImage(32);
            SmallImage = CreateImage(16);
            _iconsBar = true;
        }

        public RibbonButton(string text)
            : this()
        {
            Text = text;
        }

        public RibbonButton(Image smallImage)
            : this()
        {
            SmallImage = smallImage;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && RibbonDesigner.Current == null)
            {
                RemoveHandlers();
                if (SmallImage != null)
                    SmallImage.Dispose();
                if (FlashSmallImage != null)
                    FlashSmallImage.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Props

        /// <summary>
        /// Gets the last DropDown Item that was clicked
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RibbonItem SelectedItem
        {
            get
            {
                if (_selectedItem == null)
                {
                    return null;
                }
                else
                {
                    if (_dropDownItems.Contains(_selectedItem))
                    {
                        return _selectedItem;
                    }
                    else
                    {
                        _selectedItem = null;
                        return null;
                    }
                }
            }

            set
            {
                if (value.GetType().BaseType == typeof(RibbonItem))
                {
                    if (_dropDownItems.Contains(value))
                    {
                        _selectedItem = value;
                    }
                    else
                    {
                        _dropDownItems.Add(value);
                        _selectedItem = value;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the value of selected item on the dropdown.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedValue
        {
            get
            {
                if (_selectedItem == null)
                {
                    return null;
                }
                else
                {
                    return _selectedItem.Value;
                }
            }
            set
            {
                foreach (RibbonItem item in DropDownItems)
                {
                    if (item.Value == value)
                    {
                        _selectedItem = item;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the DropDown of the button
        /// </summary>
        internal RibbonDropDown DropDown
        {
            get { return _dropDown; }
        }
  
        /// <summary>
        /// Gets or sets if the icon bar on a drop down should be drawn
        /// </summary>
        [Category("Drop Down")]
        [DefaultValue(true)]
        [Description("Gets or sets if the icon bar on a drop down should be drawn")]
        public bool DrawDropDownIconsBar
        {
            get { return _iconsBar; }
            set { _iconsBar = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating if the <see cref="Checked"/> property should be toggled
        /// when button is clicked
        /// </summary>
        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("Toggles the Checked property of the button when clicked")]
        public bool CheckOnClick
        {
            get { return _checkOnClick; }
            set { _checkOnClick = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating if the DropDown should be resizable
        /// </summary>
        [Category("Drop Down")]
        [DefaultValue(false)]
        [Description("Makes the DropDown resizable with a grip on the corner")]
        public bool DropDownResizable
        {
            get { return _dropDownResizable; }
            set { _dropDownResizable = value; }
        }

        /// <summary>
        /// Gets the bounds where the <see cref="Image"/> or <see cref="SmallImage"/> will be drawn.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle ImageBounds
        {
            get { return _imageBounds; }
        }

        /// <summary>
        /// Gets the bounds where the <see cref="Text"/> of the button will be drawn
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle TextBounds
        {
            get { return _textBounds; }
        }


        /// <summary>
        /// Gets if the DropDown is currently visible
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DropDownVisible
        {
            get { return _dropDownVisible; }
        }

        /// <summary>
        /// Gets or sets the size of the dropdown arrow
        /// </summary>
        [Browsable(false)]
        [DefaultValue(typeof(Size), "5, 3")]
        public Size DropDownArrowSize
        {
            get { return _dropDownArrowSize; }
            set { _dropDownArrowSize = value; NotifyOwnerRegionsChanged(); }
        }

        /// <summary>
        /// Gets or sets the direction where drop down's arrow should be pointing to
        /// </summary>
        [Category("Drop Down")]
        [DefaultValue(RibbonArrowDirection.Down)]
        public RibbonArrowDirection DropDownArrowDirection
        {
            get { return _DropDownArrowDirection; }
            set { _DropDownArrowDirection = value; NotifyOwnerRegionsChanged(); }
        }


        /// <summary>
        /// Gets the style of the button
        /// </summary>
        [DefaultValue(RibbonButtonStyle.Normal)]
        [Category("Appearance")]
        [Description("Indicates the visual style of the button.")]
        public RibbonButtonStyle Style
        {
            get
            {
                return _style;
            }
            set
            {
                _style = value;

                if (Canvas is RibbonPopup
                    || (OwnerItem != null && OwnerItem.Canvas is RibbonPopup))
                {
                    DropDownArrowDirection = RibbonArrowDirection.Left;
                }

                NotifyOwnerRegionsChanged();
            }
        }

        /// <summary>
        /// Gets the collection of items shown on the dropdown pop-up when Style allows it
        /// </summary>
        [Category("Drop Down")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RibbonItemCollection DropDownItems
        {
            get
            {
                return _dropDownItems;
            }
        }

        /// <summary>
        /// Gets the bounds of the button face
        /// </summary>
        /// <remarks>When Style is different from SplitDropDown and SplitBottomDropDown, ButtonFaceBounds is the same area than DropDownBounds</remarks>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Rectangle ButtonFaceBounds
        {
            get
            {
                return _buttonFaceBounds;
            }
        }

        /// <summary>
        /// Gets the bounds of the dropdown button
        /// </summary>
        /// <remarks>When Style is different from SplitDropDown and SplitBottomDropDown, ButtonFaceBounds is the same area than DropDownBounds</remarks>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Rectangle DropDownBounds
        {
            get
            {
                return _dropDownBounds;
            }
        }

        /// <summary>
        /// Gets if the dropdown part of the button is selected
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DropDownSelected
        {
            get
            {
                return _dropDownSelected;
            }
        }

        /// <summary>
        /// Gets if the dropdown part of the button is pressed
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DropDownPressed
        {
            get
            {
                return _dropDownPressed;
            }
        }

        /// <summary>
        /// Gets or sets the image of the button when in large size mode.
        /// </summary>
        [DefaultValue(null)]
        [Category("Appearance")]
        [Description("sets the image of the button when in large size mode.")]
        public virtual Image LargeImage
        {
            get
            {
                return base.Image;
            }
            set
            {
                base.Image = value;
            }
        }

        /// <summary>
        /// Gets or sets the image of the button when in large size mode.
        /// </summary>
        [Browsable(false)]
        [Category("Appearance")]
        public override Image Image
        {
            get
            {
                return base.Image;
            }
            set
            {
                base.Image = value;
            }
        }

        /// <summary>
        /// Gets or sets the image of the button when in compact, medium or dropdown size modes
        /// </summary>
        [DefaultValue(null)]
        [Category("Appearance")]
        [Description("sets the image of the button when in compact, medium or dropdown size modes.")]
        public virtual Image SmallImage
        {
            get
            {
                return _smallImage;
            }
            set
            {
                if (_smallImage != value)
                {
                    _smallImage = value;

                    NotifyOwnerRegionsChanged();
                }
            }
        }

        [Category("Flash")]
        [DefaultValue(null)]
        public virtual Image FlashSmallImage
        {
            get
            {
                return _flashSmallImage;
            }
            set
            {
                if (_flashSmallImage != value)
                {
                    _flashSmallImage = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the minimum size for this Item.  Only applies when in Large Size Mode.
        /// </summary>
        [DefaultValue(typeof(Size), "0, 0")]
        [Category("Appearance")]
        [Description("Sets the minimum size for this Item.  Only applies when in Large Size Mode.")]
        public Size MinimumSize
        {
            get { return _MinimumSize; }
            set { _MinimumSize = value; NotifyOwnerRegionsChanged(); }

        }

        /// <summary>
        /// Gets or sets the maximum size for this Item.  Only applies when in Large Size Mode.
        /// </summary>
        [DefaultValue(typeof(Size), "0, 0")]
        [Category("Appearance")]
        [Description("Sets the maximum size for this Item.  Only applies when in Large Size Mode.")]
        public Size MaximumSize
        {
            get { return _MaximumSize; }
            set { _MaximumSize = value; NotifyOwnerRegionsChanged(); }

        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the value of the <see cref="DropDownMargin"/> property
        /// </summary>
        /// <param name="p"></param>
        protected void SetDropDownMargin(Padding p)
        {
            _dropDownMargin = p;
        }

        /// <summary>
        /// Performs a click on the button
        /// </summary>
        public void PerformClick()
        {
            OnClick(EventArgs.Empty);
        }

        /// <summary>
        /// Creates a new Transparent, empty image
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private Image CreateImage(int size)
        {
            Bitmap bmp = new Bitmap(size, size);

            //using (Graphics g = Graphics.FromImage(bmp))
            //{
            //    g.Clear(Color.FromArgb(50, Color.Navy));
            //}

            return bmp;
        }

        /// <summary>
        /// Creates the DropDown menu
        /// </summary>
        protected virtual void CreateDropDown()
        {
            _dropDown = new RibbonDropDown(this, DropDownItems, Owner);
        }

        internal override void SetPressed(bool pressed)
        {
            base.SetPressed(pressed);
        }

        internal override void SetOwner(Ribbon owner)
        {
            base.SetOwner(owner);

            if (_dropDownItems != null) _dropDownItems.SetOwner(owner);
        }

        internal override void SetOwnerPanel(RibbonPanel ownerPanel)
        {
            base.SetOwnerPanel(ownerPanel);

            if (_dropDownItems != null) _dropDownItems.SetOwnerPanel(ownerPanel);
        }

        internal override void SetOwnerTab(RibbonTab ownerTab)
        {
            base.SetOwnerTab(ownerTab);

            if (_dropDownItems != null) _dropDownItems.SetOwnerTab(ownerTab);
        }

        internal override void SetOwnerItem(RibbonItem ownerItem)
        {
            base.SetOwnerItem(ownerItem);
        }

        internal override void ClearOwner()
        {
           List<RibbonItem> oldItems = _dropDownItems == null ? null : new List<RibbonItem>(_dropDownItems);

           base.ClearOwner();

           if (oldItems != null)
           {
              foreach (RibbonItem item in oldItems)
              {
                 item.ClearOwner();
              }
           }
        }

        /// <summary>
        /// Raises the Paint event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void OnPaint(object sender, RibbonElementPaintEventArgs e)
        {
            if (Owner == null) return;

            OnPaintBackground(e);

            OnPaintImage(e);

            OnPaintText(e);

        }

        /// <summary>
        /// Renders text of the button
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPaintText(RibbonElementPaintEventArgs e)
        {
            if (SizeMode != RibbonElementSizeMode.Compact)
            {
                StringFormat sf = StringFormatFactory.NearCenter();

                if (this.Owner.AltPressed || this.Owner.OrbDropDown.MenuItems.Contains(this))
                {
                    
                    sf.HotkeyPrefix = Drawing.Text.HotkeyPrefix.Show;

                }
                else
                {

                    sf.HotkeyPrefix = Drawing.Text.HotkeyPrefix.Hide;
                }

                if (SizeMode == RibbonElementSizeMode.Large)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Near;
                }

                if (Style == RibbonButtonStyle.DropDownListItem)
                {
                    sf.LineAlignment = StringAlignment.Near;
                    Owner.Renderer.OnRenderRibbonItemText(
                        new RibbonTextEventArgs(Owner, e.Graphics, e.Clip, this, Bounds, Text, sf));
                }
                else
                {
                    var newText = Text;

                    if (!String.IsNullOrEmpty(this.AltKey) && this.Text.Contains(AltKey))
                    {

                        var regex = new Regex(Regex.Escape(this.AltKey), RegexOptions.IgnoreCase);

                        newText = regex.Replace(this.Text.Replace("&", ""), "&" + this.AltKey, 1).Replace("&&", "&");
                    }

                    Owner.Renderer.OnRenderRibbonItemText(
                        new RibbonTextEventArgs(Owner, e.Graphics, e.Clip, this, TextBounds, newText, sf));
                }
            }
        }

        /// <summary>
        /// Renders the image of the button
        /// </summary>
        /// <param name="e"></param>
        private void OnPaintImage(RibbonElementPaintEventArgs e)
        {
            RibbonElementSizeMode theSize = GetNearestSize(e.Mode);

            if (_showFlashImage)
            {
                if ((theSize == RibbonElementSizeMode.Large && FlashImage != null) || FlashSmallImage != null)
                {
                    Owner.Renderer.OnRenderRibbonItemImage(
                        new RibbonItemBoundsEventArgs(Owner, e.Graphics, e.Clip, this, OnGetImageBounds(theSize, Bounds)));
                }
            }
            else
            {
                if ((theSize == RibbonElementSizeMode.Large && Image != null) || SmallImage != null)
                {
                    Owner.Renderer.OnRenderRibbonItemImage(
                        new RibbonItemBoundsEventArgs(Owner, e.Graphics, e.Clip, this, OnGetImageBounds(theSize, Bounds)));
                }
            }
        }

        /// <summary>
        /// Renders the background of the buton
        /// </summary>
        /// <param name="e"></param>
        private void OnPaintBackground(RibbonElementPaintEventArgs e)
        {
            Owner.Renderer.OnRenderRibbonItem(new RibbonItemRenderEventArgs(Owner, e.Graphics, e.Clip, this));
        }

        /// <summary>
        /// Sets the bounds of the button
        /// </summary>
        /// <param name="bounds"></param>
        public override void SetBounds(System.Drawing.Rectangle bounds)
        {
            base.SetBounds(bounds);

            RibbonElementSizeMode sMode = GetNearestSize(SizeMode);

            _imageBounds = OnGetImageBounds(sMode, bounds);

            _textBounds = OnGetTextBounds(sMode, bounds);

            if (Style == RibbonButtonStyle.SplitDropDown)
            {
                _dropDownBounds = OnGetDropDownBounds(sMode, bounds);
                _buttonFaceBounds = OnGetButtonFaceBounds(sMode, bounds);
            }
        }

        /// <summary>
        /// Sets the bounds of the image of the button when SetBounds is called.
        /// Override this method to change image bounds
        /// </summary>
        /// <param name="sMode">Mode which is being measured</param>
        /// <param name="bounds">Bounds of the button</param>
        /// <remarks>
        /// The measuring occours in the following order:
        /// <list type="">
        /// <item>OnSetImageBounds</item>
        /// <item>OnSetTextBounds</item>
        /// <item>OnSetDropDownBounds</item>
        /// <item>OnSetButtonFaceBounds</item>
        /// </list>
        /// </remarks>
        internal virtual Rectangle OnGetImageBounds(RibbonElementSizeMode sMode, Rectangle bounds)
        {
            if (sMode == RibbonElementSizeMode.Large)// || this is RibbonOrbMenuItem)
            {
                if (Image != null)
                {
                    return new Rectangle(
                    Bounds.Left + ((Bounds.Width - Image.Width) / 2),
                    Bounds.Top + Owner.ItemMargin.Top,
                    Image.Width,
                    Image.Height);
                }
                else
                {
                    return new Rectangle(ContentBounds.Location, new Size(32, 32));
                }
            }
            else
            {
                if (SmallImage != null)
                {
                    if (SmallImage.PixelFormat != Drawing.Imaging.PixelFormat.DontCare )
                    {
                        return new Rectangle(
                            Bounds.Left + Owner.ItemMargin.Left,
                            Bounds.Top + ((Bounds.Height - SmallImage.Height) / 2),
                            SmallImage.Width,
                            SmallImage.Height);
                    }
                }
                return new Rectangle(ContentBounds.Location, new Size(0, 0));
            }
        }

        /// <summary>
        /// Sets the bounds of the text of the button when SetBounds is called.
        /// Override this method to change image bounds
        /// </summary>
        /// <param name="sMode">Mode which is being measured</param>
        /// <param name="bounds">Bounds of the button</param>
        /// <remarks>
        /// The measuring occours in the following order:
        /// <list type="">
        /// <item>OnSetImageBounds</item>
        /// <item>OnSetTextBounds</item>
        /// <item>OnSetDropDownBounds</item>
        /// <item>OnSetButtonFaceBounds</item>
        /// </list>
        /// </remarks>
        internal virtual Rectangle OnGetTextBounds(RibbonElementSizeMode sMode, Rectangle bounds)
        {
            int imgw = _imageBounds.Width;
            int imgh = _imageBounds.Height;

            if (sMode == RibbonElementSizeMode.Large)
            {
                return Rectangle.FromLTRB(
                    Bounds.Left + Owner.ItemMargin.Left,
                    Bounds.Top + Owner.ItemMargin.Top + imgh,
                    Bounds.Right - Owner.ItemMargin.Right,
                    Bounds.Bottom - Owner.ItemMargin.Bottom);
            }
            else
            {
                // ddw is the dropdown arrow width
                int ddw = (Style == RibbonButtonStyle.Normal || Style == RibbonButtonStyle.DropDownListItem) ? 0 : _dropDownMargin.Horizontal;
                int imageToTextSpacing = (sMode == RibbonElementSizeMode.DropDown) ? Owner.ItemImageToTextSpacing : 0;
                
                return Rectangle.FromLTRB(
                Bounds.Left + imgw + Owner.ItemMargin.Horizontal + Owner.ItemMargin.Left + imageToTextSpacing,
                Bounds.Top + Owner.ItemMargin.Top,
                Bounds.Right - ddw,
                Bounds.Bottom - Owner.ItemMargin.Bottom);
            }
        }

        /// <summary>
        /// Sets the bounds of the dropdown part of the button when SetBounds is called.
        /// Override this method to change image bounds
        /// </summary>
        /// <param name="sMode">Mode which is being measured</param>
        /// <param name="bounds">Bounds of the button</param>
        /// <remarks>
        /// The measuring occours in the following order:
        /// <list type="">
        /// <item>OnSetImageBounds</item>
        /// <item>OnSetTextBounds</item>
        /// <item>OnSetDropDownBounds</item>
        /// <item>OnSetButtonFaceBounds</item>
        /// </list>
        /// </remarks>
        internal virtual Rectangle OnGetDropDownBounds(RibbonElementSizeMode sMode, Rectangle bounds)
        {
            Rectangle sideBounds = Rectangle.FromLTRB(
                    bounds.Right - _dropDownMargin.Horizontal - 2,
                    bounds.Top, bounds.Right, bounds.Bottom);

            switch (sMode)
            {
                case RibbonElementSizeMode.Large:
                case RibbonElementSizeMode.Overflow:
                    return Rectangle.FromLTRB(bounds.Left,
                        bounds.Top + Image.Height + Owner.ItemMargin.Vertical,
                        bounds.Right, bounds.Bottom);

                case RibbonElementSizeMode.DropDown:
                case RibbonElementSizeMode.Medium:
                case RibbonElementSizeMode.Compact:
                    return sideBounds;
            }


            return Rectangle.Empty;
        }

        /// <summary>
        /// Sets the bounds of the button face part of the button when SetBounds is called.
        /// Override this method to change image bounds
        /// </summary>
        /// <param name="sMode">Mode which is being measured</param>
        /// <param name="bounds">Bounds of the button</param>
        /// <remarks>
        /// The measuring occours in the following order:
        /// <list type="">
        /// <item>OnSetImageBounds</item>
        /// <item>OnSetTextBounds</item>
        /// <item>OnSetDropDownBounds</item>
        /// <item>OnSetButtonFaceBounds</item>
        /// </list>
        /// </remarks>
        internal virtual Rectangle OnGetButtonFaceBounds(RibbonElementSizeMode sMode, Rectangle bounds)
        {

            Rectangle sideBounds = Rectangle.FromLTRB(
                bounds.Right - _dropDownMargin.Horizontal - 2,
                bounds.Top, bounds.Right, bounds.Bottom);

            switch (sMode)
            {
                case RibbonElementSizeMode.Large:
                case RibbonElementSizeMode.Overflow:
                    return Rectangle.FromLTRB(bounds.Left,
                        bounds.Top, bounds.Right, _dropDownBounds.Top);

                case RibbonElementSizeMode.DropDown:
                case RibbonElementSizeMode.Medium:
                case RibbonElementSizeMode.Compact:
                    return Rectangle.FromLTRB(bounds.Left, bounds.Top,
                        _dropDownBounds.Left, bounds.Bottom);

            }


            return Rectangle.Empty;
        }

        /// <summary>
        /// Measures the string for the large size
        /// </summary>
        /// <param name="g"></param>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <returns></returns>
        public static Size MeasureStringLargeSize(Graphics g, string text, Font font)
        {
            if (string.IsNullOrEmpty(text))
            {
                return Size.Empty;
            }

            Size sz = g.MeasureString(text, font).ToSize();
            string[] words = text.Split(' ');
            string longestWord = string.Empty;
            int width = sz.Width;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > longestWord.Length)
                {
                    longestWord = words[i];
                }
            }

            if (words.Length > 1)
            {
                width = Math.Max(sz.Width / 2, g.MeasureString(longestWord, font).ToSize().Width) + 1;
            }
            else
            {
                return g.MeasureString(text, font).ToSize();
            }

            Size rs = g.MeasureString(text, font, width).ToSize();

            return new Size(rs.Width, rs.Height);
        }

        /// <summary>
        /// Measures the size of the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public override Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
        {
            if (!Visible && !Owner.IsDesignMode())
            {
                SetLastMeasuredSize(new Size(0, 0));
                return LastMeasuredSize;
            }

            RibbonElementSizeMode theSize = GetNearestSize(e.SizeMode);
            int widthSum = Owner.ItemMargin.Horizontal;
            int heightSum = Owner.ItemMargin.Vertical;
            int largeHeight = OwnerPanel == null ? 0 : OwnerPanel.ContentBounds.Height - Owner.ItemPadding.Vertical;// -Owner.ItemMargin.Vertical; //58;

            Size simg = SmallImage != null ? SmallImage.Size : Size.Empty;
            Size img = Image != null ? Image.Size : Size.Empty;
            Size sz = Size.Empty;

            switch (theSize)
            {
                case RibbonElementSizeMode.Large:
                case RibbonElementSizeMode.Overflow:
                    sz = MeasureStringLargeSize(e.Graphics, Text, Owner.Font);
                    if (!string.IsNullOrEmpty(Text))
                    {
                        widthSum += Math.Max(sz.Width + 1, img.Width);
                        //Got off the patch site from logicalerror
                        //heightSum = largeHeight;
                        heightSum = Math.Max(0, largeHeight);
                    }
                    else
                    {
                        widthSum += img.Width;
                        heightSum += img.Height;
                    }

                    break;
                case RibbonElementSizeMode.DropDown:
                    sz = Size.Ceiling(e.Graphics.MeasureString(Text, Owner.Font));
                    if (!string.IsNullOrEmpty(Text)) widthSum += sz.Width + 1;
                    widthSum += simg.Width + Owner.ItemMargin.Horizontal + Owner.ItemImageToTextSpacing;
                    heightSum += Math.Max(sz.Height, simg.Height);
                    break;
                case RibbonElementSizeMode.Medium:
                    sz = Size.Ceiling(e.Graphics.MeasureString(Text, Owner.Font));
                    if (!string.IsNullOrEmpty(Text)) widthSum += sz.Width + 1;
                    widthSum += simg.Width + Owner.ItemMargin.Horizontal;
                    heightSum += Math.Max(sz.Height, simg.Height);
                    break;
                case RibbonElementSizeMode.Compact:
                    widthSum += simg.Width;
                    heightSum += simg.Height;
                    break;
                default:
                    throw new ApplicationException("SizeMode not supported: " + e.SizeMode.ToString());
            }

            //if (theSize == RibbonElementSizeMode.DropDown)
            //{
            //   heightSum += 2;
            //}
            switch (Style)
            {
                case RibbonButtonStyle.DropDown:
                case RibbonButtonStyle.SplitDropDown:  // drawing size calculation for DropDown and SplitDropDown is identical
                    widthSum += arrowWidth + _dropDownMargin.Horizontal;
                    break;
                case RibbonButtonStyle.DropDownListItem:
                    break;
            }

            //check the minimum and mazimum size properties but only in large mode
            if (theSize == RibbonElementSizeMode.Large)
            {
                //Minimum Size
                if (MinimumSize.Height > 0 && heightSum < MinimumSize.Height)
                    heightSum = MinimumSize.Height;
                if (MinimumSize.Width > 0 && widthSum < MinimumSize.Width)
                    widthSum = MinimumSize.Width;

                //Maximum Size
                if (MaximumSize.Height > 0 && heightSum > MaximumSize.Height)
                    heightSum = MaximumSize.Height;
                if (MaximumSize.Width > 0 && widthSum > MaximumSize.Width)
                    widthSum = MaximumSize.Width;
            }

            SetLastMeasuredSize(new Size(widthSum, heightSum));

            return LastMeasuredSize;
        }

        /// <summary>
        /// Sets the value of the DropDownPressed property
        /// </summary>
        /// <param name="pressed">Value that indicates if the dropdown button is pressed</param>
        internal void SetDropDownPressed(bool pressed)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Sets the value of the DropDownSelected property
        /// </summary>
        /// <param name="selected">Value that indicates if the dropdown part of the button is selected</param>
        internal void SetDropDownSelected(bool selected)
        {
            //Dont use, an overflow occours
            throw new Exception();
        }

        /// <summary>
        /// Shows the drop down items of the button, as if the dropdown part has been clicked
        /// </summary>
        public void ShowDropDown()
        {
            if (Style == RibbonButtonStyle.Normal)
            {
                if (DropDown != null)
                    RibbonPopupManager.DismissChildren(DropDown, RibbonPopupManager.DismissReason.NewPopup);
                return;
            }

            if (Style == RibbonButtonStyle.DropDown)
            {
                SetPressed(true);
            }
            else
            {
                _dropDownPressed = true;
            }
            OnDropDownShowing(EventArgs.Empty);
            if (DropDownItems.Count == 0)
            {
               if (DropDown != null)
                  RibbonPopupManager.DismissChildren(DropDown, RibbonPopupManager.DismissReason.NewPopup);
               return;
            }
            AssignHandlers();

            CreateDropDown();
            DropDown.MouseEnter += new EventHandler(DropDown_MouseEnter);
            DropDown.Closed += new EventHandler(DropDown_Closed);
            DropDown.ShowSizingGrip = DropDownResizable;
            DropDown.DrawIconsBar = DrawDropDownIconsBar;

            RibbonPopup canvasdd = Canvas as RibbonPopup;
            Point location = OnGetDropDownMenuLocation();
            Size minsize = OnGetDropDownMenuSize();

            if (!minsize.IsEmpty) DropDown.MinimumSize = minsize;

            SetDropDownVisible(true);
            DropDown.SelectionService = GetService(typeof(ISelectionService)) as ISelectionService;
            DropDown.Show(location);
        }

        void DropDownItem_Click(object sender, EventArgs e)
        {
            _selectedItem = (sender as RibbonItem);

            RibbonItemEventArgs ev = new RibbonItemEventArgs(sender as RibbonItem);
            OnDropDownItemClicked(ref ev);
        }

        private void AssignHandlers()
        {
            foreach (RibbonItem item in DropDownItems)
            {
                if (_assignedHandlers.Contains(item) == false)
                {
                    item.Click += new EventHandler(DropDownItem_Click);
                    _assignedHandlers.Add(item);
                }
            }
        }

        private void RemoveHandlers()
        {
            // ADDED
            if (DropDown != null)
            {
                DropDown.MouseEnter -= DropDown_MouseEnter;
                DropDown.Closed -= DropDown_Closed;
            }

            foreach (RibbonItem item in _assignedHandlers)
            {
                item.Click -= DropDownItem_Click;
            }
            _assignedHandlers.Clear();
        }

        void DropDown_MouseEnter(object sender, EventArgs e)
        {
            SetSelected(true);
            RedrawItem();
        }

        /// <summary>
        /// Gets the location where the dropdown menu will be shown
        /// </summary>
        /// <returns></returns>
        internal virtual Point OnGetDropDownMenuLocation()
        {

            Point location = Point.Empty;

            if (Canvas is RibbonDropDown)
            {
                location = Canvas.PointToScreen(new Point(Bounds.Right, Bounds.Top));
            }
            else
            {
                location = Canvas.PointToScreen(new Point(Bounds.Left, Bounds.Bottom));
            }

            return location;
        }

        /// <summary>
        /// Gets the size of the dropdown. If Size.Empty is returned, 
        /// size will be measured automatically
        /// </summary>
        /// <returns></returns>
        internal virtual Size OnGetDropDownMenuSize()
        {
            return Size.Empty;
        }

        /// <summary>
        /// Handles the closing of the dropdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DropDown_Closed(object sender, EventArgs e)
        {
            SetPressed(false);

            _dropDownPressed = false;

            SetDropDownVisible(false);

            SetSelected(false);
            _dropDownSelected = false;

            RedrawItem();
        }

        /// <summary>
        /// Ignores deactivation of canvas if it is a volatile window
        /// </summary>
        private void IgnoreDeactivation()
        {
            if (Canvas is RibbonPanelPopup)
            {
                (Canvas as RibbonPanelPopup).IgnoreNextClickDeactivation();
            }

            if (Canvas is RibbonDropDown)
            {
                (Canvas as RibbonDropDown).IgnoreNextClickDeactivation();
            }
        }

        /// <summary>
        /// Closes the DropDown if opened
        /// </summary>
        public void CloseDropDown()
        {
            if (DropDown != null)
            {
                RibbonPopupManager.Dismiss(DropDown, RibbonPopupManager.DismissReason.NewPopup);
                RemoveHandlers();
                _dropDown = null;
            }

            SetDropDownVisible(false);
        }

        /// <summary>
        /// Overriden. Informs the button text
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{1}: {0}", Text, GetType().Name);
        }

        /// <summary>
        /// Sets the value of DropDownVisible
        /// </summary>
        /// <param name="visible"></param>
        internal void SetDropDownVisible(bool visible)
        {
            _dropDownVisible = visible;
        }

        /// <summary>
        /// Raises the DropDownShowing event
        /// </summary>
        /// <param name="e"></param>
        public void OnDropDownShowing(EventArgs e)
        {
            if (DropDownShowing != null)
            {
                DropDownShowing(this, e);
            }
        }

        #endregion

        #region Overrides

        public override void OnCanvasChanged(EventArgs e)
        {
            base.OnCanvasChanged(e);

            if (Canvas is RibbonDropDown)
            {
                DropDownArrowDirection = RibbonArrowDirection.Left;
            }
        }

        protected override bool ClosesDropDownAt(Point p)
        {
            if (Style == RibbonButtonStyle.DropDown)
            {
                return false;
            }
            else if (Style == RibbonButtonStyle.SplitDropDown)
            {
                return ButtonFaceBounds.Contains(p);
            }
            else
            {
                return true;
            }
        }

        internal override void SetSizeMode(RibbonElementSizeMode sizeMode)
        {


            if (sizeMode == RibbonElementSizeMode.Overflow)
            {
                base.SetSizeMode(RibbonElementSizeMode.Large);
            }
            else
            {
                base.SetSizeMode(sizeMode);
            }
        }

        internal override void SetSelected(bool selected)
        {
            base.SetSelected(selected);

            SetPressed(false);
        }

        public override void OnMouseDown(MouseEventArgs e)
        {
            if (!Enabled) return;

            if ((DropDownSelected || Style == RibbonButtonStyle.DropDown) && DropDownItems.Count > 0)
            {
                if (DropDownVisible == false)
                {
                    _dropDownPressed = true;
                    ShowDropDown();
                }
                else
                {
                    //Hack: Workaround to close DropDown if it stays open....
                    _dropDownPressed = false;
                    CloseDropDown();
                }
            }

            base.OnMouseDown(e);
        }

        public override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
        }

        public override void OnMouseMove(MouseEventArgs e)
        {
            if (!Enabled) return;

            //Detect mouse on dropdwon
            if (Style == RibbonButtonStyle.SplitDropDown)
            {
                bool lastState = _dropDownSelected;

                if (DropDownBounds.Contains(e.X, e.Y))
                {
                    _dropDownSelected = true;
                }
                else
                {
                    _dropDownSelected = false;
                }

                if (lastState != _dropDownSelected)
                    RedrawItem();

                lastState = _dropDownSelected;
            }

            _lastMousePos = new Point(e.X, e.Y);

            base.OnMouseMove(e);
        }

        public override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);

            _dropDownSelected = false;

        }

        public override void OnClick(EventArgs e)
        {
            if (Style != RibbonButtonStyle.Normal && Style != RibbonButtonStyle.DropDownListItem && !ButtonFaceBounds.Contains(_lastMousePos))
            {
                //Clicked the dropdown area, don't raise Click()
                return;
            }

            if (CheckOnClick)
                Checked = !Checked;

            base.OnClick(e);
        }

        #endregion

        #region IContainsRibbonItems Members

        public IEnumerable<RibbonItem> GetItems()
        {
            return DropDownItems;
        }

        #endregion

        #region IContainsRibbonComponents Members

        public IEnumerable<Component> GetAllChildComponents()
        {
            return DropDownItems.ToArray();
        }

        #endregion
    }
}
