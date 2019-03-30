using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Packagers
{
    /// <summary>
    /// 設定
    /// </summary>
    class Settingd
    {
        /*全般*/

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
     }

}
