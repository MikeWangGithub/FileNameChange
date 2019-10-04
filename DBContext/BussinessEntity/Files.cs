using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCNDBContext.BussinessEntity
{
    public class Files
    {
        public int ID { get; set; }
        public int CheckID { get; set; }
        public DateTime  CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public string FileName { get; set; }
        public string FileFullName { get; set; }
        public string FilePath { get; set; }
        public string Extension { get; set; }
        public bool IsValid { get; set; }
        public int Size { get; set; }
        public string Size_Abbreviation { get; set; }
       
        public string Memo { get; set; }

        public virtual Check _check { get; set; }


    }
}
