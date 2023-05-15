using System;
using System.Xml.Linq;

namespace SDAM_Taxi_Main
{
    public class Taxi
    {
        public const string IN_RANK = "in rank";
        public const string ON_ROAD = "on the road";
        public double CurrentFare { get; private set; }
        public string Destination { get; private set; } = "";
        public string Location { get; private set; } = ON_ROAD;
        public int Number { get; }
        public double TotalMoneyPaid { get; private set; }
        private Rank rank;

        public Rank Rank
        {
            get
            {
                return rank;
            }
            set
            {
                if (Destination != "" && value != null)
                {
                    throw new Exception("Fare not paid");
                }

                if (value == null)
                {
                    throw new Exception("Rank cannot be null");
                }

                rank = value;
                Location = IN_RANK;
            }
        }

        public Taxi(int taxiNum)
        {
            Number = taxiNum;
        }

        public void AddFare(string destination, double agreedPrice)
        {
            Location = ON_ROAD;
            Destination = destination;
            CurrentFare = agreedPrice;
        }

        public void DropFare(bool priceWasPaid)
        {
            if (priceWasPaid)
            {
                TotalMoneyPaid += CurrentFare;
            }
            CurrentFare = 0;
            Destination = "";
        }
    }

}

