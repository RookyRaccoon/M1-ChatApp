using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;

namespace Server
{
    /**
     * Class representing my server 
     */
    class Server
    {
        //server listens on port 8976 for any IP address
        private TcpListener server = new TcpListener(IPAddress.Any, 8976); 
        
        private List<Client> connectedClients = new List<Client>(); //

        public void startListen()
        {
            
                server.Start();
                Console.WriteLine("Server started...");
                //Starting a new thread to handle clients 
                //lambda takes no param 
                new Thread(() => {
                    try
                    {
                        while (true)
                        {
                            Console.WriteLine("Waiting for clients");
                            TcpClient client = server.AcceptTcpClient();
                            Client c = new Client() { username = "", IPAdress = "", tcpClient = client };
                            connectedClients.Add(c);
                            Console.WriteLine("Accepted new client connection");
                            //TO DO SET STREAM 


                        }
                    }
                    catch
                    {

                    }
                    finally
                    {

                    }

                }).Start();




            }
           
         }


    


    public struct Client{
        public String username { get; set; }
        public String IPAdress { get; set; }

        public TcpClient tcpClient { get; set; }

        }

    
}
