using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DataModel
{
    public class ResultTable
    {
        public int ResultTableId { get; set; }
        public int Victory { get; set; }
        public int Lose { get; set; }
        public int Draw { get; set; }//Ничья
    }
}
