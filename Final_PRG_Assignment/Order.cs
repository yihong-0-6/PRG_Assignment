//===============================================
//Student Number: S10241567
//Student Name: Tan Xin Zheng Zen
//Partner Name: Huang Yi Hong
//===============================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using PRG_Assignment;

namespace PRG_Assignment
{
    class Order
    {
        protected int id;
        protected DateTime timeReceived;
        protected DateTime? timeFulfilled; //Datetime accepts null value
        protected List<IceCream> iceCreamList; //will be used after icecream class is created
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime TimeReceived
        {
            get { return timeReceived; }
            set { timeReceived = value; }
        }
        public DateTime? TimeFulfilled
        {
            get { return timeFulfilled; }
            set { timeFulfilled = value; }
        }
        public List<IceCream> IceCreamList
        {
            get { return iceCreamList; }
            set { iceCreamList = value; }
        }
        public Order()
        {
            iceCreamList = new List<IceCream>();
        }
        public Order(int id, DateTime timeReceived)
        {
            Id = id++;
            TimeReceived = timeReceived;
            TimeFulfilled = null;
        }
        public void ModifyIceCream(int modified) //option, scoops, flavours, toppings, dipped cone (if applicable), waffle flavour when asking users to modify
        {

        }
        public void AddIceCream(IceCream iceCream)//when customer orders
        {
            IceCreamList.Add(iceCream);
        }
        public void DeleteIceCream(int deleted)//if customer wants to remove their order
        {

        }
        public double CalculateTotal(double amount)
        {
            double total = amount;
            return total;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}