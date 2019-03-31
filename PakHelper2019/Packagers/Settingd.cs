using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace pakHelper2019
{
    /// <summary>
    /// 設定
    /// </summary>
    public static class Settingd
    {
        /*全般*/

        public static String _AppRootPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

        /// <summary>
        /// タブ色
        /// </summary>
        public static List<Brush> TabsColor =
        new List<Brush>() { new SolidBrush(Color.Orange),
                            new SolidBrush(Color.Turquoise),
                            new SolidBrush(Color.LightGreen),
                            new SolidBrush(Color.LightCyan),
                            new SolidBrush(Color.Khaki)};
            
        /// <summary>
        /// タブの文字色
        /// </summary>
        public static SolidBrush DefaultTextColord = new SolidBrush(System.Drawing.Color.FromArgb(80,80,80));

        /// <summary>
        /// タブボーダー色
        /// </summary>
        public static SolidBrush DefaultTabBorderColor = new SolidBrush(System.Drawing.Color.FromArgb(0,0,0));

        public static String _UseMakeobjSamepath = "UseMakeobjSamepath";
        public static String _UsePakSamepath = "UsePakSamepath";
        public static String _UseExtractSamepath = "UseExtractSamepath";
        public static String _UseMergeSamepath = "UseMergeSamepath";

        public static String _UseMakeobjRelative = "UseMakeobjRelative";
        public static String _UsePakRelative = "UsePakRelative";
        public static String _UseExtractRelative = "UseExtractRelative";
        public static String _UseMergeRelative = "UseMergeRelative";

        public static String _Makeobjpath = "Makeobjpath";
        public static String _Pakpath = "Pakpath";
        public static String _Extractpath = "Extractpath";
        public static String _Mergepath = "Mergepath";
    }

    /// <summary>
    /// Jsonヘッダ
    /// </summary>
    public static class JsonHeaderDefinition
    {
        public static String _OutputSettings = "OutputSettings";
    }

}
