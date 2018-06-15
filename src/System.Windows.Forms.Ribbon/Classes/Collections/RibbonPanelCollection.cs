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

namespace System.Windows.Forms
{
    /// <summary>
    /// Represents a collection of RibbonPanel objects
    /// </summary>
    public sealed class RibbonPanelCollection
        : System.Windows.Forms.Classes.Collections.RibbonCollectionBase<RibbonPanel>
    {
        /// <summary>
        /// Creates a new RibbonPanelCollection
        /// </summary>
        /// <param name="ownerTab">RibbonTab that contains this panel collection</param>
        /// <exception cref="ArgumentNullException">ownerTab is null</exception>
        public RibbonPanelCollection(RibbonTab ownerTab)
           : base(null)
        {
           if (ownerTab == null) throw new ArgumentNullException(nameof(ownerTab));

           OwnerTab = ownerTab;
        }

        /// <summary>
        /// Gets the Ribbon that contains this panel collection
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Ribbon Owner => base.Owner ?? OwnerTab.Owner;

        /// <summary>
        /// Gets the RibbonTab that contains this panel collection
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RibbonTab OwnerTab { get; private set; }

        internal override void SetOwner(RibbonPanel item)
        {
           item.SetOwner(Owner);
           item.SetOwnerTab(OwnerTab);
        }

        internal override void ClearOwner(RibbonPanel item)
        {
           item.ClearOwner();
        }

        /// <summary>
        /// Notifies the <see cref="OwnerTab"/> and <see cref="OwnerPanel"/> about changes in the <see cref="RibbonItemCollection"/>.
        /// </summary>
        internal override void UpdateRegions()
        {
            try
            {
                OwnerTab.UpdatePanelsRegions();
                if (Owner != null && Owner.IsDisposed == false)
                {
                    Owner.UpdateRegions();
                    Owner.Invalidate();
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Sets the value of the Owner Property
        /// </summary>
        internal override void SetOwner(Ribbon owner)
        {
           base.SetOwner(owner);
           foreach (RibbonPanel panel in this)
           {
              panel.SetOwner(owner);
           }
        }

        /// <summary>
        /// Sets the value of the OwnerTab Property
        /// </summary>
        /// <param name="onwerTab"></param>
        internal void SetOwnerTab(RibbonTab ownerTab)
        {
            OwnerTab = ownerTab;

            foreach (RibbonPanel panel in this)
            {
                panel.SetOwnerTab(OwnerTab);
            }
        }
    }
}
