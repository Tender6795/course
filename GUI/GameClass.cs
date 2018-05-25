using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GUI
{
    public class GameClass : INotifyPropertyChanged
    {
        public string UserName { get; set; }
        public int Money { get; set; }
        public ImageSource MyShipPicture { set; get; }
        public string MyShipName { get; set; }
        public int MyDamage { get; set; }
        public int MyHealthMax { get; set; }
        public int MyHealthNow { get; set; }

        public string WeaponName { get; set; }
        public int WeaponDamage { get; set; }
        public ImageSource WeaponPicture { set; get; }

        public string ArmorName { get; set; }
        public int ArmorHealth { get; set; }
        public ImageSource ArmorPicture { set; get; }

        public string EnemyShipName { get; set; }
        public ImageSource EnemyShipPicture { set; get; }
        public int EnemyDamage { get; set; }
        public int EnemyHealthMax { get; set; }
        public int EnemyHealthNow { get; set; }
        public int EnemyCost { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

       

        internal void NotifyPropertyChanged()
        {
            PropertyChanged(this, new PropertyChangedEventArgs(""));
        }
    }
}
