using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RibbonDemo
{
    public partial class BlackForm : MainForm
    {
        public BlackForm()
        {
            InitializeComponent();

            ribbon1.OrbStyle = RibbonOrbStyle.Office_2007;
            ribbon1.Theme.RendererColorTable = new RibbonProfesionalRendererColorTableBlack();
        }
    }
}