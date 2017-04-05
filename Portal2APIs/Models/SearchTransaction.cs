using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class SearchTransaction
    {
        public DateTime EntryDate
        {
            get { return m_EntryDate; }
            set { m_EntryDate = value; }
        }
        private DateTime m_EntryDate;
        public DateTime ExitDate
        {
            get { return m_ExitDate; }
            set { m_ExitDate = value; }
        }
        private DateTime m_ExitDate;
        public DateTime DateTimeOfTransaction
        {
            get { return m_DateTimeOfTransaction; }
            set { m_DateTimeOfTransaction = value; }
        }
        private DateTime m_DateTimeOfTransaction;
        public Int64 MemberId
        {
            get { return m_MemberId; }
            set { m_MemberId = value; }
        }
        private Int64 m_MemberId;
        public decimal AmountPaid
        {
            get { return m_AmountPaid; }
            set { m_AmountPaid = value; }
        }
        private decimal m_AmountPaid;

        public string FPNumber
        {
            get { return m_FPNumber; }
            set { m_FPNumber = value; }
        }
        private string m_FPNumber;
        public string Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }
        private string m_Status;

        public string ReceiptNumber
        {
            get { return m_ReceiptNumber; }
            set { m_ReceiptNumber = value; }
        }
        private string m_ReceiptNumber;
        public string ColumnNumber
        {
            get { return m_ColumnNumber; }
            set { m_ColumnNumber = value; }
        }
        private string m_ColumnNumber;
        public string ShortTermNumber
        {
            get { return m_ShortTermNumber; }
            set { m_ShortTermNumber = value; }
        }
        private string m_ShortTermNumber;
        public int LocationId
        {
            get { return m_LocationId; }
            set { m_LocationId = value; }
        }
        private int m_LocationId;

        public Boolean Archive
        {
            get { return m_Archive; }
            set { m_Archive = value; }
        }
        private Boolean m_Archive;

        public string FirstName
        {
            get { return m_FirstName; }
            set { m_FirstName = value; }
        }
        private string m_FirstName;

        public string LastName
        {
            get { return m_LastName; }
            set { m_LastName = value; }
        }
        private string m_LastName;


    }
}