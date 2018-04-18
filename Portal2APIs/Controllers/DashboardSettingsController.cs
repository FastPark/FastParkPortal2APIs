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
    public class DashboardSettingsController : ApiController
    {
        [HttpGet]
        [Route("api/DashboardSettings/GetDashboardSettings/{id}")]
        public List<DashboardSetting> GetDashboardSettings(string id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "Select dbs.*, dbi.DashboardItem " +
                         "from dbIntranet.dbo.DashboardSettings dbs " +
                         "Inner Join dbIntranet.dbo.DashboardItem dbi on dbs.DashboardItemID = dbi.DashboardItemId " +
                         "where UserName = '" + id + "'";
                List<DashboardSetting> list = new List<DashboardSetting>();
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
        [Route("api/DashboardSettings/SetDashboardSettings")]
        public string SetDashboardSettings(DashboardSetting DS)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;
            Int32 thisDashboardSettingsId = 0;

            try
            {
                strSQL = "Select DashboardSettingsId from dbIntranet.dbo.DashboardSettings where DashboardItemId = " + DS.DashboardItemId + " and UserName = '" + DS.UserName + "'";

                thisDashboardSettingsId = Convert.ToInt16(thisADO.returnSingleValueForInternalAPIUse(strSQL, false));

                if (thisDashboardSettingsId == 0)
                {
                    strSQL = "insert into dbIntranet.dbo.DashboardSettings (DashboardItemId, OffsetX, OffsetY, ItemHeight, ItemWidth, UserName) " +
                                                                 "values (" + DS.DashboardItemId + ", " + DS.OffsetX + ", " + DS.OffsetY + ", " + DS.ItemHeight + ", " + DS.ItemWidth + ", '" + DS.UserName + "')";
                    thisADO.updateOrInsert(strSQL, false);
                }
                else
                {
                    strSQL = "update dbIntranet.dbo.DashboardSettings set DashboardItemId = " + DS.DashboardItemId + ", OffsetX = " + DS.OffsetX + ", OffsetY = " + DS.OffsetY + ", ItemHeight = " + DS.ItemHeight + ", ItemWidth = " + DS.ItemWidth + ", UserName = '" + DS.UserName + "' " +
                                                                 "Where DashboardItemId = " + DS.DashboardItemId + " and UserName = '" + DS.UserName + "'";
                    thisADO.updateOrInsert(strSQL, false);
                }
                                                     
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
    }
}
