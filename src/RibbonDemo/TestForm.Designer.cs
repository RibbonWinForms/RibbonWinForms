namespace RibbonDemo
{
    partial class TestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonOrbMenuItem1 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonButton3 = new System.Windows.Forms.RibbonButton();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.ribbonUpDown1 = new System.Windows.Forms.RibbonUpDown();
            this.ribbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.ribbonCheckBox1 = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonCheckBox2 = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonCheckBox3 = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonCheckBox4 = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonSeparator2 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribbonComboBox1 = new System.Windows.Forms.RibbonComboBox();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.ribbonComboBox2 = new System.Windows.Forms.RibbonComboBox();
            this.ribbonTextBox1 = new System.Windows.Forms.RibbonTextBox();
            this.ribbonButton4 = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton5 = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton6 = new System.Windows.Forms.RibbonButton();
            this.ribbonTab2 = new System.Windows.Forms.RibbonTab();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonOrbMenuItem1);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 116);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = null;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
            // 
            // 
            // 
            this.ribbon1.QuickAccessToolbar.Items.Add(this.ribbonButton3);
            this.ribbon1.QuickAccessToolbar.Visible = false;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(1057, 150);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.Tabs.Add(this.ribbonTab2);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // ribbonOrbMenuItem1
            // 
            this.ribbonOrbMenuItem1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem1.Image")));
            this.ribbonOrbMenuItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem1.SmallImage")));
            this.ribbonOrbMenuItem1.Text = "Menu 1";
            // 
            // ribbonButton3
            // 
            this.ribbonButton3.Image = global::RibbonDemo.Properties.Resources.copy16;
            this.ribbonButton3.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton3.SmallImage = global::RibbonDemo.Properties.Resources.copy16;
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Panels.Add(this.ribbonPanel2);
            this.ribbonTab1.Panels.Add(this.ribbonPanel3);
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Panels.Add(this.ribbonPanel4);
            this.ribbonTab1.Panels.Add(this.ribbonPanel5);
            this.ribbonTab1.Text = "ribbonTab1";
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.ribbonUpDown1);
            this.ribbonPanel2.Items.Add(this.ribbonSeparator1);
            this.ribbonPanel2.Text = "Up Down Control";
            // 
            // ribbonUpDown1
            // 
            this.ribbonUpDown1.AllowTextEdit = false;
            this.ribbonUpDown1.Text = "Up/Down:";
            this.ribbonUpDown1.TextBoxText = "10";
            this.ribbonUpDown1.TextBoxWidth = 50;
            // 
            // ribbonSeparator1
            // 
            this.ribbonSeparator1.DrawBackground = false;
            this.ribbonSeparator1.Visible = false;
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Items.Add(this.ribbonCheckBox1);
            this.ribbonPanel3.Items.Add(this.ribbonCheckBox2);
            this.ribbonPanel3.Items.Add(this.ribbonCheckBox3);
            this.ribbonPanel3.Items.Add(this.ribbonCheckBox4);
            this.ribbonPanel3.Items.Add(this.ribbonSeparator2);
            this.ribbonPanel3.Text = "CheckBoxes";
            // 
            // ribbonCheckBox1
            // 
            this.ribbonCheckBox1.Checked = true;
            this.ribbonCheckBox1.Style = System.Windows.Forms.RibbonCheckBox.CheckBoxStyle.RadioButton;
            this.ribbonCheckBox1.Text = "Left Justify";
            this.ribbonCheckBox1.CheckBoxCheckChanging += new System.ComponentModel.CancelEventHandler(this.ribbonCheckBox1_CheckBoxCheckChanging);
            // 
            // ribbonCheckBox2
            // 
            this.ribbonCheckBox2.CheckBoxOrientation = System.Windows.Forms.RibbonCheckBox.CheckBoxOrientationEnum.Right;
            this.ribbonCheckBox2.Checked = true;
            this.ribbonCheckBox2.Text = "Right Justify";
            // 
            // ribbonCheckBox3
            // 
            this.ribbonCheckBox3.Style = System.Windows.Forms.RibbonCheckBox.CheckBoxStyle.RadioButton;
            this.ribbonCheckBox3.Text = "radio 2";
            // 
            // ribbonCheckBox4
            // 
            this.ribbonCheckBox4.Text = "checkbox 2";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.ribbonComboBox1);
            this.ribbonPanel1.Items.Add(this.ribbonComboBox2);
            this.ribbonPanel1.Items.Add(this.ribbonTextBox1);
            this.ribbonPanel1.Items.Add(this.ribbonButton4);
            this.ribbonPanel1.Text = "Label Width Property";
            // 
            // ribbonComboBox1
            // 
            this.ribbonComboBox1.DropDownItems.Add(this.ribbonButton1);
            this.ribbonComboBox1.DropDownItems.Add(this.ribbonButton2);
            this.ribbonComboBox1.LabelWidth = 90;
            this.ribbonComboBox1.Text = "Right Justify:";
            this.ribbonComboBox1.TextBoxText = "AllowTextEdit";
            this.ribbonComboBox1.TextBoxWidth = 150;
            this.ribbonComboBox1.DropDownItemClicked += new System.Windows.Forms.RibbonComboBox.RibbonItemEventHandler(this.ribbonComboBox1_DropDownItemClicked);
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Style = System.Windows.Forms.RibbonButtonStyle.DropDownListItem;
            this.ribbonButton1.Text = "First Item";
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.Image")));
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Style = System.Windows.Forms.RibbonButtonStyle.DropDownListItem;
            this.ribbonButton2.Text = "Second Item";
            // 
            // ribbonComboBox2
            // 
            this.ribbonComboBox2.LabelWidth = 90;
            this.ribbonComboBox2.Text = "Labels:";
            this.ribbonComboBox2.TextBoxText = null;
            // 
            // ribbonTextBox1
            // 
            this.ribbonTextBox1.Text = "Textbox";
            this.ribbonTextBox1.TextBoxText = null;
            // 
            // ribbonButton4
            // 
            this.ribbonButton4.CheckOnClick = true;
            this.ribbonButton4.Image = global::RibbonDemo.Properties.Resources.close32;
            this.ribbonButton4.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.SmallImage")));
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.Items.Add(this.ribbonButton5);
            this.ribbonPanel4.Text = "Alternating Image";
            // 
            // ribbonButton5
            // 
            this.ribbonButton5.FlashEnabled = true;
            this.ribbonButton5.FlashImage = global::RibbonDemo.Properties.Resources.close32;
            this.ribbonButton5.FlashSmallImage = global::RibbonDemo.Properties.Resources.casing16;
            this.ribbonButton5.Image = global::RibbonDemo.Properties.Resources.addons32;
            this.ribbonButton5.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.SmallImage")));
            this.ribbonButton5.Text = "ribbonButton5";
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.Items.Add(this.ribbonButton6);
            this.ribbonPanel5.Text = "DropDown Scroolbar Test";
            // 
            // ribbonButton6
            // 
            this.ribbonButton6.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.Image")));
            this.ribbonButton6.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.SmallImage")));
            this.ribbonButton6.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            this.ribbonButton6.Text = "A lot of Items";
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Text = "ribbonTab2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(67, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(235, 156);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Start Flashing";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(235, 185);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Stop Flashing";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1057, 338);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ribbon1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonComboBox ribbonComboBox1;
        private System.Windows.Forms.RibbonComboBox ribbonComboBox2;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonUpDown ribbonUpDown1;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonCheckBox ribbonCheckBox1;
        private System.Windows.Forms.RibbonCheckBox ribbonCheckBox2;
        private System.Windows.Forms.RibbonButton ribbonButton3;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator1;
        private System.Windows.Forms.RibbonTextBox ribbonTextBox1;
        private System.Windows.Forms.RibbonTab ribbonTab2;
        private System.Windows.Forms.RibbonCheckBox ribbonCheckBox3;
        private System.Windows.Forms.RibbonCheckBox ribbonCheckBox4;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator2;
        private System.Windows.Forms.RibbonButton ribbonButton4;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonButton ribbonButton5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
        private System.Windows.Forms.RibbonButton ribbonButton6;
    }
}