using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace DistantChat
{
    /**
     * Class representing my server 
     */
    class Server
    {
        private int port; 

        public Server(int port)
        {
            this.port = port; 

        }

        public void start()
        {
            TcpListener tcpListener = new TcpListener(new IPAddress(new byte[] { 127, 0, 0, 1 }), port);
            tcpListener.Start(); 

        }
    }
}
