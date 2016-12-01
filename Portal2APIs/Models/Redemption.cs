using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class Redemption
    {
        public int RedemptionId
        {
            get { return m_RedemptionId; }
            set { m_RedemptionId = value; }
        }
        private int m_RedemptionId;

        public string UpdateExternalUserData
        {
            get { return m_UpdateExternalUserData; }
            set { m_UpdateExternalUserData = value; }
        }
        private string m_UpdateExternalUserData;
    }
}