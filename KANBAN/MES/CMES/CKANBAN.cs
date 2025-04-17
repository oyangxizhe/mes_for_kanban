using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using CMES;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text ;

namespace CMES
{
    public class CKANBAN
    {
        basec bc = new basec();
        StringBuilder sqb=new StringBuilder();
        SendMail sendmail=new SendMail ();
        #region nature
        private string _ErrowInfo;
        public string ErrowInfo
        {

            set { _ErrowInfo = value; }
            get { return _ErrowInfo; }

        }
        private string _USID;
        public string USID
        {
            set { _USID = value; }
            get { return _USID; }

        }
        private string _UNAME;
        public string UNAME
        {
            set { _UNAME = value; }
            get { return _UNAME; }

        }
        private string _EMID;
        public string EMID
        {
            set { _EMID = value; }
            get { return _EMID; }

        }
        private string _GEID;
        public string GEID
        {
            set { _GEID = value; }
            get { return _GEID; }

        }
        private string _ENAME;
        public string ENAME
        {
            set { _ENAME = value; }
            get { return _ENAME; }

        }
        private string _DEPART;
        public string DEPART
        {
            set { _DEPART = value; }
            get { return _DEPART; }

        }
        private string _USER_GROUP;
        public string USER_GROUP
        {
            set { _USER_GROUP = value; }
            get { return _USER_GROUP; }

        }
        private string _MAKERID;
        public string MAKERID
        {
            set { _MAKERID = value; }
            get { return _MAKERID; }

        }
        private string _PWD;
        public string PWD
        {
            set { _PWD = value; }
            get { return _PWD; }

        }
        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        private string _sql;
        public string sql
        {
            set { _sql = value; }
            get { return _sql; }

        }
        private string _sqlo;
        public string sqlo
        {
            set { _sqlo = value; }
            get { return _sqlo; }

        }
        private string _sqlt;
        public string sqlt
        {
            set { _sqlt = value; }
            get { return _sqlt; }

        }
        private string _sqlth;
        public string sqlth
        {
            set { _sqlth = value; }
            get { return _sqlth; }

        }
        private string _sqlf;
        public string sqlf
        {
            set { _sqlf = value; }
            get { return _sqlf; }

        }
        private string _sqlfi;
        public string sqlfi
        {
            set { _sqlfi = value; }
            get { return _sqlfi; }

        }
        #endregion
        #region sql
        string setsql = @"


";
        string setsqlo = @"

SELECT
A.WOID AS 工单号,
A.WAREID AS 物料编号,
A.CNAME AS 客户名称,
B.CO_WAREID AS 料号,
B.WNAME AS 品名,
B.SPEC AS 规格,
E.FCID AS 途程编号,
F.FLOW_CHART_ID AS 途程代码,
F.FLOW_CHART AS 途程名称,
A.FLOW_CHART_EDITION AS 途程版本,
E.SN AS 项次,
G.STID AS 站别编号,
G.STEP AS 站别名称,
CASE WHEN A.STATUS='OPEN' THEN '开立'
WHEN A.STATUS='PROCESS' THEN '生产中'
WHEN A.STATUS='SCRAP' THEN '作废'
WHEN A.STATUS='COMPLETE' THEN '结案'
END 
AS 状态,
A.GODE_NEED_DATE AS 下单日期,
E.STEP_PLAN_COMPLETE_DATE AS 预计完工日期,
E.STEP_COMPLETE_DATE AS 完工日期,
E.REMARK AS 备注,
E.SCHEDULE AS 进度,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID) AS 制单人,
A.DATE AS 制单日期
FROM WORKORDER_MST A
LEFT JOIN WAREINFO B ON A.WAREID=B.WAREID
LEFT JOIN BOM_MST D ON A.BOID=D.BOID
LEFT JOIN WORKORDER_DET E ON A.WOID=E.WOID
LEFT JOIN FLOW_CHART_MST F ON E.FCID=F.FCID
LEFT JOIN STEP G ON E.STID=G.STID
WHERE A.STATUS<>'COMPLETE'
ORDER BY E.WOKEY ASC

";
        /*WHERE A.WOID IN (SELECT TOP 10 WOID FROM WORKORDER_MST WHERE STATUS!='COMPLETE' ORDER BY WOID ASC)*/

        string setsqlt = @"
 

";
        string setsqlth = @""
;



        #endregion
        public CKANBAN()
        {
            sql = setsql;
            sqlo = setsqlo;
            sqlt = setsqlt;
            sqlth = setsqlth;
        }
        public DataTable RETURN_DT()
        {
            DataTable dtx = bc.getdt(sqlo);
       
            return dtx;
        }
        public string  error_info(string aspx,string IP,string START_TIME)
        {
                string b="";
                sqb = new StringBuilder();
                sqb.AppendFormat("error come from "+aspx+" client ip {0}",IP);
                sqb.AppendFormat(" 登陸時間 {0} ", START_TIME);
                sqb.AppendFormat(" 中斷運行時間 {0} ", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").Replace("-", "/"));
                if (!string.IsNullOrEmpty(START_TIME))
                {
                    DateTime date1 = DateTime.Now;
                    DateTime date2 = DateTime.Parse(START_TIME);
                    TimeSpan ts = date1 - date2;
                    sqb.AppendFormat(" 持續運行時間 {0} ", ts.Days.ToString() + "天" + ts.Hours.ToString() + "小時" + 
                        ts.Minutes.ToString() + "分。");
                    sqb.AppendFormat(" 出現此MAIL不表示看板真的中斷運行，只是參考有這個可能 ");
                }
                b = sqb.ToString();
                return b;
            }
    }
}
