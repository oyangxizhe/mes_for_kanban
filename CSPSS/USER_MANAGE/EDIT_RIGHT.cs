using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using XizheC;
namespace CSPSS.USER_MANAGE
{
    public partial class EDIT_RIGHT : Form
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();
        basec bc = new basec();
        CUSER cuser = new CUSER();
        CEDIT_RIGHT cedit_right = new CEDIT_RIGHT();
        CUSER_GROUP cuser_group = new CUSER_GROUP();
        #region nature
        private static string _UNAME;
        public static string UNAME
        {
            set { _UNAME = value; }
            get { return _UNAME; }
        }
        private string _GET_DATA_INT;
        public string GET_DATA_INT
        {
            set { _GET_DATA_INT = value; }
            get { return _GET_DATA_INT; }
        }
        private string _IDO;
        public string IDO
        {
            set { _IDO = value; }
            get { return _IDO; }

        }
        private string _USID;
        public string USID
        {
            set { _USID = value; }
            get { return _USID; }
        }
        private string _USER_GROUP_CHECKED;
        public  string USER_GROUP_CHECKED
        {
            set { _USER_GROUP_CHECKED = value; }
            get { return _USER_GROUP_CHECKED; }
        }
        private static string _ENAME;
        public static string ENAME
        {
            set { _ENAME = value; }
            get { return _ENAME; }

        }
        private static bool _IF_DOUBLE_CLICK;
        public static bool IF_DOUBLE_CLICK
        {
            set { _IF_DOUBLE_CLICK = value; }
            get { return _IF_DOUBLE_CLICK; }

        }
        private string _OFFER_AUDIT_AUDIT;
        public string OFFER_AUDIT_AUDIT
        {
            set { _OFFER_AUDIT_AUDIT = value; }
            get { return _OFFER_AUDIT_AUDIT; }
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
        private string _EXCEL_SENVEN;
        public string EXCEL_SENVEN
        {
            set { _EXCEL_SENVEN = value; }
            get { return _EXCEL_SENVEN; }
        }
        private string _FILE_UPLOAD;
        public string FILE_UPLOAD
        {
            set { _FILE_UPLOAD = value; }
            get { return _FILE_UPLOAD; }
        }
        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

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
        StringBuilder sqb = new StringBuilder();
        protected int M_int_judge, i,j;
        public bool blInitial = true;
        Color c1 = System.Drawing.ColorTranslator.FromHtml("#c0c0c0");
        Color c2 = System.Drawing.ColorTranslator.FromHtml("#990033");
        public EDIT_RIGHT()
        {
            InitializeComponent();
      
        }

        private void EDIT_RIGHT_Load(object sender, EventArgs e)
        {
         
            dataGridView2.ColumnHeadersHeight = 38;
        
            if (Screen.AllScreens[0].Bounds.Width == 1366 && Screen.AllScreens[0].Bounds.Height == 768)
            {
             
                this.AutoScroll = true;
                this.AutoScrollMinSize = new Size(1000, 1080);
            }
            else if (Screen.AllScreens[0].Bounds.Width == 1920 && Screen.AllScreens[0].Bounds.Height == 1080)
            {

            }
            else
            {
                this.AutoScroll = true;
                this.AutoScrollMinSize = new Size(1920, 1080);
            }
     
            try
            {
                radioButton1.Checked = true;//默认授所有权限
                this.Icon = new Icon(System.IO.Path.GetFullPath("Image/xz 200X200.ico"));
                Bind(LOGIN.USID);
                textBox1.Text = IDO;
             
                dt3 = bc.getdt(cuser_group.sql);
                
                dt3 = cuser_group.RETURN_HAVE_ID_DT(dt3);
                dataGridView3.DataSource = dt3;
                Bind1(dataGridView3);
                radioButton6.Checked = true;

                label1.Text = "(1.背景色为浅灰色的复选框无需点选为不可用)";
                label1.ForeColor = c2;
                label4.Text = "(2.授权范围指该用户名只能查看自己做的凭证还是可以查看所有用户做的凭证)";
                label4.ForeColor = c2;

                comboBox2.DataSource = bc.RETURN_ADD_EMPTY_COLUMN("DEPART", "DEPART");
                comboBox2.DisplayMember = "DEPART";
                comboBox2.BackColor = Color.Yellow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
          
        }
        #region GetTableInfo
        public DataTable GetTableInfo(DataTable dtx)
        {
          DataTable  dtx1 = GetTableInfo();
            if (dtx.Rows.Count > 0)
            {
                foreach (DataRow dr1 in dtx.Rows)
                {
                    DataRow dr = dtx1.NewRow();
                    dr["复选框"] = false;
                    dr["作业名称"] = dr1["NODE_NAME"].ToString();
                    dr["查询"] = false;
                    dr["新增"] = false;
                    dr["修改"] = false;
                    dr["删除"] = false;
               
                    dtx1.Rows.Add(dr);
                }
            }
            return dtx1;
        }
        #endregion
        #region GetTableInfo
        public DataTable GetTableInfo()
        {
            dt = new DataTable();
            dt.Columns.Add("复选框", typeof(bool));
            dt.Columns.Add("作业名称", typeof(string));
            dt.Columns.Add("查询", typeof(bool));
            dt.Columns.Add("新增", typeof(bool));
            dt.Columns.Add("修改", typeof(bool));
            dt.Columns.Add("删除", typeof(bool));

            return dt;
        }
        #endregion
        #region bind
        private void Bind(string USID)
        {
         
            DataTable dty = bc.getdt("SELECT * FROM RIGHTLIST WHERE USID='" + USID + "' ORDER BY NODEID ASC" );
            sqb = new StringBuilder();
            sqb.Append("SELECT * FROM RIGHTNAME");
            sqb.AppendFormat(" WHERE NODE_NAME!= '{0}'", "基础资料");
            sqb.AppendFormat(" AND NODE_NAME!= '{0}'", "工单管理");
            sqb.AppendFormat(" AND NODE_NAME!= '{0}'", "生产管理");
            sqb.AppendFormat(" AND NODE_NAME!='{0}'", "用户管理");
            dt = bc.getdt(sqb .ToString ());
            dt = GetTableInfo(dt);
            radioButton3.Checked = true;
            if (dty.Rows.Count > 0)
            {
              
                foreach (DataRow dr1 in dty.Rows)
                {
                    foreach (DataRow dr in dt.Rows)
                    {

                        if (dr1["NODE_NAME"].ToString() == dr["作业名称"].ToString())
                        {
                            if (dr1["NODE_NAME"].ToString() == "工单作业"
                                )
                            {
                                
                                if (dr1["ADD_NEW"].ToString() == "Y")
                                {
                                    dr["新增"] = true;
                                }
                    
                                if (dr1["EDIT"].ToString() == "Y")
                                {
                                    dr["修改"] = true;
                                }
                        
                                if(dr1["DEL"].ToString() == "Y")
                                {
                                    dr["删除"] = true;
                                }
                      
                            }
                            else
                            {
                                if (dr1["OPERATE"].ToString() == "Y")
                                {
                                    dr["复选框"] = true;
                                }
                            }
                            break;
                        }
                    }
                }
            
                if (bc.getOnlyString("SELECT SCOPE FROM SCOPE_OF_AUTHORIZATION WHERE USID='" + USID + "'") == "Y")
                {
                    radioButton1.Checked = true;

                }
                else if (bc.getOnlyString("SELECT SCOPE FROM SCOPE_OF_AUTHORIZATION WHERE USID='" + USID + "'") == "GROUP")
                {
                    radioButton2.Checked = true;
                }
                else
                {

                    radioButton3.Checked = true;
                }
             
            }
         
            dataGridView1.DataSource = dt;
         
     
            this.WindowState = FormWindowState.Maximized;
            
            string a = bc.getOnlyString("SELECT UNAME FROM USERINFO WHERE USID='" + USID + "'");
            hint.ForeColor = Color.Red;
            hint.Location = new Point(400, 100);
            hint.Text = "";
           
            dt1 = bc.getdt(cedit_right.sql + " WHERE A.UNAME='" + a + "' ORDER BY NODEID ASC");
            if (dt1.Rows.Count > 0)
            {
               
                dataGridView2.DataSource = dt1;
                dgvStateControl();
                LENAME.Text = dt1.Rows[0]["姓名"].ToString();
            }
            comboBox1.Text = a;
       
            IF_DOUBLE_CLICK = false;
    
            try
            {
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region bind_GROUP
        private void Bind_GROUP(string USER_GROUP)
        {
            DataTable dty = bc.getdt("SELECT * FROM RIGHTLIST WHERE USID='" + USER_GROUP + "'");
            sqb = new StringBuilder();
            sqb.Append("SELECT * FROM RIGHTNAME");
            sqb.AppendFormat(" WHERE NODE_NAME!= '{0}'", "基础资料");
            sqb.AppendFormat(" AND NODE_NAME!= '{0}'", "库存管理");
            sqb.AppendFormat(" AND NODE_NAME!= '{0}'", "属性管理");
            sqb.AppendFormat(" AND NODE_NAME!='{0}'", "用户管理");
            dt4 = bc.getdt(sqb.ToString());
            dt4 = GetTableInfo(dt4);
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = true;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            if (dty.Rows.Count > 0)
            {
                foreach (DataRow dr1 in dty.Rows)
                {
                    foreach (DataRow dr in dt4.Rows)
                    {
                        if (dr1["NODE_NAME"].ToString() == dr["作业名称"].ToString())
                        {
                            if (dr1["NODE_NAME"].ToString() == "工单作业" 
                                )
                            {
                                if (dr1["ADD_NEW"].ToString() == "Y")
                                {
                                    dr["新增"] = true;
                                }
                                if (dr1["EDIT"].ToString() == "Y")
                                {
                                    dr["修改"] = true;
                                }
                                if (dr1["DEL"].ToString() == "Y")
                                {
                                    dr["删除"] = true;
                                }
                              
                                
                            }
                            else
                            {
                                if (dr1["OPERATE"].ToString() == "Y")
                                {
                                    dr["复选框"] = true;
                                }
                            }
                            break;
                        }
                    }
                }
        
                if (bc.getOnlyString("SELECT SCOPE FROM SCOPE_OF_AUTHORIZATION WHERE USID='" + USER_GROUP + "'") == "Y")
                {
                    radioButton4.Checked = true;
                }
                else if (bc.getOnlyString("SELECT SCOPE FROM SCOPE_OF_AUTHORIZATION WHERE USID='" + USER_GROUP + "'") == "GROUP")
                {
                    radioButton5.Checked = true;
                }
                else if (bc.getOnlyString("SELECT SCOPE FROM SCOPE_OF_AUTHORIZATION WHERE USID='" + USER_GROUP + "'") == "N")
                {
                    radioButton6.Checked = true;
                }
            }
            dataGridView4.DataSource = dt4;
            if (dt4.Rows.Count > 0)
            {
                dgvStateControl_dgv4();
            }
            this.WindowState = FormWindowState.Maximized;
            string a = bc.getOnlyString("SELECT UNAME FROM USERINFO WHERE USID='" + USER_GROUP + "'");
            hint.ForeColor = Color.Red;
            hint.Location = new Point(400, 100);
            hint.Text = "";
            IF_DOUBLE_CLICK = false;
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region bind1
        private void Bind1(DataGridView dgv)
        {
            try
            {
                hint.ForeColor = Color.Red;
                hint.Location = new Point(400, 100);
                hint.Text = "";
                label6.Text = "";
                label6.ForeColor = CCOLOR.rose;
                if (dgv == dataGridView1)
                {
                    dt1 = bc.getdt(cedit_right.sql + " WHERE A.UNAME='" + comboBox1.Text + "'");
                    dataGridView2.DataSource = dt1;
                }
           
                IF_DOUBLE_CLICK = false;
                if (bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS) != "")
                {
                    hint.Text = bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS);
                }
                else
                {
                    hint.Text = "";
                }
                if (dgv == dataGridView3)
                {
                    dt3 = bc.getdt(cuser_group.sql);
                    dt3 = cuser_group.RETURN_HAVE_ID_DT(dt3);
                    dataGridView3.DataSource = null;
                    dataGridView3.DataSource = dt3;
                    dgvStateControl_dgv3();
                    if (dt3.Rows.Count > 0)
                    {
                        USER_GROUP_CHECKED = dt3.Rows[0]["用户组"].ToString();
                        DataTable dtx = bc.getdt(string.Format("SELECT * FROM RIGHTLIST WHERE USID='{0}'", USER_GROUP_CHECKED));
                        if (dtx.Rows.Count > 0)
                        {
                            label6.Text = string.Format("当前用户组权限列表为：{0}", USER_GROUP_CHECKED);
                        }
                    }
                    Bind_GROUP(USER_GROUP_CHECKED);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region dgvStateControl
        private void dgvStateControl()
        {
            int i;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Lavender;
            dataGridView2.RowHeadersDefaultCellStyle.BackColor = Color.Lavender;
            int numCols1 = dataGridView1.Columns.Count;
            int numCols2 = dataGridView2.Columns.Count;
            int rows1=dataGridView1 .Rows .Count ;
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            for (i = 0; i < numCols1; i++)
            {

                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                //this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.Columns[i].HeaderCell.Style.BackColor = Color.Lavender;
                //dataGridView1.Columns[i].ReadOnly = true;
                //dataGridView1.Columns[i].DefaultCellStyle.BackColor = Color.Red;
            }
            dgvStateControl_control_if_readonly(dataGridView1);

            dataGridView2.Columns["作业名称"].Width = 90;
            dataGridView2.Columns["用户名"].Width = 70;
            dataGridView2.Columns["姓名"].Width = 70;
            dataGridView2.Columns["操作权限"].Width = 50;
            dataGridView2.Columns["查询权限"].Width = 50;
            dataGridView2.Columns["新增权限"].Width = 50;
            dataGridView2.Columns["修改权限"].Width = 50;
            dataGridView2.Columns["删除权限"].Width = 50;
          
            for (i = 0; i < numCols2; i++)
            {

                dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView2.EnableHeadersVisualStyles = false;
                dataGridView2.Columns[i].HeaderCell.Style.BackColor = Color.Lavender;

            }
        
            for (i = 0; i < dataGridView2.Columns.Count; i++)
            {
                dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView2.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                i = i + 1;
            }
            for (i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                i = i + 1;
            }
            for (i = 0; i < dataGridView2.Columns.Count; i++)
            {
                dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView2.Columns[i].ReadOnly = true;

            }

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns["复选框"].Width = 50;
            dataGridView1.Columns["查询"].Width = 40;
            dataGridView1.Columns["新增"].Width = 40;
            dataGridView1.Columns["修改"].Width = 40;
            dataGridView1.Columns["删除"].Width = 40;
    
        }
        #endregion
        #region dgvStateControl_control_if_readonly
        private void dgvStateControl_control_if_readonly(DataGridView dgv)
        {
            int i;

            for (i = 0; i < dgv.Rows.Count; i++)
            {
                
                if (dgv["作业名称", i].FormattedValue.ToString() == "工单作业"
                    )
                {

                    dgv.Rows[i].Cells[0].ReadOnly = true;
                    dgv.Rows[i].Cells[1].ReadOnly = true;
                    dgv.Rows[i].Cells[2].ReadOnly = true;
                    dgv.Rows[i].Cells[0].Style.BackColor = c1;
                    dgv.Rows[i].Cells[2].Style.BackColor = c1;
                    if (dgv["作业名称", i].FormattedValue.ToString() == "工单作业")
                    {
                       

                    }
               
                }
                else
                {
                    for (j = 0; j <dgv.Columns.Count ; j++)
                    {
                        if (j == 0)
                        {
                        }
                        else
                        {
                            dgv.Rows[i].Cells[j].ReadOnly = true;
                        }
                        if (j == 0 || j == 1)
                        {
                        }
                        else
                        {
                            dgv.Rows[i].Cells[j].Style.BackColor = c1;

                        }
                    }
                }
            }

           
          
        }
        #endregion
        #region dgvStateControl_dgv3
        private void dgvStateControl_dgv3()
        {
            int i;
            dataGridView3.RowHeadersDefaultCellStyle.BackColor = Color.Lavender;
            //dataGridView3.EditMode = DataGridViewEditMode.EditOnEnter;
            //dataGridView3.ClearSelection();
            dataGridView3.AllowUserToAddRows = false;
            int numCols1 = dataGridView3.Columns.Count;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;/*自动调整DATAGRIDVIEW的列宽*/
            for (i = 0; i < numCols1; i++)
            {
                dataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView3.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                //this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView3.EnableHeadersVisualStyles = false;
                dataGridView3.Columns[i].HeaderCell.Style.BackColor = Color.Lavender;
                dataGridView3.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                dataGridView3.Columns[i].ReadOnly = true;
            }
            for (i = 0; i < dataGridView3.Rows.Count; i++)
            {
                dataGridView3.Rows[i].Height = 18;
            }
            for (i = 0; i < dataGridView3.Rows.Count - 1; i++)
            {
                dataGridView3.Rows[i].DefaultCellStyle.BackColor = CCOLOR.GLS;
                dataGridView3.Rows[i + 1].DefaultCellStyle.BackColor = CCOLOR.YG;
                i = i + 1;
            }
        
            
        }
        #endregion
        #region dgvStateControl_dgv4
        private void dgvStateControl_dgv4()
        {
            int i;
            dataGridView4.RowHeadersDefaultCellStyle.BackColor = Color.Lavender;
            int numCols1 = dataGridView4.Columns.Count;
            int numCols2 = dataGridView2.Columns.Count;
            int rows1 = dataGridView4.Rows.Count;
            dataGridView4.ClearSelection();
            for (i = 0; i < numCols1; i++)
            {

                dataGridView4.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView4.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                //this.dataGridView4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView4.EnableHeadersVisualStyles = false;
                dataGridView4.Columns[i].HeaderCell.Style.BackColor = Color.Lavender;
                //dataGridView4.Columns[i].ReadOnly = true;
                //dataGridView4.Columns[i].DefaultCellStyle.BackColor = Color.Red;
            }
            dgvStateControl_control_if_readonly(dataGridView4);
            for (i = 0; i < dataGridView4.Columns.Count; i++)
            {
                dataGridView4.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView4.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                i = i + 1;
            }
            dataGridView4.AllowUserToAddRows = false;
            dataGridView4.Columns["复选框"].Width = 50;
            dataGridView4.Columns["查询"].Width = 40;
            dataGridView4.Columns["新增"].Width = 40;
            dataGridView4.Columns["修改"].Width = 40;
            dataGridView4.Columns["删除"].Width = 40;
          
        }
        #endregion
        private int return_Voucher_rows(DataTable dt)
        {
            int r = 0;
            for (i = 0; i <dt.Rows .Count ; i++)
            {
                if (dt.Rows[i]["作业名称"].ToString() == "工单作业"
                    )
                {
                    r = i;
                    break;
                }
            }
            return r;
        }

        private int return_Voucher_rows_o()
        {
            int r = 0;
            for (i = 0; i <dataGridView1 .Rows .Count ; i++)
            {
               // MessageBox.Show(dataGridView1["作业名称", i].Value.ToString());
                if (dataGridView1["作业名称", i].Value.ToString() == "工单作业" 
                    )
                {
                    r = i;
                    break;
                }  
            }
            return r;
        }
        private int return_Voucher_rows_o_dgv4()
        {
            int r = 0;
            for (i = 0; i < dataGridView4.Rows.Count; i++)
            {
                // MessageBox.Show(dataGridView1["作业名称", i].Value.ToString());
                if (dataGridView4["作业名称", i].Value.ToString() == "工单作业"
                    )
                {
                    r = i;
                    break;
                }
            }
            return r;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        protected void Clear()
        {
            comboBox1.Text = "";
            LENAME.Text = "";
            dataGridView1.DataSource = null;
        }
        #region save_click
        private void btnSave_Click(object sender, EventArgs e)
        {
      
            try
            {
                if (juage())
                {

                }
                else
                {
                    string USID = bc.getOnlyString("SELECT USID FROM USERINFO WHERE  UNAME='" + comboBox1.Text + "'");
                    bc.getcom("DELETE RIGHTLIST WHERE USID='" + USID + "'");
                    bc.getcom("DELETE SCOPE_OF_AUTHORIZATION WHERE USID='" + USID + "'");
                    if (juage_if_noall_select(dataGridView1))
                    {
                       
                    }
                    else
                    {
                        save(dataGridView1 );
                        if (radioButton1.Checked == true)
                        {
                            bc.getcom("INSERT INTO SCOPE_OF_AUTHORIZATION(USID,SCOPE) VALUES ('" + USID + "','Y')");
                        }
                        else if (radioButton2.Checked == true)
                        {
                            bc.getcom("INSERT INTO SCOPE_OF_AUTHORIZATION(USID,SCOPE) VALUES ('" + USID + "','GROUP')");
                        }
                        else
                        {
                            bc.getcom("INSERT INTO SCOPE_OF_AUTHORIZATION(USID,SCOPE) VALUES ('" + USID + "','N')");
                        }
                        IFExecution_SUCCESS = true;
                    }
                    Bind1(dataGridView1 );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }

        }
        #endregion
        #region save
        private void save(DataGridView dgv)
        {
            OFFER_DATE_SEARCH = "Y";
            SAMPLE_AUDIT = "Y";
            FILE_UPLOAD = "Y";
            PAPER_AUDIT = "Y";
            ACRYLIC_AUDIT = "Y";
            WOOD_IRON_AUDIT = "Y";
            PURCHASE_AUDIT = "Y";
            EXCEL_SENVEN = "Y";
            EXCEL_ONE = "Y";
            EXCEL_TWO = "Y";
            EXCEL_THREE = "Y";
            EXCEL_FOUR = "Y";
            EXCEL_FIVE = "Y";
            EXCEL_SIX = "Y";
            string varDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            if (dgv == dataGridView1)
            {
                USID = bc.getOnlyString("SELECT USID FROM USERINFO WHERE  UNAME='" + comboBox1.Text + "'");
            }
            else if (dgv == dataGridView4)
            {
                USID = USER_GROUP_CHECKED;
            }
            string v1, v2, v3, v4, v5, v6="";
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv["作业名称", i].Value.ToString() == "工单作业" 
                    )
                {
                    if (dgv.Rows[i].Cells["查询"].EditedFormattedValue.ToString() == "False")
                    {

                        v2 = "N";
                    }
                    else
                    {
                        v2 = "Y";

                    }
                    if (dgv.Rows[i].Cells["新增"].EditedFormattedValue.ToString() == "False")
                    {

                        v3 = "N";
                    }
                    else
                    {
                        v3 = "Y";

                    }
                    if (dgv.Rows[i].Cells["修改"].EditedFormattedValue.ToString() == "False")
                    {

                        v4 = "N";
                    }
                    else
                    {
                        v4 = "Y";

                    }
                    if (dgv.Rows[i].Cells["删除"].EditedFormattedValue.ToString() == "False")
                    {

                        v5 = "N";
                    }
                    else
                    {
                        v5 = "Y";

                    }
                
                    if (v2 == "N" && v3 == "N" && v4 == "N" && v5 == "N" )
                    {

                    }
                    else
                    {
                        string v11 = bc.getOnlyString("SELECT PARENT_NODEID FROM RIGHTNAME WHERE NODE_NAME='" + dgv.Rows[i].Cells[1].Value.ToString() + "'");
                        string v12 = bc.getOnlyString("SELECT NODE_NAME FROM RIGHTNAME WHERE NODEID='" + v11 + "'");
                        if (!bc.exists("SELECT * FROM RIGHTLIST WHERE  USID='"+USID +"' AND NODEID='" + v11 + "'") && v11 != "0")
                        {
                            cedit_right.USID = USID;
                            cedit_right.NODEID = v11;
                            cedit_right.PARENT_NODEID = bc.getOnlyString("SELECT PARENT_NODEID FROM RIGHTNAME WHERE NODEID='" + v11 + "'");
                            cedit_right.NODE_NAME = v12;
                            cedit_right.OPERATE = "N";
                            cedit_right.SEARCH = v2;
                            cedit_right.ADD_NEW = v3;
                            cedit_right.EDIT = v4;
                            cedit_right.DEL = v5;
                            cedit_right.OFFER_AUDIT = v6;
                            cedit_right.OFFER_DATE_SEARCH = OFFER_DATE_SEARCH;
                            cedit_right.SAMPLE_AUDIT = SAMPLE_AUDIT;
                            cedit_right.FILE_UPLOAD = FILE_UPLOAD;
                            cedit_right.PAPER_AUDIT = PAPER_AUDIT;
                            cedit_right.ACRYLIC_AUDIT = ACRYLIC_AUDIT;
                            cedit_right.WOOD_IRON_AUDIT = WOOD_IRON_AUDIT;
                            cedit_right.PURCHASE_AUDIT = PURCHASE_AUDIT;
                            cedit_right.EXCEL_SENVEN = EXCEL_SENVEN;
                            cedit_right.EXCEL_ONE = EXCEL_ONE;
                            cedit_right.EXCEL_TWO = EXCEL_TWO;
                            cedit_right.EXCEL_THREE = EXCEL_THREE;
                            cedit_right.EXCEL_FOUR = EXCEL_FOUR;
                            cedit_right.EXCEL_FIVE = EXCEL_FIVE;
                            cedit_right.EXCEL_SIX = EXCEL_SIX;
                            cedit_right.EMID = LOGIN.EMID;
                            cedit_right.SQlcommandE();
                        }
                        //MessageBox.Show(dgv.Rows[i].Cells[1].Value.ToString() +" "+dgv .Columns [j].Name .ToString ()+ dgv.Rows[i].Cells[j].Value.ToString()+ " "+v1);
                        cedit_right.USID = USID;
                        cedit_right.NODEID = bc.getOnlyString("SELECT NODEID FROM RIGHTNAME WHERE NODE_NAME='" + dgv.Rows[i].Cells[1].Value.ToString() + "'");
                        cedit_right.PARENT_NODEID = bc.getOnlyString("SELECT PARENT_NODEID FROM RIGHTNAME WHERE NODE_NAME='" + dgv.Rows[i].Cells[1].Value.ToString() + "'");
                        cedit_right.NODE_NAME = dgv.Rows[i].Cells[1].Value.ToString();
                        cedit_right.OPERATE = "N";
                        cedit_right.SEARCH = v2;
                        cedit_right.ADD_NEW = v3;
                        cedit_right.EDIT = v4;
                        cedit_right.DEL = v5;
                        cedit_right.OFFER_AUDIT = v6;
                        cedit_right.OFFER_DATE_SEARCH = OFFER_DATE_SEARCH;
                        cedit_right.SAMPLE_AUDIT = SAMPLE_AUDIT;
                        cedit_right.FILE_UPLOAD = FILE_UPLOAD;
                        cedit_right.PAPER_AUDIT = PAPER_AUDIT;
                        cedit_right.ACRYLIC_AUDIT = ACRYLIC_AUDIT;
                        cedit_right.WOOD_IRON_AUDIT = WOOD_IRON_AUDIT;
                        cedit_right.PURCHASE_AUDIT = PURCHASE_AUDIT;
                        cedit_right.EXCEL_ONE = EXCEL_ONE;
                        cedit_right.EXCEL_TWO = EXCEL_TWO;
                        cedit_right.EXCEL_THREE = EXCEL_THREE;
                        cedit_right.EXCEL_FOUR = EXCEL_FOUR;
                        cedit_right.EXCEL_FIVE = EXCEL_FIVE;
                        cedit_right.EXCEL_SIX = EXCEL_SIX;
                        cedit_right.EXCEL_SENVEN = EXCEL_SENVEN;
                        cedit_right.EMID = LOGIN.EMID;
                        cedit_right.SQlcommandE();
                    }
                }
                else
                {

                    if (dgv.Rows[i].Cells[0].EditedFormattedValue.ToString() == "False")
                    {
                        v1 = "N";
                    }
                    else
                    {
                        v1 = "Y";
                    }
                    //MessageBox.Show(dgv.Rows[i].Cells[1].Value.ToString() + v1);
                    if (v1 == "Y")
                    {
                        string v11 = bc.getOnlyString("SELECT PARENT_NODEID FROM RIGHTNAME WHERE NODE_NAME='" + dgv.Rows[i].Cells[1].Value.ToString() + "'");
                        string v12 = bc.getOnlyString("SELECT NODE_NAME FROM RIGHTNAME WHERE NODEID='" + v11 + "'");
                        if (!bc.exists("SELECT * FROM RIGHTLIST WHERE  USID='"+USID +"'  AND NODEID='" + v11 + "'") && v11 != "0")
                        {
                            cedit_right.USID = USID;
                            cedit_right.NODEID = v11;
                            cedit_right.PARENT_NODEID = bc.getOnlyString("SELECT PARENT_NODEID FROM RIGHTNAME WHERE NODEID='" + v11 + "'");
                            cedit_right.NODE_NAME = v12;
                            cedit_right.OPERATE = v1;
                            cedit_right.SEARCH = "N";
                            cedit_right.ADD_NEW = "N";
                            cedit_right.EDIT = "N";
                            cedit_right.DEL = "N";
                            cedit_right.OFFER_AUDIT = "N";
                            cedit_right.OFFER_DATE_SEARCH = "N";
                            cedit_right.SAMPLE_AUDIT = "N";
                            cedit_right.FILE_UPLOAD = "N";
                            cedit_right.PAPER_AUDIT = "N";
                            cedit_right.ACRYLIC_AUDIT = "N";
                            cedit_right.WOOD_IRON_AUDIT = "N";
                            cedit_right.PURCHASE_AUDIT = "N";
                            cedit_right.EXCEL_ONE = "N";
                            cedit_right.EXCEL_TWO = "N";
                            cedit_right.EXCEL_THREE = "N";
                            cedit_right.EXCEL_FOUR = "N";
                            cedit_right.EXCEL_FIVE = "N";
                            cedit_right.EXCEL_SIX = "N";
                            cedit_right.EXCEL_SENVEN = "N";
                            cedit_right.EMID = LOGIN.EMID;
                            cedit_right.SQlcommandE();
                        }
                        cedit_right.USID = USID;
                        cedit_right.NODEID = bc.getOnlyString("SELECT NODEID FROM RIGHTNAME WHERE NODE_NAME='" + dgv.Rows[i].Cells[1].Value.ToString() + "'");
                        cedit_right.PARENT_NODEID = bc.getOnlyString("SELECT PARENT_NODEID FROM RIGHTNAME WHERE NODE_NAME='" + dgv.Rows[i].Cells[1].Value.ToString() + "'");
                        cedit_right.NODE_NAME = dgv.Rows[i].Cells[1].Value.ToString();
                        cedit_right.OPERATE = v1;
                        cedit_right.SEARCH = "N";
                        cedit_right.ADD_NEW = "N";
                        cedit_right.EDIT = "N";
                        cedit_right.DEL = "N";
                        cedit_right.OFFER_AUDIT = "N";
                        cedit_right.OFFER_DATE_SEARCH = "N";
                        cedit_right.SAMPLE_AUDIT = "N";
                        cedit_right.FILE_UPLOAD = "N";
                        cedit_right.PAPER_AUDIT = "N";
                        cedit_right.ACRYLIC_AUDIT = "N";
                        cedit_right.WOOD_IRON_AUDIT = "N";
                        cedit_right.PURCHASE_AUDIT = "N";
                        cedit_right.EXCEL_ONE = "N";
                        cedit_right.EXCEL_TWO = "N";
                        cedit_right.EXCEL_THREE = "N";
                        cedit_right.EXCEL_FOUR = "N";
                        cedit_right.EXCEL_FIVE = "N";
                        cedit_right.EXCEL_SIX = "N";
                        cedit_right.EXCEL_SENVEN = "N";
                        cedit_right.EMID = LOGIN.EMID;
                        cedit_right.SQlcommandE();

                    }
                }
            }

        }
        #endregion
        #region juage()
        private bool juage()
        {
            bool b = false;
            if (comboBox1.Text == "")
            {
                b = true;
                hint.Text = "用户名不能为空！";
            }
            else if (!bc.exists("SELECT * FROM USERINFO WHERE UNAME='" + comboBox1.Text + "'"))
            {
                b = true;
                hint.Text = "用户名在系统中不存在！";
            }
            return b;
        }
        #endregion
        #region juage_dgv3()
        private bool juage_dgv3()
        {
            bool b = false;
            if (textBox1 .Text == "")
            {
                b = true;
                hint.Text = "编号不能为空！";
            }
            else if (comboBox2.Text =="")
            {
                b = true;
                hint.Text = "用户名组不能为空！";
            }
            return b;
        }
        #endregion
        #region juage_dgv32()
        private bool juage_dgv32()
        {
            bool b = false;
            if (dt3.Rows.Count > 0)
            {
           
            }
            else
            {
                b = true;
                hint.Text = "没有可选的用户组信息";

            }
          
            return b;
        }
        #endregion
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string v1 = Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim();
            dt = bc.getdt(cedit_right .sql + " WHERE A.UNAME='"+v1+"'");
            if (dt.Rows.Count > 0)
            {
              
              
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            CSPSS.USER_MANAGE.USER_INFO FRM = new USER_INFO();
            FRM.IDO = cuser.GETID();
            FRM.GET_DATA_INT = 1;
            FRM.EditRight();
            FRM.ShowDialog();
            this.comboBox1.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.comboBox1.DroppedDown = false;//使组合框不显示其下拉部分
            this.comboBox1.IntegralHeight = true;//恢复默认值
            if (IF_DOUBLE_CLICK)
            {
                comboBox1.Text = UNAME;
                LENAME.Text = ENAME;
          
                search();
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            
            }
        }
        #region juage_if_all_select
        private bool juage_if_all_select()
        {
            bool b = true;
            for (int i = 0; i <dataGridView1.Rows.Count ; i++)
            { //MessageBox.Show(dataGridView1["作业名称", i].Value.ToString());
                if (b==false )
                {
                    break;
                }
                if (i == return_Voucher_rows_o())
                {
                   
                    for (int j = 3; j < dataGridView1.Columns .Count ; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].EditedFormattedValue.ToString() == "False")
                        {
                            b = false;
                            break;
                        }
                    }
                }
                else
                {
                    if (dataGridView1.Rows[i].Cells[0].EditedFormattedValue.ToString() == "False")
                    {
                    
                        b = false;
                        break;
                    }
                  
                }
           
            }
            return b;
        }
        #endregion
        #region juage_if_all_select_dgv4
        private bool juage_if_all_select_dgv4()
        {
            bool b = true;
            for (int i = 0; i < dataGridView4.Rows.Count; i++)
            { //MessageBox.Show(dataGridView4["作业名称", i].Value.ToString());
                if (b == false)
                {
                    break;
                }
                if (i == return_Voucher_rows_o_dgv4())
                {

                    for (int j = 3; j < dataGridView4.Columns.Count; j++)
                    {
                        if (dataGridView4.Rows[i].Cells[j].EditedFormattedValue.ToString() == "False")
                        {
                            b = false;
                            break;
                        }
                    }
                }
                else
                {
                    if (dataGridView4.Rows[i].Cells[0].EditedFormattedValue.ToString() == "False")
                    {

                        b = false;
                        break;
                    }

                }

            }
            return b;
        }
        #endregion
        #region juage_if_noall_select
        private bool juage_if_noall_select(DataGridView dgv)
        {
            bool b = true;
            bool b1 = false;

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (b1 == true)
                    break;
                if (dgv["作业名称", i].Value.ToString() == "工单作业" 
                    )
                {
                    for (int j = 2; j < dgv.Columns.Count; j++)
                    {
                        if (dgv.Rows[i].Cells[j].EditedFormattedValue.ToString() == "True")
                        {
                            b = false;
                            b1 = true;
                            break;
                        }
                    }
                }
                else
                {
                    if (dgv.Rows[i].Cells[0].EditedFormattedValue.ToString() == "True")
                    {

                        b = false;
                        break;
                    }

                }

            }
            return b;
        }
        #endregion
        #region checkBox1_CheckedChanged
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (juage_if_all_select())
            {
                select(1);
            }
            else
            {

                select(0);
            }
        }
        #endregion
        #region checkBox2_CheckedChanged
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                if (dataGridView1["作业名称", i].Value.ToString() == "工单作业" 
                    )
                {
                    for (int j = 3; j <dataGridView1 .Columns .Count ; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].EditedFormattedValue.ToString() == "False")
                        {
                            dataGridView1.Rows[i].Cells[j].Value = "True";
                      
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[j].Value = "False";

                        }
                    }
                    if (dataGridView1["作业名称", i].Value.ToString() != "工单作业" )
                    {

                      
 
                    }
               
                  
                }
                else
                {

                    if (dataGridView1.Rows[i].Cells[0].EditedFormattedValue.ToString() == "False")
                    {
                        dataGridView1.Rows[i].Cells[0].Value = "True";
                       

                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[0].Value = "False";

                    }

                }
            }
         
        }
        #endregion
        #region select
        private void select(int n)
        {
            for (int i = 0; i < dataGridView1.Rows .Count ; i++)
            {
                //MessageBox.Show(dataGridView1["作业名称", i].Value.ToString()+"ok");

                if (dataGridView1["作业名称", i].Value.ToString() == "工单作业" 
                    )
                {
                    dataGridView1.Rows[i].Cells[0].Value = "False";
                    //MessageBox.Show(dataGridView1["作业名称", i].Value.ToString() + "NO");
                    for (int j = 3; j < dataGridView1 .Columns .Count ; j++)
                    {
                        if (n == 0)
                        {
                            dataGridView1.Rows[i].Cells[j].Value = "True";
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[j].Value = "False";
                        }
                    }
                    if (dataGridView1["作业名称", i].Value.ToString() != "工单作业")
                    {
                      
                    }
             
                }
                else
                {
                    if (n == 0)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = "True";
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[0].Value = "False";
                    }
                }
            }
            
        }
        #endregion
        #region select_dgv4
        private void select_dgv4(int n)
        {
            for (int i = 0; i < dataGridView4.Rows.Count; i++)
            {
                //MessageBox.Show(dataGridView4["作业名称", i].Value.ToString()+"ok");

                if (dataGridView4["作业名称", i].Value.ToString() == "工单作业"
                    )
                {
                    dataGridView4.Rows[i].Cells[0].Value = "False";
                    //MessageBox.Show(dataGridView4["作业名称", i].Value.ToString() + "NO");
                    for (int j = 3; j < dataGridView4.Columns.Count; j++)
                    {
                        if (n == 0)
                        {
                            dataGridView4.Rows[i].Cells[j].Value = "True";
                        }
                        else
                        {
                            dataGridView4.Rows[i].Cells[j].Value = "False";
                        }
                    }
                    if (dataGridView4["作业名称", i].Value.ToString() != "工单作业")
                    {
                    
                    }
                 
                }
                else
                {
                    if (n == 0)
                    {
                        dataGridView4.Rows[i].Cells[0].Value = "True";
                    }
                    else
                    {
                        dataGridView4.Rows[i].Cells[0].Value = "False";
                    }
                }
            }

        }
        #endregion
        private void treeView1_Click(object sender, EventArgs e)
        {

        }
        #region search
        private void search()
        {
         
            try
            {
          
                dt1 = bc.getdt(cedit_right.sql + " WHERE  A.UNAME LIKE '%" + comboBox1.Text + "%'");
                if (dt1.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt1;
                    dgvStateControl();

                }
                else
                {

                   
                    hint.Text = "没有找到相关信息！";
                    dataGridView2.DataSource = dt1;
                }
                if (bc.exists("SELECT * FROM USERINFO WHERE UNAME='" + comboBox1.Text + "'"))
                {
                    Bind(bc.getOnlyString("SELECT USID FROM USERINFO WHERE UNAME='" + comboBox1.Text + "'"));
                }
                else
                {
                    LENAME.Text = "";
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    radioButton1.Checked = false;
                    radioButton3.Checked = false;

                    dt = bc.getdt("SELECT * FROM RIGHTNAME");
                    dt = GetTableInfo(dt);
                    dataGridView1.DataSource = dt;
                    dgvStateControl();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
         
            if (juage_if_all_select_dgv4())
            {
                select_dgv4(1);
            }
            else
            {

                select_dgv4(0);
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridView4.Rows.Count; i++)
            {

                if (dataGridView4["作业名称", i].Value.ToString() == "工单作业" 
                    )
                {
                    for (int j = 3; j < dataGridView4.Columns.Count; j++)
                    {
                        if (dataGridView4.Rows[i].Cells[j].EditedFormattedValue.ToString() == "False")
                        {
                            dataGridView4.Rows[i].Cells[j].Value = "True";

                        }
                        else
                        {
                            dataGridView4.Rows[i].Cells[j].Value = "False";

                        }
                    }
            
                
                }
                else
                {

                    if (dataGridView4.Rows[i].Cells[0].EditedFormattedValue.ToString() == "False")
                    {
                        dataGridView4.Rows[i].Cells[0].Value = "True";


                    }
                    else
                    {
                        dataGridView4.Rows[i].Cells[0].Value = "False";

                    }

                }
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dt3.Rows.Count > 0)
            {
                USER_GROUP_CHECKED = dt3.Rows[dataGridView3.CurrentCell.RowIndex]["用户组"].ToString();
                textBox1.Text = bc.getOnlyString(string.Format ("SELECT UGID FROM USER_GROUP WHERE USER_GROUP='{0}'",USER_GROUP_CHECKED ));
                IDO = bc.getOnlyString(string.Format("SELECT UGID FROM USER_GROUP WHERE USER_GROUP='{0}'", USER_GROUP_CHECKED));
                comboBox2.Text = USER_GROUP_CHECKED;
                Bind_GROUP(USER_GROUP_CHECKED);
                label6.Text = string.Format("当前用户组权限列表为：{0}", USER_GROUP_CHECKED);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

   
        private void save2()
        {
            if (juage_dgv32())
            {

            }
            else
            {
                bc.getcom("DELETE RIGHTLIST WHERE USID='" + USER_GROUP_CHECKED + "'");
                bc.getcom("DELETE SCOPE_OF_AUTHORIZATION WHERE USID='" + USER_GROUP_CHECKED + "'");
                if (juage_if_noall_select(dataGridView4))
                {

                }
                else
                {
                    save(dataGridView4);
                    if (radioButton4.Checked == true)
                    {
                        bc.getcom("INSERT INTO SCOPE_OF_AUTHORIZATION(USID,SCOPE) VALUES ('" + USER_GROUP_CHECKED + "','Y')");
                    }
                    else if (radioButton5.Checked == true)
                    {
                        bc.getcom("INSERT INTO SCOPE_OF_AUTHORIZATION(USID,SCOPE) VALUES ('" + USER_GROUP_CHECKED + "','GROUP')");
                    }
                    else
                    {
                        bc.getcom("INSERT INTO SCOPE_OF_AUTHORIZATION(USID,SCOPE) VALUES ('" + USER_GROUP_CHECKED + "','N')");
                    }
                    IFExecution_SUCCESS = true;
                    Bind1(dataGridView4);
                }

            }
            try
            {
        
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            add();
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
       
            try
            {
                if (MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (bc.exists("SELECT * FROM USERINFO WHERE UGID='"+IDO+"'"))
                    {
                        hint.Text = string.Format("用户组 {0} 已经在用户信息中使用，不能删除，除非将在该组的用户退出该组", comboBox2.Text );
                    }
                    else
                    {
                        basec.getcoms("DELETE USER_GROUP WHERE UGID='" + IDO + "'");
                        basec.getcoms("DELETE RIGHTLIST WHERE USID='" + comboBox2.Text + "'");
                        basec.getcoms("DELETE SCOPE_OF_AUTHORIZATION WHERE  USID='" + comboBox2.Text + "'");
                        add();
                        hint.Text = "";
                        Bind1(dataGridView3);
                    }
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Focus();
                if (juage_dgv3())
                {
                    IFExecution_SUCCESS = false;
                }
                else
                {
                    save();
          
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }
        private void add()
        {
            comboBox2.Text = "";
            textBox1 .Text = cuser_group.GETID();
            IFExecution_SUCCESS = false;
        }
        private void save()
        {
            cuser_group.UGID = textBox1.Text;
            cuser_group.MAKERID = LOGIN.EMID;
            cuser_group.USER_GROUP = comboBox2.Text;
            cuser_group.save();
            if (cuser_group.IFExecution_SUCCESS)
            {
                add();
                IFExecution_SUCCESS = cuser_group.IFExecution_SUCCESS;
                Bind1(dataGridView3);
            }
            else
            {
                hint.Text = cuser_group.ErrowInfo;

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            save2();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
