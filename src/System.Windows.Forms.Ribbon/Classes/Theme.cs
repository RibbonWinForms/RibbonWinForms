namespace System.Windows.Forms
{
   public class Theme
   {
      #region public static Properties
      private static Theme _Default;
      /// <summary>
      /// Gets the standard (global, if not defined otherwise on the Ribbon) Ribbon Theme.
      /// </summary>
      public static Theme Standard
      {
         get
         {
            if (_Default == null)
            {
               _Default = new Theme();
            }
            return _Default;
         }
      }

      private static bool _standardThemeIsGlobal = true;
      /// <summary>
      /// If this value is set all ribbons will use the same theme.
      /// Otherwise different themes can be applied to multiple ribbon instances, e.g. RibbonDemo!
      /// </summary>
      public static bool StandardThemeIsGlobal
      {
         get { return _standardThemeIsGlobal; }
         set { _standardThemeIsGlobal = value; }
      }
      #endregion

      #region Constructor

      public Theme()
      {
      }

      public Theme(RibbonOrbStyle style)
      {
         Style = style;
      }

      public Theme(RibbonOrbStyle style, RibbonTheme theme)
         : this(style)
      {
         RibbonTheme = theme;
      }

      public Theme(RibbonOrbStyle style, RibbonProfesionalRendererColorTable colorTable)
         : this(style)
      {
         RendererColorTable = colorTable;
      }

      #endregion

      #region Properties

      private RibbonProfesionalRendererColorTable _RendererColorTable = new RibbonProfesionalRendererColorTable();
      public RibbonProfesionalRendererColorTable RendererColorTable
      {
         get { return _RendererColorTable; }
         set { _RendererColorTable = value; }
      }

      private RibbonOrbStyle _Style;
      public RibbonOrbStyle Style
      {
         get { return _Style; }
         set { _Style = value; }
      }

      private RibbonTheme _Theme = RibbonTheme.Normal;
      public RibbonTheme RibbonTheme
      {
         get { return _Theme; }
         set
         {
            _Theme = value;
            if (_Theme == RibbonTheme.Blue || _Theme == RibbonTheme.Normal)
               RendererColorTable = new RibbonProfesionalRendererColorTable();
            else if (_Theme == RibbonTheme.Black)
                RendererColorTable = new RibbonProfesionalRendererColorTableBlack();
            else if (_Theme == RibbonTheme.Blue_2010)
                RendererColorTable = new RibbonProfesionalRendererColorTableBlue2010();
            else if (_Theme == RibbonTheme.Green)
               RendererColorTable = new RibbonProfesionalRendererColorTableGreen();
            else if (_Theme == RibbonTheme.Purple)
               RendererColorTable = new RibbonProfesionalRendererColorTablePurple();
            else if (_Theme == RibbonTheme.JellyBelly)
               RendererColorTable = new RibbonProfesionalRendererColorTableJellyBelly();
            else if (_Theme == RibbonTheme.Halloween)
               RendererColorTable = new RibbonProfesionalRendererColorTableHalloween();
         }
      }

      #endregion

      #region Compatiblity to Release 7 Oct 2013

      [Obsolete("Either create a theme for your Ribbon or use 'Standard' instance!")]
      public static RibbonProfesionalRendererColorTable ColorTable
      {
         get { return Standard.RendererColorTable; }
         set { Standard.RendererColorTable = value; }
      }

      [Obsolete("Either create a theme for your Ribbon or use 'Standard' instance!")]
      public static RibbonOrbStyle ThemeStyle
      {
         get { return Standard.Style; }
         set { Standard.Style = value; }
      }

      [Obsolete("Either create a theme for your Ribbon or use 'Standard' instance!")]
      public RibbonTheme ThemeColor
      {
         get { return Standard.RibbonTheme; }
         set { Standard.RibbonTheme = value; }
      }

      #endregion Compatiblity to Release 7 Oct 2013
   }
}