namespace DesktopKillSwitch_Client
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.dkscServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.dkscServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // dkscServiceProcessInstaller
            // 
            this.dkscServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.dkscServiceProcessInstaller.Password = null;
            this.dkscServiceProcessInstaller.Username = null;
            // 
            // dkscServiceInstaller
            // 
            this.dkscServiceInstaller.Description = "Sends a signal once windows gets shutdown";
            this.dkscServiceInstaller.DisplayName = "Desktop Kill Switch (Remote Node.js)";
            this.dkscServiceInstaller.ServiceName = "DKSC";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.dkscServiceProcessInstaller,
            this.dkscServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller dkscServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller dkscServiceInstaller;
    }
}