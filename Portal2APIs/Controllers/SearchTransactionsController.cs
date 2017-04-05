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
    public class SearchTransactionsController : ApiController
    {
        [HttpPost]
        [Route("api/SearchTransactions/SearchTransactions")]
        public List<SearchTransaction> SearchByCompanyLocation(SearchTransaction thisTransaction)
        {
            string strStoredProcedure = "";
            clsADO thisADO = new clsADO();

            try
            {

                var thisParams = thisTransaction.EntryDate + "," + thisTransaction.ExitDate + "," + thisTransaction.ReceiptNumber + "," + thisTransaction.ColumnNumber + "," + thisTransaction.ShortTermNumber + "," + thisTransaction.LocationId + "," + thisTransaction.Archive;
                
                List<SearchTransaction> list = new List<SearchTransaction>();
                thisADO.returnSearchTransactions(strStoredProcedure, false, ref list, thisParams);

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
    }
}
