using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class Redemption
    {
        public int RedemptionId
        {
            get { return m_RedemptionId; }
            set { m_RedemptionId = value; }
        }
        private int m_RedemptionId;
        public string CertificateId
        {
            get { return m_CertificateId; }
            set { m_CertificateId = value; }
        }
        private string m_CertificateId;
        public DateTime RedeemDate
        {
            get { return m_RedeemDate; }
            set { m_RedeemDate = value; }
        }
        private DateTime m_RedeemDate;
        public int BeenUsed
        {
            get { return m_BeenUsed; }
            set { m_BeenUsed = value; }
        }
        private int m_BeenUsed;
        public DateTime DateUsed
        {
            get { return m_DateUsed; }
            set { m_DateUsed = value; }
        }
        private DateTime m_DateUsed;
        public string RedemptionTypeName
        {
            get { return m_RedemptionTypeName; }
            set { m_RedemptionTypeName = value; }
        }
        private string m_RedemptionTypeName;
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
        public Int64 MemberId
        {
            get { return m_MemberId; }
            set { m_MemberId = value; }
        }
        private Int64 m_MemberId;

        public int IsReturned
        {
            get { return m_IsReturned; }
            set { m_IsReturned = value; }
        }
        private int m_IsReturned;

        public int IsExpired
        {
            get { return m_IsExpired; }
            set { m_IsExpired = value; }
        }
        private int m_IsExpired;
        public string UpdateExternalUserData
        {
            get { return m_UpdateExternalUserData; }
            set { m_UpdateExternalUserData = value; }
        }
        private string m_UpdateExternalUserData;

        public string EmailAddress
        {
            get { return m_EmailAddress; }
            set { m_EmailAddress = value; }
        }
        private string m_EmailAddress;
        public string RedemptionSourceName
        {
            get { return m_RedemptionSourceName; }
            set { m_RedemptionSourceName = value; }
        }
        private string m_RedemptionSourceName;
        public DateTime ReturnRequest
        {
            get { return m_ReturnRequest; }
            set { m_ReturnRequest = value; }
        }
        private DateTime m_ReturnRequest;
        public DateTime ReturnProcessed
        {
            get { return m_ReturnProcessed; }
            set { m_ReturnProcessed = value; }
        }
        private DateTime m_ReturnProcessed;
    }
}
