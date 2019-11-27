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
    public class PendingManualEditsController : ApiController
    {
        [HttpGet]
        [Route("api/PendingManualEdits/PendingManualEditsByLocation/{id}")]
        public List<PendingManualEdit> PendingManualEditsByLocation(int id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select mi.FirstName + ' ' + mi.LastName as FullName, met.Explanation, " +
                         "pme.Points, pme.LocationId, pme.MemberID, pme.DateOfRequest, pme.CertificateNumber, pme.ManualEditID, " + 
                         "pme.ExplanationID, pme.Delivery, pme.Notes, pme.AddedByUserId, pme.CompanyId, mc.FPNumber " +
                         "from dbo.ManualEditHoldingArea pme " +
                         "Inner Join MemberInformationMain mi on pme.MemberID = mi.MemberID " +
                         "Inner Join MemberCard mc on pme.MemberID = mc.MemberID " +
                         "Inner Join ManualEditTypes met on pme.ExplanationId = met.ExplanationId " +
                         "Where pme.LocationId=" + id + " and mc.IsPrimary = 1";
                List<PendingManualEdit> list = new List<PendingManualEdit>();

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


        //[HttpPost]
        //[Route("api/PendingManualEdits/SubmitManualEdits/")]
        //public string PostJsonString([FromBody] string ManualEdits)
        //{
        //    var textArray = ManualEdits.Split(',');  // now you have an array of 3 strings

        //    foreach (string thisManualEditId in textArray)
        //    {
        //        //Call new submit Manual Edit with thisManualEditId
        //    }
        //    return ManualEdits;
        //}
    }
}
