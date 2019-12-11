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
    public partial class HomePage : Form
    {
        private string _uname; 
        public string username
        {
            get { return _uname; }
            set { _uname = username; }
        }

        public event EventHandler<Log_Event> Log_event;
        public delegate void DelegateBool(bool log);

        public event EventHandler<New_Chat_Event> New_chat_event;
        public delegate void DelegateString(string data); 
        public HomePage(string name)
        {
            InitializeComponent();
            _uname = name;
            clientName.Text = _uname;
            status("Connected");
            Application.ApplicationExit += new EventHandler(this.applicationExit);
        }

        #region Entering and exiting
        public void status(string data)
        {
            clientStatus.Text = data;
        }

        public void exit()
        {
            this.Close(); 
        }
       

        private void applicationExit(object sender, EventArgs e)
        {
            Log_event(this, new Log_Event (false, ""));
            this.Close();
        }
        #endregion


        #region components
        private void Create_group_chat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        private void LogoutButton_Click(object sender, EventArgs e)
        {

            Log_event(this, new Log_Event(false, ""));
            this.Close();
        }
        #endregion
    }
}
