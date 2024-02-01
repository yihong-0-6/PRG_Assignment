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
    class Cone : IceCream
    {
        public bool Dipped { get; set; }

        public Cone() { }

        public Cone(string o, int s, List<Flavour> f, List<Topping> t, bool dipped)
            : base(o, s, f, t)
        {
            Dipped = dipped;
        }
        public override double CalculatePrice()
        {
            double basePrice;
            double premiumFlavour = 2.0;
            double dip = 2.0;

            switch (Scoops)
            {
                case 1:
                    basePrice = 4.0;
                    break;
                case 2:
                    basePrice = 5.5;
                    break;
                case 3:
                    basePrice = 6.5;
                    break;
                default:
                    basePrice = 0.0;
                    break;
            }

            if (Dipped == true)
            {
                basePrice += dip;
            }

            double totalPrice = basePrice + (premiumFlavour * Flavours.Count);

            totalPrice += Toppings.Count;

            return totalPrice;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}