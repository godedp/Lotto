namespace LottoDisplay
{
    partial class LiveScreen1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LiveScreen1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.WebStop = new System.Windows.Forms.Button();
            this.WebStart = new System.Windows.Forms.Button();
            this.ddlWebCam = new System.Windows.Forms.ComboBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.txtAwardNo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lblAwardNo = new System.Windows.Forms.Label();
            this.lblSubRound = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutUp = new System.Windows.Forms.FlowLayoutPanel();
            this.UpPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblBetUp = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutDown = new System.Windows.Forms.FlowLayoutPanel();
            this.DownPanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblBetDown = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.WebCam = new System.Windows.Forms.PictureBox();
            this.timerCountDown = new System.Windows.Forms.Timer(this.components);
            this.timerBet = new System.Windows.Forms.Timer(this.components);
            this.timerLogo = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.UpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.DownPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebCam)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gold;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.lblLogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1064, 71);
            this.panel1.TabIndex = 1;
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblLogo.Location = new System.Drawing.Point(400, 20);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(238, 33);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "เถ้าแก่น้อย มหาเฮง";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.WebStop);
            this.panel2.Controls.Add(this.WebStart);
            this.panel2.Controls.Add(this.ddlWebCam);
            this.panel2.Controls.Add(this.txtTime);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.txtCardNo);
            this.panel2.Controls.Add(this.btnProcess);
            this.panel2.Controls.Add(this.txtAwardNo);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.lblAwardNo);
            this.panel2.Controls.Add(this.lblSubRound);
            this.panel2.Controls.Add(this.btnStart);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1064, 65);
            this.panel2.TabIndex = 2;
            // 
            // WebStop
            // 
            this.WebStop.Location = new System.Drawing.Point(976, 39);
            this.WebStop.Name = "WebStop";
            this.WebStop.Size = new System.Drawing.Size(74, 23);
            this.WebStop.TabIndex = 26;
            this.WebStop.Text = "ปิดกล้อง";
            this.WebStop.UseVisualStyleBackColor = true;
            this.WebStop.Click += new System.EventHandler(this.WebStop_Click);
            // 
            // WebStart
            // 
            this.WebStart.Location = new System.Drawing.Point(903, 39);
            this.WebStart.Name = "WebStart";
            this.WebStart.Size = new System.Drawing.Size(67, 23);
            this.WebStart.TabIndex = 25;
            this.WebStart.Text = "เปิดกล้อง";
            this.WebStart.UseVisualStyleBackColor = true;
            this.WebStart.Click += new System.EventHandler(this.WebStart_Click);
            // 
            // ddlWebCam
            // 
            this.ddlWebCam.FormattingEnabled = true;
            this.ddlWebCam.Location = new System.Drawing.Point(903, 10);
            this.ddlWebCam.Name = "ddlWebCam";
            this.ddlWebCam.Size = new System.Drawing.Size(147, 21);
            this.ddlWebCam.TabIndex = 24;
            // 
            // txtTime
            // 
            this.txtTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTime.ForeColor = System.Drawing.Color.Red;
            this.txtTime.Location = new System.Drawing.Point(733, 0);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(83, 38);
            this.txtTime.TabIndex = 32;
            this.txtTime.Text = "03:00";
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnNew
            // 
            this.btnNew.Enabled = false;
            this.btnNew.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNew.Location = new System.Drawing.Point(822, 39);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 31;
            this.btnNew.Text = "รอบใหม่";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtCardNo
            // 
            this.txtCardNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtCardNo.ForeColor = System.Drawing.Color.Red;
            this.txtCardNo.Location = new System.Drawing.Point(471, 2);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(74, 38);
            this.txtCardNo.TabIndex = 30;
            // 
            // btnProcess
            // 
            this.btnProcess.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnProcess.Location = new System.Drawing.Point(822, 8);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 29;
            this.btnProcess.Text = "ประมวลผล";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtAwardNo
            // 
            this.txtAwardNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtAwardNo.ForeColor = System.Drawing.Color.Red;
            this.txtAwardNo.Location = new System.Drawing.Point(673, 2);
            this.txtAwardNo.Name = "txtAwardNo";
            this.txtAwardNo.Size = new System.Drawing.Size(54, 40);
            this.txtAwardNo.TabIndex = 28;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label15.Location = new System.Drawing.Point(551, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(116, 31);
            this.label15.TabIndex = 27;
            this.label15.Text = "เลขที่ออก";
            // 
            // lblAwardNo
            // 
            this.lblAwardNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblAwardNo.ForeColor = System.Drawing.Color.Red;
            this.lblAwardNo.Location = new System.Drawing.Point(302, 5);
            this.lblAwardNo.Name = "lblAwardNo";
            this.lblAwardNo.Size = new System.Drawing.Size(55, 30);
            this.lblAwardNo.TabIndex = 23;
            this.lblAwardNo.Text = "-";
            // 
            // lblSubRound
            // 
            this.lblSubRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblSubRound.ForeColor = System.Drawing.Color.Red;
            this.lblSubRound.Location = new System.Drawing.Point(85, 5);
            this.lblSubRound.Name = "lblSubRound";
            this.lblSubRound.Size = new System.Drawing.Size(49, 29);
            this.lblSubRound.TabIndex = 22;
            this.lblSubRound.Text = "99";
            // 
            // btnStart
            // 
            this.btnStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStart.Location = new System.Drawing.Point(733, 39);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(83, 23);
            this.btnStart.TabIndex = 21;
            this.btnStart.Text = "เริ่ม";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(351, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 31);
            this.label4.TabIndex = 20;
            this.label4.Text = "เลขบัตร";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(129, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 31);
            this.label3.TabIndex = 19;
            this.label3.Text = "รอบที่แล้วออก";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(2, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 31);
            this.label2.TabIndex = 18;
            this.label2.Text = "รอบที่";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 136);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.WebCam);
            this.splitContainer1.Size = new System.Drawing.Size(1064, 450);
            this.splitContainer1.SplitterDistance = 381;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.flowLayoutUp);
            this.splitContainer2.Panel1.Controls.Add(this.UpPanel);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.flowLayoutDown);
            this.splitContainer2.Panel2.Controls.Add(this.DownPanel);
            this.splitContainer2.Size = new System.Drawing.Size(1064, 381);
            this.splitContainer2.SplitterDistance = 518;
            this.splitContainer2.TabIndex = 0;
            // 
            // flowLayoutUp
            // 
            this.flowLayoutUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.flowLayoutUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.flowLayoutUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutUp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutUp.Location = new System.Drawing.Point(0, 42);
            this.flowLayoutUp.Name = "flowLayoutUp";
            this.flowLayoutUp.Size = new System.Drawing.Size(518, 339);
            this.flowLayoutUp.TabIndex = 2;
            // 
            // UpPanel
            // 
            this.UpPanel.BackColor = System.Drawing.Color.Blue;
            this.UpPanel.Controls.Add(this.pictureBox1);
            this.UpPanel.Controls.Add(this.lblBetUp);
            this.UpPanel.Controls.Add(this.label5);
            this.UpPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.UpPanel.Location = new System.Drawing.Point(0, 0);
            this.UpPanel.Name = "UpPanel";
            this.UpPanel.Size = new System.Drawing.Size(518, 42);
            this.UpPanel.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LottoDisplay.Properties.Resources.LossB;
            this.pictureBox1.Location = new System.Drawing.Point(176, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // lblBetUp
            // 
            this.lblBetUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBetUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblBetUp.ForeColor = System.Drawing.Color.White;
            this.lblBetUp.Location = new System.Drawing.Point(357, 3);
            this.lblBetUp.Name = "lblBetUp";
            this.lblBetUp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBetUp.Size = new System.Drawing.Size(158, 29);
            this.lblBetUp.TabIndex = 1;
            this.lblBetUp.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 29);
            this.label5.TabIndex = 0;
            this.label5.Text = "บน 00 - 49";
            // 
            // flowLayoutDown
            // 
            this.flowLayoutDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.flowLayoutDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutDown.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutDown.Location = new System.Drawing.Point(0, 42);
            this.flowLayoutDown.Name = "flowLayoutDown";
            this.flowLayoutDown.Size = new System.Drawing.Size(542, 339);
            this.flowLayoutDown.TabIndex = 3;
            // 
            // DownPanel
            // 
            this.DownPanel.BackColor = System.Drawing.Color.Red;
            this.DownPanel.Controls.Add(this.pictureBox2);
            this.DownPanel.Controls.Add(this.lblBetDown);
            this.DownPanel.Controls.Add(this.label6);
            this.DownPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.DownPanel.Location = new System.Drawing.Point(0, 0);
            this.DownPanel.Name = "DownPanel";
            this.DownPanel.Size = new System.Drawing.Size(542, 42);
            this.DownPanel.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::LottoDisplay.Properties.Resources.LossR;
            this.pictureBox2.Location = new System.Drawing.Point(169, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(204, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            // 
            // lblBetDown
            // 
            this.lblBetDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBetDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblBetDown.ForeColor = System.Drawing.Color.White;
            this.lblBetDown.Location = new System.Drawing.Point(381, 3);
            this.lblBetDown.Name = "lblBetDown";
            this.lblBetDown.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBetDown.Size = new System.Drawing.Size(158, 29);
            this.lblBetDown.TabIndex = 2;
            this.lblBetDown.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 29);
            this.label6.TabIndex = 1;
            this.label6.Text = "ล่าง 50 - 99";
            // 
            // WebCam
            // 
            this.WebCam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebCam.ErrorImage = ((System.Drawing.Image)(resources.GetObject("WebCam.ErrorImage")));
            this.WebCam.Image = global::LottoDisplay.Properties.Resources.Logo1;
            this.WebCam.Location = new System.Drawing.Point(0, 0);
            this.WebCam.Name = "WebCam";
            this.WebCam.Size = new System.Drawing.Size(1064, 65);
            this.WebCam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.WebCam.TabIndex = 1;
            this.WebCam.TabStop = false;
            // 
            // timerCountDown
            // 
            this.timerCountDown.Tick += new System.EventHandler(this.timerCountDown_Tick);
            // 
            // timerBet
            // 
            this.timerBet.Interval = 2000;
            this.timerBet.Tick += new System.EventHandler(this.timerBet_Tick);
            // 
            // timerLogo
            // 
            this.timerLogo.Interval = 10;
            this.timerLogo.Tick += new System.EventHandler(this.timerLogo_Tick);
            // 
            // LiveScreen1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 586);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LiveScreen1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "โชคมหาศาล มหาเฮง";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LiveScreen1_FormClosing);
            this.Load += new System.EventHandler(this.LiveScreen_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.UpPanel.ResumeLayout(false);
            this.UpPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.DownPanel.ResumeLayout(false);
            this.DownPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebCam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button WebStop;
        private System.Windows.Forms.Button WebStart;
        private System.Windows.Forms.ComboBox ddlWebCam;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtCardNo;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.TextBox txtAwardNo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblAwardNo;
        private System.Windows.Forms.Label lblSubRound;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel UpPanel;
        private System.Windows.Forms.Label lblBetUp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel DownPanel;
        private System.Windows.Forms.Label lblBetDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutUp;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutDown;
        private System.Windows.Forms.PictureBox WebCam;
        private System.Windows.Forms.Timer timerCountDown;
        private System.Windows.Forms.Timer timerBet;
        private System.Windows.Forms.Timer timerLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}