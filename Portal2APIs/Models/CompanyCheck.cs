using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class CompanyCheck
    {
        public int ArticleCheckId
        {
            get { return m_ArticleCheckId; }
            set { m_ArticleCheckId = value; }
        }
        private int m_ArticleCheckId;

        public int ArticleNumber
        {
            get { return m_ArticleNumber; }
            set { m_ArticleNumber = value; }
        }
        private int m_ArticleNumber;
        public int LocationId
        {
            get { return m_LocationId; }
            set { m_LocationId = value; }
        }
        private int m_LocationId;
        public string CompanyName
        {
            get { return m_CompanyName; }
            set { m_CompanyName = value; }
        }
        private string m_CompanyName;
        public string EmailDomain
        {
            get { return m_EmailDomain; }
            set { m_EmailDomain = value; }
        }
        private string m_EmailDomain;
        public int CompanyId
        {
            get { return m_CompanyId; }
            set { m_CompanyId = value; }
        }
        private int m_CompanyId;
        public string EnteredByUserId
        {
            get { return m_EnteredByUserId; }
            set { m_EnteredByUserId = value; }
        }
        private string m_EnteredByUserId;
        public DateTime DateEntered
        {
            get { return m_DateEntered; }
            set { m_DateEntered = value; }
        }
        private DateTime m_DateEntered;
        public string NameOfLocation
        {
            get { return m_NameOfLocation; }
            set { m_NameOfLocation = value; }
        }
        private string m_NameOfLocation;
    }
}