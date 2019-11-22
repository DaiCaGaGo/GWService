using System.ComponentModel;
using System.ServiceProcess;

namespace PullSMS_Error
{
    [RunInstaller(true)]
    public partial class PullSMSErrorInstaller : System.Configuration.Install.Installer
    {
        public PullSMSErrorInstaller()
        {
            InitializeComponent();

            svProcessInstallerPullSMSError.Account = ServiceAccount.LocalSystem;
            svInstallPullSMSError.ServiceName = "PullSMS_Error";
            svInstallPullSMSError.DisplayName = "GWService Receive SMS Error";
            svInstallPullSMSError.Description = "Nhận và xử lý tin nhắn lỗi";
        }
    }
}
