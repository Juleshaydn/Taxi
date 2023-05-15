using System;
using System.Collections.Generic;

namespace SDAM_Taxi_Main
{
    public class TaxiManager
    {
        private SortedDictionary<int, Taxi> taxis { get; } = new SortedDictionary<int, Taxi>();

        public Taxi CreateTaxi(int taxiNum)
        {
            if (taxis.ContainsKey(taxiNum))
            {
                return taxis[taxiNum];
            }
            else
            {
                Taxi new_taxi = new Taxi(taxiNum);
                taxis.Add(taxiNum, new_taxi);
                return new_taxi;
            }
        }

        public Taxi FindTaxi(int taxiNum)
        {
            try
            {
                return this.taxis[taxiNum];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public SortedDictionary<int, Taxi> GetAllTaxis()
        {
            return this.taxis;
        }
    }
}
