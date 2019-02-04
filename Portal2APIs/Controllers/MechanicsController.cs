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
    public class MechanicsController : ApiController
    {
        [HttpGet()]
        [Route("api/Mechanics/GetMechanicsByLocation/{id}")]
        public List<Mechanics> GetPMIByVehicleID(int Id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select MechanicName, MechanicId from Vehicles.dbo.Mechanics where Active = 1 and LocationId = " + Id;

                List<Mechanics> list = new List<Mechanics>();
                //thisADO.returnSingleValueForPark09(strSQL, ref list);
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
