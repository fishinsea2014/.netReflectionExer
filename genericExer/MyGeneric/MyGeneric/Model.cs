using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    public interface ISports
    {
        void Rugby();
    }

    public interface IWork
    {
        void Work();
    }

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Hello()
        {
            Console.WriteLine("Hello");
        }
    }

    public class Kiwi: People, ISports, IWork
    {
        public void Tradition()
        {
            Console.WriteLine("We are partner");
        }

        public void SayHello()
        {
            Console.WriteLine("Kae ora");
        }

        public void Rugby()
        {
            Console.WriteLine("Play rugby");
        }

        public void Work()
        {
            throw new NotImplementedException();
        }
    }

    public class Chinese : Kiwi
    {
        public Chinese (int generation)
        {

        }

        public string Mandarine { get; set; }

        public void Majiang()
        {
            Console.WriteLine("Let play Majiang");
        }
    }

    public class Japanese : ISports
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void Hello()
        {
            Console.WriteLine("Wadaxiwa");
        }

        public void Rugby()
        {
            Console.WriteLine("Play Rugby.");
        }
    }


}
