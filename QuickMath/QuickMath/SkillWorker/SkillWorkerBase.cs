using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuickMath.UserData;

namespace QuickMath.SkillWorker
{
    abstract class SkillWorkerBase
    {
        protected int Level
        {
            get => skillHolder.Level;
        }
        private SkillHolder skillHolder;
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
        public SkillWorkerBase(SkillHolder skillHolder)
        {
            this.skillHolder = skillHolder;
        }
    }
}
