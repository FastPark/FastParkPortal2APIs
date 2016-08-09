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

        public int BusOrRepId
        {
            get { return m_BusOrRepId; }
            set { m_BusOrRepId = value; }
        }
        private int m_BusOrRepId;

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
        private String m_NameOfLocation;
        public long maxShipped
        {
            get { return m_maxShipped; }
            set { m_maxShipped = value; }
        }
        private long m_maxShipped;
        public string CardDistributionActivityDescription
        {
            get { return m_CardDistributionActivityDescription; }
            set { m_CardDistributionActivityDescription = value; }
        }
        private String m_CardDistributionActivityDescription; 

    }
}