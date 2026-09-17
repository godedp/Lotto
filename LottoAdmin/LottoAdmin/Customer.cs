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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private Int64 _id;

        public Int64 id
        {
            get { return _id; }
            set
            {
                _id = value;
                if (_id == 0) { return; } 
                DataTable dt = new DataTable();
                sqlcmd = "SELECT Id , CustomerName , STATUS , Deposit , Credit , Balance , Pay , ReturnFree" +
                    " FROM customer where id  = " + _id ;
                dt = commondata.MyExecuteReader(sqlcmd);

                decimal withdraw = 0;
                txtName.Text = dt.Rows[0]["CustomerName"].ToString();
                txtCredit.Text = dt.Rows[0]["Credit"].ToString();
                txtPay.Text = dt.Rows[0]["Pay"].ToString();
                lblBalance.Text = Convert.ToDecimal(dt.Rows[0]["Balance"]).ToString("N0");
                txtFee.Text = dt.Rows[0]["ReturnFree"].ToString();
                if (Convert.ToDecimal(dt.Rows[0]["Credit"]) > 0)
                {
                    withdraw = (Convert.ToDecimal(dt.Rows[0]["Balance"]) - Convert.ToDecimal(dt.Rows[0]["Credit"]));
                    if (withdraw < 0) { withdraw = 0; }
                }
                else
                {
                    withdraw = Convert.ToDecimal(dt.Rows[0]["Balance"]);
                }
                lblwithdraw.Text = withdraw.ToString("N0");

            }
        }
        public string Tname
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }
        public string TPay
        {
            get { return txtPay.Text; }
            set { txtPay.Text = value; }
        }
        public string TFree
        {
            get { return txtFee.Text; }
            set { txtFee.Text = value; }    
        }
        public string TCredit
        {
            get { return txtCredit.Text; }
            set { txtCredit.Text = value; }
        }
        public string TDeposit
        {
            get { return txtDeposit.Text; }
            set { txtDeposit.Text = value; }    
        }
        public string TBalance
        {
            get { return lblBalance.Text; }
            set { lblBalance.Text = value; }
        }
        public string Twithdraw
        {
            get { return lblwithdraw.Text; }
            set { lblwithdraw.Text = value; }
        }



        Class.Commondata commondata = new Class.Commondata();
        String sqlcmd;

        private void Customer_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void DisplayData()
        {
            DataTable dt = new DataTable();
            sqlcmd = "SELECT Id , CustomerName , STATUS , Deposit , Credit , Balance , Pay , ReturnFree" +
                " FROM customer where id > 0 order by updateDTM desc ";
            dt = commondata.MyExecuteReader(sqlcmd);
            dgv.DataSource = dt;
        }

        private void ClearData()
        {
            txtName.Text = String.Empty;
            txtCredit.Text = String.Empty;
            txtPay.Text = String.Empty;
            lblBalance.Text = "0";
            txtFee.Text = String.Empty;
            lblwithdraw.Text = "0";
            txtDeposit.Text = String.Empty;
            id = 0;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            decimal withdraw = 0;
            txtName.Text = dgv.Rows[e.RowIndex].Cells["CustomerName"].Value.ToString();
            txtCredit.Text = dgv.Rows[e.RowIndex].Cells["Credit"].Value.ToString();
            txtPay.Text = dgv.Rows[e.RowIndex].Cells["Pay"].Value.ToString();
            lblBalance.Text = Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells["Balance"].Value).ToString("N0");
            txtFee.Text = dgv.Rows[e.RowIndex].Cells["ReturnFree"].Value.ToString();
            id = Convert.ToInt64(dgv.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            if(Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells["Credit"].Value) > 0 )
            {
                withdraw = (Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells["Balance"].Value) - Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells["Credit"].Value));
                if (withdraw < 0 ) {withdraw = 0;}
            }
            else
            {
                withdraw = Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells["Balance"].Value);
            }
            lblwithdraw.Text = withdraw.ToString("N0");
        }

        private void Deposit_Click(object sender, EventArgs e)
        {
            bool result;
            commondata.MyBeginTran();
            try
            {
                if (id == 0)
                {
                    ClearData();
                    DisplayData();
                    return ;
                }
                sqlcmd = "SELECT max(RoundId) as RoundId , MAX(SubRoundNo) AS SubRoundNo  FROM subround WHERE RoundId = (SELECT MAX(Id) FROM round)";
                DataTable dt = new DataTable();
                dt = commondata.MyExecuteReaderTran(sqlcmd);

                sqlcmd = "INSERT INTO  customerdeposit" +
                    " (RoundId, SubRoundNo, CustomerId, Deposit)  " +
                    " VALUES " +
                    " ("+ dt.Rows[0]["RoundId"] + "," + dt.Rows[0]["SubRoundNo"]  + "," + id + "," + TDeposit + ")";
                result = commondata.MyExecuteNonQueryTran(sqlcmd);
                if (result == false)
                {
                    MessageBox.Show("ติดต่อผู้ดูแลระบบ");
                    return;
                }


                decimal deposit = Convert.ToDecimal(txtDeposit.Text.Trim());
                sqlcmd = "update customer" +
                " set balance  = balance + " + deposit +
                " , deposit = deposit + " + deposit + 
                " where id = " + id;
                result = commondata.MyExecuteNonQueryTran(sqlcmd);
                if (result == true)
                {
                    commondata.MyCommitTran();
                    MessageBox.Show("ฝากเงินเรียบร้อย");
                    ClearData();
                    DisplayData();
                }
                else
                {
                    commondata.MyRobackTran();
                }    
            }
            catch (Exception ex)
            {
                commondata.MyRobackTran();
            }
        }

        private void withdraw_Click(object sender, EventArgs e)
        {
            if(Convert.ToDecimal(lblwithdraw.Text) > 0)
            {
                DialogResult dialogResult = MessageBox.Show("ยืนยันการถอน " + txtName.Text + " จำนวน " + lblwithdraw.Text, "ถอน", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
                if (dialogResult == DialogResult.Yes)
                {
                    bool result;
                    try
                    {
                        decimal withdraw = Convert.ToDecimal(lblwithdraw.Text.Trim());
                        sqlcmd = "update customer" +
                        " set balance  = balance - " + withdraw +
                        " where id = " + id;
                        result = commondata.MyExecuteNonQuery(sqlcmd);
                        if (result == true)
                        {
                            MessageBox.Show("ถอนเงินเรียบร้อย");
                            ClearData();
                            DisplayData();
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dtCredit = new DataTable();

            bool result;
            try
            {
                if (id == 0) { return; }
                if (Convert.ToDecimal(txtCredit.Text.Trim()) != 0)
                {
                    sqlcmd = "Select Credit From customer where id = " + id;
                    dtCredit = commondata.MyExecuteReader(sqlcmd);
                    decimal diff = Convert.ToDecimal(txtCredit.Text.Trim()) - Convert.ToDecimal(dtCredit.Rows[0][0]);



                    sqlcmd = "UPDATE customer " +
                    " set CustomerName = '" + txtName.Text.Trim().Replace("'", "''") + "'" +
                    " , Credit = Credit + " + diff + 
                    " , Balance = Balance + " + diff + 
                    " , Pay = " + txtPay.Text.Trim() +
                    " , returnfree = " + txtFee.Text.Trim() +
                    " where id = " + id;
                }
                else
                {
                    sqlcmd = "UPDATE customer " +
                    " set CustomerName = '" + txtName.Text.Trim().Replace("'","''") + "'" +
                    " , Pay = " + txtPay.Text.Trim() +
                    " , returnfree = " + txtFee.Text.Trim() +
                    " where id = " + id;
                }


                result = commondata.MyExecuteNonQuery(sqlcmd);
                if (result == true)
                {
                    MessageBox.Show("แก้ไขข้อมูลเรียบร้อย");
                    ClearData();
                    DisplayData();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("กรุณาป้อนข้อมูลเป็นตัวเลข");
            }
        }

        private void btnWithdrawAll_Click(object sender, EventArgs e)
        {
            try
            {
                sqlcmd = "UPDATE customer SET Deposit = 0 , Balance = Credit";
                if (commondata.MyExecuteNonQuery(sqlcmd) == true)
                {
                    MessageBox.Show("ล้างบัญชีเรียบร้อย");
                    ClearData();
                    DisplayData();
                }
                else
                {
                    MessageBox.Show("ติดต่อผู้ดูแลระบบ");
                }
            }
            catch
            {

            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt = new DataTable();
                sqlcmd = "SELECT Id , CustomerName , STATUS , Deposit , Credit , Balance , Pay , ReturnFree" +
                    " FROM customer where CustomerName  = '" + txtName.Text.Trim().Replace("'","''") + "'" ;
                dt = commondata.MyExecuteReader(sqlcmd);
                if (dt.Rows.Count == 0 )
                {
                    DialogResult dialogResult = MessageBox.Show("เพิ่มลูกค้าใหม่", "เพิ่มลูกค้า", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    if (dialogResult == DialogResult.Yes)
                    {
                        sqlcmd = "Insert into customer ( customerName , STATUS , pay ," +
                        " CreateUser , UpdateUser ) " +
                        " values " +
                        " ('" + txtName.Text.Trim().Replace("'","''") + "'" +
                        " , 1 " +
                        " , 0.95 " +
                        " ,'Auto'" +
                        " ,'Auto')";
                        
                        if (commondata.MyExecuteNonQuery(sqlcmd) == false)
                        {
                            MessageBox.Show("ติดต่อผู้ดูแลระบบ");
                            return ;
                        }
                        sqlcmd = "SELECT id , CustomerName , balance , pay " +
                            "FROM customer" +
                            " WHERE customerName = '" + txtName.Text.Trim().Replace ("'","''") + "'" +
                            " AND STATUS = 1";
                        dt = new DataTable();
                        dt = commondata.MyExecuteReader(sqlcmd);
                        if (dt.Rows.Count != 0)
                        {
                            id = Convert.ToInt64(dt.Rows[0]["id"].ToString());
                        }
                    }
                    return;
                }

                decimal withdraw = 0;
                _id = Convert.ToInt64(dt.Rows[0]["id"]);
                txtName.Text = dt.Rows[0]["CustomerName"].ToString();
                txtCredit.Text = dt.Rows[0]["Credit"].ToString();
                txtPay.Text = dt.Rows[0]["Pay"].ToString();
                lblBalance.Text = Convert.ToDecimal(dt.Rows[0]["Balance"]).ToString("N0");
                txtFee.Text = dt.Rows[0]["ReturnFree"].ToString();
                if (Convert.ToDecimal(dt.Rows[0]["Credit"]) > 0)
                {
                    withdraw = (Convert.ToDecimal(dt.Rows[0]["Balance"]) - Convert.ToDecimal(dt.Rows[0]["Credit"]));
                    if (withdraw < 0) { withdraw = 0; }
                }
                else
                {
                    withdraw = Convert.ToDecimal(dt.Rows[0]["Balance"]);
                }
                lblwithdraw.Text = withdraw.ToString("N0");
            }
        }

        private void txtDeposit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Deposit.Focus();
            }
        }
    }
}
