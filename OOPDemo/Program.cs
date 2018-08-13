using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Europa
{
    internal abstract class Staat
    {
        public abstract void SteuernZahlen();
        public virtual void Essengehen()
        {
            Console.WriteLine("Currywurst");
        }
    }

    interface IBundesland
    {
        void FesteFeiern();
    }
}

namespace OOPDemo
{
    class Deutschland : Europa.Staat, Europa.IBundesland
    {
        public override void SteuernZahlen()
        {
            Console.WriteLine("1 EUR");
        }

        public override void Essengehen()
        {
            Console.WriteLine("Schnitzel");
        }

        public void FesteFeiern()
        {
            Console.WriteLine("Fasching zum Beispiel");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var d = new Deutschland();
            d.FesteFeiern();
        }
    }
}


