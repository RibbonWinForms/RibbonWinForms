using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.RibbonHelpers;

namespace RibbonDemo
{
    public partial class ThemeBuilderForm : RibbonForm
    {
        private Dictionary<RibbonColorPart, Panel> dicPanel = new Dictionary<RibbonColorPart, Panel>();
        private Dictionary<RibbonColorPart, TextBox> dicTxt = new Dictionary<RibbonColorPart, TextBox>();

        public ThemeBuilderForm()
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            LoadTheme();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void LoadTheme()
        {
            RibbonProfesionalRendererColorTable r = ribbon1.Theme.RendererColorTable;

            txtAuthor.Text = r.ThemeAuthor;
            txtAuthorEmail.Text = r.ThemeAuthorEmail;
            txtAuthorWebsite.Text = r.ThemeAuthorWebsite;
            txtDateCreated.Text = r.ThemeDateCreated;
            txtThemeName.Text = r.ThemeName;
            flowLayoutPanel1.Controls.Remove(tableLayoutPanel1);
            tableLayoutPanel1 = null;

            foreach (KeyValuePair<RibbonColorPart, Panel> kv in dicPanel)
            {
                Panel p = kv.Value;
                p = null;
            }

            foreach (KeyValuePair<RibbonColorPart, TextBox> kv in dicTxt)
            {
                TextBox t = kv.Value;
                t = null;
            }

            dicPanel.Clear();
            dicTxt.Clear();

            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(c1);
            tableLayoutPanel1.Controls.Add(c2);
            tableLayoutPanel1.Controls.Add(c3);
            tableLayoutPanel1.Controls.Add(c4);
            tableLayoutPanel1.Controls.Add(c5);
            tableLayoutPanel1.Controls.Add(c6);

            int count = Enum.GetNames(typeof(RibbonColorPart)).Length;
            for (int i = 0; i < count; i++)
            {
                Label l = new Label();
                l.Width = 180;
                l.Text = ((RibbonColorPart)i).ToString();

                Panel p = new Panel();
                p.Height = 16;
                p.Width = 100;
                p.BorderStyle = BorderStyle.FixedSingle;
                p.BackColor = r.GetColor((RibbonColorPart)i);
                dicPanel[(RibbonColorPart)i] = p;

                TextBox t = new TextBox();
                t.Tag = (RibbonColorPart)i;
                t.Text = r.GetColorHexStr((RibbonColorPart)i);
                t.LostFocus += new EventHandler(t_LostFocus);
                t.KeyPress += new KeyPressEventHandler(t_KeyPress);
                t.TextChanged += new EventHandler(t_LostFocus);
                dicTxt[(RibbonColorPart)i] = t;

                Button b = new Button();
                b.Text = "Get Color";
                b.Tag = (RibbonColorPart)i;
                b.Click += new EventHandler(b_Click);

                CheckBox ib = new CheckBox();
                ib.Text = "Invert";
                ib.Tag = (RibbonColorPart)i;
                ib.Click += new EventHandler(b_InvertClick);

                NumericUpDown nud = new NumericUpDown();
                nud.Width = 50;
                nud.Tag = (RibbonColorPart)i;
                nud.Minimum = 0;
                nud.Maximum = 255;
                nud.Value = r.GetColor((RibbonColorPart)i).A;
                nud.ValueChanged += new EventHandler(nud_ValueChanged);

                tableLayoutPanel1.Controls.Add(l);
                tableLayoutPanel1.Controls.Add(nud);
                tableLayoutPanel1.Controls.Add(p);
                tableLayoutPanel1.Controls.Add(t);
                tableLayoutPanel1.Controls.Add(b);
                tableLayoutPanel1.Controls.Add(ib);
            }
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(tableLayoutPanel1);
            ribbon1.Refresh();
            this.Refresh();
        }

        private void nud_ValueChanged(object sender, EventArgs e)
        {
            RibbonProfesionalRendererColorTable r = ribbon1.Theme.RendererColorTable;
            RibbonColorPart rcp = (RibbonColorPart)((NumericUpDown)sender).Tag;
            Color originalColor = r.GetColor(rcp);

            RefreshColor(rcp, Color.FromArgb((int)((NumericUpDown)sender).Value, originalColor));
        }

        private void b_Click(object sender, EventArgs e)
        {
            ColorDialog d = new ColorDialog();
            d.FullOpen = true;
            d.AllowFullOpen = true;
            if (d.ShowDialog() == DialogResult.OK)
            {
                RibbonColorPart rcp = (RibbonColorPart)((Button)sender).Tag;
                RefreshColor(rcp, d.Color);
            }
        }

        private void b_InvertClick(object sender, EventArgs e)
        {
            RibbonProfesionalRendererColorTable r = ribbon1.Theme.RendererColorTable;
            RibbonColorPart rcp = (RibbonColorPart)((CheckBox)sender).Tag;
            Color originalColor = r.GetColor(rcp);

            RefreshColor(rcp, Color.FromArgb(originalColor.A, 255 - originalColor.R, 255 - originalColor.G, 255 - originalColor.B));
        }

        private void t_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (((TextBox)sender).Text.Length == 7)
                {
                    Color color = ribbon1.Theme.RendererColorTable.FromHex(((TextBox)sender).Text);
                    RibbonColorPart rcp = (RibbonColorPart)((TextBox)sender).Tag;
                    RefreshColor(rcp, color);
                }
                else if (((TextBox)sender).Text.Length > 7)
                    MessageBox.Show("Value is to long.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void t_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (((TextBox)sender).Text.Length == 7)
                {
                    RibbonProfesionalRendererColorTable r = ribbon1.Theme.RendererColorTable;
                    Color color = ribbon1.Theme.RendererColorTable.FromHex(((TextBox)sender).Text);
                    RibbonColorPart rcp = (RibbonColorPart)((TextBox)sender).Tag;
                    RefreshColor(rcp, Color.FromArgb(r.GetColor(rcp).A, color));
                }
                else if (((TextBox)sender).Text.Length > 7)
                    MessageBox.Show("Value is to long.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshColor(RibbonColorPart rcp, Color color)
        {
            ribbon1.Theme.RendererColorTable.SetColor(rcp, color);
            dicPanel[rcp].BackColor = color;
            dicTxt[rcp].Text = ribbon1.Theme.RendererColorTable.GetColorHexStr(rcp);
            ribbon1.Refresh();
            this.Refresh();
        }

        private void btGenerateThemeClass_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Class Name is empty.");
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Drawing;");
            sb.AppendLine();
            sb.AppendLine("namespace System.Windows.Forms");
            sb.AppendLine("{");
            sb.AppendLine("    public class " + textBox1.Text + " : RibbonProfesionalRendererColorTable");
            sb.AppendLine("    {");
            sb.AppendLine("        public " + textBox1.Text + "()");
            sb.AppendLine("        {");
            sb.AppendLine("            // Rebuild the solution for the first time");
            sb.AppendLine("            // for this ColorTable to take effect.");
            sb.AppendLine("            // Guide for applying new theme: http://officeribbon.codeplex.com/wikipage?title=How%20to%20Make%20a%20New%20Theme%2c%20Skin%20for%20this%20Ribbon%20Programmatically");
            sb.AppendLine();
            sb.AppendLine("            ThemeName = \"" + txtThemeName.Text + "\";");
            sb.AppendLine("            ThemeAuthor = \"" + txtAuthor.Text + "\";");
            sb.AppendLine("            ThemeAuthorWebsite = \"" + txtAuthorWebsite.Text + "\";");
            sb.AppendLine("            ThemeAuthorEmail = \"" + txtAuthorEmail.Text + "\";");
            sb.AppendLine("            ThemeDateCreated = \"" + txtDateCreated.Text + "\";");
            sb.AppendLine();

            int count = Enum.GetNames(typeof(RibbonColorPart)).Length;
            for (int i = 0; i < count; i++)
            {
                if (ribbon1.Theme.RendererColorTable.GetColor((RibbonColorPart)i).A == 255)
                {
                    sb.AppendLine("            " + ((RibbonColorPart)i).ToString() + " = FromHex(\"" + ribbon1.Theme.RendererColorTable.GetColorHexStr((RibbonColorPart)i) + "\");");
                }
                else
                {
                    sb.AppendLine("            " + ((RibbonColorPart)i).ToString() + " = Color.FromArgb(" + ribbon1.Theme.RendererColorTable.GetColor((RibbonColorPart)i).A + ", FromHex(\"" + ribbon1.Theme.RendererColorTable.GetColorHexStr((RibbonColorPart)i) + "\"));");
                }
            }

            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine("        public Color FromHex(string hex)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (hex.StartsWith(\"#\"))");
            sb.AppendLine("                hex = hex.Substring(1);");
            sb.AppendLine();
            sb.AppendLine("            switch (hex.Length)");
            sb.AppendLine("            {");
            sb.AppendLine("                case 6:");
            sb.AppendLine("                    return Color.FromArgb(");
            sb.AppendLine("                        int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),");
            sb.AppendLine("                        int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),");
            sb.AppendLine("                        int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber));");
            sb.AppendLine("");
            sb.AppendLine("                case 8:");
            sb.AppendLine("                    return Color.FromArgb(");
            sb.AppendLine("                        int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),");
            sb.AppendLine("                        int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),");
            sb.AppendLine("                        int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber),");
            sb.AppendLine("                        int.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber));");
            sb.AppendLine("");
            sb.AppendLine("                default:");
            sb.AppendLine("                    throw new Exception(\"Color not valid\");");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");




            FormClassResult f = new FormClassResult(sb.ToString());
            f.ShowDialog();
        }

        private void btLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Multiselect = false;
            of.Filter = "ini or xml|*.ini;*.xml";
            if (of.ShowDialog() == DialogResult.OK)
            {
                txtThemeFile.Text = of.FileName;
                string a = System.IO.File.ReadAllText(of.FileName);
                string ext = System.IO.Path.GetExtension(of.FileName);
                if (ext.ToLower() == ".ini")
                    ribbon1.Theme.RendererColorTable.ReadThemeIniFile(a);
                else if (ext.ToLower() == ".xml")
                    ribbon1.Theme.RendererColorTable.ReadThemeXmlFile(a);
                LoadTheme();
            }
        }

        private void btThemeSaveIni_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog f = new SaveFileDialog();
                f.Filter = "ini|*.ini";
                if (f.ShowDialog() == DialogResult.OK)
                {
                    ribbon1.Theme.RendererColorTable.ThemeName = txtThemeName.Text;
                    ribbon1.Theme.RendererColorTable.ThemeAuthor = txtAuthor.Text;
                    ribbon1.Theme.RendererColorTable.ThemeAuthorEmail = txtAuthorEmail.Text;
                    ribbon1.Theme.RendererColorTable.ThemeAuthorWebsite = txtAuthorWebsite.Text;
                    ribbon1.Theme.RendererColorTable.ThemeDateCreated = txtDateCreated.Text;
                    string a = ribbon1.Theme.RendererColorTable.WriteThemeIniFile();
                    System.IO.File.WriteAllText(f.FileName, a, Encoding.UTF8);
                    MessageBox.Show("Saved at:\r\n" + f.FileName, "Save");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btThemeSaveXML_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog f = new SaveFileDialog();
                f.Filter = "xml|*.xml";
                if (f.ShowDialog() == DialogResult.OK)
                {
                    ribbon1.Theme.RendererColorTable.ThemeName = txtThemeName.Text;
                    ribbon1.Theme.RendererColorTable.ThemeAuthor = txtAuthor.Text;
                    ribbon1.Theme.RendererColorTable.ThemeAuthorEmail = txtAuthorEmail.Text;
                    ribbon1.Theme.RendererColorTable.ThemeAuthorWebsite = txtAuthorWebsite.Text;
                    ribbon1.Theme.RendererColorTable.ThemeDateCreated = txtDateCreated.Text;
                    string a = ribbon1.Theme.RendererColorTable.WriteThemeXmlFile();
                    System.IO.File.WriteAllText(f.FileName, a, Encoding.UTF8);
                    MessageBox.Show("Saved at:\r\n" + f.FileName, "Save");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cboChooseTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboChooseTheme.Enabled = false;

            if (cboChooseTheme.Text == "Black")
                ribbon1.Theme.RibbonTheme = RibbonTheme.Black;
            else if (cboChooseTheme.Text == "Blue_2010")
                ribbon1.Theme.RibbonTheme = RibbonTheme.Blue_2010;
            else if (cboChooseTheme.Text == "Green")
                ribbon1.Theme.RibbonTheme = RibbonTheme.Green;
            else if (cboChooseTheme.Text == "Purple")
                ribbon1.Theme.RibbonTheme = RibbonTheme.Purple;
            else if (cboChooseTheme.Text == "JellyBelly")
                ribbon1.Theme.RibbonTheme = RibbonTheme.JellyBelly;
            else if (cboChooseTheme.Text == "Halloween")
                ribbon1.Theme.RibbonTheme = RibbonTheme.Halloween;
            else
                ribbon1.Theme.RibbonTheme = RibbonTheme.Normal;

            LoadTheme();

            this.Refresh();

            cboChooseTheme.Enabled = true;
            cboChooseTheme.Focus();
        }

        private void cboOfficeStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOfficeStyle.Text == "Office 2007")
                ribbon1.OrbStyle = RibbonOrbStyle.Office_2007;
            if (cboOfficeStyle.Text == "Office 2010")
                ribbon1.OrbStyle = RibbonOrbStyle.Office_2010;
            if (cboOfficeStyle.Text == "Office 2013")
                ribbon1.OrbStyle = RibbonOrbStyle.Office_2013;

            // A hack to reapply Glass to the form when the Orb style changes
            this.Helper.ReapplyGlass();
        }

        private void ThemeBuilderForm_Load(object sender, EventArgs e)
        {
            ribbon1.OrbStyle = RibbonOrbStyle.Office_2013;
            cboOfficeStyle.Text = "Office 2010";
            cboChooseTheme.Text = "Blue_2010";
        }

        private void DummyAppButton_Click(object sender, EventArgs e)
        {
            // Get the system menu of this application
            IntPtr wMenu = WinApi.GetSystemMenu(this.Handle, false);

            // Display the menu
            uint command = WinApi.TrackPopupMenuEx(wMenu, WinApi.TPM_LEFTBUTTON | WinApi.TPM_RETURNCMD,
                this.PointToScreen(ribbon1.Bounds.Location).X, this.PointToScreen(ribbon1.Bounds.Location).Y + ribbon1.CaptionBarSize, this.Handle, IntPtr.Zero);

            if (command == 0)
                return;

            // Post a message for the menu selection
            WinApi.PostMessage(this.Handle, WinApi.WM_SYSCOMMAND, new UIntPtr(command), IntPtr.Zero);
        }

        private void DummyAppButton_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ribbonButton37_Click(object sender, EventArgs e)
        {
            ribbonContext1.Visible = !ribbonContext1.Visible;
        }


        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            ribbon1.Enabled = !ribbon1.Enabled;
        }

        private void FontEnableDisableHomeButton_Click(object sender, EventArgs e)
        {
            foreach (var item in ribbon1.Tabs)
            {
                if (item.Text == "Home")
                {
                    item.Enabled = !item.Enabled;
                    break;
                }
            }

        }
    }
}