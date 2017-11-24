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
using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms
{
    public class RibbonOrbOptionButton
        : RibbonButton
    {
        #region Ctors

        public RibbonOrbOptionButton()
            : base()
        {

        }

        public RibbonOrbOptionButton(string text)
            : this()
        {
            Text = text;
        }

        #endregion

        #region Props

        /// <summary>
        /// This property is not relevant for this class
        /// </summary>
        [Browsable(false)]
        public override Image LargeImage
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

        [DefaultValue(null)]
        [Browsable(true)]
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

                SmallImage = value;
            }
        }

        /// <summary>
        /// This property is not relevant for this class
        /// </summary>
        [Browsable(false)]
        public override Image SmallImage
        {
            get
            {
                return base.SmallImage;
            }
            set
            {
                base.SmallImage = value;
            }
        }

        #endregion
    }
}
