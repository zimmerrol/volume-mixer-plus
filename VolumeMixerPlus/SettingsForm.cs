using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VolumeMixerPlus
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            //Program.KeyboardHook.Stop();
        }

        private void loadSettings()
        {
            _autoStartCheckBox.Checked = System.IO.File.Exists(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "VolumeMixerPlus.lnk"));
            _increaseCurrentKeyCombinationLinkLabel.Text = Program.IncreaseCurrentCurrentVolumeKeyCombinationAsString();
            _decreaseCurrentKeyCombinationLinkLabel.Text = Program.DecreaseCurrentVolumeKeyCombinationAsString();
            _muteCurrentKeyCombinationLinkLabel.Text = Program.MuteCurrentCurrentKeyCombinationAsString();

            _increaseAllKeyCombinationLinkLabel.Text = Program.IncreaseAllCurrentVolumeKeyCombinationAsString();
            _decreaseAllKeyCombinationLinkLabel.Text = Program.DecreaseAllVolumeKeyCombinationAsString();
            _muteAllKeyCombinationLinkLabel.Text = Program.MuteAllKeyCombinationAsString();

            _switchAudioDeviceLinkLabel.Text = Program.SwitchAudioDeviceKeyCombinationAsString();
        }

        private void saveSettings()
        {
            Properties.Settings.Default.IncreaseCurrentVolumeKeyCombinationAsString = Program.IncreaseCurrentCurrentVolumeKeyCombinationAsString();
            Properties.Settings.Default.DecreaseCurrentVolumeKeyCombinationAsString = Program.DecreaseCurrentVolumeKeyCombinationAsString();
            Properties.Settings.Default.MuteCurrentKeyCombinationAsString = Program.MuteCurrentCurrentKeyCombinationAsString();
            Properties.Settings.Default.IncreaseAllVolumeKeyCombinationAsString = Program.IncreaseAllCurrentVolumeKeyCombinationAsString();
            Properties.Settings.Default.DecreaseAllVolumeKeyCombinationAsString = Program.DecreaseAllVolumeKeyCombinationAsString();
            Properties.Settings.Default.MuteAllKeyCombinationAsString = Program.MuteAllKeyCombinationAsString();
            Properties.Settings.Default.SwitchAudioDeviceKeyCombinationAsString = Program.SwitchAudioDeviceKeyCombinationAsString();
            Properties.Settings.Default.Save();

            if (_autoStartCheckBox.Checked)
                addAutostart();
            else
                removeAutostart();

            Program.RefreshHotKeys();
        }

        private static void createShortcut(string path, string targetPath, string description)
        {
            ShellLink lnk = new ShellLink();
            lnk.Description = description;
            lnk.Target = targetPath;
            lnk.Save(path);
        }

        private static void addAutostart()
        {
            try
            {
                createShortcut(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "VolumeMixerPlus.lnk"), Application.ExecutablePath, "VolumeMixer+");
            }
            catch (Exception)
            {
            }
        }

        private static void removeAutostart()
        {
            try
            {
                System.IO.File.Delete(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "VolumeMixerPlus.lnk"));
            }
            catch (Exception)
            {
            }
        }

        private void _increaseCurrentKeyCombinationLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var res = KeyCombinationDialog.GetKeyCombination();
            if (res != null)
                Program.IncreaseCurrentVolumeKeyCombination = res;
            loadSettings();
        }

        private void _decreaseCurrentKeyCombinationLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var res = KeyCombinationDialog.GetKeyCombination();
            if (res != null)
                Program.DecreaseCurrentVolumeKeyCombination = res;
            loadSettings();
        }

        private void _increaseAllKeyCombinationLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var res = KeyCombinationDialog.GetKeyCombination();
            if (res != null)
                Program.IncreaseAllVolumeKeyCombination = res;
            loadSettings();
        }

        private void _decreaseAllKeyCombinationLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var res = KeyCombinationDialog.GetKeyCombination();
            if (res != null)
                Program.DecreaseAllVolumeKeyCombination = res;
            loadSettings();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            loadSettings();
        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            saveSettings();
            this.Close();
        }

        private void _aboutLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var about = new AboutForm();
            about.ShowDialog();
            about.Dispose();
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.KeyboardHook.Start();
        }

        private void _muteCurrentKeyCombinationLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var res = KeyCombinationDialog.GetKeyCombination();
            if (res != null)
                Program.MuteCurrentKeyCombination = res;
            loadSettings();
        }

        private void _muteAllKeyCombinationLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var res = KeyCombinationDialog.GetKeyCombination();
            if (res != null)
                Program.MuteAllKeyCombination = res;
            loadSettings();
        }

        private void _switchAudioDeviceLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var res = KeyCombinationDialog.GetKeyCombination();
            if (res != null)
                Program.SwitchAudioDeviceKeyCombination = res;
            loadSettings();
        }
    }
}
