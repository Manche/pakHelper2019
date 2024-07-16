using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

using System.IO;

namespace pakHelper2019
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
            Opacity = 0;
            ControlBox = false;

            this.LoadDefaultSettings();
        }

        private void LoadSettings(bool Desinare = false, string Path = "")
        {
            try
            {
                if (Desinare)
                {
                    if (Path == "")
                    {
                        // 対象がない
                        return;
                    }
                    if (!File.Exists(Path))
                    {
                        return;
                    }
                    try
                    {
                        String strF = FSUtil.ReadFiles(Path);
                        List<JsonProxy> objProxy = new List<JsonProxy>();
                        objProxy = SmallUtil.LoadJsonString(strF);
                        Console.WriteLine(strF);
                        Console.WriteLine(objProxy.Count());
                        foreach(JsonProxy objTmpProxy in objProxy)
                        {
                            if (objTmpProxy.IsDefinition)
                            {
                                continue;
                            }

                            Console.WriteLine(objTmpProxy.name);

                            switch (objTmpProxy.Types.ToString())
                            {
                                case "System.String":
                                    SmallUtil.SaveSettings(objTmpProxy.name, objTmpProxy.Val);
                                    break;
                                case "System.Integer":
                                    SmallUtil.SaveSettings(objTmpProxy.name, ObjTrys.TryInt(objTmpProxy.Val));
                                    break;
                                case "System.Boolean":
                                    SmallUtil.SaveSettings(objTmpProxy.name, ObjTrys.TryBool(objTmpProxy.Val));
                                    break;
                                default:
                                    //SmallUtil.SaveSettings(objTmpProxy.name, objTmpProxy.Val);
                                    break;
                            }

                        }
                        /*`
                        SmallUtil.SaveSettings(objProxy(Settingd._Makeobjpath), this.textBox1);
                        SmallUtil.SaveSettings(objProxy(Settingd._Pakpath), this.textBox2);
                        SmallUtil.SaveSettings(objProxy(Settingd._Extractpath), this.textBox3);
                        SmallUtil.SaveSettings(objProxy(Settingd._Mergepath), this.textBox4);
                        SmallUtil.SaveSettings(objProxy(Settingd._UseMakeobjSamepath), this.radioButton1, this.radioButton2);
                        SmallUtil.SaveSettings(objProxy(Settingd._UsePakSamepath), this.radioButton3, this.radioButton4);
                        SmallUtil.SaveSettings(objProxy(Settingd._UseExtractSamepath), this.radioButton5, this.radioButton6);
                        SmallUtil.SaveSettings(objProxy(Settingd._UseMergeSamepath), this.radioButton7, this.radioButton8);
                        */
                        this.LoadDefaultSettings();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                else
                {
                    this.LoadDefaultSettings();
                }
            }
            catch(Exception ex)
            {
                this.LoadDefaultSettings();
                Console.WriteLine(ex);
            }
        }

        private void LoadDefaultSettings()
        {
            SmallUtil.GetSettings(ref this.textBox1, Settingd._Makeobjpath, Settingd._UseMakeobjSamepath);
            SmallUtil.GetSettings(ref this.textBox2, Settingd._Pakpath, Settingd._UsePakSamepath);
            SmallUtil.GetSettings(ref this.textBox3, Settingd._Extractpath, Settingd._UseExtractSamepath);
            SmallUtil.GetSettings(ref this.textBox4, Settingd._Mergepath, Settingd._UseMergeSamepath);
            SmallUtil.GetSettings(Settingd._UseMakeobjSamepath, this.radioButton1, this.radioButton2);
            SmallUtil.GetSettings(Settingd._UsePakSamepath, this.radioButton3, this.radioButton4);
            SmallUtil.GetSettings(Settingd._UseExtractSamepath, this.radioButton5, this.radioButton6);
            SmallUtil.GetSettings(Settingd._UseMergeSamepath, this.radioButton7, this.radioButton8);
        }

        private void SaveSettings(String FilePath)
        {
            String JsonStrings = "";
            if (SmallUtil.CreateJsonString(ref JsonStrings,
                                        Settingd._Makeobjpath, 
                                        Settingd._Pakpath, 
                                        Settingd._Extractpath, 
                                        Settingd._Mergepath,
                                        Settingd._UseMakeobjSamepath,
                                        Settingd._UsePakSamepath,
                                        Settingd._UseExtractSamepath,
                                        Settingd._UseMergeSamepath))
            {
                if(FSUtil.WriteFiles(FilePath, JsonStrings))
                {
                }
                else
                {
                }
            }
        }


        #region "アニメータ"
        private void pakHelperOptions_Load(object sender, EventArgs e)
        {
            Animator.Animate(150, (frame, frequency) =>
            {
                if (!Visible || IsDisposed) return false;
                Opacity = (double)frame / frequency;
                Console.WriteLine(Opacity);
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
            Console.WriteLine("閉じる");
            Animator.Animate(150, (frame, frequency) =>
            {
                Console.WriteLine(frame + "|" + frequency);
                //if (!Visible || IsDisposed) return false;
                Opacity = 1 - (double)frame / frequency;
                Console.WriteLine(Opacity);
                return true;
            });

            this.Close();
        }


        #endregion

        #region "イベント他"
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            SmallUtil.SaveSettings(Settingd._Makeobjpath, this.textBox1);
            SmallUtil.SaveSettings(Settingd._Pakpath, this.textBox2);
            SmallUtil.SaveSettings(Settingd._Extractpath, this.textBox3);
            SmallUtil.SaveSettings(Settingd._Mergepath, this.textBox4);
            SmallUtil.SaveSettings(Settingd._UseMakeobjSamepath, this.radioButton1, this.radioButton2);
            SmallUtil.SaveSettings(Settingd._UsePakSamepath, this.radioButton3, this.radioButton4);
            SmallUtil.SaveSettings(Settingd._UseExtractSamepath, this.radioButton5, this.radioButton6);
            SmallUtil.SaveSettings(Settingd._UseMergeSamepath, this.radioButton7, this.radioButton8);
            this.canBeClose = true;
            this.pakHelperOptions_FormBeforeClosing();
        }
        #endregion

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog browse = new FolderBrowserDialog();
            browse.SelectedPath=this.textBox1.Text;
            if (browse.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = browse.SelectedPath;
            }
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog browse = new FolderBrowserDialog();
            browse.SelectedPath = this.textBox2.Text;
            if (browse.ShowDialog() == DialogResult.OK)
            {
                this.textBox2.Text = browse.SelectedPath;
            }
        }

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog browse = new FolderBrowserDialog();
            browse.SelectedPath = this.textBox3.Text;
            if (browse.ShowDialog() == DialogResult.OK)
            {
                this.textBox3.Text = browse.SelectedPath;
            }
        }

        private void button5_MouseClick(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog browse = new FolderBrowserDialog();
            browse.SelectedPath = this.textBox4.Text;
            if (browse.ShowDialog() == DialogResult.OK)
            {
                this.textBox4.Text = browse.SelectedPath;
            }
        }

        private void button6_MouseClick(object sender, MouseEventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.SaveSettings(saveFileDialog1.FileName);
            }
        }

        private void bunSettingLoad_MouseClick(object sender, MouseEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.LoadSettings(true, openFileDialog1.FileName);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine(sender.ToString());
            RadioButton rd = (RadioButton)sender;
            Console.WriteLine(rd.Name);
        }

        private void pakHelperOptions_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
