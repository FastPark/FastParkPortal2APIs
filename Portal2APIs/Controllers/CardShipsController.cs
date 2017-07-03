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
    public class CardShipsController : ApiController
    {
        [HttpGet]
        [Route("api/CardShips/GetShipments/{id}")]
        public List<CardShip> GetShipments(string id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "select css.CardShipStatus, l1.ShortLocationName as CardShipFromName, CardShipFrom, CardShipTo, l2.ShortLocationName as CardShipToName, cs.*, cd.CardDesignDesc, cd.CardDesignId " +
                        "from CardDistribution.dbo.CardShip cs " +
                        "Inner Join CardDistribution.dbo.CardShipStatus css on cs.CardShipStatusId = css.CardShipStatusID " +
                        "Inner Join CardDistribution.dbo.locationDetails l1 on cs.CardShipFrom = l1.LocationId " +
                        "Inner Join CardDistribution.dbo.LocationDetails l2 on cs.CardShipTo = l2.LocationId " +
                        "Inner Join CardDistribution.dbo.CardDesign cd on cs.CardDesignId = cd.CardDesignId " +
                        "Where cs.CardShipTo in (" + id + ") " +
                        "Order by CardShipEndNumber desc, CardShipID";
                List<CardShip> list = new List<CardShip>();
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
        [Route("api/CardShips/ShipCards")]
        public string ShipCards(CardShip CS)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;
            Int64 startingNumber = CS.CardShipStartNumber;
            Int64 endingNumber = CS.CardShipEndNumber;

            DateTime now = DateTime.Now;

            try
            {
                strSQL = "insert into CardDistribution.dbo.CardShip (CardShipFrom, CardShipTo, CardShipDate, CardShipShippedBy, CardShipStartNumber, CardShipEndNumber, CardShipStatusId, CardDesignId) " +
                                                        "values (" + CS.CardShipFrom + ", " + CS.CardShipTo + ", '" + now + "', '" + CS.CardShipShippedBy + "', " + CS.CardShipStartNumber + ", "+ CS.CardShipEndNumber + ", 1, " + CS.CardDesignId + ")";

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
        [Route("api/CardShips/Update")]
        public string Update(CardShip CS)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            DateTime now = DateTime.Now;

            try
            {
                strSQL = "Update CardDistribution.dbo.CardShip set CardShipReceivedBy =  '" + CS.CardShipReceivedBy + "',  CardShipReceiveDate = '" + now + "', CardShipStatusID = 3 where CardShipID = " + CS.CardShipID;

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
        [Route("api/CardShips/reShip")]
        public string reShip(CardShip CS)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            DateTime now = DateTime.Now;

            try
            {
                strSQL = "Update CardDistribution.dbo.CardShip set IsActive = 0 where CardShipID = " + CS.CardShipID;

                thisADO.updateOrInsert(strSQL, false);

                strSQL = "insert into CardDistribution.dbo.CardShip (CardShipFrom, CardShipTo, CardShipDate, CardShipShippedBy, CardShipStartNumber, CardShipEndNumber, CardShipStatusId, CardDesignId) " +
                                                        "values (" + CS.CardShipFrom + ", " + CS.CardShipTo + ", '" + now + "', '" + CS.CardShipShippedBy + "', " + CS.CardShipStartNumber + ", " + CS.CardShipEndNumber + ", 1, " + CS.CardDesignId + ")";

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
        [Route("api/CardShips/edit")]
        public string edit(CardShip CS)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            DateTime now = DateTime.Now;

            try
            {
                strSQL = "Update CardDistribution.dbo.CardShip set CardShipFrom =  " + CS.CardShipFrom + ",  CardShipTo = " + CS.CardShipTo + ", CardShipShippedBy = '" + CS.CardShipShippedBy +
                                                  "', CardShipStartNumber =  " + CS.CardShipStartNumber + ",  CardShipEndNumber = " + CS.CardShipEndNumber + ", CardDesignId = " + CS.CardDesignId +
                                                  " where CardShipID = " + CS.CardShipID;

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

        [HttpGet]
        [Route("api/CardShips/ConfirmNumbers/{id}")]
        public List<CardShip> ConfirmNumbers(string Id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "select * from CardDistribution.dbo.CardShip " +
                        "where " + Id + " between CardShipStartNumber and CardShipEndNumber where IsActive = 1 ";

                List<CardShip> list = new List<CardShip>();
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
        [Route("api/CardShips/ConfirmShipLocation/{id}")]
        public List<CardShip> ConfirmShipLocation(string Id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "select CardShipTo from CardDistribution.dbo.CardShip " +
                        "where " + Id + " between CardShipStartNumber and CardShipEndNumber where IsActive = 1 ";

                List<CardShip> list = new List<CardShip>();
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
        [Route("api/CardShips/GetLastShipped/")]
        public List<CardShip> Get()
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select max(CardShipEndNumber) as maxShipped from CardDistribution.dbo.CardShip where IsActive = 1";
                List<CardShip> list = new List<CardShip>();
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
