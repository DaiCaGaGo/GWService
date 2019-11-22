namespace SMSBirthday
{
    partial class SMSBirthdayInstaller
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
            this.svProcessInstallerSMSBirthday = new System.ServiceProcess.ServiceProcessInstaller();
            this.svInstallerSMSBirthday = new System.ServiceProcess.ServiceInstaller();
            // 
            // svProcessInstallerSMSBirthday
            // 
            this.svProcessInstallerSMSBirthday.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.svProcessInstallerSMSBirthday.Password = null;
            this.svProcessInstallerSMSBirthday.Username = null;
            // 
            // svInstallerSMSBirthday
            // 
            this.svInstallerSMSBirthday.ServiceName = "SMSBirthday";
            // 
            // SMSBirthdayInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.svProcessInstallerSMSBirthday,
            this.svInstallerSMSBirthday});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller svProcessInstallerSMSBirthday;
        private System.ServiceProcess.ServiceInstaller svInstallerSMSBirthday;
    }
}