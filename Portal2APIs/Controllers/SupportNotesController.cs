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
    public class SupportNotesController : ApiController
    {
        [HttpGet]
        [Route("api/SupportNotes/GetSupportNotesById/{id}")]
        public List<SupportNote> GetSupportNotesById(Int32 id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();
                
                strSQL = "select SupportNoteId, SupportNoteDesc, SupportNotetDate, SupportNoteSubmittedBy " +
                        "from SupportTicket.dbo.SupportNote " +
                        "where SupportTicketId = " + id + " " +
                        "order by SupportNoteDate";
                

                List<SupportNote> list = new List<SupportNote>();
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
        [Route("api/SupportNotes/PostSupportNotes")]
        public string PostSupportNotes(SupportNote sn)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {

                strSQL = "Insert into SupportTicket.dbo.SupporNote (SupportNoteDesc, SupportNoteDate, SupportNoteSubmittedBy) " +
                                           "Values ('" + sn.SupportNoteDesc + "', '" + sn.SupportNoteDate + "', '" + sn.SupportNoteSubmittedBy + "')";

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
