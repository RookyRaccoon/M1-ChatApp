using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;

namespace DistantChat
{
    /**
     * Class representing my server 
     */
    class Server
    {
        private static void ProcessClientRequest(object arg)
        {
            TcpClient tcpClient = (TcpClient)arg;

            try
            {
                StreamReader reader = new StreamReader(tcpClient.GetStream());
                StreamWriter writer = new StreamWriter(tcpClient.GetStream());

                string s = String.Empty; 

                while( ! (s=reader.ReadLine()).Equals("Exit")||s==null){

                    Console.WriteLine(s +" from the client");
                    writer.WriteLine(s + " from the server");
                    writer.Flush(); 

                }
                reader.Close();
                writer.Close();
                tcpClient.Close();
                Console.WriteLine("closing client"); 

            } catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if(tcpClient != null)
                {
                    tcpClient.Close();

                }
            }

        }

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
