using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class Rate
    {
        public int CompanyId
        {
            get { return m_CompanyId; }
            set { m_CompanyId = value; }
        }
        private int m_CompanyId;
        public int LocationId
        {
            get { return m_LocationId; }
            set { m_LocationId = value; }
        }
        private int m_LocationId;
        public string Designation
        {
            get { return m_Designation; }
            set { m_Designation = value; }
        }
        private string m_Designation;
        public decimal RateAmount
        {
            get { return m_Rate; }
            set { m_Rate = value; }
        }
        private decimal m_Rate;
        public string ShortLocationName
        {
            get { return m_ShortLocationName; }
            set { m_ShortLocationName = value; }
        }
        private string m_ShortLocationName;
    }
}