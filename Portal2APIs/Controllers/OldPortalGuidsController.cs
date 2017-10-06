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
    public class OldPortalGuidsController : ApiController
    {
        [HttpGet()]
        [Route("api/OldPortalGuids/getUserId/{id}")]
        public List<OldPortalGuid> getUserId(string Id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO(); 

            try
            {

                strSQL = "select UserId from aspnetdb.dbo.aspnet_Users where UserName = '" + Id + "'";
                List<OldPortalGuid> list = new List<OldPortalGuid>();
                thisADO.returnSingleValue(strSQL, false, ref list);

                return list; ;
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
