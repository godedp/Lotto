using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LottoAdmin.ClassUtil;

namespace LottoAdmin
{
    public partial class ChangePassword : Form
    {
        DataTable dt = new DataTable();
        Class.Commondata commondata = new Class.Commondata();
        MD5 md5 = new MD5();
        public ChangePassword()
        {
            InitializeComponent();
        }
        public string UserName { get; set; }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtUserPassword.Text.Trim().Length == 0 )
            {
                MessageBox.Show("กรุณาใส่หรัสผ่านเดิม");
                return;
            }
            if (txtNewPassword.Text.Trim().Length == 0 )
            {
                MessageBox.Show("กรุณาใส่หรัสผ่านใหม่");
                return;
            }
            if (txtConfirmPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("กรุณาใส่ยืนยันรหัสผ่านใหม่");
                return;
            }
            if (txtNewPassword.Text != txtConfirmPassword.Text) 
            {
                MessageBox.Show("รหัสผ่านใหม่และยืนยันรหัสผ่านใหม่ไม่ตรงกัน");
                return;
            }
            string sqlcmd;
            md5 = new MD5();
            string newPass = md5.PasswordMD5(txtConfirmPassword.Text);
            md5 = new MD5();
            string oldPass = md5.PasswordMD5(txtUserPassword.Text);
            sqlcmd = $@"update user 
                        set UserPassword = '{newPass}'
                        , updateUser = '{UserName}'
                        where UserName = '{UserName}'
                        and UserPassword = '{oldPass}'";
            if (commondata.MyExecuteNonQuery(sqlcmd) == false)
            {
                MessageBox.Show("กรุณาตรวจสอบรหัสผ่าน");
                return;
            }
            else
            {
                this.Dispose();
            }
        }
    }
}
