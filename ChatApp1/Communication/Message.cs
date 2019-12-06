using System;
using System.Collections.Generic;
using System.Text;

namespace Communication
{
    [Serializable]
    public class Message
    {
        private String message;

        public Message(String m)
        {
            this.message = m; 
        }

        public String getMessage()
        {
            return this.message; 
        }
    }
}
