Imports System.ComponentModel

Public Class frm_Main
    Private SystemList As New List(Of VGSystem)
    Private selectedSystem As VGSystem

    Private metaDir As String = My.Application.Info.DirectoryPath & "\meta"
    Private tempDir As String = My.Application.Info.DirectoryPath & "\temp"

    Private siteURL As String = "https://retroachievements.org"
    Private githubURL As String = "https://raw.githubusercontent.com/meleu/hascheevos/master/data"

    Private Sub frm_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' prepare Directories within app directory
        prepareDirectories()

        ' fill DropDown list of Systems
        initSystemList()
        cmb_System.DisplayMember = "Name"
        cmb_System.DataSource = SystemList
    End Sub

    Private Sub frm_Main_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        ' remove temporary files
        tidyUp(tempDir)
    End Sub

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

    Private Sub cmb_System_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_System.SelectedIndexChanged
        selectedSystem = cmb_System.SelectedItem
    End Sub

    Private Sub btn_ScanNow_Click(sender As Object, e As EventArgs) Handles btn_ScanNow.Click
        If (chk_RefreshMetadata.CheckState = CheckState.Checked) Then
            ' TODO getMetadata() first, clearMetadata() only when no error, then move metadata
            selectedSystem.clearMetadata(metaDir)
            selectedSystem.getMetadata(siteURL, githubURL, metaDir)
        Else
            If (selectedSystem.hasMetadata(metaDir) = False) Then
                selectedSystem.getMetadata(siteURL, githubURL, metaDir)
            End If
        End If

        selectedSystem.readMetadata(metaDir)

        selectedSystem.checkFilesForCheevos(txt_PathToCheck.Text, tempDir)

        selectedSystem.writePlaylist(tempDir & "\hasCheevos_" & selectedSystem.ShortName & ".lpl")
    End Sub
#End Region

#Region "Functions"
    Private Sub initSystemList()
        With SystemList
            .Add(New VGSystem("Sega Mega Drive", "megadrive", 1, {"*.md"}))
            .Add(New VGSystem("Nintendo N64", "n64", 2, {"*.n64", "*.v64"}))
            .Add(New VGSystem("Nintendo SuperNES", "snes", 3, {"*.sfc", "*.smc"}))
            .Add(New VGSystem("Nintendo GameBoy", "gb", 4, {"*.gb"}))
        End With
    End Sub

    Private Sub prepareDirectories()
        If (My.Computer.FileSystem.DirectoryExists(metaDir) = False) Then
            My.Computer.FileSystem.CreateDirectory(metaDir)
        End If

        If (My.Computer.FileSystem.DirectoryExists(tempDir) = False) Then
            My.Computer.FileSystem.CreateDirectory(tempDir)
        End If
    End Sub

    ' TODO remove this
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txt_Log.Clear()
        txt_PathToCheck.Text = "E:\www.github.com\hasCheevos\hasCheevos\ROMs\megadrive"
    End Sub
#End Region
End Class
