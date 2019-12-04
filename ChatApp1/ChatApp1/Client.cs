using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace DistantChat
{
    class Client
    {

        public void Main()
        {
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 8080);

                StreamReader reader = new StreamReader(client.GetStream());
                StreamWriter writer = new StreamWriter(client.GetStream());

                String s = String.Empty;

                while (!(s.Equals("Exit")))
                {
                    Console.WriteLine("enter message to send to the server");
                    s = Console.ReadLine();
                    Console.WriteLine();
                    writer.WriteLine(s);
                    writer.Flush();
                    String server_string = reader.ReadLine();
                    Console.WriteLine(server_string);
                }
                reader.Close();
                writer.Close();
                client.Close(); 
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
          
          }

        }
    }

