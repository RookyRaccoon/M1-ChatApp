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
        }

    public static void starting()
        {
            new Client("127.0.0.1"); 
        }
    }
}
