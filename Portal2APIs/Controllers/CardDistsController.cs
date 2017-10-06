using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Portal2APIs.Common;
using Portal2APIs.Models;

namespace Portal2APIs.Controllers
{
    public class CardDistsController : ApiController
    {
        [HttpGet]
        [Route("api/CardDists/GetCardDist/{id}")]
        public List<CardDist> GetCardDist(string id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "select cd.*, Cast((CardDistEndNumber - CardDistStartNumber + 1) as int) as NumberOfCards, mr.FirstName + ' ' + mr.LastName as CardDistRepName " +
                        "from CardDistribution.dbo.CardDist cd " +
                        "left outer join MarketingReps mr on cd.CardDistRepLineId = mr.ID " +
                        "Where cd.CardDistLocationID = " + id + " " +
                        "order by CardDistDate desc";
                List<CardDist> list = new List<CardDist>();
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
        [Route("api/CardDists/Distribute")]
        public string Distribute(CardDist CD)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;
            Int64 startingNumber = CD.CardDistStartNumber;
            Int64 endingNumber = CD.CardDistEndNumber;

            DateTime now = DateTime.Now;

            try
            {
                strSQL = "insert into CardDistribution.dbo.CardDist (CardDistLocationID, CardDistRepLineID, CardDistBooth, CardDistBusName, CardDistStartNumber, CardDistEndNumber, CardDistBy, CardDistDate) " +
                                                        "values (" + CD.CardDistLocationID + ", " + CD.CardDistRepLineID + ", " + CD.CardDistBooth + ", '" + CD.CardDistBusName + "', " + CD.CardDistStartNumber + ", " + CD.CardDistEndNumber + ", '" + CD.CardDistBy + "', '" + CD.CardDistDate + "')";

                thisADO.updateOrInsert(strSQL, false);

                if (CD.CardDistBooth != 1)
                {
                    for (long i = CD.CardDistStartNumber; i <= CD.CardDistEndNumber; i++)
                    {
                        strSQL = "Update CardDistribution.dbo.CardInventory set RepLineId = " + CD.CardDistRepLineID + " where CardFPNumber = " + i;

                        thisADO.updateOrInsert(strSQL, false);
                    }
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

        [HttpPost]
        [Route("api/CardDists/UpdateDistribute")]
        public string UpdateDistribute(CardDist CD)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;
            Int64 startingNumber = CD.CardDistStartNumber;
            Int64 endingNumber = CD.CardDistEndNumber;

            DateTime now = DateTime.Now;

            try
            {
                strSQL = "Update CardDistribution.dbo.CardDist set CardDistBooth = " + CD.CardDistBooth + ", CardDistBusName = '" + CD.CardDistBusName + "', CardDistStartNumber = " + CD.CardDistStartNumber + ", CardDistEndNumber = " + CD.CardDistEndNumber + ", CardDistBy = '" + CD.CardDistBy + "', CardDistDate = '" + CD.CardDistDate + "', CardDistRepLineID = " + CD.CardDistRepLineID + " Where CardDistID = " + CD.CardDistID;
                 
                thisADO.updateOrInsert(strSQL, false);

                if (CD.CardDistBooth != 1)
                {
                    for (long i = CD.CardDistStartNumber; i <= CD.CardDistEndNumber; i++)
                    {
                        strSQL = "Update CardDistribution.dbo.CardInventory set RepLineId = " + CD.CardDistRepLineID + " where CardFPNumber = " + i;

                        thisADO.updateOrInsert(strSQL, false);
                    }
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

        [HttpPost]
        [Route("api/CardDists/ConfirmNumbers")]
        public List<CardDist> ConfirmNumbers(CardDist CD)
        {
           string strSQL = "";
            clsADO thisADO = new clsADO();

            if (CD.CardDistStartNumber != 0)
            {
                strSQL = "select 1 as CardDistStartNumber from CardDistribution.dbo.CardShip " +
                 "where " + CD.CardDistStartNumber + " between CardShipStartNumber and CardShipEndNumber and CardShipReceiveDate is not null and IsActive = 1 and CardShipTo = " + CD.CardDistLocationID;
            }
            else
            {
                strSQL = "select 1 as CardDistEndNumber from CardDistribution.dbo.CardShip " +
                "where " + CD.CardDistEndNumber + " between CardShipStartNumber and CardShipEndNumber and CardShipReceiveDate is not null and IsActive = 1 and CardShipTo = " + CD.CardDistLocationID;
            }

            try
            {
                List<CardDist> list = new List<CardDist>();
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
