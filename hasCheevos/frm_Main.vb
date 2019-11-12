Imports System.ComponentModel
Imports System.Text.RegularExpressions

Public Class frm_Main
    Private SystemList As New List(Of VGSystem)
    Private selectedSystem As VGSystem

    Private metaDir As String = My.Application.Info.DirectoryPath & "\meta"
    Private tempDir As String = My.Application.Info.DirectoryPath & "\temp"

    Private siteURL As String = "https://retroachievements.org"
    Private githubURL As String = "https://raw.githubusercontent.com/meleu/hascheevos/master/data"

    Public bs_ScanResults As New BindingSource()
    Public scanResults As New ScanResults()

    Private Sub frm_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' prepare Directories within app directory
        prepareDirectories()

        ' fill DropDown list of Systems
        initSystemList()
        cmb_System.DisplayMember = "Name"
        cmb_System.DataSource = SystemList

        ' init controls
        initDGV_ScanResults()

        tssl_Status.Text = "Status: Waiting"
        tssl_ScannedFiles.Text = "Scanned files: 0"
        tssl_ROMsWithCheevos.Text = "ROMs with Cheevos: 0"
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

    Private Sub btn_ToDo_SetPath_Click(sender As Object, e As EventArgs) Handles btn_ToDo_SetPath.Click
        Dim fbd As New FolderBrowserDialog()

        fbd.Description = "Set the destination path"
        fbd.RootFolder = System.Environment.SpecialFolder.MyComputer
        fbd.ShowNewFolderButton = True

        If (fbd.ShowDialog() = DialogResult.OK) Then
            txt_ToDo_Path.Text = fbd.SelectedPath
        End If
    End Sub

    Private Sub btn_ScanNow_Click(sender As Object, e As EventArgs) Handles btn_ScanNow.Click
        ' If (chk_RefreshMetadata.CheckState = CheckState.Checked) Then
        '     ' TODO getMetadata() first, clearMetadata() only when no error, then move metadata
        '     selectedSystem.clearMetadata(metaDir)
        '     selectedSystem.getMetadata(siteURL, githubURL, metaDir)
        ' Else
        '     If (selectedSystem.hasMetadata(metaDir) = False) Then
        '         selectedSystem.getMetadata(siteURL, githubURL, metaDir)
        '     End If
        ' End If
        '
        ' selectedSystem.readMetadata(metaDir)
        '
        ' selectedSystem.checkFilesForCheevos(txt_PathToCheck.Text, tempDir)
        '
        ' selectedSystem.writePlaylist(tempDir & "\hasCheevos_" & selectedSystem.ShortName & ".lpl")

        ' some error checks
        If (rad_ToDo_CreateRetroarchPlaylist.Checked AndAlso txt_ToDo_Path.Text = "") Then
            MsgBox("Please set a destination path first!", vbOKOnly)

            Exit Sub
        End If

        ' Refresh or get metadata
        If (chk_RefreshMetadata.CheckState = CheckState.Checked) Then
            ' TODO getMetadata() first, clearMetadata() only when no error, then move metadata
            setStatus("Refreshing metadata...")

            selectedSystem.clearMetadata(metaDir)
            selectedSystem.getMetadata(siteURL, githubURL, metaDir)
        Else
            If (selectedSystem.hasMetadata(metaDir) = False) Then
                setStatus("Getting metadata...")

                selectedSystem.getMetadata(siteURL, githubURL, metaDir)
            End If
        End If

        ' read metadata
        setStatus("Reading metadata...")
        selectedSystem.readMetadata(metaDir)

        ' scan files for Cheevos
        setStatus("Scanning files...")

        Dim archiveExt As String() = {"*.zip"}
        Dim files = My.Computer.FileSystem.GetFiles(txt_PathToCheck.Text, FileIO.SearchOption.SearchAllSubDirectories, selectedSystem.Extensionlist.Concat(archiveExt).ToArray)

        Dim FileCount As Integer = files.Count()
        Dim scannedFiles As Integer = 0
        Dim ROMsWithCheevos As Integer = 0

        For Each file In files
            Dim retList As New List(Of ScanResult)
            retList = selectedSystem.checkFileForCheevos(file, tempDir, archiveExt)

            For Each ret In retList
                bs_ScanResults.Add(ret)

                If ret.HasCheevos = True Then ROMsWithCheevos += 1

                dgv_ScanResults.FirstDisplayedScrollingRowIndex = dgv_ScanResults.RowCount - 1
                Application.DoEvents()
            Next

            scannedFiles += 1
            setScannedFiles(scannedFiles & " / " & FileCount)
            setROMsWithCheevos(ROMsWithCheevos)

            tspb_Progress.Value = scannedFiles * 100 / FileCount
        Next

        If (rad_ToDo_CreateRetroarchPlaylist.Checked) Then
            scanResults.writePlaylist(txt_ToDo_Path.Text & "\hasCheevos_" & selectedSystem.ShortName & ".lpl")
        End If

        setStatus("Finished!")
    End Sub
#End Region

#Region "Functions"
    Private Sub initSystemList()
        With SystemList
            .Add(New VGSystem("Sega Mega Drive", "megadrive", 1, {"*.md"}))
            .Add(New VGSystem("Nintendo N64", "n64", 2, {"*.n64", "*.v64"}))
            .Add(New VGSystem("Nintendo SuperNES", "snes", 3, {"*.sfc", "*.smc"}))
            .Add(New VGSystem("Nintendo GameBoy", "gb", 4, {"*.gb"}))

            .Add(New VGSystem("Nintendo NES", "nes", 7, {"*.nes"}))
        End With
    End Sub

    Private Sub initDGV_ScanResults()
        Dim col_File As New DataGridViewTextBoxColumn()
        col_File.DataPropertyName = "File"
        col_File.Name = "File"

        Dim col_InnerFile As New DataGridViewTextBoxColumn()
        col_InnerFile.DataPropertyName = "InnerFile"
        col_InnerFile.Name = "Inner File"

        Dim col_Name As New DataGridViewTextBoxColumn()
        col_Name.DataPropertyName = "Name"
        col_Name.Name = "Name"

        Dim col_MD5 As New DataGridViewTextBoxColumn()
        col_MD5.DataPropertyName = "MD5"
        col_MD5.Name = "MD5"

        Dim col_HasCheevos As New DataGridViewTextBoxColumn()
        col_HasCheevos.DataPropertyName = "HasCheevos"
        col_HasCheevos.Name = "Has Cheevos"

        With dgv_ScanResults
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .RowHeadersVisible = False

            .Columns.Add(col_File)
            .Columns.Add(col_InnerFile)
            .Columns.Add(col_MD5)
            .Columns.Add(col_Name)
            .Columns.Add(col_HasCheevos)

            .DataSource = bs_ScanResults
        End With

        bs_ScanResults.DataSource = scanResults.scanResults
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
