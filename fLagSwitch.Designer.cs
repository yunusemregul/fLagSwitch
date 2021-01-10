using System.Drawing;

namespace fLagSwitch
{
    partial class fLagSwitch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLagSwitch));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lagTogglerKeyEntry = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.enableSoundNotifications = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.laggerEnabled = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.toggleLag = new System.Windows.Forms.CheckBox();
            this.lagInSecondsLayoutBox = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.lagInSecondsTextbox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.button_change = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.lagInSecondsLayoutBox.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 20);
            this.button1.TabIndex = 0;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose the path to your program that will be lagged:";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(84, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(216, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(3, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(297, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter your lagger shortcut:";
            // 
            // lagTogglerKeyEntry
            // 
            this.lagTogglerKeyEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lagTogglerKeyEntry.Location = new System.Drawing.Point(74, 3);
            this.lagTogglerKeyEntry.Name = "lagTogglerKeyEntry";
            this.lagTogglerKeyEntry.Size = new System.Drawing.Size(155, 20);
            this.lagTogglerKeyEntry.TabIndex = 4;
            this.lagTogglerKeyEntry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTogglerShortcutSpecified);
            this.lagTogglerKeyEntry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnTogglerShortcutKeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Status:";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.statusLabel.ForeColor = System.Drawing.Color.Red;
            this.statusLabel.Location = new System.Drawing.Point(49, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(24, 13);
            this.statusLabel.TabIndex = 6;
            this.statusLabel.Text = "test";
            // 
            // enableSoundNotifications
            // 
            this.enableSoundNotifications.AutoSize = true;
            this.enableSoundNotifications.Checked = true;
            this.enableSoundNotifications.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableSoundNotifications.Dock = System.Windows.Forms.DockStyle.Top;
            this.enableSoundNotifications.Location = new System.Drawing.Point(3, 145);
            this.enableSoundNotifications.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.enableSoundNotifications.Name = "enableSoundNotifications";
            this.enableSoundNotifications.Size = new System.Drawing.Size(297, 17);
            this.enableSoundNotifications.TabIndex = 7;
            this.enableSoundNotifications.Text = "Sound notifications";
            this.enableSoundNotifications.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel5);
            this.flowLayoutPanel1.Controls.Add(this.enableSoundNotifications);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(8);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(307, 185);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.textBox1);
            this.flowLayoutPanel2.Controls.Add(this.button1);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 13);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(303, 26);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.AutoSize = true;
            this.flowLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel4.Controls.Add(this.laggerEnabled);
            this.flowLayoutPanel4.Controls.Add(this.lagTogglerKeyEntry);
            this.flowLayoutPanel4.Controls.Add(this.button_change);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(0, 61);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(303, 26);
            this.flowLayoutPanel4.TabIndex = 9;
            // 
            // laggerEnabled
            // 
            this.laggerEnabled.AutoSize = true;
            this.laggerEnabled.Checked = true;
            this.laggerEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.laggerEnabled.Dock = System.Windows.Forms.DockStyle.Left;
            this.laggerEnabled.Location = new System.Drawing.Point(3, 5);
            this.laggerEnabled.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.laggerEnabled.Name = "laggerEnabled";
            this.laggerEnabled.Size = new System.Drawing.Size(65, 18);
            this.laggerEnabled.TabIndex = 9;
            this.laggerEnabled.Text = "Enabled";
            this.laggerEnabled.UseVisualStyleBackColor = true;
            this.laggerEnabled.CheckedChanged += new System.EventHandler(this.laggerEnabled_CheckedChanged);
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.AutoSize = true;
            this.flowLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel5.Controls.Add(this.toggleLag);
            this.flowLayoutPanel5.Controls.Add(this.lagInSecondsLayoutBox);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel5.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(0, 93);
            this.flowLayoutPanel5.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(303, 46);
            this.flowLayoutPanel5.TabIndex = 9;
            // 
            // toggleLag
            // 
            this.toggleLag.AutoSize = true;
            this.toggleLag.Checked = true;
            this.toggleLag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toggleLag.Location = new System.Drawing.Point(3, 3);
            this.toggleLag.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.toggleLag.Name = "toggleLag";
            this.toggleLag.Size = new System.Drawing.Size(76, 17);
            this.toggleLag.TabIndex = 0;
            this.toggleLag.Text = "Toggle lag";
            this.toggleLag.UseVisualStyleBackColor = true;
            this.toggleLag.CheckedChanged += new System.EventHandler(this.toggleLag_CheckedChanged);
            // 
            // lagInSecondsLayoutBox
            // 
            this.lagInSecondsLayoutBox.AutoSize = true;
            this.lagInSecondsLayoutBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lagInSecondsLayoutBox.Controls.Add(this.label4);
            this.lagInSecondsLayoutBox.Controls.Add(this.lagInSecondsTextbox);
            this.lagInSecondsLayoutBox.Enabled = false;
            this.lagInSecondsLayoutBox.Location = new System.Drawing.Point(0, 20);
            this.lagInSecondsLayoutBox.Margin = new System.Windows.Forms.Padding(0);
            this.lagInSecondsLayoutBox.Name = "lagInSecondsLayoutBox";
            this.lagInSecondsLayoutBox.Size = new System.Drawing.Size(297, 26);
            this.lagInSecondsLayoutBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Lag in seconds:";
            // 
            // lagInSecondsTextbox
            // 
            this.lagInSecondsTextbox.Location = new System.Drawing.Point(91, 3);
            this.lagInSecondsTextbox.Name = "lagInSecondsTextbox";
            this.lagInSecondsTextbox.Size = new System.Drawing.Size(203, 20);
            this.lagInSecondsTextbox.TabIndex = 1;
            this.lagInSecondsTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lagInSecondsTextbox_KeyPress);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel3.Controls.Add(this.label3);
            this.flowLayoutPanel3.Controls.Add(this.statusLabel);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 171);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(303, 13);
            this.flowLayoutPanel3.TabIndex = 9;
            // 
            // button_change
            // 
            this.button_change.Location = new System.Drawing.Point(235, 3);
            this.button_change.Name = "button_change";
            this.button_change.Size = new System.Drawing.Size(65, 20);
            this.button_change.TabIndex = 10;
            this.button_change.Text = "CHANGE";
            this.button_change.UseVisualStyleBackColor = true;
            this.button_change.Click += new System.EventHandler(this.button_change_Click);
            // 
            // fLagSwitch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 209);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fLagSwitch";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Text = "fLagSwitch";
            this.Load += new System.EventHandler(this.fLagSwitch_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.lagInSecondsLayoutBox.ResumeLayout(false);
            this.lagInSecondsLayoutBox.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lagTogglerKeyEntry;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.CheckBox enableSoundNotifications;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.CheckBox laggerEnabled;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.CheckBox toggleLag;
        private System.Windows.Forms.FlowLayoutPanel lagInSecondsLayoutBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox lagInSecondsTextbox;
        private System.Windows.Forms.Button button_change;
    }
}

