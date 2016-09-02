using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class ManualEdit
    {
        public int ManualEditId
        {
            get { return m_ManualEditId; }
            set { m_ManualEditId = value; }
        }
        private int m_ManualEditId;

        public int MemberId
        {
            get { return m_MemberId; }
            set { m_MemberId = value; }
        }
        private int m_MemberId;

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

        public DateTime SubMittedDate
        {
            get { return m_SubMittedDate; }
            set { m_SubMittedDate = value; }
        }
        private DateTime m_SubMittedDate;

        public int PerformedBy
        {
            get { return m_PerformedBy; }
            set { m_PerformedBy = value; }
        }
        private int m_PerformedBy;

        public int SubmittedBy
        {
            get { return m_SubmittedBy; }
            set { m_SubmittedBy = value; }
        }
        private int m_SubmittedBy;

        public int ExplanationId
        {
            get { return m_ExplanationId; }
            set { m_ExplanationId = value; }
        }
        private int m_ExplanationId;

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

        public Guid PerformedByUserId
        {
            get { return m_PerformedByUserId; }
            set { m_PerformedByUserId = value; }
        }
        private Guid m_PerformedByUserId;

        public Guid SubmittedByUserId
        {
            get { return m_SubmittedByUserId; }
            set { m_SubmittedByUserId = value; }
        }
        private Guid m_SubmittedByUserId;

    }
}