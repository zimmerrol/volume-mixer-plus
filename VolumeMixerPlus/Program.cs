using CSCore.CoreAudioAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace VolumeMixerPlus
{
    static class Program
    {
        public static HotKey IncreaseCurrentVolumeKeyCombination;
        public static HotKey DecreaseCurrentVolumeKeyCombination;
        public static HotKey MuteCurrentKeyCombination;

        public static HotKey IncreaseAllVolumeKeyCombination;
        public static HotKey DecreaseAllVolumeKeyCombination;
        public static HotKey MuteAllKeyCombination;


        public static HotKey SwitchAudioDeviceKeyCombination;

        public static string IncreaseCurrentCurrentVolumeKeyCombinationAsString()
        {
            return keyCombinationAsString(IncreaseCurrentVolumeKeyCombination);
        }

        public static string DecreaseCurrentVolumeKeyCombinationAsString()
        {
            return keyCombinationAsString(DecreaseCurrentVolumeKeyCombination);
        }

        public static string MuteCurrentCurrentKeyCombinationAsString()
        {
            return keyCombinationAsString(MuteCurrentKeyCombination);
        }

        public static string IncreaseAllCurrentVolumeKeyCombinationAsString()
        {
            return keyCombinationAsString(IncreaseAllVolumeKeyCombination);
        }

        public static string DecreaseAllVolumeKeyCombinationAsString()
        {
            return keyCombinationAsString(DecreaseAllVolumeKeyCombination);
        }

        public static string MuteAllKeyCombinationAsString()
        {
            return keyCombinationAsString(MuteAllKeyCombination);
        }

        public static string SwitchAudioDeviceKeyCombinationAsString()
        {
            return keyCombinationAsString(SwitchAudioDeviceKeyCombination);
        }

        private static string keyCombinationAsString(HotKey hotKey)
        {
            var data = new List<string>();

            if ((hotKey.Modifiers & HotKey.Modifier.Alt) == HotKey.Modifier.Alt)
                data.Add("Alt");

            if ((hotKey.Modifiers & HotKey.Modifier.Shift) == HotKey.Modifier.Shift)
                data.Add("Shift");

            if ((hotKey.Modifiers & HotKey.Modifier.Control) == HotKey.Modifier.Control)
                data.Add("Control");

            data.Add(hotKey.Key.ToString("F"));
            return String.Join("+", data.ToArray());
        }

        private static MMDeviceEnumerator _devEnum = new MMDeviceEnumerator();
        private static MMDevice _device;

        public static KeyboardHook KeyboardHook;

        public static Overlay.OverlayHandler OverlayHandler;

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool onlyInstance = false;
            Mutex mutex = new Mutex(true, "VolumeMixerPlus", out onlyInstance);
            if (!onlyInstance)
            {
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Properties.Settings.Default.Reload();

            RefreshHotKeys();

            var nIcon = new NotifyIcon();
            nIcon.Text = "VolumeMixer+ 0.0.0.7";
            nIcon.Icon = VolumeMixerPlus.Properties.Resources.ico;
            nIcon.ContextMenu = new ContextMenu();
            nIcon.ContextMenu.MenuItems.Add(new MenuItem("Settings...", new EventHandler((object sender, EventArgs e) =>
            {
                showSettings();
            })));

            nIcon.ContextMenu.MenuItems.Add(new MenuItem("Exit", new EventHandler((object sender, EventArgs e) =>
            {
                Application.Exit();
            })));

            nIcon.DoubleClick += (object sender, EventArgs e) =>
                {
                    showSettings();
                };

            nIcon.Visible = true;

            _device = _devEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            OverlayHandler = new Overlay.OverlayHandler();

            KeyboardHook = new KeyboardHook();
            KeyboardHook.HotKeyPressed += _keyboardHook_HotKeyPressed;
            RefreshHotKeys();
            GC.KeepAlive(mutex);
            Application.Run();
        }

        static void _keyboardHook_HotKeyPressed(HotKey hotKey)
        {
            try
            {
                if (hotKey.Equals(IncreaseCurrentVolumeKeyCombination))
                    increaseCurrentVolume();
                if (hotKey.Equals(DecreaseCurrentVolumeKeyCombination))
                    decreaseCurrentVolume();
                if (hotKey.Equals(MuteCurrentKeyCombination))
                    muteCurrent();
                if (hotKey.Equals(IncreaseAllVolumeKeyCombination))
                    increaseAllButCurrentVolume();
                if (hotKey.Equals(DecreaseAllVolumeKeyCombination))
                    decreaseAllButCurrentVolume();
                if (hotKey.Equals(MuteAllKeyCombination))
                    muteAllButCurrent();
                if (hotKey.Equals(SwitchAudioDeviceKeyCombination))
                    switchAudioDevice();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.Write(ex);
            }
        }

        private static uint getPIDOfCurrentWindow()
        {
            uint res = 0;
            Win32.user32.GetWindowThreadProcessId(Win32.user32.GetForegroundWindow(), out res);
            return res;
        }

        private static AudioSessionControl2 getCurrentAudioSessionControl()
        {
            uint PID = getPIDOfCurrentWindow();

            AudioSessionManager2 sm = AudioSessionManager2.FromMMDevice(_device);

            foreach (var item in sm.GetSessionEnumerator())
            {
                if (PID == item.AsAudioSessionControl2().ProcessID)
                {
                    return item.AsAudioSessionControl2();
                }
            }

            for (int i = 0; i < sm.GetSessionEnumerator().Count; i++)
            {
                if (sm.GetSessionEnumerator()[i].IconPath.StartsWith(@"@%SystemRoot%\System32\AudioSrv.Dll"))
                    return new AudioSessionControl2(sm.GetSessionEnumerator()[i].BasePtr);
            }

            return new AudioSessionControl2(sm.GetSessionEnumerator()[0].BasePtr);
        }

        private static void switchAudioDevice()
        {
            var endPoints = (from device in _devEnum.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active)
                             where device.DeviceState == DeviceState.Active
                             select device).ToList();

            for (int i = 0; i < endPoints.Count; i++)
            {
                if (endPoints[i].DeviceID == _device.DeviceID)
                {
                    if (i < endPoints.Count - 1)
                        _device = endPoints[i + 1];
                    else
                        _device = endPoints[0];
                    break;
                }
            }

            var pPolicyConfig = new PolicyConfigClient();
            pPolicyConfig.SetDefaultEndpoint(_device.DeviceID, Role.Multimedia);

            OverlayHandler.Show(_device.FriendlyName);
        }

        private static void increaseCurrentVolume()
        {
            increaseVolume(getCurrentAudioSessionControl(), true);
        }

        private static void decreaseCurrentVolume()
        {
            decreaseVolume(getCurrentAudioSessionControl(), true);
        }

        private static void muteCurrent()
        {
            mute(getCurrentAudioSessionControl(), true);
        }

        private static void mute(AudioSessionControl2 session, bool notifiyUser = true)
        {
            var simpleAudioVolume = session.QueryInterface<SimpleAudioVolume>();

            simpleAudioVolume.IsMuted = !simpleAudioVolume.IsMuted;

            if (notifiyUser)
            {
                OverlayHandler.Show(simpleAudioVolume.IsMuted ? "mute" : "loud");
            }
        }

        private static void increaseVolume(AudioSessionControl2 session, bool notifiyUser = true)
        {
            var simpleAudioVolume = session.QueryInterface<SimpleAudioVolume>();

            if (simpleAudioVolume.MasterVolume <= 0.85)
                simpleAudioVolume.MasterVolume += 0.05f;
            else if (simpleAudioVolume.MasterVolume <= 0.99f)
                simpleAudioVolume.MasterVolume += 0.01f;
            else
                simpleAudioVolume.MasterVolume = 1;

            if (notifiyUser)
            {
                OverlayHandler.Show(((int)(simpleAudioVolume.MasterVolume * 100)).ToString());
            }
        }

        private static void decreaseVolume(AudioSessionControl2 session, bool notifiyUser = true)
        {
            var simpleAudioVolume = session.QueryInterface<SimpleAudioVolume>();

            if (simpleAudioVolume.MasterVolume >= 0.15)
                simpleAudioVolume.MasterVolume -= 0.05f;
            else if (simpleAudioVolume.MasterVolume >= 0.01f)
                simpleAudioVolume.MasterVolume -= 0.01f;
            else
                simpleAudioVolume.MasterVolume = 0;

            if (notifiyUser)
            {
                OverlayHandler.Show(((int)(simpleAudioVolume.MasterVolume * 100)).ToString());
            }
        }

        private static void increaseAllButCurrentVolume()
        {
            AudioSessionManager2 sm = AudioSessionManager2.FromMMDevice(_device);
            foreach (var item in sm.GetSessionEnumerator())
            {
                if (item.AsAudioSessionControl2().ProcessID != getPIDOfCurrentWindow())
                {
                    increaseVolume(item.AsAudioSessionControl2(), false);
                }
            }
        }

        private static void decreaseAllButCurrentVolume()
        {
            AudioSessionManager2 sm = AudioSessionManager2.FromMMDevice(_device);
            foreach (var item in sm.GetSessionEnumerator())
            {
                if (item.AsAudioSessionControl2().ProcessID != getPIDOfCurrentWindow())
                {
                    decreaseVolume(item.AsAudioSessionControl2(), false);
                }
            }
        }

        private static void muteAllButCurrent()
        {
            AudioSessionManager2 sm = AudioSessionManager2.FromMMDevice(_device);
            foreach (var item in sm.GetSessionEnumerator())
            {
                if (item.AsAudioSessionControl2().ProcessID != getPIDOfCurrentWindow())
                {
                    mute(item.AsAudioSessionControl2(), false);
                }
            }
        }

        public static void RefreshHotKeys()
        {
            IncreaseCurrentVolumeKeyCombination = new HotKey();
            foreach (var item in Properties.Settings.Default.IncreaseCurrentVolumeKeyCombinationAsString.Split('+'))
            {
                if (!string.IsNullOrEmpty(item))
                {
                    if (item == "Alt")
                        IncreaseCurrentVolumeKeyCombination.Modifiers |= HotKey.Modifier.Alt;
                    else if (item == "Control")
                        IncreaseCurrentVolumeKeyCombination.Modifiers |= HotKey.Modifier.Control;
                    else if (item == "Shift")
                        IncreaseCurrentVolumeKeyCombination.Modifiers |= HotKey.Modifier.Shift;
                    else
                        IncreaseCurrentVolumeKeyCombination.Key = (Keys)Enum.Parse(typeof(Keys), item);

                }
            }

            DecreaseCurrentVolumeKeyCombination = new HotKey();
            foreach (var item in Properties.Settings.Default.DecreaseCurrentVolumeKeyCombinationAsString.Split('+'))
            {
                if (!string.IsNullOrEmpty(item))
                {
                    if (item == "Alt")
                        DecreaseCurrentVolumeKeyCombination.Modifiers |= HotKey.Modifier.Alt;
                    else if (item == "Control")
                        DecreaseCurrentVolumeKeyCombination.Modifiers |= HotKey.Modifier.Control;
                    else if (item == "Shift")
                        DecreaseCurrentVolumeKeyCombination.Modifiers |= HotKey.Modifier.Shift;
                    else
                        DecreaseCurrentVolumeKeyCombination.Key = (Keys)Enum.Parse(typeof(Keys), item);

                }
            }

            MuteCurrentKeyCombination = new HotKey();
            foreach (var item in Properties.Settings.Default.MuteCurrentKeyCombinationAsString.Split('+'))
            {
                if (!string.IsNullOrEmpty(item))
                {
                    if (item == "Alt")
                        MuteCurrentKeyCombination.Modifiers |= HotKey.Modifier.Alt;
                    else if (item == "Control")
                        MuteCurrentKeyCombination.Modifiers |= HotKey.Modifier.Control;
                    else if (item == "Shift")
                        MuteCurrentKeyCombination.Modifiers |= HotKey.Modifier.Shift;
                    else
                        MuteCurrentKeyCombination.Key = (Keys)Enum.Parse(typeof(Keys), item);

                }
            }

            IncreaseAllVolumeKeyCombination = new HotKey();
            foreach (var item in Properties.Settings.Default.IncreaseAllVolumeKeyCombinationAsString.Split('+'))
            {
                if (!string.IsNullOrEmpty(item))
                {
                    if (item == "Alt")
                        IncreaseAllVolumeKeyCombination.Modifiers |= HotKey.Modifier.Alt;
                    else if (item == "Control")
                        IncreaseAllVolumeKeyCombination.Modifiers |= HotKey.Modifier.Control;
                    else if (item == "Shift")
                        IncreaseAllVolumeKeyCombination.Modifiers |= HotKey.Modifier.Shift;
                    else
                        IncreaseAllVolumeKeyCombination.Key = (Keys)Enum.Parse(typeof(Keys), item);

                }
            }

            DecreaseAllVolumeKeyCombination = new HotKey();
            foreach (var item in Properties.Settings.Default.DecreaseAllVolumeKeyCombinationAsString.Split('+'))
            {
                if (!string.IsNullOrEmpty(item))
                {
                    if (item == "Alt")
                        DecreaseAllVolumeKeyCombination.Modifiers |= HotKey.Modifier.Alt;
                    else if (item == "Control")
                        DecreaseAllVolumeKeyCombination.Modifiers |= HotKey.Modifier.Control;
                    else if (item == "Shift")
                        DecreaseAllVolumeKeyCombination.Modifiers |= HotKey.Modifier.Shift;
                    else
                        DecreaseAllVolumeKeyCombination.Key = (Keys)Enum.Parse(typeof(Keys), item);

                }
            }

            MuteAllKeyCombination = new HotKey();
            foreach (var item in Properties.Settings.Default.MuteAllKeyCombinationAsString.Split('+'))
            {
                if (!string.IsNullOrEmpty(item))
                {
                    if (item == "Alt")
                        MuteAllKeyCombination.Modifiers |= HotKey.Modifier.Alt;
                    else if (item == "Control")
                        MuteAllKeyCombination.Modifiers |= HotKey.Modifier.Control;
                    else if (item == "Shift")
                        MuteAllKeyCombination.Modifiers |= HotKey.Modifier.Shift;
                    else
                        MuteAllKeyCombination.Key = (Keys)Enum.Parse(typeof(Keys), item);

                }
            }

            SwitchAudioDeviceKeyCombination = new HotKey();
            foreach (var item in Properties.Settings.Default.SwitchAudioDeviceKeyCombinationAsString.Split('+'))
            {
                if (!string.IsNullOrEmpty(item))
                {
                    if (item == "Alt")
                        SwitchAudioDeviceKeyCombination.Modifiers |= HotKey.Modifier.Alt;
                    else if (item == "Control")
                        SwitchAudioDeviceKeyCombination.Modifiers |= HotKey.Modifier.Control;
                    else if (item == "Shift")
                        SwitchAudioDeviceKeyCombination.Modifiers |= HotKey.Modifier.Shift;
                    else
                        SwitchAudioDeviceKeyCombination.Key = (Keys)Enum.Parse(typeof(Keys), item);

                }
            }

            if (KeyboardHook != null)
            {
                KeyboardHook.ClearHooks();
                KeyboardHook.AddHook(IncreaseCurrentVolumeKeyCombination);
                KeyboardHook.AddHook(DecreaseCurrentVolumeKeyCombination);
                KeyboardHook.AddHook(MuteCurrentKeyCombination);
                KeyboardHook.AddHook(IncreaseAllVolumeKeyCombination);
                KeyboardHook.AddHook(DecreaseAllVolumeKeyCombination);
                KeyboardHook.AddHook(MuteAllKeyCombination);
                KeyboardHook.AddHook(SwitchAudioDeviceKeyCombination);

                KeyboardHook.Start();
            }
        }

        private static SettingsForm sForm;

        private static void showSettings()
        {
            if (sForm != null)
                return;

            sForm = new SettingsForm();
            sForm.ShowDialog();
            sForm.Dispose();
            sForm = null;
        }

        public static AudioSessionControl2 AsAudioSessionControl2(this AudioSessionControl value)
        {
            return new AudioSessionControl2(value.BasePtr);
        }
    }
}
