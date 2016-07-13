using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.Http;
using Portal2APIs.Models;
using Portal2APIs.Common;

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
            CardDistHistoryNote CDHN = null;
            List<CardDistHistoryNote> allNotes = new List<CardDistHistoryNote>();
            clsCommon nullCheck = new clsCommon();

            strSQL = "Select * from dbo.CardDistributionHistoryNote where CardHistoryID = " + id;
            using (SqlConnection connection = new SqlConnection(thisADO.getMaxConnectionString()))
            {
                SqlCommand command = new SqlCommand(strSQL, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    CDHN = new CardDistHistoryNote();
                    CDHN.CardHistoryNoteID = Convert.ToInt32(nullCheck.checknull(reader.GetValue(0), false));
                    CDHN.CardHistoryId = Convert.ToInt32(nullCheck.checknull(reader.GetValue(1), false));
                    CDHN.Note = Convert.ToString(nullCheck.checknull(reader.GetValue(2), false));

                    allNotes.Add(CDHN);
                }
                reader.Close();
            }

            return allNotes;

        }
        [HttpPost]
        [Route("api/CardDistHistoryNotes/Post")]
        public CardDistHistoryNote Post(CardDistHistoryNote CDHN)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            strSQL = "insert into CardDistributionHistoryNote (CardHistoryID, Note) " +
                                                                "values ('" + CDHN.CardHistoryId + "', '" + CDHN.Note + "')";

            thisADO.updateOrInsert(strSQL, true);

            return null;
        }

        
    }
}
