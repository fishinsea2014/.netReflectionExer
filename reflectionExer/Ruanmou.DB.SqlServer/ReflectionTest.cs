using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.DB.SqlServer
{
    /// <summary>
    /// Test reflection
    /// </summary>
    public class ReflectionTest
    {
        #region Identity
        /// <summary>
        /// Construction without arguments
        /// </summary>
        public ReflectionTest()
        {
            Console.WriteLine("This is construction of {0} without arguments", this.GetType());
        }

        /// <summary>
        /// Construction with arguments
        /// </summary>
        /// <param name="name"></param>
        public ReflectionTest(string name)
        {
            Console.WriteLine("This is construction of {0} with arguments", this.GetType());
        }

        public ReflectionTest(int id)
        {
            Console.WriteLine("This is construction of {0} with arguments", this.GetType());
        }
        #endregion

        #region Method
        /// <summary>
        /// Method without arguments
        /// </summary>
        public void Show1()
        {
            Console.WriteLine("This is the show1 method of {0}", this.GetType());
        }
        /// <summary>
        /// Method with arguments
        /// </summary>
        /// <param name="id"></param>
        public void Show2(int id)
        {

            Console.WriteLine("This is the show2 method of {0}", this.GetType());
        }
        /// <summary>
        /// First method of reloading 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public void Show3(int id, string name)
        {
            Console.WriteLine("This is the show3 method of {0}", this.GetType());
        }
        /// <summary>
        /// Second method of reloading 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        public void Show3(string name, int id)
        {
            Console.WriteLine("This is the show3_2 method of {0}", this.GetType());
        }
        /// <summary>
        /// Third method of reloading 
        /// </summary>
        /// <param name="id"></param>
        public void Show3(int id)
        {

            Console.WriteLine("This is the show3_3 method of {0}", this.GetType());
        }
        /// <summary>
        /// Fourth method of reloading 
        /// </summary>
        /// <param name="name"></param>
        public void Show3(string name)
        {

            Console.WriteLine("This is the show3_4 method of {0}", this.GetType());
        }
        /// <summary>
        /// Fifth method of reloading 
        /// </summary>
        public void Show3()
        {

            Console.WriteLine("This is the show3_1 method of {0}", this.GetType());
        }
        /// <summary>
        /// Private method
        /// </summary>
        /// <param name="name"></param>
        private void Show4(string name)
        {
            Console.WriteLine("This is the show4 method of {0}", this.GetType());
        }
        /// <summary>
        /// Static method
        /// </summary>
        /// <param name="name"></param>
        public static void Show5(string name)
        {
            Console.WriteLine("This is the show5 method of {0}", typeof(ReflectionTest));
        }
        #endregion
    }
}
