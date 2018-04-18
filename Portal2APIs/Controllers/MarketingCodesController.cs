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
    public class MarketingCodesController : ApiController
    {
        [HttpGet]
        [Route("api/MarketingCodes/GetMarketingCodes/{id}")]
        public List<MarketingCodeObject> GetMarketingCodes(string id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "select MarketingCodeId, MarketingCode, StartDate, Active, RepID, Notes, ShortNotes, CreateUserId, UpdateExternalUserData " +
                         "from MarketingCode " +
                         "where RepID = '" + id + "' ";

                List<MarketingCodeObject> list = new List<MarketingCodeObject>();
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
        [Route("api/MarketingCodes/PostMarketingCodes")]
        public string PostRateAmounts(MarketingCodeObject MC)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {

                strSQL = "Insert into MarketingCode (MarketingCode, StartDate, Active, RepID, Notes, ShortNotes, CreateUserId, IsDeleted, UpdateExternalUserData) " +
                                           "Values ('" + MC.MarketingCode + "', '" + MC.StartDate + "', " + MC.Active + ", '" + MC.Notes + "', '" + MC.ShortNotes + "', -1, 0, '" + MC.UpdateExternalUserData + "')";

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
