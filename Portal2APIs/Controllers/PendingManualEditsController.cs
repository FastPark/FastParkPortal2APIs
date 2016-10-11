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


                strSQL = "Select mi.FPNumber, mi.FullName, met.Explanation, pme.* from dbo.ManualEditHoldingArea pme " +
                         "Inner Join MemberInformation mi on pme.MemberID = mi.MemberID " +
                         "Inner Join ManualEditTypes met on pme.ExplanationId = met.ExplanationId " +
                         "Where mi.LocationId <> 5 " +
                         "and mi.LocationId <> 3 " +
                         "and pme.LocationId=" + id + "";
                List<PendingManualEdit> list = new List<PendingManualEdit>();
                thisADO.returnList(strSQL, true, ref list);

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
