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

namespace Packagers
{
    public partial class pakHelperOptions : MetroForm   
    {
        private int formXsize = 0;
        private int formYsize = 0;

        /// <summary>
        /// このフォームが閉じられることを許可する
        /// </summary>
        private Boolean canBeClose = false;

        public pakHelperOptions()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            this.formXsize = this.Width;
            this.formYsize = this.Height;

            ControlBox = false;
        }


        #region "アニメータ"
        private void pakHelperOptions_Load(object sender, EventArgs e)
        {
            Animator.Animate(250, (frame, frequency) =>
            {
                this.SuspendLayout();
                if (!Visible || IsDisposed) return false;
                Console.WriteLine(frame * frequency + "m" + frame + "," + frequency);
                this.Height = this.formYsize / frequency * frame;
                this.ResumeLayout();
                return true;
            });
        }

        private void pakHelperOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!canBeClose)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 閉じる時のアニメーションがやりたいだけ
        /// </summary>
        private void pakHelperOptions_FormBeforeClosing()
        {
        }


        #endregion

        #region "イベント他"
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            this.canBeClose = true;
            this.pakHelperOptions_FormBeforeClosing();
            this.Close();
        }
        #endregion
    }
}
