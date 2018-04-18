using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class MailerCode
    {
        public int flyer_id
        {
            get { return m_flyer_id; }
            set { m_flyer_id = value; }
        }
        private int m_flyer_id;

        public string promo_code
        {
            get { return m_promo_code; }
            set { m_promo_code = value; }
        }
        private string m_promo_code;

        public string FirstName
        {
            get { return m_FirstName; }
            set { m_FirstName = value; }
        }
        private string m_FirstName;

        public string LastName
        {
            get { return m_LastName; }
            set { m_LastName = value; }
        }
        private string m_LastName;

        public string rate_code
        {
            get { return m_rate_code; }
            set { m_rate_code = value; }
        }
        private string m_rate_code;

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

        public DateTime deleted_at
        {
            get { return m_deleted_at; }
            set { m_deleted_at = value; }
        }
        private DateTime m_deleted_at;

        public string CompanyName
        {
            get { return m_CompanyName; }
            set { m_CompanyName = value; }
        }
        private string m_CompanyName;

        public string ShortLocationName
        {
            get { return m_ShortLocationName; }
            set { m_ShortLocationName = value; }
        }
        private string m_ShortLocationName;
    }
}