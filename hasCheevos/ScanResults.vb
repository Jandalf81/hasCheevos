Imports System.Text.RegularExpressions

Public Class ScanResults
    Public scanResults As New List(Of ScanResult)

    Public Sub New()
    End Sub

    Public Sub writePlaylist(toFile As String)
        Dim content As String

        ' start of file
        content = "{" & vbCrLf &
            vbTab & """version"": ""1.0""," & vbCrLf &
            vbTab & """items"": [" & vbCrLf

        ' for each item...
        For Each item In scanResults
            If item.HasCheevos = True Then
                content += vbTab & vbTab & "{" & vbCrLf &
                vbTab & vbTab & vbTab & """path"": """ & item.File.Replace("\", "\\") & """," & vbCrLf &
                vbTab & vbTab & vbTab & """label"": """ & item.Name & """," & vbCrLf &
                vbTab & vbTab & vbTab & """core_path"": ""DETECT""," & vbCrLf &
                vbTab & vbTab & vbTab & """core_name"": ""DETECT""," & vbCrLf &
                vbTab & vbTab & vbTab & """crc32"": ""DETECT""," & vbCrLf &
                vbTab & vbTab & vbTab & """db_name"": """ & System.IO.Path.GetFileName(toFile) & """" & vbCrLf &
                vbTab & vbTab & "}," & vbCrLf
            End If
        Next

        ' clean last entry
        content = Regex.Replace(content, "},\r\n$", "}" & vbCrLf, RegexOptions.IgnoreCase)

        ' end of file
        content += vbTab & "]" & vbCrLf &
            "}"

        ' write content to file
        Dim file As System.IO.StreamWriter

        file = My.Computer.FileSystem.OpenTextFileWriter(toFile, False)
        file.Write(content)

        file.Close()
        file.Dispose()
    End Sub
End Class
