using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class CombineCompany
    {
        public int id
        {
            get { return m_id; }
            set { m_id = value; }
        }
        private int m_id;
        public string name 
        {
            get { return m_name; }
            set { m_name = value; }
        }
        private string m_name;
        public string address_1
        {
            get { return m_address_1; }
            set { m_address_1 = value; }
        }
        private string m_address_1;
        public string city
        {
            get { return m_city; }
            set { m_city = value; }
        }
        private string m_city;
        public string state
        {
            get { return m_state; }
            set { m_state = value; }
        }
        private string m_state;
        public string zip
        {
            get { return m_zip; }
            set { m_zip = value; }
        }
        private string m_zip;
        public int home_rate_code
        {
            get { return m_home_rate_code; }
            set { m_home_rate_code = value; }
        }
        private int m_home_rate_code;
        public int away_rate_code
        {
            get { return m_away_rate_code; }
            set { m_away_rate_code = value; }
        }
        private int m_away_rate_code;
        public int members
        {
            get { return m_members; }
            set { m_members = value; }
        }
        private int m_members;
        public int activity
        {
            get { return m_activity; }
            set { m_activity = value; }
        }
        private int m_activity;
        public int manual_edits
        {
            get { return m_manual_edits; }
            set { m_manual_edits = value; }
        }
        private int m_manual_edits;
        public int mailer_rates
        {
            get { return m_mailer_rates; }
            set { m_mailer_rates = value; }
        }
        private int m_mailer_rates;
        public int contacts
        {
            get { return m_contacts; }
            set { m_contacts = value; }
        }
        private int m_contacts;
        public int flyers
        {
            get { return m_flyers; }
            set { m_flyers = value; }
        }
        private int m_flyers;
        public string website
        {
            get { return m_website; }
            set { m_website = value; }
        }
        private string m_website;
    }
}