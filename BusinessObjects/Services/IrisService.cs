[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Web.Services.WebServiceBindingAttribute(Name = "IrisServiceSoap", Namespace = "http://tempuri.org/")]
public partial class IrisService : System.Web.Services.Protocols.SoapHttpClientProtocol
{
    private System.Threading.SendOrPostCallback SendSMSOperationCompleted;

    private System.Threading.SendOrPostCallback SendSMSQuangCaoOperationCompleted;

    /// <remarks/>
    public IrisService(string url = "https://brandsms.irismedia.vn/Service.asmx")
    {
        this.Url = url;
    }

    /// <remarks/>
    public event IrisSendSMSCompletedEventHandler SendSMSCompleted;

    /// <remarks/>
    public event SendSMSQuangCaoCompletedEventHandler SendSMSQuangCaoCompleted;

    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SendSMS", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public string SendSMS(string userid, string password, string SMS_ID, string brandname, string phonenumber, string message)
    {
        object[] results = this.Invoke("SendSMS", new object[] {
                    userid,
                    password,
                    SMS_ID,
                    brandname,
                    phonenumber,
                    message});
        return ((string)(results[0]));
    }

    /// <remarks/>
    public System.IAsyncResult BeginSendSMS(string userid, string password, string SMS_ID, string brandname, string phonenumber, string message, System.AsyncCallback callback, object asyncState)
    {
        return this.BeginInvoke("SendSMS", new object[] {
                    userid,
                    password,
                    SMS_ID,
                    brandname,
                    phonenumber,
                    message}, callback, asyncState);
    }

    /// <remarks/>
    public string EndSendSMS(System.IAsyncResult asyncResult)
    {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }

    /// <remarks/>
    public void SendSMSAsync(string userid, string password, string SMS_ID, string brandname, string phonenumber, string message)
    {
        this.SendSMSAsync(userid, password, SMS_ID, brandname, phonenumber, message, null);
    }

    /// <remarks/>
    public void SendSMSAsync(string userid, string password, string SMS_ID, string brandname, string phonenumber, string message, object userState)
    {
        if ((this.SendSMSOperationCompleted == null))
        {
            this.SendSMSOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendSMSOperationCompleted);
        }
        this.InvokeAsync("SendSMS", new object[] {
                    userid,
                    password,
                    SMS_ID,
                    brandname,
                    phonenumber,
                    message}, this.SendSMSOperationCompleted, userState);
    }

    private void OnSendSMSOperationCompleted(object arg)
    {
        if ((this.SendSMSCompleted != null))
        {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.SendSMSCompleted(this, new IrisSendSMSCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }

    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SendSMSQuangCao", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public string SendSMSQuangCao(string userid, string password, string SMS_ID, string brandname, string phonenumber, string message)
    {
        object[] results = this.Invoke("SendSMSQuangCao", new object[] {
                    userid,
                    password,
                    SMS_ID,
                    brandname,
                    phonenumber,
                    message});
        return ((string)(results[0]));
    }

    /// <remarks/>
    public System.IAsyncResult BeginSendSMSQuangCao(string userid, string password, string SMS_ID, string brandname, string phonenumber, string message, System.AsyncCallback callback, object asyncState)
    {
        return this.BeginInvoke("SendSMSQuangCao", new object[] {
                    userid,
                    password,
                    SMS_ID,
                    brandname,
                    phonenumber,
                    message}, callback, asyncState);
    }

    /// <remarks/>
    public string EndSendSMSQuangCao(System.IAsyncResult asyncResult)
    {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }

    /// <remarks/>
    public void SendSMSQuangCaoAsync(string userid, string password, string SMS_ID, string brandname, string phonenumber, string message)
    {
        this.SendSMSQuangCaoAsync(userid, password, SMS_ID, brandname, phonenumber, message, null);
    }

    /// <remarks/>
    public void SendSMSQuangCaoAsync(string userid, string password, string SMS_ID, string brandname, string phonenumber, string message, object userState)
    {
        if ((this.SendSMSQuangCaoOperationCompleted == null))
        {
            this.SendSMSQuangCaoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendSMSQuangCaoOperationCompleted);
        }
        this.InvokeAsync("SendSMSQuangCao", new object[] {
                    userid,
                    password,
                    SMS_ID,
                    brandname,
                    phonenumber,
                    message}, this.SendSMSQuangCaoOperationCompleted, userState);
    }

    private void OnSendSMSQuangCaoOperationCompleted(object arg)
    {
        if ((this.SendSMSQuangCaoCompleted != null))
        {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.SendSMSQuangCaoCompleted(this, new SendSMSQuangCaoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }

    /// <remarks/>
    public new void CancelAsync(object userState)
    {
        base.CancelAsync(userState);
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
public delegate void IrisSendSMSCompletedEventHandler(object sender, IrisSendSMSCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class IrisSendSMSCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{
    private object[] results;

    internal IrisSendSMSCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
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

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
public delegate void SendSMSQuangCaoCompletedEventHandler(object sender, SendSMSQuangCaoCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class SendSMSQuangCaoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{
    private object[] results;

    internal SendSMSQuangCaoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
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
