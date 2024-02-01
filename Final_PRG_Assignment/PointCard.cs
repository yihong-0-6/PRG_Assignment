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
    class PointCard : Order
    {
        //PointCard attributes
        private int points;
        private int punchCard;
        private string tier;

        public int Points
        {
            get { return points; }
            set { points = value; }
        }
        public int PunchCard
        {
            get { return punchCard; }
            set { punchCard = value; }
        }
        public string Tier
        {
            get { return tier; }
            set { tier = value; }
        }
        public PointCard()
        {

        } //points and punchcard initialized to 0

        //PointCard constructor
        public PointCard(int points, int punchCard)
        {
            Points = points;
            PunchCard = punchCard;
        }
        //adding points for every purchase, amountspent stores user order amount in dollars
        public int AddPoints(int amountspent)
        {
            int point = Convert.ToInt32(Math.Floor(amountspent * 0.72));
            return point;
        }
        //redeeming points, 1 point = $0.02, based on how many points customer want to redeem. Eg, 100, then 100 points = $2
        //redeemed points will minus off the points in the pointcard
        public int RedeemPoints(int Redeem)
        {
            //Redeem stores userinput of the amount they want to redeem, then the calculation of converting points into money is stored into a variable
            int redemptionAmount = Convert.ToInt32(Redeem * 0.02);
            if (Points >= redemptionAmount)
            {
                if (Tier == "Gold" || Tier == "Silver")
                {
                    Points -= redemptionAmount;
                    Console.WriteLine($"Redemption successful. Redeemed amount: ${Redeem / 50.0:F2}");
                }
                else
                {
                    Console.WriteLine("Only Silver members and above can redeem points");
                }
            }
            else
            {
                Console.WriteLine("You do not have points to redeem");
            }
            return Redeem;
        }
        //For every 10 orders, the 11th order will be free and will reset back to 0
        public void Punch()
        {
            PunchCard++;
            if (PunchCard % 10 == 0)
            {
                Console.WriteLine($"Congratulations! You've earned a free order with ID {Id}!");
                PunchCard = 0; //resets punchcard
            }
        }
        public override string ToString()
        {
            return $"This your current Tier: {tier}\nAccumulated points: {points}\n orders left to free order: {10 - punchCard}";
        }
    }
}