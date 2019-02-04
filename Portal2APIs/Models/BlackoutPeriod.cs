using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class BlackoutPeriod
    {
        public DateTime EffectiveDatetime
        {
            get { return m_EffectiveDatetime; }
            set { m_EffectiveDatetime = value; }
        }
        private DateTime m_EffectiveDatetime;
        public DateTime ExpiresDatetime
        {
            get { return m_ExpiresDatetime; }
            set { m_ExpiresDatetime = value; }
        }
        private DateTime m_ExpiresDatetime;
        public String DisplayName
        {
            get { return m_DisplayName; }
            set { m_DisplayName = value; }
        }
        private String m_DisplayName;
    }
}