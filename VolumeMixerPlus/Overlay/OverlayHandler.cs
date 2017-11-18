using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace VolumeMixerPlus.Overlay
{
    public class OverlayHandler
    {
        private OverlayForm overlayForm;

        private void setupOverlayForm()
        {
            overlayForm = new OverlayForm()
        {
            BackColor = System.Drawing.Color.FromArgb(255, 16, 16, 29),
            Enabled = false,
            Text = string.Empty,
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None,
            StartPosition = FormStartPosition.Manual,
            ShowInTaskbar = false,
            ControlBox = false,
            TopMost = true
        };
        }

        public void Show(string data)
        {
            try
            {
                if (data == null)
                    throw new ArgumentNullException("data");

                if (overlayForm != null)
                {
                    if (overlayForm.Tag != null)
                        (overlayForm.Tag as Thread).Abort();
                    ((Label)overlayForm.Controls[0]).Text = data;
                }
                else
                {
                    setupOverlayForm();

                    overlayForm.Height = 0;
                    overlayForm.Width = 10;
                    overlayForm.AutoSize = true;
                    overlayForm.AutoSizeMode = AutoSizeMode.GrowOnly;

                    var dataLabel = new Label();
                    dataLabel.Location = new System.Drawing.Point(0, 8);
                    dataLabel.Text = data;
                    dataLabel.BackColor = System.Drawing.Color.Transparent;
                    dataLabel.ForeColor = System.Drawing.Color.White;
                    dataLabel.Font = new System.Drawing.Font("Segoe UI", 12);
                    overlayForm.Controls.Add(dataLabel);

                    overlayForm.Location = new System.Drawing.Point(0, 0);
                    overlayForm.SafelyShow();
                }

                if (overlayForm.Visible)
                {
                    overlayForm.BringToFront();
                    overlayForm.Tag = new System.Threading.Thread(() =>
                           {
                               System.Threading.Thread.Sleep(1500);
                               overlayForm.Invoke(new CrossAppDomainDelegate(() =>
                                   {
                                       overlayForm.Close();
                                       overlayForm.Dispose();
                                       overlayForm = null;
                                   }));
                           });
                    (overlayForm.Tag as Thread).Start();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}