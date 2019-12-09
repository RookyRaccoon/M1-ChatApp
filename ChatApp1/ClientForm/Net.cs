using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientForm
{
    class Net
    {
        public event EventHandler<Log_Event> Log_event;
        public delegate void DelegateRasingBool(bool log);

        public  void sendMessage(Stream s, String m)
        {
            BinaryFormatter binary = new BinaryFormatter();
            binary.Serialize(s, m);
        }

        public  void receiveMessage(Client c, Stream s)
        {
            new Thread(() =>
            {
                BinaryFormatter binary = new BinaryFormatter();
                string data = (String)binary.Deserialize(s);
                c.messageHandling(data);
            }).Start(); 
           

        }
    }
}
