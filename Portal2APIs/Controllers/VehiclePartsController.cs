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
    public class VehiclePartsController : ApiController
    {
        [HttpPost]
        [Route("api/VehicleParts/InsertVehiclePart")]
        public int InsertVehiclePart(VehiclePart VP)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;


            try
            {
                strSQL = "INSERT INTO Vehicles.dbo.Parts (ModelId ,PartCategoryId ,FuelTypeId ,PartName ,PartModel ,PartManufacturer ,PartDescription ,Stockable ,EnteredByUserId ,DateTimeEntered) " +    
                         "VALUES(" + VP.ModelId + " ,9 ," + VP.FuelTypeId + " ,'" + VP.PartName + "' ,'" + VP.PartModel + "' ,'" + VP.PartManufacturer + "' ,'" + VP.PartDescription + "' ," + VP.Stockable + " , '00000000-0000-0000-0000-000000000000', getdate())";

                var PartId = thisADO.updateOrInsertWithId(strSQL, false);
                

                return PartId;
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
