namespace VolumeMixerPlus
{
    partial class SettingsForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this._autoStartCheckBox = new System.Windows.Forms.CheckBox();
            this._okButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._increaseCurrentKeyCombinationLinkLabel = new System.Windows.Forms.LinkLabel();
            this._decreaseCurrentKeyCombinationLinkLabel = new System.Windows.Forms.LinkLabel();
            this._aboutLinkLabel = new System.Windows.Forms.LinkLabel();
            this._muteCurrentKeyCombinationLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this._switchAudioDeviceLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this._muteAllKeyCombinationLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this._decreaseAllKeyCombinationLinkLabel = new System.Windows.Forms.LinkLabel();
            this._increaseAllKeyCombinationLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _autoStartCheckBox
            // 
            this._autoStartCheckBox.AutoSize = true;
            this._autoStartCheckBox.Location = new System.Drawing.Point(12, 12);
            this._autoStartCheckBox.Name = "_autoStartCheckBox";
            this._autoStartCheckBox.Size = new System.Drawing.Size(117, 17);
            this._autoStartCheckBox.TabIndex = 0;
            this._autoStartCheckBox.Text = "Start with Windows";
            this._autoStartCheckBox.UseVisualStyleBackColor = true;
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(156, 326);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 1;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Increase volume of\r\ncurrent app:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Decrease volume of\r\ncurrent app:";
            // 
            // _increaseCurrentKeyCombinationLinkLabel
            // 
            this._increaseCurrentKeyCombinationLinkLabel.AutoSize = true;
            this._increaseCurrentKeyCombinationLinkLabel.Location = new System.Drawing.Point(122, 32);
            this._increaseCurrentKeyCombinationLinkLabel.Name = "_increaseCurrentKeyCombinationLinkLabel";
            this._increaseCurrentKeyCombinationLinkLabel.Size = new System.Drawing.Size(29, 13);
            this._increaseCurrentKeyCombinationLinkLabel.TabIndex = 4;
            this._increaseCurrentKeyCombinationLinkLabel.TabStop = true;
            this._increaseCurrentKeyCombinationLinkLabel.Text = "keys";
            this._increaseCurrentKeyCombinationLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._increaseCurrentKeyCombinationLinkLabel_LinkClicked);
            // 
            // _decreaseCurrentKeyCombinationLinkLabel
            // 
            this._decreaseCurrentKeyCombinationLinkLabel.AutoSize = true;
            this._decreaseCurrentKeyCombinationLinkLabel.Location = new System.Drawing.Point(122, 65);
            this._decreaseCurrentKeyCombinationLinkLabel.Name = "_decreaseCurrentKeyCombinationLinkLabel";
            this._decreaseCurrentKeyCombinationLinkLabel.Size = new System.Drawing.Size(29, 13);
            this._decreaseCurrentKeyCombinationLinkLabel.TabIndex = 5;
            this._decreaseCurrentKeyCombinationLinkLabel.TabStop = true;
            this._decreaseCurrentKeyCombinationLinkLabel.Text = "keys";
            this._decreaseCurrentKeyCombinationLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._decreaseCurrentKeyCombinationLinkLabel_LinkClicked);
            // 
            // _aboutLinkLabel
            // 
            this._aboutLinkLabel.AutoSize = true;
            this._aboutLinkLabel.Location = new System.Drawing.Point(9, 326);
            this._aboutLinkLabel.Name = "_aboutLinkLabel";
            this._aboutLinkLabel.Size = new System.Drawing.Size(35, 13);
            this._aboutLinkLabel.TabIndex = 6;
            this._aboutLinkLabel.TabStop = true;
            this._aboutLinkLabel.Text = "About";
            this._aboutLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._aboutLinkLabel_LinkClicked);
            // 
            // _muteCurrentKeyCombinationLinkLabel
            // 
            this._muteCurrentKeyCombinationLinkLabel.AutoSize = true;
            this._muteCurrentKeyCombinationLinkLabel.Location = new System.Drawing.Point(122, 99);
            this._muteCurrentKeyCombinationLinkLabel.Name = "_muteCurrentKeyCombinationLinkLabel";
            this._muteCurrentKeyCombinationLinkLabel.Size = new System.Drawing.Size(29, 13);
            this._muteCurrentKeyCombinationLinkLabel.TabIndex = 8;
            this._muteCurrentKeyCombinationLinkLabel.TabStop = true;
            this._muteCurrentKeyCombinationLinkLabel.Text = "keys";
            this._muteCurrentKeyCombinationLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._muteCurrentKeyCombinationLinkLabel_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mute current\r\napp:";
            // 
            // _switchAudioDeviceLinkLabel
            // 
            this._switchAudioDeviceLinkLabel.AutoSize = true;
            this._switchAudioDeviceLinkLabel.Location = new System.Drawing.Point(122, 273);
            this._switchAudioDeviceLinkLabel.Name = "_switchAudioDeviceLinkLabel";
            this._switchAudioDeviceLinkLabel.Size = new System.Drawing.Size(29, 13);
            this._switchAudioDeviceLinkLabel.TabIndex = 10;
            this._switchAudioDeviceLinkLabel.TabStop = true;
            this._switchAudioDeviceLinkLabel.Text = "keys";
            this._switchAudioDeviceLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._switchAudioDeviceLinkLabel_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 26);
            this.label4.TabIndex = 9;
            this.label4.Text = "Switch to next\r\naudio device:";
            // 
            // _muteAllKeyCombinationLinkLabel
            // 
            this._muteAllKeyCombinationLinkLabel.AutoSize = true;
            this._muteAllKeyCombinationLinkLabel.Location = new System.Drawing.Point(122, 221);
            this._muteAllKeyCombinationLinkLabel.Name = "_muteAllKeyCombinationLinkLabel";
            this._muteAllKeyCombinationLinkLabel.Size = new System.Drawing.Size(29, 13);
            this._muteAllKeyCombinationLinkLabel.TabIndex = 16;
            this._muteAllKeyCombinationLinkLabel.TabStop = true;
            this._muteAllKeyCombinationLinkLabel.Text = "keys";
            this._muteAllKeyCombinationLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._muteAllKeyCombinationLinkLabel_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 26);
            this.label5.TabIndex = 15;
            this.label5.Text = "Mute current all but\r\nthe current app:";
            // 
            // _decreaseAllKeyCombinationLinkLabel
            // 
            this._decreaseAllKeyCombinationLinkLabel.AutoSize = true;
            this._decreaseAllKeyCombinationLinkLabel.Location = new System.Drawing.Point(122, 187);
            this._decreaseAllKeyCombinationLinkLabel.Name = "_decreaseAllKeyCombinationLinkLabel";
            this._decreaseAllKeyCombinationLinkLabel.Size = new System.Drawing.Size(29, 13);
            this._decreaseAllKeyCombinationLinkLabel.TabIndex = 14;
            this._decreaseAllKeyCombinationLinkLabel.TabStop = true;
            this._decreaseAllKeyCombinationLinkLabel.Text = "keys";
            this._decreaseAllKeyCombinationLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._decreaseAllKeyCombinationLinkLabel_LinkClicked);
            // 
            // _increaseAllKeyCombinationLinkLabel
            // 
            this._increaseAllKeyCombinationLinkLabel.AutoSize = true;
            this._increaseAllKeyCombinationLinkLabel.Location = new System.Drawing.Point(122, 154);
            this._increaseAllKeyCombinationLinkLabel.Name = "_increaseAllKeyCombinationLinkLabel";
            this._increaseAllKeyCombinationLinkLabel.Size = new System.Drawing.Size(29, 13);
            this._increaseAllKeyCombinationLinkLabel.TabIndex = 13;
            this._increaseAllKeyCombinationLinkLabel.TabStop = true;
            this._increaseAllKeyCombinationLinkLabel.Text = "keys";
            this._increaseAllKeyCombinationLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._increaseAllKeyCombinationLinkLabel_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 26);
            this.label6.TabIndex = 12;
            this.label6.Text = "Decrease volume of\r\nall but the current app:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 26);
            this.label7.TabIndex = 11;
            this.label7.Text = "Increase volume of\r\nall but the current app:";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 361);
            this.Controls.Add(this._muteAllKeyCombinationLinkLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._decreaseAllKeyCombinationLinkLabel);
            this.Controls.Add(this._increaseAllKeyCombinationLinkLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this._switchAudioDeviceLinkLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._muteCurrentKeyCombinationLinkLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._aboutLinkLabel);
            this.Controls.Add(this._decreaseCurrentKeyCombinationLinkLabel);
            this.Controls.Add(this._increaseCurrentKeyCombinationLinkLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._autoStartCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForm_FormClosed);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox _autoStartCheckBox;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel _increaseCurrentKeyCombinationLinkLabel;
        private System.Windows.Forms.LinkLabel _decreaseCurrentKeyCombinationLinkLabel;
        private System.Windows.Forms.LinkLabel _aboutLinkLabel;
        private System.Windows.Forms.LinkLabel _muteCurrentKeyCombinationLinkLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel _switchAudioDeviceLinkLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel _muteAllKeyCombinationLinkLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel _decreaseAllKeyCombinationLinkLabel;
        private System.Windows.Forms.LinkLabel _increaseAllKeyCombinationLinkLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

