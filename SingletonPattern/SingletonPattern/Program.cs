using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    class Program
    {
                        //Make all constructors of the class private.
                        //Create a private static member that’s of the same type of the class.
                        //Create a public static member that returns and instance of that class.

        static void Main(string[] args)
        { 

            var X = PaymentService.GetInstance();
        }


            public class PaymentService
        {
            private static object _SyncRoot;
            private static PaymentService _Instance;

            private PaymentService()
            { }

            public static PaymentService GetInstance()
            {
                if (_Instance == null)
                {
                    // obtain lock so no other threads can access it until the current thread is done
                    lock (_SyncRoot)
                    {
                        // is it still null? another thread may have initialized _Instance before
                        // the current thread obtained the lock
                        if (_Instance == null)
                        {
                            _Instance = new PaymentService();
                        }
                    }
                }

                return _Instance;
            }
        }
    }
}
