using System;
using System.Collections.Generic;
using System.Text;

namespace Communication
{
    [Serializable]
    public class Message
    {
        private string content; 

        public string Content
        {
            get { return content; }
        }

       public Message(string m)
        {
            content = m; 
        }
    }
}
