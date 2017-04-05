using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class Audit
    {
        public Int64 MemberId
        {
            get { return m_MemberId; }
            set { m_MemberId = value; }
        }
        private Int64 m_MemberId;
        public string FirstName
        {
            get { return m_FirstName; }
            set { m_FirstName = value; }
        }
        private string m_FirstName;
        public string LastName
        {
            get { return m_LastName; }
            set { m_LastName = value; }
        }
        private string m_LastName;
        public string DataChanged
        {
            get { return m_DataChanged; }
            set { m_DataChanged = value; }
        }
        private string m_DataChanged;
        public string OldValue
        {
            get { return m_OldValue; }
            set { m_OldValue = value; }
        }
        private string m_OldValue;
        public string NewValue
        {
            get { return m_NewValue; }
            set { m_NewValue = value; }
        }
        private string m_NewValue;
        public string ChangeType
        {
            get { return m_ChangeType; }
            set { m_ChangeType = value; }
        }
        private string m_ChangeType;
        public string changeUser
        {
            get { return m_changeUser; }
            set { m_changeUser = value; }
        }
        private string m_changeUser;
        public DateTime changeDate
        {
            get { return m_changeDate; }
            set { m_changeDate = value; }
        }
        private DateTime m_changeDate;
        public DateTime orderColumn
        {
            get { return m_orderColumn; }
            set { m_orderColumn = value; }
        }
        private DateTime m_orderColumn;
    }
}