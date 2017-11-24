namespace RibbonDemo
{
   partial class MDIForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIForm));
         this.ribbon1 = new System.Windows.Forms.Ribbon();
         this.DropDownButton1 = new System.Windows.Forms.RibbonButton();
         this.DropDownButton2 = new System.Windows.Forms.RibbonButton();
         this.SubMenuButton1 = new System.Windows.Forms.RibbonButton();
         this.SubMenuButton2 = new System.Windows.Forms.RibbonButton();
         this.DropDownButton3 = new System.Windows.Forms.RibbonButton();
         this.DropDownButton4 = new System.Windows.Forms.RibbonButton();
         this.RibbonButtonOpen = new System.Windows.Forms.RibbonButton();
         this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
         this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
         this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
         this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
         this.ribbonButton3 = new System.Windows.Forms.RibbonButton();
         this.SuspendLayout();
         // 
         // ribbon1
         // 
         this.ribbon1.Cursor = System.Windows.Forms.Cursors.Default;
         this.ribbon1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.ribbon1.Location = new System.Drawing.Point(0, 0);
         this.ribbon1.Minimized = false;
         this.ribbon1.Name = "ribbon1";
         // 
         // 
         // 
         this.ribbon1.OrbDropDown.BorderRoundness = 8;
         this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
         this.ribbon1.OrbDropDown.Name = "";
         this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 72);
         this.ribbon1.OrbDropDown.TabIndex = 0;
         this.ribbon1.OrbText = "Menu";
         // 
         // 
         // 
         this.ribbon1.QuickAccessToolbar.DropDownButtonItems.Add(this.DropDownButton1);
         this.ribbon1.QuickAccessToolbar.DropDownButtonItems.Add(this.DropDownButton2);
         this.ribbon1.QuickAccessToolbar.DropDownButtonItems.Add(this.DropDownButton3);
         this.ribbon1.QuickAccessToolbar.DropDownButtonItems.Add(this.DropDownButton4);
         this.ribbon1.QuickAccessToolbar.Items.Add(this.RibbonButtonOpen);
         this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
         this.ribbon1.Size = new System.Drawing.Size(711, 136);
         this.ribbon1.TabIndex = 0;
         this.ribbon1.Tabs.Add(this.ribbonTab1);
         this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
         this.ribbon1.Text = "ribbon1";
         this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
         // 
         // DropDownButton1
         // 
         this.DropDownButton1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
         this.DropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("DropDownButton1.Image")));
         this.DropDownButton1.SmallImage = global::RibbonDemo.Properties.Resources.unorderedlist16;
         this.DropDownButton1.Text = "Some button";
         // 
         // DropDownButton2
         // 
         this.DropDownButton2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
         this.DropDownButton2.DropDownItems.Add(this.SubMenuButton1);
         this.DropDownButton2.DropDownItems.Add(this.SubMenuButton2);
         this.DropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("DropDownButton2.Image")));
         this.DropDownButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("DropDownButton2.SmallImage")));
         this.DropDownButton2.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
         this.DropDownButton2.Text = "Submenu";
         // 
         // SubMenuButton1
         // 
         this.SubMenuButton1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
         this.SubMenuButton1.Image = ((System.Drawing.Image)(resources.GetObject("SubMenuButton1.Image")));
         this.SubMenuButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("SubMenuButton1.SmallImage")));
         this.SubMenuButton1.Text = "1";
         // 
         // SubMenuButton2
         // 
         this.SubMenuButton2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
         this.SubMenuButton2.Image = ((System.Drawing.Image)(resources.GetObject("SubMenuButton2.Image")));
         this.SubMenuButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("SubMenuButton2.SmallImage")));
         this.SubMenuButton2.Text = "2";
         // 
         // DropDownButton3
         // 
         this.DropDownButton3.CheckOnClick = true;
         this.DropDownButton3.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
         this.DropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("DropDownButton3.Image")));
         this.DropDownButton3.SmallImage = ((System.Drawing.Image)(resources.GetObject("DropDownButton3.SmallImage")));
         this.DropDownButton3.Text = "CheckOnClick!";
         // 
         // DropDownButton4
         // 
         this.DropDownButton4.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
         this.DropDownButton4.Image = ((System.Drawing.Image)(resources.GetObject("DropDownButton4.Image")));
         this.DropDownButton4.SmallImage = global::RibbonDemo.Properties.Resources.bold16;
         this.DropDownButton4.Text = "Some other button";
         // 
         // RibbonButtonOpen
         // 
         this.RibbonButtonOpen.Image = ((System.Drawing.Image)(resources.GetObject("RibbonButtonOpen.Image")));
         this.RibbonButtonOpen.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
         this.RibbonButtonOpen.SmallImage = global::RibbonDemo.Properties.Resources.open16;
         // 
         // ribbonTab1
         // 
         this.ribbonTab1.Panels.Add(this.ribbonPanel1);
         this.ribbonTab1.Text = "ribbonTab1";
         // 
         // ribbonPanel1
         // 
         this.ribbonPanel1.Items.Add(this.ribbonButton1);
         this.ribbonPanel1.Items.Add(this.ribbonButton2);
         this.ribbonPanel1.Items.Add(this.ribbonButton3);
         this.ribbonPanel1.Text = null;
         // 
         // ribbonButton1
         // 
         this.ribbonButton1.Image = global::RibbonDemo.Properties.Resources.close32;
         this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
         this.ribbonButton1.Text = "Close_Form";
         this.ribbonButton1.ToolTip = "Close Form";
         this.ribbonButton1.Click += new System.EventHandler(this.ribbonButton1_Click);
         // 
         // ribbonButton2
         // 
         this.ribbonButton2.Image = global::RibbonDemo.Properties.Resources.newdocument32;
         this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
         this.ribbonButton2.Text = "Form_1";
         this.ribbonButton2.ToolTip = "Show Form 1";
         this.ribbonButton2.Click += new System.EventHandler(this.ribbonButton2_Click);
         // 
         // ribbonButton3
         // 
         this.ribbonButton3.Image = global::RibbonDemo.Properties.Resources.newdocument32;
         this.ribbonButton3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.SmallImage")));
         this.ribbonButton3.Text = "Form_2";
         this.ribbonButton3.ToolTip = "Show Form 2";
         this.ribbonButton3.Click += new System.EventHandler(this.ribbonButton3_Click);
         // 
         // MDIForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(711, 402);
         this.Controls.Add(this.ribbon1);
         this.IsMdiContainer = true;
         this.KeyPreview = true;
         this.Name = "MDIForm";
         this.Text = "MDIForm";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Ribbon ribbon1;
      private System.Windows.Forms.RibbonTab ribbonTab1;
      private System.Windows.Forms.RibbonPanel ribbonPanel1;
      private System.Windows.Forms.RibbonButton ribbonButton1;
      private System.Windows.Forms.RibbonButton ribbonButton2;
      private System.Windows.Forms.RibbonButton ribbonButton3;
      private System.Windows.Forms.RibbonButton DropDownButton1;
      private System.Windows.Forms.RibbonButton DropDownButton2;
      private System.Windows.Forms.RibbonButton SubMenuButton1;
      private System.Windows.Forms.RibbonButton SubMenuButton2;
      private System.Windows.Forms.RibbonButton RibbonButtonOpen;
      private System.Windows.Forms.RibbonButton DropDownButton3;
      private System.Windows.Forms.RibbonButton DropDownButton4;
   }
}