using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class CardDistInventory
    {
        public int CardFPNumber
        {
            get { return m_CardFPNumber; }
            set { m_CardFPNumber = value; }
        }
        private int m_CardFPNumber;
    
    
        public int CardHistoryId
        {
            get { return m_CardHistoryId; }
            set { m_CardHistoryId = value; }
        }
        private int m_CardHistoryId;
    
        public int CardValidationNumber
        {
            get { return m_CardValidationNumber; }
            set { m_CardValidationNumber = value; }
        }
        private int m_CardValidationNumber;
    
        public int CardActive
        {
            get { return m_CardActive; }
            set { m_CardActive = value; }
        }
        private int m_CardActive; 

        public int orderedMax
        {
            get { return m_orderedMax; }
            set { m_orderedMax = value; }
        }
        private int m_orderedMax;

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