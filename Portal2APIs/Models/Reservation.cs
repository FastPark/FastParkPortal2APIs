using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class Reservation
    {
        public Int64 MemberId
        {
            get { return m_MemberId; }
            set { m_MemberId = value; }
        }
        private Int64 m_MemberId;
        public int ReservationId
        {
            get { return m_ReservationId; }
            set { m_ReservationId = value; }
        }
        private int m_ReservationId;

        public int ReservationStatusId
        {
            get { return m_ReservationStatusId; }
            set { m_ReservationStatusId = value; }
        }
        private int m_ReservationStatusId;
        public Int64 ReservationNumber
        {
            get { return m_ReservationNumber; }
            set { m_ReservationNumber = value; }
        }
        private Int64 m_ReservationNumber;
        public string ShortLocationName
        {
            get { return m_ShortLocationName; }
            set { m_ShortLocationName = value; }
        }
        private string m_ShortLocationName;
        public DateTime StartDatetime
        {
            get { return m_StartDatetime; }
            set { m_StartDatetime = value; }
        }
        private DateTime m_StartDatetime;
        public DateTime EndDatetime
        {
            get { return m_EndDatetime; }
            set { m_EndDatetime = value; }
        }
        private DateTime m_EndDatetime;
        public DateTime CanceledDate
        {
            get { return m_CanceledDate; }
            set { m_CanceledDate = value; }
        }
        private DateTime m_CanceledDate;
        
        public string FirstName
        {
            get { return m_FirstName; }
            set { m_FirstName = value; }
        }
        private string m_FirstName;
        public string LastName
        {
            get { return m_LastName; }
            set { m_LastName = value; }
        }
        private string m_LastName;

        public string FPNumber
        {
            get { return m_FPNumber; }
            set { m_FPNumber = value; }
        }
        private string m_FPNumber;

        public int IsGuest
        {
            get { return m_IsGuest; }
            set { m_IsGuest = value; }
        }
        private int m_IsGuest;

        public int Options
        {
            get { return m_Options; }
            set { m_Options = value; }
        }
        private int m_Options;

        public string ReservationStatusName
        {
            get { return m_ReservationStatusName; }
            set { m_ReservationStatusName = value; }
        }
        private string m_ReservationStatusName;

    }
}