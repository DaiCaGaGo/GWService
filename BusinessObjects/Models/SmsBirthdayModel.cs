using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public class SmsBirthdayModel
    {
        public long ID { get; set; }
        public long ACCOUNT_ID { get; set; }
        public string SENDER_NAME { get; set; }
        public string SMS_CONTENT { get; set; }
        public Nullable<long> SMS_COUNT { get; set; }
        public string PARTNER_NAME { get; set; }
        public string PHONE { get; set; }
        public string TELCO { get; set; }
        public Nullable<short> IS_READ { get; set; }
        public string INSERT_TIME { get; set; }
        public string SCHEDULE_TIME { get; set; }
        public string CREATE_USER { get; set; }
        public string RECEIVE_CODE { get; set; }
        public string RECEIVE_RESULT { get; set; }
        public Nullable<long> SMS_ID { get; set; }
        public Nullable<long> GROUP_ID { get; set; }
    }
}
