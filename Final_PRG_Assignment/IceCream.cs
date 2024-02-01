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
    public abstract class IceCream
    {
        public string Option { get; set; }
        public int Scoops { get; set; }
        public List<Flavour> Flavours { get; set; } = new List<Flavour>();
        public List<Topping> Toppings { get; set; } = new List<Topping>();

        public IceCream() { }

        public IceCream(string o, int s, List<Flavour> f, List<Topping> t)
        {
            Option = o;
            Scoops = s;
            Flavours = f;
            Toppings = t;
        }
        public abstract double CalculatePrice();

        public override string ToString()
        {
            return "Option: " + Option + "Scoops: " + Scoops + "Flavours: " + Flavours + "Toppings: " + Toppings;
        }
    }
}