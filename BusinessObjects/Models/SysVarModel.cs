using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public class SysVarModel
    {
        public long ID { get; set; }
        public string VAR_GROUP { get; set; }
        public string VAR_NAME { get; set; }
        public string VAR_VALUE { get; set; }
        public string DESCRIPTION { get; set; }
        public int? STT { get; set; }
        public int? TOTAL { get; set; }
        public Nullable<int> ORDER_NUM { get; set; }
    }
}
