namespace PullSMS_Error
{
    partial class PullSMSErrorInstaller
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
            this.svProcessInstallerPullSMSError = new System.ServiceProcess.ServiceProcessInstaller();
            this.svInstallPullSMSError = new System.ServiceProcess.ServiceInstaller();
            // 
            // svProcessInstallerPullSMSError
            // 
            this.svProcessInstallerPullSMSError.Password = null;
            this.svProcessInstallerPullSMSError.Username = null;
            // 
            // svInstallPullSMSError
            // 
            this.svInstallPullSMSError.ServiceName = "Service1";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.svProcessInstallerPullSMSError,
            this.svInstallPullSMSError});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller svProcessInstallerPullSMSError;
        private System.ServiceProcess.ServiceInstaller svInstallPullSMSError;
    }
}