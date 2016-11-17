using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class CardDistActivityType
    {
        public int CardDistributionActivityTypeID
        {
            get { return m_CardDistributionActivityTypeID; }
            set { m_CardDistributionActivityTypeID = value; }
        }
        private int m_CardDistributionActivityTypeID;

        public string CardDistributionActivityDescription
        {
            get { return m_CardDistributionActivityDescription; }
            set { m_CardDistributionActivityDescription = value; }
        }
        private string m_CardDistributionActivityDescription;

        public string CardDistributionActivityRole
        {
            get { return m_CardDistributionActivityRole; }
            set { m_CardDistributionActivityRole = value; }
        }
        private string m_CardDistributionActivityRole;
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