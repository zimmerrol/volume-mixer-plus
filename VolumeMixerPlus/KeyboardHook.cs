using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace VolumeMixerPlus
{
    public class KeyboardHook
    {
        private static List<object> _hookProcs = new List<object>();

        private List<HotKey> _hotKeys;

        public delegate void HotKeyPressDelegate(HotKey hotKey);
        public event HotKeyPressDelegate HotKeyPressed;

        private bool _setUp;
        private IntPtr _hHook;

        public KeyboardHook()
        {
            _hotKeys = new List<HotKey>();
        }

        ~KeyboardHook()
        {
            Stop();
        }

        private VolumeMixerPlus.Win32.user32.LowLevelKeyboardProc _hookProc = null;
        private VolumeMixerPlus.Win32.user32.CBTProc _cbtHookProc = null;

        private uint shellHook;

        /// <summary>
        /// Starts the hooking process.
        /// </summary>
        public void Start()
        {
            IntPtr hInstance = Win32.kernel32.LoadLibrary("User32");
            _hookProc = new Win32.user32.LowLevelKeyboardProc(keyboardHookProc);
            _hookProcs.Add(_hookProc);
            _cbtHookProc = new Win32.user32.CBTProc(shellHookProc);
            _hookProcs.Add(_cbtHookProc);
            GC.KeepAlive(_hookProc);
            GC.KeepAlive(this);

            _hHook = Win32.user32.SetWindowsHookEx(Win32.user32.HookType.WH_KEYBOARD_LL, _hookProc, hInstance, 0);
        }

        /// <summary>
        /// Initializes the hooking process.
        /// </summary>
        private void setUp()
        {
            Start();
            _setUp = true;
        }

        /// <summary>
        /// Stops all keyboard hooks.
        /// </summary>
        public void Stop()
        {
             if (_hHook != IntPtr.Zero)
            {
                if (Win32.user32.UnhookWindowsHookEx(_hHook))
                {
                    _hHook = IntPtr.Zero;
                    _hookProcs.Remove(_hookProc);
                }

            }
        }

        /// <summary>
        /// Clear all keyboard hooks.
        /// </summary>
        public void ClearHooks()
        {
            _hotKeys.Clear();
        }

        /// <summary>
        /// Remove one specific keyboard hook.
        /// </summary>
        /// <param name="hotKey">The <c>HotKey</c> object associated to the keyboard hook.</param>
        public void RemoveHook(HotKey hotKey)
        {
            if (_hotKeys.Contains(hotKey))
                _hotKeys.Remove(hotKey);
        }

        /// <summary>
        /// Add new keyboard hook.
        /// </summary>
        /// <param name="hotKey">The <c>HotKey</c> object to be associated to the keyboard hook.</param>
        public void AddHook(HotKey hotKey)
        {
            if (!_setUp)
                setUp();

            _hotKeys.Add(hotKey);
        }

        private IntPtr shellHookProc(IntPtr hHook, int nCode, IntPtr wParam, IntPtr lParam)
        {
            IntPtr res = Win32.user32.CallNextHookEx(hHook, nCode, wParam, lParam);
            return res;
        }

        /// <summary>
        /// Handles the win32 keyboard hook.
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        private IntPtr keyboardHookProc(int nCode, IntPtr wParam, VolumeMixerPlus.Win32.user32.KBDLLHOOKSTRUCT lParam)
        {
            if (nCode >= 0)
                if (wParam.ToInt32() >= 0x0100 & wParam.ToInt32() != 257)
                {
                    foreach (var item in _hotKeys)
                    {
                        if ((int)item.Key == lParam.vkCode)
                        {
                            bool pushed = true;
                            if ((item.Modifiers & HotKey.Modifier.Control) == HotKey.Modifier.Control)
                                pushed = Win32.user32.IsKeyPushedDown(Keys.Control) | Win32.user32.IsKeyPushedDown(Keys.ControlKey);

                            if ((item.Modifiers & HotKey.Modifier.Alt) == HotKey.Modifier.Alt)
                                pushed = Win32.user32.IsKeyPushedDown(Keys.Alt) | Win32.user32.IsKeyPushedDown(Keys.Menu);

                            if ((item.Modifiers & HotKey.Modifier.Shift) == HotKey.Modifier.Shift)
                                pushed = Win32.user32.IsKeyPushedDown(Keys.Shift) | Win32.user32.IsKeyPushedDown(Keys.ShiftKey);

                            if (pushed)
                            {
                                if (wParam == (IntPtr)Win32.user32.WM_SYSKEYDOWN || wParam == (IntPtr)Win32.user32.WM_KEYDOWN)
                                    if (HotKeyPressed != null)
                                        HotKeyPressed(item);
                                return (IntPtr)1;
                            }
                        }
                    }
                }

            return Win32.user32.CallNextHookEx(_hHook, nCode, wParam, ref lParam);
        }
    }
}
