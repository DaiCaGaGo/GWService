namespace BusinessObjects.Models
{
    public class VietguysReceiveModel
    {
        //{"err":0,"error_code":"-5", "id":"1547021751.995.84903997997.5bd4c7e","desc":"","carrier":"mobifone"}
        public int err { get; set; }
        public string error_code { get; set; }
        public string id { get; set; }
        public string desc { get; set; }
        public string carrier { get; set; }
    }
}
