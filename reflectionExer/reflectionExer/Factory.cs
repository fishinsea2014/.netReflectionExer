using Ruanmou.DB.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace reflectionExer
{
    class Factory
    {
        //Get dll file name and type from config file, can use different database according to the info in the App.config.
        //When adding an new dabase, just copy corresponding dll file the running directory, and update the App.config file.
        private static string IDBHelperConfig = ConfigurationManager.AppSettings["IDBHelperConfig"];
        private static string DllName = IDBHelperConfig.Split(',')[1];
        private static string TypeName = IDBHelperConfig.Split(',')[0];
        public static IDBHelper CreateHelper()
        {
            //Assembly assembly = Assembly.Load("Ruanmou.DB.MySql"); //-1. Load dll file
            Assembly assembly = Assembly.Load(DllName); //-1. Load dll file

            //Create an instance by reflection
            //Type type = assembly.GetType("Ruanmou.DB.MySql.MySqlHelper"); //-2. Get the type of class
            Type type = assembly.GetType(TypeName); //-2. Get the type of class

            object oHelper = Activator.CreateInstance(type); //-3. Create objects
            IDBHelper dBHelper = (IDBHelper)oHelper; // -4. Convert Object to corresponding object
            return dBHelper;
        }
    }
}
