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
        /// settingに対してboolをRAWで設定する
        /// </summary>
        /// <param name="confs"></param>
        /// <param name="ra"></param>
        /// <param name="rb"></param>
        public static void SaveSettings(String confs, Boolean flg)
        {
            Properties.Settings.Default[confs] = flg;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// settingに対して直接値を入れる
        /// </summary>
        /// <param name="confs"></param>
        /// <param name="vals"></param>
        public static void SaveSettings(String confs, String vals)
        {
            Properties.Settings.Default[confs] = vals;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// settingに対して直接値を入れる
        /// </summary>
        /// <param name="confs"></param>
        /// <param name="vals"></param>
        public static void SaveSettings(String confs, int nums)
        {
            Properties.Settings.Default[confs] = nums;
            Properties.Settings.Default.Save();
        }

        public static bool CreateJsonString(ref String JsonStrings ,params String[] names)
        {
            try
            {
                var SettingsList = new List<JsonProxy>();
                SettingsList.Add(new JsonProxy { IsDefinition = true, name = JsonHeaderDefinition._OutputSettings, Val = String.Empty, Types = String.Empty });

                foreach (String temp in names)
                {
                    SettingsList.Add(new JsonProxy { IsDefinition = false, name = temp, Val = Properties.Settings.Default[temp].ToString() , Types = Properties.Settings.Default[temp].GetType().ToString()});
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

        public static List<JsonProxy> LoadJsonString(String jsonStr)
        {
            var SettingsList = new List<JsonProxy>();
            // 読み込み
            try
            {
                Newtonsoft.Json.Linq.JArray JsonStrings = (Newtonsoft.Json.Linq.JArray)JsonConvert.DeserializeObject(jsonStr);
                for (int n = 0;  n < JsonStrings.Count ; n++)
                {
                    object objJ = JsonStrings[n];
                    SettingsList.Add(new JsonProxy { IsDefinition = bool.Parse(JsonStrings[n].Value<string>("IsDefinition")),name = JsonStrings[n].Value<string>("name"),Val= JsonStrings[n].Value<string>("Val"), Types = JsonStrings[n].Value<string>("Types") });
                }
                
            }
            catch(Exception Ex)
            {
                Console.Write(Ex);
            }
            return SettingsList;
            //return Newtonsoft.Json.JsonConvert.DeserializeObject();
        }

        /// <summary>
        /// Tryparseをベースに実行結果ではなくキャスト結果のみを含めて
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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }

    class FSUtil
    {
        /// <summary>
        /// ファイルの書き出し
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="Vals"></param>
        /// <returns></returns>
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

        /// <summary>
        /// ファイルの読み込み
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static string ReadFiles(String FileName)
        {
            FileStream fStream = null;
            StreamReader sReader = null;
            String val = ""; //ファイルの中身
            if (FileName == "")
            {
                return val;
            }
            if (!File.Exists(FileName))
            {
                return val;
            }

            try
            {
                fStream = new FileStream(FileName, FileMode.Open);
                sReader = new StreamReader(fStream);
                foreach (char tmp in sReader.ReadToEnd())
                {
                    val += tmp;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                val = "";
            }
            finally
            {
                if(sReader != null)
                {
                    sReader.Close();
                    sReader.Dispose();
                }
                if (fStream != null)
                {
                    fStream.Close();
                    fStream.Dispose();
                }
            }

            return val;
            
        }
    }

    public class ObjTrys
    {
        /// <summary>
        /// Tryparseをベースに実行結果ではなくキャスト結果のみを含めて
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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        /// <summary>
        /// Tryparseをベースに実行結果ではなくキャスト結果のみを含めて
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// キャストが成功、かつ値がtrueの場合はtrue
        /// それ以外はfalse
        /// </returns>
        public static int TryInt(object obj)
        {
            try
            {
                return int.Parse(obj.ToString());
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}