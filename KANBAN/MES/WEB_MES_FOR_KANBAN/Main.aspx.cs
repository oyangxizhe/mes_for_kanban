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
    public partial class Main : System.Web.UI.Page
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
        private  string _IP;
        public  string IP
        {
            set { _IP = value; }
            get { return _IP; }

        }
        private static int _UPDATE;
        public static int UPDATE
        {
            set { _UPDATE = value; }
            get { return _UPDATE; }

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
            
            if (Request.QueryString["page"] == null)
            {
                Response.Redirect("main.aspx?page=1");
            }
       
             
                string ip = Context.Request.ServerVariables["REMOTE_ADDR"].ToString();
                if (ip == "::1")//如果取到的是IPV6的本機地址，那么調用本機IP,否則就是調用客戶端IP
                {
                    IP = bc.GetIP4Address();
                }
                else
                {
                    IP = ip;
                }
                HttpCookie cookie = new HttpCookie("cookiename");
                cookie.Values.Add("IF_LOGIN", "Y");
                cookie.Values.Add("IP", IP);
                cookie.Values.Add("START_TIME", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").Replace("-", "/"));
                Response.AppendCookie(cookie);
                cookie.Expires = DateTime.Now.AddDays(365);
                if (!IsPostBack)
                {
                    ShowByStringLabel.Text = "";
                    if (Request.QueryString["page"] != null && Request.QueryString["page"] != "")
                    {
                        page.Value = Request.QueryString["page"].ToString();
                    }
                    dt1 = ckanban.RETURN_DT();
                    bind();
                    Bind("");
                }
                hint.Value = "";
                try
                {


                }
                catch (Exception)
                {
                    hint.Value = "網絡鏈接中斷";
                }

      

        }
        #region bind
        private void bind()
        {
    

        
            HttpCookie cookie = Request.Cookies["cookiename"];//cookie不能在服務器歘漢字會報錯，歘字母就好
            //L1.Text += "最后更新時間" + dt1.Rows[0]["更新時間"].ToString();
          
 
            LinkButton1.ForeColor = Color.FromName("#4D784D");
            L1.ForeColor = Color.FromName("#4D784D");
            L2.ForeColor = Color.FromName("#4D784D");
            L3.ForeColor = Color.FromName("#4D784D");
            L4.ForeColor = Color.FromName("#4D784D");
            L4.Text = "當前IP " + cookie.Values["IP"].ToString();
           
           
        }
        #endregion
        #region chart
        private void chart(double mr,Dundas.Gauges.WebControl.GaugeContainer GN )//圖表顏色區域設置
        {
            //嫁動率
            if (mr >= 50)
            {
                GN.CircularGauges[0].Ranges[0].FillColor = Color.Green;
                GN.CircularGauges[0].Ranges[0].StartValue = 50;
                GN.CircularGauges[0].Ranges[0].EndValue = 100;
            }
            else
            {
                GN.CircularGauges[0].Ranges[0].FillColor = Color.Red;
                GN.CircularGauges[0].Ranges[0].StartValue = 49;
                GN.CircularGauges[0].Ranges[0].EndValue = 0;
            }    
        }
        #endregion
        #region chart1
        private void chart1(Dundas.Gauges.WebControl.GaugeContainer GN)//圖表顏色區域設置
        {
            GN.CircularGauges[0].Scales[0].StartAngle = 90;//1/2顯示半圓區域
            GN.CircularGauges[0].Scales[0].SweepAngle = 180;//2/2顯示半圓區域
            GN.CircularGauges[0].Scales[0].Maximum = 100;
            GN.CircularGauges[0].Scales[0].ShadowOffset = 0;
            GN.CircularGauges[0].Scales[0].Width = 2;
            GN.CircularGauges[0].Scales[0].FillColor = Color.Black;
            GN.CircularGauges[0].Scales[0].Radius = 32;
            GN.CircularGauges[0].Scales[0].LabelStyle.Font = new Font("", 8, FontStyle.Regular);
            GN.CircularGauges[0].Scales[0].LabelStyle.Placement = Dundas.Gauges.WebControl.Placement.Outside;
            GN.CircularGauges[0].Scales[0].LabelStyle.FontUnit = Dundas.Gauges.WebControl.FontUnit.Default;
            GN.CircularGauges[0].Scales[0].MajorTickMark.Width = 2;
            GN.CircularGauges[0].Scales[0].MajorTickMark.EnableGradient = false;
            GN.CircularGauges[0].Scales[0].MajorTickMark.BorderWidth = 0;
            GN.CircularGauges[0].Scales[0].MajorTickMark.FillColor = Color.Black;
            GN.CircularGauges[0].Scales[0].MajorTickMark.Length = 12;
            GN.CircularGauges[0].Scales[0].MajorTickMark.Shape = Dundas.Gauges.WebControl.MarkerStyle.Rectangle;
            GN.CircularGauges[0].Scales[0].MajorTickMark.Placement = Dundas.Gauges.WebControl.Placement.Outside;

            GN.CircularGauges[0].Scales[0].MinorTickMark.Width = 2;
            GN.CircularGauges[0].Scales[0].MinorTickMark.Placement = Dundas.Gauges.WebControl.Placement.Outside;

            GN.CircularGauges[0].BackFrame.FrameWidth = 0;
            GN.CircularGauges[0].BackFrame.FrameStyle = Dundas.Gauges.WebControl.BackFrameStyle.Simple;
            GN.CircularGauges[0].BackFrame.BorderColor = Color.Silver;
            GN.CircularGauges[0].BackFrame.BackGradientEndColor = CCOLOR.chart1;
            GN.CircularGauges[0].BackFrame.BackColor = Color.White;
            GN.CircularGauges[0].BackFrame.BackGradientType = Dundas.Gauges.WebControl.GradientType.TopBottom;
            GN.CircularGauges[0].BackFrame.BorderWidth = 2;
            GN.CircularGauges[0].BackFrame.FrameShape = Dundas.Gauges.WebControl.BackFrameShape.AutoShape;//顯示背景距形區域
            GN.CircularGauges[0].BackFrame.FrameStyle = Dundas.Gauges.WebControl.BackFrameStyle.Simple;//顯示背景距形區域1/3
            GN.CircularGauges[0].Size.Width = 60;
            GN.CircularGauges[0].Size.Height = 60;
            GN.CircularGauges[0].Scales[0].SweepAngle = 180;//2/2顯示半圓區域
            GN.CircularGauges[0].PivotPoint.X = 50;
            GN.CircularGauges[0].PivotPoint.Y = 70;

            GN.CircularGauges[0].Pointers[0].DistanceFromScale = 8;
            GN.CircularGauges[0].Pointers[0].NeedleStyle = Dundas.Gauges.WebControl.NeedleStyle.NeedleStyle4;
            GN.CircularGauges[0].Pointers[0].FillGradientEndColor = Color.White;
            GN.CircularGauges[0].Pointers[0].FillColor = Color.Red;
            GN.CircularGauges[0].Pointers[0].BorderWidth = 0;
            GN.CircularGauges[0].Pointers[0].ShadowOffset = 1;
            GN.CircularGauges[0].Pointers[0].Placement = Dundas.Gauges.WebControl.Placement.Outside;
            GN.CircularGauges[0].Pointers[0].Value = 68;

            GN.CircularGauges[0].Ranges[0].BorderWidth = 0;
            GN.CircularGauges[0].Ranges[0].StartWidth = 300;
            GN.CircularGauges[0].Ranges[0].FillGradientEndColor = Color.Yellow;
            GN.CircularGauges[0].Ranges[0].FillColor = Color.Pink;
            GN.CircularGauges[0].Ranges[0].DistanceFromScale = -80;//控制背景顏色區域
            GN.CircularGauges[0].Ranges[0].EndWidth = 300;
            GN.CircularGauges[0].Ranges[0].FillGradientType = Dundas.Gauges.WebControl.RangeGradientType.None;
            //GaugeContainer3.BackFrame.FrameStyle = Dundas.Gauges.WebControl.BackFrameStyle.Simple;//顯示背景距形區域1/3
            //GaugeContainer3.BackFrame.BackGradientType = Dundas.Gauges.WebControl.GradientType.TopBottom;//顯示背景距形區域2/3
            //GaugeContainer3.BackFrame.FrameShape = Dundas.Gauges.WebControl.BackFrameShape.AutoShape;//顯示背景距形區域3/3
            GN.BackFrame.BorderColor = Color.Silver;
            GN.BackFrame.BackGradientEndColor = CCOLOR.chart1;
            GN.BackFrame.BackColor = Color.White;
            GN.BackFrame.BorderWidth = 2;
            GN.BackFrame.FrameStyle = Dundas.Gauges.WebControl.BackFrameStyle.None;
            GN.BackFrame.FrameGradientType = Dundas.Gauges.WebControl.GradientType.None;

            GN.Labels[0].ResizeMode = Dundas.Gauges.WebControl.ResizeMode.None;
            GN.Labels[0].TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            GN.Labels[0].Text = "JLS";
            GN.Labels[0].Size.Height = 100;
            GN.Labels[0].Size.Width = 100;
            GN.Labels[0].Location.X = 0;
            GN.Labels[0].Location.Y = 5;
        }
        #endregion
        #region Bind
        protected void Bind(string machine_area_id)
        {

            DataTable dt = ckanban.RETURN_DT();
            DataTable dtx = new DataTable();
            DataTable dtx2 = bc.getdt("SELECT TOP 5.* FROM WORKORDER_MST WHERE STATUS<>'COMPLETE' ORDER BY WOID ASC");
 
            dtt = new DataTable();
            dtt.Columns.Add("MACHINE_AREA_ID", typeof(string));
            dtt.Columns.Add("PAGE", typeof(string));
            if (dtx2.Rows.Count > 0)
            {
          
                for (int i = 0; i < dtx2.Rows.Count; i++)
                {
                    DataRow dr = dtt.NewRow();
                    dr["MACHINE_AREA_ID"] = "工单号："+dtx2.Rows[i]["WOID"].ToString();
                    dr["PAGE"] = (i+1).ToString();
                    dtt.Rows.Add(dr);
                }
            }
            machine_area_count.Value = dtt.Rows.Count.ToString();
            DataList2.DataSource = dtt;
            DataList2.DataBind();
            ShowByStringLabel.Text = " ";
            ShowByStringLabel.ForeColor = CCOLOR.BLUE;
            ShowByStringLabel.Font.Bold = true;
            ShowByStringLabel.Font.Name = "新細明體";
            ShowByStringLabel.Font.Size = 12;
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
            HttpCookie cookie = Request.Cookies["cookiename"];
            cookie.Expires = DateTime.Now.AddDays(-365);
            Response.Cookies.Add (cookie);
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
   
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
    
        }
    }
}