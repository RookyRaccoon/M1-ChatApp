using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Communication;

namespace Server
{
    /// <summary>
    /// Server for my chat app
    /// </summary>
    public partial class ServerForm : Form
    {
        //My server
        private TcpListener server = new TcpListener(IPAddress.Any, 8976);
        private bool server_status = false;

        //Client infos 
        private List<Client> clientsConnected = new List<Client>();
        private List<GroupChat> listGroupChat = new List<GroupChat>();

        //handling of threads 
        private Object thisLock = new Object();

        //form
        private delegate void SetTextStatus(string data);
        private delegate void SetTextButton(string data);

        public ServerForm()
        {
            InitializeComponent();
            ListenButton_Click(this, null);
        }


        private void Start_listening()
        {
            server.Start(); // Starts Listening 
            listenButton.Text = "Stop Listening";
            server_status = true;
            logServerText("Waiting for clients to connect");

            new Thread(() =>
            {
                while (server_status)
                {
                    try
                    {
                        TcpClient client = server.AcceptTcpClient();
                        Client client_tmp = new Client() { Name = "", IP = "", tcpClient = client };
                        clientsConnected.Add(client_tmp);
                        logServerText("client " + client.Client.LocalEndPoint+ " has joined");
                        Net.sendMessage(client.GetStream(), new Communication.Message("client_connected"));

                        if (client.Connected)
                        {
                            Net.receiveMessage(client.GetStream());
                        }
                    }
                    catch
                    {
                        server_status = false;
                        logServerText("Status : Server is off.");
                        startButtonText("Listen");
                    }
                }
            }).Start();

        }

        private void ServerBroadcast(string data)
        {
            lock (server)
            {
                for(int i=0; i<clientsConnected.Count; i++)
                {
                    try
                    {
                        Net.sendMessage(clientsConnected[i].tcpClient.GetStream(), new Communication.Message(data));

                    }
                    catch
                    {
                        MessageBox.Show("could not broadcast to clients");
                    }
                }
            }
        }


        //A revoir 
        private void ServerBroadcast_group(GroupChat groupchat, string message, string sender)
        {

            lock (server)
            {
                for (int j = 0; j < groupchat.clientsSubscribed.Count; j++)
                {
                    for (int k = 0; k < clientsConnected.Count; k++)
                    {
                        if (groupchat.clientsSubscribed[j] == clientsConnected[k].Name && groupchat.clientsSubscribed[j] != sender)
                        {
                            Net.sendMessage(clientsConnected[k].tcpClient.GetStream(),new Communication.Message( message));
                        }
                    }
                }
            }
        }


        #region Client handling

        public void messageHandling(Communication.Message message, TcpClient client)
        {
            string data_content = message.Content;
            char[] delimiterChars = { '@', '#' };
            string[] words = data_content.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < words.Length; i++)
            {
            }
            //words[0] --> name of the sender
            //words[1] --> type of message
            //words[2] --> optionnal : name of recepient
            //words[3] --> optionnel : message for recepient

            string type_message = words[1];
            string receiver = words[2];

            Client myClient = new Client() { Name = words[0], IP = words[2], tcpClient = client };

            //System.Console.WriteLine(type_message);

            if (type_message == "connection")
            {
                

                //connection
                logServerText("Status : " + myClient.Name + " connected.");
                modifyListConnectedClients(myClient);
                Update_list_client(true);
                ServerBroadcast(listConnectedClients_parser());

            }
            else if (type_message == "disconnection")
            {

                //disconnection
                removeListConnectedClients(myClient);
                logServerText("Status : " + myClient.Name + " is gone.");

                Update_list_client(true);

                ServerBroadcast(listConnectedClients_parser());

            }
            /*
            else if (type_message == "NewGroupChat")
            {
                List<String> tmp_list_sub = new List<String>();
                tmp_list_sub.Add(myClient.Name);

                GroupChat group_tmp = new GroupChat() { clientsSubscribed = tmp_list_sub, topic = words[2] };
                listGroupChat.Add(group_tmp);

                Update_list_client(true);
            }
            else if (type_message == "GroupChatMessage")
            {
                string data = words[3];
                logServerText(Name + " to " + receiver + " : " + data);

                GroupChat group = Get_Group_Chat(receiver);
                if (group.topic != null && group.clientsSubscribed != null)
                {
                    ServerBroadcast_group(this, listConnectedClients, group, data_string, client_tmp.Name);
                }

            }
            else if (type_message == "JoinGroupChatMessage")
            {
                ModifyListGroup(words[2], myClient.Name);

                GroupChat group = Get_Group_Chat(receiver);
                if (group.topic != null && group.clientsSubscribed != null)
                {
                    ServerBroadcast_group(this, listConnectedClients, group, data_string, client_tmp.Name);
                }
            }
            else if (type_message == "LeaveGroupChatMessage")
            {
                remove_item_list_Group(words[2], false, myClient.Name);

                GroupChat group = Get_Group_Chat(receiver);
                if (group.topic != null && group.clientsSubscribed != null)
                {
                    Net.ServerBroadcast_group(this, listConnectedClients, group, data_string, client_tmp.Name);
                }
            }
            else if (type_message == "DeleteGroupChat")
            {
                GroupChat group = Get_Group_Chat(receiver);
                if (group.topic != null && group.clientsSubscribed != null)
                {
                    Net.ServerBroadcast_group(this, listConnectedClients, group, data_string, client_tmp.Name);
                }

                //Console.WriteLine("Deleting chat");
                remove_item_list_Group(words[2], true);
                Update_list_client(true);
            }*/
            else if (type_message == "message")
            {

                //normal message
                string data = words[3];
                logServerText(Name + " to " + receiver + " : " + data);

                for (int i = 0; i < clientsConnected.Count; i++)
                {
                    if (receiver == clientsConnected[i].Name)
                    {

                        data = data_content;
                        Net.sendMessage(clientsConnected[i].tcpClient.GetStream(),new Communication.Message(data));
                    }
                }
            }
        }

        /// <summary>
        /// Method to check if client list needs to be updated
        /// </summary>
        /// <param name="single_iteration"></param>
        public void Update_list_client(bool single_iteration)
        {
            new Thread(() =>
            {
                do
                {
                    lock (thisLock)
                    {
                        for (int i = 0; i < clientsConnected.Count; i++)
                        {
                            Ping pingSender = new Ping();
                            IPAddress address = IPAddress.Parse(clientsConnected[i].IP);

                            PingReply reply = pingSender.Send(address);

                            if (reply.Status == IPStatus.Success)
                            {
                                /*//Console.WriteLine("Address: {0}", reply.Address.ToString());
                                //Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                                //Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                                //Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                                //Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);*/
                            }
                            else
                            {
                                removeListConnectedClients(clientsConnected[i]);
                                logServerText("Status : " + clientsConnected[i].Name + " is gone.");
                                break;
                            }
                        }
                    }

                    ServerBroadcast(listConnectedClients_parser());

                    if (!single_iteration) { Thread.Sleep(5000); }

                } while (server_status && !single_iteration);

                if (single_iteration) { MessageBox.Show("Updating List clients on server side, only one iteration is done."); }

            }).Start(); // Start the Thread
        }

        /// <summary>
        /// Modify client connected to my server 
        /// </summary>
        /// <param name="myclient"></param>
        public void modifyListConnectedClients(Client myclient)
        {
            bool flag = false;
            int index = 0;

            for (int i = 0; i < clientsConnected.Count; i++)
            {
                if (clientsConnected[i].tcpClient == myclient.tcpClient)
                {
                    flag = true;
                    index = i;
                    break;
                }
            }

            if (flag)
            {   
                clientsConnected[index] = new Client() { Name = myclient.Name, IP = myclient.IP, tcpClient = myclient.tcpClient };
            }
        }

        /// <summary>
        /// Remove a client 
        /// </summary>
        /// <param name="myClient"></param>
        public void removeListConnectedClients(Client myClient)
        {
            bool flag = false;
            int index = 0;

            for (int i = 0; i < clientsConnected.Count; i++)
            {
                if (clientsConnected[i].tcpClient == myClient.tcpClient)
                {
                    flag = true;
                    index = i;
                    break;
                }
            }

            if (flag)
            {
                //client is removed 
                clientsConnected[index].tcpClient.Close();
                clientsConnected.RemoveAt(index);
            }
        }

        /// <summary>
        /// reformating of display of my clients connected 
        /// </summary>
        /// <returns></returns>
        public String listConnectedClients_parser()
        {
            string list = "@server#List_clients";
            for (int i = 0; i < clientsConnected.Count; i++)
            {
                list += "@" + clientsConnected[i].Name;
            }

            if (listGroupChat.Count > 0)
            {
                list += "@";
                for (int i = 0; i < listGroupChat.Count; i++)
                {
                    list += "&" + listGroupChat[i].topic;
                }
            }

            return list;
        }


        public void ModifyListGroup(String topic, String name)
        {
            bool flag = false;
            int index = 0;

            for (int i = 0; i < listGroupChat.Count; i++)
            {
                if (listGroupChat[i].topic == topic)
                {
                    flag = true;
                    index = i;
                    break;
                }
            }

            if (flag)
            {
                listGroupChat[index].clientsSubscribed.Add(name);
            }
        }

        public void remove_item_list_Group(String name_group, bool delete, string name_client = "")
        {
            bool flag = false;
            int index = 0;

            for (int i = 0; i < listGroupChat.Count; i++)
            {
                if (listGroupChat[i].topic == name_group)
                {
                    flag = true;
                    index = i;
                    break;
                }
            }
            if (flag)
            {
                bool flag_2 = false;
                int index_2 = 0;

                if (delete)
                {
                    listGroupChat.RemoveAt(index);
                }
                else
                {
                    //on veut quitter le groupe donc enlever un abonné 
                    for (int i = 0; i < listGroupChat[index].clientsSubscribed.Count; i++)
                    {
                        if (listGroupChat[index].clientsSubscribed[i] == name_client)
                        {
                            flag_2 = true;
                            index_2 = i;
                            break;
                        }
                    }
                    if (flag_2)
                    {
                        listGroupChat[index].clientsSubscribed.RemoveAt(index_2);
                    }
                }
            }
        }

        public GroupChat Get_Group_Chat(string name)
        {
            for (int i = 0; i < listGroupChat.Count; i++)
            {

                if (name == listGroupChat[i].topic)
                {
                    return listGroupChat[i];
                }
            }

            GroupChat tmp = new GroupChat() { clientsSubscribed = null, topic = null };

            return tmp;
        }
        #endregion

        #region text logs
        //server logs 
        public void logServerText(string data)
        {
            if (this.serverStatus.InvokeRequired)
            {
                SetTextStatus d = new SetTextStatus(logServerText);
                this.Invoke(d, new object[] { data });
            }
            else
            {
                serverStatus.Text += System.Environment.NewLine + data;
            }
        }

        //listen button logs 
        public void startButtonText(string data)
        {
            if (this.listenButton.InvokeRequired)
            {
                SetTextButton d = new SetTextButton(startButtonText);
                this.Invoke(d, new object[] { data });
            }
            else
            {
                listenButton.Text = data;
            }
        }

        #endregion

        #region Buttons

        private void SendTextButton_Click(object sender, EventArgs e)
        {
            string message = "";
            try
            {
                message = serverSendText.Text;

                if (message != "")
                {
                    message = "@Server" + "#ServerM" + "@All" + "#" + message;
                    ServerBroadcast(message);
                    logServerText("send " + message +" to all");
                    serverSendText.Clear();
                    
                }
            }
            catch
            {
                MessageBox.Show("Could not send data, no clients connected"); 
            }

        }
        private void ListenButton_Click(object sender, EventArgs e)
        {
            if (!server_status)
            {
                Start_listening();
                //Update_list_client(false);
            }
            else
            {
                try
                {
                    // Net.ServerBroadcast(this, listConnectedClients, "server_close");
                    //Net.ServerSend(client, "server_close");
                    //on notifie le client que le server ferme
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                server.Stop();
            }

        }

        #endregion

       
    }


    public struct Client
        {
            public string Name { get; set; }
            public string IP { get; set; }

            public TcpClient tcpClient { get; set; }

        }

    public struct GroupChat
        {
            public List<String> clientsSubscribed;
            public string topic { get; set; }
        }
    
}
