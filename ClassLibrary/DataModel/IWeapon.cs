using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DataModel
{
    public interface IWeapon
    {
        int WeaponId { get; set; }
        string Name { set; get; }
        int Damage { set; get; }
        int Cost { get; set; }

        // int Attack(int coefficient);

    }
}
