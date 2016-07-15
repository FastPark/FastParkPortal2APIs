using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class CardDistInventory
    {
        public int CardFPNumber
        {
            get { return m_CardFPNumber; }
            set { m_CardFPNumber = value; }
        }
        private int m_CardFPNumber;
    
    
        public int CardHistoryId
        {
            get { return m_CardHistoryId; }
            set { m_CardHistoryId = value; }
        }
        private int m_CardHistoryId;
    
        public int CardValidationNumber
        {
            get { return m_CardValidationNumber; }
            set { m_CardValidationNumber = value; }
        }
        private int m_CardValidationNumber;
    
        public int CardActive
        {
            get { return m_CardActive; }
            set { m_CardActive = value; }
        }
        private int m_CardActive;
    }
    
}