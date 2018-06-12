using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class VehicleStatus
    {
        
        public int StatusId
        {
            get { return m_StatusId; }
            set { m_StatusId = value; }
        }
        private int m_StatusId;
        public string StatusDescription
        {
            get { return m_StatusDescription; }
            set { m_StatusDescription = value; }
        }
        private string m_StatusDescription;
    }
}