Imports System.Windows.Forms
Imports HVCW.CameraControl

''' <summary >
''' Camera registration (generate and play pairing sound)
''' </summary >
Partial Public Class Sound
    Inherits Form
    Private txtToken As String
    Private clsHvcw As ClassHvcw
    Private player As System.Media.SoundPlayer = Nothing

    Public Sub New()
        InitializeComponent()
    End Sub

    ' ***** Dialog display *****
    Public Sub SetDialog(owner As IWin32Window, refHvcw As ClassHvcw, ssid As String, token As String)
        clsHvcw = refHvcw
        textSSID.Text = ssid
        txtToken = token
        Me.ShowDialog(owner)
    End Sub

    ' ***** Stop sound playing *****
    Private Sub StopSound()
        If player IsNot Nothing Then
            player.[Stop]()
            player.Dispose()
            player = Nothing
        End If
    End Sub

    ' ***** Start pairing (play sound)*****
    Private Sub button1_Click(sender As Object, e As EventArgs)
        If clsHvcw.GenerateSound(textSSID.Text, textPassword.Text, txtToken) = True Then
            ' Read sound file
            Dim buf As Byte() = System.IO.File.ReadAllBytes(clsHvcw.SoundFile)

            ' Stop when sound playing
            If player IsNot Nothing Then
                StopSound()
            End If

            player = New System.Media.SoundPlayer()

            ' Wav header definition
            Dim wavHdr As New WAVHDR()

            Dim fs As UInteger = 8000

            wavHdr.formatid = &H1
            ' PCM uncompressed
            wavHdr.channel = 1
            ' ch=1 mono
            wavHdr.fs = fs
            ' Frequency
            wavHdr.bytespersec = fs * 2
            ' 16bit
            wavHdr.blocksize = 2
            ' 16bit mono so block size (byte/sample x # of channels) is 2
            wavHdr.bitspersample = 16
            ' bit/sample
            wavHdr.size = CUInt(buf.Length)
            ' Wave data byte number
            wavHdr.fileSize = wavHdr.size + CUInt(Marshal.SizeOf(wavHdr))
            ' Total byte number
            ' Play sound through memory stream
            Dim memoryStream As New System.IO.MemoryStream(CInt(wavHdr.fileSize))
            Dim bWriter As New System.IO.BinaryWriter(memoryStream)

            ' Write Wav header
            For Each b As Byte In wavHdr.getByteArray()
                bWriter.Write(b)
            Next
            ' Write PCM data
            For Each data As Byte In buf
                bWriter.Write(data)
            Next
            bWriter.Flush()

            memoryStream.Seek(0, System.IO.SeekOrigin.Begin)
            player.Stream = memoryStream

            ' Async play

            ' Wait until sound playing is over with following:
            ' player.PlaySync();
            player.Play()
        Else
            MessageBox.Show("Pairing sound creation failed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End If
    End Sub

    ''' <summary >
    ''' Wav header definition
    ''' </summary >
    <StructLayout(LayoutKind.Sequential)>
    Public Class WAVHDR
        <MarshalAs(UnmanagedType.I4)>
        Public riff As UInt32 = &H46464952
        ' RIFF 
        <MarshalAs(UnmanagedType.I4)>
        Public fileSize As UInt32
        <MarshalAs(UnmanagedType.I4)>
        Public wave As UInt32 = &H45564157
        ' WAVE 
        <MarshalAs(UnmanagedType.I4)>
        Public fmt As UInt32 = &H20746D66
        ' fmt  
        <MarshalAs(UnmanagedType.I4)>
        Public fmtbytes As UInt32 = 16
        <MarshalAs(UnmanagedType.I2)>
        Public formatid As UInt16
        <MarshalAs(UnmanagedType.I2)>
        Public channel As UInt16
        <MarshalAs(UnmanagedType.I4)>
        Public fs As UInt32
        <MarshalAs(UnmanagedType.I4)>
        Public bytespersec As UInt32
        <MarshalAs(UnmanagedType.I2)>
        Public blocksize As UInt16
        <MarshalAs(UnmanagedType.I2)>
        Public bitspersample As UInt16
        <MarshalAs(UnmanagedType.I4)>
        Public data As UInt32 = &H61746164
        ' data 
        <MarshalAs(UnmanagedType.I4)>
        Public size As UInt32

        ' convert the struct to byte array
        Public Function getByteArray() As Byte()
            Dim len As Integer = Marshal.SizeOf(Me)
            Dim arr As Byte() = New Byte(len - 1) {}
            Dim ptr As IntPtr = Marshal.AllocHGlobal(len)
            'or false
            Marshal.StructureToPtr(Me, ptr, True)
            'or arr.Length
            Marshal.Copy(ptr, arr, 0, len)
            Marshal.FreeHGlobal(ptr)
            Return arr
        End Function
    End Class
End Class

