using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class MailerCodeSend
    {
        public string contact_email
        {
            get { return m_contact_email; }
            set { m_contact_email = value; }
        }
        private string m_contact_email;

        public string email_subject
        {
            get { return m_email_subject; }
            set { m_email_subject = value; }
        }
        private string m_email_subject;

        public string email_body
        {
            get { return m_email_body; }
            set { m_email_body = value; }
        }
        private string m_email_body;

        public DateTime created_at
        {
            get { return m_created_at; }
            set { m_created_at = value; }
        }
        private DateTime m_created_at;

        public DateTime updated_at
        {
            get { return m_updated_at; }
            set { m_updated_at = value; }
        }
        private DateTime m_updated_at;
    }
}