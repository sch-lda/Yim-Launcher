using System;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Net;
using System.Security.Cryptography;
using Microsoft.VisualBasic.Devices;
using System.Security.Policy;
using Microsoft.Win32;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace YimLauncher
{

    public partial class Form1 : Form
    {
        private int isdllok = 0;
        private int isnonegfw = 0;
        private int logerr = 0;

        private string AliceluaUrl = "https://ghproxy.com/https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/Alice.lua";
        private string AlicelibUrl = "https://ghproxy.com/https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/lib.lua";
        private string wangzixuanUrl = "https://ghproxy.com/https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/Heist.lua";
        private string schluaUrl = "https://ghproxy.com/https://raw.githubusercontent.com/sch-lda/SCH-LUA-YIMMENU/main/sch.lua";
        private string InfoUrl = "https://ghproxy.com/https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/Info.txt";
        private string YimUrl = "https://ghproxy.com/https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/YimMenu.dll";
        private string IndexUrl = "https://ghproxy.com/https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/index.json";
        private string zhcnUrl = "https://ghproxy.com/https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/zh_CN.json";
        private string OcYimUrl = "https://ghproxy.com/https://github.com/YimMenu/YimMenu/releases/download/nightly/YimMenu.dll";
        static async Task DownloadFileAsync(string url, string fileName)
        {
            using (var client = new WebClient())
            {
                // 异步下载文件
                await client.DownloadFileTaskAsync(url, fileName);

            }
        }

        static string GenerateRandomNumber()
        {
            Random random = new Random();
            return random.Next(1000, 9999).ToString();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label10.Text = "";
            label11.Text = "";
            label12.Text = "下载源:中国:ghproxy(自动)";

            label15.Text = "系统:" + Environment.OSVersion.Version.ToString();
            label16.Text = "运行库:" + Environment.Version.ToString();
            label17.Text = "用户:" + Environment.UserName.ToString();

            timer1.Enabled = false;
            button2.Enabled = false;
            button2.Text = "无需更新文件";
            label5.Text = "";

            string InjectTMP1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "YimLauncher", "tmp");
            try
            {
                foreach (string file in Directory.GetFiles(InjectTMP1))
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }
            }
            catch
            {

            }




            string InfoTxt = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimLauncher/Info.txt";

            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimLauncher"))

            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimLauncher");

            }

            using (WebClient client = new WebClient())
            {
                try
                {
                    client.DownloadFile(InfoUrl, InfoTxt);
                    timer1.Enabled = true;
                }
                catch (Exception ex)
                {

                    try
                    {
                        string fallbackUrl = "https://cdn.jsdelivr.net/gh/sch-lda/Yim-Launcher@main/static/Info.txt";
                        client.DownloadFile(fallbackUrl, InfoTxt);
                        timer1.Enabled = true;

                    }
                    catch
                    {
                        try
                        {
                            string fallbackUrl2 = "https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/Info.txt";
                            client.DownloadFile(fallbackUrl2, InfoTxt);
                            timer1.Enabled = true;

                        }
                        catch
                        {
                            MessageBox.Show("配置文件无法下载,部分功能失效!");
                            timer1.Enabled = false;
                            label4.Text = "网络错误，无法运行文件校验";
                            label12.Text = "下载源:不可用(无网络)";
                        }
                    }

                }
            }

            string keyPath = @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Rockstar Games Social Club";
            string valueName = "UninstallString";
            string installLocation = "";

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath))
            {
                if (key != null)
                {
                    object value = key.GetValue(valueName);
                    if (value != null)
                    {
                        installLocation = value.ToString();

                    }
                }
            }
            string rawpath = installLocation;
            string substringToRemove = @"\uninstallRGSCRedistributable.exe";

            string newPath = rawpath.Replace(substringToRemove, "");
            FileVersionInfo scdllinfo = FileVersionInfo.GetVersionInfo(newPath + "/socialclub.dll");
            string version = scdllinfo.ProductVersion;
            label8.Text = "启动器版本:" + version;

            try
            {

                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimLauncher/Info.txt";
                string[] lines = File.ReadAllLines(filePath);
                string SCVerValue = null;
                string SCVerLine = Array.Find(lines, line => line.StartsWith("SCVer"));

                if (SCVerLine != null)
                {
                    string[] parts = SCVerLine.Split('=');
                    SCVerValue = parts[1].Trim();
                }

                if (version != SCVerValue)
                {
                    label9.Text = "评价:过时\n卸载当前启动器，然后重新启动游戏";
                    label9.ForeColor = Color.Red;
                }
                else
                {
                    label9.Text = "评价:正常,无需进行操作";
                    label9.ForeColor = Color.Green;

                }

            }
            catch
            {

            }

            string coutPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/cout.log";
            string searchText1 = "线上小助手汉化";

            try
            {



                if (File.Exists(coutPath))
                {
                    string[] lines = File.ReadAllLines(coutPath);
                    foreach (string line in lines)
                    {
                        if (line.Contains(searchText1))
                        {
                            label20.Text = "Yim版本:汉化版";

                        }

                        if (line.Contains("Initializing"))
                        {
                            label20.Text = "Yim版本:官方版";

                        }

                        if (line.StartsWith("\t更新日期:"))
                        {
                            string dateCHS = line.Substring(line.IndexOf(":") + 1).Trim();
                            label21.Text = "Yim更新日期:\n" + dateCHS;
                        }
                        if (line.StartsWith("\tDate:"))
                        {
                            string dateOc = line.Substring(line.IndexOf(":") + 1).Trim();
                            label21.Text = "Yim更新日期:\n" + dateOc;
                        }

                    }
                }
            }
            catch
            {
                label20.Text = "无法读取Yim日志";

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process GTA5Process = null;
            string yimPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimLauncher/YimMenu.dll";

            foreach (var item in Process.GetProcessesByName("GTA5"))
            {
                if (item.MainWindowHandle == IntPtr.Zero)
                    continue;

                if (item.MainModule.FileVersionInfo.LegalCopyright.Contains("Rockstar Games Inc."))
                {
                    GTA5Process = item;
                    break;
                }
            }
            try
            {
                string sourcePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "YimLauncher", "YimMenu.dll");
                string InjectTMP = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "YimLauncher", "tmp");
                string randomFileName = "tmp_" + GenerateRandomNumber() + ".dll";
                string InjectTMPdll = Path.Combine(InjectTMP, randomFileName);

                // 创建目标文件夹（如果不存在）
                Directory.CreateDirectory(InjectTMP);

                // 复制文件
                File.Copy(sourcePath, InjectTMPdll);

                if (GTA5Process != null)
                {
                    DllInjector.InjectDll(GTA5Process.Id, InjectTMPdll);

                }
                else
                {
                    MessageBox.Show("GTA5未运行!");
                }

            }
            catch
            {

            }

        }

        private void button2_Click(object sender, EventArgs e) //下载YimMenu.dll及语言文件
        {

            label5.Text = "正在下载,请耐心等待...";


            string InjectTMPdll = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimLauncher/YimMenu.dll";
            string IndexFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/translations/index.json";
            string zhcnFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/translations/zh_CN.json";
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/translations"))
            {
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu"))
                {
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu");
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/translations");

                }
                else
                {
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/translations");

                }

            }
            using (WebClient client = new WebClient())
            {
                try
                {
                    if (isdllok != 1)
                    {
                        client.DownloadFile(YimUrl, InjectTMPdll);

                    }
                    client.DownloadFile(IndexUrl, IndexFolder);
                    client.DownloadFile(zhcnUrl, zhcnFolder);

                    label5.Text = "下载完成";
                }
                catch (Exception ex)
                {
                    label5.Text = "下载失败";

                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int errct = 0;


            string yimPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimLauncher/YimMenu.dll";



            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimLauncher/YimMenu.dll"))
            {
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimLauncher/Info.txt";
                string[] lines = File.ReadAllLines(filePath);
                string dllHashValue = null;
                string dllHashLine = Array.Find(lines, line => line.StartsWith("dllHash"));

                if (dllHashLine != null)
                {
                    string[] parts = dllHashLine.Split('=');
                    dllHashValue = parts[1].Trim();
                }
                string realdllhash = CalculateFileHash(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimLauncher/YimMenu.dll");
                if (realdllhash == dllHashValue)
                {
                    label1.ForeColor = Color.Green;
                    label1.Text = "Yimmenu(诊断程序专用) 正常,Hash与服务器一致";
                    isdllok = 1;
                }
                else
                {
                    label1.Text = "Yimmenu(诊断程序专用) 过时";
                    label1.ForeColor = Color.Black;
                    errct = errct + 1;
                    isdllok = 0;
                }
            }
            else
            {
                label1.Text = "Yimmenu(诊断程序专用) 缺失";
                label1.ForeColor = Color.Black;
                errct = errct + 1;
                isdllok = 0;

            }
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/translations/index.json"))
            {
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimLauncher/Info.txt";
                string indexHash = "";

                // 读取文件内容
                string[] lines = File.ReadAllLines(filePath);

                // 查找IndexHash行
                foreach (string line in lines)
                {
                    if (line.StartsWith("IndexHash"))
                    {
                        // 获取IndexHash的值
                        indexHash = line.Split('=')[1].Trim();
                        break;
                    }
                }

                string hash = CalculateFileHash(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/translations/index.json");
                if (hash == indexHash)
                {
                    label2.ForeColor = Color.Green;
                    label2.Text = "语言索引 正常,Hash与服务器一致";
                }
                else
                {
                    label2.Text = "语言索引 改变,若中文不正常请更新";
                    label2.ForeColor = Color.Coral;
                    errct = errct + 1;

                }

            }
            else
            {
                label2.Text = "语言索引 缺失";
                label2.ForeColor = Color.Red;
                errct = errct + 1;

            }
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/translations/zh_CN.json"))
            {
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimLauncher/Info.txt";
                string[] lines = File.ReadAllLines(filePath);
                string zhcnHashValue = null;
                // 查找zhcnHash的行
                string zhcnHashLine = Array.Find(lines, line => line.StartsWith("zhcnHash"));

                if (zhcnHashLine != null)
                {
                    // 提取zhcnHash的值
                    string[] parts = zhcnHashLine.Split('=');
                    zhcnHashValue = parts[1].Trim();

                }
                string hash2 = CalculateFileHash(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/translations/zh_CN.json");
                if (hash2 == zhcnHashValue)
                {
                    label3.ForeColor = Color.Green;
                    label3.Text = "中文语言文件 正常,Hash与服务器一致";
                }
                else
                {
                    label3.Text = "中文语言文件 改变,若中文不正常请更新";
                    label3.ForeColor = Color.Red;
                    errct = errct + 1;

                }
            }
            else
            {
                label3.Text = "中文语言文件 缺失";
                label3.ForeColor = Color.Coral;
                errct = errct + 1;

            }
            if (errct == 0)
            {
                label4.Text = "关键文件状态指示:(通过)";
                button2.Enabled = false;
            }
            else
            {
                label4.Text = "关键文件状态指示:(未通过)";
                button2.Enabled = true;
                button2.Text = "更新异常文件";
            }
            timer1.Interval = 5000;
        }
        static string CalculateFileHash(string filePath)
        {
            using (var sha256 = SHA256.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    byte[] hashBytes = sha256.ComputeHash(stream);
                    return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Process stProcess1 = null;
            try
            {
                foreach (var item1 in Process.GetProcesses())
                {
                    if (item1.MainWindowHandle == IntPtr.Zero)
                        continue;

                    if (item1.MainModule.FileVersionInfo.FileDescription.Contains("Stand"))
                    {
                        label7.Text = "Stand注入器正在运行\n如需双开,请确保先注入Yim后注入stand！";
                        label7.ForeColor = Color.Red;

                        break;
                    }
                    else
                    {
                        label7.Text = "暂未发现异常";
                        label7.ForeColor = Color.Black;


                    }

                }

            }
            catch
            {

            }
            Process GTA5Process1 = null;

            foreach (var item in Process.GetProcessesByName("GTA5"))
            {
                if (item.MainWindowHandle == IntPtr.Zero)
                    continue;

                if (item.MainModule.FileVersionInfo.LegalCopyright.Contains("Rockstar Games Inc."))
                {
                    GTA5Process1 = item;
                    break;
                }
            }
            if (GTA5Process1 != null)
            {
                label6.Text = "GTA5正在运行";
                button12.Enabled = true;

            }
            else
            {
                button12.Enabled = false;
                label6.Text = "GTA5已停止";

            }

            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/scripts/Alice.lua") && File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/scripts/Alice-lib/lib.lua"))
            {
                button9.BackColor = Color.Green;
                button9.ForeColor = Color.White;
                button9.Text = "更新Alice lua";
            }
            else
            {
                button9.BackColor = Color.White;
                button9.ForeColor = Color.Black;
                button9.Text = "下载Alice lua";

            }

            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/scripts/YimMenu-HeistLua.lua") && File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/scripts/Alice-lib/lib.lua"))
            {
                button11.BackColor = Color.Green;
                button11.ForeColor = Color.White;
                button11.Text = "更新HeistLua";

            }
            else
            {
                button11.BackColor = Color.White;
                button11.ForeColor = Color.Black;
                button11.Text = "下载HeistLua";

            }

            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/scripts/sch.lua"))
            {
                button10.BackColor = Color.Green;
                button10.ForeColor = Color.White;
                button10.Text = "更新SCH Lua";

            }
            else
            {
                button10.BackColor = Color.White;
                button10.ForeColor = Color.Black;
                button10.Text = "下载SCH Lua";

            }


        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string keyPath = @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Rockstar Games Social Club";
            string valueName = "UninstallString";
            string uninstallLocation = "";

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath))
            {
                if (key != null)
                {
                    object value = key.GetValue(valueName);
                    if (value != null)
                    {
                        uninstallLocation = value.ToString();

                    }
                }
            }

            Process.Start(uninstallLocation);
        }
        public static void DeleteDirectory(string directoryPath)
        {
            // 删除目录中的文件
            string[] files = Directory.GetFiles(directoryPath);
            foreach (string file in files)
            {
                File.Delete(file);
            }

            // 递归删除子目录
            string[] subDirectories = Directory.GetDirectories(directoryPath);
            foreach (string subDirectory in subDirectories)
            {
                DeleteDirectory(subDirectory);
            }

            // 删除空目录
            Directory.Delete(directoryPath);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu");

            }
            catch
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/cache");

            }
            catch
            {

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/translations");

            }
            catch
            {

            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/scripts");

            }
            catch
            {

            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/cout.log";
            string searchText1 = "EXCEPTION_ACCESS_VIOLATION";
            string searchText2 = "未找到 'PD";
            try
            {



                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        if (line.Contains(searchText1))
                        {
                            label10.Text = "发现复杂错误ExceptionAccessViolation";
                            logerr = logerr + 1;

                        }
                        if (line.Contains(searchText2))
                        {
                            label11.Text = "未找到PD,请重新安装GTA5启动器";
                            logerr = logerr + 1;

                        }

                    }
                }
            }
            catch
            {
                MessageBox.Show("无法读取日志,请确保Yimmenu未在运行");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

            string AliceluaDes = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Yimmenu/scripts/Alice.lua";
            string AlicelibDes = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Yimmenu/scripts/Alice-lib/lib.lua";

            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/scripts"))
            {
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu"))
                {
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu");
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/scripts");

                }
                else
                {
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/scripts");

                }

            }
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/scripts/Alice-lib");


            using (WebClient client = new WebClient())
            {
                try
                {
                    Task downloadTask1 = Task.Run(() => DownloadFileAsync(AliceluaUrl, AliceluaDes));
                    Task downloadTask2 = Task.Run(() => DownloadFileAsync(AlicelibUrl, AlicelibDes));

                    //MessageBox.Show("成功");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("下载失败");
                }
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("GTA5");

            // 遍历进程实例并关闭它们
            foreach (Process process in processes)
            {
                process.Kill();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

            string schluaDes = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Yimmenu/scripts/sch.lua";

            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/scripts"))
            {
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu"))
                {
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu");
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/scripts");

                }
                else
                {
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/scripts");

                }

            }


            using (WebClient client = new WebClient())
            {
                try
                {
                    Task downloadTask1 = Task.Run(() => DownloadFileAsync(schluaUrl, schluaDes));

                    // MessageBox.Show("成功");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("下载失败");
                }
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {

            string wangzixuanDes = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Yimmenu/scripts/YimMenu-HeistLua.lua";
            string AlicelibDes = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Yimmenu/scripts/Alice-lib/lib.lua";

            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/scripts"))
            {
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu"))
                {
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu");
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/scripts");

                }
                else
                {
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/scripts");

                }

            }
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/scripts/Alice-lib");


            using (WebClient client = new WebClient())
            {
                try
                {
                    Task downloadTask1 = Task.Run(() => DownloadFileAsync(wangzixuanUrl, wangzixuanDes));
                    Task downloadTask2 = Task.Run(() => DownloadFileAsync(AlicelibUrl, AlicelibDes));


                }
                catch (Exception ex)
                {
                    MessageBox.Show("下载失败");
                }
            }

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            string testgfwhost = "google.com";
            isnonegfw = 0;

            Ping ping = new Ping();
            PingReply reply = ping.Send(testgfwhost);

            if (reply.Status == IPStatus.Success)
            {
                isnonegfw = 1;
                AliceluaUrl = "https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/Alice.lua";
                AlicelibUrl = "https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/lib.lua";
                wangzixuanUrl = "https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/Heist.lua";
                schluaUrl = "https://raw.githubusercontent.com/sch-lda/SCH-LUA-YIMMENU/main/sch.lua";
                InfoUrl = "https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/Info.txt";
                YimUrl = "https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/YimMenu.dll";
                IndexUrl = "https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/index.json";
                zhcnUrl = "https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/zh_CN.json";
                label12.Text = "下载源:国际:Github(自动)";
            }
            else
            {

            }
            timer3.Enabled = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            AliceluaUrl = "https://cdn.jsdelivr.net/gh/sch-lda/Yim-Launcher@main/static/Alice.lua";
            AlicelibUrl = "https://cdn.jsdelivr.net/gh/sch-lda/Yim-Launcher@main/static/lib.lua";
            wangzixuanUrl = "https://cdn.jsdelivr.net/gh/sch-lda/Yim-Launcher@main/static/Heist.lua";
            schluaUrl = "https://cdn.jsdelivr.net/gh/sch-lda/SCH-LUA-YIMMENU@main/sch.lua";
            InfoUrl = "https://cdn.jsdelivr.net/gh/sch-lda/Yim-Launcher@main/static/Info.txt";
            YimUrl = "https://cdn.jsdelivr.net/gh/sch-lda/Yim-Launcher@main/static/YimMenu.dll";
            IndexUrl = "https://cdn.jsdelivr.net/gh/sch-lda/Yim-Launcher@main/static/index.json";
            zhcnUrl = "https://cdn.jsdelivr.net/gh/sch-lda/Yim-Launcher@main/static/zh_CN.json";
            label12.Text = "下载源:jsDelivr";

        }


        private void button13_Click_1(object sender, EventArgs e)
        {
            AliceluaUrl = "https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/Alice.lua";
            AlicelibUrl = "https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/lib.lua";
            wangzixuanUrl = "https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/Heist.lua";
            schluaUrl = "https://raw.githubusercontent.com/sch-lda/SCH-LUA-YIMMENU/main/sch.lua";
            InfoUrl = "https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/Info.txt";
            YimUrl = "https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/YimMenu.dll";
            IndexUrl = "https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/index.json";
            zhcnUrl = "https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/zh_CN.json";
            label12.Text = "下载源:Github";
            button13.BackColor = Color.Cyan;
            button14.BackColor = Color.White;
            button15.BackColor = Color.White;

        }

        private void button14_Click(object sender, EventArgs e)
        {
            AliceluaUrl = "https://ghproxy.com/https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/Alice.lua";
            AlicelibUrl = "https://ghproxy.com/https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/lib.lua";
            wangzixuanUrl = "https://ghproxy.com/https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/Heist.lua";
            schluaUrl = "https://ghproxy.com/https://raw.githubusercontent.com/sch-lda/SCH-LUA-YIMMENU/main/sch.lua";
            InfoUrl = "https://ghproxy.com/https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/Info.txt";
            YimUrl = "https://ghproxy.com/https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/YimMenu.dll";
            IndexUrl = "https://ghproxy.com/https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/index.json";
            zhcnUrl = "https://ghproxy.com/https://raw.githubusercontent.com/sch-lda/Yim-Launcher/main/static/zh_CN.json";
            label12.Text = "下载源:ghproxy";
            button14.BackColor = Color.Cyan;
            button13.BackColor = Color.White;
            button15.BackColor = Color.White;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            AliceluaUrl = "https://cdn.jsdelivr.net/gh/sch-lda/Yim-Launcher@main/static/Alice.lua";
            AlicelibUrl = "https://cdn.jsdelivr.net/gh/sch-lda/Yim-Launcher@main/static/lib.lua";
            wangzixuanUrl = "https://cdn.jsdelivr.net/gh/sch-lda/Yim-Launcher@main/static/Heist.lua";
            schluaUrl = "https://cdn.jsdelivr.net/gh/sch-lda/SCH-LUA-YIMMENU@main/sch.lua";
            InfoUrl = "https://cdn.jsdelivr.net/gh/sch-lda/Yim-Launcher@main/static/Info.txt";
            YimUrl = "https://cdn.jsdelivr.net/gh/sch-lda/Yim-Launcher@main/static/YimMenu.dll";
            IndexUrl = "https://cdn.jsdelivr.net/gh/sch-lda/Yim-Launcher@main/static/index.json";
            zhcnUrl = "https://cdn.jsdelivr.net/gh/sch-lda/Yim-Launcher@main/static/zh_CN.json";
            label12.Text = "下载源:jsDelivr";
            button15.BackColor = Color.Cyan;
            button14.BackColor = Color.White;
            button13.BackColor = Color.White;
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            string Officialdllcdn = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimLauncher/YimMenuOc.dll";
            string Officialdllraw = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimLauncher/YimMenuOc.dll";

            label5.Text = "Yim官方版正在下载";
            label5.ForeColor = Color.Red;
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.DownloadFile(OcYimUrl, Officialdllcdn);

                    label5.Text = "Yim官方版下载完成";
                    label5.ForeColor = Color.Black;
                    Process GTA5Process = null;
                    string yimPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimLauncher/YimMenu.dll";

                    foreach (var item in Process.GetProcessesByName("GTA5"))
                    {
                        if (item.MainWindowHandle == IntPtr.Zero)
                            continue;

                        if (item.MainModule.FileVersionInfo.LegalCopyright.Contains("Rockstar Games Inc."))
                        {
                            GTA5Process = item;
                            break;
                        }
                    }
                    try
                    {
                        string InjectTMP = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "YimLauncher", "tmp");
                        string randomFileName = "octmp_" + GenerateRandomNumber() + ".dll";
                        string InjectTMPdll = Path.Combine(InjectTMP, randomFileName);

                        // 创建目标文件夹（如果不存在）
                        Directory.CreateDirectory(InjectTMP);

                        // 复制文件
                        File.Copy(Officialdllcdn, InjectTMPdll);

                        if (GTA5Process != null)
                        {
                            DllInjector.InjectDll(GTA5Process.Id, InjectTMPdll);

                        }
                        else
                        {
                            MessageBox.Show("GTA5未运行!");
                        }

                    }
                    catch
                    {

                    }



                }
                catch (Exception ex)
                {
                    try
                    {
                        label5.Text = "尝试备用方案";

                        client.DownloadFile(OcYimUrl, Officialdllcdn);

                        label5.Text = "Yim官方版下载完成";
                        label5.ForeColor = Color.Black;
                        Process GTA5Process = null;
                        string yimPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimLauncher/YimMenu.dll";

                        foreach (var item in Process.GetProcessesByName("GTA5"))
                        {
                            if (item.MainWindowHandle == IntPtr.Zero)
                                continue;

                            if (item.MainModule.FileVersionInfo.LegalCopyright.Contains("Rockstar Games Inc."))
                            {
                                GTA5Process = item;
                                break;
                            }
                        }
                        try
                        {
                            string InjectTMP = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "YimLauncher", "tmp");
                            string randomFileName = "octmp_" + GenerateRandomNumber() + ".dll";
                            string InjectTMPdll = Path.Combine(InjectTMP, randomFileName);

                            // 创建目标文件夹（如果不存在）
                            Directory.CreateDirectory(InjectTMP);

                            // 复制文件
                            File.Copy(Officialdllcdn, InjectTMPdll);

                            if (GTA5Process != null)
                            {
                                DllInjector.InjectDll(GTA5Process.Id, InjectTMPdll);

                            }
                            else
                            {
                                MessageBox.Show("GTA5未运行!");
                            }

                        }
                        catch
                        {

                        }

                    }
                    catch {

                        label5.Text = "下载失败";

                    }

                }
            }

        }
    }
}

public class DllInjector
{
    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

    private const uint PROCESS_CREATE_THREAD = 0x0002;
    private const uint PROCESS_QUERY_INFORMATION = 0x0400;
    private const uint PROCESS_VM_OPERATION = 0x0008;
    private const uint PROCESS_VM_WRITE = 0x0020;
    private const uint PROCESS_VM_READ = 0x0010;
    private const uint MEM_COMMIT = 0x00001000;
    private const uint MEM_RESERVE = 0x00002000;
    private const uint PAGE_READWRITE = 0x04;

    public static bool InjectDll(int processId, string dllPath)
    {
        IntPtr hProcess = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, 0, (uint)processId);
        if (hProcess == IntPtr.Zero)
        {
            //Console.WriteLine("Failed to open process. Error code: " + Marshal.GetLastWin32Error());
            return false;
        }

        IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
        if (loadLibraryAddr == IntPtr.Zero)
        {
            // Console.WriteLine("Failed to get address of LoadLibraryA. Error code: " + Marshal.GetLastWin32Error());
            return false;
        }

        IntPtr allocMemAddr = VirtualAllocEx(hProcess, IntPtr.Zero, (uint)((dllPath.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
        if (allocMemAddr == IntPtr.Zero)
        {
            //Console.WriteLine("Failed to allocate memory in remote process. Error code: " + Marshal.GetLastWin32Error());
            return false;
        }

        byte[] dllPathBytes = Encoding.Default.GetBytes(dllPath);
        int bytesWritten;
        if (!WriteProcessMemory(hProcess, allocMemAddr, dllPathBytes, (uint)(dllPathBytes.Length), out bytesWritten))
        {
            //Console.WriteLine("Failed to write DLL path to remote process. Error code: " + Marshal.GetLastWin32Error());
            return false;
        }

        IntPtr remoteThread = CreateRemoteThread(hProcess, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddr, 0, IntPtr.Zero);
        if (remoteThread == IntPtr.Zero)
        {
            // Console.WriteLine("Failed to create remote thread. Error code: " + Marshal.GetLastWin32Error());
            return false;
        }

        // Console.WriteLine("DLL injected successfully.");

        return true;
    }

}
