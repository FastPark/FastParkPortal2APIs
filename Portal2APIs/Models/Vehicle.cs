using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class Vehicle
    {
        public int VehicleId
        {
            get { return m_VehicleId; }
            set { m_VehicleId = value; }
        }
        private int m_VehicleId;
        public String VehicleNumber
        {
            get { return m_VehicleNumber; }
            set { m_VehicleNumber = value; }
        }
        private String m_VehicleNumber;
        public int CurrentLocationId
        {
            get { return m_CurrentLocationId; }
            set { m_CurrentLocationId = value; }
        }
        private int m_CurrentLocationId;
    }
}