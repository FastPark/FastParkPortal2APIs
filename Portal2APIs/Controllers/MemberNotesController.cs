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
    public class MemberNotesController : ApiController
    {
        [HttpGet]
        [Route("api/MemberNotes/NotesByMemberId/{id}")]
        public List<MemberNote> NotesByMemberId(int id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select * from dbo.MemberNotes where MemberId=" + id + "";
                List<MemberNote> list = new List<MemberNote>();
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
        [Route("api/MemberNotes/AddNote/")]
        public string AddNote(MemberNote note)
        {
            try
            {
                clsADO thisADO = new clsADO();
                string strSQL = null;

                strSQL = "INSERT INTO dbo.MemberNotes (MemberID,Note,Date,SubmittedBy) " +
                         "Values (" + note.MemberId + ", '" + note.Note + "', '" + note.Date + "', '" + note.SubmittedBy + "')";

                thisADO.updateOrInsert(strSQL, true);

                return "Success";
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
        [Route("api/MemberNotes/UpdateNote")]
        public void UpdateManualEdit(MemberNote note)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            strSQL = "Update dbo.MemberNotes set MemberID = " + note.MemberId + ", Note = '" + note.Note + "', Date = '" + note.Date + "', SubmittedBy = '" + note.SubmittedBy + "' " +
                    " Where NotesId = " + note.NotesId;

            thisADO.updateOrInsert(strSQL, true);
        }

        [HttpDelete]
        [Route("api/MemberNotes/DeleteNoteById/{id}")]
        public void DeleteManualEditByID(int id)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            strSQL = "delete from dbo.MemberNotes where NotesId=" + id;

            thisADO.updateOrInsert(strSQL, true);

        }
    }
}
