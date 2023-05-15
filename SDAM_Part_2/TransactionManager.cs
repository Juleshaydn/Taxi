using System;
using System.Data.Common;
using System.Transactions;

namespace SDAM_Taxi_Main
{
    public class TransactionManager
    {
        public List<Transaction> Transactions { get; }

        public void RecordDrop(int taxiNnum, bool pricePaid)
        {

        }

        public void RecordJoin(int taxiNum, int rankId)
        {

        }

        public void RecordLeave(int rankId, Taxi t)
        {

        }
    }
}