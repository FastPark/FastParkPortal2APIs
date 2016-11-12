using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Portal2APIs.Common;
using Portal2APIs.Models;
using System.Data.SqlClient;

namespace Portal2APIs.Controllers
{
    public class RatesController : ApiController
    {
        [HttpPost]
        [Route("api/Rates/GetRateByLocationAndCompanyId/")]
        public String LocationByLocationId(Rate thisRate)
        {
            try
            {
                string thisReturn = "";
                clsADO thisADO = new clsADO();


                string strSQL = "Select dbo.GetlocationRateFunction (" + thisRate.CompanyId + ", " + thisRate.LocationId + ")";
                
                string rateNumber = Convert.ToString(thisADO.returnSingleValue(strSQL,false, true));

                string rateSQL = "select RateAmount from RateAmounts where UpdateDatetime is null and LocationId = " + thisRate.LocationId + " and RateCode = " + rateNumber;

                string rate = Convert.ToString(thisADO.returnSingleValue(rateSQL, false, true));

                string homeLocationSQL = "select location_Id from MarketingFlyer.dbo.market_has_locations mhl " +
                                         "inner join MarketingFlyer.dbo.company_market_histories cmh on mhl.market_Id = cmh.market_Id " +
                                         "where cmh.company_id = " + thisRate.CompanyId;

                string conn = thisADO.getLocalConnectionString();
                string locationList = "";
                Boolean first = true;

                using (SqlConnection con = new SqlConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = homeLocationSQL;
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (first == true)
                                {
                                    locationList =  Convert.ToString(sdr[0]);
                                    first = false;
                                }
                                else
                                {
                                    locationList = locationList + "_" + Convert.ToString(sdr[0]);
                                }
                                
                            }
                        }
                        con.Close();
                    }
                }
                thisReturn = rate + "," + rateNumber + "," + locationList;

                return thisReturn;
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
