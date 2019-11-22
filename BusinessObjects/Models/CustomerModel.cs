using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public class CustomerModel
    {
        public int? STT { get; set; }
        public string USER_NAME { get; set; }
        public long ID { get; set; }
        public long ACCOUNT_ID { get; set; }
        public string DANH_XUNG { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string FULL_NAME { get; set; }
        public string ADDRESS { get; set; }
        public string DESCRIPTION { get; set; }
        public string PHONE { get; set; }
        public string EMAIL { get; set; }
        public string BIRTHDAY { get; set; }
        public Nullable<short> BIRTHDAY_PRODUCT { get; set; }
        public string CREATE_DATE { get; set; }
        public string CREATE_USER { get; set; }
        public string EDIT_DATE { get; set; }
        public string EDIT_USER { get; set; }
        public string TELCO { get; set; }
        public Nullable<long> GROUP_ID { get; set; }
        public string MONTH_SEND { get; set; }
        public string DAY_SEND { get; set; }
        public string HOUR_SEND { get; set; }
        public string SMS_SEND { get; set; }
        public string SENDER_NAME { get; set; }
    }
}
