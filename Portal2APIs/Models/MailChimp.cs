using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class MailChimp
    {
        public Int32 MemberId
        {
            get { return m_MemberId; }
            set { m_MemberId = value; }
        }
        private Int32 m_MemberId;

        public string MCFirstName
        {
            get { return m_MCFirstName; }
            set { m_MCFirstName = value; }
        }
        private string m_MCFirstName;

        public string MCLastName
        {
            get { return m_MCLastName; }
            set { m_MCLastName = value; }
        }
        private string m_MCLastName;
        public string MCEmailAddress
        {
            get { return m_MCEmailAddress; }
            set { m_MCEmailAddress = value; }
        }
        private string m_MCEmailAddress;

        public string MCFPNumber
        {
            get { return m_MCFPNumber; }
            set { m_MCFPNumber = value; }
        }
        private string m_MCFPNumber;
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

        public string EmailAddress
        {
            get { return m_EmailAddress; }
            set { m_EmailAddress = value; }
        }
        private string m_EmailAddress;
    }
}