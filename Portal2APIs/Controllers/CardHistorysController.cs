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
    public class CardHistorysController : ApiController
    {
        [HttpGet]
        [Route("api/CardHistorys/GetHistory/{id}")]
        public List<CardHistory> GetHistory(string id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "select 'Order' as [Action], co.CardOrderDate as [ActivityDate], co.CardOrderBy as [InitialUser], co.CardOrderStartNumber as [StartingCard], co.CardOrderEndNumber as [EndingCard], " +
                               "co.CardOrderReceivedDate as [ReceivedDate], co.CardOrderReceivedBy as [ReceiveUser], cStatus.CardOrderStatus as [Status], 'From Warehouse' as Location, 1 as IsActive " +
                        "From CardDistribution.dbo.CardOrder co " +
                        "Inner Join CardDistribution.dbo.CardOrderStatus cStatus on co.CardOrderStatusID = cStatus.CardOrderStatusID " +
                        "where " + id + " between co.CardOrderStartNumber and co.CardOrderEndNumber " +
                        "Union All " +
                        "select 'Ship' as [Action], cs.CardShipDate as [ActivityDate], cs.CardShipShippedBy as [InitialUser], cs.CardShipStartNumber as [StartingCard], cs.CardShipEndNumber as [EndingCard],  " +
                               "cs.CardShipReceiveDate as [Received Date], cs.CardShipReceivedBy as [ReceiveUser], cStatus.CardShipStatus as [Status], 'To ' + l1.ShortLocationName as Location, cs.IsActive " +
                        "From CardDistribution.dbo.CardShip cs " +
                        "Inner Join CardDistribution.dbo.CardShipStatus cStatus on cs.CardShipStatusID = cStatus.CardShipStatusID " +
                        "Inner Join CardDistribution.dbo.LocationDetails l1 on cs.CardShipTo = l1.LocationId " +
                        "where " + id + " between cs.CardShipStartNumber and cs.CardShipEndNumber " +
                        "Union All " +
                        "select 'Distribution' as [Action], cd.CardDistDate as [ActivityDate], cd.CardDistBy as [InitialUser], cd.CardDistStartNumber as [StartingCard], cd.CardDistEndNumber as [EndingCard], " +
                               "'' as [Received Date], '' as [ReceiveUser], 'To ' + Case When ISNULL(cd.CardDistRepLineID, 0) = 0 Then 'Booth' Else mr.FirstName + ' ' + mr.LastName End as [Status], 'At ' + l1.ShortLocationName as Location, 1 as IsActive " +
                        "From CardDistribution.dbo.CardDist cd " +
                        "Left Outer Join FrequentParker08.dbo.MarketingReps mr on cd.CardDistRepLineID = mr.ID " +
                        "Inner Join CardDistribution.dbo.LocationDetails l1 on cd.CardDistLocationID = l1.LocationId " +
                        "where " + id + " between cd.CardDistStartNumber and cd.CardDistEndNumber " +
                        "Order by ActivityDate";

                List <CardHistory> list = new List<CardHistory>();
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
