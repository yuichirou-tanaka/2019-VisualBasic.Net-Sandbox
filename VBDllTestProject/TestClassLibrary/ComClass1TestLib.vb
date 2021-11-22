Imports System.Runtime.InteropServices
'Imports System.Net

<ComClass(ComClass1TestLib.ClassId, ComClass1TestLib.InterfaceId, ComClass1TestLib.EventsId)> _
Public Class ComClass1TestLib

#Region "COM GUID"
    ' これらの GUID は、このクラスおよびその COM インターフェイスの COM ID を 
    ' 指定します。この値を変更すると、 
    ' 既存のクライアントはクラスにアクセスできなくなります。
    Public Const ClassId As String = "61D304A9-E4F1-4BE6-AB63-101A68B4E3BA"
    Public Const InterfaceId As String = "A7E5B494-B6DD-4FC4-A976-FBFD3A822D11"
    Public Const EventsId As String = "06BD5539-8F92-4125-A641-A02F647DA49B"

#End Region

    ' 作成可能な COM クラスにはパラメーターなしの Public Sub New() を指定しなければ 
    ' なりません。これを行わないと、クラスは COM レジストリに登録されず、 
    ' CreateObject 経由で 
    ' 作成できません。
    Public Sub New()
        MyBase.New()
    End Sub

    Public Structure TestRes
        Dim nval As Integer
        <MarshalAs(UnmanagedType.BStr)> Dim name As String
    End Structure


    Public Structure ColArgs
        Dim nR As Integer
        Dim nG As Integer
        Dim nB As Integer
        Dim nA As Integer
        Sub New(ByVal in_nR As Integer, ByVal in_nG As Integer, ByVal in_nB As Integer, ByVal in_nA As Integer)
            nR = in_nR
            nG = in_nG
            nB = in_nB
            nA = in_nA
        End Sub
        Sub Init(ByVal in_nR As Integer, ByVal in_nG As Integer, ByVal in_nB As Integer, ByVal in_nA As Integer)
            nR = in_nR
            nG = in_nG
            nB = in_nB
            nA = in_nA
        End Sub
    End Structure


    Public Sub TestRedimArray(ByRef inarray() As Integer)
        ReDim inarray(4)
    End Sub
    Public Sub TestRedimArray2(ByRef inarray() As Integer)
        inarray(0) = 3
    End Sub
    Public Sub SCalcColor(ByRef in_ColArgs As ColArgs)
        in_ColArgs.nR = 3
    End Sub

    Public Function CalcColor(ByRef in_ColArgs As ColArgs) As ColArgs
        in_ColArgs.nR = 1
        Return in_ColArgs
    End Function

    Public Function GetResult(ByRef inTestRes As TestRes) As String
        inTestRes.name = "TesAAAt"
        inTestRes.nval = 1
        Return inTestRes.name
    End Function

    Public Function GetText(ByVal url As String) As String
        Dim retVal As String = ""
        retVal = "tttttttttttt2"
        Return retVal
        'Dim wc As New WebClient()
        'Return wc.DownloadString(url)
    End Function
End Class


