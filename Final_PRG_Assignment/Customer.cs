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
using PRG_Assignment;


namespace PRG_Assignment
{
    class Customer
    {
        //Customer attributes
        private string name;
        private int memberid;
        private DateTime dob;
        public Order currentOrder; //links to Order class, name is currentOrder
        public PointCard rewards; //links to pointcard class, name is rewards
        public List<Order> orderHistory; //maintains list of Orders made by a customer using Order class, name is orderHistory

        //list to manage orders based on member status
        public List<Order> goldOrders;
        public List<Order> Silver_and_Ordinary_Orders;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Memberid
        {
            get { return memberid; }
            set { memberid = value; }
        }
        public DateTime Dob
        {
            get { return dob; }
            set { dob = value; }
        }
        public Customer() { }
        //Customer Constructor, basic info of customer
        public Customer(string name, int memberid, DateTime dob)
        {
            Memberid = memberid;
            Name = name;
            Dob = dob;
            rewards = new PointCard();
            orderHistory = new List<Order>();
            // The following lines are executed only when a new Customer object is created,
            // not every time the constructor is called.
            goldOrders = new List<Order>();
            Silver_and_Ordinary_Orders = new List<Order>();
        }
        //Creates a new order
        public Order MakeOrder()
        {
            //order queue based on member status, gold will be first, silver and ordinary no priviledge
            Order newOrder = new Order();
            if (rewards.Tier == "Gold")
            {
                //invoking from pointcard class under the name rewards and getting the tier.
                goldOrders.Add(newOrder);
            }
            else
            {
                Silver_and_Ordinary_Orders.Add(newOrder);
            }

            //updates currentOrder and calls Punch() method
            currentOrder = new Order(); //currentOrder has the Order class attributes
            orderHistory.Add(currentOrder); //adds to the list of orders made by a customer
            rewards.Punch();
            return currentOrder;
        }
        //this method checks if it is customers birthday, if true, the price will be free
        public bool IsBirthday()
        {
            if (DateTime.Today == dob.Date)//removes time component to make it more accurate
            {
                if (currentOrder != null)
                {
                    currentOrder.CalculateTotal(0);//make sure to change this, cannot just put a 0 here, do it in the calculations or make a new one
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}