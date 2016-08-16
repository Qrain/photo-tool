Imports System.Windows.Forms
Imports HVCW.CameraControl

''' <summary >
''' OKAO parameter settings
''' </summary >
Public Class Params
    Private clsHvcw As ClassHvcw

    Public Sub New()
        InitializeComponent()
    End Sub

    ' ***** Dialog display *****
    Public Sub SetDialog(owner As IWin32Window, refHvcw As ClassHvcw)
        clsHvcw = refHvcw

        ' Get from camera current parameters
        If clsHvcw.GetParams() = ClassHvcw.HVCW_SUCCESS Then
            numericBdMin.Value = clsHvcw.sizeRange(ClassHvcw.HVCW_OKAO_SIZE_RANGE_body_nMin)
            numericBdMax.Value = clsHvcw.sizeRange(ClassHvcw.HVCW_OKAO_SIZE_RANGE_body_nMax)
            numericHdMin.Value = clsHvcw.sizeRange(ClassHvcw.HVCW_OKAO_SIZE_RANGE_hand_nMin)
            numericHdMax.Value = clsHvcw.sizeRange(ClassHvcw.HVCW_OKAO_SIZE_RANGE_hand_nMax)
            numericPdMin.Value = clsHvcw.sizeRange(ClassHvcw.HVCW_OKAO_SIZE_RANGE_pet_nMin)
            numericPdMax.Value = clsHvcw.sizeRange(ClassHvcw.HVCW_OKAO_SIZE_RANGE_pet_nMax)
            numericDtMin.Value = clsHvcw.sizeRange(ClassHvcw.HVCW_OKAO_SIZE_RANGE_face_nMin)
            numericDtMax.Value = clsHvcw.sizeRange(ClassHvcw.HVCW_OKAO_SIZE_RANGE_face_nMax)

            numericBdThresh.Value = clsHvcw.threshold(ClassHvcw.HVCW_OKAO_THRESHOLD_nBody)
            numericHdThresh.Value = clsHvcw.threshold(ClassHvcw.HVCW_OKAO_THRESHOLD_nHand)
            numericPdThresh.Value = clsHvcw.threshold(ClassHvcw.HVCW_OKAO_THRESHOLD_nPet)
            numericDtThresh.Value = clsHvcw.threshold(ClassHvcw.HVCW_OKAO_THRESHOLD_nFace)
            numericRecogThresh.Value = clsHvcw.threshold(ClassHvcw.HVCW_OKAO_THRESHOLD_nRecognition)
        End If
        Me.ShowDialog(owner)
    End Sub

    ' ***** Parameter settings *****
    Private Sub button1_Click(sender As Object, e As EventArgs)
        clsHvcw.sizeRange(ClassHvcw.HVCW_OKAO_SIZE_RANGE_body_nMin) = CInt(numericBdMin.Value)
        clsHvcw.sizeRange(ClassHvcw.HVCW_OKAO_SIZE_RANGE_body_nMax) = CInt(numericBdMax.Value)
        clsHvcw.sizeRange(ClassHvcw.HVCW_OKAO_SIZE_RANGE_hand_nMin) = CInt(numericHdMin.Value)
        clsHvcw.sizeRange(ClassHvcw.HVCW_OKAO_SIZE_RANGE_hand_nMax) = CInt(numericHdMax.Value)
        clsHvcw.sizeRange(ClassHvcw.HVCW_OKAO_SIZE_RANGE_pet_nMin) = CInt(numericPdMin.Value)
        clsHvcw.sizeRange(ClassHvcw.HVCW_OKAO_SIZE_RANGE_pet_nMax) = CInt(numericPdMax.Value)
        clsHvcw.sizeRange(ClassHvcw.HVCW_OKAO_SIZE_RANGE_face_nMin) = CInt(numericDtMin.Value)
        clsHvcw.sizeRange(ClassHvcw.HVCW_OKAO_SIZE_RANGE_face_nMax) = CInt(numericDtMax.Value)

        clsHvcw.threshold(ClassHvcw.HVCW_OKAO_THRESHOLD_nBody) = CInt(numericBdThresh.Value)
        clsHvcw.threshold(ClassHvcw.HVCW_OKAO_THRESHOLD_nHand) = CInt(numericHdThresh.Value)
        clsHvcw.threshold(ClassHvcw.HVCW_OKAO_THRESHOLD_nPet) = CInt(numericPdThresh.Value)
        clsHvcw.threshold(ClassHvcw.HVCW_OKAO_THRESHOLD_nFace) = CInt(numericDtThresh.Value)
        clsHvcw.threshold(ClassHvcw.HVCW_OKAO_THRESHOLD_nRecognition) = CInt(numericRecogThresh.Value)

        If clsHvcw.SetParams() = ClassHvcw.HVCW_SUCCESS Then
            MessageBox.Show("Parameter settings successful", "OK", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            MessageBox.Show("Parameter settings failed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End If
    End Sub
End Class