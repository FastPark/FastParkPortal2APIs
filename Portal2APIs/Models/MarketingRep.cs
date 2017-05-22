using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class MarketingRep
    {
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
        public string Location
        {
            get { return m_Location; }
            set { m_Location = value; }
        }
        private string m_Location;
        public string EmailAddress
        {
            get { return m_EmailAddress; }
            set { m_EmailAddress = value; }
        }
        private string m_EmailAddress;

        public string RepName
        {
            get { return m_RepName; }
            set { m_RepName = value; }
        }
        private string m_RepName;

        public string RepID
        {
            get { return m_RepID; }
            set { m_RepID = value; }
        }
        private string m_RepID;
        public Int32 ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }
        private Int32 m_ID;
    }
}