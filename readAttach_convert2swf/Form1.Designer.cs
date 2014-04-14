namespace readAttach_convert2swf
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox_AttachGuid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_readAttach = new System.Windows.Forms.Button();
            this.lb_isConvert2Swf = new System.Windows.Forms.Label();
            this.btn_isConver2Swf = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_rowsFind = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_setNoConvert = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_AttachGuid
            // 
            this.textBox_AttachGuid.Location = new System.Drawing.Point(73, 12);
            this.textBox_AttachGuid.Name = "textBox_AttachGuid";
            this.textBox_AttachGuid.Size = new System.Drawing.Size(329, 21);
            this.textBox_AttachGuid.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "AttachGuid";
            // 
            // btn_readAttach
            // 
            this.btn_readAttach.Location = new System.Drawing.Point(434, 10);
            this.btn_readAttach.Name = "btn_readAttach";
            this.btn_readAttach.Size = new System.Drawing.Size(94, 23);
            this.btn_readAttach.TabIndex = 2;
            this.btn_readAttach.Text = "读取对应附件";
            this.btn_readAttach.UseVisualStyleBackColor = true;
            this.btn_readAttach.Click += new System.EventHandler(this.btn_readAttach_Click);
            // 
            // lb_isConvert2Swf
            // 
            this.lb_isConvert2Swf.AutoSize = true;
            this.lb_isConvert2Swf.Location = new System.Drawing.Point(157, 50);
            this.lb_isConvert2Swf.Name = "lb_isConvert2Swf";
            this.lb_isConvert2Swf.Size = new System.Drawing.Size(41, 12);
            this.lb_isConvert2Swf.TabIndex = 4;
            this.lb_isConvert2Swf.Text = "未读取";
            // 
            // btn_isConver2Swf
            // 
            this.btn_isConver2Swf.Location = new System.Drawing.Point(434, 37);
            this.btn_isConver2Swf.Name = "btn_isConver2Swf";
            this.btn_isConver2Swf.Size = new System.Drawing.Size(94, 23);
            this.btn_isConver2Swf.TabIndex = 5;
            this.btn_isConver2Swf.Text = "转换状态读取";
            this.btn_isConver2Swf.UseVisualStyleBackColor = true;
            this.btn_isConver2Swf.Click += new System.EventHandler(this.btn_isConver2Swf_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "找到";
            // 
            // lb_rowsFind
            // 
            this.lb_rowsFind.AutoSize = true;
            this.lb_rowsFind.Location = new System.Drawing.Point(37, 49);
            this.lb_rowsFind.Name = "lb_rowsFind";
            this.lb_rowsFind.Size = new System.Drawing.Size(11, 12);
            this.lb_rowsFind.TabIndex = 8;
            this.lb_rowsFind.Text = "?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "行数据,分别为：";
            // 
            // btn_setNoConvert
            // 
            this.btn_setNoConvert.Location = new System.Drawing.Point(434, 64);
            this.btn_setNoConvert.Name = "btn_setNoConvert";
            this.btn_setNoConvert.Size = new System.Drawing.Size(94, 23);
            this.btn_setNoConvert.TabIndex = 6;
            this.btn_setNoConvert.Text = "设置不转";
            this.btn_setNoConvert.UseVisualStyleBackColor = true;
            this.btn_setNoConvert.Click += new System.EventHandler(this.btn_setNoConvert_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(479, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "by.邱士川";
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(4, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(424, 29);
            this.label5.TabIndex = 11;
            this.label5.Text = "说明:查询FrameAttachInfo表，根据Attachguid查询对应数据的IsconvertSWF字段，-9为不转换，1为转换成功，此字段可为空";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(540, 105);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_rowsFind);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_setNoConvert);
            this.Controls.Add(this.btn_isConver2Swf);
            this.Controls.Add(this.lb_isConvert2Swf);
            this.Controls.Add(this.btn_readAttach);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_AttachGuid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "新点FrameAttachInfo_PDF转换调整<isconvertswf字段>";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_AttachGuid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_readAttach;
        private System.Windows.Forms.Label lb_isConvert2Swf;
        private System.Windows.Forms.Button btn_isConver2Swf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_rowsFind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_setNoConvert;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

