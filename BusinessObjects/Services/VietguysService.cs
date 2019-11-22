using BusinessObjects.Supports;
using log4net;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Web.Services.WebServiceBindingAttribute(Name = "VietguysServiceBinding", Namespace = "sms")]
public partial class VietguysService : System.Web.Services.Protocols.SoapHttpClientProtocol
{
    private readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    private System.Threading.SendOrPostCallback sendOperationCompleted;

    /// <remarks/>
    public VietguysService(string url = "http://cloudsms.vietguys.biz:8090/webservices/sendsmsw.php")
    {
        this.Url = url;
    }

    /// <remarks/>
    public event SendCompletedEventHandler sendCompleted;

    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("send", RequestNamespace = "sms", ResponseNamespace = "sms")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public string send(SmsInfo sms)
    {
        object[] results = this.Invoke("send", new object[] { sms });
        return ((string)(results[0]));
    }

    /// <remarks/>
    public System.IAsyncResult Beginsend(SmsInfo sms, System.AsyncCallback callback, object asyncState)
    {
        return this.BeginInvoke("send", new object[] { sms }, callback, asyncState);
    }

    /// <remarks/>
    public string Endsend(System.IAsyncResult asyncResult)
    {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }

    /// <remarks/>
    public void sendAsync(SmsInfo sms)
    {
        this.sendAsync(sms, null);
    }

    /// <remarks/>
    public void sendAsync(SmsInfo sms, object userState)
    {
        if ((this.sendOperationCompleted == null))
        {
            this.sendOperationCompleted = new System.Threading.SendOrPostCallback(this.OnsendOperationCompleted);
        }
        this.InvokeAsync("send", new object[] {
                    sms}, this.sendOperationCompleted, userState);
    }

    private void OnsendOperationCompleted(object arg)
    {
        if ((this.sendCompleted != null))
        {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.sendCompleted(this, new SendCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }

    /// <remarks/>
    public new void CancelAsync(object userState)
    {
        base.CancelAsync(userState);
    }

    /// <summary>
    /// Gửi tin CSKH
    /// Url: https://cloudsms.vietguys.biz:4438/api/index.php
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <param name="sender"></param>
    /// <param name="phone"></param>
    /// <param name="sms"></param>
    /// <returns></returns>
    public async Task<int> SendSMS_CSKHAsync(string username, string password, string sender, string phone, string sms)
    {
        try
        {
            WebRequest webRequest = WebRequest.Create(string.Format(@"{0}?u={1}&pwd={2}&from={3}&phone={4}&sms={5}&bid=1&type=&json=", this.Url, username, password, sender, phone, sms));

            using (StreamReader reader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
            {
                string result = await reader.ReadToEndAsync();
                logger.Info(AppConst.A("SendSMS_QCAsync", this.Url, username, password, sender, sms, phone, result));
                if (!String.IsNullOrEmpty(result)) return Convert.ToInt32(result);
            }
        }
        catch
        {
            return -86;
        }

        return -86;
    }

    /// <summary>
    /// Gửi tin quảng cáo
    /// Url: https://qc.vietguys.biz/api/sendsms.php
    /// </summary>
    /// <param name="user"></param>
    /// <param name="password"></param>
    /// <param name="sender"></param>
    /// <param name="sms"></param>
    /// <param name="listPhone"></param>
    /// <param name="date"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    public async Task<string> SendSMS_QCAsync(string user, string password, string sender, string sms, string listPhone, string date, string time)
    {
        try
        {
            string url = String.Format("{0}?phone={1}&from={2}&sms={3}&u={4}&pwd={5}&day={6}&time={7}", this.Url, listPhone, sender, sms, user, password, date, time);

            using (HttpClient http = new HttpClient())
            {
                using (HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, url))
                {
                    HttpResponseMessage response = await http.SendAsync(httpRequest);
                    if (response != null)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        logger.Info(AppConst.A("SendSMS_QCAsync", url, user, password, sender, sms, listPhone, date, time, result));
                        return String.IsNullOrEmpty(result) ? String.Empty : result.Trim();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            logger.Error(AppConst.A("SendSMS_QCAsync", this.Url, user, password, sender, sms, listPhone, date, time, ex));
        }

        return String.Empty;
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.SoapTypeAttribute(TypeName = "sms", Namespace = "sms")]
public partial class SmsInfo
{
    private string phoneField;

    private string passcodeField;

    private string smsField;

    private string accountField;

    private string passwordField;

    private string contenttypeField;

    private string messagetypeField;

    private string messageidField;

    private string transactionidField;

    private string service_idField;

    private string jsonField;

    /// <remarks/>
    public string phone
    {
        get
        {
            return this.phoneField;
        }
        set
        {
            this.phoneField = value;
        }
    }

    /// <remarks/>
    public string passcode
    {
        get
        {
            return this.passcodeField;
        }
        set
        {
            this.passcodeField = value;
        }
    }

    /// <remarks/>
    public string sms
    {
        get
        {
            return this.smsField;
        }
        set
        {
            this.smsField = value;
        }
    }

    /// <remarks/>
    public string account
    {
        get
        {
            return this.accountField;
        }
        set
        {
            this.accountField = value;
        }
    }

    /// <remarks/>
    public string password
    {
        get
        {
            return this.passwordField;
        }
        set
        {
            this.passwordField = value;
        }
    }

    /// <remarks/>
    public string contenttype
    {
        get
        {
            return this.contenttypeField;
        }
        set
        {
            this.contenttypeField = value;
        }
    }

    /// <remarks/>
    public string messagetype
    {
        get
        {
            return this.messagetypeField;
        }
        set
        {
            this.messagetypeField = value;
        }
    }

    /// <remarks/>
    public string messageid
    {
        get
        {
            return this.messageidField;
        }
        set
        {
            this.messageidField = value;
        }
    }

    /// <remarks/>
    public string transactionid
    {
        get
        {
            return this.transactionidField;
        }
        set
        {
            this.transactionidField = value;
        }
    }

    /// <remarks/>
    public string service_id
    {
        get
        {
            return this.service_idField;
        }
        set
        {
            this.service_idField = value;
        }
    }

    /// <remarks/>
    public string json
    {
        get
        {
            return this.jsonField;
        }
        set
        {
            this.jsonField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
public delegate void SendCompletedEventHandler(object sender, SendCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class SendCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal SendCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public string Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((string)(this.results[0]));
        }
    }
}
