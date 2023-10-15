namespace AutoSearch
{
    partial class AutoSearch
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAlibaba = new System.Windows.Forms.CheckBox();
            this.chkYahoo = new System.Windows.Forms.CheckBox();
            this.chkBaidu = new System.Windows.Forms.CheckBox();
            this.chkGoogle = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtKeyword3 = new System.Windows.Forms.TextBox();
            this.txtKeyword2 = new System.Windows.Forms.TextBox();
            this.txtKeyword1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtClick3 = new System.Windows.Forms.TextBox();
            this.txtClick2 = new System.Windows.Forms.TextBox();
            this.txtClick1 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtTimer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.timerSearch = new System.Windows.Forms.Timer(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkproxy = new System.Windows.Forms.CheckBox();
            this.txtproxy = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAlibaba);
            this.groupBox1.Controls.Add(this.chkYahoo);
            this.groupBox1.Controls.Add(this.chkBaidu);
            this.groupBox1.Controls.Add(this.chkGoogle);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 133);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Engine/搜索引擎";
            // 
            // chkAlibaba
            // 
            this.chkAlibaba.AutoSize = true;
            this.chkAlibaba.Location = new System.Drawing.Point(26, 94);
            this.chkAlibaba.Name = "chkAlibaba";
            this.chkAlibaba.Size = new System.Drawing.Size(61, 17);
            this.chkAlibaba.TabIndex = 3;
            this.chkAlibaba.Text = "Alibaba";
            this.chkAlibaba.UseVisualStyleBackColor = true;
            // 
            // chkYahoo
            // 
            this.chkYahoo.AutoSize = true;
            this.chkYahoo.Location = new System.Drawing.Point(26, 69);
            this.chkYahoo.Name = "chkYahoo";
            this.chkYahoo.Size = new System.Drawing.Size(57, 17);
            this.chkYahoo.TabIndex = 2;
            this.chkYahoo.Text = "Yahoo";
            this.chkYahoo.UseVisualStyleBackColor = true;
            // 
            // chkBaidu
            // 
            this.chkBaidu.AutoSize = true;
            this.chkBaidu.Location = new System.Drawing.Point(26, 44);
            this.chkBaidu.Name = "chkBaidu";
            this.chkBaidu.Size = new System.Drawing.Size(53, 17);
            this.chkBaidu.TabIndex = 1;
            this.chkBaidu.Text = "Baidu";
            this.chkBaidu.UseVisualStyleBackColor = true;
            // 
            // chkGoogle
            // 
            this.chkGoogle.AutoSize = true;
            this.chkGoogle.Location = new System.Drawing.Point(26, 19);
            this.chkGoogle.Name = "chkGoogle";
            this.chkGoogle.Size = new System.Drawing.Size(60, 17);
            this.chkGoogle.TabIndex = 0;
            this.chkGoogle.Text = "Google";
            this.chkGoogle.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtKeyword3);
            this.groupBox2.Controls.Add(this.txtKeyword2);
            this.groupBox2.Controls.Add(this.txtKeyword1);
            this.groupBox2.Location = new System.Drawing.Point(197, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(174, 132);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Keyword/搜索关键字";
            // 
            // txtKeyword3
            // 
            this.txtKeyword3.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtKeyword3.Location = new System.Drawing.Point(19, 96);
            this.txtKeyword3.Name = "txtKeyword3";
            this.txtKeyword3.Size = new System.Drawing.Size(100, 20);
            this.txtKeyword3.TabIndex = 2;
            // 
            // txtKeyword2
            // 
            this.txtKeyword2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtKeyword2.Location = new System.Drawing.Point(19, 58);
            this.txtKeyword2.Name = "txtKeyword2";
            this.txtKeyword2.Size = new System.Drawing.Size(100, 20);
            this.txtKeyword2.TabIndex = 1;
            // 
            // txtKeyword1
            // 
            this.txtKeyword1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtKeyword1.Location = new System.Drawing.Point(19, 17);
            this.txtKeyword1.Name = "txtKeyword1";
            this.txtKeyword1.Size = new System.Drawing.Size(100, 20);
            this.txtKeyword1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtClick3);
            this.groupBox3.Controls.Add(this.txtClick2);
            this.groupBox3.Controls.Add(this.txtClick1);
            this.groupBox3.Location = new System.Drawing.Point(396, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(184, 132);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Click Keyword/点击关键字";
            // 
            // txtClick3
            // 
            this.txtClick3.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtClick3.Location = new System.Drawing.Point(19, 96);
            this.txtClick3.Name = "txtClick3";
            this.txtClick3.Size = new System.Drawing.Size(142, 20);
            this.txtClick3.TabIndex = 2;
            // 
            // txtClick2
            // 
            this.txtClick2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtClick2.Location = new System.Drawing.Point(19, 58);
            this.txtClick2.Name = "txtClick2";
            this.txtClick2.Size = new System.Drawing.Size(142, 20);
            this.txtClick2.TabIndex = 1;
            // 
            // txtClick1
            // 
            this.txtClick1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtClick1.Location = new System.Drawing.Point(19, 17);
            this.txtClick1.Name = "txtClick1";
            this.txtClick1.Size = new System.Drawing.Size(142, 20);
            this.txtClick1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtTimer);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(13, 165);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(164, 77);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Timer/搜索定时";
            // 
            // txtTimer
            // 
            this.txtTimer.Location = new System.Drawing.Point(6, 38);
            this.txtTimer.Name = "txtTimer";
            this.txtTimer.Size = new System.Drawing.Size(43, 20);
            this.txtTimer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "分钟(1-10000)";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(493, 151);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save/保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(493, 232);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit/退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(493, 193);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(75, 23);
            this.btnLog.TabIndex = 7;
            this.btnLog.Text = "Log/日志";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // timerSearch
            // 
            this.timerSearch.Tick += new System.EventHandler(this.timerSearch_Tick);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(286, 258);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(225, 13);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Copyright © 2009 杭州蓝光计算机有限公司";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtproxy);
            this.groupBox5.Controls.Add(this.chkproxy);
            this.groupBox5.Location = new System.Drawing.Point(197, 165);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(174, 77);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Proxy/代理服务器";
            // 
            // chkproxy
            // 
            this.chkproxy.AutoSize = true;
            this.chkproxy.Location = new System.Drawing.Point(19, 38);
            this.chkproxy.Name = "chkproxy";
            this.chkproxy.Size = new System.Drawing.Size(15, 14);
            this.chkproxy.TabIndex = 0;
            this.chkproxy.UseVisualStyleBackColor = true;
            // 
            // txtproxy
            // 
            this.txtproxy.Location = new System.Drawing.Point(53, 38);
            this.txtproxy.Name = "txtproxy";
            this.txtproxy.Size = new System.Drawing.Size(100, 20);
            this.txtproxy.TabIndex = 1;
            // 
            // AutoSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 280);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AutoSearch";
            this.Text = "AutoSearch/自动搜索";
            this.Load += new System.EventHandler(this.AutoSearch_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkBaidu;
        private System.Windows.Forms.CheckBox chkGoogle;
        private System.Windows.Forms.CheckBox chkYahoo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtKeyword3;
        private System.Windows.Forms.TextBox txtKeyword2;
        private System.Windows.Forms.TextBox txtKeyword1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtClick3;
        private System.Windows.Forms.TextBox txtClick2;
        private System.Windows.Forms.TextBox txtClick1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Timer timerSearch;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox chkAlibaba;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtproxy;
        private System.Windows.Forms.CheckBox chkproxy;
    }
}

