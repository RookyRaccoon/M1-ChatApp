using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientForm
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread client1 = new Thread(new ThreadStart(starting));
            client1.Start();
            Thread client2 = new Thread(new ThreadStart(starting2));
            client2.Start();
        }

    public static void starting()
        {
            new Client("127.0.0.1"); 
        }
        public static void starting2()
        {
            new Client("127.0.0.2");
        }
    }
}
