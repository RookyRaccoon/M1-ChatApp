using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace DistantChat
{
    /**
     * Class representing my server 
     */
    class Server
    {
        

        public static void Main()
        {
            IPAddress iPAddress = new IPAddress(new byte[] { 127, 0, 0, 1 });
            TcpListener tcpListener = new TcpListener(iPAddress, 8080);

            try
            {
                tcpListener.Start();
                Console.WriteLine("Server started ..."); 

                while (true)
                {
                    Console.WriteLine("Waiting on client requests....");
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    Console.WriteLine("Accepted new client");
                    Thread t = new Thread(ProcessClientRequest);
                    t.Start(tcpClient); 
                }


            } catch (Exception e)
            {
                Console.WriteLine(e); 
            } finally
            {
                if(tcpListener != null)
                {
                    tcpListener.Stop(); 
                }
            }



        }
    }
}
