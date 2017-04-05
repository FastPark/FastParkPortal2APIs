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
        public DateTime CreateDatetime
        {
            get { return m_CreateDatetime; }
            set { m_CreateDatetime = value; }
        }
        private DateTime m_CreateDatetime;

        public Int64 CreateUserId
        {
            get { return m_CreateUserId; }
            set { m_CreateUserId = value; }
        }
        private Int64 m_CreateUserId;
        public DateTime UpdateDatetime
        {
            get { return m_UpdateDatetime; }
            set { m_UpdateDatetime = value; }
        }
        private DateTime m_UpdateDatetime;
        public Int64 UpdateUserId
        {
            get { return m_UpdateUserId; }
            set { m_UpdateUserId = value; }
        }
        private Int64 m_UpdateUserId;
        public int IsDeleted
        {
            get { return m_IsDeleted; }
            set { m_IsDeleted = value; }
        }
        private int m_IsDeleted;
        public String CreateExternalUserData
        {
            get { return m_CreateExternalUserData; }
            set { m_CreateExternalUserData = value; }
        }
        private String m_CreateExternalUserData;
        public String UpdateExternalUserData
        {
            get { return m_UpdateExternalUserData; }
            set { m_UpdateExternalUserData = value; }
        }
        private String m_UpdateExternalUserData;
    }
}