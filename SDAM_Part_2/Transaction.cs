using System;

namespace SDAM_Taxi_Main
{
    public class Transaction
    {
        public DateTime TransactionDatetime { get; }
        public string TransactionType { get; }

        public Transaction(string type, DateTime dt)
        {
            TransactionType = type;
            TransactionDatetime = dt;
        }

        public override string ToString()
        {
            return TransactionDatetime.ToString() + TransactionType;
        }

        public static implicit operator Transaction(JoinTransaction v)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Transaction(LeaveTransaction v)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Transaction(DropTransaction v)
        {
            throw new NotImplementedException();
        }
    }
}
