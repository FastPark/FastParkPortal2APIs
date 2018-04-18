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
    public class SupportTicketsController : ApiController
    {
        [HttpGet]
        [Route("api/SupportTickets/GetSupportTicketsById/{id}")]
        public List<SupportTicket> GetSupportTicketsById(string id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                if (id == "ALL")
                {
                    strSQL = "select SupportTicketId, SupportTicketDesc, SupportTicketDate, SupportTicketSubmittedBy " +
                         "from SupportTicket.dbo.SupportTicket order by SupportTicketDate";
                }
                else
                {
                    strSQL = "select SupportTicketId, SupportTicketDesc, SupportTicketDate, SupportTicketSubmittedBy " +
                         "from SupportTicket.dbo.SupportTicket " +
                         "where SupportTicketSubmittedBy = '" + id + "' " +
                         "order by SupportTicketDate"; 
                }

                List<SupportTicket> list = new List<SupportTicket>();
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

        [HttpPost]
        [Route("api/SupportTickets/PostSupportTickets")]
        public string PostSupportTickets(SupportTicket st)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {

                strSQL = "Insert into SupportTicket.dbo.SupportTicket (SupportTicketDesc, SupportTicketDate, SupportTicketSubmittedBy) " +
                                           "Values ('" + st.SupportTicketDesc + "', '" + st.SupportTicketDate + "', '" + st.SupportTicketSubmittedBy + "')";

                thisADO.updateOrInsert(strSQL, true);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
