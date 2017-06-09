using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class ManualEdit
    {
        public Int64 ManualEditId
        {
            get { return m_ManualEditId; }
            set { m_ManualEditId = value; }
        }
        private Int64 m_ManualEditId;

        public Int64 MemberId
        {
            get { return m_MemberId; }
            set { m_MemberId = value; }
        }
        private Int64 m_MemberId;

        public int LocationId
        {
            get { return m_LocationId; }
            set { m_LocationId = value; }
        }
        private int m_LocationId;

        public DateTime ManualEditDate
        {
            get { return m_ManualEditDate; }
            set { m_ManualEditDate = value; }
        }
        private DateTime m_ManualEditDate;

        public DateTime SubmittedDate
        {
            get { return m_SubmittedDate; }
            set { m_SubmittedDate = value; }
        }
        private DateTime m_SubmittedDate;

        public string PerformedBy
        {
            get { return m_PerformedBy; }
            set { m_PerformedBy = value; }
        }
        private string m_PerformedBy;

        public string SubmittedBy
        {
            get { return m_SubmittedBy; }
            set { m_SubmittedBy = value; }
        }
        private string m_SubmittedBy;

        public int ExplanationId
        {
            get { return m_ExplanationId; }
            set { m_ExplanationId = value; }
        }
        private int m_ExplanationId;
        public string Explanation
        {
            get { return m_Explanation; }
            set { m_Explanation = value; }
        }
        private string m_Explanation;

        public int PointsChanged
        {
            get { return m_PointsChanged; }
            set { m_PointsChanged = value; }
        }
        private int m_PointsChanged;

        public string CertificateNumber
        {
            get { return m_CertificateNumber; }
            set { m_CertificateNumber = value; }
        }
        private string m_CertificateNumber;

        public string ParkingTransactionNumber
        {
            get { return m_ParkingTransactionNumber; }
            set { m_ParkingTransactionNumber = value; }
        }
        private string m_ParkingTransactionNumber;

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

        public string PerformedByUserId
        {
            get { return m_PerformedByUserId; }
            set { m_PerformedByUserId = value; }
        }
        private string m_PerformedByUserId;

        public string SubmittedByUserId
        {
            get { return m_SubmittedByUserId; }
            set { m_SubmittedByUserId = value; }
        }
        private string m_SubmittedByUserId;


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
        public byte IsDeleted
        {
            get { return m_IsDeleted; }
            set { m_IsDeleted = value; }
        }
        private byte m_IsDeleted;
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