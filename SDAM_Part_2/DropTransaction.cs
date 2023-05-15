using System;
namespace SDAM_Taxi_Main
{
    public class DropTransaction
    {
        private int taxiNum;
        private bool priceWasPaid;

        public DropTransaction(DateTime transactionDateTime, int TaxiNum, bool priceWasPaid)
        {

        }

        public string ToString()
        {
            return taxiNum.ToString() + priceWasPaid.ToString();
        }
    }
}