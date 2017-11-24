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

namespace System.Windows.Forms
{
    internal class RibbonItemGroupDesigner
        : RibbonElementWithItemCollectionDesigner
    {
        public override Ribbon Ribbon
        {
            get
            {
                if (Component is RibbonItemGroup)
                {
                    return (Component as RibbonItemGroup).Owner;
                }
                return null;
            }
        }

        public override RibbonItemCollection Collection
        {
            get 
            {
                if (Component is RibbonItemGroup)
                {
                    return (Component as RibbonItemGroup).Items;
                }
                return null;
            }
        }
    }
}
