using LottoAdmin.ClassUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LottoAdmin
{
    public partial class FrmLogin : Form
    {

        DataTable dt = new DataTable();
        Class.Commondata commondata = new Class.Commondata();
        MD5 md5 = new MD5();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim().Length == 0) 
            {
                MessageBox.Show("กรุณาระบุ ผู้ใช้งาน");
                return;
            }
            if(txtUserPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("กรุณาระบุ รหัสผ่าน");
                return;
            }
            
            string sqlcmd = string.Empty;
            sqlcmd = $@"select * 
                        from user 
                        where userName = '{txtUserName.Text.Trim()}' 
                        and userPassword = '{md5.PasswordMD5(txtUserPassword.Text.Trim())}'
                        and userStatus = 1";
            dt = commondata.MyExecuteReader(sqlcmd);
            if (dt.Rows.Count != 0 )
            {
                
                DialogNo dialogNo = new DialogNo();
                dialogNo.UserName = dt.Rows[0]["UserName"].ToString();
                dialogNo.Admin = Convert.ToBoolean(dt.Rows[0]["UserAdmin"]);
                dialogNo.Show();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("กรุณาตรวจสอบ ผู้ใช้งาน และ รหัสผ่าน");
                txtUserName.Text = string.Empty;
                txtUserPassword.Text = string.Empty;
                return;
            }
        }
    }
}
