using System.Collections.Generic;

namespace SDAM_Taxi_Main
{
    public class RankManager
    {
        private Dictionary<int, Rank> _rank;

        public RankManager()
        {
            _rank = new Dictionary<int, Rank>
            {
                { 1, new Rank(1, 5) },
                { 2, new Rank(2, 2) },
                { 3, new Rank(3, 4) }
            };
        }

        public bool AddTaxiToRank(Taxi t, int rankId)
        {
            bool taxiAdded = false;
            if (t.Location == Taxi.ON_ROAD && t.Destination == "")
            {
                Rank r = FindRank(rankId);
                if (r != null)
                {
                    taxiAdded = r.AddTaxi(t);
                }
            }
            return taxiAdded;
        }

        public Rank FindRank(int rankId)
        {
            _rank.TryGetValue(rankId, out var rank);
            return rank;
        }

        public Taxi FrontTaxiInRankTakesFare(int rankId, string destination, double agreedPrice)
        {
            Rank r = FindRank(rankId);
            if (r != null)
            {
                return r.FrontTaxiTakesFare(destination, agreedPrice);
            }
            return null;
        }
    }
}
