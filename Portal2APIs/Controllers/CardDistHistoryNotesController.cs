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
    public class CardDistHistoryNotesController : ApiController
    {
        [HttpGet]
        [Route("api/CardDistHistoryNotes/Get/{id}")]
        public List<CardDistHistoryNote> Get(int id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select * from dbo.CardDistributionHistoryNote where CardHistoryID = " + id;
                List<CardDistHistoryNote> list = new List<CardDistHistoryNote>();
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

        [HttpPost]
        [Route("api/CardDistHistoryNotes/Post")]
        public CardDistHistoryNote Post(CardDistHistoryNote CDHN)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            strSQL = "insert into CardDistributionHistoryNote (CardHistoryID, Note) " +
                                                                "values ('" + CDHN.CardHistoryId + "', '" + CDHN.Note + "')";

            thisADO.updateOrInsert(strSQL, false);

            return null;
        }

        
    }
}
