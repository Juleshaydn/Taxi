using System;
namespace SDAM_Taxi_Main
{
    public class JoinTransaction
    {
        public DateTime TransactionDatetime { get; }
        private int taxiNum;
        private int rankId;

        public JoinTransaction(DateTime transactionDatetime, int taxiNum, int rankId)
        {
            if (transactionDatetime != DateTime.Now)
            {
                throw new ArgumentException("Transaction date and time must be equal to current date and time");
            }

            TransactionDatetime = transactionDatetime;
            this.taxiNum = taxiNum;
            this.rankId = rankId;
        }

        public override string ToString()
        {
            return taxiNum.ToString() + rankId.ToString();
        }
    }
}