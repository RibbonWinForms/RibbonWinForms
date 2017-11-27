using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace RibbonDemo
{
    public partial class NaviMain : UserControl
    {
        public NaviMain()
        {
            InitializeComponent();
            tlstrpNaviButtons.Renderer = new System.Windows.Forms.ProToolstripRenderer(true);
            tlsNaviHelper.Renderer = new System.Windows.Forms.ProToolstripRenderer(false);
        }
    }
}
