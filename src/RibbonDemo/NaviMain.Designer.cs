namespace RibbonDemo
{
	partial class NaviMain
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NaviMain));
            this.tlsNaviHelper = new System.Windows.Forms.ToolStrip();
            this.tsbtnPin = new System.Windows.Forms.ToolStripButton();
            this.tlstrpNaviButtons = new System.Windows.Forms.ToolStrip();
            this.btnInbox = new System.Windows.Forms.ToolStripButton();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.lstViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.tlsNaviHelper.SuspendLayout();
            this.tlstrpNaviButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlsNaviHelper
            // 
            this.tlsNaviHelper.AutoSize = false;
            this.tlsNaviHelper.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsNaviHelper.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tlsNaviHelper.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnPin});
            this.tlsNaviHelper.Location = new System.Drawing.Point(0, 0);
            this.tlsNaviHelper.Name = "tlsNaviHelper";
            this.tlsNaviHelper.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tlsNaviHelper.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tlsNaviHelper.Size = new System.Drawing.Size(404, 24);
            this.tlsNaviHelper.TabIndex = 3;
            this.tlsNaviHelper.Text = "ToolStrip1";
            // 
            // tsbtnPin
            // 
            this.tsbtnPin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnPin.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnPin.Image")));
            this.tsbtnPin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPin.Name = "tsbtnPin";
            this.tsbtnPin.Size = new System.Drawing.Size(28, 21);
            this.tsbtnPin.Text = "ToolStripButton1";
            this.tsbtnPin.ToolTipText = "Hide Navigation Panel";
            // 
            // tlstrpNaviButtons
            // 
            this.tlstrpNaviButtons.AutoSize = false;
            this.tlstrpNaviButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlstrpNaviButtons.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.tlstrpNaviButtons.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlstrpNaviButtons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInbox,
            this.btnSearch});
            this.tlstrpNaviButtons.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.tlstrpNaviButtons.Location = new System.Drawing.Point(0, 713);
            this.tlstrpNaviButtons.MinimumSize = new System.Drawing.Size(250, 30);
            this.tlstrpNaviButtons.Name = "tlstrpNaviButtons";
            this.tlstrpNaviButtons.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.tlstrpNaviButtons.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tlstrpNaviButtons.Size = new System.Drawing.Size(404, 104);
            this.tlstrpNaviButtons.Stretch = true;
            this.tlstrpNaviButtons.TabIndex = 4;
            // 
            // btnInbox
            // 
            this.btnInbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInbox.Checked = true;
            this.btnInbox.CheckOnClick = true;
            this.btnInbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnInbox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnInbox.Image = global::RibbonDemo.Properties.Resources.send32;
            this.btnInbox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInbox.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnInbox.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnInbox.Margin = new System.Windows.Forms.Padding(0);
            this.btnInbox.Name = "btnInbox";
            this.btnInbox.Padding = new System.Windows.Forms.Padding(3);
            this.btnInbox.Size = new System.Drawing.Size(403, 42);
            this.btnInbox.Tag = "Inbox";
            this.btnInbox.Text = "Inbox";
            this.btnInbox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.CheckOnClick = true;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Image = global::RibbonDemo.Properties.Resources.find32;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnSearch.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Padding = new System.Windows.Forms.Padding(3);
            this.btnSearch.Size = new System.Drawing.Size(403, 42);
            this.btnSearch.Tag = "Search";
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.lstViewImageList;
            this.treeView1.Location = new System.Drawing.Point(0, 24);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(404, 689);
            this.treeView1.TabIndex = 5;
            // 
            // lstViewImageList
            // 
            this.lstViewImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("lstViewImageList.ImageStream")));
            this.lstViewImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.lstViewImageList.Images.SetKeyName(0, "folder-open.ico");
            this.lstViewImageList.Images.SetKeyName(1, "folder-open-4.ico");
            this.lstViewImageList.Images.SetKeyName(2, "File.ico");
            // 
            // NaviMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.tlsNaviHelper);
            this.Controls.Add(this.tlstrpNaviButtons);
            this.Name = "NaviMain";
            this.Size = new System.Drawing.Size(404, 817);
            this.tlsNaviHelper.ResumeLayout(false);
            this.tlsNaviHelper.PerformLayout();
            this.tlstrpNaviButtons.ResumeLayout(false);
            this.tlstrpNaviButtons.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        internal System.Windows.Forms.ToolStrip tlsNaviHelper;
        internal System.Windows.Forms.ToolStripButton tsbtnPin;
        internal System.Windows.Forms.ToolStrip tlstrpNaviButtons;
        internal System.Windows.Forms.ToolStripButton btnInbox;
        internal System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.TreeView treeView1;
        internal System.Windows.Forms.ImageList lstViewImageList;
	}
}
