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
    public class VehicleMaintenancesController : ApiController
    {
        [HttpPost]
        [Route("api/VehicleMaintenances/InsertVehicleMaintenance")]
        public string Distribute(VehicleMaintenance VM)
        {
            var PackageId = "";

            clsADO thisADO = new clsADO();
            string strSQL = null;

            if (VM.PackageId == 0)
            {
                PackageId = "NULL";
            }
            else
            {
                PackageId = VM.PackageId.ToString();
            }

            try
            {
                strSQL = "insert into Vehicles.dbo.VehicleMaintenance (VehicleId, WorkOrder, MaintenanceDate, MaintenanceDescription, PartsCost, PartsTax, MechanicId, LaborCost, Notes, DateTimeEntered, PackageId, WarranyWork, LocationId, EnteredByUserId, EnteredBy) " +
                                                        "values (" + VM.VehicleId + ", '" + VM.WorkOrder + "', '" + VM.MaintenanceDate + "', '" + VM.MaintenanceDescription + "', " + VM.PartsCost + ", " + VM.PartsTax + ", " + VM.MechanicId + ", " + VM.LaborCost + ", '" +
                                                        VM.Notes + "', '" + VM.DateTimeEntered + "', " + PackageId + ", " + VM.WarranyWork + ", " + VM.LocationId + ", '00000000-0000-0000-0000-000000000000', '" + VM.EnteredBy + "')";

                var vmID = thisADO.updateOrInsertWithId(strSQL, false);

                foreach (object vmp in VM.VehicleMaintenanceParts)
                {
                    //Create new part
                    var part = new VehiclePartsController();
                    var vp = new VehiclePart();
                    
                    vp.ModelId = ((VehicleMaintenancePart)vmp).ModelId;
                    vp.PartCategoryId = 0;
                    vp.FuelTypeId = ((VehicleMaintenancePart)vmp).FuelTypeId;
                    vp.PartName = ((VehicleMaintenancePart)vmp).PartDescription;
                    vp.PartModel = "";
                    vp.PartManufacturer = "";
                    vp.PartDescription = ((VehicleMaintenancePart)vmp).PartDescription;
                    vp.Stockable = 0;

                    var partId = part.InsertVehiclePart(vp);

                    //Insert maintenance part for maintenance record
                    var maintenancePart = new VehicleMaintenancePartsController();
                    var newVMP = new VehicleMaintenancePart();

                    newVMP.VehicleMaintenanceId = vmID;
                    newVMP.PartId = partId;
                    newVMP.PartDescription = ((VehicleMaintenancePart)vmp).PartDescription;
                    newVMP.Quantity = ((VehicleMaintenancePart)vmp).Quantity;
                    newVMP.PreventatitiveMaintenance = false;
                    newVMP.PartSupplierName = ((VehicleMaintenancePart)vmp).PartSupplierName;
                    newVMP.InvoiceNumber = ((VehicleMaintenancePart)vmp).InvoiceNumber;
                    newVMP.Warranty = ((VehicleMaintenancePart)vmp).Warranty;
                    newVMP.Labor = ((VehicleMaintenancePart)vmp).Labor;
                    newVMP.Tax = ((VehicleMaintenancePart)vmp).Tax;
                    newVMP.UnitPrice = ((VehicleMaintenancePart)vmp).UnitPrice;

                    maintenancePart.InsertVehicleMaintenancePart(newVMP);
                }

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
