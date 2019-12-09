using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Server;
namespace Server
{
    public class Net
    {
        public static void sendMessage(Stream s, String m)
        {
            BinaryFormatter binary = new BinaryFormatter();
            binary.Serialize(s,m); 
        }

        public static String receiveMessage(Stream s)
        {
            BinaryFormatter binary = new BinaryFormatter();
            return (String)binary.Deserialize(s);

        }

    }
}
