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
        public EventHandler<Log_Event> Log_event;
        public delegate void DelegateRaising_bool(bool log); 
        public LoginForm()
        {
            InitializeComponent();
        }


        //Connection method, raising the event creating a new eventargs and ensures you fill out the form correctly 
        //To do DB with username and password
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (textUsername.Text != "" && textPassword.Text != "")
            {
                if (textPassword.Text == "password")
                {
                    //null
                    Log_event(this, new Log_Event(true,textUsername.Text));
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
