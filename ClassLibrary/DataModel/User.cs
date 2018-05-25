using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DataModel
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public byte[] Password { get; set; }
        public int Money { get; set; }
        public int RoleId { get; set; }
        public int StarShipId { get; set; }
        public Role Role { get; set; }
        public ICollection<StarShip> StarShips { set; get; }
        public ICollection<ResultTable> ResultTables { set; get; }
    }
}
