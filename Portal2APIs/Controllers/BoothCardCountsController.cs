﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Portal2APIs.Models;
using Portal2APIs.Common;

namespace Portal2APIs.Controllers
{
    public class BoothCardCountsController : ApiController
    {
        [HttpGet()]
        [Route("api/BoothCardCounts/GetBoothCardCount")]
        public List<BoothCardCount> GetBoothCardCount()
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select bcc.*, l.NameOfLocation from BoothCardCount bcc " +
                         "Inner Join Location l on bcc.LocationId = l.LocationId";
                List<BoothCardCount> list = new List<BoothCardCount>();
                thisADO.returnSingleValue(strSQL, false, ref list);

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
        [Route("api/BoothCardCounts/Post")]
        public BoothCardCount Post(BoothCardCount BCC)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "insert into BoothCardCount (Shift1, Shift2, Shift3, Total, BoothCardCountDate, LocationId) " +
                                                        "values (" + BCC.Shift1 + ", " + BCC.Shift2 + ", " + BCC.Shift3 + ", " +
                                                        BCC.Total + ", '" + BCC.BoothCardCountDate + "', " + BCC.LocationId + ")";

                thisADO.updateOrInsertWithId(strSQL, false);
                
                return null;
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