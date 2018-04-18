using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class DashboardSetting
    {

        #region Constructors
        public DashboardSetting()
        {
        }
        #endregion
        #region Private Fields
        private int _DashboardSettingsId;
        private int _DashboardItemId;
        private int _OffsetX;
        private int _OffsetY;
        private int _ItemHeight;
        private int _ItemWidth;
        private string _UserName;
        private string _DashboardItem;
        #endregion
        #region Public Properties
        public int DashboardSettingsId
        {
            get { return _DashboardSettingsId; }
            set { _DashboardSettingsId = value; }
        }
        public int DashboardItemId
        {
            get { return _DashboardItemId; }
            set { _DashboardItemId = value; }
        }
        public int OffsetX
        {
            get { return _OffsetX; }
            set { _OffsetX = value; }
        }
        public int OffsetY
        {
            get { return _OffsetY; }
            set { _OffsetY = value; }
        }
        public int ItemHeight
        {
            get { return _ItemHeight; }
            set { _ItemHeight = value; }
        }
        public int ItemWidth
        {
            get { return _ItemWidth; }
            set { _ItemWidth = value; }
        }
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        public string DashboardItem
        {
            get { return _DashboardItem; }
            set { _DashboardItem = value; }
        }
        #endregion
    }
}