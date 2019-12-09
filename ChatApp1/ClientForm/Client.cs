using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace ClientForm
{
    public class Client
    {
        private String _username;
        private string _ip;

        private TcpClient client;
        private Net Net = null;

        //pages
        private LoginForm clientLogin;
        private HomePage homePage; 
       

        //threads for the pages
        private Thread login;
        private Thread home = null;
        
        public string IP
        {
            get { return _ip; }
        }

        public Client(string ip)
        {
            this._ip = ip;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Net = new Net();
            Net.Log_event += connectionManagement;
            login = new Thread(new ThreadStart(loginStart));
            login.Start(); 

        }

        public void closeConnection()
        {
            Net.sendMessage(client.GetStream(), "@" + _username + " disconnecting" + " @ " + IP);
            client.GetStream().Close();
            client.Close();
            login = new Thread(new ThreadStart(loginStart));
            login.Start(); 
        }
          
        //run login page
        private void loginStart()
        {
            clientLogin = new LoginForm();
            clientLogin.Log_event += connectionManagement;
            Application.Run(clientLogin);
        }

        private void homeStart()
        {
            homePage = new HomePage(this._username);
            homePage.Log_event += connectionManagement;
            //TODO
            //create tchat 
            //create grouptchat /topic
            Application.Run(homePage);

        }

        //if logevent then will send a connection
        private void connectionManagement(object sender, Log_Event e)
        {
            if (e.Log)
            {
                connect(e.Username); 
            }
            else
            {
                closeConnection(); 

            }
        }

        public void connect(string username)
        {
            this._username = username;
            try
            {
                client = new TcpClient(this._ip, 8976);

                if (client.Connected)
                {
                    //once connected, sends and receives messages 
                    Net.sendMessage(client.GetStream(), "@" + username + "connected" + "@" + this.IP);
                    Net.receiveMessage(this, client.GetStream());
                    //closing form
                    clientLogin.RequestStop();

                    if(home == null)
                    {
                        home = new Thread(new ThreadStart(homeStart));
                        home.Start(); 
                    }
                }

            }
            catch
            {

            }
        }

        public void messageHandling(string data)
        {

        }
    }

    public class Log_Event : EventArgs
    {
        private bool _log;
        private string _username;

        public bool Log
        {
            get { return _log; }
        }
        public string Username
        {
            get { return _username; }
        }

        public Log_Event(bool l, string u)
        {
            _log = l;
            _username = u; 
        }

    }

}
