Imports System.IO

Public Class DateDeleteFolder
    Public Shared Function DeleteFolder(ByVal targetPath As String, ByVal diffDay As Integer)
        If Not Directory.Exists(targetPath) Then
            Return False
        End If
        Dim deletedFlag As Boolean = False

        Dim subFolders As String() = System.IO.Directory.GetDirectories(targetPath, "*", System.IO.SearchOption.TopDirectoryOnly)
        For Each folder In subFolders
            Dim folderInfo As New System.IO.DirectoryInfo(folder)
            Dim lastDate As Date = folderInfo.LastWriteTime
            If (DateDiff(DateInterval.DayOfYear, lastDate, Now) >= diffDay) Then
                Try
                    ' サブディレクトリ内も含めすべてのファイルを取得する
                    Dim fileInfos() As System.IO.FileSystemInfo = folderInfo.GetFileSystemInfos("*", System.IO.SearchOption.AllDirectories)
                    ' ファイル属性から読み取り専用属性を外す
                    For Each fileInfo As System.IO.FileSystemInfo In fileInfos

                        ' ディレクトリまたはファイルであるかを判断する
                        If ((fileInfo.Attributes And System.IO.FileAttributes.Directory) = System.IO.FileAttributes.Directory) Then
                            ' ディレクトリの場合
                            fileInfo.Attributes = System.IO.FileAttributes.Directory
                        Else
                            ' ファイルの場合
                            fileInfo.Attributes = System.IO.FileAttributes.Normal
                        End If
                    Next
                    folderInfo.Delete(True)
                Catch ex As Exception
                    Debug.Assert(ex.Message)
                End Try
                deletedFlag = True
            End If
        Next
        Return deletedFlag
    End Function
    ''' <summary>
    ''' 半年前のフォルダ削除
    ''' </summary>
    ''' <param name="targetPath">削除フォルダ</param>
    ''' <returns>True:１つでもファイルを削除する False:１つもファイルを削除していない</returns>
    Public Shared Function CheckHalfYearDeleteFolder(ByVal targetPath As String)
        Return DeleteFolder(targetPath, 183)
    End Function
End Class
