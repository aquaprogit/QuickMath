using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMath.Resources
{
    public static class Extentions
    {
        public static int ToInt32<T>(this T self)
        {
            return Convert.ToInt32(self);
        }
        public static bool IsOneOf<T>(this T self, params T[] coll)
        {
            return coll.Contains(self);
        }

    }
}
