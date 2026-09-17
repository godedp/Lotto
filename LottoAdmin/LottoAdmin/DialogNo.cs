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
    public partial class DialogNo : Form
    {
        string roundid;
        DataTable dt = new DataTable();
        string LineToken = System.Configuration.ConfigurationManager.AppSettings["LineToken"];
        Class.Commondata commondata = new Class.Commondata();
        public DialogNo()
        {
            InitializeComponent();
        }

        public string UserName { get;set; }
        public Boolean Admin { get; set; }

        private void DialogNo_Load(object sender, EventArgs e)
        {
            if (Admin == true )
            {
                btnAdd.Enabled = true;
                btnAdd.Visible = true;
            }
            else
            {
                btnAdd.Enabled = false;
                btnAdd.Visible = false;
            }
            ClassUtil.DateUtility dateUtility = new ClassUtil.DateUtility();
            string sqlcmd;
            sqlcmd = $@"select s.Id , s.RoundID , s.SubRoundNo , s.CardNo , s.AwardNo , r.CreateDTM 
                        from subround s inner join round r
                        on s.RoundID = r.Id
                        where s.RoundID  = (select max(id) from round )
                        and s.AwardNo is not  null
                        order by s.subRoundNo desc";
            dt = commondata.MyExecuteReader(sqlcmd);

            if (dt.Rows.Count != 0)
            {
                roundid = dt.Rows[0]["RoundID"].ToString();
                lblDate.Text = dateUtility.ThDateShort( dt.Rows[0]["CreateDTM"].ToString());
                cbRound.ValueMember = "Id";
                cbRound.DisplayMember = "SubRoundNo";
                cbRound.DataSource = dt;
            }
        }

        private void cbRound_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlcmd;
            sqlcmd = $@"select Id , RoundID , SubRoundNo , CardNo , AwardNo 
                        from subround 
                        where Id  = {cbRound.SelectedValue}";
            dt = commondata.MyExecuteReader(sqlcmd);
            if (dt.Rows.Count != 0)
            {
                lblCardNo.Text = dt.Rows[0]["CardNo"].ToString();
                lblAwardNo.Text = dt.Rows[0]["AwardNo"].ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ClassUtil.LineNoti lineNoti = new ClassUtil.LineNoti();
            ClassUtil.DateUtility dateUtility = new ClassUtil.DateUtility();
            string TMessage;
            string sqlcmd;

            if (txtAward.Text.Length !=2)
            {
                MessageBox.Show("กรุณาระบุเลขที่แก้ไข 2 หลัก");
                return;
            }

            DialogResult result = MessageBox.Show("ยืนยันการแก้ไขจากเลข " + lblAwardNo.Text + " เป็นเลข " + txtAward.Text, "ยืนยันการแก้ไข",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // ตรวจสอบการตอบกลับของผู้ใช้
            if (result == DialogResult.Yes)
            {
                //Recalculate

                commondata.MyBeginTran();

                try
                {
                    sqlcmd = $@"update subround 
                            set AwardNo = {txtAward.Text}  
                            where roundid = {roundid} 
                            and SubRoundNo = {dt.Rows[0]["SubRoundNo"]}";
                    if (commondata.MyExecuteNonQueryTran(sqlcmd) == false)
                    {
                        commondata.MyRobackTran();
                        return;
                    }


                    if (Convert.ToInt32(txtAward.Text) < 50)
                    {
                        sqlcmd = $@"update transaction 
                                set ReturnBet = betup , 
                                receive = betup * Pay , 
                                amount = betup +  (betup * Pay )
                                where roundid = {roundid} 
                                and SubRoundNo = {dt.Rows[0]["SubRoundNo"]};";
                    }
                    else
                    {
                        sqlcmd = $@"update transaction 
                                set ReturnBet = betdown , 
                                receive = betdown * Pay , 
                                amount = betdown +  (betdown * Pay )
                                where roundid = {roundid} 
                                and SubRoundNo = {dt.Rows[0]["SubRoundNo"]};";
                    }
                    if (commondata.MyExecuteNonQueryTran(sqlcmd) == false)
                    {
                        commondata.MyRobackTran();
                        return;
                    }

                    //Send Message
                    TMessage = "\r\nแก้ไขรายการโดย " + UserName + "\r\n" +
                    "วันที่ " + lblDate.Text + "\r\n" +
                    "รอบที่ " + dt.Rows[0]["SubRoundNo"] + "\r\n" +
                    "บัตรเลขที่ " + lblCardNo.Text + "\r\n" +
                    "เลขที่เดิม " + lblAwardNo.Text + "\r\n" +
                    "เลขที่แก้ไข " + txtAward.Text + "\r\n" +
                    "วันเวลาที่แก้ไข " + dateUtility.ThDateTimeLong();


                    lineNoti.LineNotifyAsync("OXG6O2sGVUGD3yvsLauwXYXf7o1pI9A4HYBUVxQtjZ0", TMessage, "");
                    lineNoti.LineNotifyAsync("JRixeohIv8qe3YezgFR455fGRMTGzkB0ypQvcXpoxgc", TMessage, "");
                    commondata.MyCommitTran();

                    DateTime date = DateTime.Now;
                    DataSet ds;
                    DataTable datacustomer = new DataTable();
                    DataTable dataHeader;
                    DataTable dataDetail;
                    //DataTable dt = new DataTable();

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
                        int y = 35;
                        //if (y < 30) { y = 30; };

                        for (int x = 0; x < dataDetail.Rows.Count; x++)
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
                            if (x + y < dataDetail.Rows.Count && x + y < 60)
                            {
                                dataRow[8] = dataDetail.Rows[x + y]["รอบที่"];
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
                            if (x == y - 1) { break; }
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
                        ds.Tables[0].TableName = dataHeader.Rows[0]["customerName"].ToString();

                        //ExcelFiles
                        //filename = dataHeader.Rows[0]["customerName"].ToString() + DateTime.Now.ToString("yyyyddMM_HH") + ".xlsx";
                        //excelFile = new Excel.ExcelFile();
                        //ExcelData = string.Empty;
                        //ExcelData = excelFile.Files(ds, filename);

                        //if (datacustomer.Rows[i]["CustomerId"].ToString() == "174")
                        //{
                        //    var xxxxxxx = "xx";
                        //}
                        decimal tmp1 = xPL + xReturn;
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


                    MessageBox.Show("ปรับปรุงรายการเรียบร้อย");
                    this.Dispose();
                }
                catch
                {
                    commondata.MyRobackTran();
                }


                
            }
            else if (result == DialogResult.No)
            {
              
            }





        }


        private void txtAward_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtAward.Text.Length >= 2 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            ChangePassword change = new ChangePassword();
            change.UserName = UserName;
            change.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CreateUser createUser = new CreateUser();
            createUser.UserName = UserName;
            createUser.Show();
        }
    }
}
