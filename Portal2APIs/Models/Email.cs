using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class Email
    {
        public string ToEmailAddress
        {
            get { return m_ToEmailAddress; }
            set { m_ToEmailAddress = value; }
        }
        private string m_ToEmailAddress;

        public string FromEmailAddress
        {
            get { return m_FromEmailAddress; }
            set { m_FromEmailAddress = value; }
        }
        private string m_FromEmailAddress;

        public string Body
        {
            get { return m_Body; }
            set { m_Body = value; }
        }
        private string m_Body;

        public string Subject
        {
            get { return m_Subject; }
            set { m_Subject = value; }
        }
        private string m_Subject;
    }
}