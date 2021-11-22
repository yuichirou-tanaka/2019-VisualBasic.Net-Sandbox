Imports System
Imports System.IO
Imports System.IO.Ports

Public Class Form1

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim recvstr As String
        Dim i As Integer

        Try
            Button1.Enabled = False
            Button2.Enabled = False

            SerialPort1.NewLine = vbLf
            SerialPort1.ReadTimeout = 2000
            SerialPort1.Open()

            SendSetting(SerialPort1)
            FileOpen(1, "data.csv", OpenMode.Output)

            For i = 1 To 10
                SerialPort1.WriteLine(":FETCH?")
                recvstr = SerialPort1.ReadLine()
                WriteLine(1, recvstr)
            Next i

            FileClose(1)
            SerialPort1.Close()
            Button1.Enabled = True
            Button2.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub SendSetting(ByVal sp As SerialPort)
        Try
            sp.WriteLine(":TRIG:SOUR IMM")
            sp.WriteLine(":INIT:CONT ON")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "error sendsetting", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub


    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click

        Dim recvstr As String
        Dim i As Integer

        Try
            Button3.Enabled = False
            Button2.Enabled = False

            SerialPort1.NewLine = vbCrLf
            SerialPort1.ReadTimeout = 2000
            SerialPort1.Open()

            SerialPort1.WriteLine(":TRIG:SOUR IMM")
            SerialPort1.WriteLine(":INIT:CONT ON")
            FileOpen(1, "data.csv", OpenMode.Output)

            For i = 1 To 10
                SerialPort1.WriteLine(":FETCH?")
                recvstr = SerialPort1.ReadLine()
                WriteLine(1, recvstr)
            Next i

            FileClose(1)
            SerialPort1.Close()
            Button3.Enabled = True
            Button2.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    'Private Sub MeasureSub()
    '    Dim buffer As String * 20
    '    Dim recvstr As String
    '    Dim pad As Integer
    '    Dim gpibad As Integer
    '    Dim timeout As Integer
    '    Dim ud As Integer
    '    Dim i As Integer

    '    pad = 0
    '    gpibad = 1
    '    timeout = 10
    '    Call ibfind("gpib0", 0) ' GP-IB 初期化
    '    Call ibdev(pad, gpibad, 0, timeout, 1, 0, ud)
    '    Call SendIFC(pad)
    '    Open(App.Path & "¥data.csv")

    '    Call Send(pad, gpibad, ":TRIG:SOUR IMM", NLend) ' 内部トリガを選択
    '    Call Send(pad, gpibad, ":INIT:CONT ON", NLend) ' 連続測定 ON

    '    For i = 1 To 10
    '        Call Send(pad, gpibad, ":FETCH?", NLend) ' 最新の測定値取得 ":FETCH?" を送信
    '        Call Receive(pad, gpibad, Buffer, STOPend) ' 受信
    '        recvstr = Left(Buffer, InStr(1, Buffer, Chr(10)) - 1)
    '        Print #1, Str(i) & "," & recvstr ' ファイルへ書き出し
    '    Next

    '    Close #1
    '    Call ibon(pad, 0)
    'End Sub

End Class
