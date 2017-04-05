using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class ReservationReport
    {
        public DateTime StartDate
        {
            get { return m_StartDate; }
            set { m_StartDate = value; }
        }
        private DateTime m_StartDate;
        public DateTime EndDate
        {
            get { return m_EndDate; }
            set { m_EndDate = value; }
        }
        private DateTime m_EndDate;

        public int startsCount
        {
            get { return m_startsCount; }
            set { m_startsCount = value; }
        }
        private int m_startsCount;

        public int endsCount
        {
            get { return m_endsCount; }
            set { m_endsCount = value; }
        }
        private int m_endsCount;

        public string DayName
        {
            get { return m_DayName; }
            set { m_DayName = value; }
        }
        private string m_DayName;
    }
}