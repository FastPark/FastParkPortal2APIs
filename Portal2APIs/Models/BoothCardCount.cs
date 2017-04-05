using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class BoothCardCount
    {
        public int BoothCardCountId
        {
            get { return m_BoothCardCountId; }
            set { m_BoothCardCountId = value; }
        }
        private int m_BoothCardCountId;
        public int Shift1
        {
            get { return m_Shift1; }
            set { m_Shift1 = value; }
        }
        private int m_Shift1;
        public int Shift2
        {
            get { return m_Shift2; }
            set { m_Shift2 = value; }
        }
        private int m_Shift2;
        public int Shift3
        {
            get { return m_Shift3; }
            set { m_Shift3 = value; }
        }
        private int m_Shift3;
        public int Total
        {
            get { return m_Total; }
            set { m_Total = value; }
        }
        private int m_Total;

        public DateTime BoothCardCountDate
        {
            get { return m_BoothCardCountDate; }
            set { m_BoothCardCountDate = value; }
        }
        private DateTime m_BoothCardCountDate;

        public int LocationId
        {
            get { return m_LocationId; }
            set { m_LocationId = value; }
        }
        private int m_LocationId;

        public string NameOfLocation
        {
            get { return m_NameOfLocation; }
            set { m_NameOfLocation = value; }
        }
        private string m_NameOfLocation;
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