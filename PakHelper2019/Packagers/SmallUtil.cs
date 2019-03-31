using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Windows.Forms;
using System.IO;

using Newtonsoft.Json;

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

        public static void GetSettings(String confs,ref CheckBox ck)
        {
            try
            {
                if (TryBool(Properties.Settings.Default[confs]))
                {
                    ck.Checked = true;
                }
                else
                {
                    ck.Checked = false;
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

        public static void SaveSettings(String confs, CheckBox obj)
        {
            Properties.Settings.Default[confs] = obj.Checked;
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

        public static bool CreateJsonString(ref String JsonStrings ,params String[] names)
        {
            try
            {
                var SettingsList = new List<JsonProxy>();
                SettingsList.Add(new JsonProxy { IsDefinition = true, name = JsonHeaderDefinition._OutputSettings, Val = String.Empty });

                foreach (String temp in names)
                {
                    SettingsList.Add(new JsonProxy { IsDefinition = false, name = temp, Val = Properties.Settings.Default[temp].ToString() });
                }

                JsonStrings = Newtonsoft.Json.JsonConvert.SerializeObject(SettingsList);

                return true;
            }
            catch(Exception Ex)
            {
                Console.WriteLine(Ex);
                return false;
            }
        }

        public static Boolean LoadJsonString(List<JsonProxy> jsons)
        {
            return true;
            //return Newtonsoft.Json.JsonConvert.DeserializeObject();
        }
    }

    class FSUtil
    {
        public static bool WriteFiles(String FileName, String Vals)
        {
            FileStream fStream = null;
            StreamWriter sWriter = null;
            bool RetVal = false;
            try
            {
                fStream = new FileStream(FileName,FileMode.Create);
                sWriter = new StreamWriter(fStream);
                sWriter.Write(Vals);
                RetVal = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                RetVal = false;
            }
            finally
            {
                if(sWriter != null)
                {
                    sWriter.Close();
                    sWriter.Dispose();
                }
                if(fStream != null)
                {
                    fStream.Close();
                    fStream.Dispose();
                }
            }
            return RetVal;
        }
    }
}
