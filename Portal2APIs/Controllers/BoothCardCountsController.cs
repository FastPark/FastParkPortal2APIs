using System;
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
        [Route("api/BoothCardCounts/GetBoothCardCount/{id}")]
        public List<BoothCardCount> GetBoothCardCount(int id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select bcc.*, l.NameOfLocation from CardDistribution.dbo.BoothCardCount bcc " +
                         "Inner Join CardDistribution.dbo.LocationDetails l on bcc.LocationId = l.LocationId where bcc.LocationId = " + id + " order by BoothCardCountDate desc";
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
                strSQL = "insert into CardDistribution.dbo.BoothCardCount (Shift1, Shift2, Shift3, Total, BoothCardCountDate, LocationId, Adjustment) " +
                                                        "values (" + BCC.Shift1 + ", " + BCC.Shift2 + ", " + BCC.Shift3 + ", " +
                                                        BCC.Total + ", '" + BCC.BoothCardCountDate + "', " + BCC.LocationId + ", " + BCC.Adjustment + ")";

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

        [HttpGet()]
        [Route("api/BoothCardCounts/GetBoothLevel/{id}")]
        public List<BoothCardCount> GetBoothLevel(int id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select Sum(BoothDist) - Sum(BoothHand) as Level from ( " +
                            "select Sum(CardDistEndNumber - CardDistStartNumber + 1) as BoothDist, 0 as BoothHand " +
                            "from CardDistribution.dbo.CardDist cd " +
                            "where CardDistBooth = 1 " +
                            "and CardDistLocationID = " + id + " " +
                            "Union All " +
                            "Select 0 as BoothDist, Sum(Total) as BoothHand " +
                            "from CardDistribution.dbo.BoothCardCount " +
                            "Where LocationId = " + id + " " +
                         ") BoothTotal";
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
    }
}
