
Imports System.ComponentModel
Imports System.Threading

' Copyright(c) 2005 Claudio Grazioli, http://www.grazioli.ch

' This implementation Of a nullable DateTimePicker Is a New implementation
' from scratch, but it Is based On ideas I took from this nullable 
' DateTimePickers:
' - http//www.omnitalented.com/Blog/PermaLink,guid,9ee757fe-a3e8-46f7-ad04-ef7070934dc8.aspx 
'   from Alexander Shirshov
' - http://www.codeproject.com/cs/miscctrl/Nullable_DateTimePicker.asp 
'   from Pham Minh Tri

' This code Is free software; you can redistribute it And/Or modify it.
' However, this header must remain intact And unchanged.  Additional
' information may be appended after this header.  Publications based On
' this code must also include an appropriate reference.

' This code Is distributed In the hope that it will be useful, but 
' WITHOUT ANY WARRANTY; without even the implied warranty Of MERCHANTABILITY 
' Or FITNESS FOR A PARTICULAR PURPOSE.
Namespace Windows.Controls

    ''' <summary>
    ''' Represents a Windows date time picker control. It enhances the .NET standard <b>DateTimePicker</b>
    ''' control with a ReadOnly mode as well as with the possibility to show empty values (null values).
    ''' </summary>
    Public Class NullableDateTimePicker
        Inherits DateTimePicker

#Region "Member variables"
        ' The format of the DateTimePicker control
        Private _format As DateTimePickerFormat = DateTimePickerFormat.Long

        ' The format of the DateTimePicker control as string
        Private _formatAsString As String
#End Region

#Region "コンストラクター"

        Public Sub New()
            MyBase.Format = DateTimePickerFormat.Custom
            Me.NullValue = " "
            Me.Value = Nothing
            Me.Format = DateTimePickerFormat.Long
        End Sub

#End Region

#Region "Public Property"

        ''' <summary>
        ''' ValueにNothingが設定されると、 <see cref="NullValue"/> で定めた値をDateTimePickerに表示します。
        ''' </summary>
        ''' <returns></returns>
        Public Overloads Property Value As DateTime?
            Get
                Return If(_isNull, Nothing, MyBase.Value)
            End Get
            Set(value As DateTime?)
                If value Is Nothing OrElse value.Value.ToBinary = 0 Then
                    _isNull = True
                    MyBase.CustomFormat = If(NullValue Is Nothing OrElse NullValue = String.Empty, " ", "'" + _NullValue + "'")
                Else
                    SetToDateTimeValue()
                    MyBase.Value = value
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the format of the date and time displayed in the control.
        ''' </summary>
        ''' <value>One of the <see cref="DateTimePickerFormat"/> values. The default is 
        ''' <see cref="DateTimePickerFormat.Long"/>.</value>
        <Browsable(True)>
        <DefaultValue(DateTimePickerFormat.Long), TypeConverter(GetType(System.Enum))>
        Public Overloads Property Format As DateTimePickerFormat
            Get
                Return _format
            End Get
            Set(value As DateTimePickerFormat)
                _format = value
                SetFormat()
                OnFormatChanged(EventArgs.Empty)
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the custom date/time format string.
        ''' <value>A string that represents the custom date/time format. The default Is a null
        ''' reference (<b>Nothing</b> in Visual Basic).</value>
        ''' </summary>
        ''' <returns></returns>
        Public Overloads Property CustomFormat As String

        ' If _isNull = true, this value Is shown in the DTP

        ''' <summary>
        ''' Gets or sets the string value that is assigned to the control as null value. 
        ''' </summary>
        ''' <value>The string value assigned to the control as null value.</value>
        ''' <remarks>
        ''' If the <see cref="Value"/> Is <b>null</b>, <b>NullValue</b> Is shown in the <b>DateTimePicker</b> control.
        ''' </remarks>
        <Browsable(True)>
        <Category("Behavior")>
        <Description("The string used to display null values in the control")>
        <DefaultValue(" ")>
        Public Property NullValue As String

        ''' <summary>
        ''' 日付が Null/Nothing である場合はTrueになります。
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property IsNull As Boolean

#End Region

#Region "Private Function/Sub"
        Private Sub SetToDateTimeValue()
            If _isNull Then
                SetFormat()
                _isNull = False
                MyBase.OnValueChanged(New EventArgs)
            End If
        End Sub

        Private Sub SetFormat()
            Dim ci = Thread.CurrentThread.CurrentCulture
            Dim dtf = ci.DateTimeFormat

            Select Case _format
                Case DateTimePickerFormat.Long
                    MyBase.CustomFormat = dtf.LongDatePattern
                Case DateTimePickerFormat.Short
                    MyBase.CustomFormat = dtf.ShortDatePattern
                Case DateTimePickerFormat.Time
                    MyBase.CustomFormat = dtf.ShortTimePattern
                Case DateTimePickerFormat.Custom
                    MyBase.CustomFormat = Me.CustomFormat
            End Select
        End Sub
#End Region

#Region "Events"
        ''' <summary>
        ''' This member overrides <see cref="DateTimePicker.OnCloseUp"/>.
        ''' </summary>
        ''' <param name="e"></param>
        Protected Overrides Sub OnCloseUp(e As EventArgs)
            If Control.MouseButtons = MouseButtons.None AndAlso _isNull Then
                SetToDateTimeValue()
                _isNull = False
            End If
            MyBase.OnCloseUp(e)
        End Sub

        ''' <summary>
        ''' This member overrides <see cref="Control.OnKeyDown"/>.
        ''' </summary>
        ''' <param name="e"></param>
        Protected Overrides Sub OnKeyUp(e As KeyEventArgs)
            If e.KeyCode = Keys.Delete Then
                Me.Value = Nothing
                OnValueChanged(EventArgs.Empty)
            End If
            MyBase.OnKeyUp(e)
        End Sub
#End Region
    End Class
End Namespace

