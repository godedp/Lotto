namespace LottoAdmin
{
    partial class Customer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturnFree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCredit = new System.Windows.Forms.TextBox();
            this.txtPay = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFee = new System.Windows.Forms.TextBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.Deposit = new System.Windows.Forms.Button();
            this.withdraw = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblwithdraw = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDeposit = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnWithdrawAll = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.CustomerName,
            this.STATUS,
            this.Debit,
            this.Credit,
            this.Balance,
            this.Pay,
            this.ReturnFree});
            this.dgv.Location = new System.Drawing.Point(12, 12);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(679, 507);
            this.dgv.TabIndex = 0;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "ชื่อลูกค้า";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // STATUS
            // 
            this.STATUS.DataPropertyName = "STATUS";
            this.STATUS.HeaderText = "STATUS";
            this.STATUS.Name = "STATUS";
            this.STATUS.ReadOnly = true;
            this.STATUS.Visible = false;
            // 
            // Debit
            // 
            this.Debit.DataPropertyName = "Deposit";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.Debit.DefaultCellStyle = dataGridViewCellStyle6;
            this.Debit.HeaderText = "ฝาก";
            this.Debit.Name = "Debit";
            this.Debit.ReadOnly = true;
            // 
            // Credit
            // 
            this.Credit.DataPropertyName = "Credit";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            this.Credit.DefaultCellStyle = dataGridViewCellStyle7;
            this.Credit.HeaderText = "เครดิต";
            this.Credit.Name = "Credit";
            this.Credit.ReadOnly = true;
            // 
            // Balance
            // 
            this.Balance.DataPropertyName = "Balance";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            this.Balance.DefaultCellStyle = dataGridViewCellStyle8;
            this.Balance.HeaderText = "คงเหลือ";
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            // 
            // Pay
            // 
            this.Pay.DataPropertyName = "Pay";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.Pay.DefaultCellStyle = dataGridViewCellStyle9;
            this.Pay.HeaderText = "อัตราจ่าย";
            this.Pay.Name = "Pay";
            this.Pay.ReadOnly = true;
            // 
            // ReturnFree
            // 
            this.ReturnFree.DataPropertyName = "ReturnFree";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            this.ReturnFree.DefaultCellStyle = dataGridViewCellStyle10;
            this.ReturnFree.HeaderText = "คืนเปอร์เซ็น";
            this.ReturnFree.Name = "ReturnFree";
            this.ReturnFree.ReadOnly = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(697, 28);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(170, 20);
            this.txtName.TabIndex = 1;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // txtCredit
            // 
            this.txtCredit.Location = new System.Drawing.Point(822, 67);
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.Size = new System.Drawing.Size(124, 20);
            this.txtCredit.TabIndex = 2;
            // 
            // txtPay
            // 
            this.txtPay.Location = new System.Drawing.Point(697, 67);
            this.txtPay.Name = "txtPay";
            this.txtPay.Size = new System.Drawing.Size(55, 20);
            this.txtPay.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(703, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 13);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "ชื่อลูกค้า";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(819, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "วงเงินเครดิต";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "เงินคงเหลือ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(703, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "อัตราจ่าย";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(758, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "คืน %";
            // 
            // txtFee
            // 
            this.txtFee.Location = new System.Drawing.Point(761, 67);
            this.txtFee.Name = "txtFee";
            this.txtFee.Size = new System.Drawing.Size(55, 20);
            this.txtFee.TabIndex = 10;
            // 
            // lblBalance
            // 
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblBalance.ForeColor = System.Drawing.Color.Red;
            this.lblBalance.Location = new System.Drawing.Point(6, 29);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBalance.Size = new System.Drawing.Size(104, 23);
            this.lblBalance.TabIndex = 11;
            this.lblBalance.Text = "0";
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Deposit
            // 
            this.Deposit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Deposit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Deposit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Deposit.Location = new System.Drawing.Point(17, 45);
            this.Deposit.Name = "Deposit";
            this.Deposit.Size = new System.Drawing.Size(213, 31);
            this.Deposit.TabIndex = 12;
            this.Deposit.Text = "ฝาก";
            this.Deposit.UseVisualStyleBackColor = false;
            this.Deposit.Click += new System.EventHandler(this.Deposit_Click);
            // 
            // withdraw
            // 
            this.withdraw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.withdraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.withdraw.Location = new System.Drawing.Point(17, 55);
            this.withdraw.Name = "withdraw";
            this.withdraw.Size = new System.Drawing.Size(213, 35);
            this.withdraw.TabIndex = 13;
            this.withdraw.Text = "ถอน";
            this.withdraw.UseVisualStyleBackColor = false;
            this.withdraw.Click += new System.EventHandler(this.withdraw_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(875, 28);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "บันทึกแก้ไข";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblwithdraw
            // 
            this.lblwithdraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblwithdraw.ForeColor = System.Drawing.Color.Red;
            this.lblwithdraw.Location = new System.Drawing.Point(130, 29);
            this.lblwithdraw.Name = "lblwithdraw";
            this.lblwithdraw.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblwithdraw.Size = new System.Drawing.Size(104, 23);
            this.lblwithdraw.TabIndex = 15;
            this.lblwithdraw.Text = "0";
            this.lblwithdraw.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(193, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "ถอนได้";
            // 
            // txtDeposit
            // 
            this.txtDeposit.Location = new System.Drawing.Point(120, 19);
            this.txtDeposit.Name = "txtDeposit";
            this.txtDeposit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDeposit.Size = new System.Drawing.Size(110, 20);
            this.txtDeposit.TabIndex = 17;
            this.txtDeposit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDeposit_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnWithdrawAll);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblBalance);
            this.groupBox1.Controls.Add(this.lblwithdraw);
            this.groupBox1.Controls.Add(this.withdraw);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(697, 199);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 152);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ถอน";
            // 
            // btnWithdrawAll
            // 
            this.btnWithdrawAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnWithdrawAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnWithdrawAll.Location = new System.Drawing.Point(17, 96);
            this.btnWithdrawAll.Name = "btnWithdrawAll";
            this.btnWithdrawAll.Size = new System.Drawing.Size(213, 35);
            this.btnWithdrawAll.TabIndex = 17;
            this.btnWithdrawAll.Text = "ล้างบัญชี";
            this.btnWithdrawAll.UseVisualStyleBackColor = false;
            this.btnWithdrawAll.Click += new System.EventHandler(this.btnWithdrawAll_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtDeposit);
            this.groupBox2.Controls.Add(this.Deposit);
            this.groupBox2.Location = new System.Drawing.Point(697, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(249, 100);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ฝาก";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "จำนวนฝาก";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 531);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtFee);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtPay);
            this.Controls.Add(this.txtCredit);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.dgv);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Customer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Customer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCredit;
        private System.Windows.Forms.TextBox txtPay;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFee;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Button Deposit;
        private System.Windows.Forms.Button withdraw;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblwithdraw;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDeposit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pay;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReturnFree;
        private System.Windows.Forms.Button btnWithdrawAll;
    }
}