using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using AForge.Video;
using AForge.Video.DirectShow;

namespace LottoDisplay
{
    public partial class LiveScreen1 : Form
    {

        int LocationX = 300;
        int logoWidth = 0;
        DateTime dateTime;
        private Stopwatch timer = new Stopwatch();
        Class.Commondata commondata = new Class.Commondata();
        DataTable DataHeader = new DataTable();
        DataTable dt = new DataTable();
        string sqlcmd;

        public Int64 subRoundId { get; set; }
        public Int64 RoundId { get; set; }
        public Int64 SubRoundNo { get; set; }

        //VDO
        FilterInfoCollection filter;
        VideoCaptureDevice videoCapture;


        public LiveScreen1()
        {
            InitializeComponent();
        }


        private void timerCountDown_Tick(object sender, EventArgs e)
        {
            txtTime.Text = (dateTime - timer.Elapsed).ToString("mm:ss");
            if (txtTime.Text == "00:00")
            {
                timerCountDown.Enabled = false;
            }
            //TimeSpan xx = new TimeSpan(0, 3, 00);
            //if (xx < timer.Elapsed)
            //{
            //    txtTime.Text = "00:00";
            //    timerCountDown.Enabled = false;
            //}
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            if (txtCardNo.Text.Trim() != "")
            {
                sqlcmd = "UPDATE subround SET CardNo = '" + txtCardNo.Text.Trim() + "' WHERE id =" + subRoundId;
                commondata.MyExecuteNonQuery(sqlcmd);
                string xx = "1/1/2522 0:" + txtTime.Text.Trim();
                dateTime = Convert.ToDateTime(xx);
                timer.Start();
                timerCountDown.Enabled = true;
            }
            else
            {
                MessageBox.Show("กรุณาใส่เลขบัตรก่อน");
                txtCardNo.Focus();
            }

        }

        private void LiveScreen_Load(object sender, EventArgs e)
        {
            filter = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filter)
            {
                ddlWebCam.Items.Add(filterInfo.Name);
                ddlWebCam.SelectedIndex = 0;
                videoCapture = new VideoCaptureDevice();
            }
            pictureBox1.Image = null;
            pictureBox2.Image = null;

            sqlcmd = "select * from textdisplay";
            dt = commondata.MyExecuteReader(sqlcmd);
            lblLogo.Text = dt.Rows[0][0].ToString();
            logoWidth = (lblLogo.Width * -1);

            sqlcmd = "SELECT RoundId , SubRoundNo , CardNo , AwardNo , BetUp , BetDown" +
                      " FROM subround WHERE id = " + subRoundId;
            DataHeader = commondata.MyExecuteReader(sqlcmd);
            if (DataHeader.Rows.Count != 0)
            {

                RoundId = Convert.ToInt64(DataHeader.Rows[0]["RoundId"]);
                SubRoundNo = Convert.ToInt64(DataHeader.Rows[0]["SubRoundNo"]);
                lblSubRound.Text = SubRoundNo.ToString();
                if (DataHeader.Rows[0]["CardNo"].ToString() != "") { txtCardNo.Text = DataHeader.Rows[0]["CardNo"].ToString(); }
                if (DataHeader.Rows[0]["BetUp"].ToString() != "") { lblBetUp.Text = DataHeader.Rows[0]["BetUp"].ToString(); }
                if (DataHeader.Rows[0]["BetDown"].ToString() != "") { lblBetDown.Text = DataHeader.Rows[0]["BetDown"].ToString(); }
                if (DataHeader.Rows[0]["AwardNo"].ToString() != "")
                {

                    txtAwardNo.Text = DataHeader.Rows[0]["AwardNo"].ToString();
                    btnProcess.Enabled = false;
                    btnStart.Enabled = false;
                    btnNew.Enabled = true;
                    txtAwardNo.Enabled = false;
                    txtCardNo.Enabled = false;
                }
                sqlcmd = "SELECT AwardNo FROM subround" +
                    " WHERE RoundId = " + RoundId +
                    " and SubRoundNo = " + (SubRoundNo - 1);
                dt = new DataTable();
                dt = commondata.MyExecuteReader(sqlcmd);
                if (dt.Rows.Count != 0)
                {
                    lblAwardNo.Text = string.Format("{0:0,0}", Convert.ToDecimal(dt.Rows[0][0]));
                }
            }
            else
            {
                MessageBox.Show("กรุณาติดต่อผู้ดูแลระบบ");
            }
            DisplayBet();
            timerBet.Enabled = true;
            timerLogo.Enabled = true;
        }

        private void videoCapture_newFrame(object sender, NewFrameEventArgs eventArgs)
        {
            WebCam.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void WebStart_Click(object sender, EventArgs e)
        {
            videoCapture = new VideoCaptureDevice(filter[ddlWebCam.SelectedIndex].MonikerString);
            videoCapture.NewFrame += videoCapture_newFrame;
            videoCapture.Start();
        }

        private void WebStop_Click(object sender, EventArgs e)
        {
            if (videoCapture.IsRunning == true)
            {
                videoCapture.Stop();
                WebCam.Image = LottoDisplay.Properties.Resources.Logo1;
            }
        }

        private void LiveScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoCapture.IsRunning == true)
            {
                videoCapture.Stop();

            }
            System.Windows.Forms.Application.ExitThread();
        }

        private void DisplayBet()
        {
            DataTable dataTable = new DataTable();
            sqlcmd = "SELECT betUp , BetDown" +
                " FROM subround  " +
                " WHERE RoundId = " + RoundId +
                " AND subRoundNo = " + SubRoundNo;
            dataTable = commondata.MyExecuteReader(sqlcmd);
            if (dataTable.Rows.Count != 0)
            {
                lblBetUp.Text = Convert.ToDecimal(dataTable.Rows[0]["betUp"]).ToString("N0");
                lblBetDown.Text = Convert.ToDecimal(dataTable.Rows[0]["BetDown"]).ToString("N0");
            }
            else
            {
                lblBetUp.Text = "0";
                lblBetDown.Text = "0";
            }


            sqlcmd = "SELECT id ,  CustomerName , BetUp , BetDown   " +
                " FROM transaction " +
                " WHERE RoundId = " + RoundId +
                " AND SubRoundNo = " + SubRoundNo +
                " ORDER BY Id ";


            dataTable = commondata.MyExecuteReader(sqlcmd);
            flowLayoutUp.Controls.Clear();
            flowLayoutDown.Controls.Clear();


            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                UserControlBet userControlBet = new UserControlBet();
                userControlBet.TName = dataTable.Rows[i]["CustomerName"].ToString();
                userControlBet.Name = dataTable.Rows[i]["Id"].ToString();
                if (dataTable.Rows[i]["BetUp"].ToString() != "0.00")
                {
                    userControlBet.TAmount = Convert.ToDecimal(dataTable.Rows[i]["BetUp"]).ToString("N0");
                    flowLayoutUp.Controls.Add(userControlBet);
                }
                if (dataTable.Rows[i]["BetDown"].ToString() != "0.00")
                {
                    userControlBet.TAmount = Convert.ToDecimal(dataTable.Rows[i]["BetDown"]).ToString("N0");
                    flowLayoutDown.Controls.Add(userControlBet);
                }
            }
        }

        private void timerBet_Tick(object sender, EventArgs e)
        {
            DisplayBet();
        }

        private void LogoMove()
        {
            lblLogo.Location = new Point(LocationX, 20);
            LocationX--;
            if (LocationX < logoWidth)
            {
                dt = new DataTable();
                sqlcmd = "select * from textdisplay";
                dt = commondata.MyExecuteReader(sqlcmd);
                lblLogo.Text = dt.Rows[0][0].ToString();
                logoWidth = (lblLogo.Width * -1);

                LocationX = this.Width;
            }
        }

        private void timerLogo_Tick(object sender, EventArgs e)
        {
            LogoMove();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ยืนยันการประมวลผล ", "ประมวลผล", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                commondata.MyBeginTran();
                decimal bet = 0;
                decimal pay = 0;
                decimal amount = 0;
                decimal receive = 0;
                bool result;
                try
                {
                    if (txtAwardNo.Text.Trim() != "")
                    {
                        sqlcmd = "update subround set AwardNo = '" + txtAwardNo.Text + "'" +
                            " , CardNo = '" + txtCardNo.Text.Trim() + "'" +
                            " where RoundId = " + RoundId +
                            " and SubRoundNo = " + SubRoundNo;
                        result = commondata.MyExecuteNonQueryTran(sqlcmd);
                        if (result == false)
                        {
                            commondata.MyRobackTran();
                            MessageBox.Show("ติดต่อผู้ดูแลระบบ");
                            return;
                        }

                        if (Convert.ToInt32(txtAwardNo.Text) < 50)
                        {
                            pictureBox1.Image = LottoDisplay.Properties.Resources.WinB;
                            pictureBox2.Image = LottoDisplay.Properties.Resources.LossR;
                            sqlcmd = "SELECT  id , customerId , BetUp , BetDown , Pay , Amount" +
                                " FROM transaction " +
                                " WHERE BetUp <> 0" +
                                " and RoundId = " + RoundId +
                                " and SubRoundNo = " + SubRoundNo;
                        }
                        else
                        {
                            pictureBox1.Image = LottoDisplay.Properties.Resources.LossB;
                            pictureBox2.Image = LottoDisplay.Properties.Resources.WinR;

                            sqlcmd = "SELECT  id , customerId , BetUp , BetDown , Pay , Amount" +
                                " FROM transaction " +
                                " WHERE BetDown <> 0" +
                                " and RoundId = " + RoundId +
                                " and SubRoundNo = " + SubRoundNo;
                        }
                        //ประมวลผลเดิมพัน
                        dt = commondata.MyExecuteReaderTran(sqlcmd);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            bet = 0;
                            pay = 0;
                            amount = 0;
                            bet = Convert.ToDecimal(dt.Rows[i]["BetUp"]) + Convert.ToDecimal(dt.Rows[i]["BetDown"]);
                            pay = Convert.ToDecimal(dt.Rows[i]["Pay"]);
                            receive = bet * pay;
                            amount = (bet * pay) + bet;
                            sqlcmd = "update transaction set Amount = " + amount +
                                " ,ReturnBet = " + bet +
                                " ,Receive =" + receive +
                                " where id = " + dt.Rows[i]["id"];
                            result = commondata.MyExecuteNonQueryTran(sqlcmd);
                            if (result == false)
                            {
                                commondata.MyRobackTran();
                                MessageBox.Show("ติดต่อผู้ดูแลระบบ");
                                break;
                            }
                            sqlcmd = "update customer set Balance = Balance + " + amount +
                                " where id = " + dt.Rows[i]["customerId"];
                            result = commondata.MyExecuteNonQueryTran(sqlcmd);
                            if (result == false)
                            {
                                commondata.MyRobackTran();
                                MessageBox.Show("ติดต่อผู้ดูแลระบบ");
                                break;
                            }
                        }
                        //Bonus
                        //if (SubRoundNo > 1)
                        //{
                        //    bool Bonus4 = false;
                        //    bool Bonus3 = false;
                        //    bool Bonus2 = false;
                        //    bool Bonus1 = false;
                        //    decimal Bonus = 0;

                        //    sqlcmd = "SELECT CardNo , AwardNo " +
                        //            " FROM subround " +
                        //            " WHERE RoundId =  " + RoundId +
                        //            " AND subroundNo = " + (SubRoundNo - 1);
                        //    dt = new DataTable();
                        //    dt = commondata.MyExecuteReaderTran(sqlcmd);
                        //    if (dt.Rows[0]["CardNo"].ToString() == txtCardNo.Text.Trim() && dt.Rows[0]["AwardNo"].ToString() == txtAwardNo.Text.Trim())
                        //    {
                        //        timerBet.Enabled = false;
                        //        pictureBox1.Image = LottoDisplay.Properties.Resources.BonusB;
                        //        pictureBox2.Image = LottoDisplay.Properties.Resources.BonusR;

                        //        // >= 500,000
                        //        dt = new DataTable();
                        //        sqlcmd = "SELECT id, customerId, BetUp, BetDown, Pay, Amount " +
                        //            " FROM transaction " +
                        //            " WHERE RoundId = " + RoundId +
                        //            " AND SubRoundNo = " + SubRoundNo +
                        //            " AND (BetUp >= 50000 OR BetDown >= 50000)" +
                        //            " AND CustomerId <> 0";
                        //        dt = commondata.MyExecuteReaderTran(sqlcmd);
                        //        if (dt.Rows.Count >= 4)
                        //        {
                        //            Bonus = 500000 / dt.Rows.Count;
                        //            for (int i = 0; i < dt.Rows.Count; i++)
                        //            {
                        //                sqlcmd = "update transaction set Bonus = " + Bonus +
                        //                    " where id = " + dt.Rows[i]["id"];
                        //                result = commondata.MyExecuteNonQueryTran(sqlcmd);
                        //                if (result == false)
                        //                {
                        //                    commondata.MyRobackTran();
                        //                    MessageBox.Show("ติดต่อผู้ดูแลระบบ");
                        //                    break;
                        //                }

                        //            }
                        //            Bonus4 = true;
                        //        }

                        //        // >= 200,000
                        //        dt = new DataTable();
                        //        if (Bonus4 == false)
                        //        {
                        //            sqlcmd = "SELECT id, customerId, BetUp, BetDown, Pay, Amount " +
                        //                " FROM transaction " +
                        //                " WHERE RoundId = " + RoundId +
                        //                " AND SubRoundNo = " + SubRoundNo +
                        //                " AND (BetUp >= 10000 OR BetDown >=10000)" +
                        //                " AND CustomerId <> 0";
                        //        }
                        //        else
                        //        {
                        //            sqlcmd = "SELECT id, customerId, BetUp, BetDown, Pay, Amount " +
                        //                " FROM transaction " +
                        //                " WHERE RoundId = " + RoundId +
                        //                " AND SubRoundNo = " + SubRoundNo +
                        //                " AND ((BetUp < 50000 AND BetUp >= 10000) OR (BetDown < 50000 AND BetDown >= 10000) )  " +
                        //                " AND CustomerId <> 0";
                        //        }
                        //        dt = commondata.MyExecuteReaderTran(sqlcmd);
                        //        if (dt.Rows.Count >= 4)
                        //        {
                        //            Bonus = 200000 / dt.Rows.Count;
                        //            for (int i = 0; i < dt.Rows.Count; i++)
                        //            {
                        //                sqlcmd = "update transaction set Bonus = " + Bonus +
                        //                    " where id = " + dt.Rows[i]["id"];
                        //                result = commondata.MyExecuteNonQueryTran(sqlcmd);
                        //                if (result == false)
                        //                {
                        //                    commondata.MyRobackTran();
                        //                    MessageBox.Show("ติดต่อผู้ดูแลระบบ");
                        //                    break;
                        //                }
  
                        //            }
                        //            Bonus3 = true;
                        //        }

                        //        // >= 100,000
                        //        dt = new DataTable();
                        //        if (Bonus3 == true)
                        //        {
                        //            sqlcmd = "SELECT id, customerId, BetUp, BetDown, Pay, Amount " +
                        //                " FROM transaction " +
                        //                " WHERE RoundId = " + RoundId +
                        //                " AND SubRoundNo = " + SubRoundNo +
                        //                " AND ((BetUp < 10000  AND BetUp >= 2000) or (BetDown < 10000  AND BetDown >= 2000))" +
                        //                " AND customerId <> 0";
                        //        }
                        //        else if (Bonus4 == true && Bonus3 == false)
                        //        {
                        //            sqlcmd = "SELECT id, customerId, BetUp, BetDown, Pay, Amount " +
                        //                " FROM transaction " +
                        //                " WHERE RoundId = " + RoundId +
                        //                " AND SubRoundNo = " + SubRoundNo +
                        //                " AND ((BetUp < 50000  AND BetUp >= 2000) or (BetDown < 50000  AND BetDown >= 2000))" +
                        //                " AND customerId <> 0";
                        //        }
                        //        else if (Bonus4 == false && Bonus3 == false)
                        //        {
                        //            sqlcmd = "SELECT id, customerId, BetUp, BetDown, Pay, Amount " +
                        //                " FROM transaction " +
                        //                " WHERE RoundId = " + RoundId +
                        //                " AND SubRoundNo = " + SubRoundNo +
                        //                " AND  (BetUp >= 2000 or BetDown >= 2000) " +
                        //                " AND customerId <> 0";
                        //        }
                        //        dt = commondata.MyExecuteReaderTran(sqlcmd);
                        //        if (dt.Rows.Count >= 4)
                        //        {
                        //            Bonus = 100000 / dt.Rows.Count;
                        //            for (int i = 0; i < dt.Rows.Count; i++)
                        //            {
                        //                sqlcmd = "update transaction set Bonus = " + Bonus +
                        //                    " where id = " + dt.Rows[i]["id"];
                        //                result = commondata.MyExecuteNonQueryTran(sqlcmd);
                        //                if (result == false)
                        //                {
                        //                    commondata.MyRobackTran();
                        //                    MessageBox.Show("ติดต่อผู้ดูแลระบบ");
                        //                    break;
                        //                }

                        //            }
                        //            Bonus2 = true;
                        //        }

                        //        // >= 50,000
                        //        dt = new DataTable();
                        //        if (Bonus2 == true)
                        //        {
                        //            sqlcmd = "SELECT id, customerId, BetUp, BetDown, Pay, Amount " +
                        //                " FROM transaction " +
                        //                " WHERE RoundId = " + RoundId +
                        //                " AND SubRoundNo = " + SubRoundNo +
                        //                " AND ((BetUp < 2000 AND BetUp > 0) OR (BetDown < 2000 AND BetDown > 0))" + 
                        //                " AND customerId <> 0";
                        //        }
                        //        else if (Bonus3 == true && Bonus2 == false)
                        //        {
                        //            sqlcmd = "SELECT id, customerId, BetUp, BetDown, Pay, Amount " +
                        //                " FROM transaction " +
                        //                " WHERE RoundId = " + RoundId +
                        //                " AND SubRoundNo = " + SubRoundNo +
                        //                " AND ((BetUp < 10000 AND BetUp > 0) or (BetDown < 10000 AND BetDown > 0))" +
                        //                " AND customerId <> 0";
                        //        }
                        //        else if (Bonus4 == true && Bonus3 == false && Bonus2 == false)
                        //        {
                        //            sqlcmd = "SELECT id, customerId, BetUp, BetDown, Pay, Amount " +
                        //                " FROM transaction " +
                        //                " WHERE RoundId = " + RoundId +
                        //                " AND SubRoundNo = " + SubRoundNo +
                        //                " AND ((BetUp < 50000 AND BetUp > 0) or BetDown < 50000 AND BetDown > 0)" +
                        //                " AND customerId <> 0";
                        //        }
                        //        else if (Bonus4 == false && Bonus3 == false && Bonus2 == false)
                        //        {
                        //            sqlcmd = "SELECT id, customerId, BetUp, BetDown, Pay, Amount " +
                        //                " FROM transaction " +
                        //                " WHERE RoundId = " + RoundId +
                        //                " AND SubRoundNo = " + SubRoundNo +
                        //                " AND (BetUp > 0 or BetDown > 0)" +
                        //                " AND customerId <> 0";
                        //        }
                        //        dt = commondata.MyExecuteReaderTran(sqlcmd);
                        //        if (dt.Rows.Count >= 4)
                        //        {
                        //            Bonus = 50000 / dt.Rows.Count;
                        //            for (int i = 0; i < dt.Rows.Count; i++)
                        //            {
                        //                sqlcmd = "update transaction set Bonus = " + Bonus +
                        //                    " where id = " + dt.Rows[i]["id"];
                        //                result = commondata.MyExecuteNonQueryTran(sqlcmd);
                        //                if (result == false)
                        //                {
                        //                    commondata.MyRobackTran();
                        //                    MessageBox.Show("ติดต่อผู้ดูแลระบบ");
                        //                    break;
                        //                }

                        //            }
                        //            Bonus2 = true;
                        //        }


                        //        //Display Bonus
                        //        sqlcmd = "SELECT id ,  CustomerName , BetUp , BetDown , Bonus " + 
                        //            " FROM transaction " +
                        //            " WHERE RoundId = " + RoundId +
                        //            " AND SubRoundNo = " + SubRoundNo +
                        //            " ORDER BY Id ";

                        //        DataTable dataTable = new DataTable();
                        //        dataTable = commondata.MyExecuteReaderTran(sqlcmd);
                        //        flowLayoutUp.Controls.Clear();
                        //        flowLayoutDown.Controls.Clear();


                        //        for (int i = 0; i < dataTable.Rows.Count; i++)
                        //        {
                        //            UserControlBet userControlBet = new UserControlBet();
                        //            userControlBet.TName = dataTable.Rows[i]["CustomerName"].ToString();
                        //            userControlBet.Name = dataTable.Rows[i]["Id"].ToString();
                        //            if (dataTable.Rows[i]["BetUp"].ToString() != "0.00")
                        //            {
                        //                userControlBet.TAmount = Convert.ToDecimal(dataTable.Rows[i]["Bonus"]).ToString("N0");
                        //                flowLayoutUp.Controls.Add(userControlBet);
                        //            }
                        //            if (dataTable.Rows[i]["BetDown"].ToString() != "0.00")
                        //            {
                        //                userControlBet.TAmount = Convert.ToDecimal(dataTable.Rows[i]["Bonus"]).ToString("N0");
                        //                flowLayoutDown.Controls.Add(userControlBet);
                        //            }
                        //        }




                        //    }
                        //}

                        txtCardNo.Enabled = false;
                        txtAwardNo.Enabled = false;
                        btnNew.Enabled = true;
                        btnStart.Enabled = false;
                        btnProcess.Enabled = false;

                        commondata.MyCommitTran();
                        MessageBox.Show("ประมวลผลสำเร็จ");
                    }
                    else
                    {
                        MessageBox.Show("กรุณาใส่เลขที่ออก");
                        txtAwardNo.Focus();
                        commondata.MyRobackTran();
                    }
                }
                catch (Exception ex)
                {
                    commondata.MyRobackTran();
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            timerBet.Enabled = false;
            commondata.MyBeginTran();
            bool result;
            try
            {
                sqlcmd = "Insert into SubRound (RoundId ,SubRoundNo ,CreateUser,UpdateUser) " +
                    " values " +
                    " ( " + RoundId + " , " + (SubRoundNo + 1) + " , 'Auto' , 'Auto')";
                result = commondata.MyExecuteNonQueryTran(sqlcmd);
                if (result == true)
                {
                    sqlcmd = "select Id ,RoundId,SubRoundNo " +
                        " from SubRound " +
                        " where RoundId = " + RoundId +
                        " and SubRoundNo = " + (SubRoundNo + 1);
                    dt = commondata.MyExecuteReaderTran(sqlcmd);
                    subRoundId = Convert.ToInt64(dt.Rows[0]["id"]);
                    SubRoundNo = Convert.ToInt64(dt.Rows[0]["SubRoundNo"]);
                    lblSubRound.Text = SubRoundNo.ToString();

                    lblAwardNo.Text = "";
                    sqlcmd = "SELECT AwardNo FROM subround" +
                        " WHERE RoundId = " + RoundId +
                        " and SubRoundNo = " + (SubRoundNo - 1);
                    dt = commondata.MyExecuteReaderTran(sqlcmd);
                    if (dt.Rows.Count != 0)
                    {
                        lblAwardNo.Text = string.Format("{0:0,0}", Convert.ToDecimal(dt.Rows[0][0]));
                    }


                }
                else
                {
                    commondata.MyRobackTran();
                    MessageBox.Show("ติดต่อผู้ดูแลระบบ");
                }
                commondata.MyCommitTran();
                btnNew.Enabled = false;
                btnStart.Enabled = true;
                btnProcess.Enabled = true;
                txtAwardNo.Enabled = true;
                txtCardNo.Enabled = true;
                txtAwardNo.Text = "";
                txtCardNo.Text = "";
                MessageBox.Show("เปิดรอบใหม่สำเร็จ");







            }
            catch
            {
                commondata.MyRobackTran();
                MessageBox.Show("ติดต่อผู้ดูแลระบบ");
            }

            timerBet.Enabled = true;


        }

        private void LiveScreen1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void DisplayBonus()
        {
            DataTable dataTable = new DataTable();
            sqlcmd = "SELECT betUp , BetDown" +
                " FROM subround  " +
                " WHERE RoundId = " + RoundId +
                " AND subRoundNo = " + SubRoundNo;
            dataTable = commondata.MyExecuteReader(sqlcmd);
            if (dataTable.Rows.Count != 0)
            {
                lblBetUp.Text = Convert.ToDecimal(dataTable.Rows[0]["betUp"]).ToString("N0");
                lblBetDown.Text = Convert.ToDecimal(dataTable.Rows[0]["BetDown"]).ToString("N0");
            }
            else
            {
                lblBetUp.Text = "0";
                lblBetDown.Text = "0";
            }


            sqlcmd = "SELECT id ,  CustomerName , BetUp , BetDown , Bonus " +
                " FROM transaction " +
                " WHERE RoundId = " + RoundId +
                " AND SubRoundNo = " + SubRoundNo +
                " ORDER BY Id ";


            dataTable = commondata.MyExecuteReader(sqlcmd);
            flowLayoutUp.Controls.Clear();
            flowLayoutDown.Controls.Clear();


            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                UserControlBet userControlBet = new UserControlBet();
                userControlBet.TName = dataTable.Rows[i]["CustomerName"].ToString();
                userControlBet.Name = dataTable.Rows[i]["Id"].ToString();
                if (dataTable.Rows[i]["BetUp"].ToString() != "0.00")
                {
                    userControlBet.TAmount = Convert.ToDecimal(dataTable.Rows[i]["Bonus"]).ToString("N0");
                    flowLayoutUp.Controls.Add(userControlBet);
                }
                if (dataTable.Rows[i]["BetDown"].ToString() != "0.00")
                {
                    userControlBet.TAmount = Convert.ToDecimal(dataTable.Rows[i]["Bonus"]).ToString("N0");
                    flowLayoutDown.Controls.Add(userControlBet);
                }
            }
        }
    }
}
