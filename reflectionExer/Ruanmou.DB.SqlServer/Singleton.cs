using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.DB.SqlServer
{
    /// <summary>
    /// Singleton pattern
    /// </summary>
    public sealed class Singleton
    {
        private static Singleton _Singleton = null;
        private Singleton()
        {
            Console.WriteLine("Singleton is constructed");
        }

        static Singleton()
        {
            _Singleton = new Singleton();
        }

        public static Singleton GetInstance()
        {
            return _Singleton;
        }
    }
}
