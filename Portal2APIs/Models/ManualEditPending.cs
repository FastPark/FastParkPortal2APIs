using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class ManualEditPending
    {
        public int Points
        {
            get { return m_Points; }
            set { m_Points = value; }
        }
        private int m_Points;

        public int LocationId
        {
            get { return m_LocationId; }
            set { m_LocationId = value; }
        }
        private int m_LocationId;

        public int MemberId
        {
            get { return m_MemberId; }
            set { m_MemberId = value; }
        }
        private int m_MemberId;

        public DateTime DateOfRequest
        {
            get { return m_DateOfRequest; }
            set { m_DateOfRequest = value; }
        }
        private DateTime m_DateOfRequest;

        private int m_ExplanationId;

        public string CertificateNumber
        {
            get { return m_CertificateNumber; }
            set { m_CertificateNumber = value; }
        }
        private string m_CertificateNumber;
        public int ManualEditId
        {
            get { return m_ManualEditId; }
            set { m_ManualEditId = value; }
        }
        private int m_ManualEditId;

        public int ExplanationID
        {
            get { return m_ExplanationID; }
            set { m_ExplanationID = value; }
        }
        private int m_ExplanationID;
         
        public string Notes
        {
            get { return m_Notes; }
            set { m_Notes = value; }
        }
        private string m_Notes;

        public Guid AddedByUserId
        {
            get { return m_AddedByUserId; }
            set { m_AddedByUserId = value; }
        }
        private Guid m_AddedByUserId;

        public int CompanyId
        {
            get { return m_CompanyId; }
            set { m_CompanyId = value; }
        }
        private int m_CompanyId;
        public DateTime CreateDatetime
        {
            get { return m_CreateDatetime; }
            set { m_CreateDatetime = value; }
        }
        private DateTime m_CreateDatetime;

        public int CreateUserId
        {
            get { return m_CreateUserId; }
            set { m_CreateUserId = value; }
        }
        private int m_CreateUserId;
        public DateTime UpdateDatetime
        {
            get { return m_UpdateDatetime; }
            set { m_UpdateDatetime = value; }
        }
        private DateTime m_UpdateDatetime;
        public int UpdateUserId
        {
            get { return m_UpdateUserId; }
            set { m_UpdateUserId = value; }
        }
        private int m_UpdateUserId;
        public Boolean IsDeleted
        {
            get { return m_IsDeleted; }
            set { m_IsDeleted = value; }
        }
        private Boolean m_IsDeleted;
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