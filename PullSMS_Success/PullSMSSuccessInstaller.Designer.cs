namespace PullSMS_Success
{
    partial class PullSMSSuccessInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.svProcessInstallerPullSMSSuccess = new System.ServiceProcess.ServiceProcessInstaller();
            this.svInstallPullSMSSuccess = new System.ServiceProcess.ServiceInstaller();
            // 
            // svProcessInstallerPullSMSSuccess
            // 
            this.svProcessInstallerPullSMSSuccess.Password = null;
            this.svProcessInstallerPullSMSSuccess.Username = null;
            // 
            // svInstallPullSMSSuccess
            // 
            this.svInstallPullSMSSuccess.ServiceName = "Service1";
            // 
            // PullSMSSuccessInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.svProcessInstallerPullSMSSuccess,
            this.svInstallPullSMSSuccess});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller svProcessInstallerPullSMSSuccess;
        private System.ServiceProcess.ServiceInstaller svInstallPullSMSSuccess;
    }
}