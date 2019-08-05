namespace RibbonDemo
{
   partial class QiosCaptionTest
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.QRibbonCaption1 = new Qios.DevSuite.Components.Ribbon.QRibbonCaption();
         this.QRibbonApplicationButton1 = new Qios.DevSuite.Components.Ribbon.QRibbonApplicationButton();
         this.qCompositeMenuItem1 = new Qios.DevSuite.Components.QCompositeMenuItem();
         this.QRibbonLaunchBar1 = new Qios.DevSuite.Components.Ribbon.QRibbonLaunchBar();
         this.ribbon1 = new System.Windows.Forms.Ribbon();
         this.ribbonTab2 = new System.Windows.Forms.RibbonTab();
         this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
         this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
         this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
         ((System.ComponentModel.ISupportInitialize)(this.QRibbonCaption1)).BeginInit();
         this.SuspendLayout();
         // 
         // QRibbonCaption1
         // 
         this.QRibbonCaption1.ApplicationButton = this.QRibbonApplicationButton1;
         this.QRibbonCaption1.Configuration.IconConfiguration.Visible = Qios.DevSuite.Components.QTristateBool.False;
         this.QRibbonCaption1.LaunchBar = this.QRibbonLaunchBar1;
         this.QRibbonCaption1.Location = new System.Drawing.Point(0, 0);
         this.QRibbonCaption1.Name = "QRibbonCaption1";
         this.QRibbonCaption1.Size = new System.Drawing.Size(756, 28);
         this.QRibbonCaption1.TabIndex = 4;
         this.QRibbonCaption1.Text = "qRibbonCaption1";
         // 
         // QRibbonApplicationButton1
         // 
         this.QRibbonApplicationButton1.ChildItems.Add(this.qCompositeMenuItem1);
         // 
         // qCompositeMenuItem1
         // 
         this.qCompositeMenuItem1.Title = "Menu Item #1";
         // 
         // ribbon1
         // 
         this.ribbon1.CaptionBarVisible = false;
         this.ribbon1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
         this.ribbon1.Location = new System.Drawing.Point(0, 28);
         this.ribbon1.Minimized = false;
         this.ribbon1.Name = "ribbon1";
         // 
         // 
         // 
         this.ribbon1.OrbDropDown.BorderRoundness = 8;
         this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
         this.ribbon1.OrbDropDown.Name = "";
         this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 447);
         this.ribbon1.OrbDropDown.TabIndex = 0;
         this.ribbon1.OrbImage = null;
         // 
         // 
         // 
         this.ribbon1.QuickAcessToolbar.AltKey = null;
         this.ribbon1.QuickAcessToolbar.Image = null;
         this.ribbon1.QuickAcessToolbar.Tag = null;
         this.ribbon1.QuickAcessToolbar.Text = null;
         this.ribbon1.QuickAcessToolbar.ToolTip = null;
         this.ribbon1.QuickAcessToolbar.ToolTipImage = null;
         this.ribbon1.QuickAcessToolbar.ToolTipTitle = null;
         this.ribbon1.QuickAcessToolbar.Value = null;
         this.ribbon1.Size = new System.Drawing.Size(756, 136);
         this.ribbon1.TabIndex = 5;
         this.ribbon1.Tabs.Add(this.ribbonTab2);
         this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(55, 2, 20, 0);
         this.ribbon1.TabSpacing = 6;
         this.ribbon1.Text = "ribbon1";
         // 
         // ribbonTab2
         // 
         this.ribbonTab2.Panels.Add(this.ribbonPanel2);
         this.ribbonTab2.Tag = null;
         this.ribbonTab2.Text = "ribbonTab2";
         // 
         // ribbonPanel2
         // 
         this.ribbonPanel2.Tag = null;
         this.ribbonPanel2.Text = "ribbonPanel2";
         // 
         // ribbonPanel1
         // 
         this.ribbonPanel1.Tag = null;
         this.ribbonPanel1.Text = "ribbonPanel1";
         // 
         // ribbonTab1
         // 
         this.ribbonTab1.Panels.Add(this.ribbonPanel1);
         this.ribbonTab1.Tag = null;
         this.ribbonTab1.Text = "ribbonTab1";
         // 
         // QiosCaptionTest
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(756, 305);
         this.Controls.Add(this.ribbon1);
         this.Controls.Add(this.QRibbonCaption1);
         this.Name = "QiosCaptionTest";
         this.Text = "qRibbonCaption1";
         ((System.ComponentModel.ISupportInitialize)(this.QRibbonCaption1)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.RibbonPanel ribbonPanel1;
      private System.Windows.Forms.RibbonTab ribbonTab1;
      private System.Windows.Forms.RibbonTab ribbonTab2;
      private System.Windows.Forms.RibbonPanel ribbonPanel2;
      internal Qios.DevSuite.Components.Ribbon.QRibbonCaption QRibbonCaption1;
      internal Qios.DevSuite.Components.Ribbon.QRibbonApplicationButton QRibbonApplicationButton1;
      internal Qios.DevSuite.Components.Ribbon.QRibbonLaunchBar QRibbonLaunchBar1;
      private System.Windows.Forms.Ribbon ribbon1;
      private Qios.DevSuite.Components.QCompositeMenuItem qCompositeMenuItem1;
   }
}