using BusinessObjects.Repositorys;
using BusinessObjects.Supports;
using log4net;
using OperatorGateway.Supports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OperatorGateway
{
    public partial class OperatorGateway : Form
    {
        private readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string pathLogSession = String.Format("{0}Logs\\log-session.txt", AppDomain.CurrentDomain.BaseDirectory);
        private bool IsStop = false;
        private int COUNT_RETRY = 0;
        private CancellationTokenSource cancelToken;

        public OperatorGateway()
        {
            InitializeComponent();
        }

        private void OperatorGateway_Load(object sender, EventArgs e)
        {
            cbbStartType.DropDownStyle = ComboBoxStyle.DropDownList;
            txtUrlData.Text = "http://vntelecom.vnta.gov.vn:10246/vnta/file/download?id=";

            if (File.Exists(pathLogSession))
            {
                string[] lines = File.ReadAllLines(pathLogSession);
                if (lines.Length >= 3)
                {
                    txtJSESSIONID.Text = lines[0];
                    txtTS0165a601.Text = lines[1];
                    txtTS017dff08.Text = lines[2];
                    txtStartFile.Text = (lines.Length == 4) ? lines[3] : "0";
                    txtEndFile.Text = (Convert.ToInt32(txtStartFile.Text) + Convert.ToInt32(txtRange.Text)).ToString();
                }
            }

            tabControlMain.SelectedTab = tabMonitorService;
            BuidDataGridviewService();
        }

        private void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedIndex == 1)
            {
                RefreshForm();
                BuidDataGridviewService();
            }
        }

        private void BtnServiceStart_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceController sc = new ServiceController(txtServiceName.Text);
                sc.Start();
                sc.WaitForStatus(ServiceControllerStatus.Running);
                RefreshButtonGUI();
                BuidDataGridviewService();
            }
            catch (Exception ex)
            {
                logger.Error("BtnServiceStart_Click", ex);
            }
        }

        private void BtnServiceStop_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceController sc = new ServiceController(txtServiceName.Text);
                sc.Stop();
                sc.WaitForStatus(ServiceControllerStatus.Stopped);
                RefreshButtonGUI();
                BuidDataGridviewService();
            }
            catch (Exception ex)
            {
                logger.Error("BtnServiceStop_Click", ex);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshForm();
            BuidDataGridviewService();
        }

        private void CbbStartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtServiceName.Text))
            {
                using (ManagementObject managerService = new ManagementObject(String.Format("Win32_Service.Name='{0}'", txtServiceName.Text)))
                {
                    if (managerService != null)
                    {
                        ManagementBaseObject inParams = managerService.GetMethodParameters("ChangeStartMode");
                        if (cbbStartType.SelectedIndex == 0)
                        {
                            inParams["StartMode"] = ServiceStartMode.Manual;
                        }
                        else if (cbbStartType.SelectedIndex == 1)
                        {
                            inParams["StartMode"] = ServiceStartMode.Automatic;
                        }
                        else if (cbbStartType.SelectedIndex == 2)
                        {
                            inParams["StartMode"] = ServiceStartMode.Disabled;
                        }
                        else
                        {
                            return;
                        }

                        ManagementBaseObject outParams = managerService.InvokeMethod("ChangeStartMode", inParams, null);
                        BuidDataGridviewService();
                    }
                }
            }
        }

        private void BtnViewLogService_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtServiceName.Text.Equals("Redis"))
                {
                    Process.Start(@"C:\Program Files\Redis\server_log.txt");
                    return;
                }

                using (ManagementObject managerService = new ManagementObject(String.Format("Win32_Service.Name='{0}'", txtServiceName.Text)))
                {
                    if (managerService != null)
                    {
                        managerService.Get();
                        string servicePath = managerService["PathName"].ToString().Replace("\"", "");
                        string directorPath = Path.GetDirectoryName(servicePath);
                        string logPath = String.Format("{0}\\Logs", directorPath);
                        if (!Directory.Exists(logPath))
                            Directory.CreateDirectory(logPath);
                        Process.Start(logPath);
                    }
                    else
                    {
                        MessageBox.Show("Service not exists!", "Thông báo");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("BtnViewLogService_Click", ex);
            }
        }

        private void DgvService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgvService.Rows.Count - 1)
                {
                    DataGridViewRow row = dgvService.Rows[e.RowIndex];
                    txtServiceName.Text = row.Cells["Service Name"].Value.ToString();
                    cbbStartType.Enabled = true;
                    cbbStartType.Text = row.Cells["Start Type"].Value.ToString();
                    RefreshButtonGUI();
                }
            }
            catch (Exception ex)
            {
                logger.Error("DgvService_CellClick", ex);
            }
        }

        private void RefreshForm()
        {
            txtServiceName.ResetText();
            txtServiceDisplay.ResetText();
            txtServiceStatus.ResetText();
            cbbStartType.ResetText();
            cbbStartType.Enabled = false;
        }

        private void BuidDataGridviewService()
        {
            try
            {
                pbLoading.Visible = true;
                dgvService.ReadOnly = true;
                DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("STT");
                dt.Columns.Add("Service Name");
                dt.Columns.Add("Display Name");
                dt.Columns.Add("Path");
                dt.Columns.Add("Start Type");
                dt.Columns.Add("Status");

                foreach (var serviceName in AppConfig.SERVICE_MONITOR.Split(','))
                {
                    ServiceController service = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == serviceName);

                    if (service != null)
                    {
                        string servicePath = String.Empty;
                        using (ManagementObject managerService = new ManagementObject(String.Format("Win32_Service.Name='{0}'", serviceName)))
                        {
                            if (managerService != null)
                            {
                                managerService?.Get();
                                servicePath = managerService?["PathName"].ToString().Replace("\"", "");
                            }
                        }

                        if (service != null)
                        {
                            object[] dataRow = { dt.Rows.Count + 1, service.ServiceName, service.DisplayName, servicePath, service.StartType, service.Status };
                            dt.Rows.Add(dataRow);
                        }
                    }
                }

                dgvService.DataSource = dt;

                foreach (DataGridViewColumn column in dgvService.Columns)
                {
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    column.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                }

                dgvService.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvService.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvService.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvService.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvService.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvService.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvService.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvService.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                foreach (DataGridViewRow row in dgvService.Rows)
                {
                    if (row.Cells[5].Value != null)
                    {
                        if (row.Cells[5].Value.Equals("Running"))
                        {
                            row.Cells[5].Style.ForeColor = Color.Green;
                            row.Cells[5].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                        }
                        else
                        {
                            row.Cells[5].Style.ForeColor = Color.Red;
                            row.Cells[5].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                        }
                    }

                    if (row.Cells[4].Value != null)
                    {
                        row.Cells[4].Style.ForeColor = Color.Green;
                        row.Cells[4].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                    }
                }

                pbLoading.Visible = false;
            }
            catch (Exception ex)
            {
                logger.Error("BuidDataGridviewService", ex);
                pbLoading.Visible = false;
            }
        }

        private void RefreshButtonGUI()
        {
            ServiceController sc = new ServiceController(txtServiceName.Text);
            txtServiceDisplay.Text = sc.DisplayName;

            if (sc.Status == ServiceControllerStatus.Running)
            {
                btnServiceStart.Enabled = false;
                btnServiceStop.Enabled = true;
                txtServiceStatus.Text = "Running";
            }
            else if (sc.Status == ServiceControllerStatus.Stopped)
            {
                btnServiceStop.Enabled = false;
                btnServiceStart.Enabled = true;
                txtServiceStatus.Text = "Stopped";
            }
            else
            {
                btnServiceStart.Enabled = true;
                btnServiceStop.Enabled = true;
                txtServiceStatus.Text = "Không xác định";
            }

            btnViewLogService.Enabled = true;
        }

        private async void BtnStartPhoneChangeTelco_Click(object sender, EventArgs e)
        {
            try
            {
                this.IsStop = false;
                txtJSESSIONID.Enabled = false;
                txtTS0165a601.Enabled = false;
                txtTS017dff08.Enabled = false;
                txtUrlData.Enabled = false;
                chkEdu.Enabled = false;
                chkGateway.Enabled = false;
                chkRedis.Enabled = false;
                btnStopPhoneChangeTelco.Enabled = true;
                btnStartPhoneChangeTelco.Enabled = false;
                txtEndFile.Enabled = false;
                txtStartFile.Enabled = false;
                txtRange.Enabled = false;
                txtInterval.Enabled = false;

                string JSESSIONID = txtJSESSIONID.Text;
                string TS0165a601 = txtTS0165a601.Text;
                string TS017dff08 = txtTS017dff08.Text;
                File.WriteAllText(this.pathLogSession, JSESSIONID + Environment.NewLine + TS0165a601 + Environment.NewLine + TS017dff08);

                int startFile = Convert.ToInt32(txtStartFile.Text);
                int endFile = Convert.ToInt32(txtEndFile.Text);
                int interval = Convert.ToInt32(txtInterval.Text);
                int range = Convert.ToInt32(txtRange.Text);

                this.cancelToken = new CancellationTokenSource();

                while (!this.IsStop)
                {
                    IDictionary<String, PhoneChangeTelcoModel> dictPhoneChangeTelco = new Dictionary<String, PhoneChangeTelcoModel>();

                    await Task.Run(async () =>
                    {
                        SetTextMonitor("Start stream file " + startFile + " to " + endFile, Color.Green);

                        for (int i = startFile; i <= endFile; i++)
                        {
                            try
                            {
                                logger.Info("Start stream file " + i);

                                HttpWebRequest request = WebRequest.CreateHttp(txtUrlData.Text + i);
                                request.Headers.Add("Accept-Encoding", "gzip, deflate");
                                request.Headers.Add("Accept-Language", "en,vi-VN;q=0.8,vi;q=0.5,en-US;q=0.3");
                                request.Headers.Add("Cookie", String.Format(@"f5_cspm=1234; JSESSIONID={0}; TS017dff08={1}; TS0165a601={2}", txtJSESSIONID.Text, txtTS017dff08.Text, txtTS0165a601.Text));
                                request.Headers.Add("Upgrade-Insecure-Requests", "1");
                                request.Timeout = 20000;

                                using (StreamReader stream = new StreamReader(request.GetResponse().GetResponseStream()))
                                {
                                    while (!stream.EndOfStream)
                                    {
                                        string strLineValue = stream.ReadLine();

                                        if (strLineValue.Contains("<html>") || strLineValue.Contains("Expires"))
                                        {
                                            logger.Error(AppConst.A("BtnStartPhoneChangeTelco_Click", "Session expired, please retry login!"));
                                            SetTextMonitor(AppConst.A("BtnStartPhoneChangeTelco_Click", "Session expired, please retry login!"), Color.Red);
                                            ResetComponents();
                                            this.IsStop = true;
                                            return;
                                        }

                                        if (!String.IsNullOrEmpty(strLineValue))
                                        {
                                            if (strLineValue.Contains("<html>") || strLineValue.Contains("Expires"))
                                            {
                                                logger.Error(AppConst.A("BtnStartPhoneChangeTelco_Click", i, "Session expired, please retry login!"));
                                                SetTextMonitor(AppConst.A("BtnStartPhoneChangeTelco_Click", i, "Session expired, please retry login!"), Color.Red);
                                                break;
                                            }

                                            logger.Info(i + "," + strLineValue);

                                            if (strLineValue.Contains("MOBILE,"))
                                            {
                                                List<string> lstValue = strLineValue.Split(',').ToList();

                                                if (lstValue.Count > 5 && lstValue[2] != null && lstValue[3].Contains("84") && AppConfig.ListTelco.Contains(lstValue[4].Trim()))
                                                {
                                                    PhoneChangeTelcoModel phoneChangeTelco = new PhoneChangeTelcoModel()
                                                    {
                                                        ID_PROCESS = i.ToString(),
                                                        PHONE = lstValue[3],
                                                        TELCO = lstValue[4]
                                                    };

                                                    if (dictPhoneChangeTelco.ContainsKey(phoneChangeTelco.PHONE))
                                                    {
                                                        dictPhoneChangeTelco[phoneChangeTelco.PHONE] = phoneChangeTelco;
                                                    }
                                                    else
                                                    {
                                                        dictPhoneChangeTelco.Add(phoneChangeTelco.PHONE, phoneChangeTelco);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                if (this.IsStop) break;
                            }
                            catch (IOException ex)
                            {
                                logger.Error(AppConst.A("ScanFileOnline Error", i, ex));
                                COUNT_RETRY++;
                                await Task.Delay(3000);
                                if (COUNT_RETRY > 5)
                                {
                                    logger.Error(AppConst.A("ScanFileOnline", i, "Lỗi quá 5 lần rồi!"));
                                    SetTextMonitor(AppConst.A("ScanFileOnline", i, "Lỗi quá 5 lần rồi!"), Color.Red);
                                    break;
                                }
                                else
                                {
                                    i = i - 1;
                                    logger.Info(AppConst.A("ScanFileOnline", "Retry stream file", i, COUNT_RETRY));
                                    SetTextMonitor(AppConst.A("ScanFileOnline", "Retry stream file", i, COUNT_RETRY), Color.Red);
                                }
                            }
                            catch (ArgumentOutOfRangeException ex)
                            {
                                logger.Info(AppConst.A("ScanFileOnline Error", i, ex.ToString()));
                                SetTextMonitor(AppConst.A("ScanFileOnline Error", i, ex.ToString()), Color.Red);
                            }
                            catch (Exception ex)
                            {
                                logger.Error(AppConst.A("ScanFileOnline Error", i, ex));
                                SetTextMonitor(AppConst.A("ScanFileOnline Error", i, ex), Color.Red);
                            }
                        }
                    }, this.cancelToken.Token);

                    string idProcess = String.Empty;
                    SetTextMonitor("Total records: " + dictPhoneChangeTelco.Count, Color.Green);
                    if (dictPhoneChangeTelco.Count > 0)
                    {
                        idProcess = dictPhoneChangeTelco.Values.Last().ID_PROCESS;
                        File.WriteAllText(this.pathLogSession, JSESSIONID + Environment.NewLine + TS0165a601 + Environment.NewLine + TS017dff08 + Environment.NewLine + idProcess);

                        SetTextMonitor("Starting update !!!", Color.Green);
                        if (chkGateway.Checked) _ = Task.Run(() => (new PhoneChangeTelcoRepository()).UpdateGateway(dictPhoneChangeTelco)).ContinueWith(t => SetTextMonitor("Update to database Gateway success", Color.Green), cancelToken.Token);
                        if (chkEdu.Checked) _ = Task.Run(() => (new PhoneChangeTelcoRepository()).UpdateEdu(dictPhoneChangeTelco)).ContinueWith(t => SetTextMonitor("Update to database Edu success", Color.Green), cancelToken.Token);
                        if (chkRedis.Checked) _ = Task.Run(() => (new PhoneChangeTelcoRepository()).UpdateRedis(dictPhoneChangeTelco)).ContinueWith(t => SetTextMonitor("Update to database Redis success", Color.Green), cancelToken.Token);
                    }

                    startFile = String.IsNullOrEmpty(idProcess) ? startFile : Convert.ToInt32(idProcess);
                    endFile = startFile + range;

                    await Task.Delay(interval);
                    SetTextbox(startFile.ToString(), endFile.ToString());
                }
            }
            catch (Exception ex)
            {
                SetTextMonitor(ex.ToString(), Color.Red);
                logger.Error("BtnStartPhoneChangeTelco_Click.: " + ex);
                this.IsStop = true;
                ResetComponents();
            }
        }

        private void BtnStopPhoneChangeTelco_Click(object sender, EventArgs e)
        {
            this.IsStop = true;
            this.cancelToken.Cancel();
            ResetComponents();
        }

        private delegate void EventResetComponents();
        private void ResetComponents()
        {
            if (InvokeRequired)
            {
                Invoke(new EventResetComponents(ResetComponents));
            }
            else
            {
                txtJSESSIONID.Enabled = true;
                txtTS0165a601.Enabled = true;
                txtTS017dff08.Enabled = true;
                txtUrlData.Enabled = true;
                chkEdu.Enabled = true;
                chkGateway.Enabled = true;
                chkRedis.Enabled = true;
                btnStartPhoneChangeTelco.Enabled = true;
                txtEndFile.Enabled = true;
                txtStartFile.Enabled = true;
                txtRange.Enabled = true;
                txtInterval.Enabled = true;
            }
        }

        private void BtnViewLogPhoneChangeTelco_Click(object sender, EventArgs e)
        {
            Process.Start(String.Format("{0}Logs", System.AppDomain.CurrentDomain.BaseDirectory));
        }

        private delegate void EventSetTextCallback(string text, Color color);
        private void SetTextMonitor(string text, Color color)
        {
            if (InvokeRequired)
            {
                Invoke(new EventSetTextCallback(SetTextMonitor), text, color);
            }
            else
            {
                if (rtbMonitor.Lines.Length > Convert.ToInt32(200))
                    rtbMonitor.Clear();

                rtbMonitor.SelectionStart = rtbMonitor.TextLength;
                rtbMonitor.SelectionLength = 0;
                rtbMonitor.SelectionColor = color;
                rtbMonitor.AppendText(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss fff") + ": " + text + Environment.NewLine);
                rtbMonitor.SelectionColor = rtbMonitor.ForeColor;
                rtbMonitor.ScrollToCaret();
            }
        }

        private delegate void EventSetTextbox(string startFile, string endFile);
        private void SetTextbox(string startFile, string endFile)
        {
            if (InvokeRequired)
            {
                Invoke(new EventSetTextbox(SetTextbox), startFile, endFile);
            }
            else
            {
                txtStartFile.Text = startFile;
                txtEndFile.Text = endFile;
            }
        }

        private void txtRange_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtInterval_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtStartFile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtEndFile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                base.OnFormClosing(e);
                if (e.CloseReason == CloseReason.WindowsShutDown) return;

                if (MessageBox.Show(this, "Close Operator Gateway and kill process ?", "Closing", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.IsStop = true;
                    this.cancelToken.Cancel();
                    logger.Info("Stoped application !");
                    Process.GetCurrentProcess().Kill();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(AppConst.A("OnFormClosing", ex));
                Process.GetCurrentProcess().Kill();
            }
        }
    }
}
