using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Security.Cryptography;
using System.Collections .Generic ;
using System.Net ;
namespace CMES
{
    public class basec
    {
        private string _IPV4;
        public string IPV4
        {
            set { _IPV4 = value; }
            get { return _IPV4; }
        }
        private string _ErrowInfo;
        public string ErrowInfo
        {
            set { _ErrowInfo = value; }
            get { return _ErrowInfo; }
        }
        private static bool _IFExecutionSUCCESS;
        public static bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        public String md_var_con_tw = "Data Source=192.168.26.32;Initial Catalog=MES2;User ID=mis;Password=service";
        public String md_var_con_tw2 = "Data Source=192.168.26.32;Initial Catalog=MES2;User ID=mis;Password=service";
        public String md_var_con_dg = "Data Source=192.168.1.24;Initial Catalog=MES2;User ID=mis;Password=cj/654";
        public String md_var_con_ks = "Data Source=192.168.8.13;Initial Catalog=MES2;User ID=mis;Password=cj/654";
        public String md_var_con_cg = "Data Source=192.168.25.9;Initial Catalog=MES;User ID=mis;Password=cj/654";
        public String md_var_con_terry = "Data Source=127.0.0.1;Initial Catalog=MES2;User ID=mis;Password=cj/654";

        public basec()
        {
      
        }
        #region md_GetConnectionString() //獲取各廠區鏈接字符串
        public string md_GetConnectionString(string FACTORY_AREA_code)
        {
            string getconn = "";
            switch (FACTORY_AREA_code)
            {
                case "TW":
                    getconn = md_var_con_tw;
                    break;
                case "T":
                    getconn = md_var_con_tw;
                    break;
                case "KS":
                    getconn = md_var_con_ks;
                    break;
                case "K":
                    getconn = md_var_con_ks;
                    break;
                case "DG":
                    getconn = md_var_con_dg;
                    break;
                case "D":
                    getconn = md_var_con_dg;
                    break;
                case "CG":
                    getconn = md_var_con_cg;
                    break;
                case "G":
                    getconn = md_var_con_cg;
                    break;
            }
            return getconn;
        }
        #endregion
        
        #region  建立数据库连接
        /// <summary>
        /// 建立数据库连接.
        /// </summary>
        /// <returns>返回SqlConnection对象</returns>
        public SqlConnection getcon(string sqlconnectionstring)
        {
            string M_str_sqlcon = sqlconnectionstring;
            SqlConnection myCon = new SqlConnection(M_str_sqlcon);
            return myCon;
        }
        public SqlConnection getcon()
        {
            string M_str_sqlcon = ConfigurationManager.AppSettings["ConnectionDB"].ToString();
            SqlConnection myCon = new SqlConnection(M_str_sqlcon);
            return myCon;
        }
        #endregion
        #region  执行SqlCommand命令
        /// <summary>
        /// 执行SqlCommand
        /// </summary>
        /// <param name="M_str_sqlstr">SQL语句</param>
        public void getcom(string M_str_sqlstr, string sqlconnectionstring)
        {
            SqlConnection sqlcon = this.getcon(sqlconnectionstring);
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(M_str_sqlstr, sqlcon);
            sqlcom.ExecuteNonQuery();
            sqlcom.Dispose();
            sqlcon.Close();
            sqlcon.Dispose();
        }
        #endregion
        DataTable dt = new DataTable();
        #region getcoms
        public static void getcoms(string M_str_sqlstr, string sqlconnectionstring)
        {
            basec bc=new basec ();
            SqlConnection sqlcon = bc.getcon(sqlconnectionstring);
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(M_str_sqlstr, sqlcon);
            sqlcom.ExecuteNonQuery();
            sqlcom.Dispose();
            sqlcon.Close();
            sqlcon.Dispose();
        }
        #endregion
        public DataTable getdt(string M_str_sql,string SQLConnectionString)
        {
            SqlConnection sqlcon = this.getcon(SQLConnectionString);
            SqlCommand sqlcom = new SqlCommand(M_str_sql, sqlcon);
            sqlcom.CommandTimeout = 600;//鏈接超時由默認30秒增加到10分鐘 160818
            SqlDataAdapter da = new SqlDataAdapter(sqlcom);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public DataTable getdt(string M_str_sql)
        {
            SqlConnection sqlcon = this.getcon();
            SqlCommand sqlcom = new SqlCommand(M_str_sql, sqlcon);
            sqlcom.CommandTimeout = 3600;
            SqlDataAdapter da = new SqlDataAdapter(sqlcom);
            DataTable dt = new DataTable();
            
            
            da.Fill(dt);
            return dt;
        }
        #region yesno
        public int yesno(string vars)
        {
            int k = 1;
            int i;
            for (i = 0; i < vars.Length; i++)
            {
                int p = Convert.ToInt32(vars[i]);
                if (p >= 48 && p <= 57 || p == 46)
                {
                    k = 1;
                }
                else
                {
                    k = 0; break;
                }

            }

            return k;

        }
        #endregion
        #region yesno_no_point
        public int yesno_no_point(string vars)
        {
            int k = 1;
            int i;
            for (i = 0; i < vars.Length; i++)
            {
                int p = Convert.ToInt32(vars[i]);
                if (p >= 48 && p <= 57)
                {
                    k = 1;
                }
                else
                {
                    k = 0; break;
                }

            }

            return k;

        }
        #endregion
        #region exists
        public bool exists(string sql, string sqlconnectionstring)
        {
            DataTable dtx1 = this.getdt(sql,sqlconnectionstring);
            if (dtx1.Rows.Count > 0)
                return true;
            else
                return false;
        }
        #endregion
        #region getOnlyString
        public string getOnlyString(string sql, string sqlconnectionstring)
        {
            string s2 = "";
            DataTable dtu2 = this.getdt(sql,sqlconnectionstring);
            if (dtu2.Rows.Count > 0)
            {
                s2 = dtu2.Rows[0][0].ToString();

            }

            return s2;
        }
        #endregion
        #region RETURN_UNTIL_CHAR
        public string RETURN_UNTIL_CHAR(string HAVE_NAME_STRING, char C1)
        {
            string v = "";
            if (HAVE_NAME_STRING.Length > 0)
            {
                int q = Convert.ToInt32(C1);
                for (int i = 0; i < HAVE_NAME_STRING.Length; i++)
                {
                    int p = Convert.ToInt32(HAVE_NAME_STRING[i]);

                    if (p != q)
                    {
                        v = v + HAVE_NAME_STRING[i];
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return v;
        }
        #endregion
        #region RETURN_FROM_RIGHT_UNTIL_CHAR
        public string RETURN_FROM_RIGHT_UNTIL_CHAR(string STRING_VALUE, char c)
        {
            string v = "";
            if (STRING_VALUE.Length > 0)
            {

                for (int i = STRING_VALUE.Length - 1; i > 0; i--)
                {

                    if (STRING_VALUE[i] != c)
                    {
                        v = STRING_VALUE[i] + v;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return v;
        }
        #endregion
        public void Show(string MessageInfo)
        {
            HttpContext.Current.Response.Write("<script language=javascript>alert('" + MessageInfo + "')</script>");
        }
        public void ShowP(string values, string PageURL)
        {
            HttpContext.Current.Response.Write("<script>alert('" + values + "');window.location.href='" + PageURL + "'</script>");
            HttpContext.Current.Response.End();
        }

        public byte[] GetMD5(string Password)
        {
            byte[] Encrypt=HashAlgorithm .Create ().ComputeHash (Encoding.Unicode .GetBytes (Password ));
            return Encrypt ;
        }
        #region  GET_IFExecutionSUCCESS_HINT_INFO
        public string  GET_IFExecutionSUCCESS_HINT_INFO(bool SET_IFExecutionSUCCESS)
        {
            string v = "";
            if (SET_IFExecutionSUCCESS == true)
            {

                v = "已保存成功!";
            }
            return v;
        }
        #endregion
        #region GetIP4Address //取得IPV4地址
        public string GetIP4Address()
        {
            string IPV4 = "";
            string hostName = Dns.GetHostName();
            System.Net.IPAddress[] addressList = Dns.GetHostAddresses(hostName);
            foreach (IPAddress IPA in addressList)
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IPV4 = IPA.ToString();
                }
            }
            return IPV4;
        }
        #endregion
        #region factorychoose //'廠別判定'接值說明 ip_in = 登入設備所屬網段
        public DataTable factorychoose(string ip_in)
        {
            string buff_return = "";
            dt = factorychoose();
            dt = GET_DT_TO_DV_TO_DT(dt, "", "IP='" + ip_in.Substring(0, 10) + "'");
            if (dt.Rows.Count > 0)
            {
                buff_return = dt.Rows[0]["FACTORY_AREA"].ToString();
            }
            else
            {
                buff_return = string.Format("您的ip位置:{0}為非控管位置，請與MIS連絡", ip_in);
            }
            return dt;
        }
        #endregion
        #region factorychoose //'取得所有廠別信息
        public DataTable factorychoose()
        {
            dt = new DataTable();
            dt.Columns.Add("IP", typeof(string));
            dt.Columns.Add("FACTORY_AREA", typeof(string));
            dt.Columns.Add("FACTORY_AREA_CODE", typeof(string));
            dt.Columns.Add("FABN", typeof(string));
            string[] tw = {"192.168.0.", "192.168.18", "192.168.19", "192.168.21", "192.168.20", 
                           "192.168.22", "192.168.26", "192.168.27", "192.168.28", "192.168.29"};
            foreach (string ip in tw)
            {
                DataRow dr = dt.NewRow();
                dr["IP"] = ip;
                dr["FACTORY_AREA"] = "臺灣";
                dr["FACTORY_AREA_CODE"] = "TW";
                dr["FABN"] = "T";
                dt.Rows.Add(dr);
            }
            string[] dg = { "192.168.1.", "192.168.3." };
            foreach (string ip in dg)
            {
                DataRow dr = dt.NewRow();
                dr["IP"] = ip;
                dr["FACTORY_AREA"] = "東莞";
                dr["FACTORY_AREA_CODE"] = "DG";
                dr["FABN"] = "D";
                dt.Rows.Add(dr);
            }
            string[] ks = { "192.168.12", "192.168.11", "192.168.10", "192.168.2.", "192.168.5.", "192.168.8.", "192.168.9.", "192.168.17" };
            foreach (string ip in ks)
            {
                DataRow dr = dt.NewRow();
                dr["IP"] = ip;
                dr["FACTORY_AREA"] = "昆山";
                dr["FACTORY_AREA_CODE"] = "KS";
                dr["FABN"] = "K";
                dt.Rows.Add(dr);
            }
         
            return dt;
        }
        #endregion
        #region machineBuildNo //根據IP取得設備需要查詢機臺的區域
        public string machineBuildNo(string sqlconnectionstring)
        {
            string search_machine_FACTORY_AREA= "";
            DataTable dt = this.getdt(@"SELECT * FROM dr_kanban_parameter_st 
WHERE drkp_hostip='" + GetIP4Address() + "'", sqlconnectionstring);
            if (dt.Rows.Count > 0)
            {
                search_machine_FACTORY_AREA = dt.Rows[0]["drkp_buildno"].ToString();
            }
            return search_machine_FACTORY_AREA ;
        }
        #endregion
        #region GET_DT_TO_DV_TO_DT
        public DataTable GET_DT_TO_DV_TO_DT(DataTable dt, string Sort, string RowFilter)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = RowFilter;
            dv.Sort = Sort;
            dt = dv.ToTable();
            return dt;
        }
        #endregion
        #region RETURN_NOHAVE_REPEAT_DT
        public DataTable RETURN_NOHAVE_REPEAT_DT(DataTable dt, string COLUMN_NAME)
        {
            DataTable dtt = new DataTable();
            dtt.Columns.Add("VALUE", typeof(string));
            if (dt.Rows.Count > 0)
            {
                dt = GET_DT_TO_DV_TO_DT(dt, "", COLUMN_NAME + " IS NOT NULL");
                foreach (DataRow dr1 in dt.Rows)
                {
                    if (dr1[COLUMN_NAME].ToString() == "")
                    {

                    }
                    else
                    {
                        DataTable dtt1 = GET_DT_TO_DV_TO_DT(dtt, "", string.Format("VALUE='{0}'", dr1[COLUMN_NAME].ToString()));
                        if (dtt1.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            DataRow dr = dtt.NewRow();
                            dr["VALUE"] = dr1[COLUMN_NAME].ToString();
                            dtt.Rows.Add(dr);
                        }
                    }
                }
            }

            return dtt;
        }
        #endregion

  
    }
}
