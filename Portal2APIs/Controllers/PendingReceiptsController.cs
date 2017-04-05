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
    public class PendingReceiptsController : ApiController
    {
        [HttpPost]
        [Route("api/PendingReceipts/UpdatePendingReceipt")]
        public string UpdatePendingReceipt(PendingReceipt PR)
        {
            var strSQLPendingUpdate = "";
            var thisADO = new clsADO();

            try
            {

                strSQLPendingUpdate = "Update PendingReceipts set ReceiptNumber = '" + PR.ReceiptNumber + "', EntryDate = '" + PR.EntryDate + "', Processed = 0 where PendingReceiptId = " + PR.PendingReceiptId; 
                thisADO.updateOrInsert(strSQLPendingUpdate, false);

                return "Success";

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [HttpGet]
        [Route("api/PendingReceipts/getPendingReceipts/{id}")]
        public List<PendingReceipt> getPendingReceipts(int id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "select Cast(0 as bit) as thisSelect, mi.FirstName + ' ' + mi.LastName as memberName, PendingReceiptId, ReceiptNumber, pr.UpdateExternalUserData, EntryDate, SubmittedDate, pr.UpdateExternalUserData " +
                        "from PendingReceipts pr " +
                        "Inner Join MemberInformationMain mi on pr.MemberID = mi.MemberId " +
                        "Where pr.LocationID = " + id + " " +
                        "and Processed = 2";

                List<PendingReceipt> list = new List<PendingReceipt>();
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
        [Route("api/PendingReceipts/deletePendingReceipts/{id}")]
        public string deletePendingReceipts(int id)
        {
            try
            {
                clsADO thisADO = new clsADO();

                string strSQLPendingDelete = "Update PendingReceipts set Processed = 10 where PendingReceiptId = " + id;
                thisADO.updateOrInsert(strSQLPendingDelete, false);

                return "Success";
            }
            catch (Exception ex)
            {
                return "Error - " + ex.ToString();
            }
        }
    }
}
