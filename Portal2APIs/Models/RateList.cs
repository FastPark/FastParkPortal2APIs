using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class RateList
    {
        public string RateDisplay
        {
            get { return m_RateDisplay; }
            set { m_RateDisplay = value; }
        }
        private string m_RateDisplay;
        public int LocationId
        {
            get { return m_LocationId; }
            set { m_LocationId = value; }
        }
        private int m_LocationId;
    }
}