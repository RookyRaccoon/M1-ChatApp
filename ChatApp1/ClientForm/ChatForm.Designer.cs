namespace ClientForm
{
    partial class ChatForm
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
            this.labelFriend = new System.Windows.Forms.Label();
            this.client_Label = new System.Windows.Forms.Label();
            this.messages = new System.Windows.Forms.RichTextBox();
            this.textBoxSend = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonLeave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelFriend
            // 
            this.labelFriend.AutoSize = true;
            this.labelFriend.Location = new System.Drawing.Point(22, 45);
            this.labelFriend.Name = "labelFriend";
            this.labelFriend.Size = new System.Drawing.Size(74, 13);
            this.labelFriend.TabIndex = 0;
            this.labelFriend.Text = "receiver name";
            // 
            // client_Label
            // 
            this.client_Label.AutoSize = true;
            this.client_Label.Location = new System.Drawing.Point(41, 361);
            this.client_Label.Name = "client_Label";
            this.client_Label.Size = new System.Drawing.Size(48, 13);
            this.client_Label.TabIndex = 1;
            this.client_Label.Text = "myName";
            // 
            // messages
            // 
            this.messages.BackColor = System.Drawing.Color.White;
            this.messages.Location = new System.Drawing.Point(109, 21);
            this.messages.Name = "messages";
            this.messages.ReadOnly = true;
            this.messages.Size = new System.Drawing.Size(361, 309);
            this.messages.TabIndex = 2;
            this.messages.Text = "";
            // 
            // textBoxSend
            // 
            this.textBoxSend.Location = new System.Drawing.Point(109, 348);
            this.textBoxSend.Multiline = true;
            this.textBoxSend.Name = "textBoxSend";
            this.textBoxSend.Size = new System.Drawing.Size(276, 60);
            this.textBoxSend.TabIndex = 3;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(397, 346);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(72, 61);
            this.buttonSend.TabIndex = 4;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // buttonLeave
            // 
            this.buttonLeave.Location = new System.Drawing.Point(25, 136);
            this.buttonLeave.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLeave.Name = "buttonLeave";
            this.buttonLeave.Size = new System.Drawing.Size(65, 40);
            this.buttonLeave.TabIndex = 5;
            this.buttonLeave.Text = "Leave Group";
            this.buttonLeave.UseVisualStyleBackColor = true;
            this.buttonLeave.Click += new System.EventHandler(this.ButtonLeave_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(25, 79);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(65, 40);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "Delete Group";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 429);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonLeave);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxSend);
            this.Controls.Add(this.messages);
            this.Controls.Add(this.client_Label);
            this.Controls.Add(this.labelFriend);
            this.Name = "ChatForm";
            this.Text = "Tchat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFriend;
        private System.Windows.Forms.Label client_Label;
        private System.Windows.Forms.RichTextBox messages;
        private System.Windows.Forms.TextBox textBoxSend;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonLeave;
        private System.Windows.Forms.Button buttonDelete;
    }
}