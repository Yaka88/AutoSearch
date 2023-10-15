using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoSearch
{
    public partial class LogView : Form
    {
        public LogView()
        {
            InitializeComponent();
        }

        private void LogView_Load(object sender, EventArgs e)
        {
            FillLogData(); 
        }
        private void FillLogData()
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Logs Order BY SearchTime DESC", AutoSearch.strConn);
            DataTable dt = new DataTable();
            adapter.Fill(0, 80, dt);
            dataViewLog.DataSource = dt;
            dataViewLog.Columns[0].Width = 300;
            dataViewLog.Columns[1].Width = 200;
            dataViewLog.Columns[2].Width = 130;
            dataViewLog.Columns[3].Width = 100;    
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection conn = new OleDbConnection(AutoSearch.strConn);
                conn.Open();
                OleDbCommand command = new OleDbCommand("DELETE FROM Logs", conn);
                int intLow = command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("成功删除" + intLow + "条记录!");
                FillLogData();
                
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillLogData();
        }          
    }
}

