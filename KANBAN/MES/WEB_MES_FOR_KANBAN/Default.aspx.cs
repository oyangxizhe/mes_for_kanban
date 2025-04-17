using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using CMES;
using System.Data;
namespace WEB_MES_FOR_KANBAN
{
    public partial class _Default : System.Web.UI.Page
    {
        basec bc = new basec();
        DataTable dt = new DataTable();
        #region nature
        private static string _PROCESS;
        public static string PROCESS
        {
            set { _PROCESS = value; }
            get { return _PROCESS; }

        }
        private static string _FACTORY_AREA;
        public static string FACTORY_AREA
        {
            set { _FACTORY_AREA = value; }
            get { return _FACTORY_AREA; }

        }
        private static string _FACTORY_AREA_CODE;
        public static string FACTORY_AREA_CODE
        {
            set { _FACTORY_AREA_CODE = value; }
            get { return _FACTORY_AREA_CODE; }

        }
        private static string _FABN;
        public static string FABN
        {
            set { _FABN = value; }
            get { return _FABN; }

        }
        private static string _SQLCONN;
        public static string SQLCONN
        {
            set { _SQLCONN = value; }
            get { return _SQLCONN; }

        }
        private static string _EMID;
        public static string EMID
        {
            set { _EMID = value; }
            get { return _EMID; }

        }
        private static string _IP;
        public static string IP
        {
            set { _IP = value; }
            get { return _IP; }

        }
        private static string _ENAME;
        public static string ENAME
        {
            set { _ENAME = value; }
            get { return _ENAME; }

        }
        private static string _DEPART;
        public static string DEPART
        {
            set { _DEPART = value; }
            get { return _DEPART; }

        }
        private string _GEID;
        public string GEID
        {
            set { _GEID = value; }
            get { return _GEID; }

        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
        
             
        }
     
        protected void btnLogin_Click(object sender, ImageClickEventArgs e)
        {
 
        }
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
       
        }
    }
}