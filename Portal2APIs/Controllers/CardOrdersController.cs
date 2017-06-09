using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Portal2APIs.Models;
using Portal2APIs.Common;

namespace Portal2APIs.Controllers
{
    public class CardOrdersController : ApiController
    {
        [HttpGet]
        [Route("api/CardOrders/GetOrders")]
        public List<CardOrder> GetOrders()
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select co.*, cos.CardOrderStatus, cd.CardDesignDesc " +
                         "from CardDistribution.dbo.CardOrder co " +
                         "Inner Join CardDistribution.dbo.CardOrderStatus cos on co.CardOrderStatusID = cos.CardOrderStatusID " +
                         "Inner Join CardDistribution.dbo.CardDesign cd on co.CardDesignId = cd.CardDesignId " +
                         "Order by CardOrderEndNumber desc";
                List<CardOrder> list = new List<CardOrder>();
                thisADO.returnSingleValue(strSQL, false, ref list);

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
        [Route("api/CardOrders/Post")]
        public string Post(CardOrder CDH)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;
            Int64 startingNumber = CDH.CardOrderStartNumber;
            Int64 endingNumber = CDH.CardOrderEndNumber;
            Int64 rndNumber = 0;
            int BatchNumber;
            clsCommon myRnd = new clsCommon();
            DateTime now = DateTime.Now;

            try
            {
                strSQL = "insert into CardDistribution.dbo.CardOrder (CardOrderDate, CardOrderStartNumber, CardOrderEndNumber, CardOrderBy, CardOrderStatusID, CardDesignId) " +
                                                        "values ('" + now + "', " + startingNumber + ", " + endingNumber + ", '" + CDH.CardOrderBy + "', " + CDH.CardOrderStatus + ", " + CDH.CardDesignId + ")";

                thisADO.updateOrInsert(strSQL, false);

                strSQL = "select max(CardHistoryID) from CardDistribution.dbo.CardInventory";

                BatchNumber = Convert.ToInt16(thisADO.returnSingleValueForInternalAPIUse(strSQL, false)) + 1;

                for (Int64 i = startingNumber; i <= endingNumber; i++)
                {
                    rndNumber = myRnd.RandNumber(1000, 9999);
                    strSQL = "insert into CardDistribution.dbo.CardInventory (CardFPNumber, CardHistoryID, CardValidationNumber, CardActive) " +
                                "Values (" + i + ", " + BatchNumber + ", " + rndNumber + ", 1)";
                    thisADO.updateOrInsert(strSQL, false);
                }

                return "Success";
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
        [Route("api/CardOrders/GetLastCardOrdered/")]
        public List<CardOrder> GetLastCardOrdered()
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "select MAX(CardFPNumber) as orderedMax from CardDistribution.dbo.CardInventory where CardActive = 'True'";
                List<CardOrder> list = new List<CardOrder>();
                thisADO.returnSingleValue(strSQL, false, ref list);

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
        [Route("api/CardOrders/ConfirmNumbers/{id}")]
        public List<CardOrder> ConfirmNumbers(string Id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "select * from CardDistribution.dbo.CardOrder " +
                        "where " + Id + " between CardOrderStartNumber and CardOrderEndNumber ";

                List<CardOrder> list = new List<CardOrder>();
                thisADO.returnSingleValue(strSQL, false, ref list);


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
        [Route("api/CardOrders/Update")]
        public string Update(CardOrder CDH)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            DateTime now = DateTime.Now;

            try
            {
                strSQL = "Update CardDistribution.dbo.CardOrder set CardOrderReceivedBy =  '" + CDH.CardOrderReceivedBy + "',  CardOrderReceivedDate = '" + now + "', CardOrderStatusID = 3 where CardOrderID = " + CDH.CardOrderId;

                thisADO.updateOrInsert(strSQL, false);
                
                return "Success";
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
        [Route("api/CardOrders/GetOrderByRange/")]
        public List<CardOrder> GetOrderByRange(CardOrder CDH)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "select Right('00000' + SUBSTRING(Cast(CardFPNumber as nvarchar(100)),0,3), 3) as PreFix, SUBSTRING(Cast(CardFPNumber as nvarchar(100)),2,6) as Suffix, Cast(CardValidationNumber as nvarchar(100)) as RegistrationCode  " +
                         "from CardDistribution.dbo.CardInventory where CardFPNumber between " + CDH.CardOrderStartNumber + " and " + CDH.CardOrderEndNumber + " order by CardFPNumber";
                List<CardOrder> list = new List<CardOrder>();
                thisADO.returnSingleValue(strSQL, false, ref list);

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
    }
}
