using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.Http;
using Portal2APIs.Models;
using Portal2APIs.Common;
using System.Net;
using System.Net.Http;

namespace Portal2APIs.Controllers
{
    public class CardDistActivityTypesController : ApiController
    {
        [HttpGet()]
        [Route("api/CardDistActivityTypes/Get/{id}")]
        public List<CardDistActivityType> Get(int id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select * from dbo.CardDistributionActivityType where CardDistributionActivityTypeID=" + id + "";
                List<CardDistActivityType> list = new List<CardDistActivityType>();
                thisADO.returnList(strSQL, false, ref list);

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

        [HttpPost]
        [Route("api/CardDistActivityTypes/Post")]
        public CardDistActivityType Post(CardDistActivityType CDAT)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            strSQL = "insert into CardDistributionActivityType (CardDistributionActivityDescription, CardDistributionActivityRole) " +
                                                                "values ('" + CDAT.CardDistributionActivityDescription + "', '" + CDAT.CardDistributionActivityRole + "')";

            thisADO.updateOrInsert(strSQL, false);

            return null;
        }
    }
}
