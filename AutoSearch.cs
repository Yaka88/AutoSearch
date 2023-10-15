using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Web;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace AutoSearch
{
    public partial class AutoSearch : Form
    {

        public static string strConn = "Provider=Microsoft.JET.OLEDB.4.0;Jet OLEDB:Database Password=autosearch;Data Source=AutoSearch.ydb";
        private string strGoogle;
        private string strBaidu;
        private string strYahoo;
        private string strAlibaba;
        private string strGoogleLinkKey;
        private string strBaiduLinkKey;
        private string strYahooLinkKey;
        private string strAlibabaLinkKey;
        private DateTime Deadline;
        private WebProxy proxy;
        public AutoSearch()
        {
            InitializeComponent();
        }
        private int getRealTime()
        {
            DateTime official;			// official time from timeserver, localtime version
            string returndata = null;			// bytes returned from timeserver
            string[] dates = new string[4];			// year, month, day
            string[] times = new string[4];			// hour, minute, second
            string[] tokens = new string[11];		// bytes tokenized

            TcpClient tcpclient = new TcpClient();		// create new socket object

            try
            {
                tcpclient.Connect("time.nist.gov", 13);	// try to connect to timeserver

                NetworkStream networkStream = tcpclient.GetStream();
                // socket stream

                if (networkStream.CanWrite && networkStream.CanRead)
                // stream is ready
                {
                    Byte[] sendBytes = Encoding.ASCII.GetBytes("Hello");
                    // the hello string, Can be anything!
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                    // send to timeserver

                    byte[] bytes = new byte[tcpclient.ReceiveBufferSize];
                    networkStream.Read(bytes, 0, (int)tcpclient.ReceiveBufferSize);
                    // the official timeserver data  
                    returndata = Encoding.ASCII.GetString(bytes);
                    // cast as ASCII string
                }

                tcpclient.Close();			// close socket
            }
            catch (Exception)
            {
                MessageBox.Show("网络错误,请确认网络可用!");	// display exception to user
                return 2;					// if exception occurred don't continue
            }

            tokens = returndata.Split(' ');			// the timeserver data space parsed
            dates = tokens[1].Split('-');			// the date info hypen parsed
            times = tokens[2].Split(':');			// the time info colon parsed

            official = new DateTime(Int32.Parse(dates[0]) + 2000, Int32.Parse(dates[1]), Int32.Parse(dates[2]),
                        Int32.Parse(times[0]), Int32.Parse(times[1]), Int32.Parse(times[2]));
            // create a new datetime object with these values

            if (official >= Deadline)
                return 0;
            else
                return 1;

        }
        private bool CheckSerailNo(string strSerialNo)
        {
            string strUniq = "";
 
            NetworkInterface[] ni = NetworkInterface.GetAllNetworkInterfaces();
            for (int i = 0; i < ni.Length ; i++) 
            {
                if (ni[i].NetworkInterfaceType == NetworkInterfaceType.Ethernet || ni[i].NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {
                    strUniq = ni[i].GetPhysicalAddress().ToString();
                    break;
                }

            }                
             //  strHDInfo = "01A4B6CA46";
            strUniq = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strUniq, "MD5");

            if (strSerialNo == strUniq)
            {
                 return true;
            }
            else
            {
              /*  int intret = getRealTime();
                if (intret == 1)
                    return true;
                else if (intret == 0)*/
                {
                    MessageBox.Show("本机器码是" + strUniq + ",请联系蓝光计算机获取序列号!", linkLabel1.Text);
                    return false;
                }
                //else return false;
            }            
        }       
        private void AutoSearch_Load(object sender, EventArgs e)
        {                     
            try
            {                
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();

                OleDbCommand command = new OleDbCommand("SELECT * FROM Info", conn);
                OleDbDataReader reader = command.ExecuteReader();
       
                if (reader.Read())
                {
                    txtTimer.Text = reader["Timer"].ToString();
                    Deadline = (DateTime)reader["TestDate"];
                    chkproxy.Checked  = (bool)reader["UseProxy"];
                    txtproxy.Text = reader["Proxy"].ToString();
                    try
                    {                                                
                        proxy = new WebProxy(txtproxy.Text);
                    }
                    catch (UriFormatException)
                    {                        
                    }
                    string strSerialNo = reader["SerialNo"].ToString();
                    if (!CheckSerailNo(strSerialNo))
                    {
                        reader.Close();
                        conn.Close();
                        this.Close();
                        return;
                    }
                }
                reader.Close();

                command.CommandText = "SELECT * FROM Engine ORDER BY Engine";
                reader = command.ExecuteReader();
                reader.Read();
                chkAlibaba.Checked = (bool)reader["Used"];
                strAlibaba = reader["SearchString"].ToString();
                strAlibabaLinkKey = reader["LinkKey"].ToString();
                reader.Read();
                chkBaidu.Checked = (bool)reader["Used"];
                strBaidu = reader["SearchString"].ToString();
                strBaiduLinkKey = reader["LinkKey"].ToString();
                reader.Read();
                chkGoogle.Checked = (bool)reader["Used"];
                strGoogle = reader["SearchString"].ToString();
                strGoogleLinkKey = reader["LinkKey"].ToString();
                reader.Read();
                chkYahoo.Checked = (bool)reader["Used"];
                strYahoo = reader["SearchString"].ToString();
                strYahooLinkKey = reader["LinkKey"].ToString();
                
                
                reader.Close();

               

                command.CommandText = "SELECT * FROM Keyword ";
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    txtClick1.Text = reader["Click1"].ToString();
                    txtClick2.Text = reader["Click2"].ToString();
                    txtClick3.Text = reader["Click3"].ToString();
                    txtKeyword1.Text = reader["Keyword1"].ToString();
                    txtKeyword2.Text = reader["Keyword2"].ToString();
                    txtKeyword3.Text = reader["Keyword3"].ToString();
                }
                reader.Close();
                conn.Close();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
                CheckSerailNo("");
                this.Close();
                return;
            }
            timerSearch.Interval = int.Parse(txtTimer.Text) * 60000 ;
            timerSearch.Start();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();

                StringBuilder strb = new StringBuilder("Update Info SET Timer=");
                strb.Append(int.Parse(txtTimer.Text.Trim()));
                strb.Append(",Proxy='");
                strb.Append(txtproxy.Text.Trim());
                strb.Append("',UseProxy=");
                strb.Append(chkproxy.Checked);
                OleDbCommand command = new OleDbCommand(strb.ToString(), conn);
                int intLow = command.ExecuteNonQuery();
                command.CommandText = "Update Engine SET Used = " + chkBaidu.Checked + " WHERE Engine = 'Baidu'";
                intLow = command.ExecuteNonQuery();
                command.CommandText = "Update Engine SET Used = " + chkGoogle.Checked + " WHERE Engine = 'Google'";
                intLow = command.ExecuteNonQuery();
                command.CommandText = "Update Engine SET Used = " + chkYahoo.Checked + " WHERE Engine = 'Yahoo'";
                intLow = command.ExecuteNonQuery();
                command.CommandText = "Update Engine SET Used = " + chkAlibaba.Checked + " WHERE Engine = 'Alibaba'";
                intLow = command.ExecuteNonQuery();      
                StringBuilder str = new StringBuilder("Update Keyword SET Click1 = '");
                str.Append(txtClick1.Text.Trim());
                str.Append("',Click2 = '");
                str.Append(txtClick2.Text.Trim());
                str.Append("',Click3 = '");
                str.Append(txtClick3.Text.Trim());
                str.Append("',Keyword1 = '");
                str.Append(txtKeyword1.Text.Trim());                
                str.Append("',Keyword2 = '");
                str.Append(txtKeyword2.Text.Trim());
                str.Append("',Keyword3 = '");
                str.Append(txtKeyword3.Text.Trim());
                str.Append("'");

                command.CommandText = str.ToString();
                intLow = command.ExecuteNonQuery();               
                conn.Close();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                proxy = new WebProxy(txtproxy.Text.Trim());
            }
            catch (UriFormatException) { }
            timerSearch.Stop();
            timerSearch.Interval = int.Parse(txtTimer.Text) * 60000;
            timerSearch.Start();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            timerSearch.Stop();
            Application.Exit();
        }
        private static string ToHex(string str, string charset)
        {            
            System.Text.Encoding chs = System.Text.Encoding.GetEncoding(charset);

            byte[] bytes = chs.GetBytes(str);

            str = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                str += string.Format("%{0:X}", bytes[i]);                
            }
            return str;
        }
        private bool ClickKeyword(string strtable, string strClick,string strEngine)
        {
            if (strtable.IndexOf(strClick) != -1)
            {                
                int intlinkEnd;
                if (strEngine == "A")
                    intlinkEnd = strtable.IndexOf("'");
                else
                    intlinkEnd = strtable.IndexOf("\"");

                string strlink = HttpUtility.HtmlDecode(strtable.Substring(0, intlinkEnd));
                if (strEngine == "G")
                    strlink = "http://www.google.cn" + strlink;
                string strRealURL;
                try
                {
                    HttpWebRequest LoginReq = (HttpWebRequest)WebRequest.Create(strlink);
                    if (chkproxy.Enabled)
                        LoginReq.Proxy = proxy;
                    HttpWebResponse LoginRes = (HttpWebResponse)LoginReq.GetResponse();
                    strRealURL = LoginReq.Address.AbsoluteUri;                    
                    LoginRes.Close();
                }
                catch (WebException)
                {
                    strRealURL = "";
                }               
                try
                {
                    OleDbConnection conn = new OleDbConnection(strConn);
                    conn.Open();
                    StringBuilder str = new StringBuilder("INSERT INTO Logs(SearchLink,RealLink,Keyword,SearchTime) VALUES ('");
                    str.Append(strlink.Replace("'",""));
                    str.Append("','");                    
                    str.Append(strRealURL);
                    str.Append("','");
                    str.Append(strClick);
                    str.Append("','");
                    str.Append(DateTime.Now.ToString());
                    str.Append("')");
                    OleDbCommand command = new OleDbCommand(str.ToString(), conn);
                    int intLow = command.ExecuteNonQuery();
                    conn.Close();
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                return true;
            }
            else 
                return false;
        }
        private string GetPage(string strURLHTTP,Encoding encode)
        {
    
            string strRes;
            try
            {
                HttpWebRequest LoginReq = (HttpWebRequest)WebRequest.Create(strURLHTTP);
         //       LoginReq.Proxy = proxy;
                HttpWebResponse LoginRes = (HttpWebResponse)LoginReq.GetResponse();
                Stream receiveStream = LoginRes.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, encode);
                strRes = readStream.ReadToEnd();
                readStream.Close();
                LoginRes.Close();
            }
            catch (WebException)
            {
                strRes = "";
            }
            return strRes;
        }
        private void SearchBaidu(string strKeyword)
        {     
            string strClick1 = txtClick1.Text.Trim().Replace(strKeyword, "");
            string strClick2 = txtClick2.Text.Trim().Replace(strKeyword, "");
            string strClick3 = txtClick3.Text.Trim().Replace(strKeyword, "");

            Encoding encode = Encoding.GetEncoding("gb2312");

         //   string strURLHTTP = strBaidu + ToHex(strKeyword, "gb2312");

            string strURLHTTP = strBaidu + HttpUtility.UrlEncode(strKeyword, encode);        
            string strRes = GetPage(strURLHTTP, encode);
            if (strRes.Length == 0) return;            
            int intStart = 0;
            int intlinkStart;
            int intCenterKey = strRes.IndexOf("ScriptDiv");
            while ((intlinkStart = strRes.IndexOf(strBaiduLinkKey, intStart)) != -1)
            {
                bool ignore = false;
                int intEnd;
                if (intlinkStart > intCenterKey)
                    intEnd = strRes.IndexOf("</table>", intlinkStart);
                else
                    intEnd = strRes.IndexOf("</div>", intlinkStart);

                string strtable = strRes.Substring(intlinkStart, intEnd - intlinkStart);
                intStart = intEnd + 6;
                if (strClick1.Length != 0)
                {
                    ignore = ClickKeyword(strtable, strClick1, "B");
                    if (ignore)
                        strClick1 = "";
                }
                if (strClick2.Length != 0 && !ignore)
                {
                    ignore = ClickKeyword(strtable, strClick2, "B");
                    if (ignore)
                        strClick2 = "";
                }
                if (strClick3.Length != 0 && !ignore)
                {
                    ignore = ClickKeyword(strtable, strClick3, "B");
                    if (ignore)
                        strClick3 = "";
                }
            }                            

        }
        private void SearchYahoo(string strKeyword)
        {         
            string strClick1 = txtClick1.Text.Trim().Replace(strKeyword, "");
            string strClick2 = txtClick2.Text.Trim().Replace(strKeyword, "");
            string strClick3 = txtClick3.Text.Trim().Replace(strKeyword, "");

            Encoding encode = Encoding.GetEncoding("UTF-8");
            string strURLHTTP = strYahoo + Uri.EscapeDataString(strKeyword);
            string strRes = GetPage(strURLHTTP, encode);
            if (strRes.Length == 0) return;

            int intStart = 0;
            int intlinkStart;
            while ((intlinkStart = strRes.IndexOf(strYahooLinkKey, intStart)) != -1)
            {
                bool ignore = false;
                int intEnd = strRes.IndexOf("</li>", intlinkStart);
                string strtable = strRes.Substring(intlinkStart, intEnd - intlinkStart);
                intStart = intEnd + 5;

                if (strClick1.Length != 0)
                {
                    ignore = ClickKeyword(strtable, strClick1, "Y");
                    if (ignore)
                        strClick1 = "";
                }
                if (strClick2.Length != 0 && !ignore)
                {
                    ignore = ClickKeyword(strtable, strClick2, "Y");
                    if (ignore)
                        strClick2 = "";
                }
                if (strClick3.Length != 0 && !ignore)
                {
                    ignore = ClickKeyword(strtable, strClick3, "Y");
                    if (ignore)
                        strClick3 = "";
                }
            }
                
        }
        private void SearchGoogle(string strKeyword)
        {
            string strClick1 = txtClick1.Text.Trim().Replace(strKeyword, "");
            string strClick2 = txtClick2.Text.Trim().Replace(strKeyword, "");
            string strClick3 = txtClick3.Text.Trim().Replace(strKeyword, "");

            Encoding encode = Encoding.GetEncoding("gb2312");
            string strURLHTTP = strGoogle  + Uri.EscapeDataString(strKeyword);
            string strRes = GetPage(strURLHTTP, encode);
            if (strRes.Length == 0) return;

            int intStart = 0;
            int intlinkStart;
            while ((intlinkStart = strRes.IndexOf(strGoogleLinkKey, intStart)) != -1)
            {
                bool ignore = false;

                int intEnd = strRes.IndexOf("</cite>", intlinkStart);
                string strtable = strRes.Substring(intlinkStart, intEnd - intlinkStart);
                intStart = intEnd + 7;

                if (strClick1.Length != 0)
                {
                    ignore = ClickKeyword(strtable, strClick1, "G");
                    if (ignore)
                        strClick1 = "";
                }
                if (strClick2.Length != 0 && !ignore)
                {
                    ignore = ClickKeyword(strtable, strClick2, "G");
                    if (ignore)
                        strClick2 = "";
                }
                if (strClick3.Length != 0 && !ignore)
                {
                    ignore = ClickKeyword(strtable, strClick3, "G");
                    if (ignore)
                        strClick3 = "";
                }
            }            
        }
        private void SearchAlibaba(string strKeyword)
        {     
            string strClick1 = txtClick1.Text.Trim().Replace(strKeyword, "");
            string strClick2 = txtClick2.Text.Trim().Replace(strKeyword, "");
            string strClick3 = txtClick3.Text.Trim().Replace(strKeyword, "");

            Encoding encode = Encoding.GetEncoding("gb2312");
            string strURLHTTP = strAlibaba + HttpUtility.UrlEncode(strKeyword, encode);      
            string strRes = GetPage(strURLHTTP, encode);
            if (strRes.Length == 0) return;

            int intStart = 0;
            int intlinkStart;
            while ((intlinkStart = strRes.IndexOf(strAlibabaLinkKey, intStart)) != -1)
            {
                bool ignore = false;

                int intEnd = strRes.IndexOf("hackbox", intlinkStart);
                string strtable = strRes.Substring(intlinkStart, intEnd - intlinkStart);
                intStart = intEnd + 7;

                if (strClick1.Length != 0)
                {
                    ignore = ClickKeyword(strtable, strClick1, "A");
                    if (ignore)
                        strClick1 = "";
                }
                if (strClick2.Length != 0 && !ignore)
                {
                    ignore = ClickKeyword(strtable, strClick2, "A");
                    if (ignore)
                        strClick2 = "";
                }
                if (strClick3.Length != 0 && !ignore)
                {
                    ignore = ClickKeyword(strtable, strClick3, "A");
                    if (ignore)
                        strClick3 = "";
                }
            }
        }
        private void timerSearch_Tick(object sender, EventArgs e)
        {
            if (chkBaidu.Checked)
            {
                if (txtKeyword1.Text.Trim().Length != 0)
                    SearchBaidu(txtKeyword1.Text.Trim());
                if (txtKeyword2.Text.Trim().Length != 0)
                    SearchBaidu(txtKeyword2.Text.Trim());
                if (txtKeyword3.Text.Trim().Length != 0)
                    SearchBaidu(txtKeyword3.Text.Trim());
            }
            if (chkGoogle.Checked)
            {
                if (txtKeyword1.Text.Trim().Length != 0)
                    SearchGoogle(txtKeyword1.Text.Trim());
                if (txtKeyword2.Text.Trim().Length != 0)
                    SearchGoogle(txtKeyword2.Text.Trim());
                if (txtKeyword3.Text.Trim().Length != 0)
                    SearchGoogle(txtKeyword3.Text.Trim());
            }
            if (chkYahoo.Checked)
            {
                if (txtKeyword1.Text.Trim().Length != 0)
                    SearchYahoo(txtKeyword1.Text.Trim());
                if (txtKeyword2.Text.Trim().Length != 0)
                    SearchYahoo(txtKeyword2.Text.Trim());
                if (txtKeyword3.Text.Trim().Length != 0)
                    SearchYahoo(txtKeyword3.Text.Trim());
            }
            if (chkAlibaba.Checked)
            {
                if (txtKeyword1.Text.Trim().Length != 0)
                    SearchAlibaba(txtKeyword1.Text.Trim());
                if (txtKeyword2.Text.Trim().Length != 0)
                    SearchAlibaba(txtKeyword2.Text.Trim());
                if (txtKeyword3.Text.Trim().Length != 0)
                    SearchAlibaba(txtKeyword3.Text.Trim());
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            LogView logform = new LogView();
            logform.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", "http://www.bluelaser.cn");
        }
    }
}
