using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuickMath.UserData
{
    internal class SkillHolder : INotifyPropertyChanged
    {
        private const int targetExp = 100;
        private int level = 1;
        private int exp = 0;

        public int Level
        {
            get => level;
            private set {
                level = value;
                OnPropertyChanged();
            }
        }
        public int Exp
        {
            get => exp;
            set {
                exp = value;
                if (exp >= targetExp)
                {
                    do
                    {
                        exp -= targetExp;
                        Level++;
                    } while (exp >= targetExp);
                }
                else if (exp < 0)
                {
                    do
                    {
                        exp += targetExp;
                        Level--;
                    } while (exp < 0);
                }
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}