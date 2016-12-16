using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class Member
    {
        public int MemberId
        {
            get { return m_MemberId; }
            set { m_MemberId = value; }
        }
        private int m_MemberId;

        public string FPNumber
        {
            get { return m_FPNumber; }
            set { m_FPNumber = value; }
        }
        private string m_FPNumber;

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
        public string HomePhone
        {
            get { return m_HomePhone; }
            set { m_HomePhone = value; }
        }
        private string m_HomePhone;
        public string Company
        {
            get { return m_Company; }
            set { m_Company = value; }
        }
        private string m_Company;


        public string UserName
        {
            get { return m_UserName; }
            set { m_UserName = value; }
        }
        private string m_UserName;

        public string MailerCompany
        {
            get { return m_MailerCompany; }
            set { m_MailerCompany = value; }
        }
        private string m_MailerCompany;

        public string MarketingCode
        {
            get { return m_MarketingCode; }
            set { m_MarketingCode = value; }
        }
        private string m_MarketingCode;

        public string StreetAddress
        {
            get { return m_StreetAddress; }
            set { m_StreetAddress = value; }
        }
        private string m_StreetAddress;

        public string Home
        {
            get { return m_Home; }
            set { m_Home = value; }
        }
        private string m_Home;
    }
}