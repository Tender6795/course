using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DataModel
{
    public class StarShip
    {
        public int StarShipId { get; set; }
        [MaxLength(100)]
        public string Name{ get;set;}
        public int Cost { get; set; }
        public int Coefficient { get; set; }
        public byte[] Picture { set; get; }

        public int ? ArmorId { get; set; }
        public int ? WeaponId { get; set; }
       
        public ICollection<Weapon> Weapons { set; get; }
        public ICollection<Armor> Armors { set; get; }
    }
}

