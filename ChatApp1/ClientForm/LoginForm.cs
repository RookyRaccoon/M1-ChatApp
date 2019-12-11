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
    public partial class LoginForm : Form
    {
        
        public event EventHandler<Log_Event> Log_update;
        public delegate void DelegateRaising_bool(bool log); 
        public LoginForm()
        {
            InitializeComponent();
        }


        
        /// <summary>
        /// Connection button, raising the event creating a new log_event(username and log) 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        //To do DB with username and password
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (textUsername.Text != "" && textPassword.Text != "")
            {
                if (textPassword.Text == "password")
                {
                    //null
                    EventHandler<Log_Event> handler = Log_update;

                    if (handler != null)
                    {

                        handler(this, new Log_Event(true, textUsername.Text));

                    }
                    else
                    {
                        MessageBox.Show("event null");

                    }
                }
                else
                {
                    MessageBox.Show("wrong password, please try again");
                    textPassword.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Please fill out the form to connect");
            }
        }
            
            public void RequestStop() {
            this.Close();
        }
        
    }
}
