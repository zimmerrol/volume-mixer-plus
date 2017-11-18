using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace VolumeMixerPlus
{
    [Guid("F8679F50-850A-41CF-9C72-430F290290C8"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPolicyConfig
    {
        [PreserveSig]
        int GetMixFormat(string pszDeviceName, IntPtr ppFormat);

        [PreserveSig]
        int GetDeviceFormat(string pszDeviceName, bool bDefault, IntPtr ppFormat);

        [PreserveSig]
        int ResetDeviceFormat(string pszDeviceName);

        [PreserveSig]
        int SetDeviceFormat(string pszDeviceName, IntPtr pEndpointFormat, IntPtr MixFormat);

        [PreserveSig]
        int GetProcessingPeriod(string pszDeviceName, bool bDefault, IntPtr pmftDefaultPeriod, IntPtr pmftMinimumPeriod);

        [PreserveSig]
        int SetProcessingPeriod(string pszDeviceName, IntPtr pmftPeriod);

        [PreserveSig]
        int GetShareMode(string pszDeviceName, IntPtr pMode);

        [PreserveSig]
        int SetShareMode(string pszDeviceName, IntPtr mode);

        [PreserveSig]
        int GetPropertyValue(string pszDeviceName, bool bFxStore, IntPtr key, IntPtr pv);

        [PreserveSig]
        int SetPropertyValue(string pszDeviceName, bool bFxStore, IntPtr key, IntPtr pv);

        [PreserveSig]
        int SetDefaultEndpoint(string pszDeviceName, CSCore.CoreAudioAPI.Role role);

        [PreserveSig]
        int SetEndpointVisibility(string pszDeviceName, bool bVisible);
    }

    [Guid("00000000-0000-0000-C000-000000000046"),
   InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPolicyConfig10
    {
        [PreserveSig]
        int GetMixFormat(string pszDeviceName, IntPtr ppFormat);

        [PreserveSig]
        int GetDeviceFormat(string pszDeviceName, bool bDefault, IntPtr ppFormat);

        [PreserveSig]
        int ResetDeviceFormat(string pszDeviceName);

        [PreserveSig]
        int SetDeviceFormat(string pszDeviceName, IntPtr pEndpointFormat, IntPtr MixFormat);

        [PreserveSig]
        int GetProcessingPeriod(string pszDeviceName, bool bDefault, IntPtr pmftDefaultPeriod, IntPtr pmftMinimumPeriod);

        [PreserveSig]
        int SetProcessingPeriod(string pszDeviceName, IntPtr pmftPeriod);

        [PreserveSig]
        int GetShareMode(string pszDeviceName, IntPtr pMode);

        [PreserveSig]
        int SetShareMode(string pszDeviceName, IntPtr mode);

        [PreserveSig]
        int GetPropertyValue(string pszDeviceName, bool bFxStore, IntPtr key, IntPtr pv);

        [PreserveSig]
        int SetPropertyValue(string pszDeviceName, bool bFxStore, IntPtr key, IntPtr pv);

        [PreserveSig]
        int SetDefaultEndpoint(string pszDeviceName, CSCore.CoreAudioAPI.Role role);

        [PreserveSig]
        int SetEndpointVisibility(string pszDeviceName, bool bVisible);
    }

    [ComImport, Guid("870AF99C-171D-4F9E-AF0D-E63DF40C2BC9")]
    internal class _PolicyConfigClient
    {
    }

    public class PolicyConfigClient
    {
        private readonly IPolicyConfig _PolicyConfig;
        private readonly IPolicyConfig10 _PolicyConfig10;

        public PolicyConfigClient()
        {
            _PolicyConfig = new _PolicyConfigClient() as IPolicyConfig;
            if (_PolicyConfig != null)
                return;

         
            _PolicyConfig10 = new _PolicyConfigClient() as IPolicyConfig10;
        }

        public void SetDefaultEndpoint(string devID, CSCore.CoreAudioAPI.Role eRole)
        {
            if (_PolicyConfig != null)
            {
                Marshal.ThrowExceptionForHR(_PolicyConfig.SetDefaultEndpoint(devID, eRole));
                return;
            }
          
            if (_PolicyConfig10 != null)
            {
                Marshal.ThrowExceptionForHR(_PolicyConfig10.SetDefaultEndpoint(devID, eRole));
            }
        }
    }
}
