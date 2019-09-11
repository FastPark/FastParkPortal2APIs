using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class VehicleMaintenancePart
    {

        public VehicleMaintenancePart()
        {
        }
        #region Private Fields
        private int _VehicleMaintenanceId;
        private string _PartDescription;
        private int _PartId;
        private object _UnitPrice;
        private int _Quantity;
        private bool _PreventatitiveMaintenance;
        private int _PartSupplierId;
        private string _InvoiceNumber;
        private string _PartSupplierName;
        private string _Warranty;
        private object _Labor;
        private object _Tax;
        private int _ModelId;
        private int _FuelTypeId;
        private string _PartModel;
        #endregion
        #region Public Properties
        public int VehicleMaintenanceId
        {
            get { return _VehicleMaintenanceId; }
            set { _VehicleMaintenanceId = value; }
        }
        public int PartId
        {
            get { return _PartId; }
            set { _PartId = value; }
        }
        public string PartDescription
        {
            get { return _PartDescription; }
            set { _PartDescription = value; }
        }
        public object UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }
        public int Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        public bool PreventatitiveMaintenance
        {
            get { return _PreventatitiveMaintenance; }
            set { _PreventatitiveMaintenance = value; }
        }
        public int PartSupplierId
        {
            get { return _PartSupplierId; }
            set { _PartSupplierId = value; }
        }
        public string InvoiceNumber
        {
            get { return _InvoiceNumber; }
            set { _InvoiceNumber = value; }
        }
        public string Warranty
        {
            get { return _Warranty; }
            set { _Warranty = value; }
        }
        public object Labor
        {
            get { return _Labor; }
            set { _Labor = value; }
        }
        public object Tax
        {
            get { return _Tax; }
            set { _Tax = value; }
        }
        public int ModelId
        {
            get { return _ModelId; }
            set { _ModelId = value; }
        }
        public int FuelTypeId
        {
            get { return _FuelTypeId; }
            set { _FuelTypeId = value; }
        }
        public string PartSupplierName
        {
            get { return _PartSupplierName; }
            set { _PartSupplierName = value; }
        }
        public string PartModel
        {
            get { return _PartModel; }
            set { _PartModel = value; }
        }
        #endregion
    }
}