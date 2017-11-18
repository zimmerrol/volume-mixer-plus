using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VolumeMixerPlus
{
    public partial class KeyCombinationDialog : Form
    {
        public HotKey _hotKey;

        public KeyCombinationDialog()
        {
            InitializeComponent();
        }

        private void refreshLabel()
        {
            _keyCombinationLabel.Text = "";

            var data = new List<string>();

            if ((_hotKey.Modifiers & HotKey.Modifier.Alt) == HotKey.Modifier.Alt)
                data.Add("Alt");

            if ((_hotKey.Modifiers & HotKey.Modifier.Shift) == HotKey.Modifier.Shift)
                data.Add("Shift");

            if ((_hotKey.Modifiers & HotKey.Modifier.Control) == HotKey.Modifier.Control)
                data.Add("Control");

            if (_hotKey.Key != Keys.None)
                data.Add(_hotKey.Key.ToString("F"));

            _keyCombinationLabel.Text = String.Join("+", data.ToArray());
        }

        private void KeyCombinationDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Modifiers & Keys.Alt) == Keys.Alt)
                _hotKey.Modifiers |= HotKey.Modifier.Alt;

            if ((e.Modifiers & Keys.Shift) == Keys.Shift)
                _hotKey.Modifiers |= HotKey.Modifier.Shift;

            if ((e.Modifiers & Keys.Control) == Keys.Control)
                _hotKey.Modifiers |= HotKey.Modifier.Control;

            if (e.KeyValue != 0 && (e.KeyData & Keys.Menu) != Keys.Menu && (e.KeyData & Keys.ControlKey) != Keys.ControlKey)
                _hotKey.Key = e.KeyCode;

            refreshLabel();

        }

        private void _acceptButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        public static HotKey GetKeyCombination(HotKey hotKey = null)
        {
            if (hotKey == null)
                hotKey = new HotKey();

            var diag = new KeyCombinationDialog();
            diag._hotKey = hotKey;
            return diag.ShowDialog() == DialogResult.OK ? diag._hotKey : null;
        }

    }
}
