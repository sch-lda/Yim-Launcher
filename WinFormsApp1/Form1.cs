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

namespace YimLauncher
{

    public partial class Form1 : Form
    {
        private bool isdllok = false;
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
            timer1.Enabled = false;
            button2.Enabled = false;
            button2.Text = "��������ļ�";
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
                    timer1.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("�����ļ��޷�����,���ֹ���ʧЧ!");
                    timer1.Enabled = false;
                    label4.Text = "��������޷������ļ�У��";
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
            label8.Text = "�������汾:" + version;

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
                    label9.Text = "����:��ʱ\nж�ص�ǰ��������Ȼ������������Ϸ";
                    label9.ForeColor = Color.Red;
                }
                else
                {
                    label9.Text = "����:����,������в���";
                    label9.ForeColor = Color.Green;

                }

            }
            catch
            {

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

                // ����Ŀ���ļ��У���������ڣ�
                Directory.CreateDirectory(InjectTMP);

                // �����ļ�
                File.Copy(sourcePath, InjectTMPdll);

                if (GTA5Process != null)
                {
                    DllInjector.InjectDll(GTA5Process.Id, InjectTMPdll);

                }
                else
                {
                    MessageBox.Show("GTA5δ����!");
                }

            }
            catch
            {

            }

        }

        private void button2_Click(object sender, EventArgs e) //����YimMenu.dll�������ļ�
        {

            label5.Text = "��������,�����ĵȴ�...";

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
                    if (isdllok = false)
                    {
                        client.DownloadFile(YimUrl, InjectTMPdll);

                    }
                    client.DownloadFile(IndexUrl, IndexFolder);
                    client.DownloadFile(zhcnUrl, zhcnFolder);

                    label5.Text = "�������";
                }
                catch (Exception ex)
                {
                    label5.Text = "����ʧ��";

                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int errct = 0;


            string yimPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimLauncher/YimMenu.dll";

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
                label6.Text = "GTA5��������";
            }
            else
            {

            }

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
                    label1.Text = "Yimmenu(��ϳ���ר��) ����,Hash�������һ��";
                    isdllok = true;
                }
                else
                {
                    label1.Text = "Yimmenu(��ϳ���ר��) ��ʱ";
                    label1.ForeColor = Color.Coral;
                    errct = errct + 1;
                }
            }
            else
            {
                label1.Text = "Yimmenu(��ϳ���ר��) ȱʧ";
                label1.ForeColor = Color.Red;
                errct = errct + 1;

            }
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/translations/index.json"))
            {
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimLauncher/Info.txt";
                string indexHash = "";

                // ��ȡ�ļ�����
                string[] lines = File.ReadAllLines(filePath);

                // ����IndexHash��
                foreach (string line in lines)
                {
                    if (line.StartsWith("IndexHash"))
                    {
                        // ��ȡIndexHash��ֵ
                        indexHash = line.Split('=')[1].Trim();
                        break;
                    }
                }

                string hash = CalculateFileHash(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/translations/index.json");
                if (hash == indexHash)
                {
                    label2.ForeColor = Color.Green;
                    label2.Text = "�������� ����,Hash�������һ��";
                }
                else
                {
                    label2.Text = "�������� ���ܹ�ʱ,�����Ĳ����������";
                    label2.ForeColor = Color.Coral;
                    errct = errct + 1;

                }

            }
            else
            {
                label2.Text = "�������� ȱʧ";
                label2.ForeColor = Color.Red;
                errct = errct + 1;

            }
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/translations/zh_CN.json"))
            {
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimLauncher/Info.txt";
                string[] lines = File.ReadAllLines(filePath);
                string zhcnHashValue = null;
                // ����zhcnHash����
                string zhcnHashLine = Array.Find(lines, line => line.StartsWith("zhcnHash"));

                if (zhcnHashLine != null)
                {
                    // ��ȡzhcnHash��ֵ
                    string[] parts = zhcnHashLine.Split('=');
                    zhcnHashValue = parts[1].Trim();

                }
                string hash2 = CalculateFileHash(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YimMenu/translations/zh_CN.json");
                if (hash2 == zhcnHashValue)
                {
                    label3.ForeColor = Color.Green;
                    label3.Text = "���������ļ� ����,Hash�������һ��";
                }
                else
                {
                    label3.Text = "���������ļ� ��ʱ";
                    label3.ForeColor = Color.Red;
                    errct = errct + 1;

                }
            }
            else
            {
                label3.Text = "���������ļ� ȱʧ";
                label3.ForeColor = Color.Coral;
                errct = errct + 1;

            }
            if (errct == 0)
            {
                label4.Text = "�ؼ��ļ�״ָ̬ʾ:(ͨ��)";
                button2.Enabled = false;
            }
            else
            {
                label4.Text = "�ؼ��ļ�״ָ̬ʾ:(δͨ��)";
                button2.Enabled = true;
                button2.Text = "�����쳣�ļ�";
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            Process stProcess1 = null;

            foreach (var item1 in Process.GetProcessesByName("Stand.Launchpad"))
            {
                if (item1.MainWindowHandle == IntPtr.Zero)
                    continue;

                if (item1.MainModule.FileVersionInfo.FileDescription.Contains("Stand"))
                {
                    stProcess1 = item1;
                    break;
                }

            }
            if (stProcess1 != null)
            {
                label7.Text = "Standע������������\n����˫��,��ȷ����ע��Yim��ע��stand��";
                label7.ForeColor = Color.Red;
            }
            else
            {
                label7.Text = "��δ�����쳣";

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
            // ɾ��Ŀ¼�е��ļ�
            string[] files = Directory.GetFiles(directoryPath);
            foreach (string file in files)
            {
                File.Delete(file);
            }

            // �ݹ�ɾ����Ŀ¼
            string[] subDirectories = Directory.GetDirectories(directoryPath);
            foreach (string subDirectory in subDirectories)
            {
                DeleteDirectory(subDirectory);
            }

            // ɾ����Ŀ¼
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
