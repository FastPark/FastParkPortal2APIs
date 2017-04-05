using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Portal2APIs.Common;
using System.Data.SqlClient;
using Portal2APIs.Models;

namespace Portal2APIs.Controllers
{
    public class CompanyDropDownsController : ApiController
    {
        [HttpGet]
        [Route("api/CompanyDropDowns/GetCompanies/")]
        public List<CompanyDropDown> GetCompanies()
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select id, name from dbo.companies";
                List<CompanyDropDown> list = new List<CompanyDropDown>();
                thisADO.returnSingleValueMarketing(strSQL, true, ref list);

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
        [Route("api/CompanyDropDowns/GetCompanyName/{Id}")]
        public List<CompanyDropDown> GetCompanyName(int Id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select name from dbo.companies where ID = " + Id;
                List<CompanyDropDown> list = new List<CompanyDropDown>();
                thisADO.returnSingleValueMarketing(strSQL, true, ref list);

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
