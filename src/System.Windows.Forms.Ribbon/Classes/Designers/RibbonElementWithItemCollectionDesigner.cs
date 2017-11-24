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
using System.ComponentModel.Design;
using System.ComponentModel;

namespace System.Windows.Forms
{
   internal abstract class RibbonElementWithItemCollectionDesigner
       : ComponentDesigner
   {
      #region Props

      /// <summary>
      /// Gets a reference to the Ribbon that owns the item
      /// </summary>
      public abstract Ribbon Ribbon { get; }

      /// <summary>
      /// Gets the collection of items hosted by this item
      /// </summary>
      public abstract RibbonItemCollection Collection { get; }

      /// <summary>
      /// Called when verbs must be retrieved
      /// </summary>
      /// <returns></returns>
      protected virtual DesignerVerbCollection OnGetVerbs()
      {
         return new DesignerVerbCollection(new DesignerVerb[] { 
               new DesignerVerb("Add Button", new EventHandler(AddButton)),
               new DesignerVerb("Add ButtonList", new EventHandler(AddButtonList)),
               new DesignerVerb("Add ItemGroup", new EventHandler(AddItemGroup)),
               new DesignerVerb("Add Separator", new EventHandler(AddSeparator)),
               new DesignerVerb("Add TextBox", new EventHandler(AddTextBox)),
               new DesignerVerb("Add ComboBox", new EventHandler(AddComboBox)),
               new DesignerVerb("Add ColorChooser", new EventHandler(AddColorChooser)),
               new DesignerVerb("Add DescriptionMenuItem", new EventHandler(AddDescriptionMenuItem)),
               new DesignerVerb("Add CheckBox", new EventHandler(AddCheckBox)),
               new DesignerVerb("Add UpDown", new EventHandler(AddUpDown)),
               new DesignerVerb("Add Label", new EventHandler(AddLabel)),
               new DesignerVerb("Add Host", new EventHandler(AddHost))
            });
      }

      /// <summary>
      /// Overriden. Passes the verbs to the designer
      /// </summary>
      public override DesignerVerbCollection Verbs
      {
         get
         {
            return OnGetVerbs();
         }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Creates an item of the speciifed type
      /// </summary>
      /// <param name="t"></param>
      private void CreateItem(Type t)
      {
         CreateItem(Ribbon, Collection, t);
      }

      /// <summary>
      /// Creates an item of the specified type and adds it to the specified collection
      /// </summary>
      /// <param name="ribbon"></param>
      /// <param name="collection"></param>
      /// <param name="t"></param>
      protected virtual void CreateItem(Ribbon ribbon, RibbonItemCollection collection, Type t)
      {
         IDesignerHost host = GetService(typeof(IDesignerHost)) as IDesignerHost;

         if (host != null && collection != null && ribbon != null)
         {
            DesignerTransaction transaction = host.CreateTransaction("AddRibbonItem_" + Component.Site.Name);

            MemberDescriptor member = TypeDescriptor.GetProperties(Component)["Items"];
            base.RaiseComponentChanging(member);

            RibbonItem item = host.CreateComponent(t) as RibbonItem;

            if (!(item is RibbonSeparator)) item.Text = item.Site.Name;

            collection.Add(item);
            ribbon.OnRegionsChanged();

            base.RaiseComponentChanged(member, null, null);
            transaction.Commit();
         }
      }

      protected virtual void AddButton(object sender, EventArgs e)
      {
         CreateItem(typeof(RibbonButton));
      }

      protected virtual void AddButtonList(object sender, EventArgs e)
      {
         CreateItem(typeof(RibbonButtonList));
      }

      protected virtual void AddItemGroup(object sender, EventArgs e)
      {
         CreateItem(typeof(RibbonItemGroup));
      }

      protected virtual void AddSeparator(object sender, EventArgs e)
      {
         CreateItem(typeof(RibbonSeparator));
      }

      protected virtual void AddTextBox(object sender, EventArgs e)
      {
         CreateItem(typeof(RibbonTextBox));
      }

      protected virtual void AddComboBox(object sender, EventArgs e)
      {
         CreateItem(typeof(RibbonComboBox));
      }

      protected virtual void AddColorChooser(object sender, EventArgs e)
      {
         CreateItem(typeof(RibbonColorChooser));
      }

      protected virtual void AddDescriptionMenuItem(object sender, EventArgs e)
      {
         CreateItem(typeof(RibbonDescriptionMenuItem));
      }
      protected virtual void AddCheckBox(object sender, EventArgs e)
      {
         CreateItem(typeof(RibbonCheckBox));
      }
      protected virtual void AddUpDown(object sender, EventArgs e)
      {
         CreateItem(typeof(RibbonUpDown));
      }
      protected virtual void AddLabel(object sender, EventArgs e)
      {
         CreateItem(typeof(RibbonLabel));
      }
      protected virtual void AddHost(object sender, EventArgs e)
      {
         CreateItem(typeof(RibbonHost));
      }
      #endregion
   }
}
