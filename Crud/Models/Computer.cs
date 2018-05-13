using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Models
{
    public class Computer
    {
        public int id { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string motherBoard { get; set; }
        public string ram { get; set; }
        public string hd { get; set; }
        public double cpu { get; set; }
        public string image { get; set; }

    }
}
