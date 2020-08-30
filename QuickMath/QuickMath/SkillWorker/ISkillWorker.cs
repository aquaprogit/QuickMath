using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMath.SkillWorker
{
    interface ISkillWorker
    {
        string GetQuestion();

        void CheckAnswer(string question, string userAnswer);
    }
}
