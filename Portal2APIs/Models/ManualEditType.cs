using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class ManualEditType
    {
        public int ExplanationID
        {
            get { return m_ExplanationID; }
            set { m_ExplanationID = value; }
        }
        private int m_ExplanationID;

        public string Explanation
        {
            get { return m_Explanation; }
            set { m_Explanation = value; }
        }
        private string m_Explanation;
    }
}