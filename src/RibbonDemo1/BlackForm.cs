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