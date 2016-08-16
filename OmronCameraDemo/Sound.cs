using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace OmronCameraDemo
{
    /// <summary >
    /// Camera registration (generate and play pairing sound)
    /// </summary >
    public partial class Sound : Form
    {
        string txtToken;
        ClassHvcw clsHvcw;
        System.Media.SoundPlayer player = null;

        public Sound()
        {
            InitializeComponent();
        }

        // ***** Dialog display *****
        public void SetDialog(IWin32Window owner, ClassHvcw refHvcw, string ssid, string token)
        {
            clsHvcw = refHvcw;
            textSSID.Text = ssid;
            txtToken = token;
            this.ShowDialog(owner);
        }

        // ***** Stop sound playing *****
        private void StopSound()
        {
            if (player != null)
            {
                player.Stop();
                player.Dispose();
                player = null;
            }
        }

        // ***** Start pairing (play sound)*****
        private void button1_Click(object sender, EventArgs e)
        {
            if (clsHvcw.GenerateSound(textSSID.Text, textPassword.Text, txtToken) == true)
            {
                // Read sound file
                byte[] buf = System.IO.File.ReadAllBytes(clsHvcw.SoundFile);

                // Stop when sound playing
                if (player != null)
                    StopSound();

                player = new System.Media.SoundPlayer();

                // Wav header definition
                WAVHDR wavHdr = new WAVHDR();

                uint fs = 8000;

                wavHdr.formatid = 0x0001;                                       // PCM uncompressed
                wavHdr.channel = 1;                                             // ch=1 mono
                wavHdr.fs = fs;                                                 // Frequency
                wavHdr.bytespersec = fs * 2;                                    // 16bit
                wavHdr.blocksize = 2;                                           // 16bit mono so block size (byte/sample x # of channels) is 2
                wavHdr.bitspersample = 16;                                      // bit/sample
                wavHdr.size = (uint)buf.Length;                                 // Wave data byte number
                wavHdr.fileSize = wavHdr.size + (uint)Marshal.SizeOf(wavHdr);   // Total byte number

                // Play sound through memory stream
                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream((int)wavHdr.fileSize);
                System.IO.BinaryWriter bWriter = new System.IO.BinaryWriter(memoryStream);

                // Write Wav header
                foreach (byte b in wavHdr.getByteArray())
                {
                    bWriter.Write(b);
                }
                // Write PCM data
                foreach (byte data in buf)
                {
                    bWriter.Write(data);
                }
                bWriter.Flush();

                memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                player.Stream = memoryStream;

                // Async play
                player.Play();

                // Wait until sound playing is over with following:
                // player.PlaySync();
            }
            else
            {
                MessageBox.Show("Pairing sound creation failed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary >
        /// Wav header definition
        /// </summary >
        [StructLayout(LayoutKind.Sequential)]
        public class WAVHDR
        {
            [MarshalAs(UnmanagedType.I4)]
            public UInt32 riff = 0x46464952; /* RIFF */
            [MarshalAs(UnmanagedType.I4)]
            public UInt32 fileSize;
            [MarshalAs(UnmanagedType.I4)]
            public UInt32 wave = 0x45564157; /* WAVE */
            [MarshalAs(UnmanagedType.I4)]
            public UInt32 fmt = 0x20746D66; /* fmt  */
            [MarshalAs(UnmanagedType.I4)]
            public UInt32 fmtbytes = 16;
            [MarshalAs(UnmanagedType.I2)]
            public UInt16 formatid;
            [MarshalAs(UnmanagedType.I2)]
            public UInt16 channel;
            [MarshalAs(UnmanagedType.I4)]
            public UInt32 fs;
            [MarshalAs(UnmanagedType.I4)]
            public UInt32 bytespersec;
            [MarshalAs(UnmanagedType.I2)]
            public UInt16 blocksize;
            [MarshalAs(UnmanagedType.I2)]
            public UInt16 bitspersample;
            [MarshalAs(UnmanagedType.I4)]
            public UInt32 data = 0x61746164; /* data */
            [MarshalAs(UnmanagedType.I4)]
            public UInt32 size;

            // convert the struct to byte array
            public byte[] getByteArray()
            {
                int len = Marshal.SizeOf(this);
                byte[] arr = new byte[len];
                IntPtr ptr = Marshal.AllocHGlobal(len);
                Marshal.StructureToPtr(this, ptr, true/*or false*/);
                Marshal.Copy(ptr, arr, 0, len/*or arr.Length*/);
                Marshal.FreeHGlobal(ptr);
                return arr;
            }
        }
    }
}
