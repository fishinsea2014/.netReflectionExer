using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    /// <summary>
    /// Usa a class or an interface to fit different classes or interfaces
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int aInt = 124;
            GenericMethod.Show<int>(aInt);
           

            {
                People p = new People()
                {
                    Id = 1,
                    Name = "Jason"
                };

                Kiwi kw = new Kiwi()
                {
                    Id = 2,
                    Name = "kiwi"
                };

                Chinese c = new Chinese(3)
                {
                    Id = 3,
                    Name = "Hao"
                };

                Japanese j = new Japanese()
                {
                    Id = 4,
                    Name = "Tokyo"
                };

                //Constraint.Show<People>(p);
                Constraint.Show<Chinese>(c);

            }


            Console.Read();
        }
    }

    internal class GenericMethod
    {
        public static void Show<T>(T tParameter)
        {
            Console.WriteLine($"This is {typeof(GenericMethod)}, parameter = {tParameter.GetType().Name}, type = {tParameter.ToString()}");
        }
    }
}
