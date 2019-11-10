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
End Module
