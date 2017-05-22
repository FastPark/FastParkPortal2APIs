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
    public class CardsController : ApiController
    {
        [HttpGet]
        [Route("api/Cards/GetCards/{id}")]
        public List<Card> GetCards(int id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select CardId, MemberId, SerialNumber, FPNumber, IsPrimary, IsDeleted, IsActive, CreateDatetime, UpdateDatetime from MemberCard " +
                        "where MemberId = " + id + " " +
                        "order by FPNumber";

                List<Card> list = new List<Card>();

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

        [HttpGet]
        [Route("api/Cards/UnDeleteCard/{id}")]
        public string UnDeleteCard(int id)
        {
            try
            {
                clsADO thisADO = new clsADO();

                string strSQLPendingDelete = "Update MemberCard set IsDeleted = 0 where CardId = " + id;
                thisADO.updateOrInsert(strSQLPendingDelete, true);

                return "Success";
            }
            catch (Exception ex)
            {
                return "Error - " + ex.ToString();
            }
        }
    }
}
