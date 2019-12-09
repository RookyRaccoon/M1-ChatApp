using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class ServerForm : Form
    {

        private TcpListener server = new TcpListener(IPAddress.Any,8976);
        private bool server_status = false; 
        private List<Client> clientsConnected = new List<Client>();
        
        private delegate void SetTextStatus(string data);
        private delegate void SetTextButton(string data);

        public ServerForm()
        {
            InitializeComponent();
            ConnectButton_Click(this, null);
        }


        private void Start_listening()
        {
            server.Start(); // Starts Listening 
            connectButton.Text = "Stop Listening";
            server_status = true;
            logServerText("server on =" + server_status); 

            new Thread(() => 
            {
                //dont loose connection, loop
                while (server_status)
                {
                    logServerText("Status : Waiting For Connection...");

                    try
                    {   //accept new clients
                        TcpClient client = server.AcceptTcpClient();


                        Client client_struc = new Client() { Name = "", IP = "", tcpClient = client };

                        clientsConnected.Add(client_struc);

                        Net.sendMessage(client.GetStream(),"Client connected");

                        if (client.Connected) 
                        {
                            Net.receiveMessage(client.GetStream()); 
                        }
                    }
                    catch
                    {
                        //detect when server is stopped
                        server_status = false;
                        logServerText("Server not connected to clients");
                        startButtonText("Listen");
                    }
                }
            }).Start();
        }


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
            if (this.connectButton.InvokeRequired)
            {
                SetTextButton d = new SetTextButton(startButtonText);
                this.Invoke(d, new object[] { data });
            }
            else
            {
                connectButton.Text = data;
            }
        }
        private void SendButton_Click(object sender, EventArgs e)
        {

        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (!server_status)
            {
                Start_listening();

            }
            else
            {

            }

            server.Stop();
        }
    }

    public struct Client
    {
        public string Name { get; set; }
        public string IP { get; set; }

        public TcpClient tcpClient { get; set; }

    }
}
