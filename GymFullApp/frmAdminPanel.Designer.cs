
namespace GymFullApp
{
    partial class frmAdminPanel
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pCheckLogs = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pADDNEW = new System.Windows.Forms.Panel();
            this.lblMember = new System.Windows.Forms.Label();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.lblShowAs = new System.Windows.Forms.Label();
            this.lblIsAdmin = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pCheckLogs.SuspendLayout();
            this.pADDNEW.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(48, 21);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(79, 15);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Logged In As:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.lblIsAdmin);
            this.panel1.Controls.Add(this.lblShowAs);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.lblAdmin);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 89);
            this.panel1.TabIndex = 1;
            // 
            // pCheckLogs
            // 
            this.pCheckLogs.BackColor = System.Drawing.Color.RoyalBlue;
            this.pCheckLogs.Controls.Add(this.label1);
            this.pCheckLogs.Location = new System.Drawing.Point(469, 247);
            this.pCheckLogs.Name = "pCheckLogs";
            this.pCheckLogs.Size = new System.Drawing.Size(156, 126);
            this.pCheckLogs.TabIndex = 9;
            this.pCheckLogs.Click += new System.EventHandler(this.pCheckLogs_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(43, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Check Logs";
            // 
            // pADDNEW
            // 
            this.pADDNEW.BackColor = System.Drawing.Color.RoyalBlue;
            this.pADDNEW.Controls.Add(this.lblMember);
            this.pADDNEW.Location = new System.Drawing.Point(220, 247);
            this.pADDNEW.Name = "pADDNEW";
            this.pADDNEW.Size = new System.Drawing.Size(156, 126);
            this.pADDNEW.TabIndex = 8;
            this.pADDNEW.Click += new System.EventHandler(this.pADDNEW_Click);
            // 
            // lblMember
            // 
            this.lblMember.AutoSize = true;
            this.lblMember.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMember.Location = new System.Drawing.Point(22, 53);
            this.lblMember.Name = "lblMember";
            this.lblMember.Size = new System.Drawing.Size(95, 17);
            this.lblMember.TabIndex = 0;
            this.lblMember.Text = "Add New User";
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Location = new System.Drawing.Point(19, 46);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(111, 15);
            this.lblAdmin.TabIndex = 6;
            this.lblAdmin.Text = "Have Admin Status:";
            // 
            // lblShowAs
            // 
            this.lblShowAs.AutoSize = true;
            this.lblShowAs.Location = new System.Drawing.Point(136, 21);
            this.lblShowAs.Name = "lblShowAs";
            this.lblShowAs.Size = new System.Drawing.Size(0, 15);
            this.lblShowAs.TabIndex = 7;
            // 
            // lblIsAdmin
            // 
            this.lblIsAdmin.AutoSize = true;
            this.lblIsAdmin.Location = new System.Drawing.Point(136, 46);
            this.lblIsAdmin.Name = "lblIsAdmin";
            this.lblIsAdmin.Size = new System.Drawing.Size(0, 15);
            this.lblIsAdmin.TabIndex = 8;
            // 
            // frmAdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 621);
            this.Controls.Add(this.pCheckLogs);
            this.Controls.Add(this.pADDNEW);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAdminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Panel";
            this.Load += new System.EventHandler(this.frmAdminPanel_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pCheckLogs.ResumeLayout(false);
            this.pCheckLogs.PerformLayout();
            this.pADDNEW.ResumeLayout(false);
            this.pADDNEW.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pCheckLogs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pADDNEW;
        private System.Windows.Forms.Label lblMember;
        private System.Windows.Forms.Label lblIsAdmin;
        private System.Windows.Forms.Label lblShowAs;
        private System.Windows.Forms.Label lblAdmin;
    }
}