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
    public class MarketingCodeSavesController : ApiController
    {
        [HttpPost]
        [Route("api/MarketingCodeSaves/SaveMarketingCode")]
        public string SaveMarketingCode(MarketingCodeSave MC)
        {
            var strSQL = "";
            var thisADO = new clsADO();

            try
            {


            strSQL = "Update MemberInformationMain set MarketingCode = '" + MC.MarketingCode + "', UpdateDatetime = GetDate() where MemberId = " + MC.MemberId;
            thisADO.updateOrInsert(strSQL, true);

            int intMaxBatch = 0;
            intMaxBatch = Convert.ToInt32(thisADO.returnSingleValueForInternalAPIUse("Select Max(changeBatch) from changeLog", false));
            int nextBatch = intMaxBatch + 1;

            strSQL = "Insert into changeLog " + "(changeUser, changeDate, changeID, changeValOld, changeValNew, changeTable, changeNote, changeBatch, CreateUserId) " +
                     "Values ('" + MC.ChangedBy + "', '" + DateTime.Now + "', '" + MC.MemberId + "', '" + MC.OldMarketingCode + "', '" + MC.MarketingCode + "', 'MemberInformationMain', 'Change MarketingCode', " + nextBatch + ", -1)";

            thisADO.updateOrInsert(strSQL, true);

            return "Success!";

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
