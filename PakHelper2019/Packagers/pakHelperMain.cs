﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Windows.Forms.VisualStyles;

using System.IO;

namespace pakHelper2019
{
    public partial class pakHelperMain : MetroForm
    {

        private string inputDatPath = "";
        private string inputDatFile = "";


        public pakHelperMain(string verInfo = "")
        {
            InitializeComponent();
            Opacity = 0;
            this.label4.Text = "version:" + verInfo;
        }

        #region "WindowManage"
        private void ShowSettingWindow()
        {
            pakHelperOptions subWindow = new pakHelperOptions();
            subWindow.Owner = this;
            subWindow.Size = this.Size;
            subWindow.SetDesktopLocation(this.DesktopLocation.X, this.DesktopLocation.Y);
            subWindow.StartPosition = FormStartPosition.CenterParent;
            subWindow.ShowDialog();
        }
        #endregion

        #region "Events"
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tb = (TabControl)sender;
            string txt = tb.TabPages[e.Index].Text;

            Brush foreBrush, backBrush;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                foreBrush = Settingd.DefaultTextColord;
                backBrush = Settingd.TabsColor[e.Index];
            }
            else
            {
                foreBrush = Brushes.Black;
                backBrush = Brushes.White;
            }
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            e.Graphics.FillRectangle(backBrush, e.Bounds);
            e.Graphics.DrawString(txt, e.Font, foreBrush, e.Bounds, sf);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Animator.Animate(150, (frame, frequency) =>
            {
                if (!Visible || IsDisposed) return false;
                Opacity = (double)frame / frequency;
                return true;
            });
        }

        private void Form1_Enter(object sender, EventArgs e)
        {
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox2.Text = openFileDialog1.SafeFileName;
                this.inputDatPath = Path.GetDirectoryName(openFileDialog1.FileName);
                this.textBox3.Text = inputDatPath;
                this.folderBrowserDialog1.SelectedPath = inputDatPath;
                this.inputDatFile = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
            }
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox3.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBox4.Text = this.inputDatFile + ".pak";
        }
        #endregion

        private void button5_MouseClick(object sender, MouseEventArgs e)
        {
            ShowSettingWindow();
        }

        /// <summary>
        /// pakボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            Console.WriteLine("relativemakeobjpath:" + SmallUtil.TryBool(Properties.Settings.Default[Settingd._UseMakeobjRelative]));
            Console.WriteLine("makeobjpath:" + Properties.Settings.Default[Settingd._Makeobjpath]);
            if (SmallUtil.TryBool(Properties.Settings.Default[Settingd._UseMakeobjRelative]) == true && (String)Properties.Settings.Default[Settingd._Makeobjpath] == "")
            {
                MessageBox.Show( Properties.Resources.makeobjpath_default, "Configuration Error",MessageBoxButtons.OK ,MessageBoxIcon.Exclamation);
                SmallUtil.SaveSettings(Settingd._Makeobjpath, Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            }
            if (Settingd._Pakpath == "")
            {
                MessageBox.Show("Use default makeobj path (path of this application).", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (Settingd._Extractpath == "")
            {
                MessageBox.Show("Use default makeobj path (path of this application).", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (Settingd._Mergepath == "")
            {
                MessageBox.Show("Use default makeobj path (path of this application).", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (Settingd._UseMakeobjSamepath == "")
            {
            }
            if (Settingd._UsePakSamepath == "")
            {
            }
            if (Settingd._UseExtractSamepath == "")
            {
            }
            if (Settingd._UseMergeSamepath == "")
            {
            }
        }
    }
}
