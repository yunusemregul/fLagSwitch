using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fLagSwitch
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
            #if DEBUG
                return true;
            #endif

            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void fLagSwitch_Load(object sender, EventArgs e)
        {
            keyPressTimer.Start();
            statusUpdater();
            #if DEBUG
                Text = "DEBUG MODE";
            #else
                Text = randomString(random.Next(10, 20));
            #endif
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
            lagTogglerKeyEntry.Enabled = false;
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
                toggleLag.Enabled = false;
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
#if DEBUG
                statusLabel.Text = "DEBUG MODE";
#else
                statusLabel.Text = "Waiting for settings to be filled...";
#endif
                ready = false;
            }
        }

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        private void startLag()
        {
#if DEBUG
                return;
#endif

            if (enableSoundNotifications.Checked)
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
            lagTogglerKeyEntry.Enabled = false;
            laggerEnabled.Enabled = false;

        }

        private void endLag()
        {
#if DEBUG
                return;
#endif

            if (enableSoundNotifications.Checked)
                Console.Beep(1250, 250);

            ProcessStartInfo ruleDeleter = new ProcessStartInfo("cmd.exe");
            ruleDeleter.WindowStyle = ProcessWindowStyle.Hidden;
            ruleDeleter.Arguments = "/C netsh advfirewall firewall delete rule name=\"" + randomRuleName + "\" program=\"" + filePath + "\"";

            Process.Start(ruleDeleter);

            laggerEnabled.Enabled = true;
            button1.Enabled = true;
            statusLabel.ForeColor = Color.Green;
            statusLabel.Text = "Ready!";

            isLagging = false;
        }

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
                        startLag();

                        if (!toggleLag.Checked)
                        {
                            float lagSeconds = float.Parse(lagInSecondsTextbox.Text);
                            await Task.Delay((int)(lagSeconds * 1000) + random.Next(-500, 500));
                            endLag();
                        }
                    }
                    else if (toggleLag.Checked)
                    {
                        endLag();
                    }
                }
            }
        }

        private void laggerEnabled_CheckedChanged(object sender, EventArgs e)
        {
            statusUpdater();
        }

        private void toggleLag_CheckedChanged(object sender, EventArgs e)
        {
            lagInSecondsLayoutBox.Enabled = !toggleLag.Checked;
        }

        private void lagInSecondsTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void button_change_Click(object sender, EventArgs e)
        {
            lagTogglerKeyEntry.Enabled = true;
            lagTogglerKeyEntry.Focus();
        }
    }
}