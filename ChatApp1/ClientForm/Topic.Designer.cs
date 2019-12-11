namespace ClientForm
{
    partial class Topic
    {  /// <summary>
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTopic = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonCreateGroupChat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose a topic:";
            // 
            // textBoxTopic
            // 
            this.textBoxTopic.Location = new System.Drawing.Point(205, 68);
            this.textBoxTopic.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxTopic.Name = "textBoxTopic";
            this.textBoxTopic.Size = new System.Drawing.Size(135, 20);
            this.textBoxTopic.TabIndex = 1;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(113, 112);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(59, 27);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonCreateGroupChat
            // 
            this.buttonCreateGroupChat.Location = new System.Drawing.Point(221, 112);
            this.buttonCreateGroupChat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonCreateGroupChat.Name = "buttonCreateGroupChat";
            this.buttonCreateGroupChat.Size = new System.Drawing.Size(103, 27);
            this.buttonCreateGroupChat.TabIndex = 3;
            this.buttonCreateGroupChat.Text = "Create Group Chat";
            this.buttonCreateGroupChat.UseVisualStyleBackColor = true;
            this.buttonCreateGroupChat.Click += new System.EventHandler(this.ButtonCreateGroupChat_Click);
            // 
            // Topic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 176);
            this.Controls.Add(this.buttonCreateGroupChat);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxTopic);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Topic";
            this.Text = "Create Topic";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTopic;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonCreateGroupChat;

    }
}