namespace LottoDisplay
{
    partial class LiveScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LiveScreen));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.MainContainer = new System.Windows.Forms.SplitContainer();
            this.BetContainer = new System.Windows.Forms.SplitContainer();
            this.flowLayoutUp = new System.Windows.Forms.FlowLayoutPanel();
            this.UpPanel = new System.Windows.Forms.Panel();
            this.lblBetUp = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutDown = new System.Windows.Forms.FlowLayoutPanel();
            this.DownPanel = new System.Windows.Forms.Panel();
            this.lblBetDown = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.FooterContainer = new System.Windows.Forms.SplitContainer();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.WebCam = new System.Windows.Forms.PictureBox();
            this.timerCountDown = new System.Windows.Forms.Timer(this.components);
            this.timerBet = new System.Windows.Forms.Timer(this.components);
            this.timerLogo = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).BeginInit();
            this.MainContainer.Panel1.SuspendLayout();
            this.MainContainer.Panel2.SuspendLayout();
            this.MainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BetContainer)).BeginInit();
            this.BetContainer.Panel1.SuspendLayout();
            this.BetContainer.Panel2.SuspendLayout();
            this.BetContainer.SuspendLayout();
            this.UpPanel.SuspendLayout();
            this.DownPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FooterContainer)).BeginInit();
            this.FooterContainer.Panel1.SuspendLayout();
            this.FooterContainer.Panel2.SuspendLayout();
            this.FooterContainer.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(1199, 71);
            this.panel1.TabIndex = 0;
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
            // MainContainer
            // 
            this.MainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContainer.Location = new System.Drawing.Point(0, 71);
            this.MainContainer.Name = "MainContainer";
            this.MainContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainContainer.Panel1
            // 
            this.MainContainer.Panel1.Controls.Add(this.BetContainer);
            // 
            // MainContainer.Panel2
            // 
            this.MainContainer.Panel2.Controls.Add(this.FooterContainer);
            this.MainContainer.Size = new System.Drawing.Size(1199, 445);
            this.MainContainer.SplitterDistance = 340;
            this.MainContainer.TabIndex = 1;
            // 
            // BetContainer
            // 
            this.BetContainer.Location = new System.Drawing.Point(0, 0);
            this.BetContainer.Name = "BetContainer";
            // 
            // BetContainer.Panel1
            // 
            this.BetContainer.Panel1.Controls.Add(this.flowLayoutUp);
            this.BetContainer.Panel1.Controls.Add(this.UpPanel);
            // 
            // BetContainer.Panel2
            // 
            this.BetContainer.Panel2.Controls.Add(this.flowLayoutDown);
            this.BetContainer.Panel2.Controls.Add(this.DownPanel);
            this.BetContainer.Size = new System.Drawing.Size(1199, 340);
            this.BetContainer.SplitterDistance = 597;
            this.BetContainer.TabIndex = 0;
            // 
            // flowLayoutUp
            // 
            this.flowLayoutUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.flowLayoutUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutUp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutUp.Location = new System.Drawing.Point(0, 42);
            this.flowLayoutUp.Name = "flowLayoutUp";
            this.flowLayoutUp.Size = new System.Drawing.Size(597, 298);
            this.flowLayoutUp.TabIndex = 1;
            // 
            // UpPanel
            // 
            this.UpPanel.BackColor = System.Drawing.Color.Blue;
            this.UpPanel.Controls.Add(this.lblBetUp);
            this.UpPanel.Controls.Add(this.label5);
            this.UpPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.UpPanel.Location = new System.Drawing.Point(0, 0);
            this.UpPanel.Name = "UpPanel";
            this.UpPanel.Size = new System.Drawing.Size(597, 42);
            this.UpPanel.TabIndex = 0;
            // 
            // lblBetUp
            // 
            this.lblBetUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBetUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblBetUp.ForeColor = System.Drawing.Color.White;
            this.lblBetUp.Location = new System.Drawing.Point(436, 3);
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
            this.flowLayoutDown.Size = new System.Drawing.Size(598, 298);
            this.flowLayoutDown.TabIndex = 2;
            // 
            // DownPanel
            // 
            this.DownPanel.BackColor = System.Drawing.Color.Red;
            this.DownPanel.Controls.Add(this.lblBetDown);
            this.DownPanel.Controls.Add(this.label6);
            this.DownPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.DownPanel.Location = new System.Drawing.Point(0, 0);
            this.DownPanel.Name = "DownPanel";
            this.DownPanel.Size = new System.Drawing.Size(598, 42);
            this.DownPanel.TabIndex = 1;
            // 
            // lblBetDown
            // 
            this.lblBetDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBetDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblBetDown.ForeColor = System.Drawing.Color.White;
            this.lblBetDown.Location = new System.Drawing.Point(437, 3);
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
            // FooterContainer
            // 
            this.FooterContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FooterContainer.Location = new System.Drawing.Point(0, 0);
            this.FooterContainer.Name = "FooterContainer";
            this.FooterContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // FooterContainer.Panel1
            // 
            this.FooterContainer.Panel1.Controls.Add(this.WebStop);
            this.FooterContainer.Panel1.Controls.Add(this.WebStart);
            this.FooterContainer.Panel1.Controls.Add(this.ddlWebCam);
            this.FooterContainer.Panel1.Controls.Add(this.txtTime);
            this.FooterContainer.Panel1.Controls.Add(this.btnNew);
            this.FooterContainer.Panel1.Controls.Add(this.txtCardNo);
            this.FooterContainer.Panel1.Controls.Add(this.btnProcess);
            this.FooterContainer.Panel1.Controls.Add(this.txtAwardNo);
            this.FooterContainer.Panel1.Controls.Add(this.label15);
            this.FooterContainer.Panel1.Controls.Add(this.lblAwardNo);
            this.FooterContainer.Panel1.Controls.Add(this.lblSubRound);
            this.FooterContainer.Panel1.Controls.Add(this.btnStart);
            this.FooterContainer.Panel1.Controls.Add(this.label4);
            this.FooterContainer.Panel1.Controls.Add(this.label3);
            this.FooterContainer.Panel1.Controls.Add(this.label2);
            // 
            // FooterContainer.Panel2
            // 
            this.FooterContainer.Panel2.Controls.Add(this.panel2);
            this.FooterContainer.Size = new System.Drawing.Size(1199, 101);
            this.FooterContainer.SplitterDistance = 72;
            this.FooterContainer.TabIndex = 0;
            // 
            // WebStop
            // 
            this.WebStop.Location = new System.Drawing.Point(1113, 9);
            this.WebStop.Name = "WebStop";
            this.WebStop.Size = new System.Drawing.Size(74, 23);
            this.WebStop.TabIndex = 10;
            this.WebStop.Text = "ปิดกล้อง";
            this.WebStop.UseVisualStyleBackColor = true;
            this.WebStop.Click += new System.EventHandler(this.WebStop_Click);
            // 
            // WebStart
            // 
            this.WebStart.Location = new System.Drawing.Point(1033, 9);
            this.WebStart.Name = "WebStart";
            this.WebStart.Size = new System.Drawing.Size(74, 23);
            this.WebStart.TabIndex = 9;
            this.WebStart.Text = "เปิดกล้อง";
            this.WebStart.UseVisualStyleBackColor = true;
            this.WebStart.Click += new System.EventHandler(this.WebStart_Click);
            // 
            // ddlWebCam
            // 
            this.ddlWebCam.FormattingEnabled = true;
            this.ddlWebCam.Location = new System.Drawing.Point(847, 10);
            this.ddlWebCam.Name = "ddlWebCam";
            this.ddlWebCam.Size = new System.Drawing.Size(180, 21);
            this.ddlWebCam.TabIndex = 8;
            // 
            // txtTime
            // 
            this.txtTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTime.ForeColor = System.Drawing.Color.Red;
            this.txtTime.Location = new System.Drawing.Point(415, 8);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(68, 26);
            this.txtTime.TabIndex = 17;
            this.txtTime.Text = "03:00";
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnNew
            // 
            this.btnNew.Enabled = false;
            this.btnNew.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNew.Location = new System.Drawing.Point(8, 8);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 16;
            this.btnNew.Text = "รอบใหม่";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtCardNo
            // 
            this.txtCardNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtCardNo.ForeColor = System.Drawing.Color.Red;
            this.txtCardNo.Location = new System.Drawing.Point(355, 10);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(54, 22);
            this.txtCardNo.TabIndex = 15;
            // 
            // btnProcess
            // 
            this.btnProcess.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnProcess.Location = new System.Drawing.Point(686, 7);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 14;
            this.btnProcess.Text = "ประมวลผล";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtAwardNo
            // 
            this.txtAwardNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtAwardNo.ForeColor = System.Drawing.Color.Red;
            this.txtAwardNo.Location = new System.Drawing.Point(626, 8);
            this.txtAwardNo.Name = "txtAwardNo";
            this.txtAwardNo.Size = new System.Drawing.Size(54, 22);
            this.txtAwardNo.TabIndex = 13;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(570, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 13);
            this.label15.TabIndex = 12;
            this.label15.Text = "เลขที่ออก";
            // 
            // lblAwardNo
            // 
            this.lblAwardNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblAwardNo.ForeColor = System.Drawing.Color.Red;
            this.lblAwardNo.Location = new System.Drawing.Point(256, 13);
            this.lblAwardNo.Name = "lblAwardNo";
            this.lblAwardNo.Size = new System.Drawing.Size(43, 13);
            this.lblAwardNo.TabIndex = 6;
            this.lblAwardNo.Text = "-";
            // 
            // lblSubRound
            // 
            this.lblSubRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblSubRound.ForeColor = System.Drawing.Color.Red;
            this.lblSubRound.Location = new System.Drawing.Point(129, 13);
            this.lblSubRound.Name = "lblSubRound";
            this.lblSubRound.Size = new System.Drawing.Size(43, 13);
            this.lblSubRound.TabIndex = 5;
            this.lblSubRound.Text = "-";
            // 
            // btnStart
            // 
            this.btnStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStart.Location = new System.Drawing.Point(489, 9);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "เริ่ม";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(305, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "เลขบัตร";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "รอบที่แล้วออก";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "รอบที่";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.WebCam);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1199, 25);
            this.panel2.TabIndex = 0;
            // 
            // WebCam
            // 
            this.WebCam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebCam.ErrorImage = ((System.Drawing.Image)(resources.GetObject("WebCam.ErrorImage")));
            this.WebCam.Location = new System.Drawing.Point(0, 0);
            this.WebCam.Name = "WebCam";
            this.WebCam.Size = new System.Drawing.Size(1195, 21);
            this.WebCam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.WebCam.TabIndex = 0;
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
            // LiveScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 516);
            this.Controls.Add(this.MainContainer);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LiveScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "เถ้าแก่น้อน มหาเฮง";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LiveScreen_FormClosing);
            this.Load += new System.EventHandler(this.LiveScreen_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.MainContainer.Panel1.ResumeLayout(false);
            this.MainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).EndInit();
            this.MainContainer.ResumeLayout(false);
            this.BetContainer.Panel1.ResumeLayout(false);
            this.BetContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BetContainer)).EndInit();
            this.BetContainer.ResumeLayout(false);
            this.UpPanel.ResumeLayout(false);
            this.UpPanel.PerformLayout();
            this.DownPanel.ResumeLayout(false);
            this.DownPanel.PerformLayout();
            this.FooterContainer.Panel1.ResumeLayout(false);
            this.FooterContainer.Panel1.PerformLayout();
            this.FooterContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FooterContainer)).EndInit();
            this.FooterContainer.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WebCam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer MainContainer;
        private System.Windows.Forms.SplitContainer BetContainer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutUp;
        private System.Windows.Forms.Panel UpPanel;
        private System.Windows.Forms.Panel DownPanel;
        private System.Windows.Forms.SplitContainer FooterContainer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer timerCountDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblBetUp;
        private System.Windows.Forms.Label lblAwardNo;
        private System.Windows.Forms.Label lblSubRound;
        private System.Windows.Forms.Button WebStop;
        private System.Windows.Forms.Button WebStart;
        private System.Windows.Forms.ComboBox ddlWebCam;
        private System.Windows.Forms.PictureBox WebCam;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.TextBox txtAwardNo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCardNo;
        private System.Windows.Forms.Label lblBetDown;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer timerBet;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Timer timerLogo;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtTime;
    }
}