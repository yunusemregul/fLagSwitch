using System;
using System.Drawing;
using System.Windows.Forms;

namespace fSwitch
{
    public partial class fLagSwitch : Form
    {
        private OpenFileDialog fileDialog;
        private bool fileSpecified = false;
        private bool keySpecified = false;

        public fLagSwitch()
        {
            InitializeComponent();
            fileDialog = new OpenFileDialog();
            fileDialog.Title = "Choose the path to your program that will be lagged:";
            fileDialog.RestoreDirectory = true;
            fileDialog.DefaultExt = "exe";
            fileDialog.CheckPathExists = true;
            fileDialog.CheckFileExists = true;
            fileDialog.Multiselect = false;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fileDialog.FileName;
                fileSpecified = true;
                statusTextUpdater();
            }
            else
            {
                fileSpecified = false;
                statusTextUpdater();
            }
        }

        private void OnTogglerShortcutKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void OnTogglerShortcutSpecified(object sender, KeyEventArgs e)
        {
            textBox2.Text = e.KeyCode.ToString();
            keySpecified = true;
            statusTextUpdater();
        }

        private void statusTextUpdater()
        {
            if (keySpecified && fileSpecified)
            {
                statusLabel.ForeColor = Color.Green;
                statusLabel.Text = "Everything is good! Waiting for lag key press...";
            }
            else
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "Waiting for settings to be filled...";
            }
        }
    }
}
