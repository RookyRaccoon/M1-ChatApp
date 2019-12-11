using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientForm
{
    /// <summary>
    /// 
    /// Class for creating a new topic <=> a new group chat 
    /// </summary>
    public partial class Topic : Form
    {
        public event EventHandler<New_Group_Chat_Event> new_group_chat_event;
        public delegate void DelegatString(string data); 

        public Topic()
        {
            InitializeComponent();
        }

        private void ButtonCreateGroupChat_Click(object sender, EventArgs e)
        {
            if (textBoxTopic.Text != "")
            {
                new_group_chat_event(this, new New_Group_Chat_Event(textBoxTopic.Text));
                this.Close(); 
            }
            else
            {
                MessageBox.Show("please chose a topic"); 
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close(); 

        }
    }



    public class New_Group_Chat_Event : EventArgs
    {
        private string _data;
        public string Data
        {
            get { return _data; }
        }

        public New_Group_Chat_Event(string d)
        {
            _data = d; 
        }
    }
}
