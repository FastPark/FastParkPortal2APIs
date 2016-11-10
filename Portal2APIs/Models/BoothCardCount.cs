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
    }
}