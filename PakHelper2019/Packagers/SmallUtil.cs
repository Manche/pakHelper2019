using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Windows.Forms;

namespace pakHelper2019
{
    class SmallUtil
    {
        public static void GetSettings(ref TextBox dest, String confs, String chs)
        {
            try
            {
                dest.Text = Properties.Settings.Default[confs].ToString();
            }                                           
            catch(Exception ex)
            {                       
                Console.WriteLine(ex);
                return;
            }
        }

        public static void GetSettings(String confs, RadioButton ra, RadioButton rb)
        {
            try
            {
                if (TryBool(Properties.Settings.Default[confs]))
                {
                    rb.Checked = true;
                }
                else
                {
                    ra.Checked = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }
        }

        public static void SaveSettings(String confs, TextBox obj)
        {
            Properties.Settings.Default[confs] = obj.Text;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// settingに対してra(true）とrb(false)を設定する
        /// </summary>
        /// <param name="confs"></param>
        /// <param name="ra"></param>
        /// <param name="rb"></param>
        public static void SaveSettings(String confs, RadioButton ra, RadioButton rb)
        {
            Properties.Settings.Default[confs] = rb.Checked ? true : ra.Checked ? false : false;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Tryparseをベースに実行結果ではなくキャスト結果のみを返す
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// キャストが成功、かつ値がtrueの場合はtrue
        /// それ以外はfalse
        /// </returns>
        public static bool TryBool(object obj)
        {
            try
            {
                return Boolean.Parse(obj.ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
