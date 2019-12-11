namespace Server
{
    partial class ServerForm
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
            this.sendTextButton = new System.Windows.Forms.Button();
            this.serverStatus = new System.Windows.Forms.RichTextBox();
            this.serverSendText = new System.Windows.Forms.TextBox();
            this.listenButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sendTextButton
            // 
            this.sendTextButton.Location = new System.Drawing.Point(153, 315);
            this.sendTextButton.Name = "sendTextButton";
            this.sendTextButton.Size = new System.Drawing.Size(174, 36);
            this.sendTextButton.TabIndex = 1;
            this.sendTextButton.Text = "Send";
            this.sendTextButton.UseVisualStyleBackColor = true;
            this.sendTextButton.Click += new System.EventHandler(this.SendTextButton_Click);
            // 
            // serverStatus
            // 
            this.serverStatus.BackColor = System.Drawing.Color.White;
            this.serverStatus.Location = new System.Drawing.Point(53, 86);
            this.serverStatus.Name = "serverStatus";
            this.serverStatus.ReadOnly = true;
            this.serverStatus.Size = new System.Drawing.Size(365, 160);
            this.serverStatus.TabIndex = 2;
            this.serverStatus.Text = "";
            // 
            // serverSendText
            // 
            this.serverSendText.Location = new System.Drawing.Point(53, 271);
            this.serverSendText.Name = "serverSendText";
            this.serverSendText.Size = new System.Drawing.Size(364, 20);
            this.serverSendText.TabIndex = 3;
            // 
            // listenButton
            // 
            this.listenButton.Location = new System.Drawing.Point(153, 28);
            this.listenButton.Name = "listenButton";
            this.listenButton.Size = new System.Drawing.Size(174, 36);
            this.listenButton.TabIndex = 4;
            this.listenButton.Text = "Listen";
            this.listenButton.UseVisualStyleBackColor = true;
            this.listenButton.Click += new System.EventHandler(this.ListenButton_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 399);
            this.Controls.Add(this.listenButton);
            this.Controls.Add(this.serverSendText);
            this.Controls.Add(this.serverStatus);
            this.Controls.Add(this.sendTextButton);
            this.Name = "ServerForm";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button sendTextButton;
        private System.Windows.Forms.RichTextBox serverStatus;
        private System.Windows.Forms.TextBox serverSendText;
        private System.Windows.Forms.Button listenButton;
    }
}