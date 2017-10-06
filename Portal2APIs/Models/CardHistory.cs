using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class CardHistory
    {
        public string Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }
        private string m_Action;
        public DateTime ActivityDate
        {
            get { return m_ActivityDate; }
            set { m_ActivityDate = value; }
        }
        private DateTime m_ActivityDate;
        public string InitialUser
        {
            get { return m_InitialUser; }
            set { m_InitialUser = value; }
        }
        private string m_InitialUser;
        public long StartingCard
        {
            get { return m_StartingCard; }
            set { m_StartingCard = value; }
        }
        private long m_StartingCard;
        public long EndingCard
        {
            get { return m_EndingCard; }
            set { m_EndingCard = value; }
        }
        private long m_EndingCard;
        public DateTime ReceivedDate
        {
            get { return m_ReceivedDate; }
            set { m_ReceivedDate = value; }
        }
        private DateTime m_ReceivedDate;
        public string ReceiveUser
        {
            get { return m_ReceiveUser; }
            set { m_ReceiveUser = value; }
        }
        private string m_ReceiveUser;
        public string Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }
        private string m_Status;
        public string Location
        {
            get { return m_Location; }
            set { m_Location = value; }
        }
        private string m_Location;
        public int IsActive
        {
            get { return m_IsActive; }
            set { m_IsActive = value; }
        }
        private int m_IsActive;
    }

}