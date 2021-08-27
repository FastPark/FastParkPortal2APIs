using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Portal2APIs.Models;
using Portal2APIs.Common;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace Portal2APIs.Controllers
{
    public class PCASearchPermitsController : ApiController
    {
        [HttpPost()]
        [Route("api/PCASearchPermits/GetPCASearchPermits/")]
        public List<PCASearchPermit> GetCreditTransactions(PCASearchPermit per)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();
            bool search = false;
            var thisWhere = "";
            var thisFirstName = "";
            var thisLastName = "";
            var thisLicensePlate = "";

            if (per.FirstName != null)
            {
                thisFirstName = per.FirstName;
                search = true;
            }

            if (per.LastName != null)
            {
                thisLastName = per.LastName;
                search = true;
            }

            if (per.LicensePlate != null)
            {
                thisLicensePlate = per.LicensePlate;
                search = true;
            }

            if (search == true)
            {
                thisWhere = "Where (per.PermitStatusId = 2 And u.FirstName = '" + thisFirstName + "' And u.LastName = '" + thisLastName + "') Or (per.PermitStatusId = 2 And uv.LicensePlate = '" + thisLicensePlate + "') ";

                try
                {
                    strSQL = "Select vxr.VendorServiceLocationId, p.PermitId, u.FirstName, u.LastName, c.CityName, st.StateAbbreviation, l.LotName, Cast(pd.EffectiveDatetime + ' 00:00:00' as datetime) as EffectiveDatetime, Cast(pd.ExpiresDatetime + ' 23:59:59' as datetime) as ExpiresDatetime, uv.LicensePlate, c.CityId " +
                                "From ParkPlaceParking.dbo.CreditTransaction ct " +
                                "Inner Join ParkPlaceParking.dbo.Payment p on ct.CreditTransactionId = p.CreditTransactionId " +
                                "Inner Join ParkPlaceParking.dbo.Permit per on p.PermitId = per.PermitId " +
                                "Inner Join ParkPlaceParking.dbo.Lot l on per.LotId = l.LotId " +
                                "Inner Join ParkPlaceParking.dbo.VenderLocationXRef vxr on l.LotId = vxr.PPPLotId " +
                                "Inner Join ParkPlaceParking.dbo.City c on l.CityId = c.CityId " +
                                "Inner Join ParkPlaceParking.dbo.UserVehicle uv on per.UserVehicleId = uv.UserVehicleId " +
                                "Inner Join ParkPlaceParking.dbo.[User] u on uv.UserId = u.UserId " +
                                "Inner Join ParkPlaceParking.dbo.[State] st on uv.LicenseStateId = st.StateId " +
                                "Inner Join( " +
                                    "Select Cast(EOMONTH(Max(ParkDate)) as nvarchar) ExpiresDatetime, Min(ParkDate) EffectiveDatetime, PermitId, CreditTransactionId " +
                                    "From( " +
                                        "Select Convert(Datetime, Cast(ParkingMonth as nvarchar) + '/1/' + Cast(ParkingYear as nvarchar), 101) ParkDate, PermitId, CreditTransactionId " +
                                        "From ParkPlaceParking.dbo.Payment " +
                                    ") pd " +
                                    "Group by PermitId, CreditTransactionId " +
                                ") pd on ct.CreditTransactionId = pd.CreditTransactionId and per.PermitId = pd.PermitId " +
                                thisWhere +
                                "Group by vxr.VendorServiceLocationId, ct.CreditTransactionId, p.PermitId, u.FirstName, u.LastName, c.CityName, st.StateAbbreviation, l.LotName, pd.EffectiveDatetime + ' 00:00:00', pd.ExpiresDatetime + ' 23:59:59', uv.LicensePlate, c.CityId " +
                                "Order by pd.ExpiresDatetime + ' 23:59:59' desc";

                    List<PCASearchPermit> list = new List<PCASearchPermit>();
                    thisADO.returnSingleValue(strSQL, true, ref list);

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
            else
            {
                List<PCASearchPermit> list = new List<PCASearchPermit>();
                return list;
            }
        }

        [HttpPost()]
        [Route("api/PCASearchPermits/PostPCASearchPermits/")]
        public async System.Threading.Tasks.Task<string> PostPCASearchPermitsAsync(PCASearchPermit per)
        {
            string contents = "";
            var thisADO = new clsADO();

            //Get City Id from permit lot
            var strSQL = "Select l.CityId " +
                            "From ParkPlaceParking.dbo.Lot l " +
                            "Inner Join ParkPlaceParking.dbo.Permit p on l.LotId = p.LotId " +
                            "Where p.PermitId = " + per.PermitId;

            var thisCityId = thisADO.returnSingleValueForInternalAPIUse(strSQL, true);

            //Get Credentials for BallParc API 
            strSQL = "Select AccessToken, ApplicationKey From ParkPlaceParking.dbo.VendorAPICred Where VendorId = 1 and CityId = " + thisCityId;

            List<string[]> cred = thisADO.returnAllValues(strSQL, true);

            string AccessToken = cred[0][0].ToString();
            string ApplicationKey = cred[0][1].ToString();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-api-key", ApplicationKey);
            client.DefaultRequestHeaders.Add("x-api-secret", AccessToken);
            client.DefaultRequestHeaders.Add("Accept", "application/x.ballparc.v2+json");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            //DateTime startTime = DateTime.Parse(per.EffectiveDatetime.ToString());
            DateTime startTime = DateTime.Today.AddDays(-1);
            string formatedStartTime = startTime.ToString("yyyy-MM-dd HH:mm:ss");

            DateTime endTime = DateTime.Parse(per.ExpiresDatetime.ToString());
            string formatedEndTime = endTime.ToString("yyyy-MM-dd HH:mm:ss");

            var paidVehicle = new PaidVehicle();

            paidVehicle.location_id = per.VendorServiceLocationId;
            paidVehicle.source = per.Source;
            paidVehicle.start_time = formatedStartTime;
            paidVehicle.end_time = formatedEndTime;
            paidVehicle.space_number = "0";
            paidVehicle.plate_number = per.LicensePlate;
            paidVehicle.plate_state = per.StateAbbreviation;
            paidVehicle.external_key = per.PermitId.ToString();


            string json = JsonConvert.SerializeObject(paidVehicle);
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

            strSQL = "Select InitialEffectiveDate From ParkPlaceParking.dbo.VendorPermitPosted Where PermitId = " + paidVehicle.external_key;

            string InitialEffectiveDate = thisADO.returnSingleValueForInternalAPIUse(strSQL, true);

            if (InitialEffectiveDate == "" || InitialEffectiveDate == null) {
                var url = "https://api.ballparc.com/enforcement/paid_vehicles";

                var response = await client.PostAsync(url, data);
                contents = await response.Content.ReadAsStringAsync();

                //Insert record into VenderPermitPosted so we know we have already posted in the future.
                strSQL = "Insert Into ParkPlaceParking.dbo.VendorPermitPosted (VendorId, PermitId, CreateDatetime, InitialEffectiveDate) " +
                         "Values (1, '" + paidVehicle.external_key + "', GetDate(), '" + paidVehicle.start_time + "' )";

                thisADO.updateOrInsert(strSQL, true);
            }
            else
            {
                //DateTime ie = DateTime.Parse(InitialEffectiveDate);
                //string startDate = ie.ToString("yyyy-MM-dd HH:mm:ss");
                //paidVehicle.start_time = startDate;

                json = JsonConvert.SerializeObject(paidVehicle);
                data = new StringContent(json, Encoding.UTF8, "application/json");

                var url = "https://api.ballparc.com/enforcement/paid_vehicles?external_key=" + paidVehicle.external_key;

                var response = await client.PutAsync(url, data);
                contents = await response.Content.ReadAsStringAsync();
            }
            return "Success";
        }

        [HttpPost()]
        [Route("api/PCASearchPermits/GetPCAPostedPermits/")]
        public async System.Threading.Tasks.Task<Object> GetBallParcPermitsAsync(SearchDates dateRange)
        {
            try
            {
                //Get Credentials for BallParc API for columbus
                var thisADO = new clsADO();
                var strSQL = "Select AccessToken, ApplicationKey From ParkPlaceParking.dbo.VendorAPICred Where VendorId = 1 and CityId = " + dateRange.CityId;

                List<string[]> cred = thisADO.returnAllValues(strSQL, true);

                string AccessToken = cred[0][0].ToString();
                string ApplicationKey = cred[0][1].ToString();

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-api-key", ApplicationKey);
                client.DefaultRequestHeaders.Add("x-api-secret", AccessToken);
                client.DefaultRequestHeaders.Add("Accept", "application/x.ballparc.v2+json");

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                DateTime startTime = DateTime.Parse(dateRange.StartDate);
                string formatedStartTime = startTime.ToString("yyyy-MM-dd");

                DateTime endTime = DateTime.Parse(dateRange.EndDate);
                string formatedEndTime = endTime.ToString("yyyy-MM-dd");

                var url = "https://api.ballparc.com/enforcement/paid_vehicles?start_date=" + formatedStartTime + "&end_date=" + formatedEndTime + "&location_id=" + dateRange.LocationId;

                var response = await client.GetAsync(url);
                var contents = await response.Content.ReadAsStringAsync();

                var json = JsonConvert.DeserializeObject(contents);

                return json;
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
        [Route("api/PCASearchPermits/DeletePCASearchPermits/{id}")]
        public async System.Threading.Tasks.Task<String> DeletePCASearchPermits(string id)
        {
            try
            {
                var thisADO = new clsADO();
                //Get City Id from permit lot
                var strSQL = "Select l.CityId " +
                                "From ParkPlaceParking.dbo.Lot l " +
                                "Inner Join ParkPlaceParking.dbo.Permit p on l.LotId = p.LotId " +
                                "Where p.PermitId = " + id;

                var thisCityId = thisADO.returnSingleValueForInternalAPIUse(strSQL, true);

                
                //Get Credentials for BallParc API 
                strSQL = "Select AccessToken, ApplicationKey From ParkPlaceParking.dbo.VendorAPICred Where VendorId = 1 and CityId = " + thisCityId;

                List<string[]> cred = thisADO.returnAllValues(strSQL, true);

                string AccessToken = cred[0][0].ToString();
                string ApplicationKey = cred[0][1].ToString();

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-api-key", ApplicationKey);
                client.DefaultRequestHeaders.Add("x-api-secret", AccessToken);
                client.DefaultRequestHeaders.Add("Accept", "application/x.ballparc.v2+json");

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                var url = "https://api.ballparc.com/enforcement/paid_vehicles?external_key=" + id;

                //Use PostAsync
                var response = await client.DeleteAsync(url);
                var contents = await response.Content.ReadAsStringAsync();

                return "Success";
            }
            catch(Exception ex)
            {
                return ex.ToString();
            } 
        }

        [HttpGet]
        [Route("api/PCASearchPermits/GetLots/{id}")]
        public List<BallParcLocations> GetCardDesigns(string id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "SELECT l.LotName, vlxr.VendorServiceLocationId " +
                        "FROM ParkPlaceParking.dbo.VenderLocationXRef vlxr " +
                        "Inner Join ParkPlaceParking.dbo.Lot l on vlxr.PPPLotId = l.LotId " +
                        "Where vlxr.PPPCityId = " + id + " " +
                        "Order by l.LotName";
                List<BallParcLocations> list = new List<BallParcLocations>();
                thisADO.returnSingleValue(strSQL, true, ref list);

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
        [Route("api/PCASearchPermits/GetBallParcCities")]
        public List<BallParcCities> GetBallParcCities()
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "Select c.CityId, c.CityName " +
                        "from ParkPlaceParking.dbo.City c " +
                        "Inner Join ParkPlaceParking.dbo.VendorAPICred vac on c.CityId = vac.CityId";

                List<BallParcCities> list = new List<BallParcCities>();
                thisADO.returnSingleValue(strSQL, true, ref list);

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

        public class PaidVehicle
        {
            public string _location_id;
            public string _source;
            public string _start_time;
            public string _end_time;
            public string _space_number;
            public string _plate_number;
            public string _plate_state;
            public string _external_key;

            public string location_id
            {
                get { return _location_id; }
                set { _location_id = value; }
            }

            public string source
            {
                get { return _source; }
                set { _source = value; }
            }
            public string start_time
            {
                get { return _start_time; }
                set { _start_time = value; }
            }
            public string end_time
            {
                get { return _end_time; }
                set { _end_time = value; }
            }
            public string space_number
            {
                get { return _space_number; }
                set { _space_number = value; }
            }
            public string plate_number
            {
                get { return _plate_number; }
                set { _plate_number = value; }
            }
            public string plate_state
            {
                get { return _plate_state; }
                set { _plate_state = value; }
            }
            public string external_key
            {
                get { return _external_key; }
                set { _external_key = value; }
            }
        }

        public class BallParcCities
        {
            public int _CityId;
            public string _CityName;

            public int CityId
            {
                get { return _CityId; }
                set { _CityId = value; }
            }

            public string CityName
            {
                get { return _CityName; }
                set { _CityName = value; }
            }
        }

        public class BallParcLocations
        {
            public string _LotName;
            public string _VendorServiceLocationId;

            public string LotName
            {
                get { return _LotName; }
                set { _LotName = value; }
            }

            public string VendorServiceLocationId
            {
                get { return _VendorServiceLocationId; }
                set { _VendorServiceLocationId = value;  }
            }
        }

        public class SearchDates
        {
            public string _StartDate;
            public string _EndDate;
            public string _LocationId;
            public string _CityId;

            public string StartDate
            {
                get { return _StartDate; }
                set { _StartDate = value; }
            }

            public string EndDate
            {
                get { return _EndDate; }
                set { _EndDate = value; }
            }

            public string LocationId
            {
                get { return _LocationId; }
                set { _LocationId = value; }
            }

            public string CityId
            {
                get { return _CityId; }
                set { _CityId = value; }
            }
        }
    }
}
