//===============================================
//Student Number: S10257222
//Student Name: Huang Yi Hong
//Partner Name: Tan Xin Zheng Zen
//===============================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRG_Assignment;

namespace PRG_Assignment
{
    public class Waffle : IceCream
    {
        public string WaffleFlavour { get; set; }

        public Waffle() { }
        public Waffle(string o, int s, List<Flavour> f, List<Topping> t, string w)
        {
            Option = o;
            Scoops = s;
            Flavours = f;
            Toppings = t;
            WaffleFlavour = w;
        }
        public override double CalculatePrice()
        {
            double price = 0;

            if (Scoops == 1)
            {
                price = 7.00;
            }
            else if (Scoops == 2)
            {
                price = 8.50;
            }
            else if (Scoops == 3)
            {
                price = 9.50;
            }
            foreach (var f in Flavours)
            {
                if (f.Premium)
                {
                    price += 2.00;
                }
            }
            price += Toppings.Count;

            return price;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}