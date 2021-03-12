using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
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
        private static bool isDebugging = false;

        private OpenFileDialog fileDialog;

        private String filePath;
        private int key;

        private bool legacyMode = false;
        private bool isKeyPressing = false;
        private bool fileSpecified = false;
        private bool keySpecified = false;
        private bool ready = false;

        private bool isLagging = false;

        private Timer keyPressTimer;

        private string randomRuleName;

        private DateTime lagStartTime;

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

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

#if DEBUG
            isDebugging = true;
#endif
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (isLagging)
            {
                endLag();
            }
        }

        public static bool IsAdministrator()
        {
            if (isDebugging)
                return true;

            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void fLagSwitch_Load(object sender, EventArgs e)
        {
            keyPressTimer.Start();
            statusUpdater();

            if (isDebugging)
                Text = "DEBUG MODE";
            else
                Text = randomString(random.Next(10, 20));
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

        private void lagTogglerKeyEntry_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
                return;

            if (e.Button == MouseButtons.Middle)
            {
                lagTogglerKeyEntry.Text = "Middle";
                key = 0x04; // VK_MBUTTON
            }

            if (e.Button == MouseButtons.XButton1)
            {
                lagTogglerKeyEntry.Text = "Mouse4";
                key = 0x05; // VK_XBUTTON1
            }

            if (e.Button == MouseButtons.XButton2)
            {
                lagTogglerKeyEntry.Text = "Mouse5";
                key = 0x06; // VK_XBUTTON2
            }

            ready = false;
            keySpecified = true;
            lagTogglerKeyEntry.Enabled = false;
            statusUpdater();
        }

        private async void statusUpdater()
        {
            if (!IsAdministrator())
            {
                // TODO: this looks stupid
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
                button_change.Enabled = false;
                lagLimitLayoutBox.Enabled = false;
                legacyModeCheckbox.Enabled = false;
                return;
            }

            if (!laggerEnabled.Checked)
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "You have to enable the lagger.";
                return;
            }

            if (keySpecified && (isDebugging || (legacyMode || fileSpecified)) && IsAdministrator() && (toggleLag.Checked || lagInSecondsTextbox.Text.Length > 0))
            {
                {
                    statusLabel.ForeColor = Color.Green;
                    statusLabel.Text = "Everything is good! Waiting for lag key press...";
                    await Task.Delay(1000);
                    ready = true;
                }
            }
            else
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "Waiting for settings to be filled...";
                ready = false;
            }
        }

        private void startLag()
        {
            if (!isDebugging)
            {
                if (legacyMode)
                {
                    ProcessStartInfo block = new ProcessStartInfo("cmd.exe");
                    block.WindowStyle = ProcessWindowStyle.Hidden;

                    block.Arguments = "/C ipconfig /release";

                    Process.Start(block);
                }
                else
                {
                    ProcessStartInfo blockIn = new ProcessStartInfo("cmd.exe");
                    ProcessStartInfo blockOut = new ProcessStartInfo("cmd.exe");
                    blockIn.WindowStyle = ProcessWindowStyle.Hidden;
                    blockOut.WindowStyle = ProcessWindowStyle.Hidden;

                    randomRuleName = randomString(10);

                    blockIn.Arguments = "/C netsh advfirewall firewall add rule name=\"" + randomRuleName + "\" dir=in action=block program=\"" + filePath + "\" enable=yes";
                    blockOut.Arguments = "/C netsh advfirewall firewall add rule name=\"" + randomRuleName + "\" dir=out action=block program=\"" + filePath + "\" enable=yes";

                    Process.Start(blockIn);
                    Process.Start(blockOut);
                }
            }

            lagStartTime = DateTime.Now;
            isLagging = true;

            if (enableSoundNotifications.Checked)
                Console.Beep(420, 250);

            statusLabel.ForeColor = Color.Blue;
            statusLabel.Text = "Lagging!";
            
            button1.Enabled = false;
            lagTogglerKeyEntry.Enabled = false;
            laggerEnabled.Enabled = false;
            legacyModeCheckbox.Enabled = false;
            toggleLag.Enabled = false;
            lagLimitEntry.Enabled = false;
            lagInSecondsTextbox.Enabled = false;
            button_change.Enabled = false;
            label5.Enabled = false;
            label2.Enabled = false;
            label1.Enabled = false;
        }

        private void endLag()
        {
            if (!isDebugging)
            {
                if (legacyMode)
                {
                    ProcessStartInfo unBlock = new ProcessStartInfo("cmd.exe");
                    unBlock.WindowStyle = ProcessWindowStyle.Hidden;

                    unBlock.Arguments = "/C ipconfig /renew";

                    Process.Start(unBlock);
                }
                else
                {
                    ProcessStartInfo ruleDeleter = new ProcessStartInfo("cmd.exe");
                    ruleDeleter.WindowStyle = ProcessWindowStyle.Hidden;
                    ruleDeleter.Arguments = "/C netsh advfirewall firewall delete rule name=\"" + randomRuleName + "\" program=\"" + filePath + "\"";

                    Process.Start(ruleDeleter);
                }
            }

            if (enableSoundNotifications.Checked)
                Console.Beep(1250, 250);

            laggerEnabled.Enabled = true;
            button1.Enabled = true;
            legacyModeCheckbox.Enabled = true;
            toggleLag.Enabled = true;
            lagLimitEntry.Enabled = true;
            lagInSecondsTextbox.Enabled = true;
            button_change.Enabled = true;
            label5.Enabled = true;
            label2.Enabled = true;
            label1.Enabled = true;
            statusLabel.ForeColor = Color.Green;
            statusLabel.Text = "Ready!";

            isLagging = false;
        }

        private async void keypressTimer_Tick(object sender, EventArgs e)
        {
            if (isDebugging || (keySpecified && (legacyMode || fileSpecified) && laggerEnabled.Checked))
            {
                if (ready)
                {
                    short keyState = GetAsyncKeyState(key);
                    bool isKeyPressed = ((int)keyState >> 15 & 1) == 1;

                    if (isKeyPressed && !isKeyPressing)
                    {
                        if (!isLagging)
                        {
                            startLag();

                            if (!toggleLag.Checked)
                            {
                                float lagSeconds = float.Parse(lagInSecondsTextbox.Text, new CultureInfo("en-US").NumberFormat);
                                await Task.Delay((int)(lagSeconds * 1000) + random.Next(-500, 500));
                                endLag();
                            }
                        }
                        else if (toggleLag.Checked)
                        {
                            endLag();
                        }

                        isKeyPressing = true;
                    }
                    else if (!isKeyPressed)
                    {
                        isKeyPressing = false;
                    }

                    if (isLagging && toggleLag.Checked)
                    {
                        if (lagLimitEntry.Text.Length > 0)
                        {
                            float lagSecondsLimit = float.Parse(lagLimitEntry.Text, new CultureInfo("en-US").NumberFormat);

                            if (DateTime.Now.Subtract(lagStartTime).TotalMilliseconds > lagSecondsLimit * 1000)
                            {
                                endLag();
                            }
                        }
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
            lagLimitLayoutBox.Enabled = toggleLag.Checked;
            statusUpdater();
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

        private void lagInSecondsTextbox_TextChanged(object sender, EventArgs e)
        {
            statusUpdater();
        }

        private void legacyModeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            legacyMode = legacyModeCheckbox.Checked;
            button1.Enabled = !legacyMode;
            label1.Enabled = !legacyMode;
            statusUpdater();
        }
    }
}