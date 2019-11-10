Imports System.IO.Compression

Module _functions
    Public Function download(url As String, toFile As String) As Integer
        Dim wc As Net.WebClient = New Net.WebClient()
        wc.Encoding = Global.System.Text.Encoding.UTF8

        ' test security protocols
        Try
            wc.DownloadFile(url, toFile)

            GoTo finish
        Catch ex As Exception

        End Try

        Try
            Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Ssl3
            wc.DownloadFile(url, toFile)

            GoTo finish
        Catch ex As Exception

        End Try

        Try
            Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls
            wc.DownloadFile(url, toFile)

            GoTo finish
        Catch ex As Exception

        End Try

        Try
            Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls11
            wc.DownloadFile(url, toFile)

            GoTo finish
        Catch ex As Exception

        End Try

        Try
            Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls12
            wc.DownloadFile(url, toFile)

            GoTo finish
        Catch ex As Exception

        End Try

        Return -1
finish:
        Return 0
    End Function

    Public Sub log(entry As String)
        frm_Main.txt_Log.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & vbTab & entry & vbCrLf)
    End Sub

    Public Function getMD5(path As String) As String
        Dim md5 = System.Security.Cryptography.MD5.Create
        Dim hash As Byte()
        Dim sb As New System.Text.StringBuilder

        Using st As New IO.FileStream(path, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
            hash = md5.ComputeHash(st)

            For Each b In hash
                sb.Append(b.ToString("X2"))
            Next
        End Using

        Return sb.ToString
    End Function

    Public Sub extractArchive(file As String, toDir As String)
        Dim fileExt As String = System.IO.Path.GetExtension(file).Replace(".", "")

        ' TODO add 7z
        Select Case fileExt
            Case "zip"
                ZipFile.ExtractToDirectory(file, toDir)
        End Select
    End Sub

    Public Sub tidyUp(path As String)
        For Each file As String In System.IO.Directory.GetFiles(path, "*.*")
            My.Computer.FileSystem.DeleteFile(file)
        Next
    End Sub
End Module
