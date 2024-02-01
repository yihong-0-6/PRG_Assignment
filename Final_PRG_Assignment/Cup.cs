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
    public class Cup : IceCream
    {
        public Cup() { }

        public Cup(string o, int s, List<Flavour> f, List<Topping> t)
            : base(o, s, f, t) { }


        public override double CalculatePrice()
        {
            double price;

            switch (Scoops)
            {
                case 1:
                    price = 4.0;
                    break;
                case 2:
                    price = 5.5;
                    break;
                case 3:
                    price = 6.5;
                    break;
                default:
                    price = 0.0;
                    break;
            }

            double totalPrice = price;

            totalPrice += Toppings.Count;

            return totalPrice;
        }

        public override string ToString()
        {
            return base.ToString() +
                "\tPrice: " + CalculatePrice();
        }
    }
}