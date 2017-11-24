using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Text;

namespace System.Windows.Forms
{
    [Editor(typeof(RibbonQuickAccessToolbarItemCollectionEditor), typeof(UITypeEditor))]
    public class RibbonQuickAccessToolbarItemCollection : RibbonItemCollection
    {
        #region Fields
        private RibbonQuickAccessToolbar _ownerToolbar; 
        #endregion

        /// <summary>
        /// Creates a new collection
        /// </summary>
        /// <param name="ownerGroup"></param>
        internal RibbonQuickAccessToolbarItemCollection(RibbonQuickAccessToolbar toolbar)
        {
            _ownerToolbar = toolbar;
            SetOwner(toolbar.Owner);
        }
        /// <summary>
        /// Gets the group that owns this item collection
        /// </summary>
        public RibbonQuickAccessToolbar OwnerToolbar
        {
            get
            {
                return _ownerToolbar;
            }
        }

        /// <summary>
        /// Adds the specified item to the collection
        /// </summary>
        public override void Add(RibbonItem item)
        {
            item.MaxSizeMode = RibbonElementSizeMode.Compact;
            base.Add(item);
        }

        /// <summary>
        /// Adds the specified range of items
        /// </summary>
        /// <param name="items">Items to add</param>
        public override void AddRange(IEnumerable<RibbonItem> items)
        {
            foreach (RibbonItem item in items)
            {
                item.MaxSizeMode = RibbonElementSizeMode.Compact;
            }
            base.AddRange(items);
        }

        /// <summary>
        /// Inserts the specified item at the desired index
        /// </summary>
        /// <param name="index">Desired index of the item</param>
        /// <param name="item">Item to insert</param>
        public override void Insert(int index, RibbonItem item)
        {
            item.MaxSizeMode = RibbonElementSizeMode.Compact;
            base.Insert(index, item);
        }
    }
}
