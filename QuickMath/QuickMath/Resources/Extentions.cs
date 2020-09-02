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
        public static int IndexOf(this string self, params char[] chars)
        {
            if (self.ToArray().Any(c => c.IsOneOf(chars)) == false) return -1;
            for (int i = 0; i < self.Length; i++)
            {
                for (int j = 0; j < chars.Length; j++)
                {
                    if (self[i] == chars[i])
                        return i;
                }
            }
            return -1;
        }
    }
}
