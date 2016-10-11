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
    public class CompanyChecksController : ApiController
    {
        [HttpGet]
        [Route("api/CompanyChecks/CompanyCheckByLocationId/{id}")]
        public List<CompanyCheck> CompanyCheckByLocationId(int id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select ac.ArticleCheckId, ac.ArticleNumber, ac.LocationId, ac.CompanyName, ac.EmailDomain, ac.CompanyId, ac.EnteredByUserId, ac.DateEntered, l.NameOfLocation from dbo.ArticleCheck ac " +
                    "Inner Join Location l on ac.LocationId = l.LocationId " +
                    "where ac.LocationId=" + id + "";
                List<CompanyCheck> list = new List<CompanyCheck>();
                thisADO.returnList(strSQL, false, ref list);

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
