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
    public class VehiclePartSuppliersController : ApiController
    {
        [HttpGet]
        [Route("api/VehiclePartSuppliers/GetSuppliers/")]
        public List<VehiclePartSupplier> GetSuppliers()
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "Select PartSupplierId, PartSupplierName from Vehicles.dbo.PartSuppliers order by PartSupplierName";
                List<VehiclePartSupplier> list = new List<VehiclePartSupplier>();
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
        [Route("api/VehiclePartSuppliers/GetSuppliersIdByName/{name}")]
        public List<VehiclePartSupplier> GetSuppliers(string name)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "Select PartSupplierId  from Vehicles.dbo.PartSuppliers Where PartSupplierName = '" + name + "'";
                List<VehiclePartSupplier> list = new List<VehiclePartSupplier>();
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
    }
}
