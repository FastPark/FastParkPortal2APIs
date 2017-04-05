using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class MarketingCodeSave
    {
        public Int64 MemberId
        {
            get { return m_MemberId; }
            set { m_MemberId = value; }
        }
        private Int64 m_MemberId;

        public string MarketingCode
        {
            get { return m_MarketingCode; }
            set { m_MarketingCode = value; }
        }
        private string m_MarketingCode;

        public string OldMarketingCode
        {
            get { return m_OldMarketingCode; }
            set { m_OldMarketingCode = value; }
        }
        private string m_OldMarketingCode;

        public string ChangedBy
        {
            get { return m_ChangedBy; }
            set { m_ChangedBy = value; }
        }
        private string m_ChangedBy;
    }
}