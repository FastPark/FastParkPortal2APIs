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
    public class RateListsController : ApiController
    {
        [HttpGet]
        [Route("api/RateLists/GetRates/{id}")]
        public List<RateList> GetRates(string id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "Select l.LocationId, l.ShortLocationName + ' - ' + Cast(dbo.GetlocationRateFunction(" + id + ", l.LocationId) as nvarchar) + ' - ' + Cast(ra.RateAmount as nvarchar) + " +
                            "Case When l.LocationId In ( " +
                                "select location_Id from MarketingFlyer.dbo.market_has_locations mhl " +
                                "inner join company_market_histories_For_Import_Current cmh on mhl.market_Id = cmh.market_Id " +
                                "where cmh.company_id = " + id + " " +
                            ") then ' **' Else '' End as RateDisplay " +
                            "from LocationDetails l " +
                            //"inner join RateAmounts ra on l.LocationId = ra.LocationId and dbo.GetlocationRateFunction(" + id + ", l.LocationId) = ra.RateCode and getdate() between ra.EffectiveDatetime AND ISNULL(ra.UpdateDatetime, DATEADD(DAY,1,GETDATE())) " +
                            "inner join RateAmounts ra on l.LocationId = ra.LocationId and dbo.GetlocationRateFunction(" + id + ", l.LocationId) = ra.RateCode and ra.CreateDatetime = (select max(CreateDatetime) from RateAmounts where RateCode = ra.RateCode and LocationId = ra.LocationId AND GETDATE() > EffectiveDatetime) " +
                            "Where l.SkiDataLocation = 1 " +
                            "Order by l.ShortLocationName";

                List<RateList> list = new List<RateList>();
                thisADO.returnSingleValue(strSQL, true, ref list);

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
        [Route("api/RateLists/GetRatesDO/")]
        public List<RateList> GetRatesDO()
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "Select l.LocationId, l.ShortLocationName + ' - ' + Cast(5 as nvarchar) + ' - ' + Cast(Cast(ra.RateAmount * .9 / 100 as decimal(10,2)) as nvarchar) as RateDisplay " +
                            "from LocationDetails l " +
                            "inner " +
                            "join RateAmounts ra on l.LocationId = ra.LocationId and dbo.GetlocationRateFunction(12962, l.LocationId) = ra.RateCode and ra.CreateDatetime = (select max(CreateDatetime) from RateAmounts where RateCode = ra.RateCode and LocationId = ra.LocationId AND GETDATE() > EffectiveDatetime) " +
                            "Where l.SkiDataLocation = 1 " +
                            "Order by l.ShortLocationName; ";

                List<RateList> list = new List<RateList>();
                thisADO.returnSingleValue(strSQL, true, ref list);

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
        [Route("api/RateLists/MemberHasDO/{id}")]
        public List<RateList> MemberHasDO(string id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "Select MemberId from MemberHasDiscountOrganization where GETDATE() between EffectiveDatetime and ExpiresDatetime and MemberId = " + id;

                List<RateList> list = new List<RateList>();
                thisADO.returnSingleValue(strSQL, true, ref list);

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
