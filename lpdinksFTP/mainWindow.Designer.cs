namespace lpdinksFTP
{
    partial class mainWindow
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.upload = new System.Windows.Forms.Button();
            this.download = new System.Windows.Forms.Button();
            this.ip = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.signin = new System.Windows.Forms.Button();
            this.signout = new System.Windows.Forms.Button();
            this.changeType = new System.Windows.Forms.Button();
            this.log = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // upload
            // 
            this.upload.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.upload.Location = new System.Drawing.Point(226, 79);
            this.upload.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.upload.Name = "upload";
            this.upload.Size = new System.Drawing.Size(84, 53);
            this.upload.TabIndex = 2;
            this.upload.Text = "上传";
            this.upload.UseVisualStyleBackColor = true;
            this.upload.Click += new System.EventHandler(this.upload_Click);
            // 
            // download
            // 
            this.download.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.download.Location = new System.Drawing.Point(370, 79);
            this.download.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.download.Name = "download";
            this.download.Size = new System.Drawing.Size(84, 53);
            this.download.TabIndex = 3;
            this.download.Text = "下载";
            this.download.UseVisualStyleBackColor = true;
            this.download.Click += new System.EventHandler(this.download_Click);
            // 
            // ip
            // 
            this.ip.Location = new System.Drawing.Point(112, 41);
            this.ip.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(155, 27);
            this.ip.TabIndex = 4;
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(385, 37);
            this.username.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(155, 27);
            this.username.TabIndex = 5;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(645, 37);
            this.password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(155, 27);
            this.password.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(81, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(317, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "用户名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(596, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "密码";
            // 
            // signin
            // 
            this.signin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.signin.Location = new System.Drawing.Point(85, 79);
            this.signin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.signin.Name = "signin";
            this.signin.Size = new System.Drawing.Size(84, 53);
            this.signin.TabIndex = 10;
            this.signin.Text = "登录";
            this.signin.UseVisualStyleBackColor = true;
            this.signin.Click += new System.EventHandler(this.signin_Click);
            // 
            // signout
            // 
            this.signout.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.signout.Location = new System.Drawing.Point(520, 79);
            this.signout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.signout.Name = "signout";
            this.signout.Size = new System.Drawing.Size(84, 53);
            this.signout.TabIndex = 11;
            this.signout.Text = "注销";
            this.signout.UseVisualStyleBackColor = true;
            this.signout.Click += new System.EventHandler(this.signout_Click);
            // 
            // changeType
            // 
            this.changeType.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.changeType.Location = new System.Drawing.Point(664, 79);
            this.changeType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.changeType.Name = "changeType";
            this.changeType.Size = new System.Drawing.Size(105, 53);
            this.changeType.TabIndex = 12;
            this.changeType.Text = "详细信息";
            this.changeType.UseVisualStyleBackColor = true;
            this.changeType.Click += new System.EventHandler(this.changeType_Click);
            // 
            // log
            // 
            this.log.Location = new System.Drawing.Point(459, 140);
            this.log.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.log.Size = new System.Drawing.Size(341, 409);
            this.log.TabIndex = 13;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(85, 140);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(368, 409);
            this.dataGridView1.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(85, 496);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 53);
            this.button1.TabIndex = 15;
            this.button1.Text = "刷新";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(902, 643);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.log);
            this.Controls.Add(this.changeType);
            this.Controls.Add(this.signout);
            this.Controls.Add(this.signin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.ip);
            this.Controls.Add(this.download);
            this.Controls.Add(this.upload);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainWindow";
            this.Text = "LPdinksFTP";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button upload;
        private System.Windows.Forms.Button download;
        private System.Windows.Forms.TextBox ip;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button signin;
        private System.Windows.Forms.Button signout;
        private System.Windows.Forms.Button changeType;
        private System.Windows.Forms.TextBox log;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
    }
}

