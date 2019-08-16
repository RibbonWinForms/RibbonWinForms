using System.ComponentModel;
using System.Windows.Forms;

namespace RibbonDemo
{
    partial class RightToLeftForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ribbon1.Size = new System.Drawing.Size(743, 174);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.Text = "ribbon1";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Panels.Add(this.ribbonPanel2);
            this.ribbonTab1.Panels.Add(this.ribbonPanel3);
            this.ribbonTab1.Text = "ribbonTab1";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.ribbonButton1);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Text = "ribbonPanel1";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = global::RibbonDemo.Properties.Resources.find32;
            this.ribbonButton1.LargeImage = global::RibbonDemo.Properties.Resources.find32;
            this.ribbonButton1.Name = "ribbonButton1";
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "ribbonButton1";
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Text = "ribbonPanel2";
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Name = "ribbonPanel3";
            this.ribbonPanel3.Text = "ribbonPanel3";
            // 
            // RightToLeftForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 322);
            this.Controls.Add(this.ribbon1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RightToLeftForm";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private Ribbon ribbon1;
        private RibbonTab ribbonTab1;
        private RibbonPanel ribbonPanel1;
        private RibbonPanel ribbonPanel2;
        private RibbonButton ribbonButton1;
        private RibbonPanel ribbonPanel3;
    }
}