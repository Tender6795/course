using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DataModel
{
    public class Armor : IArmor
    {
        public int ArmorId { get; set ; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int Life { get; set; }
        public int Cost { get; set; }
        public byte[] Picture { set; get; }
        //public StarShip StarShip { get; set; }
    }
}
