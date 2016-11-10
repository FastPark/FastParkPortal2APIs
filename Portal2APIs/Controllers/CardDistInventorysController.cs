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
    public class CardDistInventorysController : ApiController
    {
        [HttpGet]
        [Route("api/CardDistInventorys/GetLastCardOrdered/")]
        public List<CardDistInventory> GetLastCardOrdered()
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "select MAX(CardFPNumber) as orderedMax from CardDistributionInventory where CardActive = 'True'";
                List<CardDistInventory> list = new List<CardDistInventory>();
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