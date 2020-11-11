using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading.Tasks;

namespace fSwitch
{
    public partial class fLagSwitch : Form
    {
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private static Random random = new Random();

        private OpenFileDialog fileDialog;

        private String filePath;
        private int key;

        private bool fileSpecified = false;
        private bool keySpecified = false;
        private bool ready = false;

        private bool isLagging = false;
        
        private Timer keyPressTimer;
        
        private string randomRuleName;

        public fLagSwitch()
        {
            InitializeComponent();
            keyPressTimer = new Timer();
            keyPressTimer.Interval = 16;
            keyPressTimer.Tick += new EventHandler(keypressTimer_Tick);

            fileDialog = new OpenFileDialog();
            fileDialog.Title = "Choose the path to your program that will be lagged:";
            fileDialog.RestoreDirectory = true;
            fileDialog.DefaultExt = "exe";
            fileDialog.CheckPathExists = true;
            fileDialog.CheckFileExists = true;
            fileDialog.Multiselect = false;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public static bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void fLagSwitch_Load(object sender, EventArgs e)
        {
            keyPressTimer.Start();
            statusUpdater();
            Text = randomString(random.Next(10,20));
        }

        public static string randomString(int length)
        {
            char[] str = new char[length];

            for (int i = 0; i < length; i++)
            {
                str[i] = chars[random.Next(chars.Length)];
            }

            return new string(str);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = fileDialog.FileName;
                textBox1.Text = fileDialog.FileName;
                fileSpecified = true;
                statusUpdater();
            }
            else
            {
                filePath = "";
                fileSpecified = false;
                ready = false;
                statusUpdater();
            }
        }

        private void OnTogglerShortcutKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void OnTogglerShortcutSpecified(object sender, KeyEventArgs e)
        {
            ready = false;
            lagTogglerKeyEntry.Text = e.KeyCode.ToString();
            key = e.KeyValue;
            keySpecified = true;
            statusUpdater();
        }

        private async void statusUpdater()
        {
            if (!IsAdministrator())
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "You have to run this as Administrator.";
                button1.Enabled = false;
                lagTogglerKeyEntry.Enabled = false;
                label1.Enabled = false;
                label2.Enabled = false;
                enableSoundNotifications.Enabled = false;
                laggerEnabled.Enabled = false;
                ready = false;
                return;
            }

            if (!laggerEnabled.Checked)
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "You have to enable the lagger.";
                return;
            }

            if (keySpecified && fileSpecified && IsAdministrator())
            {
                statusLabel.ForeColor = Color.Green;
                statusLabel.Text = "Everything is good! Waiting for lag key press...";
                await Task.Delay(1000);
                ready = true;
            }
            else
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "Waiting for settings to be filled...";
                ready = false;
            }
        }

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        private async void keypressTimer_Tick(object sender, EventArgs e)
        {
            if (keySpecified && fileSpecified && ready && laggerEnabled.Checked)
            {
                short keyState = GetAsyncKeyState(key);
                bool isKeyPressed = ((int)keyState >> 15 & 1) == 1;

                if (isKeyPressed)
                {
                    if (!isLagging)
                    {
                        if(enableSoundNotifications.Checked)
                            Console.Beep(420, 250);

                        ProcessStartInfo blockIn = new ProcessStartInfo("cmd.exe");
                        ProcessStartInfo blockOut = new ProcessStartInfo("cmd.exe");
                        blockIn.WindowStyle = ProcessWindowStyle.Hidden;
                        blockOut.WindowStyle = ProcessWindowStyle.Hidden;

                        randomRuleName = randomString(10);

                        blockIn.Arguments = "/C netsh advfirewall firewall add rule name=\"" + randomRuleName + "\" dir=in action=block program=\"" + filePath + "\" enable=yes";
                        blockOut.Arguments = "/C netsh advfirewall firewall add rule name=\"" + randomRuleName + "\" dir=out action=block program=\"" + filePath + "\" enable=yes";

                        Process.Start(blockIn);
                        Process.Start(blockOut);

                        statusLabel.ForeColor = Color.Blue;
                        statusLabel.Text = "Lagging!";
                        isLagging = true;

                        button1.Enabled = false;
                    }
                    else
                    {
                        if(enableSoundNotifications.Checked)
                            Console.Beep(1250, 250);

                        ProcessStartInfo ruleDeleter = new ProcessStartInfo("cmd.exe");
                        ruleDeleter.WindowStyle = ProcessWindowStyle.Hidden;
                        ruleDeleter.Arguments = "/C netsh advfirewall firewall delete rule name=\""+ randomRuleName + "\" program=\"" + filePath + "\"";

                        Process.Start(ruleDeleter);
                        button1.Enabled = true;
                        statusLabel.ForeColor = Color.Green;
                        statusLabel.Text = "Ready!";
                        isLagging = false;
                    }
                }
            }
        }

        private void laggerEnabled_CheckedChanged(object sender, EventArgs e)
        {
            statusUpdater();
        }
    }
}
