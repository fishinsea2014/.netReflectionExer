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
    /// <summary>
    /// Create a object factory for db helper
    /// </summary>
    public class Factory
    {

        private static string IDBHelperConfig = ConfigurationManager.AppSettings["IDBHelperConfig"];
        private static string DllName = IDBHelperConfig.Split(',')[1];
        private static string TypeName = IDBHelperConfig.Split(',')[0];

        public static IDBHelper CreateHelper()
        {
            Assembly assembly = Assembly.Load(DllName);
            Type type = assembly.GetType(TypeName);
            object ODBHelper = Activator.CreateInstance(type);
            IDBHelper iDBHelper = (IDBHelper)ODBHelper;
            return iDBHelper;
        }
    }
}
