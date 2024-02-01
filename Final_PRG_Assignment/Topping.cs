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
    public class Topping
    {
        public string Type { get; set; }

        public Topping() { }
        public Topping(string type)
        {
            Type = type;
        }
        public override string ToString()
        {
            return "Type:" + Type;
        }
    }
}
