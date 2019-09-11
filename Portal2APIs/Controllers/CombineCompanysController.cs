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
    public class CombineCompanysController : ApiController
    {
        [HttpGet]
        [Route("api/CombineCompanysController/CompanyInfo/{id}")]
        public List<CombineCompany> CombineCompanys(string id)
        {
            CombineCompany thisCompany = new CombineCompany();

            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "select c.id, name, address_1, city, state, zip, home_rate_code, away_rate_code, website " +
                        "from companies c " +
                        "Inner Join company_market_histories_For_Import_Current cmh on c.id = cmh.company_id " +
                        "where c.id = " + id;

                List<CombineCompany> list = new List<CombineCompany>();
                thisADO.returnSingleValue(strSQL, true, ref list);

                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("api/CombineCompanysController/GetActivity/{id}")]
        public CombineCompany GetActivity(string id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();
                CombineCompany thisCompany = new CombineCompany();

                strSQL = "select count(a.MemberId) from Activity a " +
                         "Inner Join MemberInformationMain mi on a.MemberId = mi.MemberId " +
                         "where mi.CompanyId = " + id;

                thisCompany.activity = Convert.ToInt16(thisADO.returnSingleValueForInternalAPIUse(strSQL, true));


                strSQL = "select count(me.MemberId) from ManualEdits me " +
                         "Inner Join MemberInformationMain mi on me.MemberId = mi.MemberId " +
                         "where mi.CompanyId = " + id;

                thisCompany.manual_edits = Convert.ToInt16(thisADO.returnSingleValueForInternalAPIUse(strSQL, true));

                strSQL = "select count(MemberId) from MemberInformationMain " +
                         "where CompanyId = " + id;

                thisCompany.members = Convert.ToInt16(thisADO.returnSingleValueForInternalAPIUse(strSQL, true));

                strSQL = "select count(id) from vcontacts " +
                         "where company_id = " + id;

                thisCompany.contacts = Convert.ToInt16(thisADO.returnSingleValueForInternalAPIUse(strSQL, true));

                strSQL = "select count(id) from vflyers " +
                         "where company_id = " + id;

                thisCompany.flyers = Convert.ToInt16(thisADO.returnSingleValueForInternalAPIUse(strSQL, true));

                strSQL = "select count(id) from vcompany_location_rate_codes " +
                         "where company_id = " + id;

                thisCompany.mailer_rates = Convert.ToInt16(thisADO.returnSingleValueForInternalAPIUse(strSQL, true));

                return thisCompany;
            }
            catch
            {
                return null;
            }
        }
    }
}
