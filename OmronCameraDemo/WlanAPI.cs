using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OmronCameraDemo
{
    /// <summary >
    /// Get WLAN I/F info
    /// System32内のwlanapi.dllを利用して、無線LANインターフェース情報を取得するためのクラス。
    /// </summary >
    class WlanAPI
    {
        /** SSID */
        public string ssid = "";
        /** Mac Address */
        public string macad = "";

        //************************************************************
        #region declarations

        private const int WLAN_API_VERSION_2_0 = 2; // Windows Vista WiFi API Version
        private const int ERROR_SUCCESS = 0;

        /// <summary >
        /// Create handle
        /// </summary >
        [DllImport("wlanapi.dll", SetLastError = true)]
        private static extern UInt32 WlanOpenHandle(
            UInt32 dwClientVersion,
            IntPtr pReserved, 
            out UInt32 pdwNegotiatedVersion,
            out IntPtr phClientHandle);

        /// <summary >
        /// Delete handle
        /// </summary >
        [DllImport("wlanapi.dll", SetLastError = true)]
        private static extern UInt32 WlanCloseHandle(
            IntPtr hClientHandle,
            IntPtr pReserved);

        /// <summary >
        /// Get WLAN I/F info
        /// </summary >
        [DllImport("wlanapi.dll", SetLastError = true)]
        private static extern UInt32 WlanEnumInterfaces(IntPtr hClientHandle,
                        IntPtr pReserved, out IntPtr ppInterfaceList);

        /// <summary >
        /// Inquire to WLAN I/F
        /// </summary >
        [DllImport("Wlanapi.dll", SetLastError = true)]
        public static extern uint WlanQueryInterface(IntPtr hClientHandle,
                        [MarshalAs(UnmanagedType.LPStruct)] Guid pInterfaceGuid,
                        WLAN_INTF_OPCODE OpCode,
                        IntPtr pReserved,
                        out uint pdwDataSize,
                        ref IntPtr ppData,
                        IntPtr pWlanOpcodeValueType);

        /// <summary >
        /// Release obtained info
        /// </summary >
        [DllImport("wlanapi.dll", SetLastError = true)]
        private static extern void WlanFreeMemory(IntPtr pmemory);

        /// <summary >
        /// WLAN I/F status
        /// </summary >
        public enum WLAN_INTERFACE_STATE : int
        {
            wlan_interface_state_not_ready = 0,
            wlan_interface_state_connected,
            wlan_interface_state_ad_hoc_network_formed,
            wlan_interface_state_disconnecting,
            wlan_interface_state_disconnected,
            wlan_interface_state_associating,
            wlan_interface_state_discovering,
            wlan_interface_state_authenticating
        };

        /// <summary >
        /// WLAN I/F connection mode
        /// </summary >
        public enum WLAN_CONNECTION_MODE
        {
            wlan_connection_mode_profile,
            wlan_connection_mode_temporary_profile,
            wlan_connection_mode_discovery_secure,
            wlan_connection_mode_discovery_unsecure,
            wlan_connection_mode_auto,
            wlan_connection_mode_invalid
        };

        /// <summary >
        /// Inquiry code to WLAN I/F
        /// </summary >
        public enum WLAN_INTF_OPCODE : uint
        {
            wlan_intf_opcode_autoconf_start = 0x000000000,
            wlan_intf_opcode_autoconf_enabled,
            wlan_intf_opcode_background_scan_enabled,
            wlan_intf_opcode_media_streaming_mode,
            wlan_intf_opcode_radio_state,
            wlan_intf_opcode_bss_type,
            wlan_intf_opcode_interface_state,
            wlan_intf_opcode_current_connection,
            wlan_intf_opcode_channel_number,
            wlan_intf_opcode_supported_infrastructure_auth_cipher_pairs,
            wlan_intf_opcode_supported_adhoc_auth_cipher_pairs,
            wlan_intf_opcode_supported_country_or_region_string_list,
            wlan_intf_opcode_current_operation_mode,
            wlan_intf_opcode_supported_safe_mode,
            wlan_intf_opcode_certified_safe_mode,
            wlan_intf_opcode_hosted_network_capable,
            wlan_intf_opcode_management_frame_protection_capable,
            wlan_intf_opcode_autoconf_end = 0x0fffffff,
            wlan_intf_opcode_msm_start = 0x10000100,
            wlan_intf_opcode_statistics,
            wlan_intf_opcode_rssi,
            wlan_intf_opcode_msm_end = 0x1fffffff,
            wlan_intf_opcode_security_start = 0x20010000,
            wlan_intf_opcode_security_end = 0x2fffffff,
            wlan_intf_opcode_ihv_start = 0x30000000,
            wlan_intf_opcode_ihv_end = 0x3fffffff
        };

        /// <summary >
        /// WLAN I/F info
        /// </summary >
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct WLAN_INTERFACE_INFO
        {
            /// GUID->_GUID
            public Guid InterfaceGuid;

            /// WCHAR[256]
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string strInterfaceDescription;

            /// WLAN_INTERFACE_STATE->_WLAN_INTERFACE_STATE
            public WLAN_INTERFACE_STATE isState;
        }
        /// <summary >
        /// WLAN I/F info list
        /// 無線LANインターフェース情報リスト構造体
        /// </summary >
        [StructLayout(LayoutKind.Sequential)]
        public struct WLAN_INTERFACE_INFO_LIST
        {
            public Int32 dwNumberofItems;
            public Int32 dwIndex;
            public WLAN_INTERFACE_INFO[] InterfaceInfo;

            public WLAN_INTERFACE_INFO_LIST(IntPtr pList)
            {
                // The first 4 bytes are the number of WLAN_INTERFACE_INFO structures.
                dwNumberofItems = Marshal.ReadInt32(pList, 0);

                // The next 4 bytes are the index of the current item in the unmanaged API.
                dwIndex = Marshal.ReadInt32(pList, 4);

                // Construct the array of WLAN_INTERFACE_INFO structures.
                InterfaceInfo = new WLAN_INTERFACE_INFO[dwNumberofItems];

                for (int i = 0; i < dwNumberofItems; i++)
                {
                    // The offset of the array of structures is 8 bytes past the beginning.
                    // Then, take the index and multiply it by the number of bytes in the
                    // structure.
                    // the length of the WLAN_INTERFACE_INFO structure is 532 bytes - this
                    // was determined by doing a sizeof(WLAN_INTERFACE_INFO) in an
                    // unmanaged C++ app.
                    IntPtr pItemList = new IntPtr(pList.ToInt32() + (i * 532) + 8);

                    // Construct the WLAN_INTERFACE_INFO structure, marshal the unmanaged
                    // structure into it, then copy it to the array of structures.
                    WLAN_INTERFACE_INFO wii = new WLAN_INTERFACE_INFO();
                    wii = (WLAN_INTERFACE_INFO)Marshal.PtrToStructure(pItemList,
                        typeof(WLAN_INTERFACE_INFO));
                    InterfaceInfo[i] = wii;
                }
            }
        }

        public enum DOT11_BSS_TYPE
        {
            /// <summary>
            /// Infrastructure BSS network
            /// </summary>
            dot11_BSS_type_infrastructure = 1,

            /// <summary>
            /// Independent BSS (IBSS) network
            /// </summary>
            dot11_BSS_type_independent = 2,

            /// <summary>
            /// Either infrastructure or IBSS network
            /// </summary>
            dot11_BSS_type_any = 3,
        };

        public enum DOT11_PHY_TYPE : uint
        {
            dot11_phy_type_unknown = 0,
            dot11_phy_type_any = 0,
            dot11_phy_type_fhss = 1,
            dot11_phy_type_dsss = 2,
            dot11_phy_type_irbaseband = 3,
            dot11_phy_type_ofdm = 4,
            dot11_phy_type_hrdsss = 5,
            dot11_phy_type_erp = 6,
            dot11_phy_type_ht = 7,
            dot11_phy_type_vht = 8,
            dot11_phy_type_IHV_start = 0x80000000,
            dot11_phy_type_IHV_end = 0xffffffff
        };

        public enum DOT11_AUTH_ALGORITHM : uint
        {
            DOT11_AUTH_ALGO_80211_OPEN = 1,
            DOT11_AUTH_ALGO_80211_SHARED_KEY = 2,
            DOT11_AUTH_ALGO_WPA = 3,
            DOT11_AUTH_ALGO_WPA_PSK = 4,
            DOT11_AUTH_ALGO_WPA_NONE = 5,
            DOT11_AUTH_ALGO_RSNA = 6,
            DOT11_AUTH_ALGO_RSNA_PSK = 7,
            DOT11_AUTH_ALGO_IHV_START = 0x80000000,
            DOT11_AUTH_ALGO_IHV_END = 0xffffffff
        };

        public enum DOT11_CIPHER_ALGORITHM : uint
        {
            DOT11_CIPHER_ALGO_NONE = 0x00,
            DOT11_CIPHER_ALGO_WEP40 = 0x01,
            DOT11_CIPHER_ALGO_TKIP = 0x02,
            DOT11_CIPHER_ALGO_CCMP = 0x04,
            DOT11_CIPHER_ALGO_WEP104 = 0x05,
            DOT11_CIPHER_ALGO_WPA_USE_GROUP = 0x100,
            DOT11_CIPHER_ALGO_RSN_USE_GROUP = 0x100,
            DOT11_CIPHER_ALGO_WEP = 0x101,
            DOT11_CIPHER_ALGO_IHV_START = 0x80000000,
            DOT11_CIPHER_ALGO_IHV_END = 0xffffffff
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct DOT11_SSID
        {
            public uint uSSIDLength;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] ucSSID;

            public byte[] ToBytes()
            {
                return (ucSSID != null)
                  ? ucSSID.Take((int)uSSIDLength).ToArray()
                  : null;
            }

            private static Encoding _encoding =
                Encoding.GetEncoding(65001, // UTF-8 code page
                    EncoderFallback.ReplacementFallback,
                    DecoderFallback.ExceptionFallback);

            public override string ToString()
            {
                if (ucSSID == null)
                    return null;

                try
                {
                    return _encoding.GetString(ToBytes());
                }
                catch (DecoderFallbackException)
                {
                    return null;
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DOT11_MAC_ADDRESS
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] ucDot11MacAddress;

            public byte[] ToBytes()
            {
                return (ucDot11MacAddress != null)
                  ? ucDot11MacAddress.ToArray()
                  : null;
            }

            public override string ToString()
            {
                return (ucDot11MacAddress != null)
                    ? BitConverter.ToString(ucDot11MacAddress).Replace('-', ':')
                    : null;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WLAN_ASSOCIATION_ATTRIBUTES
        {
            public DOT11_SSID dot11Ssid;
            public DOT11_BSS_TYPE dot11BssType;
            public DOT11_MAC_ADDRESS dot11Bssid;
            public DOT11_PHY_TYPE dot11PhyType;
            public uint uDot11PhyIndex;
            public uint wlanSignalQuality;
            public uint ulRxRate;
            public uint ulTxRate;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WLAN_SECURITY_ATTRIBUTES
        {
            [MarshalAs(UnmanagedType.Bool)]
            public bool bSecurityEnabled;

            [MarshalAs(UnmanagedType.Bool)]
            public bool bOneXEnabled;

            public DOT11_AUTH_ALGORITHM dot11AuthAlgorithm;
            public DOT11_CIPHER_ALGORITHM dot11CipherAlgorithm;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct WLAN_CONNECTION_ATTRIBUTES
        {
            public WLAN_INTERFACE_STATE isState;
            public WLAN_CONNECTION_MODE wlanConnectionMode;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string strProfileName;

            public WLAN_ASSOCIATION_ATTRIBUTES wlanAssociationAttributes;
            public WLAN_SECURITY_ATTRIBUTES wlanSecurityAttributes;
        }

        public const uint WLAN_AVAILABLE_NETWORK_INCLUDE_ALL_ADHOC_PROFILES = 0x00000001;
        public const uint WLAN_AVAILABLE_NETWORK_INCLUDE_ALL_MANUAL_HIDDEN_PROFILES = 0x00000002;

        #endregion

        //************************************************************
        #region Private Functions
        /// <summary >
        /// WLAN I/F status wording
        /// </summary >
        private string getStateDescription(WLAN_INTERFACE_STATE state)
        {
            string stateDescription = string.Empty;
            switch (state)
            {
                case WLAN_INTERFACE_STATE.wlan_interface_state_not_ready:
                    stateDescription = "not ready to operate";
                    break;
                case WLAN_INTERFACE_STATE.wlan_interface_state_connected:
                    stateDescription = "connected";
                    break;
                case WLAN_INTERFACE_STATE.wlan_interface_state_ad_hoc_network_formed:
                    stateDescription = "first node in an adhoc network";
                    break;
                case WLAN_INTERFACE_STATE.wlan_interface_state_disconnecting:
                    stateDescription = "disconnecting";
                    break;
                case WLAN_INTERFACE_STATE.wlan_interface_state_disconnected:
                    stateDescription = "disconnected";
                    break;
                case WLAN_INTERFACE_STATE.wlan_interface_state_associating:
                    stateDescription = "associating";
                    break;
                case WLAN_INTERFACE_STATE.wlan_interface_state_discovering:
                    stateDescription = "discovering";
                    break;
                case WLAN_INTERFACE_STATE.wlan_interface_state_authenticating:
                    stateDescription = "authenticating";
                    break;
            }

            return stateDescription;
        }
        #endregion

        //************************************************************
        #region Public Functions

        /// <summary >
        /// Get WLAN I/F info
        /// 端末の無線LANインターフェースから接続済みのNIC情報を取得する
        /// </summary >
        public void EnumerateNICs()
        {
            uint serviceVersion = 0;
            IntPtr handle = IntPtr.Zero;
            if (WlanOpenHandle(WLAN_API_VERSION_2_0, IntPtr.Zero,
                out serviceVersion, out handle) == ERROR_SUCCESS)
            {
                IntPtr ppInterfaceList = IntPtr.Zero;
                WLAN_INTERFACE_INFO_LIST interfaceList;
                var availableNetworkList = IntPtr.Zero;
                var queryData = IntPtr.Zero;

                if (WlanEnumInterfaces(handle, IntPtr.Zero, out ppInterfaceList) == ERROR_SUCCESS)
                {
                    // Transfer all values from IntPtr to WLAN_INTERFACE_INFO_LIST structure 
                    interfaceList = new WLAN_INTERFACE_INFO_LIST(ppInterfaceList);

                    Console.WriteLine("Enumerating Wireless Network Adapters...");
                    for (int i = 0; i < interfaceList.dwNumberofItems; i++)
                    {
                        Console.WriteLine("{0}-->{1}",
                            interfaceList.InterfaceInfo[i].strInterfaceDescription,
                            getStateDescription(interfaceList.InterfaceInfo[i].isState));

                        uint dataSize;
                        if (WlanQueryInterface(handle,
                                    interfaceList.InterfaceInfo[i].InterfaceGuid,
                                    WLAN_INTF_OPCODE.wlan_intf_opcode_current_connection,
                                    IntPtr.Zero,
                                    out dataSize,
                                    ref queryData,
                                    IntPtr.Zero) != ERROR_SUCCESS)
                            continue;

                        // Connected WLAN I/F items only
                        var connection = (WLAN_CONNECTION_ATTRIBUTES)Marshal.PtrToStructure(queryData, typeof(WLAN_CONNECTION_ATTRIBUTES));
                        if (connection.isState != WLAN_INTERFACE_STATE.wlan_interface_state_connected)
                            continue;

                        var association = connection.wlanAssociationAttributes;

                        Console.WriteLine("   SSID: {0}, BSSID: {1}, Signal: {2}",
                            association.dot11Ssid,
                            association.dot11Bssid,
                            association.wlanSignalQuality);

                        // Hold WLAN I/F SSID and MAC address info
                        ssid = association.dot11Ssid.ToString();
                        macad = association.dot11Bssid.ToString();
                        break;
                    }

                    // Release memory
                    if (ppInterfaceList != IntPtr.Zero)
                        WlanFreeMemory(ppInterfaceList);
                }
                // Delete handle
                WlanCloseHandle(handle, IntPtr.Zero);
            }
        }
        #endregion
    }
}
