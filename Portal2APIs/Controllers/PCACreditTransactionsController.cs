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
    public class PCACreditTransactionsController : ApiController
    {
        [HttpPost()]
        [Route("api/PCACreditTransactions/GetCreditTransactions/")]
        public List<PCACreditTransaction> GetCreditTransactions(PCACreditTransaction trans)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            var thisWhere = "";

            thisWhere = " Where ct.CreditTransactionTypeId = 6";

            if (trans.FirstName != null)
            {
                thisWhere = " And u.FirstName = '" + trans.FirstName + "'";
            }

            if (trans.LastName != null)
            {
               thisWhere = thisWhere + " and mi.LastName like '" + trans.LastName + "%'";
            }

            if (trans.Company != null)
            {
                thisWhere = thisWhere + " and mi.Company like '" + trans.Company + "%'";
            }

            if (trans.InvoiceNumber != null)
            {
                thisWhere = thisWhere + " and ct.InvoiceNumber = '" + trans.InvoiceNumber + "'";
            }

            try
            {
                strSQL = "Select  ct.CreditTransactionId, Cast(ct.AuthoriseAmount/Cast(100 as decimal) as decimal (10,2)) as AuthoriseAmount,  Cast(ct.CaptureAmount/Cast(100 as decimal) as decimal (10,2)) as CaptureAmount, ct.LocalCreateDatetime, ct.CheckNumber, ct.InvoiceNumber, ct.UpdateDatetime " +
                        "From ParkPlaceParking.dbo.CreditTransaction ct " +
                        "Inner Join(Select * from( " +
                                        "Select ROW_NUMBER() OVER(PARTITION by CreditTransactionID Order by PermitId Desc) as RowNum, " +
                                                "CreditTransactionId, PermitId " +
                                         "from ParkPlaceParking.dbo.Payment " +
                                    ") Payment " +
                                    "Where RowNum = 1) as pay on ct.CreditTransactionId = pay.CreditTransactionId " +
                        "Inner Join ParkPlaceParking.dbo.Permit p on pay.PermitId = p.PermitId " +
                        "Inner Join ParkPlaceParking.dbo.[User] u on p.UserId = u.UserId " +
                        thisWhere;

                List<PCACreditTransaction> list = new List<PCACreditTransaction>();
                thisADO.returnSingleValue(strSQL, true, ref list);

                return list; ;
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
        [Route("api/PCACreditTransactions/UpdateCreditTransaction/")]
        public string UpdateCreditTransaction(PCACreditTransaction trans)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "Select CheckNumber From ParkPlaceParking.dbo.CreditTransaction where CreditTransactionId = " + trans.CreditTransactionId;
                
                string CheckCheck = thisADO.returnSingleValueForInternalAPIUse(strSQL, true);

                if (trans.CheckNumber == null)
                {
                    strSQL = "Update ParkPlaceParking.dbo.CreditTransaction Set CheckNumber = '" + trans.CheckNumber + "', UpdateDatetime = Null Where CreditTransactionId = " + trans.CreditTransactionId;
                }
                else if (CheckCheck == "")
                {
                    strSQL = "Update ParkPlaceParking.dbo.CreditTransaction Set CheckNumber = '" + trans.CheckNumber + "', UpdateDatetime = '" + trans.UpdateDatetime + "' Where CreditTransactionId = " + trans.CreditTransactionId;
                }
                else
                {
                    strSQL = "Update ParkPlaceParking.dbo.CreditTransaction Set CheckNumber = '" + trans.CheckNumber + "' Where CreditTransactionId = " + trans.CreditTransactionId;
                }


                thisADO.updateOrInsert(strSQL, true);

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
