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
    public class VehicleMaintenancePartsController : ApiController
    {
        [HttpPost]
        [Route("api/VehicleMaintenanceParts/InsertVehicleMaintenancePart")]
        public string InsertVehicleMaintenancePart(VehicleMaintenancePart VMP)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;
                


            try
            {
                var strPartSupplierSQL = "Select PartSupplierId from Vehicles.dbo.PartSuppliers where PartSupplierName = '" + VMP.PartSupplierName + "'";

                var strPartSupplierId = thisADO.returnSingleValueForInternalAPIUse(strPartSupplierSQL, false);

                if (strPartSupplierId == null)
                {
                    strPartSupplierId = "423";  //need MISC ID if no supplier 
                }

                strSQL = "INSERT INTO Vehicles.dbo.VehicleMaintenanceParts (VehicleMaintenanceId, PartId,UnitPrice ,Quantity ,PreventatitiveMaintenance ,PartSupplierId ,InvoiceNumber ,Warranty ,Labor ,Tax) " +
                            "VALUES(" + VMP.VehicleMaintenanceId + ", " + VMP.PartId + " ," + VMP.UnitPrice + " ," + VMP.Quantity + " , 0, " + strPartSupplierId + " ,'" + VMP.InvoiceNumber + "', '" + VMP.Warranty + "', " + VMP.Labor + ", " + VMP.Tax + ")";

                thisADO.updateOrInsert(strSQL, false);


                return "Succes";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
