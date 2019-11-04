Public Class frm_Main
    Private ConsoleList As New List(Of Console)

    Dim tempDir As String = My.Application.Info.DirectoryPath & "\tmp"
    Dim siteURL As String = "https://retroachievements.org"
    Dim githubURL As String = "https://raw.githubusercontent.com/meleu/hascheevos/master/data"

#Region "GUI elements"
    Private Sub btnPathToCheck_Click(sender As Object, e As EventArgs) Handles btnPathToCheck.Click
        Dim fbd As New FolderBrowserDialog()

        fbd.Description = "Select the path containing your ROM files"
        fbd.RootFolder = System.Environment.SpecialFolder.MyComputer
        fbd.ShowNewFolderButton = False

        If (fbd.ShowDialog() = DialogResult.OK) Then
            txt_PathToCheck.Text = fbd.SelectedPath
        End If
    End Sub

    Private Sub btn_ScanNow_Click(sender As Object, e As EventArgs) Handles btn_ScanNow.Click
        refreshMetadata(cmb_PathContains.SelectedItem)
        scanROMFiles(txt_PathToCheck.Text, cmb_PathContains.SelectedItem)
    End Sub
#End Region

#Region "Functions"
    Private Sub initConsoleList()
        With ConsoleList
            .Add(New Console("Sega Mega Drive", "megadrive", 1, {"md"}))
            .Add(New Console("Nintendo N64", "n64", 2, {"n64", "v64"}))
            .Add(New Console("Nintendo SuperNES", "snes", 3, {"sfc", "smc"}))
            .Add(New Console("Nintendo GameBoy", "gb", 4, {"gb"}))
        End With
    End Sub

    Private Sub refreshMetadata(Console As Console)
        If (My.Computer.FileSystem.DirectoryExists(tempDir) = False) Then
            My.Computer.FileSystem.CreateDirectory(tempDir)
        End If

        log("Refreshing metadata files for " & Console.Name)

        log("getting hashfile...")
        If (download(siteURL & "/dorequest.php?r=hashlibrary&c=" & Console.Index, tempDir & "\" & Console.ShortName & ".json") = 0) Then
            log("got hashfile")
        Else
            log("error while getting hashfile")
        End If

        log("getting gamelist...")
        If (download(githubURL & "/" & Console.ShortName & "_hascheevos.txt", tempDir & "\" & Console.ShortName & ".txt") = 0) Then
            log("got gamelist")
        Else
            log("error while getting gamelist")
        End If
    End Sub

    Private Sub scanROMFiles(PathToCheck As String, Console As Console)
        log("reading gamelist...")
        Console.readGamelist(tempDir)
        log("found " & Console.Gamelist.Count & " games")
    End Sub

    Private Sub log(entry As String)
        txt_Log.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & vbTab & entry & vbCrLf)
    End Sub

    Public Function download(url As String, toFile As String) As Integer
        Dim wc As Net.WebClient = New Net.WebClient()
        wc.Encoding = System.Text.Encoding.UTF8

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
#End Region

    Private Sub frm_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initConsoleList()
        cmb_PathContains.DisplayMember = "Name"
        cmb_PathContains.DataSource = ConsoleList
    End Sub
End Class
