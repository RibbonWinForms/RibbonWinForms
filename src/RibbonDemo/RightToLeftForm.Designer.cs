namespace RibbonDemo
{
    partial class RightToLeftForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RightToLeftForm));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.RecentItemsCaption = null;
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 447);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = null;
            this.ribbon1.OrbText = null;
            // 
            // 
            // 
            this.ribbon1.QuickAccessToolbar.AltKey = null;
            this.ribbon1.QuickAccessToolbar.CheckedGroup = null;
            this.ribbon1.QuickAccessToolbar.Image = null;
            this.ribbon1.QuickAccessToolbar.ShowFlashImage = false;
            this.ribbon1.QuickAccessToolbar.Tag = null;
            this.ribbon1.QuickAccessToolbar.Text = null;
            this.ribbon1.QuickAccessToolbar.ToolTip = null;
            this.ribbon1.QuickAccessToolbar.ToolTipTitle = null;
            this.ribbon1.QuickAccessToolbar.Value = null;
            this.ribbon1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ribbon1.Size = new System.Drawing.Size(557, 141);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.TabSpacing = 6;
            this.ribbon1.Text = "ribbon1";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Panels.Add(this.ribbonPanel2);
            this.ribbonTab1.Panels.Add(this.ribbonPanel3);
            this.ribbonTab1.Tag = null;
            this.ribbonTab1.Text = "ribbonTab1";
            this.ribbonTab1.ToolTip = null;
            this.ribbonTab1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.ribbonTab1.ToolTipImage = null;
            this.ribbonTab1.ToolTipTitle = null;
            this.ribbonTab1.Value = null;
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.ribbonButton1);
            this.ribbonPanel1.Tag = null;
            this.ribbonPanel1.Text = "ribbonPanel1";
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Tag = null;
            this.ribbonPanel2.Text = "ribbonPanel2";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.AltKey = null;
            this.ribbonButton1.CheckedGroup = null;
            this.ribbonButton1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton1.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton1.Image = global::RibbonDemo.Properties.Resources.find32;
            this.ribbonButton1.ShowFlashImage = false;
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton1.Tag = null;
            this.ribbonButton1.Text = "ribbonButton1";
            this.ribbonButton1.ToolTip = null;
            this.ribbonButton1.ToolTipTitle = null;
            this.ribbonButton1.Value = null;
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Tag = null;
            this.ribbonPanel3.Text = "ribbonPanel3";
            // 
            // RightToLeftForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 262);
            this.Controls.Add(this.ribbon1);
            this.Name = "RightToLeftForm";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
    }
}