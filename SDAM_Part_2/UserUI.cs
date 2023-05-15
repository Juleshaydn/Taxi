using System;
using System.Transactions;

namespace SDAM_Taxi_Main

{
	public class UserUI
	{
        private RankManager rankMgr;
        private TaxiManager taxiMgr;
        private TransactionManager transactionMgr;

        public UserUI(RankManager rkMgr, TaxiManager txMgr, TransactionManager trMgr)
		{

		}

        //Function to drop taxi fare
        public List<string> TaxiDropsFare(int taxiNum, bool pricePaid)
        {
            var TaxiDropsFareText = new List<string>();

            //creates new instance of taxi management to use FindTaxi method
            var taxi_management = new TaxiManager();
            var find_taxi = taxi_management.FindTaxi(taxiNum);

            if (find_taxi.Location == "on road")
            {
                var amountPaid = find_taxi.CurrentFare;
                if (amountPaid > 0)
                {
                    var transactionDateTime = DateTime.Now;
                    bool priceWasPaid = false;
                    //creates drop transation if fare was fully paid
                    DropTransaction dropTransaction = new DropTransaction(transactionDateTime, taxiNum, priceWasPaid);

                    TaxiDropsFareText.Add($"{dropTransaction}");
                }
            }

            return TaxiDropsFareText;
        }

        //Function to join a taxi to a rank
        public List<string> TaxiJoinsRank(int taxiNum, int rankId)
        {
            var TaxiJoinsRankText = new List<string>();

            //creates new instance of taxi management to use FindTaxi method
            var taxi_management = new TaxiManager();
            var find_taxi = taxi_management.FindTaxi(taxiNum);

            //if the taxi does not exists
            if (find_taxi == null)
            {
                //create new taxi and adds to a rank
                TaxiManager taxiManager = new TaxiManager();
                var new_taxi = taxiManager.CreateTaxi(10);

                var rank = new Rank(1, 10);

                RankManager rankManager = new RankManager();
                rankManager.AddTaxiToRank(new_taxi, rank.Id);

                JoinTransaction join_transaction = new JoinTransaction(DateTime.Now, taxiNum, rank.Id);

                TaxiJoinsRankText.Add($"{join_transaction}");
            }
            else
            {
                //AttributeTargets location and destination for taxi
                var location = find_taxi.Location;
                var destination = find_taxi.Destination;

                //checks if taxi is on the road
                if (find_taxi.Destination == null && find_taxi.Location == "on road")
                {
                    RankManager rankManager = new RankManager();

                    rankManager.FindRank(rankId);
                    JoinTransaction join_transaction = new JoinTransaction(DateTime.Now, taxiNum, rankId);

                    TaxiJoinsRankText.Add($"{join_transaction}");
                }
            }

            return TaxiJoinsRankText;
        }


        //Function ran to make a taxi leaves a rank
        public List<string> TaxiLeavesRank(int rankId, string destination, double agreedPrice)
        {
            RankManager rankManager = new RankManager();

            var rank = rankManager.FindRank(rankId);
            var spaces = rank.numberOfTaxiSpaces;
            var leaveTransactionLogText = new List<string>();

            if (rank.numberOfTaxiSpaces > 0)
            {
                Taxi taxi = new Taxi(1);
                taxi.AddFare(destination, agreedPrice);

                var datetime = DateTime.Now;
                LeaveTransaction leaveTransaction = new LeaveTransaction(datetime, rankId, taxi.Number);

                leaveTransactionLogText.Add($"Transaction details: {leaveTransaction.ToString()}");
            }
            else
            {
                leaveTransactionLogText.Add("No Transaction Details");
            }

            return leaveTransactionLogText;
        }

        public List<string> ViewFinancialReport()
        {
            List<string> financialReport = new List<string>();
            return financialReport;
        }

        //Returns the location of all the taxis
        public List<string> ViewTaxiLocations()
        {
            var leaveTransactionLogText = new List<string>();

            TaxiManager taxiManager = new TaxiManager();
            var message = taxiManager.GetAllTaxis();

            leaveTransactionLogText.Add($"{message}");

            return leaveTransactionLogText;
        }

        //Returns a full transaction log
        public List<string> ViewTransactionLog()
        {
            var ViewTransactionLogText = new List<string>();

            TransactionManager transactionManager = new TransactionManager();

            var transactions = transactionManager.Transactions;

            foreach (var transaction in transactions)
            {
                ViewTransactionLogText.Add($"transaction");
            }

            return ViewTransactionLogText;
        }
    }
}