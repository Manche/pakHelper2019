using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Windows.Forms.VisualStyles;

using System.IO;

namespace Packagers
{
    public partial class Form1 : MetroForm
    {

        public Form1()
        {
            InitializeComponent();
            Opacity = 0;
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tb = (TabControl)sender;
            string txt = tb.TabPages[e.Index].Text;

            Brush foreBrush, backBrush;
            if((e.State & DrawItemState.Selected) == DrawItemState.Selected){
                foreBrush = Settingd.DefaultTextColord;
                backBrush = Settingd.TabsColor[e.Index];
            }
            else{
                foreBrush = Brushes.Black;
                backBrush = Brushes.White;
            }
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            e.Graphics.FillRectangle(backBrush,e.Bounds);
            e.Graphics.DrawString(txt,e.Font,foreBrush,e.Bounds,sf);
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
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox2.Text = openFileDialog1.FileName;
            }
        }
    }
}
