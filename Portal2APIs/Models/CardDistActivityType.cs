using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class CardDistActivityType
    {
        public int CardDistributionActivityTypeID
        {
            get { return m_CardDistributionActivityTypeID; }
            set { m_CardDistributionActivityTypeID = value; }
        }
        private int m_CardDistributionActivityTypeID;

        public string CardDistributionActivityDescription
        {
            get { return m_CardDistributionActivityDescription; }
            set { m_CardDistributionActivityDescription = value; }
        }
        private string m_CardDistributionActivityDescription;

        public string CardDistributionActivityRole
        {
            get { return m_CardDistributionActivityRole; }
            set { m_CardDistributionActivityRole = value; }
        }
        private string m_CardDistributionActivityRole;
    }
}