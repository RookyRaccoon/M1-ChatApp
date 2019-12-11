using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Communication
{
    public class Net
    {
        public static void sendMessage(Stream s, Message m)
        {
            BinaryFormatter binary = new BinaryFormatter();
            binary.Serialize(s, m);
        }

        public static Message receiveMessage(Stream s)
        {   
                BinaryFormatter binary = new BinaryFormatter();
                return (Message)binary.Deserialize(s);
        }
    }
}
