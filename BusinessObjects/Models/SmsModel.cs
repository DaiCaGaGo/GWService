namespace BusinessObjects.Models
{
    public class SmsModel
    {
        public long ID;
        public string SENDER_NAME;
        public string SMS_TYPE; // CSKH or QC
        public string SMS_CONTENT;
        public string IS_UNICODE; // 0 or 1 gửi ký tự đặc biệt
        public string PARTNER_NAME;
        public string PHONE;
        public string TELCO;
        public string COUNT_RETRY; // Tối đa default 5
        public string SCHEDULE_TIME; // Thời gian gửi
        public string CAMPAIGN_ID;  // Mã đơn hàng quảng cáo
        public string SENDBY; // SMPP or API
        public string DLVR; // 1 or 0

        public string URL_HTTP_1_CSKH;
        public string URL_HTTP_2_CSKH;
        public string URL_HTTP_3_CSKH;
        public string HTTP_USER_CSKH;
        public string HTTP_PASS_CSKH;
        public string HTTP_ENCODE_CSKH; // HttpUtility.UrlEncode

        public string SMPP_IP_1;
        public string SMPP_IP_2;
        public string SMPP_PORT_1;
        public string SMPP_PORT_2;
        public string SMPP_USER;
        public string SMPP_PASS;

        public string URL_HTTP_1_QC;
        public string URL_HTTP_2_QC;
        public string URL_HTTP_3_QC;
        public string HTTP_USER_QC;
        public string HTTP_PASS_QC;
        public string HTTP_ENCODE_QC;

        public int ERR_CODE; // Mã lỗi của hệ thống
        public int ERR_CODE_PARTNER; // Mã lỗi nhận từ đối tác
        public string RECEIVE_RESULT; // Message nhận từ đối tác

        public long ACCOUNT_ID;
        public int SMS_COUNT;
        public string VIA;
        //public long GROUP_ID;
    }
}
