using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class Location
    {
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

        public string ShortLocationName
        {
            get { return m_ShortLocationName; }
            set { m_ShortLocationName = value; }
        }
        private string m_ShortLocationName;

        public int AirportId
        {
            get { return m_AirportId; }
            set { m_AirportId = value; }
        }
        private int m_AirportId;
    }
}