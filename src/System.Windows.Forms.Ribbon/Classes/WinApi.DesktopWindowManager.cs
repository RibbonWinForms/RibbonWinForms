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

namespace System.Windows.Forms.RibbonHelpers
{
    public static partial class WinApi
    {
        /// <summary>
        /// Gets if computer is glass capable and enabled
        /// </summary>
        public static bool IsGlassEnabled {
            get {
                //Check is windows vista
                if (IsVista)
                {
                    //Check what DWM says about composition
                    int enabled = 0;
                    int response = DwmIsCompositionEnabled(ref enabled);

                    return enabled > 0;
                }

                return false;
            }
        }

    }
}
