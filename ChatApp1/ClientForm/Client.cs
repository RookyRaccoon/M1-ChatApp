using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Communication;

namespace ClientForm
{
    public class Client
    {
        private String _username;
        private string _ip;

        private TcpClient client;

        //pages
        private LoginForm clientLogin;
        private HomePage homePage; 
       

        //threads for the pages
        private Thread login;
        private Thread home = null;

        //
        private List<ChatForm> chats = new List<ChatForm>();
        private List<Topic> topics = new List<Topic>();
        private List<String> members_connected = new List<String>();
        private List<String> group_members_connected = new List<String>();
        private List<String> mygroups = new List<String>(); 

        
        public string IP
        {
            get { return _ip; }
        }

        public Client(string ip)
        {
            this._ip = ip;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            login = new Thread(new ThreadStart(loginStart));
            login.Start(); 

        }

       

        #region pages

        //run login page
        private void loginStart()
        {
            clientLogin = new LoginForm();
            clientLogin.Log_update += connectionManagement;
            Application.Run(clientLogin);
        }

        private void homeStart()
        {
            homePage = new HomePage(this._username);
            homePage.Log_event += connectionManagement;
            
            homePage.New_chat_event +=newChat;
            homePage.New_group_event +=createGroupChat;
            //TODO
            //create tchat 
            //create grouptchat /topic
            Application.Run(homePage);

        }

        #endregion



        #region connection

        //if logevent then will send a connection
        private void connectionManagement(object sender, Log_Event e)
        {
            if (e.Log)
            {
                //login
                connect(e.Username);
            }
            else
            {
                //logout
                closeConnection();

            }
        }


        //connection to the server 
        //by default on port 8976
        private void connect(string username)
        {
            this._username = username;

            try
            {
                client = new TcpClient(this._ip, 8976);

                if (client.Connected)
                {
                    //once connected, sends and receives messages 
                    Net.sendMessage(client.GetStream(),new Communication.Message( "@" + username + "connected" + "@" + this.IP));
                    Net.receiveMessage(client.GetStream());

                    //closing form
                    clientLogin.RequestStop();

                    if(home == null)
                    {
                        home = new Thread(new ThreadStart(homeStart));
                        home.Start(); 
                    }
                }
                else
                {
                    MessageBox.Show("Connexion failed"); 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void closeConnection()
        {
            //doesnot WORK
            Net.sendMessage(client.GetStream(), new Communication.Message("@" + _username + " disconnecting" + " @ " + IP));
            client.GetStream().Close();
            client.Close();
            login = new Thread(new ThreadStart(loginStart));
            login.Start();
        }

        #endregion

        private bool clientSent(string m)
        {
            try
            {
                Net.sendMessage(client.GetStream(), new Communication.Message(m));
                return true;
            }
            catch
            {
                return false; 
            }
        }

        //sending message 
        private void sendMessage(object sender, Send_Event e)
        {
            ChatForm chat = sender as ChatForm;
            chat.message_sent(clientSent(e.Message));

        }

        #region Chat 
        private void newChat(object sender, New_Chat_Event e)
        {
            ChatForm new_chat;

            if(findChat(e.Name) == null) 
            {
                if(e.Group && !findGroup(e.Name))
                {
                    mygroups.Add(e.Name);
                    new_chat = new ChatForm(this._username, e.Name, true);
                    new_chat.new_group_modif_event += toGroup;
                    Net.sendMessage(client.GetStream(), new Communication.Message("@" + _username + "#JoinGCtMessage" + "@" + e.Name));

                  
                }
                else
                {
                    return;
                }
            }
            else
            {
                //create private
                new_chat = new ChatForm(this._username, e.Name, false);

            }

            new_chat.send_event += sendMessage;
            chats.Add(new_chat);

            new Thread(() =>
            {
                Application.Run(new_chat);
                // TO do à enlever de liste pour le rouvrir later

            }).Start();


        }


        //Check if chatroom already exists 
        private ChatForm findChat(string name)
        {
            lock (this)
            {
                foreach (ChatForm chat in chats)
                {
                    if(chat.ReceiverName == name)
                    {
                        return chat; 
                    }
                }
                return null; 
            }
        }
        #endregion

        #region groupchat 

        private void createGroupChat(object sender, New_Group_Event e)
        {

        }

        //if i leave or delete a group
        private void toGroup(object sender,New_Group_Modif_Event e)
        {
            if (e.Delete)
            {
                Net.sendMessage(client.GetStream(), new Communication.Message("@" + _username + "#DeleteGC" + "@" + e.Data));

            }
            else
            {
                Net.sendMessage(client.GetStream(), new Communication.Message("@" + _username + "#LeaveGC" + "@" + e.Data)); 

            }

            mygroups.Remove(e.Data);
        }

        private bool findGroup(string name)
        {
            foreach(string n in mygroups)
            {
                if (n == name)
                {
                    return true;
                }
            }
            return false; 
        }
        #endregion
        public void messageHandling(string data)
        {

        }
    }

    #region eventargs

    //for login
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

        public Log_Event(bool l, string u) : base()
        {
            _log = l;
            _username = u; 
        }

    }

    //for chat form boolean whether or not it is a group chat 
    public class New_Chat_Event : EventArgs
    {
        private string _name;
        private bool _group; 

        public string Name
        {
            get { return _name; }
        }

        public bool Group
        {
            get { return _group; }
        }

        public New_Chat_Event(bool g, string n) : base()
        {
            _name = n;
            _group = g; 
        }
    }

    //for group chat / topic creation
    public class New_Group_Event : EventArgs
    {
        private string _name; 
        public string Name
        {
            get { return _name;  }

        }

       public New_Group_Event(string n) : base()
        {
            _name = n; 
        }
    }

    //for leaving the group and deleting it  
    public class New_Group_Modif_Event : EventArgs
    {
        private string _data;
        private bool _do_delete;

        public string Data
        {
            get { return _data; }
        }

        public bool Delete
        {
            get { return _do_delete; }
        }

        public New_Group_Modif_Event(string data, bool del) : base()
        {
            _data = data;
            _do_delete = del;
        }

    }
    //chat sending message 
    public class Send_Event : EventArgs
    {
        private string _message; 
       public string Message
        {
            get { return _message; }
        }

        public Send_Event(string m) : base()
        {
            _message = m; 
        }


    }
    #endregion

}
