using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DataModel
{
    // using Machine_Gun_Damage =int ;

    public class Weapon : IWeapon
    {
        public int WeaponId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Cost { get; set; }
        public byte[] Picture { set; get; }
      //  public StarShip StarShip { get; set; }
    }
}
