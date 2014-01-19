using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
      public class Singleton
    {
        // .NET guarantees thread safety for static initialization
        private static Singleton instance = null;
        private string ComputerName { get; set; }
        
        private Singleton()
        {
            //To DO: Remove below line
            Console.WriteLine("Singleton Intance");

            ComputerName = "Mirza";
            
        }
        // Lock synchronization object
        private static object syncLock = new object();

        public static Singleton Instance
        {
            get
            {
                // Support multithreaded applications through
                // 'Double checked locking' pattern which (once
                // the instance exists) avoids locking each
                // time the method is invoked
                lock (syncLock)
                {
                    if (Singleton.instance == null)
                        Singleton.instance = new Singleton();
                    else
                        Console.WriteLine("Same Instance");
                    return Singleton.instance;
                }
            }
        }

        public void Show()
        {
            Console.WriteLine("Computer Information is : Computer Name={0} ", ComputerName);
        }

    }

}
