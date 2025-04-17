
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMES;
using System.Drawing;
using System.Data;
using System.Text;



namespace WEB_MES_FOR_KANBAN
{
    public partial class VIEW : System.Web.UI.Page
    {
        #region nature
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
        private string _IP;
        public string IP
        {
            set { _IP = value; }
            get { return _IP; }

        }
        private static string _SQLCONN;
        public static string SQLCONN
        {
            set { _SQLCONN = value; }
            get { return _SQLCONN; }
        }
        private static string _MACHINE_AREA_ID;
        public static string MACHINE_AREA_ID
        {
            set { _MACHINE_AREA_ID = value; }
            get { return _MACHINE_AREA_ID; }
        }
        private string _BUILD_NO;
        public string BUILD_NO
        {
            set { _BUILD_NO = value; }
            get { return _BUILD_NO; }
        }
        #endregion
        basec bc = new basec();
        DataTable FACTORY_AREA_dr_worktime_standard =new DataTable(); //調用交班基準表 
        StringBuilder sqb = new StringBuilder();
        DataTable dt1 = new DataTable();//取得有關生產數據的數據表
        CKANBAN ckanban = new CKANBAN();
        DataTable dtt = new DataTable();//申明一個用于臨時數據存儲的DATATABLE
        SendMail sendmail = new SendMail();
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["cookiename"];
          
            if (!IsPostBack)
            {

                if (Request.QueryString["page"] != null && Request.QueryString["page"] != "")
                {
                    page.Value = Request.QueryString["page"].ToString();

                }
               
                bind();
                Bind("");
            }
            try
            {

       
            }
            catch (Exception ex)
            {
                sendmail.send_email("WEB 成型看板出現異常",ex.Message+
                    ckanban.error_info("view.aspx",cookie.Values["IP"].ToString (),cookie.Values["START_TIME"].ToString()) ,
                    sendmail.LIST , "mes_admin@acesconn.com");
                hint.Value = "網絡鏈接中斷";
            }
        }
        #region bind
        private void bind()
        {
           
            DataTable dt = ckanban.RETURN_DT();
        }
        #endregion
        #region Bind
        protected void Bind(string machine_area_id)
        {

            DataTable dt = ckanban.RETURN_DT();
            DataTable dtx = dt;

            DataTable dtx2 = bc.getdt("SELECT TOP 5.* FROM WORKORDER_MST WHERE STATUS<>'COMPLETE' ORDER BY WOID ASC");
    
            dtt.Columns.Add("MACHINE_AREA_ID", typeof(string));
            dtt.Columns.Add("PAGE", typeof(string));
            if (dtx2.Rows.Count > 0)
            {
             
                for (int i = 0; i < dtx2.Rows.Count; i++)
                {
                    DataRow dr = dtt.NewRow();
                    dr["MACHINE_AREA_ID"] = dtx2.Rows[i]["WOID"].ToString();
                    dr["PAGE"] = (i + 1).ToString();
                    dtt.Rows.Add(dr);
                }
            }
            machine_area_count.Value = dtt.Rows.Count.ToString();

         
            if (Request.QueryString["page"] != null && Request.QueryString["page"] != "")
            {
                if (Request.QueryString["page"].ToString() != "0")
                {
                    if (Request.QueryString["page"] != null && Request.QueryString["page"] != "")//分區顯示
                    {

                        dtt = bc.GET_DT_TO_DV_TO_DT(dtt, "", string.Format("PAGE='{0}'", Request.QueryString["page"].ToString()));
                        if (dtt.Rows.Count > 0)
                        {
                            MACHINE_AREA_ID = dtt.Rows[0]["MACHINE_AREA_ID"].ToString();
                        }
                        dtx = bc.GET_DT_TO_DV_TO_DT(dtx, "", string.Format("工单号='{0}'",
                             MACHINE_AREA_ID));
                    }
                }
                else
                {//全區顯示
                }
            }

            GridView1.DataSource = dtx;
            GridView1.DataBind();
          
        
          
        }
        #endregion
        private string datecka()
        {
            string ds = "";
            if (DateTime.Now.Hour >= 7 && DateTime.Now.Hour <= 23)
            {
                ds = DateTime.Now.AddDays(0).ToString("yyyy/MM/dd") + " 7:30";
            }
            else
            {
                ds = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd") + " 19:30";
            }
            return ds;
        }
        private DataTable RETURN_EMPTY_DT()
        {
            DataTable dtt = new DataTable();
            dtt.Columns.Add("TIME", typeof(string));
            dtt.Columns.Add("TOTAL_EFFICIENCY", typeof(string));
            dtt.Columns.Add("NOTOTAL_EFFICIENCY", typeof(string));
            return dtt;
        }
        private DataTable RETURN_EMPTY_DT_BUILDING()
        {
            DataTable dtt = new DataTable();
            dtt.Columns.Add("BUILD_NO", typeof(string));
            return dtt;
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["FACTORY_AREA"] = null;
            Session["PROCESS"] = null;
            ClearClientPageCache();
            Response.Redirect("Default.aspx"); 
        }
        public void ClearClientPageCache()
        {
            //清除浏览器缓存 
            Response.Buffer = true;
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
            Response.Expires = 0;
            Response.CacheControl = "no-cache";
            Response.Cache.SetNoStore();
        }

        protected void Chart1_Load(object sender, EventArgs e)
        {

        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
          

          
           
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
         
        }
      

    }
}