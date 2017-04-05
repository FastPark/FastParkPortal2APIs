using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class PendingReceipt
    {
        public byte thisSelect
        {
            get { return m_thisSelect; }
            set { m_thisSelect = value; }
        }
        private byte m_thisSelect;
        public int PendingReceiptId
        {
            get { return m_PendingReceiptId; }
            set { m_PendingReceiptId = value; }
        }
        private int m_PendingReceiptId;
        public string memberName
        {
            get { return m_memberName; }
            set { m_memberName = value; }
        }
        private string m_memberName;
        public string ReceiptNumber
        {
            get { return m_ReceiptNumber; }
            set { m_ReceiptNumber = value; }
        }
        private string m_ReceiptNumber;
        public string UpdateExternalUserData
        {
            get { return m_UpdateExternalUserData; }
            set { m_UpdateExternalUserData = value; }
        }
        private string m_UpdateExternalUserData;
        public DateTime EntryDate
        {
            get { return m_EntryDate; }
            set { m_EntryDate = value; }
        }
        private DateTime m_EntryDate;

        public DateTime SubmittedDate
        {
            get { return m_SubmittedDate; }
            set { m_SubmittedDate = value; }
        }
        private DateTime m_SubmittedDate;
        public DateTime LocationID
        {
            get { return m_LocationID; }
            set { m_LocationID = value; }
        }
        private DateTime m_LocationID;
    }
}