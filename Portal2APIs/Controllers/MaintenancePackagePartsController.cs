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
    public class MaintenancePackagePartsController : ApiController
    {
        [HttpGet]
        [Route("api/MaintenancePackageParts/GetPartsByPMIId/{id}")]
        public List<MaintenancePackagePart> GetPartsByPMIId(int id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "Select p.PartId, p.PartDescription, p.PartModel, mpp.Quantity, mpp.UnitPrice, p.PartManufacturer, mpp.Tax, mpp.Labor, mpp.Warranty " +
                         "from Vehicles.dbo.MaintenancePackageParts mpp " +
                         "inner join Vehicles.dbo.Parts p on mpp.PartId = p.PartId " +
                         "Where PackageId = " + id;

                List<MaintenancePackagePart> list = new List<MaintenancePackagePart>();

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
