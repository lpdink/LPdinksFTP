using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lpdinksFTP
{
    public partial class mainWindow : Form
    {
        public Ftp ftp = new Ftp();

        public int logType = 0;//0表示人工信息，1表示服务器信息。
        public bool signIn = false;
        public mainWindow()
        {
            
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            ip.Text = "192.168.191.1";
            username.Text = "lpdink";
            password.PasswordChar ='*';
            
        }

        private void signin_Click(object sender, EventArgs e)
        {
            try
            {
                log.Text += "尝试登录...\r\n";
                string dialog = ftp.signIn(ip.Text, username.Text, password.Text);
                if(logType==1)log.Text += dialog;
                log.Text += "登录成功...\r\n";
                signIn = true;
            
            List<DataBinding> fileList = new List<DataBinding>();
            fileList = ftp.getFileList(ip.Text);
            BindingList<DataBinding> Blist=new BindingList<DataBinding>(fileList);
            dataGridView1.DataSource = Blist;
            
            }
            catch
            {
            MessageBox.Show("登录失败，请检查输入信息");
             }
        }

        private void signout_Click(object sender, EventArgs e)
        {
            try
            {
                log.Text += "尝试登出...\r\n";
                string dialog = ftp.signOut();
                if(logType==1)log.Text += dialog;
                log.Text += "登出成功...\r\n";
                signIn = false;
            }
            catch
            {
                MessageBox.Show("登出失败，请勿重复登出");
            }
        }

        private void download_Click(object sender, EventArgs e)
        {
            if (!signIn) { MessageBox.Show("请先登录");return; }
            //try
            //{
                log.Text += "开始下载...\r\n";
                string dialog = ftp.downLoad(ip.Text,Convert.ToString(dataGridView1.CurrentCell.Value).Replace("\r",""));
                if(logType==1)log.Text += dialog;
                
            //}
            //catch
            //{
                //MessageBox.Show("下载出现异常，请检查登录状态");
            //}
        }

        private void changeType_Click(object sender, EventArgs e)
        {
            if (logType == 0) { logType = 1; log.Text += "切换显示server信息\n";changeType.Text = "简略信息"; }
            else { logType = 0;log.Text += "切换显示简略信息\n"; changeType.Text = "详细信息"; }
        }

        private void upload_Click(object sender, EventArgs e)
        {
            if (!signIn) { MessageBox.Show("请先登录"); return; }
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
            }
            try
            {
                log.Text += "开始上传...\r\n";
                string dialog = ftp.upLoad(ip.Text, filePath);
                if (logType == 1) log.Text += dialog;
            }
            catch
            {
                MessageBox.Show("上传出现异常，请检查登录状态");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<DataBinding> fileList = new List<DataBinding>();
            fileList = ftp.getFileList(ip.Text);
            BindingList<DataBinding> Blist = new BindingList<DataBinding>(fileList);
            dataGridView1.DataSource = Blist;
        }

        //private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        //{

        //}
    }
}
