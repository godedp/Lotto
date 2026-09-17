using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace LottoAdmin
{
    public partial class FrmReport : Form
    {
        DataTable dt = new DataTable();
        string sqlcmd = string.Empty;
        Class.Commondata commondata = new Class.Commondata();

        public FrmReport()
        {
            InitializeComponent();
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            sqlcmd = "SELECT * FROM round ORDER BY id desc";
            dt = commondata.MyExecuteReader(sqlcmd);
            ddl1.DisplayMember = "CreateDTM";
            ddl1.ValueMember = "Id";
            ddl1.DataSource = dt;
        }
    }
}
