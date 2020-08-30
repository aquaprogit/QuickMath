using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using QuickMath.SkillWorker;
using QuickMath.UserData;

namespace QuickMath
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MemorySkillWorker memorySkillWorker = new MemorySkillWorker(new SkillHolder() {Exp = 300});
            Debug.WriteLine(memorySkillWorker.GetQuestion());



        }
    }
}   
