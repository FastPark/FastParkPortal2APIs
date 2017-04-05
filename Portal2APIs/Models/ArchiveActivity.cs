using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class ArchiveActivity
    {
        public string ParkingTransactionNumber
        {
            get { return m_ParkingTransactionNumber; }
            set { m_ParkingTransactionNumber = value; }
        }
        private string m_ParkingTransactionNumber;

        public Int64 ManualEditId
        {
            get { return m_ManualEditId; }
            set { m_ManualEditId = value; }
        }
        private Int64 m_ManualEditId;

        public int PointsChanged
        {
            get { return m_PointsChanged; }
            set { m_PointsChanged = value; }
        }
        private int m_PointsChanged;

        public DateTime ManualEditDate
        {
            get { return m_ManualEditDate; }
            set { m_ManualEditDate = value; }
        }
        private DateTime m_ManualEditDate;

        public DateTime DateTimeOfEntry
        {
            get { return m_DateTimeOfEntry; }
            set { m_DateTimeOfEntry = value; }
        }
        private DateTime m_DateTimeOfEntry;

        public DateTime DateTimeOfExit
        {
            get { return m_DateTimeOfExit; }
            set { m_DateTimeOfExit = value; }
        }
        private DateTime m_DateTimeOfExit;

        public string Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }
        private string m_Description;

        public string ActivityType
        {
            get { return m_ActivityType; }
            set { m_ActivityType = value; }
        }
        private string m_ActivityType;

        public DateTime OrderColumn
        {
            get { return m_OrderColumn; }
            set { m_OrderColumn = value; }
        }
        private DateTime m_OrderColumn;
    }
}