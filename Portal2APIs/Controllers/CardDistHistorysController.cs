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
        public List<CardDistHistory> Get(string id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();
            var thisLocationId = "";

            if (Convert.ToString(id).IndexOf('_') > -1)
            {
                string[] thisVarialbe = Convert.ToString(id).Split('_');
                id = thisVarialbe[0];
                thisLocationId = thisVarialbe[1];
            }

            try
            {
                if (id == "-1")  //Get Order only
                {
                    strSQL = "Select cdh.*, l.ShortLocationName, cdat.CardDistributionActivityDescription from CardDistributionHistory cdh " +
                          "Left Outer Join LocationDetails l on cdh.LocationId = l.LocationID " +
                          "Inner Join CardDistributionActivityType cdat on cdh.ActivityId = cdat.CardDistributionActivityTypeID " +
                          "where ActivityId = 1 order by cdh.EndingNumber desc ";
                }
                else if (id == "-2")  // get orders for receiving
                {
                    strSQL = "Select * from ( " +
                                "select cdh.*, cdh2.ActivityDate as ReceivedDate, cdh2.RecordedBy as ReceviedBy " +
                                "from CardDistributionHistory cdh " +
                                "Left Outer Join CardDistributionHistory cdh2 on cdh.CardHistoryId = cdh2.JoinCardHistoryId " +
                            ") orderActivity " +
                            "where ActivityId = 1 order by EndingNumber desc ";
                }
                else if (id == "-3")  //shipping only
                {
                    strSQL = "Select cdh.*, l.ShortLocationName, cdat.CardDistributionActivityDescription from CardDistributionHistory cdh " +
                          "Left Outer Join LocationDetails l on cdh.LocationId = l.LocationID " +
                          "Inner Join CardDistributionActivityType cdat on cdh.ActivityId = cdat.CardDistributionActivityTypeID " +
                          "where ActivityId = 2 order by cdh.EndingNumber desc "; 
                }
                else if (id == "-4")  // get orders for receiving
                {
                    strSQL = "Select * from ( " +
                                "select cdh.*, cdh2.ActivityDate as ReceivedDate, cdh2.RecordedBy as ReceviedBy " +
                                "from CardDistributionHistory cdh " +
                                "Left Outer Join CardDistributionHistory cdh2 on cdh.CardHistoryId = cdh2.JoinCardHistoryId " +
                            ") orderActivity " +
                            "where ActivityId = 2 and LocationId = " + thisLocationId + " " +
                            "order by EndingNumber desc ";
                }
                else if (id == "-5")  // get orders for receiving
                {
                    strSQL = "Select CardHistoryId, ActivityDate, ActivityId, StartingNumber, EndingNumber, NumberOfCards, JoinCardHistoryId, OrderConfirmationDate, DistributionPoint, BusOrRepId, " +
                                "Shift, RecordDate, RecordedBy, LocationId, CreateDatetime, CreateUserId, UpdateDatetime, UpdateUserId, IsDeleted, CreateExternalUserData, " +
                                "UpdateExternalUserData " +
                            "from( " +
                                "select *, CardHistoryId as OrderId " +
                                "from CardDistributionHistory " +
                                "where ActivityId = 7 " +
                                "Union " +
                                "select *, JoinCardHistoryId as OrderId " +
                                "from CardDistributionHistory " +
                                "where ActivityId = 4 " +
                            ") dist " +
                            "Where LocationId = " + thisLocationId + " " + 
                            "Order by OrderId";
                }
                else // this is for locations
                {
                    strSQL = "Select cdh.*, l.ShortLocationName from CardDistributionHistory cdh " +
                          "inner Join LocationDetails l on cdh.LocationId = l.LocationID " +
                          "where cdh.LocationId=" + id + "";
                }
                
                List<CardDistHistory> list = new List<CardDistHistory>();
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
        [Route("api/CardDistHistorys/GetCardRange")]
        public List<CardDistHistory> GetCardRange([FromUri]int startingNumber, [FromUri]int endingNumber)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "Select cdh.*, l.ShortLocationName, cdat.CardDistributionActivityDescription " +
                          "from CardDistributionHistory cdh " +
                          "left Outer Join LocationDetails l on cdh.LocationId = l.LocationID " +
                          "inner Join CardDistributionActivityType cdat on cdh.ActivityId = cdat.CardDistributionActivityTypeID " +
                          "where StartingNumber >= " + startingNumber + " and EndingNumber <= " + endingNumber;

                List<CardDistHistory> list = new List<CardDistHistory>();
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
                                                        "OrderConfirmationDate, DistributionPoint, BusOrRepID, Shift, RecordDate, RecordedBy, LocationId, CreateUserId, CreateDatetime, JoinCardHistoryId) " +
                                                        "values ('" + CDH.ActivityDate + "', " + CDH.ActivityId + ", " + CDH.StartingNumber + ", " +
                                                        CDH.EndingNumber + ", " + CDH.NumberOfCards + ", '" + CDH.OrderConfirmationDate + "', '" +
                                                        CDH.DistributionPoint + "', '" + CDH.BusOrRepId + "', '" + CDH.Shift + "', getDate(), '" + CDH.RecordedBy + "', " + CDH.LocationId + ", -1, getDate(), " + CDH.CardHistoryId + ")";

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
        [Route("api/CardDistHistorys/GetHighestCardNumberOrderReceived/")]
        public List<CardDistHistory> GetHighestCardNumberOrderReceived()
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select max(EndingNumber) as maxShipped from CardDistributionHistory where ActivityId = 3 ";
                List<CardDistHistory> list = new List<CardDistHistory>();
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
        [Route("api/CardDistHistorys/ConfirmOrder/{id}")]
        public HttpResponseMessage ConfirmOrder(int Id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "update CardDistributionHistory set OrderConfirmationDate = getdate() where CardHistoryId = " + Id;

                thisADO.updateOrInsert(strSQL, false);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "Success");
                return response;
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
        [Route("api/CardDistHistorys/FindCardHistory/{id}")]
        public List<CardDistHistory> FindCardHistory(int id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {

                strSQL = "Select cdh.*, l.ShortLocationName, cdat.CardDistributionActivityDescription from CardDistributionHistory cdh " +
                        "Left Outer Join LocationDetails l on cdh.LocationId = l.LocationID " +
                        "Inner Join CardDistributionActivityType cdat on cdh.ActivityId = cdat.CardDistributionActivityTypeID " +
                        "Where StartingNumber < " + id + " " +
                        "And EndingNumber > " + id + " " +
                        "order by endingNumber desc ";
               

                List<CardDistHistory> list = new List<CardDistHistory>();
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
        [Route("api/CardDistHistorys/ConfirmNumbers/{id}")]
        public List<CardDistHistory> ConfirmNumbers(string Id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();
            var thisHitoryType = "";
            var thisCardNumber = "";

            if (Id.IndexOf('_') > -1)
            {
                string[] thisVarialbe = Convert.ToString(Id).Split('_');
                thisHitoryType = thisVarialbe[0];
                thisCardNumber = thisVarialbe[1];
            }

            try
            {
                strSQL = "select * " +
                        "from CardDistributionHistory " +
                        "where " + thisCardNumber + " between StartingNumber and EndingNumber " +
                        "and ActivityId = " + thisHitoryType;

                List<CardDistHistory> list = new List<CardDistHistory>();
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
