﻿using System;
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
                strSQL = "Select cdh.*, l.NameOfLocation from CardDistributionHistory cdh " + 
                          "inner Join Location l on cdh.LocationId = l.LocationID " +
                          "where cdh.CardHistoryId=" + id + "";
                List<CardDistHistory> list = new List<CardDistHistory>();
                thisADO.returnList(strSQL, false, ref list);

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

                strSQL = "Select cdh.*, l.NameOfLocation, cdat.CardDistributionActivityDescription " +
                          "from CardDistributionHistory cdh " +
                          "left Outer Join Location l on cdh.LocationId = l.LocationID " +
                          "inner Join CardDistributionActivityType cdat on cdh.ActivityId = cdat.CardDistributionActivityTypeID " +
                          "where StartingNumber >= " + startingNumber + " and EndingNumber <= " + endingNumber;

                List<CardDistHistory> list = new List<CardDistHistory>();
                thisADO.returnList(strSQL, false, ref list);

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
            Int64 startingNumber = CDH.StartingNumber;
            Int64 endingNumber = CDH.EndingNumber;
            Int64 rndNumber= 0;
            int BatchNumber;
            clsCommon myRnd = new clsCommon();

            try
            {
                strSQL = "insert into CardDistributionHistory (ActivityDate, ActivityId, StartingNumber, EndingNumber, NumberOfCards, " +
                                                        "OrderConfirmationDate, DistributionPoint, BusOrRepID, Shift, RecordDate, RecordedBy, LocationId) " +
                                                        "values ('" + CDH.ActivityDate + "', " + CDH.ActivityId + ", " + CDH.StartingNumber + ", " +
                                                        CDH.EndingNumber + ", " + CDH.NumberOfCards + ", '" + CDH.OrderConfirmationDate + "', '" +
                                                        CDH.DistributionPoint + "', " + CDH.BusOrRepId + ", '" + CDH.Shift + "', '" + CDH.RecordDate + "', '" + CDH.RecordedBy + "', " + CDH.LocationId + ")";

                BatchNumber = thisADO.updateOrInsertWithId(strSQL, false);

                if (CDH.ActivityId == 1)
                {
                    for(Int64 i = startingNumber; i <= endingNumber; i++)
                    {
                        rndNumber = myRnd.RandNumber(1000, 9999);
                        strSQL = "insert into CardDistributionInventory (CardFPNumber, CardHistoryID, CardValidationNumber, CardActive) " +
                                 "Values (" + i + ", " + BatchNumber + ", " + rndNumber + ", 1)";
                        thisADO.updateOrInsert(strSQL, false);
                    }
                }
                return null;
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
        [Route("api/CardDistHistorys/GetLastShipped/")]
        public List<CardDistHistory> Get()
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select max(EndingNumber) as maxShipped from CardDistributionHistory where ActivityId = 2 ";
                List<CardDistHistory> list = new List<CardDistHistory>();
                thisADO.returnList(strSQL, false, ref list);

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
