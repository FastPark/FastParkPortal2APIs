﻿using System;
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
        public List<CardDist> GetShipments(string id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "select cd.*, mr.LastName + ' ' + mr.LastName as CardDistRepName " +
                        "from CardDistribution.dbo.CardDist cd " +
                        "left outer join MarketingReps mr on cd.CardDistRepLineId = mr.ID ";
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
                                                        "values (" + CD.CardDistLocationID + ", " + CD.CardDistRepLineID + ", " + CD.CardDistBooth + ", '" + CD.CardDistBusName + "', " + CD.CardDistStartNumber + ", " + CD.CardDistEndNumber + ", '" + CD.CardDistBy + "', '" + now + "')";

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
        [Route("api/CardDists/ConfirmNumbers")]
        public List<CardDist> ConfirmNumbers(CardDist CD)
        {
           string strSQL = "";
            clsADO thisADO = new clsADO();

            if (CD.CardDistStartNumber != 0)
            {
                strSQL = "select 1 as CardDistStartNumber from CardDistribution.dbo.CardShip " +
                 "where " + CD.CardDistStartNumber + " between CardShipStartNumber and CardShipEndNumber and CardShipReceiveDate is not null and CardShipTo = " + CD.CardDistLocationID;
            }
            else
            {
                strSQL = "select 1 as CardDistEndNumber from CardDistribution.dbo.CardShip " +
                "where " + CD.CardDistEndNumber + " between CardShipStartNumber and CardShipEndNumber and CardShipReceiveDate is not null and CardShipTo = " + CD.CardDistLocationID;
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
