using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class VehiclePart
    {

        #region Constructors
        public VehiclePart()
        {
        }
        #endregion
        #region Private Fields
        private int _PartId;
        private int _ModelId;
        private int _PartCategoryId;
        private int _FuelTypeId;
        private string _PartName;
        private string _PartModel;
        private string _PartManufacturer;
        private string _PartDescription;
        private int _Stockable;
        private object _EnteredByUserId;
        private DateTime _DateTimeEntered;
        #endregion
        #region Public Properties
        public int PartId
        {
            get { return _PartId; }
            set { _PartId = value; }
        }
        public int ModelId
        {
            get { return _ModelId; }
            set { _ModelId = value; }
        }
        public int PartCategoryId
        {
            get { return _PartCategoryId; }
            set { _PartCategoryId = value; }
        }
        public int FuelTypeId
        {
            get { return _FuelTypeId; }
            set { _FuelTypeId = value; }
        }
        public string PartName
        {
            get { return _PartName; }
            set { _PartName = value; }
        }
        public string PartModel
        {
            get { return _PartModel; }
            set { _PartModel = value; }
        }
        public string PartManufacturer
        {
            get { return _PartManufacturer; }
            set { _PartManufacturer = value; }
        }
        public string PartDescription
        {
            get { return _PartDescription; }
            set { _PartDescription = value; }
        }
        public int Stockable
        {
            get { return _Stockable; }
            set { _Stockable = value; }
        }
        public object EnteredByUserId
        {
            get { return _EnteredByUserId; }
            set { _EnteredByUserId = value; }
        }
        public DateTime DateTimeEntered
        {
            get { return _DateTimeEntered; }
            set { _DateTimeEntered = value; }
        }
        #endregion
    }
}