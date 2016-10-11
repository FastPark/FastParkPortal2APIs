using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class PendingManualEdit
    {
        public int ManualEditID
        {
            get { return m_ManualEditID; }
            set { m_ManualEditID = value; }
        }
        private int m_ManualEditID;

        public int MemberID
        {
            get { return m_MemberID; }
            set { m_MemberID = value; }
        }
        private int m_MemberID;

        public int LocationId
        {
            get { return m_LocationId; }
            set { m_LocationId = value; }
        }
        private int m_LocationId;

        public DateTime DateOfRequest
        {
            get { return m_DateOfRequest; }
            set { m_DateOfRequest = value; }
        }
        private DateTime m_DateOfRequest;

        public int AddedByUserId
        {
            get { return m_AddedByUserId; }
            set { m_AddedByUserId = value; }
        }
        private int m_AddedByUserId;

        public int ExplanationID
        {
            get { return m_ExplanationID; }
            set { m_ExplanationID = value; }
        }
        private int m_ExplanationID;

        public int Points
        {
            get { return m_Points; }
            set { m_Points = value; }
        }
        private int m_Points;

        public string CertificateNumber
        {
            get { return m_CertificateNumber; }
            set { m_CertificateNumber = value; }
        }
        private string m_CertificateNumber;

        public int Delivery
        {
            get { return m_Delivery; }
            set { m_Delivery = value; }
        }
        private int m_Delivery;
        public string FPNumber
        {
            get { return m_FPNumber; }
            set { m_FPNumber = value; }
        }
        private string m_FPNumber;
        public string FullName
        {
            get { return m_FullName; }
            set { m_FullName = value; }
        }
        private string m_FullName;
        public string Explanation
        {
            get { return m_Explanation; }
            set { m_Explanation = value; }
        }
        private string m_Explanation;
        public int CompanyId
        {
            get { return m_CompanyId; }
            set { m_CompanyId = value; }
        }
        private int m_CompanyId;
        public string Notes
        {
            get { return m_Notes; }
            set { m_Notes = value; }
        }
        private string m_Notes;
    }
}