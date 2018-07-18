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
    public class RateAmountObjectsController : ApiController
    {
        [HttpGet]
        [Route("api/RateAmountObjects/GetRateAmounts/{id}")]
        public List<RateAmountObject> GetRateAmounts(int id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "select RateAmountId, RateCode, RateAmount, EffectiveDatetime, AdvertisedRate, HourlyRate, DailyRateThreshold, UpdateDatetime, UpdateExternalUserData " +
                         "from rateamounts " +
                         "where locationId = " + id + " " +
                         "--and UpdateDatetime is null " +
                         "order by EffectiveDatetime";

                List<RateAmountObject> list = new List<RateAmountObject>();
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

        [HttpPost]
        [Route("api/RateAmountObjects/PostRateAmounts")]
        public string PostRateAmounts(RateAmountObject RAO)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                //strSQL = "Update RateAmounts set UpdateDatetime = GetDate() where RateCode = " + RAO.RateCode + " and UpdateDatetime is null and LocationId = " + RAO.LocationId;

                //thisADO.updateOrInsert(strSQL, true);

                strSQL = "Insert into RateAmounts (RateCode, RateAmount, EffectiveDatetime, LocationId, AdvertisedRate, HourlyRate, DailyRateThreshold, CreateUserId, IsDeleted, UpdateExternalUserData) " +
                                           "Values (" + RAO.RateCode + ", " + RAO.RateAmount + ", '" + RAO.EffectiveDatetime + "', " + RAO.LocationId + ", " + RAO.AdvertisedRate + ", " + RAO.HourlyRate + ", " + RAO.DailyRateThreshold + ", -1, 0, '" + RAO.UpdateExternalUserData +"')";

                thisADO.updateOrInsert(strSQL, true);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
