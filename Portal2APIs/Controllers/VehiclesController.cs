﻿using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.Http;
using Portal2APIs.Models;
using Portal2APIs.Common;
using System.Net;
using System.Net.Http;

namespace Portal2APIs.Controllers
{
    public class VehiclesController : ApiController
    {
        [HttpGet()]
        [Route("api/Vehicles/GetVehiclesByLocation/{id}")]
        public List<Vehicle> GetVehiclesByLocation(int Id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select VehicleId, VehicleNumber from Vehicles.dbo.Vehicles where CurrentLocationId = " + Id;
                List<Vehicle> list = new List<Vehicle>();
                thisADO.returnSingleValueForPark09(strSQL, ref list);

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
