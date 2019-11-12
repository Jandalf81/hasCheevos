Imports System.IO
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

    Public Sub setStatus(status As String)
        frm_Main.tssl_Status.Text = "Status: " & status
    End Sub

    Public Sub setScannedFiles(scannedFiles As String)
        frm_Main.tssl_ScannedFiles.Text = "Scanned Files: " & scannedFiles
    End Sub

    Public Sub setROMsWithCheevos(ROMswithCheevos As Integer)
        frm_Main.tssl_ROMsWithCheevos.Text = "ROMs with Cheevos: " & ROMswithCheevos
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

    Public Function getCRC32(file As String) As String
        Try
            Dim FS As FileStream = New FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
            Dim CRC32Result As Integer = &HFFFFFFFF
            Dim Buffer(4096) As Byte
            Dim ReadSize As Integer = 4096
            Dim Count As Integer = FS.Read(Buffer, 0, ReadSize)
            Dim CRC32Table(256) As Integer
            Dim DWPolynomial As Integer = &HEDB88320
            Dim DWCRC As Integer
            Dim i As Integer, j As Integer, n As Integer

            'CRC32 Tabelle erstellen
            For i = 0 To 255
                DWCRC = i
                For j = 8 To 1 Step -1
                    If (DWCRC And 1) Then
                        DWCRC = ((DWCRC And &HFFFFFFFE) \ 2&) And &H7FFFFFFF
                        DWCRC = DWCRC Xor DWPolynomial
                    Else
                        DWCRC = ((DWCRC And &HFFFFFFFE) \ 2&) And &H7FFFFFFF
                    End If
                Next j
                CRC32Table(i) = DWCRC
            Next i

            'CRC32 Hash berechnen
            Do While (Count > 0)
                For i = 0 To Count - 1
                    n = (CRC32Result And &HFF) Xor Buffer(i)
                    CRC32Result = ((CRC32Result And &HFFFFFF00) \ &H100) And &HFFFFFF
                    CRC32Result = CRC32Result Xor CRC32Table(n)
                Next i
                Count = FS.Read(Buffer, 0, ReadSize)
            Loop
            Return Hex(Not (CRC32Result))
        Catch ex As Exception
            Return ""
        End Try
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
