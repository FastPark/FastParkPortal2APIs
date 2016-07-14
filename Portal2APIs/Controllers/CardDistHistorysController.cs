using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.Http;
using Portal2APIs.Models;
using Portal2APIs.Common;


namespace Portal2APIs.Controllers
{
    public class CardDistHistorysController : ApiController
    {
        [HttpGet]
        [Route("api/CardDistHistorys/Get/{id}")]
        public CardDistHistory Get(int id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();
            CardDistHistory CDH = null;
            clsCommon nullCheck = new clsCommon();

            strSQL = "Select * from CardDistributionHistory where CardHistoryId=" + id + "";
            using (SqlConnection connection = new SqlConnection(thisADO.getMaxConnectionString()))
            {
                SqlCommand command = new SqlCommand(strSQL, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CDH = new CardDistHistory();
                    CDH.CardHistoryId = Convert.ToInt32(nullCheck.checknull(reader.GetValue(0), false));
                    CDH.ActivityDate = Convert.ToDateTime(nullCheck.checknull(reader.GetValue(1), false));
                    CDH.ActivityId = Convert.ToInt32(nullCheck.checknull(reader.GetValue(2), false));
                    CDH.StartingNumber = Convert.ToInt64(nullCheck.checknull(reader.GetValue(3), false));
                    CDH.EndingNumber = Convert.ToInt64(nullCheck.checknull(reader.GetValue(4), false));
                    CDH.NumberOfCards = Convert.ToInt64(nullCheck.checknull(reader.GetValue(5), false));
                    CDH.OrderConfirmationDate = Convert.ToDateTime(nullCheck.checknull(reader.GetValue(6), false));
                    CDH.DistributionPoint = Convert.ToString(nullCheck.checknull(reader.GetValue(7), false));
                    CDH.BusOrRepID = Convert.ToInt32(nullCheck.checknull(reader.GetValue(8), false));
                    CDH.Shift = Convert.ToString(nullCheck.checknull(reader.GetValue(9), false));
                    CDH.RecordDate = Convert.ToDateTime(nullCheck.checknull(reader.GetValue(10), false));
                    CDH.RecordedBy = Convert.ToString(nullCheck.checknull(reader.GetValue(11), false));
                    CDH.BusOrRepID = Convert.ToInt32(nullCheck.checknull(reader.GetValue(12), false));
                }
                reader.Close();

                return CDH;
            }
        }

        [HttpGet]
        [Route("api/CardDistHistorys/GetCardRange")]
        public List<CardDistHistory> GetCardRange([FromUri]int startingNumber, [FromUri]int endingNumber)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();
            CardDistHistory CDH = null;
            List<CardDistHistory> allHistory = new List<CardDistHistory>();
            clsCommon nullCheck = new clsCommon();

            strSQL = "Select * from CardDistributionHistory where StartingNumber >= " + startingNumber + " and EndingNumber <= " + endingNumber;
            using (SqlConnection connection = new SqlConnection(thisADO.getMaxConnectionString()))
            {
                SqlCommand command = new SqlCommand(strSQL, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CDH = new CardDistHistory();
                    CDH.CardHistoryId = Convert.ToInt32(nullCheck.checknull(reader.GetValue(0), false));
                    CDH.ActivityDate = Convert.ToDateTime(nullCheck.checknull(reader.GetValue(1), false));
                    CDH.ActivityId = Convert.ToInt32(nullCheck.checknull(reader.GetValue(2), false));
                    CDH.StartingNumber = Convert.ToInt64(nullCheck.checknull(reader.GetValue(3), false));
                    CDH.EndingNumber = Convert.ToInt64(nullCheck.checknull(reader.GetValue(4), false));
                    CDH.NumberOfCards = Convert.ToInt64(nullCheck.checknull(reader.GetValue(5), false));
                    CDH.OrderConfirmationDate = Convert.ToDateTime(nullCheck.checknull(reader.GetValue(6), false));
                    CDH.DistributionPoint = Convert.ToString(nullCheck.checknull(reader.GetValue(7), false));
                    CDH.BusOrRepID = Convert.ToInt32(nullCheck.checknull(reader.GetValue(8), false));
                    CDH.Shift = Convert.ToString(nullCheck.checknull(reader.GetValue(9), false));
                    CDH.RecordDate = Convert.ToDateTime(nullCheck.checknull(reader.GetValue(10), false));
                    CDH.RecordedBy = Convert.ToString(nullCheck.checknull(reader.GetValue(11), false));
                    CDH.BusOrRepID = Convert.ToInt32(nullCheck.checknull(reader.GetValue(12), false));

                    allHistory.Add(CDH);
                }
                reader.Close();
            }

            return allHistory;

        }

        [HttpPost]
        [Route("api/CardDistHistorys/Post")]
        public CardDistHistory Post(CardDistHistory CDH)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            strSQL = "insert into CardDistributionHistory (ActivityDate, ActivityId, StartingNumber, EndingNumber, NumberOfCards, " +
                                                        "OrderConfirmationDate, DistributionPoint, BusOrRepID, Shift, RecordDate, RecordedBy) " +
                                                        "values ('" + CDH.ActivityDate + "', " + CDH.ActivityId + ", " + CDH.StartingNumber + ", " +
                                                        CDH.EndingNumber + ", " + CDH.NumberOfCards + ", '" + CDH.OrderConfirmationDate + "', '" +
                                                        CDH.DistributionPoint + "', " + CDH.BusOrRepID + ", '" + CDH.Shift + "', '" + CDH.RecordDate + "', '" + CDH.RecordedBy + "')";

            thisADO.updateOrInsert(strSQL, true);

            return null;
        }
    }
}
