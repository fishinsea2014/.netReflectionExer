using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ruanmou.DB.Interface;
using Ruanmou.DB.MySql;
using Ruanmou.DB.Oracle;
using Ruanmou.DB.SqlServer;
using Ruanmou.Model;


namespace reflectionExer
{
    class Program
    {
        static void Main(string[] args)
        {


            {
                Console.WriteLine("************************Reflection*****************");
                //Assembly assembly = Assembly.Load("Ruanmou.DB.MySql");
                //Ignore the suffix of dll, load it form current dir
                //Or load dll by an full path
                //Assembly assembly1 = Assembly.LoadFile(@"D:\ruanmou\online11\20180425Advanced11Course2Reflection\MyReflection\MyReflection\bin\Debug\Ruanmou.DB.MySql.dll");
                // Or load dll by an full name
                //    Assembly assembly2 = Assembly.LoadFrom("Ruanmou.DB.MySql.dll");
                //    foreach (var item in assembly.GetModules())
                //    {
                //        Console.WriteLine(item.FullyQualifiedName);
                //    }
                //    foreach (var item in assembly.GetTypes())
                //    {
                //        Console.WriteLine(item.FullName);
                //    }
                //}

                //{
                //    Console.WriteLine("Reflection exercise");
                //    Console.WriteLine("===============Common==============");
                //    IDBHelper iDBHelper = new MySqlHelper();
                //    iDBHelper.Query();

                //    Console.WriteLine("===============Reflection==============");
                //    Assembly assembly = Assembly.Load("Ruanmou.DB.MySql");
                //    //Assembly assembly1 = Assembly.Load(@"D:\my_projects\.netReflectionExer\reflectionExer\reflectionExer\bin\Debug\Ruanmou.DB.MySql.dll");
                //    Assembly assembly2 = Assembly.LoadFrom("Ruanmou.DB.MySql.dll");

                //    foreach (var item in assembly.GetModules())
                //    {
                //        Console.WriteLine(item.FullyQualifiedName);
                //        Console.WriteLine("===============Common==============");

                //    }

                //    foreach (var item in assembly.GetTypes())
                //    {
                //        Console.WriteLine(item.FullName);
                //    }

                //    Type type = assembly.GetType("Ruanmou.DB.MySql.MySqlHelper");
                //    object oDBHelper = Activator.CreateInstance(type);
                //    //oDBHelper.Query(); // Cannot call the Query() method
                //    IDBHelper iDBHelper1 = (IDBHelper)oDBHelper;
                //    iDBHelper1.Query();
                //}

                //IOC， inversion of control, is a desing principle 控制翻转，将多个Object对象分开，在中间做管理，降低耦合性
                //{
                //    Console.WriteLine("===============Reflection Factory configration programming==============");
                //    IDBHelper iDBHelper = Factory.CreateHelper();
                //    iDBHelper.Query();
                //}

                //{
                //    Console.WriteLine("===============Use reflection to create an instance==============");
                //    Assembly assembly = Assembly.Load("Ruanmou.DB.MySql");
                //    Type type = assembly.GetType("Ruanmou.DB.SqlServer.Singleton");
                //    //Reflection can call a private method and break the singleton model.
                //    //Singleton singleton2 = (Singleton)Activator.CreateInstance(type, true);

                //}

                //{//Create reflection object by generic method.
                //    Assembly assembly = Assembly.Load("Ruanmou.DB.SqlServer");
                //    Type type = assembly.GetType("Ruanmou.DB.SqlServer.GenericClass`3");
                //    //object oGeneric = Activator.CreateInstance(type);
                //    Type newType = type.MakeGenericType(new Type[] { typeof(int), typeof(string), typeof(DateTime) });
                //    object oGeneric = Activator.CreateInstance(newType);
                //}
                //MVC Model, View and Controller 
                //{
                //    Console.WriteLine("===============Use reflection to create a method==============");
                //    Assembly assembly = Assembly.Load("ruanmou.db.sqlserver");
                //    Type type = assembly.GetType("ruanmou.db.sqlserver.reflectiontest");
                //    object oreflectionTest = Activator.CreateInstance(type);

                //    {
                //        MethodInfo method = type.GetMethod("Show1");
                //        method.Invoke(oreflectionTest, null);
                //    }

                //}

                {
                    //ORM Object Relational Mapping 采用xml描述对象-关系映射细节，只要提供持久化类与表的映射关系，ORM框架就能参照映射文件的信
                    //息，把对象持久化到数据库中。当前有四种：Hibernate（典型常用！）,iBATIS,Mybatis,EclipseLink；
                    Console.WriteLine("************************Reflection+Property/Field*****************");
                    //General ways to reference a class
                    People people = new People(); //
                    people.Id = 123;
                    people.Name = "Lutte";
                    people.Description = "New student";

                    Console.WriteLine($"people.Id={people.Id}");
                    Console.WriteLine($"people.Name={people.Name}");
                    Console.WriteLine($"people.Description={people.Description}");

                    //Create a People object by reflection
                    Type type = typeof(People);
                    object oPeople = Activator.CreateInstance(type);
                    foreach (var prop in type.GetProperties()) //Get the attrubutes of People object
                    {
                        Console.WriteLine(type.Name);
                        Console.WriteLine(prop.Name);
                        Console.WriteLine(prop.GetValue(oPeople));
                        if (prop.Name.Equals("Id"))
                        {
                            prop.SetValue(oPeople, 234);
                        }
                        else if (prop.Name.Equals("Name"))
                        {
                            prop.SetValue(oPeople, "风潇潇");
                        }
                        Console.WriteLine($"{type.Name}.{prop.Name}={prop.GetValue(oPeople)}");
                    }
                    foreach (var field in type.GetFields())
                    {
                        Console.WriteLine(type.Name);
                        Console.WriteLine(field.Name);
                        Console.WriteLine(field.GetValue(oPeople));
                        if (field.Name.Equals("Description"))
                        {
                            field.SetValue(oPeople, "高级班的新学员");
                        }
                        Console.WriteLine($"{type.Name}.{field.Name}={field.GetValue(oPeople)}");
                    }
                }

                Console.ReadLine();





            }
        }
    }
}
