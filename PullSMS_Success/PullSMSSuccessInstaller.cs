using System.ComponentModel;
using System.ServiceProcess;

namespace PullSMS_Success
{
    [RunInstaller(true)]
    public partial class PullSMSSuccessInstaller : System.Configuration.Install.Installer
    {
        public PullSMSSuccessInstaller()
        {
            InitializeComponent();

            svProcessInstallerPullSMSSuccess.Account = ServiceAccount.LocalSystem;
            svInstallPullSMSSuccess.ServiceName = "PullSMS_Success";
            svInstallPullSMSSuccess.DisplayName = "GWService Receive SMS Success";
            svInstallPullSMSSuccess.Description = "Nhận và xử lý tin nhắn thành công";
        }
    }
}
