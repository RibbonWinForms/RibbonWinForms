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
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;

namespace System.Windows.Forms
{
   [ToolboxItem(false)]
   public partial class RibbonDropDown
       : RibbonPopup, IScrollableRibbonItem
   {
      #region Static

      //private static List<RibbonDropDown> registeredDds = new List<RibbonDropDown>();

      //private static void RegisterDropDown(RibbonDropDown dropDown)
      //{
      //    registeredDds.Add(dropDown);
      //}

      //private static void UnregisterDropDown(RibbonDropDown dropDown)
      //{
      //    registeredDds.Remove(dropDown);
      //}

      //internal static void DismissAll()
      //{
      //    for (int i = 0; i < registeredDds.Count; i++)
      //    {

      //        registeredDds[i].Close();
      //    }

      //    registeredDds.Clear();
      //}

      ///// <summary>
      ///// Closes all the dropdowns before the specified dropDown
      ///// </summary>
      ///// <param name="dropDown"></param>
      //internal static void DismissTo(RibbonDropDown dropDown)
      //{
      //    if (dropDown == null) throw new ArgumentNullException("dropDown");

      //    for (int i = registeredDds.Count - 1; i >= 0; i--)
      //    {
      //        if (i >= registeredDds.Count)
      //        {
      //            break;
      //        }

      //        if (registeredDds[i].Equals(dropDown))
      //        {
      //            break;
      //        }
      //        else
      //        {
      //            registeredDds[i].Close();
      //        }
      //    }
      //}

      #endregion

      #region Fields
      private IEnumerable<RibbonItem> _items; 
      private bool _showSizingGrip;
      private int _sizingGripHeight;
      private Ribbon _ownerRibbon;
      private RibbonMouseSensor _sensor;
      private RibbonItem _parentItem;
      private bool _ignoreNext;
      private RibbonElementSizeMode _MeasuringSize;
      private bool _resizing;
      private Rectangle _sizingGripBounds;
      private Point _resizeOrigin;
      private Size _resizeSize;
      private ISelectionService _SelectionService;
      private bool _iconsBar;

      //scroll properties
      private Rectangle _thumbBounds;
      private Rectangle _buttonUpBounds;
      private Rectangle _buttonDownBounds;
      private Rectangle _contentBounds;
      private Rectangle _fullContentBounds;
      private bool _thumbSelected;
      private bool _thumbPressed;
      private bool _buttonDownSelected;
      private bool _buttonDownPressed;
      private bool _buttonUpSelected;
      private bool _buttonUpPressed;
      private bool _buttonUpEnabled;
      private bool _buttonDownEnabled;
      private int _scrollValue;
      private bool _scrollBarEnabled;
      private bool _avoidNextThumbMeasure;
      private int _jumpDownSize;
      private int _jumpUpSize;
      private int _offset;
      private int _thumbOffset;
      private int _scrollBarSize;
      private int _maxHeight = 0;
      #endregion

      #region Ctor

      private RibbonDropDown()
      {
         //RegisterDropDown(this);
         DoubleBuffered = true;
         DrawIconsBar = true;
      }

      internal RibbonDropDown(RibbonItem parentItem, IEnumerable<RibbonItem> items, Ribbon ownerRibbon)
         : this(parentItem, items, ownerRibbon, RibbonElementSizeMode.DropDown)
      {
      }

      internal RibbonDropDown(RibbonItem parentItem, IEnumerable<RibbonItem> items, Ribbon ownerRibbon, RibbonElementSizeMode measuringSize)
         : this()
      {
         _items = items;
         _ownerRibbon = ownerRibbon;
         _sizingGripHeight = 12;
         _parentItem = parentItem;
         _sensor = new RibbonMouseSensor(this, OwnerRibbon, items);
         _MeasuringSize = measuringSize;
         _scrollBarSize = 16;

         if (Items != null)
            foreach (RibbonItem item in Items)
            {
               item.SetSizeMode(RibbonElementSizeMode.DropDown);
               item.SetCanvas(this);

                //If item is a RibbonHost, the MouseSensor will not detect the mouse move event, so manually hook into the event.
               if (item is RibbonHost)
               {
                   ((RibbonHost)item).ClientMouseMove += new MouseEventHandler(OnRibbonHostMouseMove);
               }
            }

         UpdateSize();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Sets the maximum height in pixels for the dropdown window. Enter 0 for autosize. If the contents is larger than the window scrollbars will be shown.
      /// </summary>
      public int DropDownMaxHeight
      {
         get { return _maxHeight; }
         set { _maxHeight = value; }
      }
      /// <summary>
      /// Gets or sets the width of the scrollbar
      /// </summary>
      public int ScrollBarSize
      {
         get
         {
            return _scrollBarSize;
         }
         set
         {
            _scrollBarSize = value;
         }
      }
      /// <summary>
      /// Gets the control where the item is currently being drawn
      /// </summary>
      [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public Control Canvas
      {
         get
         {
            return this;
         }
      }
      [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public Rectangle ScrollBarBounds
      {
         get
         {
            return Rectangle.FromLTRB(ButtonUpBounds.Left, ButtonUpBounds.Top, ButtonDownBounds.Right, ButtonDownBounds.Bottom);
         }
      }
      [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public bool ScrollBarEnabled
      {
         get { return _scrollBarEnabled; }
      }
      /// <summary>
      /// Gets the percent of scrolled content
      /// </summary>
      [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public double ScrolledPercent
      {
         get
         {
            if ((double)_fullContentBounds.Height > (double)ContentBounds.Height)
               return ((double)ContentBounds.Top - (double)_fullContentBounds.Top) /
                   ((double)_fullContentBounds.Height - (double)ContentBounds.Height);
            else
               return 0.0;
         }
         set
         {
            _avoidNextThumbMeasure = true;
            ScrollTo(-Convert.ToInt32((double)(_fullContentBounds.Height - ContentBounds.Height) * value));
         }
      }
      [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public int ScrollMinimum
      {
         get
         {
            return ButtonUpBounds.Bottom;
         }
      }
      [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public int ScrollMaximum
      {
         get
         {
            return ButtonDownBounds.Top - ThumbBounds.Height;
         }
      }
      [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public int ScrollValue
      {
         get { return _scrollValue; }
         set
         {
            if (value > ScrollMaximum || value < ScrollMinimum)
            {
               throw new IndexOutOfRangeException("Scroll value must exist between ScrollMinimum and Scroll Maximum");
            }

            _thumbBounds.Y = value;

            double scrolledPixels = value - ScrollMinimum;
            double pixelsAvailable = ScrollMaximum - ScrollMinimum;

            ScrolledPercent = scrolledPixels / pixelsAvailable;

            _scrollValue = value;
         }
      }
      /// <summary>
      /// Redraws the scroll part of the list
      /// </summary>
      private void RedrawScroll()
      {
         if (Canvas != null)
            Canvas.Invalidate(Rectangle.FromLTRB(ButtonDownBounds.X, ButtonUpBounds.Y, ButtonDownBounds.Right, ButtonDownBounds.Bottom));
      }
      /// <summary>
      /// Gets if the scrollbar thumb is currently selected
      /// </summary>
      [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public bool ThumbSelected
      {
         get { return _thumbSelected; }
      }
      /// <summary>
      /// Gets if the scrollbar thumb is currently pressed
      /// </summary>
      [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public bool ThumbPressed
      {
         get { return _thumbPressed; }
      }
      /// <summary>
      /// Gets the bounds of the scrollbar thumb
      /// </summary>
      [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public Rectangle ThumbBounds
      {
         get
         {
            return _thumbBounds;
         }
      }
      /// <summary>
      /// Gets a value indicating if the button that scrolls up the content is currently enabled
      /// </summary>
      [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public bool ButtonUpEnabled
      {
         get { return _buttonUpEnabled; }
      }
      /// <summary>
      /// Gets a value indicating if the button that scrolls down the content is currently enabled
      /// </summary>
      [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public bool ButtonDownEnabled
      {
         get { return _buttonDownEnabled; }
      }
      /// <summary>
      /// Gets a vaule indicating if the button that scrolls down the content is currently selected
      /// </summary>
      [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public bool ButtonDownSelected
      {
         get { return _buttonDownSelected; }
      }
      /// <summary>
      /// Gets a vaule indicating if the button that scrolls down the content is currently pressed
      /// </summary>
      [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public bool ButtonDownPressed
      {
         get { return _buttonDownPressed; }
      }
      /// <summary>
      /// Gets a vaule indicating if the button that scrolls up the content is currently selected
      /// </summary>
      [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public bool ButtonUpSelected
      {
         get { return _buttonUpSelected; }
      }
      /// <summary>
      /// Gets the bounds of the content where items are shown
      /// </summary>
      [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public Rectangle ContentBounds
      {
         get { return _contentBounds; }
      }
      /// <summary>
      /// Gets a vaule indicating if the button that scrolls up the content is currently pressed
      /// </summary>
      [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public bool ButtonUpPressed
      {
         get { return _buttonUpPressed; }
      }
      /// <summary>
      /// Gets the bounds of the button that scrolls the items up
      /// </summary>
      [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public Rectangle ButtonUpBounds
      {
         get { return _buttonUpBounds; }
      }
      /// <summary>
      /// Gets the bounds of the button that scrolls the items down
      /// </summary>
      [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public Rectangle ButtonDownBounds
      {
         get { return _buttonDownBounds; }
      }
      /// <summary>
      /// Gets or sets if the icons bar should be drawn
      /// </summary>
      public bool DrawIconsBar
      {
         get { return _iconsBar; }
         set { _iconsBar = value; }
      }
      /// <summary>
      /// Gets or sets the selection service for the dropdown
      /// </summary>
      internal ISelectionService SelectionService
      {
         get { return _SelectionService; }
         set { _SelectionService = value; }
      }
      /// <summary>
      /// Gets the bounds of the sizing grip
      /// </summary>
      public Rectangle SizingGripBounds
      {
         get { return _sizingGripBounds; }
      }
      /// <summary>
      /// Gets or sets the size for measuring items (by default is DropDown)
      /// </summary>
      public RibbonElementSizeMode MeasuringSize
      {
         get { return _MeasuringSize; }
         set { _MeasuringSize = value; }
      }
      /// <summary>
      /// Gets the parent item of this dropdown
      /// </summary>
      public RibbonItem ParentItem
      {
         get { return _parentItem; }
      }
      /// <summary>
      /// Gets the sennsor of this dropdown
      /// </summary>
      public RibbonMouseSensor Sensor
      {
         get { return _sensor; }
      }
      /// <summary>
      /// Gets the Ribbon this DropDown belongs to
      /// </summary>
      public Ribbon OwnerRibbon
      {
         get { return _ownerRibbon; }
      }
      /// <summary>
      /// Gets the RibbonItem this dropdown belongs to
      /// </summary>
      public IEnumerable<RibbonItem> Items
      {
         get { return _items; }
      }
      /// <summary>
      /// Gets or sets a value indicating if the sizing grip should be visible
      /// </summary>
      public bool ShowSizingGrip
      {
         get { return _showSizingGrip; }
         set
         {
            _showSizingGrip = value;
            UpdateSize();
         }
      }
      /// <summary>
      /// Gets or sets the height of the sizing grip area
      /// </summary>
      [DefaultValue(12)]
      public int SizingGripHeight
      {
         get { return _sizingGripHeight; }
         set { _sizingGripHeight = value; }
      }

      #endregion

      #region Methods
      public void SetBounds()
      {
         #region Assign grip regions
         if (ShowSizingGrip)
         {
            _sizingGripBounds = Rectangle.FromLTRB(
                ClientSize.Width - SizingGripHeight, ClientSize.Height - SizingGripHeight,
                ClientSize.Width, ClientSize.Height);
         }
         else
         {
            _sizingGripBounds = Rectangle.Empty;
         }
         #endregion

         #region Assign buttons regions
         if (ScrollBarEnabled)
         {
            int bwidth = _scrollBarSize;
            int bheight = _scrollBarSize;
            _thumbBounds.Width = _scrollBarSize;

            _buttonUpBounds = new Rectangle(Bounds.Right - bwidth - 1,
                Bounds.Top + OwnerRibbon.DropDownMargin.Top, bwidth, bheight);

            _buttonDownBounds = new Rectangle(_buttonUpBounds.Left, Bounds.Height - bheight - _sizingGripBounds.Height - OwnerRibbon.DropDownMargin.Bottom - 1,
                bwidth, bheight);

            _thumbBounds.X = _buttonUpBounds.Left;

            _buttonUpEnabled = _offset < 0;
            if (!_buttonUpEnabled) _offset = 0;
            _buttonDownEnabled = false;
         }
         #endregion

         int scrollWidth = ScrollBarEnabled ? ScrollBarSize : 0;
         int itemsWidth = Math.Max(0, ClientSize.Width - OwnerRibbon.DropDownMargin.Horizontal - scrollWidth);

         _contentBounds = Rectangle.FromLTRB(OwnerRibbon.DropDownMargin.Left,
             OwnerRibbon.DropDownMargin.Top,
             Bounds.Right - scrollWidth - OwnerRibbon.DropDownMargin.Right, 
             Bounds.Bottom - OwnerRibbon.DropDownMargin.Bottom - _sizingGripBounds.Height);

         int curTop = OwnerRibbon.DropDownMargin.Top + _offset;
         int curLeft = OwnerRibbon.DropDownMargin.Left;
         int maxBottom = curTop; // int.MinValue;
         int iniTop = curTop;

         foreach (RibbonItem item in Items)
         {
            item.SetBounds(Rectangle.Empty);
         }

         foreach (RibbonItem item in Items)
         {
             curTop = maxBottom;

            item.SetBounds(new Rectangle(curLeft, curTop, itemsWidth, item.LastMeasuredSize.Height));

            //maxBottom = Math.Max(maxBottom, item.Bounds.Bottom);
            maxBottom = curTop + item.LastMeasuredSize.Height;

            //if (item.Bounds.Bottom > ContentBounds.Bottom) _buttonDownEnabled = true;

            _jumpDownSize = item.Bounds.Height;
            _jumpUpSize = item.Bounds.Height;
         }

         _fullContentBounds = Rectangle.FromLTRB(ContentBounds.Left, iniTop, ContentBounds.Right, maxBottom);

         #region Adjust thumb size

         double contentHeight = maxBottom - iniTop - 1;
         double viewHeight = Bounds.Height;

         //scrollbars?
         if (ContentBounds.Height < _fullContentBounds.Height)
         {
            double viewPercent = _fullContentBounds.Height > ContentBounds.Height ? (double)ContentBounds.Height / _fullContentBounds.Height : 0.0;
            double availHeight = ButtonDownBounds.Top - ButtonUpBounds.Bottom;
            double thumbHeight = Math.Ceiling(viewPercent * availHeight);

            if (thumbHeight < 30)
            {
               if (availHeight >= 30)
               {
                  thumbHeight = 30;
               }
               else
               {
                  thumbHeight = availHeight;
               }
            }
            _buttonUpEnabled = _offset < 0;
            _buttonDownEnabled = ScrollMaximum > -_offset;

            _thumbBounds.Height = Convert.ToInt32(thumbHeight);

            _scrollBarEnabled = true;

            UpdateThumbPos();
         }
         else
         {
            _scrollBarEnabled = false;
         }

         #endregion
      }

      /// <summary>
      /// Updates the position of the scroll thumb depending on the current offset
      /// </summary>
      private void UpdateThumbPos()
      {
         if (_avoidNextThumbMeasure)
         {
            _avoidNextThumbMeasure = false;
            return;
         }

         double scrolledp = ScrolledPercent;

         if (!double.IsInfinity(scrolledp))
         {
            double availSpace = ScrollMaximum - ScrollMinimum;
            double scrolledSpace = Math.Ceiling(availSpace * ScrolledPercent);

            _thumbBounds.Y = ScrollMinimum + Convert.ToInt32(scrolledSpace);
         }
         else
         {
            _thumbBounds.Y = ScrollMinimum;
         }

         if (_thumbBounds.Y > ScrollMaximum)
         {
            _thumbBounds.Y = ScrollMaximum;
         }

      }

      /// <summary>
      /// Scrolls the list down
      /// </summary>
      public void ScrollDown()
      {
         if (ScrollBarEnabled)
            ScrollOffset(-(_jumpDownSize + 1));
      }

      /// <summary>
      /// Scrolls the list up
      /// </summary>
      public void ScrollUp()
      {
         if (ScrollBarEnabled)
            ScrollOffset(_jumpUpSize + 1);
      }

      /// <summary>
      /// Pushes the amount of _offset of the top of items
      /// </summary>
      /// <param name="amount"></param>
      private void ScrollOffset(int amount)
      {
         ScrollTo(_offset + amount);
      }

      /// <summary>
      /// Scrolls the content to the specified offset
      /// </summary>
      /// <param name="offset"></param>
      private void ScrollTo(int offset)
      {
         if (ScrollBarEnabled)
         {
            int minOffset = ContentBounds.Height - _fullContentBounds.Height;

            if (offset < minOffset)
            {
               offset = minOffset;
            }

            _offset = offset;
            SetBounds();
            Invalidate();
         }
      }

      /// <summary>
      /// Prevents the form from being hidden the next time the mouse clicks on the form.
      /// It is useful for reacting to clicks of items inside items.
      /// </summary>
      public void IgnoreNextClickDeactivation()
      {
         _ignoreNext = true;
      }

      /// <summary>
      /// Updates the size of the dropdown
      /// </summary>
      private void UpdateSize()
      {
         int heightSum = OwnerRibbon.DropDownMargin.Vertical;
         int maxWidth = 0;
         int scrollableHeight = 0;
         using (Graphics g = CreateGraphics())
         {
            foreach (RibbonItem item in Items)
            {
               Size s = item.MeasureSize(this, new RibbonElementMeasureSizeEventArgs(g, MeasuringSize));

               heightSum += s.Height;
               maxWidth = Math.Max(maxWidth, s.Width + OwnerRibbon.DropDownMargin.Horizontal);

               if (item is IScrollableRibbonItem)
               {
                  scrollableHeight += s.Height;
               }
            }
         }

         //This is the initial sizing of the popup window so
         //we need to add the width of the scrollbar if its needed.
         if ((_maxHeight > 0 && _maxHeight < heightSum && !_resizing) || (heightSum + (ShowSizingGrip ? SizingGripHeight + 2 : 0) + 1) > Screen.PrimaryScreen.WorkingArea.Height)
         {
             if (_maxHeight > 0)
                 heightSum = _maxHeight;
             else
                 heightSum = Screen.PrimaryScreen.WorkingArea.Height - ((ShowSizingGrip ? SizingGripHeight + 2 : 0) + 1);
            
             maxWidth += _scrollBarSize;
            _thumbBounds.Width = _scrollBarSize;
            _scrollBarEnabled = true;
         }

         if (!_resizing)
         {
             Size sz = new Size(maxWidth, heightSum + (ShowSizingGrip ? SizingGripHeight + 2 : 0));
            Size = sz;
         }

         if (WrappedDropDown != null)
         {
            WrappedDropDown.Size = this.Size;
         }

         SetBounds();
      }

      ///// <summary>
      ///// Updates the bounds of the items
      ///// </summary>
      //private void UpdateItemsBounds()
      //{
      //   SetBounds();
      //   return;
      //   int curTop = OwnerRibbon.DropDownMargin.Top;
      //   int curLeft = OwnerRibbon.DropDownMargin.Left;
      //   //Got off the patch site from logicalerror
      //   //int itemsWidth = ClientSize.Width - OwnerRibbon.DropDownMargin.Horizontal;
      //   int itemsWidth = Math.Max(0, ClientSize.Width - OwnerRibbon.DropDownMargin.Horizontal);

      //   if (ScrollBarEnabled) itemsWidth -= ScrollBarSize;

      //   int scrollableItemsHeight = 0;
      //   int nonScrollableItemsHeight = 0;
      //   int scrollableItems = 0;
      //   int scrollableItemHeight = 0;

      //   #region Measure scrollable content
      //   foreach (RibbonItem item in Items)
      //   {
      //      if (item is IScrollableRibbonItem)
      //      {
      //         scrollableItemsHeight += item.LastMeasuredSize.Height;
      //         scrollableItems++;
      //      }
      //      else
      //      {
      //         nonScrollableItemsHeight += item.LastMeasuredSize.Height;
      //      }
      //   }

      //   if (scrollableItems > 0)
      //   {
      //      //Got off the patch site from logicalerror
      //      //scrollableItemHeight = (Height - nonScrollableItemsHeight - (ShowSizingGrip ? SizingGripHeight : 0)) / scrollableItems;
      //      scrollableItemHeight = Math.Max(0, (Height - nonScrollableItemsHeight - (ShowSizingGrip ? SizingGripHeight : 0)) / scrollableItems);
      //   }

      //   #endregion

      //   foreach (RibbonItem item in Items)
      //   {
      //      if (item is IScrollableRibbonItem)
      //      {
      //         item.SetBounds(new Rectangle(curLeft, curTop, itemsWidth, scrollableItemHeight - 1));
      //      }
      //      else
      //      {
      //         item.SetBounds(new Rectangle(curLeft, curTop, itemsWidth, item.LastMeasuredSize.Height));
      //      }

      //      curTop += item.Bounds.Height;
      //   }

      //   if (ShowSizingGrip)
      //   {
      //      _sizingGripBounds = Rectangle.FromLTRB(
      //          ClientSize.Width - SizingGripHeight, ClientSize.Height - SizingGripHeight,
      //          ClientSize.Width, ClientSize.Height);
      //   }
      //   else
      //   {
      //      _sizingGripBounds = Rectangle.Empty;
      //   }
      //}

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

      #region Overrides

      protected override void OnOpening(CancelEventArgs e)
      {
         base.OnOpening(e);

         SetBounds();
      }

      protected override void OnShowed(EventArgs e)
      {
         base.OnShowed(e);

          //Allow the Combobox and other items to contain a selected item on the dropdown.
         if (ParentItem is RibbonButton)
         {  
             foreach (RibbonItem item in Items)
             {
                 item.SetSelected(false);
             }
         }
      }

      protected override void OnMouseDown(MouseEventArgs e)
      {
         base.OnMouseDown(e);

         if (Cursor == Cursors.SizeNWSE)
         {
            _resizeOrigin = new Point(e.X, e.Y);
            _resizeSize = Size;
            _resizing = true;
         }
         if (ButtonDownSelected || ButtonUpSelected)
         {
            IgnoreDeactivation();
         }

         if (ButtonDownSelected && ButtonDownEnabled)
         {
            _buttonDownPressed = true;
            ScrollDown();
         }

         if (ButtonUpSelected && ButtonUpEnabled)
         {
            _buttonUpPressed = true;
            ScrollUp();
         }

         if (ThumbSelected)
         {
            _thumbPressed = true;
            _thumbOffset = e.Y - _thumbBounds.Y;
         }

         if (
             ScrollBarBounds.Contains(e.Location) &&
             e.Y >= ButtonUpBounds.Bottom && e.Y <= ButtonDownBounds.Y &&
             !ThumbBounds.Contains(e.Location) &&
             !ButtonDownBounds.Contains(e.Location) &&
             !ButtonUpBounds.Contains(e.Location))
         {
            if (e.Y < ThumbBounds.Y)
            {
               ScrollOffset(Bounds.Height);
            }
            else
            {
               ScrollOffset(-Bounds.Height);
            }
         }
      }

      protected override void OnMouseClick(MouseEventArgs e)
      {
          //Close();

          base.OnMouseClick(e);
      }

      protected override void OnMouseMove(MouseEventArgs e)
      {
         base.OnMouseMove(e);

         if (ShowSizingGrip && SizingGripBounds.Contains(e.X, e.Y))
         {
            Cursor = Cursors.SizeNWSE;
         }
         else if (Cursor == Cursors.SizeNWSE)
         {
            Cursor = Cursors.Default;
         }

         if (_resizing)
         {
            int dx = e.X - _resizeOrigin.X;
            int dy = e.Y - _resizeOrigin.Y;

            int w = _resizeSize.Width + dx;
            int h = _resizeSize.Height + dy;

            if (w != Width || h != Height)
            {
               Size = new Size(w, h);
               if (WrappedDropDown != null)
               {
                  WrappedDropDown.Size = Size;
               }
               int contentHeight = Bounds.Height - OwnerRibbon.DropDownMargin.Vertical - _sizingGripBounds.Height;
               if (contentHeight < _fullContentBounds.Height)
               {
                  _scrollBarEnabled = true;
                  if (-_offset + contentHeight > _fullContentBounds.Height)
                  {
                     _offset = contentHeight - _fullContentBounds.Height;
                  }                  
               }
               else
               {
                  _scrollBarEnabled = false;
               }

               SetBounds();
               Invalidate();
            }
         }

         if (ButtonDownPressed && ButtonDownSelected && ButtonDownEnabled)
         {
            ScrollOffset(-1);
         }

         if (ButtonUpPressed && ButtonUpSelected && ButtonUpEnabled)
         {
            ScrollOffset(1);
         }

         bool upCache = _buttonUpSelected;
         bool downCache = _buttonDownSelected;
         bool thumbCache = _thumbSelected;

         _buttonUpSelected = _buttonUpBounds.Contains(e.Location);
         _buttonDownSelected = _buttonDownBounds.Contains(e.Location);
         _thumbSelected = _thumbBounds.Contains(e.Location) && ScrollBarEnabled;

         if ((upCache != _buttonUpSelected)
             || (downCache != _buttonDownSelected)
             || (thumbCache != _thumbSelected))
         {
            Invalidate();
         }

         if (ThumbPressed)
         {
            int newval = e.Y - _thumbOffset;

            if (newval < ScrollMinimum)
            {
               newval = ScrollMinimum;
            }
            else if (newval > ScrollMaximum)
            {
               newval = ScrollMaximum;
            }

            ScrollValue = newval;
            Invalidate();
         }
      }

      protected override void OnMouseUp(MouseEventArgs e)
      {
         base.OnMouseUp(e);

         _buttonDownPressed = false;
         _buttonUpPressed = false;
         _thumbPressed = false;

         if (_resizing)
         {
            _resizing = false;
            return;
         }

         if (_ignoreNext)
         {
            _ignoreNext = false;
            return;
         }

         if (RibbonDesigner.Current != null)
            Close();
      }

      protected override void OnPaint(PaintEventArgs e)
      {
         base.OnPaint(e);

         OwnerRibbon.Renderer.OnRenderDropDownBackground(
             new RibbonCanvasEventArgs(OwnerRibbon, e.Graphics, new Rectangle(Point.Empty, ClientSize), this, ParentItem));

         RectangleF lastClip = e.Graphics.ClipBounds;
         //if (e.ClipRectangle.Top < OwnerRibbon.DropDownMargin.Top)
         //{
         RectangleF newClip = lastClip;
         newClip.Y = OwnerRibbon.DropDownMargin.Top;
         newClip.Height = Bounds.Bottom - _sizingGripBounds.Height - OwnerRibbon.DropDownMargin.Vertical;
         e.Graphics.SetClip(newClip);
         //}

         foreach (RibbonItem item in Items)
         {
             //Draw image separator for normal menu buttons and their separators
             if ((item is RibbonButton && !(item is RibbonDescriptionMenuItem)) ||
                    (item is RibbonSeparator && ((RibbonSeparator)item).DropDownWidth == RibbonSeparatorDropDownWidth.Partial))
             {
                 OwnerRibbon.Renderer.OnRenderDropDownDropDownImageSeparator(item,
                     new RibbonCanvasEventArgs(OwnerRibbon, e.Graphics, new Rectangle(Point.Empty, ClientSize), this, ParentItem));
             }

             if (item.Bounds.IntersectsWith(_contentBounds))
                 item.OnPaint(this, new RibbonElementPaintEventArgs(item.Bounds, e.Graphics, RibbonElementSizeMode.DropDown));
         }

         if (ScrollBarEnabled)
             OwnerRibbon.Renderer.OnRenderScrollbar(e.Graphics, this, OwnerRibbon);

         e.Graphics.SetClip(lastClip);
      }

      protected override void OnMouseLeave(EventArgs e)
      {
         base.OnMouseLeave(e);

         foreach (RibbonItem item in Items)
         {
            item.SetSelected(false);
         }
      }

      private void OnRibbonHostMouseMove(object sender, MouseEventArgs e)
      {
          //Raise mouse move event from the RibbonHost control as if it were generated by the MouseSensor.
          OnMouseMove(e);
      }

      #endregion
      #endregion
   }
}