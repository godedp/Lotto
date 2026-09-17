using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LottoDisplay
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        LiveScreen1 liveScreen  = new LiveScreen1();

        DataTable dt = new DataTable(); 
        Class.Commondata commondata = new Class.Commondata();
        string sqlcmd;

        private void btnNew_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("ยืนยันเปิดช่วงใหม่ ", "เปิดช่วงใหม่", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                commondata.MyBeginTran();
                try
                {
                    sqlcmd = "INSERT INTO round (CreateUser) VALUES ('Auto')";
                    commondata.MyExecuteNonQueryTran(sqlcmd);
                    sqlcmd = "Select max(Id) from round";
                    dt = commondata.MyExecuteReaderTran(sqlcmd);
                    sqlcmd = "INSERT INTO subround (RoundId , SubRoundNo , CreateUser , UpdateUser) VALUES (" + dt.Rows[0][0] + ",1,'Auto','Auto')";
                    commondata.MyExecuteNonQueryTran(sqlcmd);
                    sqlcmd = "SELECT MAX(id) FROM subround";
                    dt.Clear();
                    dt = commondata.MyExecuteReaderTran(sqlcmd);

                    commondata.MyCommitTran();
                    liveScreen.subRoundId = Convert.ToInt32(dt.Rows[0][0].ToString());
                    liveScreen.Show();
                }
                catch (Exception ex)
                {
                    commondata.MyRobackTran();
                }

            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                sqlcmd = "SELECT MAX(id) FROM subround";
                dt.Clear();
                dt = commondata.MyExecuteReader(sqlcmd);



                liveScreen.subRoundId = Convert.ToInt32( dt.Rows[0][0].ToString());
                
                liveScreen.Show();
                this.Hide();

     


            }
            catch(Exception ex)
            {

            }
        }
    }
}
