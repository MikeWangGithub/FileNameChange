using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCNDBContext.BussinessEntity
{
    public class Check
    {
        public int ID { get; set; }
        public String  Name { get; set; }
        public DateTime CreateDate { get; set; }

        public String CheckDirectory { get; set; }
        public int Total { get; set; }
        public int Valid { get; set; }
        public int Invalid { get; set; }
        public virtual List<Files> _fileslist { get; set; }
    }
}
