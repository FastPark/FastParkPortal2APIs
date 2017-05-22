using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class Card
    {
        public Int64 CardId
        {
            get { return m_CardId; }
            set { m_CardId = value; }
        }
        private Int64 m_CardId;

        public Int64 MemberId
        {
            get { return m_MemberId; }
            set { m_MemberId = value; }
        }
        private Int64 m_MemberId;

        public Int64 SerialNumber
        {
            get { return m_SerialNumber; }
            set { m_SerialNumber = value; }
        }
        private Int64 m_SerialNumber;
        public String FPNumber
        {
            get { return m_FPNumber; }
            set { m_FPNumber = value; }
        }
        private String m_FPNumber;

        public int IsPrimary
        {
            get { return m_IsPrimary; }
            set { m_IsPrimary = value; }
        }
        private int m_IsPrimary;

        public int IsDeleted
        {
            get { return m_IsDeleted; }
            set { m_IsDeleted = value; }
        }
        private int m_IsDeleted;
        public int IsActive
        {
            get { return m_IsActive; }
            set { m_IsActive = value; }
        }
        private int m_IsActive;

        public DateTime CreateDatetime
        {
            get { return m_CreateDatetime; }
            set { m_CreateDatetime = value; }
        }
        private DateTime m_CreateDatetime;

        public DateTime UpdateDatetime
        {
            get { return m_UpdateDatetime; }
            set { m_UpdateDatetime = value; }
        }
        private DateTime m_UpdateDatetime;
    }
}