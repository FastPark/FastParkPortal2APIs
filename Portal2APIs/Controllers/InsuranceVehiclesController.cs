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
    public class InsuranceVehiclesController : ApiController
    {
        [HttpGet]
        [Route("api/InsuranceVehicles/GetInsuranceVehicles/{id}")]
        public List<InsVehicles> GetInsuranceVehicles(string id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                string whereClause = "Where ";

                //Update Vehicle Link by adding any new vehicles in the vehicle table
                strSQL = "INSERT INTO InsuranceClaims.dbo.VehicleLink (VehicleId, VehicleCoverageId, CoverageStatus) " +
                         "Select v.VehicleId, 1, 1 " +
                         "from Vehicles.dbo.Vehicles v " +
                         "Where v.VehicleId not in (Select VehicleId from InsuranceClaims.dbo.VehicleLink)";

                thisADO.updateOrInsert(strSQL, false);

                id = id.Replace("_", ",");

                string[] thisParams = id.Split('~');

                if (thisParams[0].ToString() != "")
                {
                    whereClause = whereClause + "v.CurrentLocationId in (" + thisParams[0].ToString() + ") ";
                }

                if (thisParams[1].ToString() != "")
                {
                    if (whereClause == "Where ")
                    {
                        whereClause = whereClause + "v.StatusId in (" + thisParams[1].ToString() + ") ";
                    }
                    else
                    {
                        whereClause = whereClause + "and v.StatusId in (" + thisParams[1].ToString() + ") ";
                    }
                }

                if (thisParams[2].ToString() != "")
                {
                    if (whereClause == "Where ")
                    {
                        whereClause = whereClause + "vl.VehicleCoverageId in (" + thisParams[2].ToString() + ")";
                    }
                    else
                    {
                        whereClause = whereClause + "and vl.VehicleCoverageId in (" + thisParams[2].ToString() + ")";
                    }
                }

                //"where v.CurrentLocationId in (" + thisParams[0].ToString() + ") " +
                //"and v.StatusId in (" + thisParams[1].ToString() + ") " +
                //"and vl.VehicleCoverageId in (" + thisParams[2].ToString() + ")";

                strSQL = "select v.VehicleId, s.StatusDescription, v.VehicleNumber, v.Year, vmake.MakeName, vm.ModelName, v.VINNumber, l.NameOfLocation as Garaged,  vpt.OriginalCost, vt.TypeDescription as Class, vc.VehicleCoveragename as Coverage, vl.VehicleCoverageId as CoverageCode, d.DriverName, " +
                        "vct.ChangeInitiatedDate as [ChangeDate], Replace(Replace(vct.ChangeNotes, char(13) + char(10), ''), char(9), '') as [ChangeNotes], v.ActiveDate as [AddDate], IsNull(v.InactiveDate, '') as [DeleteDate], " +
                        "Case When vl.CoverageStatus = 1 Then 'Active' Else 'In-Active' End as Insurance, vl.CoverageStatus as InsuranceCode, vl.CoverageAdded, vl.CoverageRemoved, vs.PostalAbrev as [State] " +
                        "from InsuranceClaims.dbo.VehicleLink vl " +
                        "inner join InsuranceClaims.dbo.VehicleCoverage vc on vl.VehicleCoverageId = vc.VehicleCoverageId " +
                        "inner join Vehicles.dbo.Vehicles v on vl.VehicleId = v.VehicleId " +
                        "inner join Vehicles.dbo.Location l on v.CurrentLocationId = l.LocationId " +
                        "Left Outer Join InsuranceClaims.dbo.VehicleState vs on vl.StateId = vs.StateId " +
                        "inner join Vehicles.dbo.VehicleModels vm on v.ModelId = vm.ModelId " +
                        "inner join Vehicles.dbo.Status s on v.StatusId = s.StatusId " +
                        "inner join Vehicles.dbo.VehicleMakes vmake on vm.MakeId = vmake.MakeId " +
                        "Left Outer Join Vehicles.dbo.VehiclePurchaseTracking vpt on v.VehicleId = vl.VehicleId and PurchaseTrackingId = (Select Max(PurchaseTrackingId) from Vehicles.dbo.VehiclePurchaseTracking where VehicleId = v.VehicleId)  " +
                        "inner join Vehicles.dbo.VehicleTypes vt on vm.TypeId = vt.TypeId " +
                        "left outer join Vehicles.dbo.Drivers d on v.DriverId = d.DriverId " +
                        "left outer join( " +
                            "Select top 1 * " +
                            "from Vehicles.dbo.VehicleChangeTracking " +
                            "Order by ChangeInitiatedDate desc " +
                        ") vct on v.VehicleId = vl.VehicleId " +
                        whereClause;

                List<InsVehicles> list = new List<InsVehicles>();

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

        [HttpPost]
        [Route("api/InsuranceVehicles/UpdateInsuranceVehicleStatus/")]
        public string UpdateInsuranceVehicleStatus(InsVehicles iv)
        {
            string strSQL = "";
            int thisState  = iv.StateID;

            try
            {
                clsADO thisADO = new clsADO();

                strSQL = "Update InsuranceClaims.dbo.VehicleLink " +
                         "Set VehicleCoverageId = " + iv.Coverage + ", CoverageStatus = " + iv.Insurance + ", CoverageAdded = '" + iv.CoverageAdded + "', CoverageRemoved = '" + iv.CoverageRemoved + "', StateID = " + thisState + " " +
                         "Where VehicleId = " + iv.VehicleId;

                if (iv.CoverageAdded == null)
                {
                    strSQL = "Update InsuranceClaims.dbo.VehicleLink " +
                         "Set VehicleCoverageId = " + iv.Coverage + ", CoverageStatus = " + iv.Insurance + ", CoverageAdded = null, CoverageRemoved = '" + iv.CoverageRemoved + "', StateID = " + thisState + " " +
                         "Where VehicleId = " + iv.VehicleId;
                }
                if (iv.CoverageRemoved == null)
                {
                    strSQL = "Update InsuranceClaims.dbo.VehicleLink " +
                         "Set VehicleCoverageId = " + iv.Coverage + ", CoverageStatus = " + iv.Insurance + ", CoverageAdded = '" + iv.CoverageAdded + "', CoverageRemoved = null, StateID = " + thisState + " " +
                         "Where VehicleId = " + iv.VehicleId;
                }
                if (iv.CoverageAdded == null && iv.CoverageRemoved == null)
                {
                    strSQL = "Update InsuranceClaims.dbo.VehicleLink " +
                        "Set VehicleCoverageId = " + iv.Coverage + ", CoverageStatus = " + iv.Insurance + ", CoverageAdded = null, CoverageRemoved = null, StateID = " + thisState + " " +
                        "Where VehicleId = " + iv.VehicleId;
                }


                thisADO.updateOrInsert(strSQL, false);

                return "Success";
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
        [Route("api/InsuranceVehicles/GetCoverageTypes/")]
        public List<InsuranceVehiclesCoverage> GetCoverageTypes()
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "Select VehicleCoverageId, VehicleCoveragename from InsuranceClaims.dbo.VehicleCoverage Order By VehicleCoveragename";

                List<InsuranceVehiclesCoverage> list = new List<InsuranceVehiclesCoverage>();

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
        [Route("api/InsuranceVehicles/GetStateId/{id}")]
        public string GetStateId(string id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "Select StateId from InsuranceClaims.dbo.VehicleState where PostalAbrev = '" + id + "'";

                string returnId = thisADO.returnSingleValueForInternalAPIUse(strSQL, false);

                return returnId;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [HttpGet]
        [Route("api/InsuranceVehicles/GetInvuranceVehiclesByLocation/{id}")]
        public List<InsVehicles> GetInvuranceVehiclesByLocation(string id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "Select v.VehicleId, v.VehicleNumber " +
                            "from Vehicles.dbo.Vehicles v " +
                            "Inner Join InsurancePCA.dbo.Location l on v.CurrentLocationId = l.VehicleLocationId " +
                            "Where StatusId = 1 " +
                            "and v.VehicleNumber not like '%stock%' " +
                            "and l.locationId = " + id;

                List<InsVehicles> list = new List<InsVehicles>();

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
