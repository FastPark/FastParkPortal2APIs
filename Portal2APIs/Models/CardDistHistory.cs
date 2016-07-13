using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class CardDistHistory
    {
        public int CardHistoryId
        {
            get { return m_CardHistoryId; }
            set { m_CardHistoryId = value; }
        }
        private int m_CardHistoryId;

        public DateTime ActivityDate
        {
            get { return m_ActivityDate; }
            set { m_ActivityDate = value; }
        }
        private DateTime m_ActivityDate;

        public int ActivityId
        {
            get { return m_ActivityId; }
            set { m_ActivityId = value; }
        }
        private int m_ActivityId;

        public long StartingNumber
        {
            get { return m_SeriesStartingNumber; }
            set { m_SeriesStartingNumber = value; }
        }
        private long m_SeriesStartingNumber;

        public long EndingNumber
        {
            get { return m_SeriesEndingNumber; }
            set { m_SeriesEndingNumber = value; }
        }
        private long m_SeriesEndingNumber;

        public long NumberOfCards
        {
            get { return m_NumberOfCards; }
            set { m_NumberOfCards = value; }
        }
        private long m_NumberOfCards;

        public DateTime OrderConfirmationDate
        {
            get { return m_OrderConfirmationDate; }
            set { m_OrderConfirmationDate = value; }
        }
        private DateTime m_OrderConfirmationDate;

        public string DistributionPoint
        {
            get { return m_DistributionPoint; }
            set { m_DistributionPoint = value; }
        }
        private string m_DistributionPoint;

        public int BusOrRepID
        {
            get { return m_BusOrRepID; }
            set { m_BusOrRepID = value; }
        }
        private int m_BusOrRepID;

        public string Shift
        {
            get { return m_Shift; }
            set { m_Shift = value; }
        }
        private string m_Shift;

        public DateTime RecordDate
        {
            get { return m_RecordDate; }
            set { m_RecordDate = value; }
        }
        private DateTime m_RecordDate;

        public string RecordedBy
        {
            get { return m_RecordedBy; }
            set { m_RecordedBy = value; }
        }
        private string m_RecordedBy;
    }
}