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
    public partial class Bet : Form
    {
        public Bet()
        {
            InitializeComponent();
        }

        Int64 RoundId;
        Int64 SubRoundNo;
        Int64 CustId;
        Int64 TmpID = 0;
        decimal BetUp;
        decimal BetDown;
        decimal Pay;
        bool Result;
        decimal tmpBetUp = 0;
        decimal tmpBetDown = 0;
        decimal Diff = 0;

        DataTable dt = new DataTable();
        Class.Commondata commondata = new Class.Commondata();
        string sqlcmd;

        private void Bet_Load(object sender, EventArgs e)
        {
            IntialData();
            DisplayBet();
            timer1.Enabled = true;
        }

        private void IntialData()
        {
            sqlcmd = "SELECT * FROM textdisplay";
            dt = new DataTable();
            dt = commondata.MyExecuteReader(sqlcmd);
            txtMoving.Text = dt.Rows[0][0].ToString();

            sqlcmd = "SELECT RoundId , SubRoundNo , CardNo , AwardNo , BetUp , BetDown" + 
                " FROM subround WHERE id = (SELECT MAX(id) FROM subround)";
            dt = new DataTable();
            dt = commondata.MyExecuteReader(sqlcmd);
            RoundId = Convert.ToInt64(dt.Rows[0]["RoundId"]);
            SubRoundNo = Convert.ToInt64(dt.Rows[0]["SubRoundNo"]);
            lblSubRound.Text = SubRoundNo.ToString();
            if (dt.Rows[0]["CardNo"].ToString() != "")
            {
                lblCardNo.Text = dt.Rows[0]["CardNo"].ToString(); 
            }
            else
            {
                lblCardNo.Text = "";
            }
        }

        private void txtFB_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    decimal xx;
                    string tmpName = string.Empty;
                    string tmpValue = string.Empty;
                    string tmpxValue = string.Empty;
                    var x = txtFB.Text.Trim();


                    string[] result = txtFB.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

                    for (int i = 0; i < result.Length; i++)
                    {
                        if (result[i] != "")
                        {
                            if (tmpName == string.Empty)
                            {
                                tmpName = result[i];
                            }
                            else if (tmpValue == string.Empty)
                            {
                                tmpValue = result[i];
                            }

                        }
                    }
                    if (tmpValue.Contains("ฝาก"))
                    {
                        tmpxValue = tmpValue.Replace("ฝาก", "");
                    }
                    else if (tmpValue.Contains("ฝ"))
                    {
                        tmpxValue = tmpValue.Replace("ฝ", "");
                    }
                    //ฝ , ฝาก ,  = ฝาก
                    //บ , บน = บน
                    //ล , ล่าง = ล่าง
                    //ย , ยก = ยกเลิก
                    //+ = เพิ่ม
                    //- = ลด

                    if (SearchCustomer_New(tmpName , tmpxValue) == true)
                    {
                        
                        DataTable oldBet = new DataTable();
                        txtCustName.Text = tmpName;
                        oldBet = SearchBet();
                        if (tmpValue.Contains("บน"))
                        {
                            if (oldBet.Rows.Count > 0)
                            {
                                MessageBox.Show("มีเดิมพันแล้ว กรุณาส่ง +- แทน");
                                Cancel();
                                return;
                            }
                            tmpValue = tmpValue.Replace("บน", "");
                            xx = Convert.ToDecimal(tmpValue);
                            txtBetUp.Text = xx.ToString();
                        }
                        else if (tmpValue.Contains("บ"))
                        {
                            if (oldBet.Rows.Count > 0)
                            {
                                MessageBox.Show("มีเดิมพันแล้ว กรุณาส่ง +- แทน");
                                Cancel();
                                return;
                            }
                            tmpValue = tmpValue.Replace("บ", "");
                            xx = Convert.ToDecimal(tmpValue);
                            txtBetUp.Text = xx.ToString();
                        }
                        else if (tmpValue.Contains("ล่าง"))
                        {
                            if (oldBet.Rows.Count > 0)
                            {
                                MessageBox.Show("มีเดิมพันแล้ว กรุณาส่ง +- แทน");
                                Cancel();
                                return;
                            }
                            tmpValue = tmpValue.Replace("ล่าง", "");
                            xx = Convert.ToDecimal(tmpValue);
                            txtBetDown.Text = xx.ToString();
                        }
                        else if (tmpValue.Contains("ล"))
                        {
                            if (oldBet.Rows.Count > 0)
                            {
                                MessageBox.Show("มีเดิมพันแล้ว กรุณาส่ง +- แทน");
                                Cancel();
                                return;
                            }
                            tmpValue = tmpValue.Replace("ล", "");
                            xx = Convert.ToDecimal(tmpValue);
                            txtBetDown.Text = xx.ToString();
                        }
                        else if (tmpValue.Contains("+"))
                        {
                            oldBet = SearchBet();
                            if(oldBet.Rows.Count > 0)
                            {
                                tmpValue = tmpValue.Replace("+", "");
                                xx = Convert.ToDecimal(tmpValue);
                                if (Convert.ToDecimal(oldBet.Rows[0]["betup"].ToString()) > 0)
                                {
                                    txtBetUp.Text = xx.ToString();
                                }
                                else
                                {
                                    txtBetDown.Text = xx.ToString();
                                }
                            }
                            else
                            {
                                MessageBox.Show("ไม่มียอดเดิม");
                            }

                            
                        }
                        else if (tmpValue.Contains("-"))
                        {
                            oldBet = SearchBet();
                            if (oldBet.Rows.Count > 0)
                            {
                                tmpValue = tmpValue.Replace("-", "");
                                xx = Convert.ToDecimal(tmpValue);
                                if (Convert.ToDecimal(oldBet.Rows[0]["betup"].ToString()) > 0)
                                {
                                    if (xx <= Convert.ToDecimal(oldBet.Rows[0]["betup"].ToString()))
                                    {
                                        txtBetUp.Text = "-" + xx.ToString();
                                    }
                                    else
                                    {
                                        txtBetUp.Text = "-" + oldBet.Rows[0]["betup"].ToString();
                                    }
                                    
                                }
                                else if (Convert.ToDecimal(oldBet.Rows[0]["betDown"].ToString()) > 0)
                                {
                                    if (xx <= Convert.ToDecimal(oldBet.Rows[0]["betDown"].ToString()))
                                    {
                                        txtBetDown.Text = "-" + xx.ToString();
                                    }
                                    else
                                    {
                                        txtBetDown.Text = "-" + oldBet.Rows[0]["betDown"].ToString();
                                    }
                                        
                                }
                            }
                            else
                            {
                                MessageBox.Show("ไม่มียอดเดิม");
                            }


                        }
                        else if (tmpValue.Contains("ยก"))
                        {
                            oldBet = SearchBet();
                            if (oldBet.Rows.Count > 0)
                            {
                                tmpValue = tmpValue.Replace("ยก", "");
                                if (Convert.ToDecimal(oldBet.Rows[0]["betup"].ToString()) > 0)
                                {
                                    txtBetUp.Text = "-" + oldBet.Rows[0]["betup"].ToString();
                                }
                                else
                                {
                                    txtBetDown.Text = "-" + oldBet.Rows[0]["betDown"].ToString();
                                }
                            }
                            else
                            {
                                MessageBox.Show("ไม่มียอดเดิม");
                            }
                        }
                        else if (tmpValue.Contains("ย"))
                        {
                            oldBet = SearchBet();
                            if (oldBet.Rows.Count > 0)
                            {
                                tmpValue = tmpValue.Replace("ย", "");
                                if (Convert.ToDecimal(oldBet.Rows[0]["betup"].ToString()) > 0)
                                {
                                    txtBetUp.Text = "-" + oldBet.Rows[0]["betup"].ToString();
                                }
                                else
                                {
                                    txtBetDown.Text = "-" + oldBet.Rows[0]["betDown"].ToString();
                                }
                            }
                            else
                            {
                                MessageBox.Show("ไม่มียอดเดิม");
                            }
                        }
                        else if (tmpValue.Contains("ฝาก"))
                        {
                            tmpValue = tmpValue.Replace("ฝาก", "");
                            Customer customer = new Customer();
                            customer.id = Convert.ToInt64(dt.Rows[0]["ID"]);
                            customer.Tname = txtCustName.Text.Trim();
                            customer.TPay = dt.Rows[0]["pay"].ToString();
                            customer.TFree = "0.00";
                            customer.TCredit = "0.00";
                            customer.TDeposit = tmpValue;
                            customer.Show();
                        }
                        else if (tmpValue.Contains("ฝ"))
                        {
                            tmpValue = tmpValue.Replace("ฝ", "");
                            Customer customer = new Customer();
                            customer.id = Convert.ToInt64(dt.Rows[0]["ID"]);
                            customer.Tname = txtCustName.Text.Trim();
                            customer.TPay = dt.Rows[0]["pay"].ToString();
                            customer.TFree = "0.00";
                            customer.TCredit = "0.00";
                            customer.TDeposit = tmpValue;
                            customer.Show();
                        }
                    }

                    txtFB.Text = string.Empty;
                    btnBet.Focus();
                }
            }
            catch (Exception ex)
            {

            }


            //if (e.KeyCode == Keys.Enter)
            //{
            //    decimal xx;
            //    var x = txtFB.Text.Trim();
            //    string[] result = txtFB.Text.Split(new string[] {Environment.NewLine}, StringSplitOptions.None);
            //    txtCustName.Text = result[0].ToString();
            //    string values = result[1];
            //    SearchCustomer_New(txtCustName.Text.Trim());
            //    if (values.Contains("บ"))
            //    {

            //        values = values.Replace("บ", "");
            //        xx = Convert.ToDecimal(values);
            //        txtBetUp.Text = xx.ToString();
            //    }
            //    if (values.Contains("ล"))
            //    {

            //        values = values.Replace("ล", "");
            //        xx = Convert.ToDecimal(values);
            //        txtBetDown.Text = xx.ToString(); 
            //    }

            //}
        }

        private DataTable SearchBet()
        {
            DataTable dtsearch = new DataTable();
            sqlcmd = "SELECT betup , betDown " + 
                " FROM transaction" + 
                " WHERE RoundId =  " +  RoundId + 
                " AND SubRoundNo = " + SubRoundNo +
                " AND CustomerId = " + CustId ;
            dtsearch = commondata.MyExecuteReader(sqlcmd);
            return dtsearch;
        }

        private bool DeleteBet()
        {

            sqlcmd = "delete " +
                " FROM transaction" +
                " WHERE RoundId =  " + RoundId +
                " AND SubRoundNo = " + SubRoundNo +
                " AND CustomerId = " + CustId;
            return commondata.MyExecuteNonQuery(sqlcmd);
        }

        private void txtCustName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (SearchCustomer_New(txtCustName.Text.Trim(),"") == true)
                {
                    if(txtCustName.Text.Trim() != "")
                    {
                        txtBetUp.Focus();
                    }
                }

            }
        }

        private bool SearchCustomer_New(string custname , string Deposit )
        {
            bool result;
            CustId = 0;
            Pay = 0;
            sqlcmd = "SELECT id , CustomerName , balance , pay " +
                "FROM customer" +
                " WHERE customerName = '" +   custname.Replace("'","''") + "'" +
                " AND STATUS = 1";
            dt = new DataTable();
            dt = commondata.MyExecuteReader(sqlcmd);
            if (dt.Rows.Count > 0)
            {
                DisplaySearch(dt);
                return true;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("เพิ่มลูกค้าใหม่", "เพิ่มลูกค้า", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                if (dialogResult == DialogResult.Yes)
                {
                    sqlcmd = "Insert into customer ( customerName , STATUS , pay ," +
                    " CreateUser , UpdateUser ) " +
                    " values " +
                    " ('" + custname.Replace("'", "''") + "'" +
                    " , 1 " +
                    " , 0.95 " +
                    " ,'Auto'" +
                    " ,'Auto')";
                    result = commondata.MyExecuteNonQuery(sqlcmd);
                    if (result == false)
                    {
                        MessageBox.Show("ติดต่อผู้ดูแลระบบ");
                        return false;
                    }
                    sqlcmd = "SELECT id , CustomerName , balance , pay " +
                        "FROM customer" +
                        " WHERE customerName = '" + custname.Replace("'", "''") + "'" +
                        " AND STATUS = 1";
                    dt = new DataTable();
                    dt = commondata.MyExecuteReader(sqlcmd);
                    if (dt.Rows.Count > 0)
                    {
                        Customer customer = new Customer();
                        customer.id = Convert.ToInt64(dt.Rows[0]["ID"]);
                        customer.Tname = custname;
                        customer.TPay = dt.Rows[0]["pay"].ToString();
                        customer.TFree = "0.00";
                        customer.TCredit = "0.00";
                        customer.TDeposit = Deposit;
                        customer.Show();
                        return false;
                    }
                }
            }
            return false;
        }

        private void DisplaySearch(DataTable dataTable)
        {
            txtCustName.Text = dataTable.Rows[0]["CustomerName"].ToString();
            lblBalance.Text = Convert.ToDecimal(dataTable.Rows[0]["balance"]).ToString("N0");
            CustId = Convert.ToInt64(dataTable.Rows[0]["id"]);
            Pay = Convert.ToDecimal(dataTable.Rows[0]["pay"]);
        }

        private bool SearchCustomer(string custname)
        {
            bool result;
            CustId = 0;
            Pay = 0;
            sqlcmd = "SELECT id , CustomerName , balance , pay " +
                "FROM customer" +
                " WHERE customerName = '" + custname.Replace("'", "''") + "'" + 
                " AND STATUS = 1";
            dt = new DataTable();
            dt = commondata.MyExecuteReader(sqlcmd);
            if (dt.Rows.Count > 0)
            {
                txtCustName.Text = dt.Rows[0]["CustomerName"].ToString();
                lblBalance.Text = Convert.ToDecimal(dt.Rows[0]["balance"]).ToString("N0");
                CustId = Convert.ToInt64(dt.Rows[0]["id"]);
                Pay = Convert.ToDecimal(dt.Rows[0]["pay"]);
                return true;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("เพิ่มลูกค้าใหม่" , "เพิ่มลูกค้า", MessageBoxButtons.YesNo,MessageBoxIcon.Hand,MessageBoxDefaultButton.Button1);
                if (dialogResult == DialogResult.Yes)
                {  
                    sqlcmd = "Insert into customer ( customerName , STATUS , pay ," +
                    " CreateUser , UpdateUser ) " +
                    " values " +
                    " ('" + txtCustName.Text.Trim().Replace("'","''") + "'" +
                    " , 1 " +
                    " , 0.95 " +
                    " ,'Auto'" +
                    " ,'Auto')";
                    result = commondata.MyExecuteNonQuery(sqlcmd);
                    if (result == false)
                    {
                        MessageBox.Show("ติดต่อผู้ดูแลระบบ");
                        return false;
                    }
                    sqlcmd = "SELECT id , CustomerName , balance , pay " +
                        "FROM customer" +
                        " WHERE customerName = '" + custname.Replace("'", "''") + "'" +
                        " AND STATUS = 1";
                    dt = new DataTable();
                    dt = commondata.MyExecuteReader(sqlcmd);
                    if (dt.Rows.Count > 0)
                    {
                        Customer customer = new Customer();
                        customer.id = Convert.ToInt64(dt.Rows[0]["ID"]);
                        customer.Tname = custname;
                        customer.TPay = dt.Rows[0]["pay"].ToString();
                        customer.TFree = "0.00";
                        customer.TCredit = "0.00";
                        customer.Show();
                        return false;
                    }
                }
            }
            return false;
        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            if (CustId == 0)
            {
                Cancel();
                return;
            }
            if (txtBetUp.Text.Trim() != "" && txtBetDown.Text.Trim() != "")
            { Cancel(); }
            InsertBet();
            DisplayBet();
            txtCustName.Focus();
        }

        private void InsertBet()
        {
            if (txtCustName.Text.Trim() == "")
            {
                MessageBox.Show("กรุณาใส่ข้อมูลลูกค้า");
                return;
            }
            if (txtBetUp.Text.Trim() == "" && txtBetDown.Text.Trim() == "" )
            {
                MessageBox.Show("กรุณาใส่เดิมพัน");
                return;
            }

            BetUp = 0;
            BetDown = 0;
            if (txtBetUp.Text.ToString().Trim() != "")
            {
                BetUp = Convert.ToDecimal(txtBetUp.Text.ToString().Trim());
            }
            else if (txtBetDown.Text.ToString().Trim() != "")
            {
                BetDown = Convert.ToDecimal(txtBetDown.Text.ToString().Trim());
            }

            if ((BetUp + BetDown) == 0)
            {
                MessageBox.Show("กรุณาใส่เดิมพัน");
                return;
            }
 
            if ((BetUp + BetDown) > Convert.ToDecimal(lblBalance.Text))
            {
                MessageBox.Show("วงเงินไม่พอ");
                return;
            }

            commondata.MyBeginTran();
            try
            {
                decimal ReturnCredit = 0;

                DataTable dd = new DataTable();
                sqlcmd = "select * from transaction where RoundId = " + RoundId +
                    " and SubRoundNo = " + SubRoundNo +
                    " and CustomerId = " + CustId;
                dd = commondata.MyExecuteReaderTran(sqlcmd);
                if (dd.Rows.Count == 0 )
                {
                    if (BetUp !=0)
                    {
                        //Insert Data
                        sqlcmd = "Insert into transaction " +
                            " ( RoundId , SubRoundNo , CustomerId ," +
                            " CustomerName , BetUp , BetDown , Pay ," +
                            " CreateUser , UpdateUser )" +
                            " values " +
                            " (" + RoundId + "," + SubRoundNo + "," + CustId + "," +
                            " '" + txtCustName.Text.Trim().Replace("'", "''") + "'," + BetUp + ",0," + Pay + "," +
                            " 'Auto','Auto')";
                    }
                    else
                    {
                        //Insert Data
                        sqlcmd = "Insert into transaction " +
                            " ( RoundId , SubRoundNo , CustomerId ," +
                            " CustomerName , BetUp , BetDown , Pay ," +
                            " CreateUser , UpdateUser )" +
                            " values " +
                            " (" + RoundId + "," + SubRoundNo + "," + CustId + "," +
                            " '" + txtCustName.Text.Trim().Replace("'", "''") + "',0," + BetDown + "," + Pay + "," +
                            " 'Auto','Auto')";
                    }


                    Result = commondata.MyExecuteNonQueryTran(sqlcmd);
                    if (Result == false)
                    {
                        commondata.MyRobackTran();
                        return;
                    }
                }
                else
                {
                    //เพิ่ม
                    if (BetUp != 0)
                    {
                        sqlcmd = "UPDATE transaction " + 
                            " SET BetUp = (BetUp + " + BetUp + " ) , BetDown = 0 " + 
                            " WHERE ID = " + dd.Rows[0]["id"];
                    }
                    else if (BetDown !=0)
                    {
                        sqlcmd = "UPDATE transaction " +
                            " SET BetDown = (BetDown + " + BetDown + " ) , BetUp = 0 " +
                            " WHERE ID = " + dd.Rows[0]["id"];
                    }
                    Result = commondata.MyExecuteNonQueryTran(sqlcmd);
                    if (Result == false)
                    {
                        commondata.MyRobackTran();
                        return;
                    }
                }



                //Update Credit
                sqlcmd = "UPDATE customer SET Balance = Balance - " + ( BetUp + BetDown ) + " WHERE id = " + CustId ;
                Result = commondata.MyExecuteNonQueryTran(sqlcmd);
                if (Result == false)
                {
                    commondata.MyRobackTran();
                    return;
                }
                //Update SubRound
                sqlcmd = "UPDATE SubRound set BetUp =  BetUp + " + BetUp + ", BetDown = BetDown + " + BetDown +
                    " where RoundId = " + RoundId +
                    " and SubRoundNo = " + SubRoundNo;
                Result = commondata.MyExecuteNonQueryTran(sqlcmd);
                if (Result == false)
                {
                    commondata.MyRobackTran();
                    return;
                }

                sqlcmd = "DELETE  FROM transaction " + 
                    " WHERE RoundId = " + RoundId + 
                    " AND SubRoundNo = " + SubRoundNo + 
                    " AND betup = 0 AND betdown = 0";
                Result = commondata.MyExecuteNonQueryTran(sqlcmd);
                commondata.MyCommitTran();
            }
            catch (Exception ex)
            {
                commondata.MyRobackTran();
            }
            txtCustName.Text = "";
            txtBetUp.Text = "";
            txtBetDown.Text = "";
            lblBalance.Text = "0";

        }

        private void DisplayBet()
        {

            sqlcmd = "select BetUp , BetDown" +
                " from subround " +
                " WHERE RoundId = " + RoundId +
                " AND SubRoundNo = " + SubRoundNo;
            DataTable dataTable = new DataTable();
            dataTable = commondata.MyExecuteReader(sqlcmd);
            if (dataTable.Rows.Count != 0)
            {
                tmpBetUp = Convert.ToDecimal(dataTable.Rows[0]["BetUp"]);
                tmpBetDown = Convert.ToDecimal(dataTable.Rows[0]["BetDown"]);
            }
            Diff = 0;
            if (tmpBetUp > tmpBetDown)
            {
                Diff = tmpBetUp - tmpBetDown;

            }
            else
            {
                Diff = tmpBetDown - tmpBetUp;
            }

            lblDiff.Text = Diff.ToString("N0");
            lblBetUp.Text = tmpBetUp.ToString("N0");
            lblBetDown.Text = tmpBetDown.ToString("N0");
            txtDiff.Text = Diff.ToString("N");



            sqlcmd = "SELECT id ,  CustomerName , BetUp , BetDown " +
                " FROM transaction " +
                " WHERE RoundId = " + RoundId +
                " AND SubRoundNo = " + SubRoundNo +
                " ORDER BY Id ";

            dataTable = new DataTable();
            dataTable = commondata.MyExecuteReader(sqlcmd);
            flowLayoutPanelUp.Controls.Clear();
            flowLayoutPanelDown.Controls.Clear();


            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                UserControlBet userControlBet = new UserControlBet();
                userControlBet.TName = dataTable.Rows[i]["CustomerName"].ToString();
                userControlBet.Name = dataTable.Rows[i]["Id"].ToString();
                if (dataTable.Rows[i]["BetUp"].ToString() != "0.00")
                {
                    userControlBet.TAmount = Convert.ToDecimal(dataTable.Rows[i]["BetUp"]).ToString("N0");
                    flowLayoutPanelUp.Controls.Add(userControlBet);
                }
                if (dataTable.Rows[i]["BetDown"].ToString() != "0.00")
                {
                    userControlBet.TAmount = Convert.ToDecimal(dataTable.Rows[i]["BetDown"]).ToString("N0");
                    flowLayoutPanelDown.Controls.Add(userControlBet);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();


        }

        private void Cancel()
        {
            txtCustName.Text = "";
            txtBetUp.Text = "";
            txtBetDown.Text = "";
            lblBalance.Text = "0";
            txtFB.Text = string.Empty;
            CustId = 0;
        }

        private void DiffBet_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ยืนยันปิดยอดเพิ่มจำนวน " + Diff.ToString("N0"), "ปิดยอด", MessageBoxButtons.YesNo); ; ;
            if(dialogResult == DialogResult.Yes)
            {
                decimal AutoUp = 0;
                decimal AutoDown = 0;
                decimal AutoBet = 0;
                try
                {
                    DataTable BetDt = new DataTable();
                    commondata.MyBeginTran();
                    //Clear เจ้ามือรับ
                    sqlcmd = "DELETE  FROM transaction " +
                        " WHERE RoundId = " + RoundId + 
                        " AND SubRoundNo = " + SubRoundNo + 
                        " AND CustomerId = 0 ";
                    commondata.MyExecuteNonQueryTran(sqlcmd);


                    //Select Bet
                    sqlcmd = "SELECT SUM(betUp) AS betUp , SUM(betDown) AS betDown " +
                        " FROM transaction " +
                        " WHERE RoundId = " + RoundId +
                        " AND SubRoundNo = " + SubRoundNo;
                    BetDt = commondata.MyExecuteReaderTran(sqlcmd);
                    tmpBetUp = Convert.ToDecimal( BetDt.Rows[0]["betUp"]);
                    tmpBetDown = Convert.ToDecimal(BetDt.Rows[0]["betDown"]);

                    if (tmpBetUp > tmpBetDown)
                    {
                        AutoDown = tmpBetUp - tmpBetDown;
                        AutoBet = tmpBetUp;
                    }
                    else
                    {
                        AutoUp = tmpBetDown - tmpBetUp;
                        AutoBet = tmpBetDown;
                    }

                    //Insert Data
                    sqlcmd = "Insert into transaction " +
                        " ( RoundId , SubRoundNo , CustomerId ," +
                        " CustomerName , BetUp , BetDown , Pay ," +
                        " CreateUser , UpdateUser )" +
                        " values " +
                        " (" + RoundId + "," + SubRoundNo + ",0," +
                        " 'โชคมหาศาล'," + AutoUp + "," + AutoDown + ",1," +
                        " 'Auto','Auto')";
                    Result = commondata.MyExecuteNonQueryTran(sqlcmd);
                    if (Result == false)
                    {
                        commondata.MyRobackTran();
                        return;
                    }
                    //Update Credit
                    //sqlcmd = "UPDATE customer SET Balance = Balance - " + (BetUp + BetDown) + " WHERE id = " + CustId;
                    //Result = commondata.MyExecuteNonQueryTran(sqlcmd);
                    //if (Result == false)
                    //{
                    //    commondata.MyRobackTran();
                    //    return;
                    //}
                    //Update SubRound
                    sqlcmd = "UPDATE SubRound set BetUp =  " + AutoBet + ", BetDown = " + AutoBet +
                        " where RoundId = " + RoundId +
                        " and SubRoundNo = " + SubRoundNo;
                    Result = commondata.MyExecuteNonQueryTran(sqlcmd);
                    if (Result == false)
                    {
                        commondata.MyRobackTran();
                        return;
                    }

                    commondata.MyCommitTran();
                }
                catch (Exception ex)
                {
                    commondata.MyRobackTran();
                }
                DisplayBet();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DataTable TdataTable = new DataTable();  
            sqlcmd = "SELECT  RoundId , SubRoundNo , CardNo , AwardNo , BetUp , BetDown" +
                " FROM subround WHERE id = (SELECT MAX(id) FROM subround)";

            TdataTable = commondata.MyExecuteReader(sqlcmd);
            if (RoundId != Convert.ToInt64(TdataTable.Rows[0]["RoundId"])) 
            {
                IntialData();
                DisplayBet();
            }
            else if (SubRoundNo != Convert.ToInt64(TdataTable.Rows[0]["SubRoundNo"]))
            {
                IntialData();
                DisplayBet();
            }
            else if (lblCardNo.Text != TdataTable.Rows[0]["CardNo"].ToString())
            {
                IntialData();
                DisplayBet();
            }
        }

        private void txtBetUp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBetUp.Text.Trim() == "")
                {
                    txtBetDown.Focus();
                }
                else
                {
                    btnBet.Focus();
                }
            }
        }

        private void txtBetDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBetDown.Text.Trim() != "")
                {
                    btnBet.Focus();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Customer customer = new Customer();
            customer.id = CustId;
            //customer.Tname = txtCustName.Text.Trim();
            //customer.TPay = Pay.ToString(); ;
            //customer.TFree = "0.00";
            //customer.TCredit = "0.00";
   
            customer.Show();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {


            DateTime date = DateTime.Now;
            DataSet ds;
            DataTable datacustomer = new DataTable();
            DataTable dataHeader;
            DataTable dataDetail;
            DataTable dt = new DataTable();

            DataTable DataDisplay = new DataTable();
            sqlcmd = "SELECT convert(s1.SubRoundNo,CHAR) as 'รอบที่  ' , t2.deposit as 'ฝาก  ' ," +
                " S1.CardNo as 'เลขที่บัตร  ' , S1.AwardNo as 'เลขที่ออก  ' , t1.BetUp as 'บน  ' , t1.BetDown as 'ล่าง  '  ," +
                " t1.Receive as 'ได้-เสีย  '  ,  t1.ReturnFee AS 'คืนส่วนลด  ' ," + 
                " convert(s1.SubRoundNo,CHAR) as 'รอบที่ ' , t2.deposit as 'ฝาก ' ," +
                " S1.CardNo as 'เลขที่บัตร ' , S1.AwardNo as 'เลขที่ออก ' , t1.BetUp as 'บน ' , t1.BetDown as 'ล่าง '  ," +
                " t1.Receive as 'ได้-เสีย '  ,  t1.ReturnFee as 'คืนส่วนลด '," +
                " convert(s1.SubRoundNo,CHAR) as 'รอบที่' , t2.deposit as 'ฝาก' ," +
                " S1.CardNo as 'เลขที่บัตร' , S1.AwardNo as 'เลขที่ออก' , t1.BetUp as 'บน' , t1.BetDown as 'ล่าง'  ," +
                " t1.Receive as 'ได้-เสีย'  ,  t1.ReturnFee as 'คืนส่วนลด'  " +
                " FROM subround s1  LEFT OUTER JOIN(SELECT RoundId, subroundNo, betUp, betdown, " +
                " case receive when 0 then ((betup + betdown) * -1) ELSE receive END  AS receive, " +
                " bonus, returnfee  FROM transaction  WHERE RoundId = 30 AND CustomerId = 0) t1  " +
                " ON s1.RoundId = t1.RoundId AND s1.SubRoundNo = t1.SubRoundNo " +
                " LEFT OUTER JOIN(SELECT RoundId , SubRoundNo , CustomerId , SUM(Deposit) AS Deposit " +
                " FROM customerdeposit   WHERE RoundId = 0 AND CustomerId = 0 GROUP BY RoundId ," +
                " SubRoundNo , CustomerId) t2  ON s1.RoundId = t2.RoundId AND " +
                " s1.SubRoundNo = t2.SubRoundNo  WHERE s1.RoundId = 0 ORDER BY s1.SubRoundNo";
            DataDisplay = commondata.MyExecuteReader(sqlcmd);


            //ExcelFiles
            string filename = string.Empty;
            Excel.ExcelFile excelFile = new Excel.ExcelFile();
            string ExcelData = string.Empty;



            sqlcmd = "SELECT RoundId , CustomerId " +
                " FROM transaction " +
                " WHERE RoundId = (SELECT MAX(id) FROM round) " +
                " GROUP BY CustomerId ";
            datacustomer = commondata.MyExecuteReader(sqlcmd);
            for (int i = 0; i < datacustomer.Rows.Count; i++)
            {
                ds = new DataSet();
                dataHeader = new DataTable();
                dataDetail = new DataTable();
                //Customer Detail
                sqlcmd = "SELECT customerName, deposit" + 
                    " FROM Customer " + 
                    " WHERE id = " + datacustomer.Rows[i]["CustomerId"].ToString();
                dataHeader = commondata.MyExecuteReader(sqlcmd);

                //DataDetail
                sqlcmd = "SELECT convert(s1.SubRoundNo,CHAR) as 'รอบที่' , t2.deposit as 'ฝาก' ,  S1.CardNo as 'เลขที่บัตร' , S1.AwardNo as 'เลขที่ออก' ," + 
                    " t1.BetUp as 'บน' , t1.BetDown as 'ล่าง'  , t1.Receive as 'ได้-เสีย'  ,  t1.ReturnFee as 'คืนส่วนลด' " + 
                    " FROM subround s1 " +
                    " LEFT OUTER JOIN(SELECT RoundId, subroundNo, betUp, betdown, " + 
                    " case receive when 0 then ((betup + betdown) * -1) ELSE receive END  AS receive," + 
                    " bonus, returnfee " + 
                    " FROM transaction " + 
                    " WHERE RoundId = " + datacustomer.Rows[i]["RoundId"].ToString() + 
                    " AND CustomerId = " + datacustomer.Rows[i]["CustomerId"].ToString() + ") t1 " + 
                    " ON s1.RoundId = t1.RoundId AND s1.SubRoundNo = t1.SubRoundNo " +
                    " LEFT OUTER JOIN(SELECT RoundId , SubRoundNo , CustomerId , SUM(Deposit) AS Deposit " + 
                    " FROM customerdeposit  " + 
                    " WHERE RoundId = " + datacustomer.Rows[i]["RoundId"].ToString() +
                    " AND CustomerId = " + datacustomer.Rows[i]["CustomerId"].ToString() +
                    " GROUP BY RoundId , SubRoundNo , CustomerId) t2 " + 
                    " ON s1.RoundId = t2.RoundId AND s1.SubRoundNo = t2.SubRoundNo " +
                    " WHERE s1.RoundId = " + datacustomer.Rows[i]["RoundId"].ToString() +
                    " ORDER BY s1.SubRoundNo";

                dataDetail = commondata.MyExecuteReader(sqlcmd);

                DataTable tmpTable = new DataTable();
                tmpTable = DataDisplay.Clone();

                DataRow dataRow;
                decimal xDeposit = 0;
                decimal xUp = 0;
                decimal xDown = 0;
                decimal xPL = 0;
                decimal xBonus = 0;
                decimal xReturn = 0;
                int y = 30;
                //if (y < 30) { y = 30; };

                for (int x=0;x < dataDetail.Rows.Count; x++ )
                {
                    dataRow = tmpTable.NewRow();
                    dataRow[0] = dataDetail.Rows[x]["รอบที่"];
                    dataRow[1] = dataDetail.Rows[x]["ฝาก"];
                    if (dataDetail.Rows[x]["ฝาก"].ToString() != "")
                    {
                        xDeposit = xDeposit + Convert.ToDecimal(dataDetail.Rows[x]["ฝาก"]);
                    }
                    dataRow[2] = dataDetail.Rows[x]["เลขที่บัตร"];
                    dataRow[3] = dataDetail.Rows[x]["เลขที่ออก"];
                    dataRow[4] = dataDetail.Rows[x]["บน"];
                    if (dataDetail.Rows[x]["บน"].ToString() != "")
                    {
                        xUp = xUp + Convert.ToDecimal(dataDetail.Rows[x]["บน"]);
                    }
                    dataRow[5] = dataDetail.Rows[x]["ล่าง"];
                    if (dataDetail.Rows[x]["ล่าง"].ToString() != "")
                    {
                        xDown = xDown + Convert.ToDecimal(dataDetail.Rows[x]["ล่าง"]);
                    }
                    dataRow[6] = dataDetail.Rows[x]["ได้-เสีย"];
                    if (dataDetail.Rows[x]["ได้-เสีย"].ToString() != "")
                    {
                        xPL = xPL + Convert.ToDecimal(dataDetail.Rows[x]["ได้-เสีย"]);
                    }
                    dataRow[7] = dataDetail.Rows[x]["คืนส่วนลด"];
                    if (dataDetail.Rows[x]["คืนส่วนลด"].ToString() != "")
                    {
                        xReturn = xReturn + Convert.ToDecimal(dataDetail.Rows[x]["คืนส่วนลด"]);
                    }
                    //tmpTable.Rows.Add(dataRow);

                    //Set 2
                    if (x + y < dataDetail.Rows.Count && x+y < 60)
                    {
                        dataRow[8] = dataDetail.Rows[x+y]["รอบที่"];
                        dataRow[9] = dataDetail.Rows[x + y]["ฝาก"];
                        if (dataDetail.Rows[x + y]["ฝาก"].ToString() != "")
                        {
                            xDeposit = xDeposit + Convert.ToDecimal(dataDetail.Rows[x + y]["ฝาก"]);
                        }
                        dataRow[10] = dataDetail.Rows[x + y]["เลขที่บัตร"];
                        dataRow[11] = dataDetail.Rows[x + y]["เลขที่ออก"];
                        dataRow[12] = dataDetail.Rows[x + y]["บน"];
                        if (dataDetail.Rows[x + y]["บน"].ToString() != "")
                        {
                            xUp = xUp + Convert.ToDecimal(dataDetail.Rows[x + y]["บน"]);
                        }
                        dataRow[13] = dataDetail.Rows[x + y]["ล่าง"];
                        if (dataDetail.Rows[x + y]["ล่าง"].ToString() != "")
                        {
                            xDown = xDown + Convert.ToDecimal(dataDetail.Rows[x + y]["ล่าง"]);
                        }
                        dataRow[14] = dataDetail.Rows[x + y]["ได้-เสีย"];
                        if (dataDetail.Rows[x + y]["ได้-เสีย"].ToString() != "")
                        {
                            xPL = xPL + Convert.ToDecimal(dataDetail.Rows[x + y]["ได้-เสีย"]);
                        }
                        dataRow[15] = dataDetail.Rows[x + y]["คืนส่วนลด"];
                        if (dataDetail.Rows[x + y]["คืนส่วนลด"].ToString() != "")
                        {
                            xReturn = xReturn + Convert.ToDecimal(dataDetail.Rows[x + y]["คืนส่วนลด"]);
                        }
                    }

                    //Set 3
                    if (x + y + y < dataDetail.Rows.Count)
                    {
                        dataRow[16] = dataDetail.Rows[x + y + y]["รอบที่"];
                        dataRow[17] = dataDetail.Rows[x + y + y]["ฝาก"];
                        if (dataDetail.Rows[x + y + y]["ฝาก"].ToString() != "")
                        {
                            xDeposit = xDeposit + Convert.ToDecimal(dataDetail.Rows[x + y + y]["ฝาก"]);
                        }
                        dataRow[18] = dataDetail.Rows[x + y + y]["เลขที่บัตร"];
                        dataRow[19] = dataDetail.Rows[x + y + y]["เลขที่ออก"];
                        dataRow[20] = dataDetail.Rows[x + y + y]["บน"];
                        if (dataDetail.Rows[x + y + y]["บน"].ToString() != "")
                        {
                            xUp = xUp + Convert.ToDecimal(dataDetail.Rows[x + y + y]["บน"]);
                        }
                        dataRow[21] = dataDetail.Rows[x + y + y]["ล่าง"];
                        if (dataDetail.Rows[x + y + y]["ล่าง"].ToString() != "")
                        {
                            xDown = xDown + Convert.ToDecimal(dataDetail.Rows[x + y + y]["ล่าง"]);
                        }
                        dataRow[22] = dataDetail.Rows[x + y + y]["ได้-เสีย"];
                        if (dataDetail.Rows[x + y + y]["ได้-เสีย"].ToString() != "")
                        {
                            xPL = xPL + Convert.ToDecimal(dataDetail.Rows[x + y + y]["ได้-เสีย"]);
                        }
                        dataRow[23] = dataDetail.Rows[x + y + y]["คืนส่วนลด"];
                        if (dataDetail.Rows[x + y + y]["คืนส่วนลด"].ToString() != "")
                        {
                            xReturn = xReturn + Convert.ToDecimal(dataDetail.Rows[x + y + y]["คืนส่วนลด"]);
                        }
                    }

                    tmpTable.Rows.Add(dataRow);
                    if (x == y-1) { break; }
                }
                dataRow = tmpTable.NewRow();
                dataRow[0] = " ";
                tmpTable.Rows.Add(dataRow);


                dataRow = tmpTable.NewRow();
                dataRow[16] = "รวม";
                dataRow[17] = xDeposit;
                dataRow[20] = xUp;
                dataRow[21] = xDown;
                //dataRow["โบนัส"] = xBonus;
                tmpTable.Rows.Add(dataRow);


                dataRow = tmpTable.NewRow();
                dataRow[16] = "";
                dataRow[22] = xPL;
                dataRow[23] = xReturn;
                tmpTable.Rows.Add(dataRow);

                dataRow = tmpTable.NewRow();
                dataRow[16] = "ยอดสุทธิ์";
                dataRow[23] = xDeposit + xPL + xReturn;
                tmpTable.Rows.Add(dataRow);

                ds.Tables.Add(tmpTable);
                ds.Tables[0].TableName =  dataHeader.Rows[0]["customerName"].ToString();

                //ExcelFiles
                filename = dataHeader.Rows[0]["customerName"].ToString() +   DateTime.Now.ToString("yyyyddMM_HH") + ".xlsx";
                excelFile = new Excel.ExcelFile();
                ExcelData = string.Empty;
                ExcelData = excelFile.Files(ds, filename);

                if (datacustomer.Rows[i]["CustomerId"].ToString() == "174")
                {
                    var xxxxxxx = "xx";
                }
                decimal tmp1 =  xPL + xReturn;
                //Update Customer Balance
                sqlcmd = "Update Customer set up = " + xUp + 
                    " , down = " + xDown + 
                    " , pl = " + xPL +  
                    " , bonus = " + xBonus + 
                    " , Free = " + xReturn + 
                    " , Balance = Deposit + Credit + " + tmp1 +
                    " where id =  " + datacustomer.Rows[i]["CustomerId"].ToString();

                commondata.MyExecuteNonQuery(sqlcmd);
                


            }

            //สรุปยอดรวมรายคน

            sqlcmd = "SELECT c1.CustomerName AS ลูกค้า , d1.Deposit as ฝาก , c1.Credit AS เครดิต ," + 
                " t1.BetUp AS บน , t1.betdown AS ล่าง , t1.Receive AS ได้เสีย , t1.comm AS ค่าน้ำ ," + 
                " T1.ReturnFee AS คืนค่าน้ำ , " +
                " (if (d1.deposit is NULL ,0,d1.deposit)  + t1.receive + T1.ReturnFee) AS 'จ่ายคืน / ฝากเพิ่ม'  " +
                " FROM customer c1 LEFT OUTER join " + 
                " (SELECT CustomerId, sum(Deposit) AS Deposit " + 
                " FROM customerdeposit WHERE RoundID = (SELECT MAX(id) FROM round) " + 
                " GROUP BY CustomerId) AS d1 ON c1.Id = d1.customerId   " + 
                " LEFT OUTER JOIN(SELECT customerId, SUM(betUp) AS BetUp, sum(betdown) AS BetDown," + 
                " sum(receive) AS Receive, SUM(Comm) AS Comm, sum(bonus) AS Bonus, " + 
                " sum(ReturnFee) AS ReturnFee FROM(SELECT customerId, betUp, betdown, " + 
                " Case receive when 0 then((betup + betdown) * -1) ELSE receive END  AS receive, " + 
                " case receive when 0 then 0 ELSE(returnBet - receive)  END  AS Comm, " + 
                " returnBet, bonus, returnfee AS ReturnFee  FROM transaction " + 
                " WHERE RoundId = (SELECT MAX(id) FROM round)) aa GROUP BY customerId  ) AS t1 " +
                " ON c1.Id = t1.customerId  WHERE T1.ReturnFee IS NOT null and c1.Id <> 0 " + 
                " ORDER BY c1.CustomerName";
            // c1.Id <> 0 " +


            //sqlcmd = "SELECT customername as 'ชื่อลูกค้า' , deposit as 'ฝาก' , credit as 'เครดิต' , balance AS 'คงเหลือ' ," +
            //    " case when balance -credit < 0 then 0 ELSE balance -credit END AS 'ถอนได้' ," +
            //    " case when balance -credit < 0 then credit -balance  ELSE 0 END AS 'ฝากเพิ่ม'" +
            //    " FROM customer  WHERE id in (SELECT CustomerId FROM transaction WHERE RoundId = (SELECT MAX(id) FROM round)  AND CustomerId<>0 GROUP BY CustomerId )" +
            //    " AND (deposit <> 0  OR credit <> 0 OR balance )";

            dt = commondata.MyExecuteReader(sqlcmd);
            ds = new DataSet();
            ds.Tables.Add(dt);
            ds.Tables[0].TableName = "สรุปยอดรวมรายคน";

            sqlcmd = "SELECT CustomerName AS 'ชื่อลูกค้า' , if (Deposit IS NULL , 0 , Deposit) AS 'ฝาก' ," +
                " if (amount > 0 , amount , 0 ) AS 'ถอนได้' , if (amount < 0 , amount * -1 , 0 ) AS 'ฝากเพิ่ม' ," +
                " ReturnFee AS 'คืน %' " +
                " FROM ( SELECT c1.CustomerName, d1.Deposit, c1.Credit, t1.BetUp, t1.betdown, " +
                " t1.Receive, t1.comm, T1.ReturnFee, " +
                " (if (d1.deposit is NULL ,0,d1.deposit)  +t1.receive + T1.ReturnFee) AS amount " +
                " FROM customer c1 LEFT OUTER join(SELECT CustomerId, sum(Deposit) AS Deposit " +
                " FROM customerdeposit WHERE RoundID = (SELECT MAX(id) FROM round) " +
                " GROUP BY CustomerId) AS d1 ON c1.Id = d1.customerId  " +
                " LEFT OUTER JOIN(SELECT customerId, SUM(betUp) AS BetUp, sum(betdown) AS BetDown, " +
                " sum(receive) AS Receive, SUM(Comm) AS Comm, sum(bonus) AS Bonus, " +
                " sum(ReturnFee) AS ReturnFee FROM(SELECT customerId, betUp, betdown, " +
                " Case receive when 0 then((betup + betdown) * -1) ELSE receive END  AS receive, " +
                " case receive when 0 then 0 ELSE(returnBet - receive)  END  AS Comm, " +
                " returnBet, bonus, returnfee AS ReturnFee " +
                " FROM transaction  " +
                " WHERE RoundId = (SELECT MAX(id) FROM round)) aa GROUP BY customerId  ) AS t1 " +
                " ON c1.Id = t1.customerId  WHERE T1.ReturnFee IS NOT null  and c1.Id <> 0 " +
                " ) AS aa ORDER BY aa.CustomerName";
            //c1.Id <> 0 " +

            dt = commondata.MyExecuteReader(sqlcmd);
            ds.Tables.Add(dt);
            ds.Tables[1].TableName = "สรุปยอดรวม";

            //ExcelFiles
            filename = "สรุปยอดรวมรายคน_" + DateTime.Now.ToString("yyyyddMM_HH") + ".xlsx";
            excelFile = new Excel.ExcelFile();
            ExcelData = string.Empty;
            ExcelData = excelFile.Files(ds, filename);



            //สรุปยอดรวมทุกรอบ
            sqlcmd = "SELECT s1.SubRoundNo as 'รอบที่' , s1.CardNo as 'เลขที่บัตร'  , s1.AwardNo as 'เลขที่ออก' ," +
                " s2.BetUp as 'บน', s2.BetDown as 'ล่าง' , s2.Free as 'ค่าน้ำ' , s2.ReturnFree as 'คืนส่วนลด' ," +
                " s3.Betup AS 'เท่าแก่บน' , s3.BetDown AS 'เท่าแก่ล่าง'" +
                " FROM subround s1 " +
                " LEFT OUTER JOIN ( SELECT roundId, subroundNo , sum(betup) AS BetUp ," +
                " sum(betdown) BetDown, sum(returnbet-receive) as Free ," +
                " sum(bonus) AS bonus, sum(returnfee) AS ReturnFree FROM transaction" +
                " WHERE customerId<> 0 group BY roundId ,subroundNo ) s2" +
                " ON s1.SubRoundNo = s2.SubRoundNo AND s1.RoundId = s2.RoundId" +
                " LEFT OUTER JOIN(SELECT roundId, subroundNo, sum(betup) AS BetUp, " +
                " sum(betdown) BetDown, sum(returnbet - receive) as Free," +
                " sum(bonus) AS bonus, sum(returnfee) AS ReturnFree FROM transaction " +
                " WHERE customerId = 0 " +
                " group BY roundId, subroundNo) s3 " +
                " ON s1.SubRoundNo = s3.SubRoundNo AND s1.RoundId = s3.RoundId" +
                " WHERE s1.RoundId = (SELECT MAX(id) FROM round)";
            //sqlcmd = "SELECT SubRoundNo as 'รอบที่' , CardNo as 'เลขที่บัตร' , AwardNo as 'เลขที่ออก' ," +
            //    " BetUp as 'บน' , BetDown as 'ล่าง' , ReturnBet as 'คืนเดิมพัน' , Receive as 'ส่วนเพิ่ม' , Bonus as 'โบนัส' , ReturnFee as 'คืนส่วนลด'" +
            //    " FROM subround " +
            //    " WHERE RoundId = (SELECT MAX(id) FROM round)";
            dt = commondata.MyExecuteReader(sqlcmd);
            ds = new DataSet();
            ds.Tables.Add(dt);
            ds.Tables[0].TableName = "สรุปยอดรวมทุกรอบ";

            //ExcelFiles
            filename = "สรุปยอดรวมทุกรอบ_" + DateTime.Now.ToString("yyyyddMM_HH") + ".xlsx";
            excelFile = new Excel.ExcelFile();
            ExcelData = string.Empty;
            ExcelData = excelFile.Files(ds, filename);

            //สรุปยอดรวมฺ Bonus
            sqlcmd = "SELECT RoundId , SubRoundno " +
                " FROM transaction " +
                " WHERE RoundId = (SELECT MAX(id) FROM round) " +
                " and bonus<> 0 " +
                " GROUP BY subroundNo";
            dataHeader = new DataTable();
            dataHeader = commondata.MyExecuteReader(sqlcmd);
            ds = new DataSet();
            for (int i = 0; i<dataHeader.Rows.Count; i++)
            {
                sqlcmd = "SELECT  t1.CustomerName , (t1.BetUp + t1.BetDown) as Bet  ,  t1.Bonus" +
                    " FROM transaction t1 " + 
                    " WHERE t1.RoundId = " + dataHeader.Rows[i]["RoundId"] +
                    " AND t1.SubRoundNo = " + dataHeader.Rows[i]["SubRoundno"] +
                    " AND t1.bonus <> 0 " +
                    " ORDER BY Bonus DESC , (t1.BetUp + t1.BetDown) Desc , CustomerName";
                dataDetail = new DataTable();
                dataDetail = commondata.MyExecuteReader(sqlcmd);
                ds.Tables.Add(dataDetail);
                ds.Tables[i].TableName = "Bonus รอบที่ " + dataHeader.Rows[i]["SubRoundno"].ToString();

            }

            //ExcelFiles
            filename = "สรุปยอดโบนัส_" + DateTime.Now.ToString("yyyyddMM_HH") + ".xlsx";
            excelFile = new Excel.ExcelFile();
            ExcelData = string.Empty;
            ExcelData = excelFile.Files(ds, filename);

            //ลูกค้า
            sqlcmd = "SELECT CustomerName , Deposit AS 'ฝาก' , Credit AS 'เครดิต' , Balance AS 'คงเหลือ' ," +
                " Pay AS 'จ่าย' , ReturnFree AS 'คืน%' FROM customer ORDER BY CustomerName";
            dt = commondata.MyExecuteReader(sqlcmd);
            ds = new DataSet();
            ds.Tables.Add(dt);
            ds.Tables[0].TableName = "ลูกค้า";

            //ExcelFiles
            filename = "สรุปลูกค้า.xlsx";
            excelFile = new Excel.ExcelFile();
            ExcelData = string.Empty;
            ExcelData = excelFile.Files(ds, filename);

            //Error
            sqlcmd = "SELECT SubRoundNo , AwardNo , CustomerName , BetUp , BetDown , Receive ," +
                " CONCAT( bet1 , bet2) Error " +
                " FROM (SELECT Tr.SubRoundNo ,sr.AwardNo , Tr.CustomerName , Tr.BetUp , Tr.BetDown ," +
                " Tr.Receive , if (sr.AwardNo < 50 , if (Tr.BetUp > 0 AND Tr.Receive = 0 ,'Error','') ," +
                " if (Tr.BetDown > 0 AND Tr.Receive = 0 , 'Error',''  )) AS bet1, " +
                " if (Tr.BetUp <> 0 AND Tr.BetDown <> 0 , 'Error' , '') AS bet2 " +
                " FROM transaction AS Tr INNER JOIN subround sr " +
                " ON Tr.RoundId = sr.RoundId AND Tr.SubRoundNo = sr.SubRoundNo" +
                " WHERE Tr.RoundId = (SELECT MAX(id) FROM round) " +
                " ORDER BY Tr.SubRoundNo ,Tr.BetUp desc, Tr.BetDown desc, Tr.Id) AS aa";
            dt = commondata.MyExecuteReader(sqlcmd);
            ds = new DataSet();
            ds.Tables.Add(dt);
            ds.Tables[0].TableName = "ลูกค้า";

            //ExcelFiles
            filename = "Error.xlsx";
            excelFile = new Excel.ExcelFile();
            ExcelData = string.Empty;
            ExcelData = excelFile.Files(ds, filename);

            //DataTable dataDetail;
            sqlcmd = "SELECT * FROM `transaction` WHERE roundId =  (SELECT MAX(id) FROM round) AND betUp <> 0 AND Betdown <> 0";
            dataDetail = new DataTable();
            dataDetail = commondata.MyExecuteReader(sqlcmd);
            if (dataDetail.Rows.Count != 0)
            { 
                MessageBox.Show("Error"); }
            else
            {
                MessageBox.Show("ออกรายงานเรียบร้อย"); 
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool result = false;
            DataTable dataTable = new DataTable();
            commondata.MyBeginTran();
            try
            {
                sqlcmd = "SELECT t1.id , t1.RoundId , t1.CustomerId ,  (t1.ReturnBet * t2.returnfree) AS Fee " +
                    " FROM transaction t1 " +
                    " INNER JOIN(SELECT id, returnfree FROM customer WHERE ReturnFree <> 0) t2" +
                    " ON t1.CustomerId = t2.id" +
                    " WHERE t1.ReturnBet <> 0" +
                    " AND t1.ReturnFee = 0 " +
                    " AND t1.RoundId = (SELECT MAX(id) FROM round)";
                dataTable = commondata.MyExecuteReaderTran(sqlcmd);

                for (int i=0;i < dataTable.Rows.Count; i++)
                {
                    sqlcmd = "UPDATE transaction SET ReturnFee = " + dataTable.Rows[i]["Fee"] +
                        " WHERE id = " + dataTable.Rows[i]["id"];
                    if (commondata.MyExecuteNonQueryTran(sqlcmd) == false)
                    {
                        commondata.MyRobackTran();
                        MessageBox.Show("ติดต่อผู้ดูแลระบบ");
                        return;
                    }

                    sqlcmd = "UPDATE customer SET Balance = Balance + " + dataTable.Rows[i]["Fee"] +
                        " WHERE id = " + dataTable.Rows[i]["CustomerId"];
                    if (commondata.MyExecuteNonQueryTran(sqlcmd) == false)
                    {
                        commondata.MyRobackTran();
                        MessageBox.Show("ติดต่อผู้ดูแลระบบ");
                        return;
                    }

                }
                commondata.MyCommitTran();
                MessageBox.Show("คืนส่วนลดเรียบร้อย");
            }
            catch
            {
                commondata.MyRobackTran();
                MessageBox.Show("ติดต่อผู้ดูแลระบบ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlcmd = "update textdisplay SET TEXT = '" + txtMoving.Text.Trim().Replace("'","''") + "'";
            commondata.MyExecuteNonQuery(sqlcmd);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmReport report = new FrmReport();
            report.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            login.Show();


        }
    }
}
