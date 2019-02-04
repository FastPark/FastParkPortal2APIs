using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class MaintenancePackagePart
    {
        public int PartId
        {
            get { return m_PartId; }
            set { m_PartId = value; }
        }
        private int m_PartId;
        public string PartDescription
        {
            get { return m_PartDescription; }
            set { m_PartDescription = value; }
        }
        private string m_PartDescription;
        public string PartModel
        {
            get { return m_PartModel; }
            set { m_PartModel = value; }
        }
        private string m_PartModel;
        public int Quantity
        {
            get { return m_Quantity; }
            set { m_Quantity = value; }
        }
        private int m_Quantity;
        public decimal UnitPrice
        {
            get { return m_UnitPrice; }
            set { m_UnitPrice = value; }
        }
        private decimal m_UnitPrice;
        public string PartManufacturer
        {
            get { return m_PartManufacturer; }
            set { m_PartManufacturer = value; }
        }
        private string m_PartManufacturer;
        public decimal Tax
        {
            get { return m_Tax; }
            set { m_Tax = value; }
        }
        private decimal m_Tax;
        public decimal Labor
        {
            get { return m_Labor; }
            set { m_Labor = value; }
        }
        private decimal m_Labor;
    }
}