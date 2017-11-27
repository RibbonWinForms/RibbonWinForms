namespace RibbonDemo2
{
    partial class frmMenu
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
            this.btMainDemo = new System.Windows.Forms.Button();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.cmbOrbStyle = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btMainDemo
            // 
            this.btMainDemo.Location = new System.Drawing.Point(15, 65);
            this.btMainDemo.Name = "btMainDemo";
            this.btMainDemo.Size = new System.Drawing.Size(260, 23);
            this.btMainDemo.TabIndex = 0;
            this.btMainDemo.Text = "Main Demo";
            this.btMainDemo.UseVisualStyleBackColor = true;
            this.btMainDemo.Click += new System.EventHandler(this.btMainDemo_Click);
            // 
            // cmbColor
            // 
            this.cmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(113, 38);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(162, 21);
            this.cmbColor.TabIndex = 9;
            // 
            // cmbOrbStyle
            // 
            this.cmbOrbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrbStyle.FormattingEnabled = true;
            this.cmbOrbStyle.Location = new System.Drawing.Point(15, 38);
            this.cmbOrbStyle.Name = "cmbOrbStyle";
            this.cmbOrbStyle.Size = new System.Drawing.Size(92, 21);
            this.cmbOrbStyle.TabIndex = 8;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 9);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(188, 26);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "Select an OrbStyle and a ColorTheme.\r\nThen select the Ribbon to show.";
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 261);
            this.Controls.Add(this.cmbColor);
            this.Controls.Add(this.cmbOrbStyle);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btMainDemo);
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btMainDemo;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.ComboBox cmbOrbStyle;
        private System.Windows.Forms.Label lblDescription;
    }
}