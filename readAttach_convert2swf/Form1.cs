using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace readAttach_convert2swf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_readAttach_Click(object sender, EventArgs e)
        {
            string url = ConfigurationManager.AppSettings["url"];
            string attachGuid = textBox_AttachGuid.Text;
            System.Diagnostics.Process.Start(url+attachGuid);
        }

        private void btn_isConver2Swf_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string attachGuid = textBox_AttachGuid.Text.Trim().ToString();
            string sqlcomm = "select isconvertswf from FRAME_ATTACHINFO  where attachguid='" + attachGuid + "' ";
            dt= sqlHelper.ExecuteDt(sqlcomm);
            int rows = dt.Rows.Count;
            lb_rowsFind.Text = rows.ToString();
            string convertState = "";
            for (int i = 0; i < rows; i++)
            {
                convertState += dt.Rows[i][0].ToString();
            }
            lb_isConvert2Swf.Text = convertState;
        }

        private void btn_setNoConvert_Click(object sender, EventArgs e)
        {
            string attachguid=textBox_AttachGuid.Text;
            string comm = "begin update Frame_AttachInfo set isconvertswf ='-9' where attachguid ='" + attachguid + "'; commit; end;";
            sqlHelper.ExecuteSql(comm);
            
        }
    }
}
