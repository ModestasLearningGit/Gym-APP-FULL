
namespace GymFullApp
{
    partial class frmMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblIsAdmin = new System.Windows.Forms.Label();
            this.lblShowAs = new System.Windows.Forms.Label();
            this.pnlEXIT = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlLOGOUT = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlADMINPANEL = new System.Windows.Forms.Panel();
            this.lblAdminPanel = new System.Windows.Forms.Label();
            this.lblAdminStatus = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.pnlRemoveTime = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlUpdateInfo = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlRemoveMember = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlCheckTime = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pADDTIME = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pADDNEW = new System.Windows.Forms.Panel();
            this.lblMember = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlEXIT.SuspendLayout();
            this.pnlLOGOUT.SuspendLayout();
            this.pnlADMINPANEL.SuspendLayout();
            this.pnlRemoveTime.SuspendLayout();
            this.pnlUpdateInfo.SuspendLayout();
            this.pnlRemoveMember.SuspendLayout();
            this.pnlCheckTime.SuspendLayout();
            this.pADDTIME.SuspendLayout();
            this.pADDNEW.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.lblIsAdmin);
            this.panel1.Controls.Add(this.lblShowAs);
            this.panel1.Controls.Add(this.pnlEXIT);
            this.panel1.Controls.Add(this.pnlLOGOUT);
            this.panel1.Controls.Add(this.pnlADMINPANEL);
            this.panel1.Controls.Add(this.lblAdminStatus);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.lblUsername);
            this.panel1.Controls.Add(this.lblAdmin);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 89);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblIsAdmin
            // 
            this.lblIsAdmin.AutoSize = true;
            this.lblIsAdmin.Location = new System.Drawing.Point(140, 46);
            this.lblIsAdmin.Name = "lblIsAdmin";
            this.lblIsAdmin.Size = new System.Drawing.Size(0, 15);
            this.lblIsAdmin.TabIndex = 14;
            // 
            // lblShowAs
            // 
            this.lblShowAs.AutoSize = true;
            this.lblShowAs.Location = new System.Drawing.Point(140, 21);
            this.lblShowAs.Name = "lblShowAs";
            this.lblShowAs.Size = new System.Drawing.Size(0, 15);
            this.lblShowAs.TabIndex = 13;
            // 
            // pnlEXIT
            // 
            this.pnlEXIT.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlEXIT.Controls.Add(this.label7);
            this.pnlEXIT.Location = new System.Drawing.Point(751, 10);
            this.pnlEXIT.Name = "pnlEXIT";
            this.pnlEXIT.Size = new System.Drawing.Size(85, 69);
            this.pnlEXIT.TabIndex = 12;
            this.pnlEXIT.Click += new System.EventHandler(this.pnlEXIT_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(25, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "EXIT";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // pnlLOGOUT
            // 
            this.pnlLOGOUT.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlLOGOUT.Controls.Add(this.label6);
            this.pnlLOGOUT.Location = new System.Drawing.Point(660, 10);
            this.pnlLOGOUT.Name = "pnlLOGOUT";
            this.pnlLOGOUT.Size = new System.Drawing.Size(85, 69);
            this.pnlLOGOUT.TabIndex = 11;
            this.pnlLOGOUT.Click += new System.EventHandler(this.pnlLOGOUT_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(15, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "LOGOUT";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // pnlADMINPANEL
            // 
            this.pnlADMINPANEL.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlADMINPANEL.Controls.Add(this.lblAdminPanel);
            this.pnlADMINPANEL.Location = new System.Drawing.Point(500, 10);
            this.pnlADMINPANEL.Name = "pnlADMINPANEL";
            this.pnlADMINPANEL.Size = new System.Drawing.Size(151, 69);
            this.pnlADMINPANEL.TabIndex = 10;
            this.pnlADMINPANEL.Click += new System.EventHandler(this.pnlADMINPANEL_Click);
            // 
            // lblAdminPanel
            // 
            this.lblAdminPanel.AutoSize = true;
            this.lblAdminPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAdminPanel.Location = new System.Drawing.Point(36, 29);
            this.lblAdminPanel.Name = "lblAdminPanel";
            this.lblAdminPanel.Size = new System.Drawing.Size(87, 17);
            this.lblAdminPanel.TabIndex = 0;
            this.lblAdminPanel.Text = "Admin Panel";
            // 
            // lblAdminStatus
            // 
            this.lblAdminStatus.AutoSize = true;
            this.lblAdminStatus.Location = new System.Drawing.Point(134, 46);
            this.lblAdminStatus.Name = "lblAdminStatus";
            this.lblAdminStatus.Size = new System.Drawing.Size(0, 15);
            this.lblAdminStatus.TabIndex = 8;
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
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(134, 21);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 15);
            this.lblUsername.TabIndex = 7;
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
            // pnlRemoveTime
            // 
            this.pnlRemoveTime.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlRemoveTime.Controls.Add(this.label5);
            this.pnlRemoveTime.Location = new System.Drawing.Point(591, 337);
            this.pnlRemoveTime.Name = "pnlRemoveTime";
            this.pnlRemoveTime.Size = new System.Drawing.Size(156, 126);
            this.pnlRemoveTime.TabIndex = 9;
            this.pnlRemoveTime.Click += new System.EventHandler(this.pnlRemoveTime_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(37, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Remove Time";
            // 
            // pnlUpdateInfo
            // 
            this.pnlUpdateInfo.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlUpdateInfo.Controls.Add(this.label4);
            this.pnlUpdateInfo.Location = new System.Drawing.Point(97, 337);
            this.pnlUpdateInfo.Name = "pnlUpdateInfo";
            this.pnlUpdateInfo.Size = new System.Drawing.Size(156, 126);
            this.pnlUpdateInfo.TabIndex = 8;
            this.pnlUpdateInfo.Click += new System.EventHandler(this.pnlUpdateInfo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(36, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Update Info";
            // 
            // pnlRemoveMember
            // 
            this.pnlRemoveMember.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlRemoveMember.Controls.Add(this.label3);
            this.pnlRemoveMember.Location = new System.Drawing.Point(350, 337);
            this.pnlRemoveMember.Name = "pnlRemoveMember";
            this.pnlRemoveMember.Size = new System.Drawing.Size(156, 126);
            this.pnlRemoveMember.TabIndex = 5;
            this.pnlRemoveMember.Click += new System.EventHandler(this.pnlRemoveMember_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(22, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Remove Member";
            // 
            // pnlCheckTime
            // 
            this.pnlCheckTime.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlCheckTime.Controls.Add(this.label2);
            this.pnlCheckTime.Location = new System.Drawing.Point(591, 138);
            this.pnlCheckTime.Name = "pnlCheckTime";
            this.pnlCheckTime.Size = new System.Drawing.Size(156, 126);
            this.pnlCheckTime.TabIndex = 6;
            this.pnlCheckTime.Click += new System.EventHandler(this.pnlCheckTime_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(22, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Check Time Left";
            // 
            // pADDTIME
            // 
            this.pADDTIME.BackColor = System.Drawing.Color.RoyalBlue;
            this.pADDTIME.Controls.Add(this.label1);
            this.pADDTIME.Location = new System.Drawing.Point(346, 138);
            this.pADDTIME.Name = "pADDTIME";
            this.pADDTIME.Size = new System.Drawing.Size(156, 126);
            this.pADDTIME.TabIndex = 7;
            this.pADDTIME.Click += new System.EventHandler(this.pADDTIME_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(4, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Membership Time";
            // 
            // pADDNEW
            // 
            this.pADDNEW.BackColor = System.Drawing.Color.RoyalBlue;
            this.pADDNEW.Controls.Add(this.lblMember);
            this.pADDNEW.Location = new System.Drawing.Point(97, 138);
            this.pADDNEW.Name = "pADDNEW";
            this.pADDNEW.Size = new System.Drawing.Size(156, 126);
            this.pADDNEW.TabIndex = 4;
            this.pADDNEW.Click += new System.EventHandler(this.pADDNEW_Click);
            // 
            // lblMember
            // 
            this.lblMember.AutoSize = true;
            this.lblMember.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMember.Location = new System.Drawing.Point(22, 53);
            this.lblMember.Name = "lblMember";
            this.lblMember.Size = new System.Drawing.Size(119, 17);
            this.lblMember.TabIndex = 0;
            this.lblMember.Text = "Add New Member";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 621);
            this.ControlBox = false;
            this.Controls.Add(this.pnlRemoveTime);
            this.Controls.Add(this.pnlUpdateInfo);
            this.Controls.Add(this.pnlRemoveMember);
            this.Controls.Add(this.pnlCheckTime);
            this.Controls.Add(this.pADDTIME);
            this.Controls.Add(this.pADDNEW);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlEXIT.ResumeLayout(false);
            this.pnlEXIT.PerformLayout();
            this.pnlLOGOUT.ResumeLayout(false);
            this.pnlLOGOUT.PerformLayout();
            this.pnlADMINPANEL.ResumeLayout(false);
            this.pnlADMINPANEL.PerformLayout();
            this.pnlRemoveTime.ResumeLayout(false);
            this.pnlRemoveTime.PerformLayout();
            this.pnlUpdateInfo.ResumeLayout(false);
            this.pnlUpdateInfo.PerformLayout();
            this.pnlRemoveMember.ResumeLayout(false);
            this.pnlRemoveMember.PerformLayout();
            this.pnlCheckTime.ResumeLayout(false);
            this.pnlCheckTime.PerformLayout();
            this.pADDTIME.ResumeLayout(false);
            this.pADDTIME.PerformLayout();
            this.pADDNEW.ResumeLayout(false);
            this.pADDNEW.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAdminStatus;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.Panel pnlADMINPANEL;
        private System.Windows.Forms.Label lblAdminPanel;
        private System.Windows.Forms.Panel pnlRemoveTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlUpdateInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlRemoveMember;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlCheckTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pADDTIME;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pADDNEW;
        private System.Windows.Forms.Label lblMember;
        private System.Windows.Forms.Panel pnlEXIT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlLOGOUT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblShowAs;
        private System.Windows.Forms.Label lblIsAdmin;
    }
}