using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DataModel
{
  public  class EnemyShip
    {
        public int EnemyShipId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Money { get; set; }
        public byte[] Picture { set; get; }
    }
}
