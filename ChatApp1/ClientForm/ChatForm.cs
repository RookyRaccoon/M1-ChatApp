using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Communication;

namespace ClientForm
{
    public partial class ChatForm : Form
    {
        private bool _group;
        private string _name;
        private string _receiverName;
        private bool _can_send_msg;

        public event EventHandler<Send_Event> send_event;
        public delegate void DelegateRasing(string message); 
        public event EventHandler<New_Group_Modif_Event> new_group_modif_event;
        public delegate void DelegateModifGroup(string data, bool del); 

        delegate void SetText(string text);
        delegate void Exit();
        public bool Group
        {
            get { return _group; }
            set { _group = Group; }
        }


        public string ChatName
        {
            get { return _name; }
            set { _name = Name; }
        }

        public string ReceiverName
        {
            get { return _receiverName; }
            set { _receiverName = ReceiverName; }
        }



        public ChatForm(string name, string receiver, bool group)
        {
            _group = group;
            _name = name;
            _receiverName = name; 
            InitializeComponent();
            labelMyName.Text = _name;
            labelReceiver.Text = _receiverName;
            _can_send_msg = true;
            this.ActiveControl = textBoxSend;
            textBoxSend.Focus();

            if (!group)
            {
                buttonLeave.Text = "Just the two of us";
                buttonDelete.Text = "is nice"; 
            }

        }

        public void exit()
        {
            if (this.InvokeRequired)
            {
                Exit e = new Exit(exit);
                this.Invoke(e, new object[] { });
            }
            else
            {
                this.Close(); 
            }
        }

        #region message
        public void updateMessage(string data)
        {
            if (this.messages.InvokeRequired)
            {
                SetText setText = new SetText(updateMessage);
                this.Invoke(setText, new object[] { data });

            }
        }

        public void message_sent(bool sent)
        {
            if (sent)
            {
                updateMessage(this._name+": "+textBoxSend.Text);

                textBoxSend.Text = "";
            }
            else
            {
                MessageBox.Show("Did not send message oops"); 
            }
        }

       
        #endregion


        #region components
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            new_group_modif_event(this, new New_Group_Modif_Event(_receiverName, true));
            this.exit(); 
        }

        private void ButtonLeave_Click(object sender, EventArgs e)
        {
            new_group_modif_event(this, new New_Group_Modif_Event(_receiverName, false));
            this.exit();
        }

        /* //words[0] --> name of the sender
            //words[1] --> type of message
            //words[2] --> optionnal : name of recepient
            //words[3] --> optionnal : message for recepient
            */

            //Sending message
        private void ButtonSend_Click(object sender, EventArgs e)
        {
            string message = textBoxSend.Text; 

            if (message!="" && _can_send_msg)
            {
                if (_group)
                {
                    message = "@" + this._name + "#GCMessage" + "@" + this._receiverName + "#" + message; 
                }
                else
                {
                    message = "@" + this._name + "#message" + "@" + this._receiverName + "#" + message;

                }

                send_event(this, new Send_Event(message)); 
            }
        }
        #endregion
    }
}
