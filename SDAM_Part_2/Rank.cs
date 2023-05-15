using System;
using System.Collections.Generic;

namespace SDAM_Taxi_Main
{
    public class Rank
    {
        public int Id { get; }
        public int numberOfTaxiSpaces;
        private List<Taxi> taxis;
        private int rankId;

        public Rank(int rankId, int numberOfTaxiSpaces)
        {
            this.rankId = rankId;
            this.Id = rankId;
            this.numberOfTaxiSpaces = numberOfTaxiSpaces;

            taxis = new List<Taxi>(numberOfTaxiSpaces);
        }

        public bool AddTaxi(Taxi t)
        {
            if (taxis.Count >= numberOfTaxiSpaces)
            {
                return false;
            }
            t.Rank = this;
            taxis.Add(t);
            return true;
        }


        public Taxi FrontTaxiTakesFare(string destination, double agreedPrice)
        {
            if (taxis.Count == 0)
            {
                return null;
            }

            var temp_taxi = taxis[0];
            temp_taxi.AddFare(destination, agreedPrice);
            taxis.RemoveAt(0);

            return temp_taxi;
        }

    }
}
