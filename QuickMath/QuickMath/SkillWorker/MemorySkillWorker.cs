using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using QuickMath.UserData;

namespace QuickMath.SkillWorker
{
    class MemorySkillWorker : SkillWorkerBase, ISkillWorker
    {
        private int Level
        {
            get => MemorySkillHolder.Level;
        }
        private SkillHolder MemorySkillHolder;
        public void CheckAnswer(string question, string userAnswer)
        {
            if (question == userAnswer)
                Right++;
            else
                Wrong++;
        }

        public string GetQuestion()
        {
            int question;
            Random r = new Random();
            if (Level <= 3)
                question = r.Next(1000, 10000);
            else if (Level < 7)
                question = r.Next(10000, 100000);
            else if (Level <10)
                question = r.Next(100000, 1000000);
            else
                question = r.Next(1000000, 10000000);
            return question.ToString();
        }

        public MemorySkillWorker(SkillHolder memSkillHolder)
        {
            MemorySkillHolder = memSkillHolder;
        }
    }
}
