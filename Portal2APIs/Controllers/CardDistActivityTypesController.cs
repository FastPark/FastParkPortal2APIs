using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.Http;
using Portal2APIs.Models;
using Portal2APIs.Common;

namespace Portal2APIs.Controllers
{
    public class CardDistActivityTypesController : ApiController
    {
        [HttpGet()]
        [Route("api/CardDistActivityTypes/Get/{id}")]
        public CardDistActivityType Get(int id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();
            CardDistActivityType CDAT = null;
            clsCommon nullCheck = new clsCommon();

            strSQL = "Select * from dbo.CardDistributionActivityType where CardDistributionActivityTypeID=" + id + "";
            using (SqlConnection connection = new SqlConnection(thisADO.getMaxConnectionString()))
            {
                SqlCommand command = new SqlCommand(strSQL, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CDAT = new CardDistActivityType();
                    CDAT.CardDistributionActivityTypeID = Convert.ToInt32(nullCheck.checknull(reader.GetValue(0), false));
                    CDAT.CardDistributionActivityRole = Convert.ToString(nullCheck.checknull(reader.GetValue(1), false));
                    CDAT.CardDistributionActivityDescription = Convert.ToString(nullCheck.checknull(reader.GetValue(2), false));
                }
                reader.Close();

                return CDAT;
            }
        }

        [HttpPost()]
        [Route("api/CardDistActivityTypes/Post")]
        public CardDistActivityType Post(CardDistActivityType CDAT)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            strSQL = "insert into CardDistributionActivityType (CardDistributionActivityDescription, CardDistributionActivityRole) " +
                                                                "values ('" + CDAT.CardDistributionActivityDescription + "', '" + CDAT.CardDistributionActivityRole + "')";

            thisADO.updateOrInsert(strSQL, true);

            return null;
        }
    }
}
