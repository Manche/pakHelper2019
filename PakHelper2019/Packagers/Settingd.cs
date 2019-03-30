using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packagers
{
    /// <summary>
    /// 設定
    /// </summary>
    class Settingd
    {
        /*全般*/
        public static List<Brush> TabsColor =
            new List<Brush>() { new SolidBrush(Color.Orange),
                                new SolidBrush(Color.Turquoise),
                                new SolidBrush(Color.LightGreen),
                                new SolidBrush(Color.LightCyan),
                                new SolidBrush(Color.Khaki)};

        public static SolidBrush DefaultTextColord = new SolidBrush(System.Drawing.Color.FromArgb(80,80,80));
     }
}
