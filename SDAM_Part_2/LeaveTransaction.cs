using System;
namespace SDAM_Taxi_Main
{
    public class LeaveTransaction
    {
        private int taxiNum;
        private int rankId;
        private string destination;
        private double agreedPrice;
        private DateTime transactionDateTime;
        private DateTime now;
        private int v;
        private Taxi t;

        public LeaveTransaction(DateTime transactionDateTime, int taxiNum, int rankId)
        {
            this.transactionDateTime = transactionDateTime;
            this.taxiNum = taxiNum;
            this.rankId = rankId;
        }

        public LeaveTransaction(DateTime now, int v, Taxi t)
        {
            this.now = now;
            this.v = v;
            this.t = t;
        }

        public string ToString()
        {
            return taxiNum + rankId + destination + agreedPrice;
        }
    }
}