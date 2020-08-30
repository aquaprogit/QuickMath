using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMath.SkillWorker
{
    abstract class SkillWorkerBase
    {
        public int Level { get; protected set; }
        public int Right { get; protected set; }
        public int Wrong { get; protected set; }
        public double Mark
        {
            get {
                int answersGiven = Right + Wrong;

                double mark = (Right / answersGiven) * 12.0D;
                return mark;
            }
        }
    }
}
