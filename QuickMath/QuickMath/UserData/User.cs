 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuickMath.UserData
{
    internal class User : INotifyPropertyChanged
    {
        private SkillHolder mathSkillHolder, memorySkillHolder;
        public SkillHolder MathSkillHolder
        {
            get => mathSkillHolder;
            private set {
                mathSkillHolder = value;
                OnPropertyChanged();
            }
        }
        public SkillHolder MemorySkillHolder
        {
            get => memorySkillHolder;
            private set {
                memorySkillHolder = value;
                OnPropertyChanged();
            }
        }

        public User()
        {
            MathSkillHolder = new SkillHolder();
            MemorySkillHolder = new SkillHolder();
            MathSkillHolder.PropertyChanged += MathSkillHolder_PropertyChanged;
            MemorySkillHolder.PropertyChanged += MemorySkillHolder_PropertyChanged;
        }

        private void MemorySkillHolder_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("MemorySkillHolder");
        }

        private void MathSkillHolder_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("MathSkillHolder");
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 
