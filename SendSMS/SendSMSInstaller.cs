using System;
using System.ComponentModel;
using System.Configuration;
using System.Reflection;
using System.ServiceProcess;

namespace SendSMS
{
    [RunInstaller(true)]
    public partial class SendSMSInstaller : System.Configuration.Install.Installer
    {
        public SendSMSInstaller()
        {
            InitializeComponent();

            svProcessSendSMS.Account = ServiceAccount.LocalSystem;
            svInstallSendSMS.ServiceName = String.Format("SendSMS_{0}", GetServiceNameAppConfig("PARTNER.NAME"));
            svInstallSendSMS.DisplayName = String.Format("GWService Send SMS {0}", GetServiceNameAppConfig("PARTNER.NAME"));
            svInstallSendSMS.Description = String.Format("Gửi tin nhắn đến đối tác {0}", GetServiceNameAppConfig("PARTNER.NAME"));
        }

        public string GetServiceNameAppConfig(string serviceName)
        {
            var config = ConfigurationManager.OpenExeConfiguration(Assembly.GetAssembly(typeof(SendSMSInstaller)).Location);
            return config.AppSettings.Settings[serviceName].Value;
        }
    }
}
