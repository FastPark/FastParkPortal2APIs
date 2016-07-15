using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.Http;
using Portal2APIs.Models;
using Portal2APIs.Common;
using System.Net;
using System.Net.Http;

namespace Portal2APIs.Controllers
{
    public class CardDistHistorysController : ApiController
    {
        [HttpGet]
        [Route("api/CardDistHistorys/Get/{id}")]
        public List<CardDistHistory> Get(int id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select * from CardDistributionHistory where CardHistoryId=" + id + "";
                List<CardDistHistory> list = new List<CardDistHistory>();
                thisADO.returnList(strSQL, true, ref list);

                return list;
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message, System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.BadRequest
                };
                throw new HttpResponseException(response);
            }  
        }

        [HttpGet]
        [Route("api/CardDistHistorys/GetCardRange")]
        public List<CardDistHistory> GetCardRange([FromUri]int startingNumber, [FromUri]int endingNumber)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "Select * from CardDistributionHistory where StartingNumber >= " + startingNumber + " and EndingNumber <= " + endingNumber;

                List<CardDistHistory> list = new List<CardDistHistory>();
                thisADO.returnList(strSQL, true, ref list);

                return list;
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message, System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.BadRequest
                };
                throw new HttpResponseException(response);
            }
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
