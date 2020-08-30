using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //Сверить число из вопроса и ответ пользователя
            //Если равны то Right++ если нет, Wrong++
        }

        public string GetQuestion()
        {
            string question = "";
            /*
             * Сгенерировать 4-значное число если Level от [1 до 3]
             * 5-значное если от (3 - 7]
             * 6- значное если от (7 до 10]
             * 7-значное если больше 10
            */
            return question;
        }

        public MemorySkillWorker(SkillHolder memSkillHolder)
        {
            MemorySkillHolder = memSkillHolder;
        }
    }
}
