using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ruanmou.DB.Interface;
using Ruanmou.DB.MySql;
//using Ruanmou.DB.Oracle;
using Ruanmou.DB.SqlServer;
using Ruanmou.Model;


namespace reflectionExer
{
    /// <summary>
    /// Refelction:
    /// --Advantage: Dymanmic
    /// --Disadvantage: 
    /// ----Complex
    /// ----Avoid the check of compailer
    /// ----Time consumming
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("************************Reflection in class exercise*****************");
            try
            {
                {
                    //Normal ways
                    IDBHelper d = new MySqlHelper();
                    d.Query();
                }

                {
                    //Reflection
                    Assembly assembly = Assembly.Load("Ruanmou.DB.MySql"); //-1. Load dll file
                                                                           //Assembly assemblyFromFile = Assembly.LoadFile(@"full path of dll file");
                                                                           //Assembly assemblyFromDll = Assembly.LoadFrom("Ruanmou.DB.MySql.dll"); // Full dll name
                    foreach (var item in assembly.GetModules())
                    {
                        Console.WriteLine($"Modules: {item.FullyQualifiedName}");
                    }

                    foreach (var item in assembly.GetTypes())
                    {
                        Console.WriteLine($"Types: {item.FullName}");
                    }

                    //Create an instance by reflection
                    Type type = assembly.GetType("Ruanmou.DB.MySql.MySqlHelper"); //-2. Get the type of class
                    object oHelper = Activator.CreateInstance(type); //-3. Create objects
                    IDBHelper dBHelper = (IDBHelper)oHelper; // -4. Convert Object to corresponding object
                    dBHelper.Query(); // -5. Call methods
                }
                {
                    //This is IOC
                    //Use reflection + factory + config
                    IDBHelper dBHelper = Factory.CreateHelper();
                    dBHelper.Query();

                }

                {
                    //Reflection + object

                    {
                        //Break the singleton pattern
                        //Assembly assembly = Assembly.Load("Ruanmou.DB.SqlServer");
                        //Type type = assembly.GetType("Ruanmou.DB.SqlServer.Singleton");
                        //Singleton st1 = (Singleton)Activator.CreateInstance(type, true);
                        //Singleton st2 = (Singleton)Activator.CreateInstance(type, true); //Here st1 and st2 is not the same one.
                    }

                    {
                        //Test variety type of reflection
                        Assembly assembly = Assembly.Load("Ruanmou.DB.SqlServer");
                        Type type = assembly.GetType("Ruanmou.DB.SqlServer.ReflectionTest");
                        object oReflectionTestNoArgu = Activator.CreateInstance(type);
                        object oReflectionTestWithArgu1 = Activator.CreateInstance(type, new object[] { 123 });
                        object oReflectionTestWithArgu2 = Activator.CreateInstance(type, new object[] { "123" });
                    }

                    {
                        //By generic
                        Assembly assembly = Assembly.Load("Ruanmou.DB.SqlServer");
                        Type type = assembly.GetType("Ruanmou.DB.SqlServer.GenericClass`3"); //3 means there are three parameters
                        //object OGeneric = Activator.CreateInstance(type); //This will not work.
                        Type usefulType = type.MakeGenericType(new Type[] { typeof(int), typeof(string), typeof(DateTime) });
                        object OGeneric = Activator.CreateInstance(usefulType);
                    }
                }

                {
                    //Refelction + Method
                    Assembly assembly = Assembly.Load("Ruanmou.DB.SqlServer");
                    Type type = assembly.GetType("Ruanmou.DB.SqlServer.ReflectionTest");
                    object oReflectionTest = Activator.CreateInstance(type);

                    //Find all method names
                    {
                        foreach (var item in type.GetMethods())
                        {
                            Console.Write($"{item.Name}, ");
                        }
                    }

                    {
                        MethodInfo method = type.GetMethod("Show1");
                        method.Invoke(oReflectionTest, null); //No arguments
                    }

                    {
                        MethodInfo method = type.GetMethod("Show2");
                        method.Invoke(oReflectionTest, new object[] { 123 }); // With an int argument
                    }

                    {
                        //For static method
                        MethodInfo method = type.GetMethod("Show5");
                        method.Invoke(oReflectionTest, new object[] { "Jason" }); // With an int argument
                        method.Invoke(null, new object[] { "Jason" }); // With an int argument
                    }

                    {
                        //For override methods
                        {
                            MethodInfo method = type.GetMethod("Show3", new Type[] { });
                            method.Invoke(oReflectionTest, new object[] {}); // Without argument
                        }

                        {
                            MethodInfo method = type.GetMethod("Show3", new Type[] { typeof(int)});
                            method.Invoke(oReflectionTest, new object[] {123 }); // With an int argument
                        }

                        {
                            MethodInfo method = type.GetMethod("Show3", new Type[] { typeof(string) });
                            method.Invoke(oReflectionTest, new object[] { "123" }); // With an string argument
                        }

                        {
                            MethodInfo method = type.GetMethod("Show3", new Type[] { typeof(int),typeof(string) });
                            method.Invoke(oReflectionTest, new object[] {123, "123" }); // With two arguments
                        }


                        { //For private method
                            MethodInfo method = type.GetMethod("Show4",BindingFlags.Instance | BindingFlags.NonPublic);
                            method.Invoke(oReflectionTest, new object[] { "Hello"}); 
                        }

                        { //For Generic class and methods
                            Type typeG = assembly.GetType("Ruanmou.DB.SqlServer.GenericDouble`1"); //With one parameter
                            Type usefulTypeG = typeG.MakeGenericType(new Type[] { typeof(int) });
                            object oReflectionTestG = Activator.CreateInstance(usefulTypeG);
                            MethodInfo method = usefulTypeG.GetMethod("Show");
                            MethodInfo methodG   = method.MakeGenericMethod(new Type[] { typeof(string), typeof(DateTime) });
                            methodG.Invoke(oReflectionTestG, new object[] { 111, "Hello", DateTime.Now });

                        }

                    }

                    {
                        //Reflection + property / Field, used in ORM
                        Console.WriteLine("==============Reflection+Property/Field============");
                        Type typeP = typeof(People);
                        object oPeople = Activator.CreateInstance(typeP); //Get an reflection people instance

                        //For properties
                        foreach (var item in typeP.GetProperties())
                        {
                            Console.WriteLine(typeP.Name);
                            Console.WriteLine(item.Name);
                            Console.WriteLine(item.GetValue(oPeople)); //Show the properties of people
                            if (item.Name.Equals("Id")) item.SetValue(oPeople, 123);
                            if (item.Name.Equals("Name")) item.SetValue(oPeople, "NoName");
                            Console.WriteLine($"{type.Name}.{item.Name}={item.GetValue(oPeople)}");
                        }

                        //For fields
                        foreach (var item in typeP.GetFields())
                        {
                            Console.WriteLine(typeP.Name);
                            Console.WriteLine(item.Name);
                            Console.WriteLine(item.GetValue(oPeople)); //Show the properties of people
                            if (item.Name.Equals("Description")) item.SetValue(oPeople, "He is a driver");
                            Console.WriteLine($"{type.Name}.{item.Name}={item.GetValue(oPeople)}");
                        }                       

                    }

                    //Create a peopleDTO instance according to a people object by relfection
                    {
                        Console.WriteLine("======Create a peopleDTO instance according to a people object by relfection=======");
                        People people = new People();
                        people.Id = 111;
                        people.Name = "jason";
                        people.Description = "he is a driver";

                        Type typePeople = typeof(People);
                        Type typePeopleDTO = typeof(PeopleDTO);
                        object peopleDTO = Activator.CreateInstance(typePeopleDTO);
                        //Copy properties
                        foreach (var prop in typePeopleDTO.GetProperties())
                        {
                            object value = typePeople.GetProperty(prop.Name).GetValue(people);
                            prop.SetValue(peopleDTO, value);
                        }

                        //Copy fields
                        foreach (var prop in typePeopleDTO.GetFields())
                        {
                            object value = typePeople.GetField(prop.Name).GetValue(people);
                            prop.SetValue(peopleDTO, value);
                        }


                    }



                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }


            Console.ReadLine();

            
        }
    }
}
