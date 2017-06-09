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
    public class CardDesignsController : ApiController
    {

        [HttpGet]
        [Route("api/CardDesigns/GetCardDesigns")]
        public List<CardDesign> GetCardDesigns()
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "select * from CardDistribution.dbo.CardDesign";
                List<CardDesign> list = new List<CardDesign>();
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
    }
}
