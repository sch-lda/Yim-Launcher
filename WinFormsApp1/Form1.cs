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

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
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

            string InfoUrl = "https://cus.host3650.live/Info.txt";
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("配置文件无法下载,部分功能失效!");
                    timer1.Enabled = false;
                    label4.Text = "网络错误，无法运行检查";
                }
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

                DllInjector.InjectDll(GTA5Process.Id, InjectTMPdll);

            }
            catch
            {

            }

        }

        private void button2_Click(object sender, EventArgs e) //下载YimMenu.dll及语言文件
        {

            label5.Text = "正在下载,请耐心等待...";

            string YimUrl = "https://cus.host3650.live/YimMenu.dll";
            string IndexUrl = "https://cus.host3650.live/index.json";
            string zhcnUrl = "https://cus.host3650.live/zh_CN.json";

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
                    client.DownloadFile(YimUrl, InjectTMPdll);
                    client.DownloadFile(IndexUrl, IndexFolder);
                    client.DownloadFile(zhcnUrl, zhcnFolder);


                    MessageBox.Show("全部下载完成");
                }
                catch (Exception ex)
                {
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int errct = 0;

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
                    label1.Text = "Yimmenu Dll 正常,Hash与服务器一致";
                }
                else
                {
                    label1.Text = "Yimmenu Dll 过时";
                    label1.ForeColor = Color.Coral;
                    errct = errct + 1;
                }
            }
            else
            {
                label1.Text = "Yimmenu Dll缺失";
                label1.ForeColor = Color.Coral;
                errct = errct + 1;

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
                    label2.Text = "语言索引 过时";
                    label2.ForeColor = Color.Coral;
                    errct = errct + 1;

                }

            }
            else
            {
                label2.Text = "语言索引 缺失";
                label2.ForeColor = Color.Coral;
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
                    label3.Text = "中文语言文件 过时";
                    label3.ForeColor = Color.Coral;
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
            }
            else
            {
                label4.Text = "关键文件状态指示:(未通过)";

            }
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
            Console.WriteLine("Failed to open process. Error code: " + Marshal.GetLastWin32Error());
            return false;
        }

        IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
        if (loadLibraryAddr == IntPtr.Zero)
        {
            Console.WriteLine("Failed to get address of LoadLibraryA. Error code: " + Marshal.GetLastWin32Error());
            return false;
        }

        IntPtr allocMemAddr = VirtualAllocEx(hProcess, IntPtr.Zero, (uint)((dllPath.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
        if (allocMemAddr == IntPtr.Zero)
        {
            Console.WriteLine("Failed to allocate memory in remote process. Error code: " + Marshal.GetLastWin32Error());
            return false;
        }

        byte[] dllPathBytes = Encoding.Default.GetBytes(dllPath);
        int bytesWritten;
        if (!WriteProcessMemory(hProcess, allocMemAddr, dllPathBytes, (uint)(dllPathBytes.Length), out bytesWritten))
        {
            Console.WriteLine("Failed to write DLL path to remote process. Error code: " + Marshal.GetLastWin32Error());
            return false;
        }

        IntPtr remoteThread = CreateRemoteThread(hProcess, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddr, 0, IntPtr.Zero);
        if (remoteThread == IntPtr.Zero)
        {
            Console.WriteLine("Failed to create remote thread. Error code: " + Marshal.GetLastWin32Error());
            return false;
        }

        Console.WriteLine("DLL injected successfully.");

        return true;
    }

}
