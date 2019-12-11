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
    public partial class ChatForm : Form
    {
        private bool _group;
        private string _name;
        private string _receiverName;
        private bool _can_send_msg; 


        public ChatForm(string name, string receiver, bool group)
        {
            _group = group;
            _name = name;
            _receiverName = name; 
            InitializeComponent();
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {

        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {

        }

        private void ButtonLeave_Click(object sender, EventArgs e)
        {

        }
    }
}
