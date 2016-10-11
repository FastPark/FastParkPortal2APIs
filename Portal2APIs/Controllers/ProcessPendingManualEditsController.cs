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
    public class ProcessPendingManualEditsController : ApiController
    {
        [HttpPost]
        [Route("api/ProcessPendingManualEditsController/SubmitManualEdits")]
        public HttpResponseMessage SubmitManualEdits(ProcessPendingManualEdit PPME)
        {
            var strSQLInsertNew = "";
            var strSQLPendingDelete = "";
            var thisADO = new clsADO();

            try
            {
                var thisList = Convert.ToString(PPME.ProcessList);

                var textArray = thisList.Split(',');  // now you have an array 

                foreach (string thisManualEditId in textArray)
                {
                    var tempUser = "BA1B0B96-30D3-45AB-815D-3527F72B6442";


                    strSQLInsertNew = "	INSERT INTO ManualEdits (MemberId, LocationId, ManualEditDate, SubmittedDate, PerformedByUserId, SubmittedByUserId, ExplanationId, PointsChanged, Notes, CompanyId) " +
                                        "SELECT MemberId, LocationId, DateOfRequest, GETDATE(), AddedByUserId, '" + tempUser + "', ExplanationId, Points, Notes, CompanyId " +
                                        "FROM ManualEditHoldingArea " +
                                        "WHERE ManualEditId = " + thisManualEditId;
                    thisADO.updateOrInsert(strSQLInsertNew, true);

                    strSQLPendingDelete = "Delete from ManualEditHoldingArea where ManualEditId = " + thisManualEditId;
                    thisADO.updateOrInsert(strSQLPendingDelete, true);
                }

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

        [HttpPost]
        [Route("api/ProcessPendingManualEditsController/DeleteManualEdits")]
        public HttpResponseMessage DeleteManualEdits(ProcessPendingManualEdit PPME)
        {
            var strSQLPendingDelete = "";
            var thisADO = new clsADO();

            try
            {
                var thisList = Convert.ToString(PPME.ProcessList);

                var textArray = thisList.Split(',');  // now you have an array 

                foreach (string thisManualEditId in textArray)
                {
                    strSQLPendingDelete = "Delete from ManualEditHoldingArea where ManualEditId = " + thisManualEditId;
                    thisADO.updateOrInsert(strSQLPendingDelete, true);
                }

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
    }
}
