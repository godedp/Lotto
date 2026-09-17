using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace LottoAdmin
{
    partial class Dialog : Form
    {
        DataTable dt = new DataTable();
        string sqlcmd = string.Empty;
        Class.Commondata commondata = new Class.Commondata();   
        private void Dialog_Load(object sender, EventArgs e)
        {
            sqlcmd = "SELECT * FROM round ORDER BY id desc";
            dt = commondata.MyExecuteReader(sqlcmd);
            ddl1.DisplayMember = "CreateDTM";
            ddl1.ValueMember = "Id";
            ddl1.DataSource = dt;
            
        }
    }
}
