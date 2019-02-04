using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class AFPFieldInvoice
    {

        #region Constructors
        public AFPFieldInvoice()
        {
        }
        #endregion
        #region Private Fields
        private int _InvoiceID;
        private DateTime _ProcessDate;
        private DateTime _InvoiceDate;
        private string _VendorID;
        private string _VendorName;
        private string _InvoiceItem;
        private string _Unit;
        private string _InvoiceNumber;
        private string _InvoiceAmount;
        private string _ExpenseCategoryID;
        private string _ExpenseCategory;
        private int _LocationId;
        #endregion
        #region Public Properties
        public int InvoiceID
        {
            get { return _InvoiceID; }
            set { _InvoiceID = value; }
        }
        public DateTime ProcessDate
        {
            get { return _ProcessDate; }
            set { _ProcessDate = value; }
        }
        public DateTime InvoiceDate
        {
            get { return _InvoiceDate; }
            set { _InvoiceDate = value; }
        }
        public string VendorID
        {
            get { return _VendorID; }
            set { _VendorID = value; }
        }

        public string VendorName
        {
            get { return _VendorName; }
            set { _VendorName = value; }
        }
        public string InvoiceItem
        {
            get { return _InvoiceItem; }
            set { _InvoiceItem = value; }
        }
        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        public string InvoiceNumber
        {
            get { return _InvoiceNumber; }
            set { _InvoiceNumber = value; }
        }
        public string InvoiceAmount
        {
            get { return _InvoiceAmount; }
            set { _InvoiceAmount = value; }
        }
        public string ExpenseCategoryID
        {
            get { return _ExpenseCategoryID; }
            set { _ExpenseCategoryID = value; }
        }

        public string ExpenseCategory
        {
            get { return _ExpenseCategory; }
            set { _ExpenseCategory = value; }
        }
        public int LocationId
        {
            get { return _LocationId; }
            set { _LocationId = value; }
        }
        #endregion
    }
}