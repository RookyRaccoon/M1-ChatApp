namespace ClientForm
{
    partial class HomePage
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
            this.clientName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkCreateGroupChat = new System.Windows.Forms.LinkLabel();
            this.clientStatus = new System.Windows.Forms.Label();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clientName
            // 
            this.clientName.AutoSize = true;
            this.clientName.Location = new System.Drawing.Point(23, 35);
            this.clientName.Name = "clientName";
            this.clientName.Size = new System.Drawing.Size(64, 13);
            this.clientName.TabIndex = 0;
            this.clientName.Text = "Name Client";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.linkCreateGroupChat);
            this.panel1.Location = new System.Drawing.Point(26, 116);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 30);
            this.panel1.TabIndex = 3;
            // 
            // linkCreateGroupChat
            // 
            this.linkCreateGroupChat.AutoSize = true;
            this.linkCreateGroupChat.LinkColor = System.Drawing.Color.Black;
            this.linkCreateGroupChat.Location = new System.Drawing.Point(167, 10);
            this.linkCreateGroupChat.Name = "linkCreateGroupChat";
            this.linkCreateGroupChat.Size = new System.Drawing.Size(77, 13);
            this.linkCreateGroupChat.TabIndex = 2;
            this.linkCreateGroupChat.TabStop = true;
            this.linkCreateGroupChat.Text = "Create a group";
            this.linkCreateGroupChat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkCreateGroupChat_LinkClicked);
            // 
            // clientStatus
            // 
            this.clientStatus.AutoSize = true;
            this.clientStatus.Location = new System.Drawing.Point(238, 35);
            this.clientStatus.Name = "clientStatus";
            this.clientStatus.Size = new System.Drawing.Size(79, 13);
            this.clientStatus.TabIndex = 5;
            this.clientStatus.Text = "Not Connected";
            // 
            // LogoutButton
            // 
            this.LogoutButton.Location = new System.Drawing.Point(334, 26);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(83, 30);
            this.LogoutButton.TabIndex = 6;
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.UseVisualStyleBackColor = true;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 341);
            this.Controls.Add(this.LogoutButton);
            this.Controls.Add(this.clientStatus);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.clientName);
            this.Name = "HomePage";
            this.Text = "Home";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label clientName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkCreateGroupChat;
        private System.Windows.Forms.Label clientStatus;
        private System.Windows.Forms.Button LogoutButton;
    }
}
