using System.Windows.Forms;

namespace RibbonDemo
{
    public partial class NaviMain : UserControl
    {
        public NaviMain()
        {
            InitializeComponent();
            tlstrpNaviButtons.Renderer = new ProToolstripRenderer(true);
            tlsNaviHelper.Renderer = new ProToolstripRenderer(false);
        }
    }
}
