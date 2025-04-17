using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
using XizheC;
using System.Windows.Forms;

namespace XizheC
{
    public class CEDIT_RIGHT
    {
        basec bc = new basec();
        #region NATURE
        private string _sql;
        public string sql
        {
            set { _sql = value; }
            get { return _sql; }

        }
        private string _EXCEL_SENVEN;
        public string EXCEL_SENVEN
        {
            set { _EXCEL_SENVEN = value; }
            get { return _EXCEL_SENVEN; }
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
        private string _EMID;
        public string EMID
        {
            set { _EMID = value; }
            get { return _EMID; }

        }
        private string _USID;
        public string USID
        {
            set { _USID = value; }
            get { return _USID; }

        }
        private string _NODEID;
        public string NODEID
        {
            set { _NODEID = value; }
            get { return _NODEID; }

        }
        private string _PARENT_NODEID;
        public string PARENT_NODEID
        {
            set { _PARENT_NODEID = value; }
            get { return _PARENT_NODEID; }

        }
        private string _NODE_NAME;
        public string NODE_NAME
        {
            set { _NODE_NAME = value; }
            get { return _NODE_NAME; }

        }
        private string _OPERATE;
        public string OPERATE
        {
            set { _OPERATE = value; }
            get { return _OPERATE; }

        }
        private string _SEARCH;
        public string SEARCH
        {
            set { _SEARCH = value; }
            get { return _SEARCH; }

        }
        private string _ADD_NEW;
        public string ADD_NEW
        {
            set { _ADD_NEW = value; }
            get { return _ADD_NEW; }

        }
        private string _EDIT;
        public string EDIT
        {
            set { _EDIT = value; }
            get { return _EDIT; }

        }
        private string _DEL;
        public string DEL
        {
            set { _DEL = value; }
            get { return _DEL; }

        }
        private string _MANAGE;
        public string MANAGE
        {
            set { _MANAGE = value; }
            get { return _MANAGE; }

        }
        private string _FINANCIAL;
        public string FINANCIAL
        {
            set { _FINANCIAL = value; }
            get { return _FINANCIAL; }

        }
        private string _GENERAL_MANAGE;
        public string GENERAL_MANAGE
        {
            set { _GENERAL_MANAGE = value; }
            get { return _GENERAL_MANAGE; }

        }
        private string _OFFER_AUDIT;
        public string OFFER_AUDIT
        {
            set { _OFFER_AUDIT = value; }
            get { return _OFFER_AUDIT; }
        }
        private string _OFFER_DATE_SEARCH;
        public string OFFER_DATE_SEARCH
        {
            set { _OFFER_DATE_SEARCH = value; }
            get { return _OFFER_DATE_SEARCH; }
        }
        private string _SAMPLE_AUDIT;
        public string SAMPLE_AUDIT
        {
            set { _SAMPLE_AUDIT = value; }
            get { return _SAMPLE_AUDIT; }
        }
        private string _FILE_UPLOAD;
        public string FILE_UPLOAD
        {
            set { _FILE_UPLOAD = value; }
            get { return _FILE_UPLOAD; }
        }
        private string _PAPER_AUDIT;
        public string PAPER_AUDIT
        {
            set { _PAPER_AUDIT = value; }
            get { return _PAPER_AUDIT; }
        }
        private string _ACRYLIC_AUDIT;
        public string ACRYLIC_AUDIT
        {
            set { _ACRYLIC_AUDIT = value; }
            get { return _ACRYLIC_AUDIT; }
        }
        private string _WOOD_IRON_AUDIT;
        public string WOOD_IRON_AUDIT
        {
            set { _WOOD_IRON_AUDIT = value; }
            get { return _WOOD_IRON_AUDIT; }
        }
        private string _PURCHASE_AUDIT;
        public string PURCHASE_AUDIT
        {
            set { _PURCHASE_AUDIT = value; }
            get { return _PURCHASE_AUDIT; }
        }
        private string _EXCEL_ONE;
        public string EXCEL_ONE
        {
            set { _EXCEL_ONE = value; }
            get { return _EXCEL_ONE; }
        }
        private string _EXCEL_TWO;
        public string EXCEL_TWO
        {
            set { _EXCEL_TWO = value; }
            get { return _EXCEL_TWO; }
        }
        private string _EXCEL_THREE;
        public string EXCEL_THREE
        {
            set { _EXCEL_THREE = value; }
            get { return _EXCEL_THREE; }
        }
        private string _EXCEL_FOUR;
        public string EXCEL_FOUR
        {
            set { _EXCEL_FOUR = value; }
            get { return _EXCEL_FOUR; }
        }
        private string _EXCEL_FIVE;
        public string EXCEL_FIVE
        {
            set { _EXCEL_FIVE = value; }
            get { return _EXCEL_FIVE; }
        }
        private string _EXCEL_SIX;
        public string EXCEL_SIX
        {
            set { _EXCEL_SIX = value; }
            get { return _EXCEL_SIX; }
        }
        #endregion
        string setsql = @"
SELECT
A.UNAME AS 用户名,
B.EName AS 姓名,
C.NODE_NAME AS 作业名称,
CASE WHEN C.OPERATE='Y' AND  C.NODE_NAME NOT IN ('工单作业')  THEN '有权限'
WHEN C.OPERATE='N' AND C.NODE_NAME NOT IN ('工单作业') THEN '无权限'
ElSE ''
END AS 操作权限,
CASE WHEN C.SEARCH='Y'  THEN ''
WHEN C.SEARCH='N' THEN ''
ELSE ''
END AS 查询权限,
CASE WHEN C.ADD_NEW='Y' AND  C.NODE_NAME  IN ('工单作业') THEN '有权限'
WHEN C.ADD_NEW='N' AND  C.NODE_NAME  IN ('工单作业') THEN '无权限'
ELSE ''
END AS 新增权限,
CASE WHEN C.EDIT='Y' AND  C.NODE_NAME  IN ('工单作业') THEN '有权限'
WHEN C.EDIT='N' AND  C.NODE_NAME  IN ('工单作业') THEN '无权限'
ELSE ''
END AS 修改权限,
CASE WHEN C.DEL='Y' AND  C.NODE_NAME  IN ('工单作业') THEN '有权限'
WHEN C.DEL='N' AND  C.NODE_NAME  IN ('工单作业') THEN '无权限'
ELSE ''
END AS 删除权限,
CASE WHEN D.SCOPE='Y' THEN '所有用户'
WHEN D.SCOPE='GROUP' THEN '本组用户'
ELSE '当前用户'
END AS '授权范围',
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=C.MAKERID) AS 制单人,
C.DATE AS 制单日期 
FROM  
USERINFO  A 
LEFT JOIN EMPLOYEEINFO B ON A.EMID=B.EMID
LEFT JOIN RIGHTLIST C ON A.USID=C.USID
LEFT JOIN SCOPE_OF_AUTHORIZATION D ON A.USID=D.USID

";

        string setsqlo = @"
INSERT INTO 
RIGHTLIST
(
USID,
NodeID,
NODE_NAME,
PARENT_NODEID,
OPERATE,
SEARCH,
ADD_NEW,
EDIT,
DEL,
MakerID,
Date
)
VALUES
(
@USID,
@NodeID,
@NODE_NAME,
@PARENT_NODEID,
@OPERATE,
@SEARCH,
@ADD_NEW,
@EDIT,
@DEL,
@MakerID,
@Date
)

";
        
        public CEDIT_RIGHT()
        {
            sql = setsql; /*WAREINFO*/
            sqlo = setsqlo; /*ORDER*/
           
        }
        #region SQlcommandE
        public  void SQlcommandE()
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
            SqlConnection sqlcon = bc.getcon();
            SqlCommand sqlcom = new SqlCommand(setsqlo, sqlcon);
            sqlcom.Parameters.Add("USID", SqlDbType.VarChar, 20).Value = USID;
            sqlcom.Parameters.Add("NodeID", SqlDbType.VarChar, 20).Value = NODEID;
            sqlcom.Parameters.Add("NODE_NAME", SqlDbType.VarChar, 20).Value = NODE_NAME;
            sqlcom.Parameters.Add("PARENT_NODEID", SqlDbType.VarChar, 20).Value = PARENT_NODEID;
            sqlcom.Parameters.Add("OPERATE", SqlDbType.VarChar, 20).Value = OPERATE;
            sqlcom.Parameters.Add("SEARCH", SqlDbType.VarChar, 20).Value = SEARCH;
            sqlcom.Parameters.Add("ADD_NEW", SqlDbType.VarChar, 20).Value = ADD_NEW;
            sqlcom.Parameters.Add("EDIT", SqlDbType.VarChar, 20).Value = EDIT;
            sqlcom.Parameters.Add("DEL", SqlDbType.VarChar, 20).Value = DEL;
     
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = EMID;
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion
        #region SQlcommandE_USER_GROUP_USERD
        public void SQlcommandE_USER_GROUP_USERD(DataTable dt,string USID,string EMID,string USER_GROUP)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
            basec.getcoms("DELETE RIGHTLIST WHERE USID='"+USID +"'");
            bc.getcom("DELETE SCOPE_OF_AUTHORIZATION WHERE USID='" + USID  + "'");
            DataTable dt1 = bc.getdt("SELECT * FROM SCOPE_OF_AUTHORIZATION WHERE USID='" +USER_GROUP + "'");
            if (dt1.Rows.Count > 0)
            {
                //MessageBox.Show(dt1.Rows[0]["USID"].ToString() + "," + dt1.Rows[0]["SCOPE"].ToString());
                bc.getcom(string .Format ("INSERT INTO SCOPE_OF_AUTHORIZATION(USID,SCOPE) VALUES ('{0}','{1}')",USID ,dt1.Rows [0]["SCOPE"].ToString ()));
            }
            foreach (DataRow dr in dt.Rows)
            {
                SqlConnection sqlcon = bc.getcon();
                SqlCommand sqlcom = new SqlCommand(setsqlo, sqlcon);
                sqlcom.Parameters.Add("USID", SqlDbType.VarChar, 20).Value = USID;
                sqlcom.Parameters.Add("NodeID", SqlDbType.VarChar, 20).Value = dr["NodeID"].ToString();
                sqlcom.Parameters.Add("NODE_NAME", SqlDbType.VarChar, 20).Value = dr["NODE_NAME"].ToString();
                sqlcom.Parameters.Add("PARENT_NODEID", SqlDbType.VarChar, 20).Value = dr["PARENT_NODEID"].ToString();
                sqlcom.Parameters.Add("OPERATE", SqlDbType.VarChar, 20).Value = dr["OPERATE"].ToString();
                sqlcom.Parameters.Add("SEARCH", SqlDbType.VarChar, 20).Value = dr["SEARCH"].ToString();
                sqlcom.Parameters.Add("ADD_NEW", SqlDbType.VarChar, 20).Value = dr["ADD_NEW"].ToString();
                sqlcom.Parameters.Add("EDIT", SqlDbType.VarChar, 20).Value = dr["EDIT"].ToString();
                sqlcom.Parameters.Add("DEL", SqlDbType.VarChar, 20).Value = dr["DEL"].ToString();

                sqlcom.Parameters.Add("MAKERID", SqlDbType.VarChar, 20).Value = EMID;
                sqlcom.Parameters.Add("DATE", SqlDbType.VarChar, 20).Value = varDate;
                sqlcon.Open();
                sqlcom.ExecuteNonQuery();
                sqlcon.Close();
            }
        }
        #endregion
        #region RETURN_RIGHT_LIST
        public DataTable RETURN_RIGHT_LIST(string NODE_NAME ,string USID)
        {
            DataTable dt = bc.getdt(sql + string.Format(" WHERE C.NODE_NAME='{0}' AND A.USID='{1}'", NODE_NAME , USID ));
            return dt;
        }
        #endregion
    }
}
