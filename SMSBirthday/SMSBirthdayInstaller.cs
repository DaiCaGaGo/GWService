using System.ComponentModel;
using System.ServiceProcess;

namespace SMSBirthday
{
    [RunInstaller(true)]
    public partial class SMSBirthdayInstaller : System.Configuration.Install.Installer
    {
        public SMSBirthdayInstaller()
        {
            InitializeComponent();

            svProcessInstallerSMSBirthday.Account = ServiceAccount.LocalSystem;
            svInstallerSMSBirthday.ServiceName = "SMSBirthday";
            svInstallerSMSBirthday.DisplayName = "GWService Process SMS Birthday";
            svInstallerSMSBirthday.Description = "Nhận và xử lý tin nhắn sinh nhật";
        }
    }
}
