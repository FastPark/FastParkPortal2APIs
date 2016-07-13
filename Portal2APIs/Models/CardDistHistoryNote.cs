using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class CardDistHistoryNote
    {
        public int CardHistoryNoteID
        {
            get { return m_CardHistoryNoteID; }
            set { m_CardHistoryNoteID = value; }
        }
        private int m_CardHistoryNoteID;

        public int CardHistoryId
        {
            get { return m_CardHistoryId; }
            set { m_CardHistoryId = value; }
        }
        private int m_CardHistoryId;

        public string Note
        {
            get { return m_Note; }
            set { m_Note = value; }
        }
        private string m_Note;
    }
}