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
using System.Net;
using System.IO;

namespace CSPSS.WORKORDER_MANAGE
{
    public partial class WORKORDERT : Form
    {
        DataTable dt = new DataTable();
        DataTable dt3 = new DataTable();
  
        basec bc=new basec ();
        StringBuilder sqb = new StringBuilder();
        #region nature
        private string _IDO;
        public string IDO
        {
            set { _IDO = value; }
            get { return _IDO; }
        }
        private string _WOKEY;
        public string WOKEY
        {
            set { _WOKEY = value; }
            get { return _WOKEY; }
        }
        private string _INITIAL_OR_OTHER;
        public string INITIAL_OR_OTHER
        {
            set { _INITIAL_OR_OTHER = value; }
            get { return _INITIAL_OR_OTHER; }
        }

        private string _WATER_MARK_CONTENT;
        public string WATER_MARK_CONTENT
        {
            set { _WATER_MARK_CONTENT = value; }
            get { return _WATER_MARK_CONTENT; }
        }
        private string _OLD_FILE_NAME;
        public string OLD_FILE_NAME
        {
            set { _OLD_FILE_NAME = value; }
            get { return _OLD_FILE_NAME; }

        }
        private string _NEW_FILE_NAME;
        public string NEW_FILE_NAME
        {
            set { _NEW_FILE_NAME = value; }
            get { return _NEW_FILE_NAME; }

        }
        private string _ADD_OR_UPDATE;
        public string ADD_OR_UPDATE
        {
            set { _ADD_OR_UPDATE = value; }
            get { return _ADD_OR_UPDATE; }
        }
        private string _EDIT;
        public string EDIT
        {
            set { _EDIT = value; }
            get { return _EDIT; }
        }
        private static string _WAREID;
        public static string WAREID
        {
            set { _WAREID = value; }
            get { return _WAREID; }
        }
        private string _FROM;
        public string FROM
        {
            set { _FROM = value; }
            get { return _FROM; }
        }
        private static string _CO_WAREID;
        public static string CO_WAREID
        {
            set { _CO_WAREID = value; }
            get { return _CO_WAREID; }

        }
        private static string _WNAME;
        public static string WNAME
        {
            set { _WNAME = value; }
            get { return _WNAME; }

        }
        private static string _FCID;
        public static string FCID
        {
            set { _FCID = value; }
            get { return _FCID; }

        }
        private static string _FLOW_CHART_ID;
        public static string FLOW_CHART_ID
        {
            set { _FLOW_CHART_ID = value; }
            get { return _FLOW_CHART_ID; }

        }
        private static string _FCNAME;
        public static string FCNAME
        {
            set { _FCNAME = value; }
            get { return _FCNAME; }

        }
        private static string _FLOW_CHART_EDITION;
        public static string FLOW_CHART_EDITION
        {
            set { _FLOW_CHART_EDITION = value; }
            get { return _FLOW_CHART_EDITION; }

        }
  
        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        private static bool _IF_DOUBLE_CLICK;
        public static bool IF_DOUBLE_CLICK
        {
            set { _IF_DOUBLE_CLICK = value; }
            get { return _IF_DOUBLE_CLICK; }

        }
        #endregion
        private  delegate bool dele(string a1,string a2);
        private delegate void delex();
        CEDIT_RIGHT cedit_right = new CEDIT_RIGHT();
        protected int M_int_judge, i;
        protected int select;
        DataTable dtx = new DataTable();
        CWORKORDER cWORKORDER = new CWORKORDER();
        DataGridViewTextBoxColumn d18 = new DataGridViewTextBoxColumn();
        public WORKORDERT()
        {
            InitializeComponent();
        }
    
        private void WORKORDERT_Load(object sender, EventArgs e)
        {
            if (Screen.AllScreens[0].Bounds.Width == 1366 && Screen.AllScreens[0].Bounds.Height == 768 ||
                   Screen.AllScreens[0].Bounds.Width == 1280 && Screen.AllScreens[0].Bounds.Height == 800)
            {
                /*groupBox11.Height = 125;*/
                groupBox6.Location = new Point(1021,321);
                groupBox6.Height = 380;
                groupBox6.Width = 533;
                dataGridView1.Width = 1000;

            }
            else if (Screen.AllScreens[0].Bounds.Width == 1920 && Screen.AllScreens[0].Bounds.Height == 1080)
            {
                groupBox6.Location = new Point(1350, 321);
               
                groupBox6.Width = 533;
                dataGridView1.Width = 1341;
            }
            else
            {
                this.AutoScroll = true;
                this.AutoScrollMinSize = new Size(1920, 1080);
            }
            textBox1.Text = IDO;
            #region addcolumns
            DataGridViewTextBoxColumn d1 = new DataGridViewTextBoxColumn();
            d1.Name = "工单号";
            d1.HeaderText = "工单号";
            dataGridView1.Columns.Add(d1);
            DataGridViewTextBoxColumn d22 = new DataGridViewTextBoxColumn();
            d22.Name = "客户名称";
            d22.HeaderText = "客户名称";
            dataGridView1.Columns.Add(d22);
            DataGridViewTextBoxColumn d23 = new DataGridViewTextBoxColumn();
            d23.Name = "规格";
            d23.HeaderText = "规格";
            dataGridView1.Columns.Add(d23);
            DataGridViewTextBoxColumn d2 = new DataGridViewTextBoxColumn();
            d2.Name = "物料编号";
            d2.HeaderText = "物料编号";
            dataGridView1.Columns.Add(d2);
            d2.Visible = false;
            DataGridViewTextBoxColumn d4 = new DataGridViewTextBoxColumn();
            d4.Name = "料号";
            d4.HeaderText = "料号";
            dataGridView1.Columns.Add(d4);
            d4.Visible = false;
            DataGridViewTextBoxColumn d5 = new DataGridViewTextBoxColumn();
            d5.Name = "品名";
            d5.HeaderText = "品名";
            dataGridView1.Columns.Add(d5);
            d5.Visible = false;
            DataGridViewTextBoxColumn d6 = new DataGridViewTextBoxColumn();
            d6.Name = "途程编号";
            d6.HeaderText = "途程编号";
            dataGridView1.Columns.Add(d6);
            d6.Visible = false;
            DataGridViewTextBoxColumn d7 = new DataGridViewTextBoxColumn();
            d7.Name = "途程代码";
            d7.HeaderText = "途程代码";
            dataGridView1.Columns.Add(d7);
            d7.Visible = false;
            DataGridViewTextBoxColumn d8 = new DataGridViewTextBoxColumn();
            d8.Name = "途程名称";
            d8.HeaderText = "途程名称";
            dataGridView1.Columns.Add(d8);
            d8.Visible = false;
            DataGridViewTextBoxColumn d9 = new DataGridViewTextBoxColumn();
            d9.Name = "途程版本";
            d9.HeaderText = "途程版本";
            dataGridView1.Columns.Add(d9);
            d9.Visible = false;
            DataGridViewTextBoxColumn d10 = new DataGridViewTextBoxColumn();
            d10.Name = "项次";
            d10.HeaderText = "项次";
            dataGridView1.Columns.Add(d10);

            DataGridViewTextBoxColumn d11 = new DataGridViewTextBoxColumn();
            d11.Name = "站别名称";
            d11.HeaderText = "站别名称";
            dataGridView1.Columns.Add(d11);
            DataGridViewTextBoxColumn d24 = new DataGridViewTextBoxColumn();
            d24.Name = "数量";
            d24.HeaderText = "数量";
            dataGridView1.Columns.Add(d24);
            DataGridViewTextBoxColumn d17 = new DataGridViewTextBoxColumn();
            d17.Name = "进度";
            d17.HeaderText = "进度%";
            dataGridView1.Columns.Add(d17);

            DataGridViewTextBoxColumn d12 = new DataGridViewTextBoxColumn();
            d12.Name = "状态";
            d12.HeaderText = "状态";
            dataGridView1.Columns.Add(d12);
            DataGridViewButtonColumn d19 = new DataGridViewButtonColumn();
            d19.DataPropertyName = "确认完工"; 
            d19.Name = "确认完工";
            d19.HeaderText = "确认完工";
            d19.Text = "确认完工";
            dataGridView1.Columns.Add(d19);
            d19.ReadOnly = true;
            DataGridViewTextBoxColumn d13 = new DataGridViewTextBoxColumn();
            d13.Name = "下单日期";
            d13.HeaderText = "下单日期";
            dataGridView1.Columns.Add(d13);

            DataGridViewTextBoxColumn d14 = new DataGridViewTextBoxColumn();
            d14.Name = "预计完工日期";
            d14.HeaderText = "预计完工日期";
            dataGridView1.Columns.Add(d14);
          
            d18.Name = "完工日期";
            d18.HeaderText = "完工日期";
            dataGridView1.Columns.Add(d18);
            DataGridViewTextBoxColumn d15 = new DataGridViewTextBoxColumn();
            d15.Name = "制单人";
            d15.HeaderText = "制单人";
            dataGridView1.Columns.Add(d15);
            d15.Visible = false;
            DataGridViewTextBoxColumn d16 = new DataGridViewTextBoxColumn();
            d16.Name = "制单日期";
            d16.HeaderText = "制单日期";
            dataGridView1.Columns.Add(d16);
            d16.Visible = false;
            DataGridViewTextBoxColumn d20 = new DataGridViewTextBoxColumn();
            d20.Name = "站别编号";
            d20.HeaderText = "站别编号";
            dataGridView1.Columns.Add(d20);
            d20.Visible = false;
            DataGridViewTextBoxColumn d21 = new DataGridViewTextBoxColumn();
            d21.Name = "备注";
            d21.HeaderText = "备注";
            dataGridView1.Columns.Add(d21);
            /*DataGridViewImageColumn d25 = new DataGridViewImageColumn();
            d25.Name = "缩略图";
            d25.HeaderText = "缩略图";
            dataGridView1.Columns.Add(d25);*/
           
            #endregion
            bind();
            label52.Text = "";
            label53.Visible = false;
            label55.Visible = false;
            label56.Visible = false;
            label57.Visible = false;
            progressBar1.Visible = false;
            bind2();
            right();
        }
        #region right
        private void right()
        {
            dtx = cedit_right.RETURN_RIGHT_LIST("工单作业", LOGIN.USID);
            btnAdd.Visible = false;
            btnSave.Visible = false;
            label15.Visible = false;
            label17.Visible = false;
            btnDel.Visible = false;
            label13.Visible = false;
            btnupload.Visible = false;
            btndelfile.Visible = false;
            label29.Visible = false;
            label28.Visible = false;
          
            if (dtx.Rows.Count > 0)
            {
                if (dtx.Rows[0]["新增权限"].ToString() == "有权限")
                {
                    btnAdd.Visible = true;
                    label17.Visible = true;
                    btnSave.Visible = true;
                    label15.Visible = true;
                    btnSave.Visible = true;
                    label15.Visible = true;
                    EDIT = "有权限";
                    btnupload.Visible = true;
                    btndelfile.Visible = true;
                    label29.Visible = true;
                    label28.Visible = true;
                }
         
                if (dtx.Rows[0]["删除权限"].ToString() == "有权限")
                {
                    btnDel.Visible = true;
                    label13.Visible = true;
                    btnupload.Visible = true;
                    btndelfile.Visible = true;
                    label29.Visible = true;
                    label28.Visible = true;
                }
         

            }

        }
        #endregion
        #region bind
        private void bind()
        {
            dataGridView2.Columns.Clear();
            dataGridView2.Rows.Clear();
            DataGridViewCheckBoxColumn dgvc1 = new DataGridViewCheckBoxColumn();
            dgvc1.Name = "复选框";
            dataGridView2.Columns.Add(dgvc1);
            DataGridViewTextBoxColumn dgvc2 = new DataGridViewTextBoxColumn();
            dgvc2.Name = "文件名";
            dataGridView2.Columns.Add(dgvc2);
           
            DataGridViewTextBoxColumn dgvc4 = new DataGridViewTextBoxColumn();
            dgvc4.Name = "索引";
            dgvc4.Visible = false;
            dataGridView2.Columns.Add(dgvc4);
            DataGridViewTextBoxColumn dgvc5 = new DataGridViewTextBoxColumn();
            dgvc5.Name = "新文件名";
            dgvc5.Visible = false;
            dataGridView2.Columns.Add(dgvc5);
            label52.Text = "";
            label53.Visible = false;
            label55.Visible = false;
            label56.Visible = false;
            label57.Visible = false;
            progressBar1.Visible = false;
           

            dataGridView1.Rows.Clear();
            this.Icon = new Icon(System.IO.Path.GetFullPath("Image/xz 200X200.ico"));
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy/MM/dd";
            dateTimePicker2.Text = (dateTimePicker1.Value.AddDays(+15)).ToString();
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "yyyy/MM/dd";
            dateTimePicker4.Format = DateTimePickerFormat.Custom;
            dateTimePicker4.CustomFormat = "yyyy/MM/dd";
            dateTimePicker5.Format = DateTimePickerFormat.Custom;
            dateTimePicker5.CustomFormat = "yyyy/MM/dd";

            dateTimePicker6.Format = DateTimePickerFormat.Custom;
            dateTimePicker6.CustomFormat = "yyyy/MM/dd";
            dateTimePicker7.Format = DateTimePickerFormat.Custom;
            dateTimePicker7.CustomFormat = "yyyy/MM/dd";
    
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.AllowUserToAddRows = false;
         
            textBox2.Focus();
            hint.Location = new Point(400, 100);
            hint.ForeColor = Color.Red;
            comboBox1.BackColor  = Color.Yellow;
            //textBox4.BackColor = Color.Yellow;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox10.ReadOnly = true;
            if (bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS) != "")
            {

                hint.Text = bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS);
            }
            else
            {
                hint.Text = "";
            }
            string v1 = dateTimePicker6.Value.ToString("yyyy/MM/dd").Replace("-", "/");
            string v2 = dateTimePicker7.Value.ToString("yyyy/MM/dd").Replace("-", "/");
            if (FROM == "Y")
            {
                
                sqb = new StringBuilder();
                sqb.AppendFormat(cWORKORDER.getsqlsi);
                sqb.AppendFormat(" WHERE A.FCID like '%{0}%'", comboBox2.Text );
                sqb.AppendFormat(" AND B.FLOW_CHART_EDITION like '%{0}%'", textBox7.Text);
                sqb.AppendFormat(" ORDER BY  A.FCKEY ASC");
            }
            else
            {
               
                sqb = new StringBuilder();
                sqb.AppendFormat(cWORKORDER.getsql);
                sqb.AppendFormat(" WHERE A.WOID like '%{0}%'", textBox11.Text);
                sqb.AppendFormat(" AND A.CNAME like '%{0}%'", textBox12.Text);
                sqb.AppendFormat(" AND A.GODE_NEED_DATE BETWEEN '{0}' AND '{1}'", "2017/05/01", "2017/06/01");//供用户测试所以要有数据
                if (comboBox3.Text != "")
                {
                    if (comboBox3.Text == "开立")
                    {
                        sqb.AppendFormat(" AND A.STATUS='OPEN'");
                    }
                    else if (comboBox3.Text == "生产中")
                    {
                        sqb.AppendFormat(" AND A.STATUS='PROCESS'");
                    }
                    else if (comboBox3.Text == "作废")
                    {
                        sqb.AppendFormat(" AND A.STATUS='SCRAP'");
                    }
                    else
                    {
                        sqb.AppendFormat(" AND A.STATUS='COMPLETE'");
                    }

                }
                sqb.AppendFormat(" ORDER BY  A.WOID ASC");
            }
            string path = "";
            dt = basec.getdts(sqb.ToString ());
        
            /*计算机名绑定站别 start*/
            if (bc.exists("select * from STEP where PCNAME ='" + bc.GetComputerName() + "'"))
            {
            
                dt = bc.GET_DT_TO_DV_TO_DT(dt, "", "计算机名='" + bc.GetComputerName() + "'");
            }
            /*计算机名绑定站别 end*/
            if (dt.Rows.Count > 0)
            {


                WOKEY = dt.Rows[0]["索引"].ToString();//默认加载工单第一项次的图片或文件地址
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                   
                    DataGridViewRow dar = new DataGridViewRow();
                    dataGridView1.Rows.Add(dar);
                    dataGridView1["工单号", i].Value = dt.Rows[i]["工单号"].ToString();
                    dataGridView1["物料编号", i].Value = dt.Rows[i]["物料编号"].ToString();
                    dataGridView1["料号", i].Value = dt.Rows[i]["料号"].ToString();
                    dataGridView1["品名", i].Value = dt.Rows[i]["品名"].ToString();
                    dataGridView1["途程编号", i].Value = dt.Rows[i]["途程编号"].ToString();
                    dataGridView1["途程代码", i].Value = dt.Rows[i]["途程代码"].ToString();
                    dataGridView1["途程名称", i].Value = dt.Rows[i]["途程名称"].ToString();
                    dataGridView1["途程版本", i].Value = dt.Rows[i]["途程版本"].ToString();
                    dataGridView1["项次", i].Value = dt.Rows[i]["项次"].ToString();
                    dataGridView1["站别编号", i].Value = dt.Rows[i]["站别编号"].ToString();
                    dataGridView1["站别名称", i].Value = dt.Rows[i]["站别名称"].ToString();
                    dataGridView1["状态", i].Value = dt.Rows[i]["状态"].ToString();
                    dataGridView1["下单日期", i].Value = dt.Rows[i]["下单日期"].ToString();
                    dataGridView1["预计完工日期", i].Value = dt.Rows[i]["生成预计完工日期"].ToString();
                    dataGridView1["数量", i].Value = dt.Rows[i]["数量"].ToString();
                    dataGridView1["进度", i].Value = dt.Rows[i]["进度"].ToString();
                    dataGridView1["完工日期", i].Value = dt.Rows[i]["完工日期"].ToString();
                    dataGridView1["客户名称", i].Value = dt.Rows[i]["客户名称"].ToString();
                    dataGridView1["备注", i].Value = dt.Rows[i]["备注"].ToString();
                    dataGridView1["制单人", i].Value = dt.Rows[i]["制单人"].ToString();
                    dataGridView1["制单日期", i].Value = dt.Rows[i]["制单日期"].ToString();
                    dataGridView1["规格", i].Value = dt.Rows[i]["规格"].ToString();
                    if (dt.Rows[i]["完工日期"].ToString() != "")
                    {
                        dataGridView1["确认完工", i].Value = "已完工";
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                        dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
               
                        DateTime d1 = Convert.ToDateTime(dt.Rows[i]["完工日期"].ToString());
                        if (!string.IsNullOrEmpty(dt.Rows[i]["生成预计完工日期"].ToString()))
                        {
                            DateTime d2 = Convert.ToDateTime(dt.Rows[i]["生成预计完工日期"].ToString());
                            if (d1 > d2)
                            {
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            }
                        }
                    }
                    else
                    {
                        dataGridView1["确认完工", i].Value = "确认完工";
                        string v11 = DateTime.Now.ToString("yyyy/MM/dd").Replace("-", "/");
                        DateTime d1 = Convert.ToDateTime(v11);
                  
                        if (!string.IsNullOrEmpty(dt.Rows[i]["生成预计完工日期"].ToString()))
                        {
                            
                            DateTime d2 = Convert.ToDateTime(dt.Rows[i]["生成预计完工日期"].ToString());
                            if (d1 > d2)
                            {
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                                dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                            }
                        }
                    }

                  
                }
                path = bc.getOnlyString(@"
SELECT PATH FROM WAREFILE 
WHERE WAREID='" + dt.Rows[0]["途程编号"].ToString() + "'  AND INITIAL_OR_OTHER='700X700'");


               /* if (path != "")
                {
                    pictureBox1.Visible = true;
                    pictureBox1.Image = Image.FromStream(System.Net.WebRequest.Create(path).GetResponse().GetResponseStream());
                }
                else
                {
                
                    pictureBox1.Visible = false;
                }*/

            }

            this.Text = "工单信息";
          
            dgvStateControl();
            comboBox2.BackColor = Color.Yellow;
            textBox7.ReadOnly = true;
            FROM = "N";
        }
        #endregion
        #region dgvStateControl
        private void dgvStateControl()
        {
            int i;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Lavender;
            int numCols1 = dataGridView1.Columns.Count;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;/*自动调整DATAGRIDVIEW的列宽*/
            for (i = 0; i < numCols1; i++)
            {
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                //this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.Columns[i].HeaderCell.Style.BackColor = Color.Lavender;
                if (dataGridView1.Columns[i].Name == "进度" || dataGridView1.Columns[i].Name == "备注" ||
                    dataGridView1.Columns[i].Name == "数量")
                {

                    dataGridView1.Columns[i].ReadOnly = false;
                }
                else
                {
                    dataGridView1.Columns[i].ReadOnly = true;
                }
                dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            for (i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;

                i = i + 1;

            }
            dataGridView2.RowHeadersDefaultCellStyle.BackColor = Color.Lavender;
            int numCols2 = dataGridView2.Columns.Count;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;/*自动调整DATAGRIDVIEW的列宽*/
            /*dataGridView1.Columns["项次"].Width = 40;
            dataGridView2.Columns["站别代码"].Width = 80;
            dataGridView2.Columns["站别名称"].Width =80;*/
            for (i = 0; i < numCols2; i++)
            {

                dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                //this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.EnableHeadersVisualStyles = false;
                dataGridView2.Columns[i].HeaderCell.Style.BackColor = Color.Lavender;

            }

            for (i = 0; i < dataGridView2.Columns.Count; i++)
            {
                dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView2.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                i = i + 1;
            }


        }
        #endregion
        public void ClearText()
        {
            comboBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox2.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            dateTimePicker1.Text = DateTime.Now.ToString("yyyy/MM/dd");
            dateTimePicker2.Text = DateTime.Now.ToString("yyyy/MM/dd");
            dateTimePicker3.Text = DateTime.Now.ToString("yyyy/MM/dd");
            dateTimePicker4.Text = DateTime.Now.ToString("yyyy/MM/dd");
            dateTimePicker5.Text = DateTime.Now.ToString("yyyy/MM/dd");
            dateTimePicker6.Text = DateTime.Now.ToString("yyyy/MM/dd");
            dateTimePicker7.Text = DateTime.Now.ToString("yyyy/MM/dd");
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
          
        }
 
    
        private void btnAdd_Click(object sender, EventArgs e)
        {
            add();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            M_int_judge = 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Focus();
            if (juage())
            {
                IFExecution_SUCCESS = false;
            }
            else
            {
                save();
                if (IFExecution_SUCCESS == true )
                {
                    add();
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
        private void add()
        {
            ClearText();
            textBox1.Text = cWORKORDER.GETID();
         
            bind();
         
            ADD_OR_UPDATE = "ADD";
           

        }
        private void save()
        {
            btnSave.Focus();
            //dgvfoucs();
            cWORKORDER.WOID = textBox1.Text;
            cWORKORDER.WAREID = comboBox1.Text;
            cWORKORDER.WO_COUNT = "0";
            cWORKORDER.FCID = comboBox2.Text;
            cWORKORDER.FLOW_CHART_EDITION = textBox7.Text;
            cWORKORDER.CNAME = textBox4.Text;
            cWORKORDER.GODE_NEED_DATE = dateTimePicker1.Text;
            cWORKORDER.DELIVERY_DATE = dateTimePicker2.Text;
            cWORKORDER.LAST_PICKING_DATE = dateTimePicker3.Text;
            cWORKORDER.COMPLETE_DATE = dateTimePicker4.Text;
            cWORKORDER.ADVICE_DELIVER_DATE = dateTimePicker5.Text;
            cWORKORDER.MAKERID = LOGIN.EMID;
            cWORKORDER.STATUS = "OPEN";
            cWORKORDER.save(dataGridView1);
            IFExecution_SUCCESS = cWORKORDER.IFExecution_SUCCESS;
            hint.Text = cWORKORDER.ErrowInfo;
            if (IFExecution_SUCCESS)
            {

                bind();
            }


            try
            {
       
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
        }
        private bool juage()
        {
            bool b = false;
           if (comboBox1 .Text =="")
            {
                hint.Text = "ID不能为空！";
                b = true;
            }
           if (bc.exists(cWORKORDER .getsql  + " WHERE A.WOID='" + IDO + "'") && EDIT != "有权限")
           {
               hint.Text = "本账号无修改权限！";
               b = true;
           }
           else if (!bc.exists(string.Format("SELECT * FROM WAREINFO WHERE WAREID='{0}'", comboBox1.Text)))
           {
               hint.Text = "ID不存于系统中！";
               b = true;
           }
           /*else if (textBox4.Text == "")
           {
               hint.Text = "数量不能为空！";
               b = true;
           }
           else if (bc.yesno (textBox4 .Text )==0)
           {
               hint.Text = "数量只能为数字！";
               b = true;
           }*/
           else if(!bc.exists("SELECT * FROM FLOW_CHART_MST WHERE WAREID='" + comboBox1.Text + "' AND ACTIVE='Y'"))
           {
               hint.Text = "此物料编号的途程不存在或未生效需先维护！";
               b = true;

           }
           else if (!bc.exists("SELECT * FROM FLOW_CHART_MST WHERE FCID='" + comboBox2.Text + "'"))
           {
               hint.Text = "此途程编号为空或不存在系统中！";
               b = true;

           }
           else if (!bc.exists("SELECT * FROM FLOW_CHART_MST WHERE FCID='" + comboBox2.Text + "' AND  WAREID='"+comboBox1 .Text  +"'"))
           {
               hint.Text =string.Format ( "此途程编号："+"{0}"+" 不是物料编码："+"{1}"+"的途程！",comboBox2.Text ,comboBox1 .Text );
               b = true;

           }
           else if (bc.exists("SELECT * FROM WORKORDER_MST WHERE WOID='" + textBox1.Text + "'") && bc.getOnlyString(@"
SELECT STATUS FROM WORKORDER_MST WHERE WOID='" + textBox1.Text + "'") != "OPEN")
           {
               hint.Text = string.Format("此工单号：" + "{0}" + " 状态不为开立不允许修改", textBox1.Text);
               b = true;
           }
         else if (juage3())
           {
            
               b = true;
           }
           /* else if (juage3()>1)
          {
              hint.Text = "默认联系人只能选择一个！";
              b = true;
          }*/
            return b;
        }
        private bool juage3()
        {
            bool b=false ;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string v1 = dataGridView1["站别名称", i].FormattedValue.ToString();
       
                if (bc.getOnlyString("SELECT M_PERCENT FROM STEP WHERE STEP='"+v1+"'")=="")
                {
                    hint.Text = string.Format("站别：{0} 并未维护过完成百分比",v1 );
                    b = true;
                    break;
                }
            }
            return b;


        }
        private void btnDel_Click(object sender, EventArgs e)
        {
          
            if (MessageBox.Show("确定要删除该工单吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (bc.getOnlyString (string.Format ("SELECT STATUS FROM WORKORDER_MST WHERE WOID='{0}'",textBox1 .Text ))!="OPEN")
                {
                  
                    hint.Text = string.Format("工单号 {0} 状态非开立不允许删除", textBox1.Text);
                }
                else
                {
                    basec.getcoms("DELETE WORKORDER_DET WHERE WOID='" + textBox1.Text + "'");
                    basec.getcoms("DELETE WORKORDER_MST WHERE WOID='" + textBox1.Text + "'");
                    bind();
                    ClearText();
                  
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region override enter
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && ((!(ActiveControl is System.Windows.Forms.TextBox) ||
                !((System.Windows.Forms.TextBox)ActiveControl).AcceptsReturn)))
            {
                SendKeys.SendWait("{Tab}");
                return true;
            }
            if (keyData == (Keys.Enter | Keys.Shift))
            {
                SendKeys.SendWait("+{Tab}");

                return true;
            }
            if (keyData == (Keys.F7))
            {

                //double_info();

                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

   

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
           

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
            int a = dataGridView1.CurrentCell.ColumnIndex;
            int b = dataGridView1.CurrentCell.RowIndex;
            int c = dataGridView1.Columns.Count - 1;
            int d = dataGridView1.Rows.Count - 1;


            if (a == c && b == d)
            {
                if (dt.Rows.Count >= 6)
                {

                    DataRow dr = dt.NewRow();
                    int b1 = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["项次"].ToString());
                    dr["项次"] = Convert.ToString(b1 + 1);
                    dt.Rows.Add(dr);
                }

            }
            //dgvfoucs();

        }

    

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
       
        }

   

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
     
            try
            {

                BASE_INFO.WAREINFO FRM = new CSPSS.BASE_INFO.WAREINFO();
                FRM.WORKORDER_USE();
                FRM.ShowDialog();
                this.comboBox1.IntegralHeight = false;//使组合框不调整大小以显示其所有项
                this.comboBox1.DroppedDown = false;//使组合框不显示其下拉部分
                this.comboBox1.IntegralHeight = true;//恢复默认值
                if (IF_DOUBLE_CLICK)
                {
                    comboBox1.Text = WAREID;
                    textBox2.Text = CO_WAREID;
                    textBox3.Text = WNAME;
                }
                textBox4.Focus();

                DataTable dtx = bc.getdt("SELECT * FROM FLOW_CHART_MST WHERE WAREID='" + comboBox1.Text + "' AND ACTIVE='Y'");
                if (dtx.Rows.Count > 0)
                {
                    hint.Text = "";
                    comboBox2.Text = dtx.Rows[0]["FCID"].ToString();
                    textBox5.Text = dtx.Rows[0]["FLOW_CHART_ID"].ToString();
                    textBox6.Text = dtx.Rows[0]["FLOW_CHART"].ToString();
                    textBox7.Text = dtx.Rows[0]["FLOW_CHART_EDITION"].ToString();
                    FROM = "Y";
                    bind();

                }
                else
                {
                    hint.Text = "此物料编号不存在途程或是没有生效需先维护";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hint.Text = "";
            int i=dataGridView1 .CurrentCell.RowIndex ;
            int j=dataGridView1 .CurrentCell .ColumnIndex ;
            string v1 = Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim();
            if (v1 != "")
            {
                textBox1.Text = Convert.ToString(dataGridView1["工单号", dataGridView1.CurrentCell.RowIndex].Value).Trim();
                comboBox1.Text = Convert.ToString(dataGridView1["物料编号", dataGridView1.CurrentCell.RowIndex].Value).Trim();
                textBox2.Text = Convert.ToString(dataGridView1["料号", dataGridView1.CurrentCell.RowIndex].Value).Trim();
                textBox3.Text = Convert.ToString(dataGridView1["品名", dataGridView1.CurrentCell.RowIndex].Value).Trim();
                textBox4.Text = Convert.ToString(dataGridView1["客户名称", dataGridView1.CurrentCell.RowIndex].Value).Trim();
                comboBox2.Text = Convert.ToString(dataGridView1["途程编号", dataGridView1.CurrentCell.RowIndex].Value).Trim();
                textBox5.Text = Convert.ToString(dataGridView1["途程代码", dataGridView1.CurrentCell.RowIndex].Value).Trim();
                textBox6.Text = Convert.ToString(dataGridView1["途程名称", dataGridView1.CurrentCell.RowIndex].Value).Trim();
                textBox7.Text = Convert.ToString(dataGridView1["途程版本", dataGridView1.CurrentCell.RowIndex].Value).Trim();
                dateTimePicker1.Text = Convert.ToString(dataGridView1["下单日期", dataGridView1.CurrentCell.RowIndex].Value).Trim();
                dateTimePicker2.Text = Convert.ToString(dataGridView1["预计完工日期", dataGridView1.CurrentCell.RowIndex].Value).Trim();
                /*dateTimePicker3.Text = dt.Rows[i]["下料日期"].ToString();
                dateTimePicker4.Text = dt.Rows[i]["齐套日期"].ToString();
                dateTimePicker5.Text = dt.Rows[i]["建议交期"].ToString();*/
                string v2 = Convert.ToString(dataGridView1["工单号", dataGridView1.CurrentCell.RowIndex].Value).Trim();
                string v3 = Convert.ToString(dataGridView1["项次", dataGridView1.CurrentCell.RowIndex].Value).Trim();
                string v4 = Convert.ToString(dataGridView1["备注", dataGridView1.CurrentCell.RowIndex].Value).Trim();
                WOKEY = bc.getOnlyString("SELECT WOKEY FROM WORKORDER_DET WHERE WOID='"+v2+"' AND SN='"+v3+"'");
           
                string varDate = DateTime.Now.ToString("yyy/MM/dd").Replace("-", "/");
                if (dataGridView1.Columns[j].Name == "确认完工")
                {
                    if (Convert.ToString(dataGridView1["完工日期",dataGridView1.CurrentCell.RowIndex].Value).Trim() != "")
                    {
                        hint.Text = "此站别已经完工不能再修改";
                    }
                    else
                    {
                        basec.getcoms(@"UPDATE WORKORDER_DET SET STEP_COMPLETE_DATE='" + varDate +
                            "',WORKORDER_STATUS_DET='PROCESS' WHERE WOID='" + v2 + "' AND SN='" + v3 + "'");
                        if (JUAGE_WORKORDER_STATUS(v2))
                        {
                            basec.getcoms(@"UPDATE WORKORDER_MST SET
                           STATUS='PROCESS' WHERE WOID='" + v2 + "'");

                            for (int j1 = 0; j1 < dataGridView1.Rows.Count; j1++)
                            {
                                string v5 = dataGridView1["工单号", j1].FormattedValue.ToString();
                                if (v5 == textBox1.Text)
                                {
                                    dataGridView1["状态", j1].Value = "生产中";
                                }
                            }
                          
                        }
                        else
                        {
                            basec.getcoms(@"UPDATE WORKORDER_MST SET
                           STATUS='COMPLETE' WHERE WOID='" + v2 + "'");
                            for (int j1 = 0; j1 < dataGridView1.Rows.Count; j1++)
                            {
                                string v5 = dataGridView1["工单号", j1].FormattedValue.ToString();
                                if (v5 == textBox1.Text)
                                {
                                    dataGridView1["状态", j1].Value = "结案";
                                }
                            }
                           
                        }
                        dataGridView1["确认完工", i].Value = "已完工";
                        dataGridView1["完工日期", i].Value = varDate;
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                        dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                        DateTime d1 = Convert.ToDateTime(DateTime .Now.ToString ("yyyy/MM/dd").Replace ("-","/"));
                        if (dataGridView1["预计完工日期", i].FormattedValue.ToString() != "")
                        {
                            DateTime d2 = Convert.ToDateTime(dataGridView1["预计完工日期", i].FormattedValue.ToString());
                            if (d1 > d2)
                            {
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            }
                        }
                     
                    }
                }

                bind2();
         
            }
            }
        private bool JUAGE_WORKORDER_STATUS(string WOID)
        {
            bool b = false;
            dt = bc.getdt(cWORKORDER.getsql + " WHERE A.WOID='"+WOID  +"'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["完工日期"].ToString () ==""  )
                {
                    
                        b = true;
                        break;
                }

            }
            return b;


        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            hint.Text = "";
            int i = dataGridView1.CurrentCell.RowIndex;
            int j = dataGridView1.CurrentCell.ColumnIndex;
            string v1 = Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim();
            if (v1 != "")
            {

                string v2 = Convert.ToString(dataGridView1["工单号", dataGridView1.CurrentCell.RowIndex].Value).Trim();
                string v3 = Convert.ToString(dataGridView1["项次", dataGridView1.CurrentCell.RowIndex].Value).Trim();
                string v4 = Convert.ToString(dataGridView1["备注", dataGridView1.CurrentCell.RowIndex].Value).Trim();
                string v5 = Convert.ToString(dataGridView1["进度", dataGridView1.CurrentCell.RowIndex].Value).Trim();
                string v6 = Convert.ToString(dataGridView1["数量", dataGridView1.CurrentCell.RowIndex].Value).Trim();
                string varDate = DateTime.Now.ToString("yyy/MM/dd").Replace("-", "/");
                if (dataGridView1.Columns[j].Name == "数量")
                {

                    basec.getcoms(@"UPDATE WORKORDER_DET SET COUNT='" + v6 +
                        "' WHERE WOID='" + v2 + "' AND SN='" + v3 + "'");
                }
                if (dataGridView1.Columns[j].Name == "备注")
                {

                    basec.getcoms(@"UPDATE WORKORDER_DET SET REMARK='" + v4 +
                        "' WHERE WOID='" + v2 + "' AND SN='" + v3 + "'");
                }
              

                if (Convert.ToString(dataGridView1["完工日期", dataGridView1.CurrentCell.RowIndex].Value).Trim() != "")
                {
                    hint.Text = "此站别已经完工不能再修改";
                    //MessageBox.Show("此站别已经完工不能再修改", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(dataGridView1.Columns[j].Name == "进度")
                {
                            basec.getcoms(@"UPDATE WORKORDER_DET SET SCHEDULE='" + v5+
                        "' WHERE WOID='" + v2 + "' AND SN='" + v3 + "'");
                }
                if(v5=="100")
                {
                    basec.getcoms(@"UPDATE WORKORDER_DET SET STEP_COMPLETE_DATE='" + varDate +
                        "' WHERE WOID='" + v2 + "' AND SN='" + v3 + "'");

                    dataGridView1["确认完工", i].Value = "已完工";
                    dataGridView1["完工日期", i].Value = varDate;
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    DateTime d1 = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd").Replace("-", "/"));
                    DateTime d2 = Convert.ToDateTime(dataGridView1["预计完工日期", i].FormattedValue.ToString());
                    if (d1 > d2)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                }



                if (v5 == "")
                {

                }

                
                else   if (JUAGE_WORKORDER_STATUS(v2))
                {
                    basec.getcoms(@"UPDATE WORKORDER_MST SET
                           STATUS='PROCESS' WHERE WOID='" + v2 + "'");

                    for (int j1 = 0; j1 < dataGridView1.Rows.Count; j1++)
                    {
                        string v7 = dataGridView1["工单号", j1].FormattedValue.ToString();
                        if (v7 == textBox1.Text)
                        {
                            dataGridView1["状态", j1].Value = "生产中";
                        }
                    }

                }
                else
                {
                    basec.getcoms(@"UPDATE WORKORDER_MST SET
                           STATUS='COMPLETE' WHERE WOID='" + v2 + "'");
                    for (int j1 = 0; j1 < dataGridView1.Rows.Count; j1++)
                    {
                        string v7 = dataGridView1["工单号", j1].FormattedValue.ToString();
                        if (v7 == textBox1.Text)
                        {
                            dataGridView1["状态", j1].Value = "结案";
                        }
                    }

                }
            }
        }
        private void comboBox2_DropDown(object sender, EventArgs e)
        {

            PRODUCTION_MANAGE.FLOW_CHART FRM = new CSPSS.PRODUCTION_MANAGE.FLOW_CHART();
            FRM.WORKORDER_USE();
            FRM.ShowDialog();
            this.comboBox2.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.comboBox2.DroppedDown = false;//使组合框不显示其下拉部分
            this.comboBox2.IntegralHeight = true;//恢复默认值
            if (IF_DOUBLE_CLICK)
            {
                comboBox2.Text = FCID;
                textBox5.Text = FLOW_CHART_ID;
                textBox6.Text = FCNAME;
                textBox7.Text = FLOW_CHART_EDITION;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        public void BATCH_USE()
        {
            dataGridView1.ReadOnly = true;
            select = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bc.getOnlyString("SELECT STATUS FROM WORKORDER_MST WHERE WOID='" + textBox1.Text + "'") != "OPEN")
            {
                hint.Text = string.Format("此工单号：" + "{0}" + " 状态不为开立不允许作废", textBox1.Text);
            }
            else
            {
                basec.getcoms("UPDATE WORKORDER_MST SET STATUS='SCRAP' WHERE WOID='" + textBox1.Text + "'");
                hint.Text = "已经作废";
                bind();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Text = (dateTimePicker1.Value.AddDays(+15)).ToString();
        }

        private void dateTimePicker6_ValueChanged(object sender, EventArgs e)
        {
      
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            bind();
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) //判断是不是右键
            {
                Control control = new Control();
                Point ClickPoint = new Point(e.X, e.Y);
                control.GetChildAtPoint(ClickPoint);
                if (dataGridView1.HitTest(e.X, e.Y).RowIndex >= 0 && dataGridView1.HitTest(e.X, e.Y).ColumnIndex >= 0)//判断你点的是不是一个信息行里
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.HitTest(e.X, e.Y).RowIndex].Cells[dataGridView1.HitTest(e.X, e.Y).ColumnIndex];
                    ContextMenu con = new ContextMenu();
                    MenuItem menuDeleteknowledge = new MenuItem("复制");
                    menuDeleteknowledge.Click += new EventHandler(btndgvInfoCopy_Click);
                    con.MenuItems.Add(menuDeleteknowledge);
                    this.dataGridView1.ContextMenu = con;
                    con.Show(dataGridView1, new Point(e.X + 10, e.Y));
                }
            }
        }
        private void btndgvInfoCopy_Click(object sender, EventArgs e)
        {

            dgvCopy(ref dataGridView1);
        }
        private void dgvCopy(ref DataGridView dgv)
        {
            if (dgv.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                try
                {
                    Clipboard.SetDataObject(dgv.GetClipboardContent());
                }
                catch (Exception MyEx)
                {
                    MessageBox.Show(MyEx.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dataGridView1_DataMemberChanged(object sender, EventArgs e)
        {
            int rows=dataGridView1 .CurrentCell .RowIndex ;

        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int rowsindex = dataGridView1.CurrentCell.RowIndex;
            int columnsindex = dataGridView1.CurrentCell.ColumnIndex;
            if (dataGridView1.Columns[columnsindex].Name == "数量" && bc.yesno(e.FormattedValue.ToString()) == 0)
            {
                e.Cancel = true;
                MessageBox.Show("只能输入数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (dataGridView1.Columns[columnsindex].Name == "进度" && bc.yesno(e.FormattedValue.ToString()) == 0)
            {
                e.Cancel = true;
                MessageBox.Show("只能输入数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnupload_Click(object sender, EventArgs e)
        {
            DataTable dty = bc.getdt("SELECT * FROM WAREFILE WHERE WAREID='" + WOKEY  + "'");
            if (juage())
            {

            }
            /*else if (dty.Rows.Count.ToString() == "2")
            {

                hint.Text = "最多只能上传一张图片";
            }*/
            else
            {

                uploadfile();
            }
            try
            {


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
        }
        #region uploadfile
        private void uploadfile()
        {
            CFileInfo cfileinfo = new CFileInfo();
            int i = 0;
            label53.Visible = false;
            label55.Visible = false;
            label56.Visible = false;
            label57.Visible = false;
            progressBar1.Visible = false;
            /*  string v2 = bc.getOnlyString("SELECT EDIT FROM RIGHTLIST WHERE USID='" + LOGIN.USID + "' AND NODE_NAME='传单作业'");
              if (v2 != "Y" && ADD_OR_UPDATE == "UPDATE")
              {
                  hint.Text = "您没有修改权限不能修改上传";
              }
              else*/
            label52.Text = "";
            if (bc.RETURN_SERVER_IP_OR_DOMAIN() == "")
            {
                hint.Text = "未设置服务器IP或域名";
            }

            else
            {
                OpenFileDialog openf = new OpenFileDialog();
                if (openf.ShowDialog() == DialogResult.OK)
                {

                    Random ro = new Random();
                    string stro = ro.Next(80, 10000000).ToString() + "-";
                    string NeWAREID = DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + stro;

                    cfileinfo.SERVER_IP_OR_DOMAIN = bc.RETURN_SERVER_IP_OR_DOMAIN();
                    WATER_MARK_CONTENT = "";//水印内容
                    //cfileinfo.UploadImage(openf.FileName, Path.GetFileName(openf.FileName), textBox1 .Text );
                    //this.UploadFile(openf.FileName, System.IO.Path.GetFileName(openf.FileName), "File/", textBox1.Text);

                    string v21 = bc.FROM_RIGHT_UNTIL_CHAR(Path.GetFileName(openf.FileName), 46);
                    OLD_FILE_NAME = Path.GetFileName(openf.FileName);
                    NEW_FILE_NAME = NeWAREID + Path.GetFileName(openf.FileName);
                    //如果上传的是图片文件
                    if (v21 == "jpeg" || v21 == "jpg" || v21 == "JPG" || v21 == "png" || v21 == "bmp" || v21 == "gif")
                    {


                        //裁切小图
                        cfileinfo.MakeThumbnail(openf.FileName, "d:\\80X80" + Path.GetFileName(openf.FileName), 80, 80, "Cut");
                        //裁切700*700
                        cfileinfo.MakeThumbnail(openf.FileName, "d:\\700X700" + Path.GetFileName(openf.FileName), 700, 700, "Cut");

                        //小图加水印
                        cfileinfo.ADD_WATER_MARK("d:\\80X80" + Path.GetFileName(openf.FileName), "d:\\80X80" + NeWAREID + Path.GetFileName(openf.FileName), WATER_MARK_CONTENT);
                        //700*700图加水印
                        cfileinfo.ADD_WATER_MARK("d:\\700X700" + Path.GetFileName(openf.FileName), "d:\\700X700" + NeWAREID + Path.GetFileName(openf.FileName), WATER_MARK_CONTENT);
                        //原图加水印
                        cfileinfo.ADD_WATER_MARK(openf.FileName, "d:\\INITIAL" + NeWAREID + Path.GetFileName(openf.FileName), WATER_MARK_CONTENT);
                        INITIAL_OR_OTHER = "INITIAL";

                        //上传原图
                        i = Upload_Request("http://" + bc.RETURN_SERVER_IP_OR_DOMAIN() + "/webuploadfile/default.aspx", "D:\\INITIAL" + NeWAREID + System.IO.Path.GetFileName(openf.FileName),
                                "INITIAL" + NeWAREID + System.IO.Path.GetFileName(openf.FileName), progressBar1, textBox1.Text);

                        //上传80X80的缩略图
                        INITIAL_OR_OTHER = "80X80";
                        i = Upload_Request("http://" + bc.RETURN_SERVER_IP_OR_DOMAIN() + "/webuploadfile/default.aspx", "D:\\80X80" + NeWAREID + System.IO.Path.GetFileName(openf.FileName),
                                "80X80" + NeWAREID + System.IO.Path.GetFileName(openf.FileName), progressBar1, textBox1.Text);

                        //上传700X700的缩略图
                        INITIAL_OR_OTHER = "700X700";
                        i = Upload_Request("http://" + bc.RETURN_SERVER_IP_OR_DOMAIN() + "/webuploadfile/default.aspx", "D:\\700X700" + NeWAREID + System.IO.Path.GetFileName(openf.FileName),
                                "700X700" + NeWAREID + System.IO.Path.GetFileName(openf.FileName), progressBar1, textBox1.Text);

                        //删除本地临时水印图及剪切图
                        if (File.Exists("d:\\80X80" + NeWAREID + Path.GetFileName(openf.FileName)))
                        {
                            File.Delete("d:\\80X80" + NeWAREID + Path.GetFileName(openf.FileName));
                            File.Delete("d:\\700X700" + NeWAREID + Path.GetFileName(openf.FileName));
                            File.Delete("d:\\80X80" + Path.GetFileName(openf.FileName));
                            File.Delete("d:\\700X700" + Path.GetFileName(openf.FileName));
                            File.Delete("d:\\" + Path.GetFileName(openf.FileName));
                            File.Delete("d:\\INITIAL" + NeWAREID + Path.GetFileName(openf.FileName));
                        }
                        if (i == 1)
                        {
                            label52.Text = "成功上传";
                        }
                        else
                        {
                            label52.Text = "上传失败";
                        }

                        bind2();
                    }
                    else
                    {
                        //MessageBox.Show("只能上传图片格式为jpeg/jpg/png/bmp/gif", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        /*label53.Visible = true;
                        label55.Visible = true;
                        label56.Visible = true;
                        label57.Visible = true;
                        progressBar1.Visible = true;*/
                        //上传的是非图片文件
                        INITIAL_OR_OTHER = "INITIAL";
                        i = Upload_Request("http://" + bc.RETURN_SERVER_IP_OR_DOMAIN() + "/webuploadfile/default.aspx", openf.FileName,
                                                      "INITIAL" + NeWAREID + System.IO.Path.GetFileName(openf.FileName), progressBar1, textBox1.Text);
                        bind2();
                    }

                }
            }

        }
        #endregion
        #region Upload_Request
        public int Upload_Request(string address, string fileNamePath, string saveName, ProgressBar progressBar, string WAREID)
        {
            int returnValue = 0;
            // 要上传的文件

            FileStream fs = new FileStream(fileNamePath, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fs);
            //时间戳
            string strBoundary = "----------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + strBoundary + "\r\n");
            //请求头部信息
            StringBuilder sb = new StringBuilder();
            sb.Append("--");
            sb.Append(strBoundary);
            sb.Append("\r\n");
            sb.Append("Content-Disposition: form-data; name=\"");
            sb.Append("file");
            sb.Append("\"; filename=\"");
            sb.Append(saveName);
            sb.Append("\"");
            sb.Append("\r\n");
            sb.Append("Content-Type: ");
            sb.Append("application/octet-stream");
            sb.Append("\r\n");
            sb.Append("\r\n");
            string strPostHeader = sb.ToString();


            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(strPostHeader);
            // 根据uri创建HttpWebRequest对象
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(new Uri(address));
            httpReq.Method = "POST";
            //对发送的数据不使用缓存
            httpReq.AllowWriteStreamBuffering = false;
            //设置获得响应的超时时间（300秒）
            httpReq.Timeout = 300000;
            httpReq.ContentType = "multipart/form-data; boundary=" + strBoundary;
            long length = fs.Length + postHeaderBytes.Length + boundaryBytes.Length;
            long fileLength = fs.Length;
            httpReq.ContentLength = length;
            if (fileLength / 1048576.0 > 2.5)
            {

                label52.Visible = false;
                label53.Visible = false;
                label55.Visible = false;
                label56.Visible = false;
                label57.Visible = false;
                progressBar1.Visible = false;
                MessageBox.Show("上传的图片长度为:" + (fileLength / 1048576.0).ToString("F2") + "M" + " 已经大于允许上传的2.5M");
            }
            else
            {
                try
                {
                    progressBar.Maximum = int.MaxValue;
                    progressBar.Minimum = 0;
                    progressBar.Value = 0;
                    //每次上传4k
                    int bufferLength = 4096;
                    byte[] buffer = new byte[bufferLength];
                    //已上传的字节数
                    long offset = 0;
                    //开始上传时间
                    DateTime startTime = DateTime.Now;
                    int size = r.Read(buffer, 0, bufferLength);

                    Stream postStream = httpReq.GetRequestStream();
                    //发送请求头部消息
                    postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
                    while (size > 0)
                    {
                        postStream.Write(buffer, 0, size);
                        offset += size;
                        progressBar.Value = (int)(offset * (int.MaxValue / length));
                        TimeSpan span = DateTime.Now - startTime;
                        double second = span.TotalSeconds;
                        label53.Text = "已用时：" + second.ToString("F2") + "秒";

                        if (second > 0.001)
                        {
                            label55.Text = "平均速度：" + (offset / 1024 / second).ToString("0.00") + "KB/秒";
                        }
                        else
                        {
                            label55.Text = "正在连接…";
                        }
                        label56.Text = "已上传：" + (offset * 100.0 / length).ToString("F2") + "%";
                        label57.Text = (offset / 1048576.0).ToString("F2") + "M/" + (fileLength / 1048576.0).ToString("F2") + "M";
                        Application.DoEvents();
                        size = r.Read(buffer, 0, bufferLength);
                    }
                    //添加尾部的时间戳
                    postStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                    postStream.Close();

                    string year = DateTime.Now.ToString("yy");
                    string month = DateTime.Now.ToString("MM");
                    string day = DateTime.Now.ToString("dd");
                    string varDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    string v1 = bc.numYMD(20, 12, "000000000001", "SELECT * FROM WAREFILE", "FLKEY", "FL");
                    string newFileName, uriString;
                    newFileName = System.IO.Path.GetFileName(saveName);
                    uriString = "http://" + bc.RETURN_SERVER_IP_OR_DOMAIN() + "/uploadfile/" + newFileName;


                    String sql = @"
INSERT INTO  WAREFILE 
(
FLKEY,
WAREID,
OLD_FILE_NAME,
NEW_FILE_NAME,
PATH,
INITIAL_OR_OTHER,
DATE,
YEAR,
MONTH,
DAY
) 
VALUES
(
@FLKEY,
@WAREID,
@OLD_FILE_NAME,
@NEW_FILE_NAME,
@PATH,
@INITIAL_OR_OTHER,
@DATE,
@YEAR,
@MONTH,
@DAY

)";
                    SqlConnection sqlcon = bc.getcon();
                    SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                    sqlcom.Parameters.Add("@FLKEY", SqlDbType.VarChar, 20).Value = v1;
                    sqlcom.Parameters.Add("@WAREID", SqlDbType.VarChar, 20).Value = WOKEY;
                    sqlcom.Parameters.Add("@OLD_FILE_NAME", SqlDbType.VarChar, 100).Value = OLD_FILE_NAME;
                    sqlcom.Parameters.Add("@NEW_FILE_NAME", SqlDbType.VarChar, 100).Value = NEW_FILE_NAME;
                    sqlcom.Parameters.Add("@PATH", SqlDbType.VarChar, 100).Value = uriString;
                    sqlcom.Parameters.Add("@INITIAL_OR_OTHER", SqlDbType.VarChar, 100).Value = INITIAL_OR_OTHER;
                    sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
                    sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
                    sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
                    sqlcom.Parameters.Add("@DAY", SqlDbType.VarChar, 20).Value = day;
                    sqlcon.Open();
                    sqlcom.ExecuteNonQuery();
                    sqlcon.Close();


                    //获取服务器端的响应
                    WebResponse webRespon = httpReq.GetResponse();
                    Stream s = webRespon.GetResponseStream();
                    StreamReader sr = new StreamReader(s);
                    //读取服务器端返回的消息
                    String sReturnString = sr.ReadLine();
                    s.Close();
                    sr.Close();
                    if (sReturnString == "Success")
                    {
                        returnValue = 1;
                    }
                    else if (sReturnString == "Error")
                    {
                        returnValue = 0;
                    }
                }
                catch
                {
                    returnValue = 0;
                }
                finally
                {
                    fs.Close();
                    r.Close();
                }
            }
            return returnValue;
        }
        #endregion
        #region bind2
        private void bind2()
        {
            dt3 = new DataTable();
            dt3 = bc.getdt(@"
SELECT cast(0   as   bit)   as   复选框,
OLD_FILE_NAME AS 文件名,NEW_FILE_NAME AS 新文件名,FLKEY AS 索引,
PATH FROM WAREFILE WHERE WAREID='" + WOKEY  + "'  AND INITIAL_OR_OTHER='INITIAL'");


            dataGridView2.Rows.Clear();//在下一次增加行前需清空上一次产生的行，否则显示行数不正常
            if (dt3.Rows.Count > 0)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {

                    DataGridViewRow dgr = new DataGridViewRow();
                    dataGridView2.Rows.Add(dgr);
                    dataGridView2["复选框", i].Value = false;
                    dataGridView2["文件名", i].Value = dt3.Rows[i]["文件名"].ToString();


                    dataGridView2["索引", i].Value = dt3.Rows[i]["索引"].ToString();

                }

                this.WindowState = FormWindowState.Maximized;
                Color c = System.Drawing.ColorTranslator.FromHtml("#efdaec");
            }
            dgvStateControl();
        }
        #endregion
        private void btndelfile_Click(object sender, EventArgs e)
        {
            try
            {
                /*string v21 = bc.getOnlyString("SELECT EDIT FROM RIGHTLIST WHERE USID='" + LOGIN.USID + "' AND NODE_NAME='传单作业'");
                if (v21 != "Y" && ADD_OR_UPDATE == "UPDATE")
                {
                    hint.Text = "您没有修改权限不能删除文件";
                }
                else if (vou.CheckIfALLOW_SAVEOR_DELETE(textBox1.Text, LOGIN.USID))
                {
                    hint.Text = vou.ErrowInfo;
                }
                else
                {
                

                }*/
                if (MessageBox.Show("确定要删除该文件吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (dt3.Rows.Count > 0)
                    {

                        for (int i = 0; i < dt3.Rows.Count; i++)
                        {
                            if (dataGridView2.Rows[i].Cells[0].EditedFormattedValue.ToString() == "True")
                            {

                                string v2 = dt3.Rows[i]["索引"].ToString();
                                string v4 = dt3.Rows[i]["新文件名"].ToString();
                                bc.getcom(@"INSERT INTO SERVER_DELETE_FILE(FLKEY,NEW_FILE_NAME) VALUES ('" + v2 + "','" + v4 + "')");
                                bc.getcom("DELETE WAREFILE WHERE NEW_FILE_NAME='" + v4 + "'");

                            }
                        }
                        bind2();

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = dataGridView2.CurrentCell.RowIndex;

                if (dataGridView2.CurrentCell.ColumnIndex == 1)
                {
                    SaveFileDialog sfl = new SaveFileDialog();
                    sfl.FileName = dt3.Rows[dataGridView2.CurrentCell.RowIndex]["文件名"].ToString();
                    sqb = new StringBuilder();
                    sqb.AppendFormat("SELECT PATH FROM WAREFILE WHERE ");
                    sqb.AppendFormat(" NEW_FILE_NAME='{0}'", dt3.Rows[i]["新文件名"].ToString());
                    sqb.AppendFormat(" AND INITIAL_OR_OTHER='INITIAL'");
                    WebClient wclient = new WebClient();
                    string v1 = bc.getOnlyString(sqb.ToString());
                    wclient.DownloadFile(v1, "d:\\" + dt3.Rows[dataGridView2.CurrentCell.RowIndex]["文件名"].ToString());
                    string v2 = "d:\\" + dt3.Rows[dataGridView2.CurrentCell.RowIndex]["文件名"].ToString();
                    /*DataTable dt3x = bc.getdt("SELECT * FROM WAREFILE WHERE FLKEY='" + dt3.Rows[dataGridView1.CurrentCell.RowIndex]["索引"].ToString() + "'");
                    Byte[] byte2 = (byte[])dt3x.Rows[0]["IMAGE_DATA"];
                    System.IO.File.WriteAllBytes(sfl.FileName, byte2);*/
                    if (File.Exists(v2))
                    {
                        System.Diagnostics.Process.Start(v2);
                       
                    }
                
                 

                    //hint.Text = "已下载";

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists("D:\\汽车报价.xlsx"))
            {
            
                System.Diagnostics.Process.Start("D:\\汽车报价.xlsx");
            }
        }

   


  

     
   
    }
}
