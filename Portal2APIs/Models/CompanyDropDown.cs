using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class CompanyDropDown
    {
        public int id
        {
            get { return m_id; }
            set { m_id = value; }
        }
        private int m_id;

        public string name
        {
            get { return m_name; }
            set { m_name = value; }
        }
        private string m_name;
    }
}