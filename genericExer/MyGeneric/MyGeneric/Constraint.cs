using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    class Constraint
    {

        public static void Show<T> (T tParameter) 
            where T : People //Could be a class
                      , ISports, IWork // Could be an interface
                      //, new() //this mean that T must has a construction method without arguments
        {
            Console.WriteLine($"{tParameter.Id} - {tParameter.Name}");
            tParameter.Hello();
            tParameter.Rugby();
            //tParameter.Majiang(); //Not work for Majiang is not a method of People
            tParameter.Work();
        }


        public static void ShowBase(People tParameter)//Constraint can be overlap,
        {
            Console.WriteLine($"{tParameter.Id}_{tParameter.Name}");
            tParameter.Hello();
        }

        public delegate void SayHello<T>(T t); //Generic delegation
    }
}
