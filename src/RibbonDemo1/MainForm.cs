using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace RibbonDemo
{
    public partial class MainForm : RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
            InitLists();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private Color GetRandomColor(Random r)
        {
            if (r == null)
            {
                r = new Random(DateTime.Now.Millisecond);
            }

            return Color.FromKnownColor((KnownColor)r.Next(1, 150));
        }

        private void InitLists()
        {
            Image[] images = new Image[255];
            RibbonProfessionalRenderer rend = new RibbonProfessionalRenderer(this.ribbon1);
            BackColor = Theme.ColorTable.RibbonBackground;
            Random r = new Random();

            #region Color Squares
            using (GraphicsPath path = RibbonProfessionalRenderer.RoundRectangle(new Rectangle(3, 3, 26, 26), 4))
            {
                using (GraphicsPath outer = RibbonProfessionalRenderer.RoundRectangle(new Rectangle(0, 0, 32, 32), 4))
                {
                    for (int i = 0; i < images.Length; i++)
                    {
                        Bitmap b = new Bitmap(32, 32);

                        using (Graphics g = Graphics.FromImage(b))
                        {
                            g.SmoothingMode = SmoothingMode.AntiAlias;

                            using (SolidBrush br = new SolidBrush(Color.FromArgb(255, i * (255 / images.Length), 0)))
                            {
                                g.FillPath(br, path);
                            }

                            using (Pen p = new Pen(Color.White, 3))
                            {
                                g.DrawPath(p, path);
                            }

                            g.DrawPath(Pens.Wheat, path);

                            g.DrawString(Convert.ToString(i + 1), Font, Brushes.White, new Point(10, 10));
                        }

                        images[i] = b;

                        RibbonButton btn = new RibbonButton();
                        btn.Image = b;
                        lst.Buttons.Add(btn);
                    }
                }
            }

            //lst.DropDownItems.Add(new RibbonSeparator("Available styles"));
            RibbonButtonList lst2 = new RibbonButtonList();

            for (int i = 0; i < images.Length; i++)
            {
                RibbonButton btn = new RibbonButton();
                btn.Image = images[i];
                lst2.Buttons.Add(btn);
            }
            lst.DropDownItems.Add(lst2);
            lst.DropDownItems.Add(new RibbonButton("Save selection as a new quick style..."));
            lst.DropDownItems.Add(new RibbonButton("Erase Format"));
            lst.DropDownItems.Add(new RibbonButton("Apply style...")); 
            #endregion

            #region Theme Colors

            RibbonButton[] buttons = new RibbonButton[30];
            int square = 16;
            int squares = 4;
            int sqspace = 2;

            for (int i = 0; i < buttons.Length; i++)
            {
                #region Create color squares
                Bitmap colors = new Bitmap((square + sqspace) * squares, square + 1);
                string[] colorss = new string[squares];
                using (Graphics g = Graphics.FromImage(colors))
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Color sqcolor = GetRandomColor(r);
                        colorss[j] = sqcolor.Name;
                        using (SolidBrush b = new SolidBrush(sqcolor))
                        {
                            g.FillRectangle(b, new Rectangle(j * (square + sqspace), 0, square, square));
                        }
                        g.DrawRectangle(Pens.Gray, new Rectangle(j * (square + sqspace), 0, square, square));
                    }
                } 
                #endregion

                buttons[i] = new RibbonButton(colors);
                buttons[i].Text = string.Join(", ", colorss); ;
                buttons[i].MaxSizeMode = RibbonElementSizeMode.Medium;
                buttons[i].MinSizeMode = RibbonElementSizeMode.Medium;
            }
            RibbonButtonList blst = new RibbonButtonList(buttons);
            blst.FlowToBottom = false;
            blst.ItemsSizeInDropwDownMode = new Size(1, 10);
            itemColors.DropDownItems.Insert(0, blst);
            itemColors.DropDownResizable = true;

            #endregion

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void ribbonOrbOptionButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ribbonButton2_Click(object sender, EventArgs e)
        {
           //Console.WriteLine("clicked");
           TestForm t = new TestForm();
           t.ShowDialog(this);
        }

        private void ribbonButton5_Click(object sender, EventArgs e)
        {
           //Console.WriteLine("clicked");
           TestForm t = new TestForm();
           t.Show(this);
        }

        public void toggleQuickAccessButton(RibbonButton dropDownButton, RibbonButton quickAccessButton)
        {
            if (quickAccessButton.Visible)
            {
                dropDownButton.SmallImage = global::RibbonDemo.Properties.Resources.unchecked16;
                quickAccessButton.Visible = false;
            }
            else
            {
                dropDownButton.SmallImage = global::RibbonDemo.Properties.Resources.exit16;
                quickAccessButton.Visible = true;
            } // if / else
        } // toggleQuickAccessButton

        private void dropDownButtonSave_Click(object sender, EventArgs e)
        {
            toggleQuickAccessButton(sender as RibbonButton, ribbonButton42);
        }

        private void dropDownButtonPrint_Click(object sender, EventArgs e)
        {
            toggleQuickAccessButton(sender as RibbonButton, ribbonButton43);
        }

        private void dropDownButtonUndo_Click(object sender, EventArgs e)
        {
            toggleQuickAccessButton(sender as RibbonButton, ribbonButton44);
        }

        private void dropDownButtonOpen_Click(object sender, EventArgs e)
        {
            toggleQuickAccessButton(sender as RibbonButton, ribbonButton45);
        }
    }
}