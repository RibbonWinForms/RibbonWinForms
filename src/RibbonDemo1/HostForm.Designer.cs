namespace RibbonDemo
{
   partial class HostForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HostForm));
            this.month1 = new System.Windows.Forms.MonthCalendar();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.GridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.ribbonLabel4 = new System.Windows.Forms.RibbonLabel();
            this.ribbonLabel1 = new System.Windows.Forms.RibbonLabel();
            this.ribbonComboBox1 = new System.Windows.Forms.RibbonComboBox();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonHost2 = new System.Windows.Forms.RibbonHost();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribbonLabel2 = new System.Windows.Forms.RibbonLabel();
            this.ribbonLabel3 = new System.Windows.Forms.RibbonLabel();
            this.ribbonHost1 = new System.Windows.Forms.RibbonHost();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.ribbonHost3 = new System.Windows.Forms.RibbonHost();
            this.ribbonOrbMenuItem2 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonButton5 = new System.Windows.Forms.RibbonButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // month1
            // 
            this.month1.Location = new System.Drawing.Point(9, 242);
            this.month1.Name = "month1";
            this.month1.TabIndex = 2;
            this.month1.TitleBackColor = System.Drawing.Color.LightSteelBlue;
            this.month1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.month1_DateSelected);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(211, 242);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(98, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GridID,
            this.GridName});
            this.dataGridView1.Location = new System.Drawing.Point(324, 242);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(250, 70);
            this.dataGridView1.TabIndex = 4;
            // 
            // GridID
            // 
            this.GridID.HeaderText = "ID";
            this.GridID.Name = "GridID";
            // 
            // GridName
            // 
            this.GridName.HeaderText = "Name";
            this.GridName.Name = "GridName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(715, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "To host a control you simply insert a RibbonHost item into the desired container " +
    "and then set the HostedControl property to the control you want to host";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(706, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "If you host a control into a popup or drowdown menu then you must call the HostCo" +
    "mpleted method after you get the desired data to close the popup";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(15, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(862, 46);
            this.label3.TabIndex = 7;
            this.label3.Text = "If the ribbon is resized you may need to manually set the size of the control by " +
    "responding to the SizeModeChanging event.  If you manually set the control you n" +
    "eed to set the Handled flag to true";
            // 
            // ribbon1
            // 
            this.ribbon1.CaptionBarVisible = false;
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = true;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 72);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            // 
            // 
            // 
            this.ribbon1.QuickAccessToolbar.Visible = false;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(889, 132);
            this.ribbon1.TabIndex = 1;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(6, 26, 20, 0);
            this.ribbon1.TabSpacing = 3;
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue_2010;
            this.ribbon1.OrbDoubleClick += new System.EventHandler(this.ribbon1_OrbDoubleClick);
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Panels.Add(this.ribbonPanel3);
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Panels.Add(this.ribbonPanel2);
            this.ribbonTab1.Text = "ribbonTab1";
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Items.Add(this.ribbonLabel4);
            this.ribbonPanel3.Items.Add(this.ribbonLabel1);
            this.ribbonPanel3.Items.Add(this.ribbonComboBox1);
            this.ribbonPanel3.Name = "ribbonPanel3";
            this.ribbonPanel3.Text = "Simulate a DateTimePicker";
            // 
            // ribbonLabel4
            // 
            this.ribbonLabel4.LabelWidth = 130;
            this.ribbonLabel4.Name = "ribbonLabel4";
            this.ribbonLabel4.Text = "Host a month control";
            this.ribbonLabel4.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            // 
            // ribbonLabel1
            // 
            this.ribbonLabel1.LabelWidth = 130;
            this.ribbonLabel1.Name = "ribbonLabel1";
            this.ribbonLabel1.Text = "in the dropdown items";
            this.ribbonLabel1.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            // 
            // ribbonComboBox1
            // 
            this.ribbonComboBox1.AllowTextEdit = false;
            this.ribbonComboBox1.DrawIconsBar = false;
            this.ribbonComboBox1.DropDownItems.Add(this.ribbonButton1);
            this.ribbonComboBox1.DropDownItems.Add(this.ribbonHost2);
            this.ribbonComboBox1.DropDownResizable = true;
            this.ribbonComboBox1.Name = "ribbonComboBox1";
            this.ribbonComboBox1.Text = "Date:";
            this.ribbonComboBox1.TextBoxText = "";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
            this.ribbonButton1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.LargeImage")));
            this.ribbonButton1.Name = "ribbonButton1";
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "All Dates";
            // 
            // ribbonHost2
            // 
            this.ribbonHost2.HostedControl = this.month1;
            this.ribbonHost2.Name = "ribbonHost2";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.ribbonLabel2);
            this.ribbonPanel1.Items.Add(this.ribbonLabel3);
            this.ribbonPanel1.Items.Add(this.ribbonHost1);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Text = "hosting a control";
            // 
            // ribbonLabel2
            // 
            this.ribbonLabel2.LabelWidth = 120;
            this.ribbonLabel2.Name = "ribbonLabel2";
            this.ribbonLabel2.Text = "DateTimePicker";
            this.ribbonLabel2.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            // 
            // ribbonLabel3
            // 
            this.ribbonLabel3.LabelWidth = 120;
            this.ribbonLabel3.Name = "ribbonLabel3";
            this.ribbonLabel3.Text = "hosted in the panel";
            this.ribbonLabel3.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            // 
            // ribbonHost1
            // 
            this.ribbonHost1.HostedControl = this.dateTimePicker1;
            this.ribbonHost1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonHost1.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonHost1.Name = "ribbonHost1";
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.ribbonHost3);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Text = "Grid Hosted in panel";
            // 
            // ribbonHost3
            // 
            this.ribbonHost3.HostedControl = this.dataGridView1;
            this.ribbonHost3.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonHost3.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonHost3.Name = "ribbonHost3";
            this.ribbonHost3.Text = "Grid Host";
            this.ribbonHost3.SizeModeChanging += new System.Windows.Forms.RibbonHost.RibbonHostSizeModeHandledEventHandler(this.ribbonHost3_SizeModeChanging);
            // 
            // ribbonOrbMenuItem2
            // 
            this.ribbonOrbMenuItem2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem2.Image")));
            this.ribbonOrbMenuItem2.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem2.LargeImage")));
            this.ribbonOrbMenuItem2.Name = "ribbonOrbMenuItem2";
            this.ribbonOrbMenuItem2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem2.SmallImage")));
            this.ribbonOrbMenuItem2.Text = "Menu 2";
            // 
            // ribbonButton5
            // 
            this.ribbonButton5.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.Image")));
            this.ribbonButton5.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.LargeImage")));
            this.ribbonButton5.Name = "ribbonButton5";
            this.ribbonButton5.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.SmallImage")));
            this.ribbonButton5.Text = "ribbonButton5";
            // 
            // HostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(889, 436);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.month1);
            this.Controls.Add(this.ribbon1);
            this.KeyPreview = true;
            this.Name = "HostForm";
            this.Text = "Control Hosting Examples";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.RibbonTab ribbonTab1;
      private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem2;
      private System.Windows.Forms.RibbonButton ribbonButton5;
      private System.Windows.Forms.Ribbon ribbon1;
      private System.Windows.Forms.MonthCalendar month1;
      private System.Windows.Forms.DateTimePicker dateTimePicker1;
      private System.Windows.Forms.RibbonPanel ribbonPanel3;
      private System.Windows.Forms.RibbonLabel ribbonLabel1;
      private System.Windows.Forms.RibbonComboBox ribbonComboBox1;
      private System.Windows.Forms.RibbonHost ribbonHost2;
      private System.Windows.Forms.RibbonPanel ribbonPanel1;
      private System.Windows.Forms.RibbonLabel ribbonLabel2;
      private System.Windows.Forms.RibbonHost ribbonHost1;
      private System.Windows.Forms.RibbonLabel ribbonLabel4;
      private System.Windows.Forms.RibbonLabel ribbonLabel3;
      private System.Windows.Forms.RibbonPanel ribbonPanel2;
      private System.Windows.Forms.DataGridView dataGridView1;
      private System.Windows.Forms.RibbonHost ribbonHost3;
      private System.Windows.Forms.DataGridViewTextBoxColumn GridID;
      private System.Windows.Forms.DataGridViewTextBoxColumn GridName;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.RibbonButton ribbonButton1;
    }
}