using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Portal2APIs.Common;
using Portal2APIs.Models;

namespace Portal2APIs.Controllers
{
    public class AFPFieldInvoicesController : ApiController
    {
        [HttpPost]
        [Route("api/AFPFieldInvoices/SearchInvoices")]
        public List<AFPFieldInvoice> SearchInvoices(AFPFieldInvoice inv)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            var thisWhere = " where i.LocationId = " + inv.LocationId;

            if (inv.InvoiceNumber != null)
            {
                thisWhere = thisWhere + " and i.InvoiceNumber like '%" + inv.InvoiceNumber + "%'";
            }

            var pd = new DateTime(0001, 1, 1, 0, 0, 0);

            if (DateTime.Compare(inv.ProcessDate, pd) > 0)
            {

                thisWhere = thisWhere + " and Convert(nvarchar, i.ProcessDate, 101) = Convert(nvarchar, Cast('" + inv.ProcessDate + "' as datetime), 101)";
            }

            if (DateTime.Compare(inv.InvoiceDate, pd) > 0)
            {

                thisWhere = thisWhere + " and Convert(nvarchar, i.InvoiceDate, 101) = Convert(nvarchar, Cast('" + inv.InvoiceDate + "' as datetime), 101)";
            }

            if (inv.VendorID != null)
            {
                thisWhere = thisWhere + " and i.VendorID = " + inv.VendorID;
            }

            if (inv.InvoiceItem != null)
            {
                thisWhere = thisWhere + " and i.InvoiceItem like '%" + inv.InvoiceItem + "%'";
            }

            if (inv.ExpenseCategoryID != null)
            {
                thisWhere = thisWhere + " and i.ExpenseCategoryID = " + inv.ExpenseCategoryID;
            }


            try
            {
                
                    strSQL = "Select i.InvoiceID, i.ProcessDate, i.InvoiceDate, v.VendorName, i.InvoiceItem, i.InvoiceNumber, i.InvoiceAmount, i.Unit, ec.ExpenseCategory, Cast(i.VendorId as nvarchar) as VendorID, Cast(i.ExpenseCategoryID as nvarchar) as  ExpenseCategoryID " +
                        "from AFPExpenses.dbo.Invoice i " +
                        "Left Outer Join AFPExpenses.dbo.ExpenseCategory ec on i.ExpenseCategoryID = ec.ExpenseCategoryID " +
                        "Left Outer Join AFPExpenses.dbo.Vendor v on i.VendorID = v.VendorId " +
                        thisWhere + 
                        " order by InvoiceDate desc";

                    List<AFPFieldInvoice> list = new List<AFPFieldInvoice>();
                    thisADO.returnSingleValue(strSQL, false, ref list);

                    return list;

   
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message, System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.BadRequest
                };
                throw new HttpResponseException(response);
            }
        }

        [HttpGet]
        [Route("api/AFPFieldInvoices/GetInvoices/{id}")]
        public List<AFPFieldInvoice> GetSupportTicketsById(string id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "Select i.InvoiceID, i.ProcessDate, i.InvoiceDate, v.VendorName, i.InvoiceItem, i.InvoiceNumber, i.InvoiceAmount, i.Unit, ec.ExpenseCategory, Cast(i.VendorId as nvarchar) as VendorID, Cast(i.ExpenseCategoryID as nvarchar) as  ExpenseCategoryID " +
                        "from AFPExpenses.dbo.Invoice i " +
                        "Inner Join AFPExpenses.dbo.ExpenseCategory ec on i.ExpenseCategoryID = ec.ExpenseCategoryID " +
                        "Inner Join AFPExpenses.dbo.Vendor v on i.VendorID = v.VendorId " +
                        "Where i.LocationId = " + id + " order by InvoiceDate desc";

                List<AFPFieldInvoice> list = new List<AFPFieldInvoice>();
                thisADO.returnSingleValue(strSQL, false, ref list);

                return list;
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message, System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.BadRequest
                };
                throw new HttpResponseException(response);
            }
        }

        [HttpGet]
        [Route("api/AFPFieldInvoices/GetInvoicesByID/{id}")]
        public List<AFPFieldInvoice> GetInvoicesByID(string id)
        {
            try
            {

                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "Select i.InvoiceID, i.ProcessDate, i.InvoiceDate, v.VendorName, i.InvoiceItem, i.InvoiceNumber, i.InvoiceAmount, i.Unit, ec.ExpenseCategory, Cast(i.VendorId as nvarchar) as VendorID, Cast(i.ExpenseCategoryID as nvarchar) as  ExpenseCategoryID " +
                        "from AFPExpenses.dbo.Invoice i " +
                        "Left Outer Join AFPExpenses.dbo.ExpenseCategory ec on i.ExpenseCategoryID = ec.ExpenseCategoryID " +
                        "Left Outer Join AFPExpenses.dbo.Vendor v on i.VendorID = v.VendorID " +
                        "Where i.InvoiceID = " + id;

                List<AFPFieldInvoice> list = new List<AFPFieldInvoice>();
                thisADO.returnSingleValue(strSQL, false, ref list);

                return list;
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message, System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.BadRequest
                };
                throw new HttpResponseException(response);
            }
        }

        [HttpGet]
        [Route("api/AFPFieldInvoices/GetInvoicesByNumber/{id}")]
        public List<AFPFieldInvoice> GetInvoicesByNumber(string id)
        {
            try
            {
                id = id.Replace(@"~", "/");

                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "Select i.InvoiceID, i.ProcessDate, i.InvoiceDate, v.VendorName, i.InvoiceItem, i.InvoiceNumber, i.InvoiceAmount, i.Unit, ec.ExpenseCategory, Cast(i.VendorId as nvarchar) as VendorID, Cast(i.ExpenseCategoryID as nvarchar) as  ExpenseCategoryID " +
                        "from AFPExpenses.dbo.Invoice i " +
                        "Inner Join AFPExpenses.dbo.ExpenseCategory ec on i.ExpenseCategoryID = ec.ExpenseCategoryID " +
                        "Inner Join AFPExpenses.dbo.Vendor v on i.VendorID = v.VendorID " +
                        "Where i.InvoiceNumber = '" + id + "'";

                List<AFPFieldInvoice> list = new List<AFPFieldInvoice>();
                thisADO.returnSingleValue(strSQL, false, ref list);

                return list;
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message, System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.BadRequest
                };
                throw new HttpResponseException(response);
            }
        }

        [HttpPost]
        [Route("api/AFPFieldInvoices/PUTInvoice")]
        public string PUTInvoice(AFPFieldInvoice I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {

                strSQL = "Update AFPExpenses.dbo.Invoice set ProcessDate = '" + I.ProcessDate + "', InvoiceDate = '" + I.InvoiceDate + "', VendorID = '" + I.VendorID + "', InvoiceItem = '" + I.InvoiceItem + "', " +
                         "Unit = '" + I.Unit + "', InvoiceNumber = '" + I.InvoiceNumber + "', InvoiceAmount = '" + I.InvoiceAmount + "', ExpenseCategoryID = '" + I.ExpenseCategoryID + "', LocationId = " + I.LocationId + " " +
                         "where InvoiceId = " + I.InvoiceID;
                         

                thisADO.updateOrInsert(strSQL, false);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [HttpPost]
        [Route("api/AFPFieldInvoices/PostInvoice")]
        public string PostInvoice(AFPFieldInvoice I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {

                strSQL = "INSERT INTO AFPExpenses.dbo.Invoice (ProcessDate, InvoiceDate, VendorID, InvoiceItem, Unit, InvoiceNumber, InvoiceAmount, ExpenseCategoryID, LocationId) " +
                         "Values ('" + I.ProcessDate + "', '" + I.InvoiceDate + "', '" + I.VendorID + "', '" + I.InvoiceItem + "', '" + I.Unit + "', '" + I.InvoiceNumber + "', '" + I.InvoiceAmount + "', '" + I.ExpenseCategoryID + "', " + I.LocationId + ")";

                thisADO.updateOrInsert(strSQL, false);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [HttpGet]
        [Route("api/AFPFieldInvoices/GetVendors/{id}")]
        public List<AFPFieldInvoice> GetVendors(string id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "Select Cast(VendorID as nvarchar) as VendorID, VendorName " +
                        "from AFPExpenses.dbo.Vendor " +
                        "where locationId = " + id + " " +
                        "order by VendorName ";

                List<AFPFieldInvoice> list = new List<AFPFieldInvoice>();
                thisADO.returnSingleValue(strSQL, false, ref list);

                return list;
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message, System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.BadRequest
                };
                throw new HttpResponseException(response);
            }
        }

        [HttpGet]
        [Route("api/AFPFieldInvoices/GetCategories/")]
        public List<AFPFieldInvoice> GetCategories()
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "Select Cast(ExpenseCategoryID as nvarchar) as ExpenseCategoryID, ExpenseCategory from AFPExpenses.dbo.ExpenseCategory order by ExpenseCategory";

                List<AFPFieldInvoice> list = new List<AFPFieldInvoice>();
                thisADO.returnSingleValue(strSQL, false, ref list);

                return list;
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message, System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.BadRequest
                };
                throw new HttpResponseException(response);
            }
        }

        [HttpPost]
        [Route("api/AFPFieldInvoices/InsertVendor")]
        public string InsertVendor(InvoiceVendor v)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {

                strSQL = "INSERT INTO AFPExpenses.dbo.Vendor (Vendorname, LocationId) " +
                         "Values ('" + v.VendorName + "', " + v.LocationId + ")";

                thisADO.updateOrInsert(strSQL, false);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [HttpGet]
        [Route("api/AFPFieldInvoices/DeleteInvoice/{id}")]
        public string DeleteInvoice(int id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "Delete from AFPExpenses.dbo.Invoice where InvoiceID = " + id;
                
                thisADO.updateOrInsert(strSQL, false);

                return "Success";
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message, System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.BadRequest
                };
                throw new HttpResponseException(response);
            }
        }
    }
}
