﻿using System;
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
        public String GetRateByLocationAndCompanyId(Rate thisRate)
        {
            try
            {
                string thisReturn = "";
                clsADO thisADO = new clsADO();


                string strSQL = "Select dbo.GetlocationRateFunction (" + thisRate.CompanyId + ", " + thisRate.LocationId + ")";
                
                string rateNumber = Convert.ToString(thisADO.selectConvertToString(strSQL,true, true));

                //string rateSQL = "select RateAmount from RateAmounts where UpdateDatetime is null and LocationId = " + thisRate.LocationId + " and RateCode = " + rateNumber;
                string rateSQL = "select RateAmount from RateAmounts where LocationId = " + thisRate.LocationId + " and RateCode = " + rateNumber + " " +
                                 "and CreateDatetime = (select max(CreateDatetime) from RateAmounts where RateCode = ra.RateCode and LocationId = ra.LocationId AND GETDATE() > EffectiveDatetime)";

                string rate = Convert.ToString(thisADO.selectConvertToString(rateSQL, true, true));

                //string homeLocationSQL = "select location_Id from MarketingFlyer.dbo.market_has_locations mhl " +
                //                         "inner join MarketingFlyer.dbo.company_market_histories cmh on mhl.market_Id = cmh.market_Id " +
                //                         "where cmh.company_id = " + thisRate.CompanyId;

                string homeLocationSQL = "select location_Id from MarketingFlyer.dbo.market_has_locations mhl " +
                                         "inner join company_market_histories_For_Import_Current cmh on mhl.market_Id = cmh.market_Id " +
                                         "where cmh.company_id = " + thisRate.CompanyId;

                string conn = thisADO.getRemoteConnectionString();
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

        [HttpGet]
        [Route("api/Rates/GetRateDescriptionAmounts/{id}")]
        public List<Rate> GetRateDescriptionAmounts(string id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "select r.Designation, Convert(decimal(10,2),Cast(ra.RateAmount as decimal)/100) as RateAmount, l.ShortLocationName " +
                         "from rates r " +
                         "Inner Join rateAmounts ra on r.RateNumber = ra.RateCode and r.LocationId = ra.LocationId " +
                         "Inner Join LocationDetails l on r.LocationId = l.LocationId " +
                         "where ra.UpdateDatetime is null " +
                         "and r.LocationId = " + id + " " +
                         "Order by l.ShortLocationName, r.Designation ";

                List <Rate> list = new List<Rate>();
                thisADO.returnSingleValue(strSQL, true, ref list);

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
