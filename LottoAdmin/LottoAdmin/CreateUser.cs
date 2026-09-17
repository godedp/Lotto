using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Spreadsheet;
using LottoAdmin.ClassUtil;

namespace LottoAdmin
{
    public partial class CreateUser : Form
    {
        DataTable dt = new DataTable();
        Class.Commondata commondata = new Class.Commondata();
        MD5 md5 = new MD5();
        string sqlcmd;
        string mode = "A";
        string tmpID = string.Empty;
        public CreateUser()
        {
            InitializeComponent();
        }
        public string UserName { get; set; }

        private void CreateUser_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            sqlcmd = $@"select id , username , userstatus , userAdmin from user ";
            dt = commondata.MyExecuteReader(sqlcmd);
            DGV1.DataSource = dt;
        }

        private void DGV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                mode = "E";
                txtUserName.Enabled = false;
                txtUserPassword.Enabled = false;
                tmpID = DGV1.Rows[e.RowIndex].Cells["id"].Value.ToString();
                txtUserName.Text = DGV1.Rows[e.RowIndex].Cells["username"].Value.ToString();
                if (DGV1.Rows[e.RowIndex].Cells["userAdmin"].Value.ToString() == "0")
                {
                    CBAdmin.Checked = false;
                }
                else
                {
                    CBAdmin.Checked = true;
                }
                if (DGV1.Rows[e.RowIndex].Cells["userstatus"].Value.ToString() == "0")
                {
                    CBStatus.Checked = false;
                }
                else 
                { 
                    CBStatus.Checked = true;
                }
            }
        }

        private void Clear()
        {
            mode = "A";
            txtUserName.Enabled = true;
            txtUserPassword.Enabled = true;
            txtUserName.Text = string.Empty;
            txtUserPassword.Text = string.Empty;
            CBAdmin.Checked = false;
            CBStatus.Checked = false;
            tmpID = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim().Length == 0) 
            {
                MessageBox.Show("กรุณาระบุผู้ใช้งาน");
                return;
            }
            if (mode == "A") 
            {
                if (txtUserPassword.Text.Trim().Length == 0)
                {
                    MessageBox.Show("กรุณาระบุรหัสผ่าน");
                    return;
                }
                sqlcmd = $@"insert into user (UserName , UserPassword , UserStatus , UserAdmin , CreateUser)
                            values 
                            ('{txtUserName.Text.Trim()}','{md5.PasswordMD5(txtUserPassword.Text.Trim())}',{CBStatus.Checked},{CBAdmin.Checked},'{UserName}' )";
            }
            else if (mode == "E")
            {
                sqlcmd = $@"update user set userstatus = {CBStatus.Checked} , userAdmin = {CBAdmin.Checked} , UpdateUser = '{UserName}' where id = {tmpID} ";

            }
            if (commondata.MyExecuteNonQuery(sqlcmd) == true)
            {
                Clear();
                LoadData();
            }
            else
            {
                MessageBox.Show("กรุณาตรวจสอบผู้ใช้งาน");
            }
        }
    }
}
