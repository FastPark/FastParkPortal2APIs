using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class CombineMemberCard
    {
        
        public string CombinedBy
        {
            get { return m_CombinedBy; }
            set { m_CombinedBy = value; }
        }
        private string m_CombinedBy;

        public string TargetCard
        {
            get { return m_TargetCard; }
            set { m_TargetCard = value; }
        }
        private string m_TargetCard;

        public string OriginCard
        {
            get { return m_OriginCard; }
            set { m_OriginCard = value; }
        }
        private string m_OriginCard;

    }
}