using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class MemberNote
    {
        public int NotesId
        {
            get { return m_NotesId; }
            set { m_NotesId = value; }
        }
        private int m_NotesId;
        public int MemberId
        {
            get { return m_MemberId; }
            set { m_MemberId = value; }
        }
        private int m_MemberId;
        public string Note
        {
            get { return m_Note; }
            set { m_Note = value; }
        }
        private string m_Note;
        public DateTime Date
        {
            get { return m_Date; }
            set { m_Date = value; }
        }
        private DateTime m_Date;
        public string SubmittedBy
        {
            get { return m_SubmittedBy; }
            set { m_SubmittedBy = value; }
        }
        private string m_SubmittedBy;
    }
}