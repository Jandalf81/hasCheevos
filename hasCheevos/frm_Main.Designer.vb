<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Main
    Inherits Global.System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <Global.System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As Global.System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <Global.System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txt_PathToCheck = New System.Windows.Forms.TextBox()
        Me.btnPathToCheck = New System.Windows.Forms.Button()
        Me.lbl_PathContains = New System.Windows.Forms.Label()
        Me.cmb_System = New System.Windows.Forms.ComboBox()
        Me.btn_ScanNow = New System.Windows.Forms.Button()
        Me.txt_Log = New System.Windows.Forms.TextBox()
        Me.chk_RefreshMetadata = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.grp_ToDo = New System.Windows.Forms.GroupBox()
        Me.btn_ToDo_SetPath = New System.Windows.Forms.Button()
        Me.txt_ToDo_Path = New System.Windows.Forms.TextBox()
        Me.rad_ToDo_CreateRetroarchPlaylist = New System.Windows.Forms.RadioButton()
        Me.rad_ToDo_MoveTo = New System.Windows.Forms.RadioButton()
        Me.rad_ToDo_CopyTo = New System.Windows.Forms.RadioButton()
        Me.sstr_Strip = New System.Windows.Forms.StatusStrip()
        Me.tssl_Status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssl_ScannedFiles = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssl_ROMsWithCheevos = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dgv_ScanResults = New System.Windows.Forms.DataGridView()
        Me.tspb_Progress = New System.Windows.Forms.ToolStripProgressBar()
        Me.grp_ToDo.SuspendLayout()
        Me.sstr_Strip.SuspendLayout()
        CType(Me.dgv_ScanResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_PathToCheck
        '
        Me.txt_PathToCheck.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_PathToCheck.Location = New System.Drawing.Point(167, 6)
        Me.txt_PathToCheck.Name = "txt_PathToCheck"
        Me.txt_PathToCheck.ReadOnly = True
        Me.txt_PathToCheck.Size = New System.Drawing.Size(558, 20)
        Me.txt_PathToCheck.TabIndex = 1
        '
        'btnPathToCheck
        '
        Me.btnPathToCheck.Location = New System.Drawing.Point(12, 4)
        Me.btnPathToCheck.Name = "btnPathToCheck"
        Me.btnPathToCheck.Size = New System.Drawing.Size(149, 23)
        Me.btnPathToCheck.TabIndex = 2
        Me.btnPathToCheck.Text = "set Path to check"
        Me.btnPathToCheck.UseVisualStyleBackColor = True
        '
        'lbl_PathContains
        '
        Me.lbl_PathContains.AutoSize = True
        Me.lbl_PathContains.Location = New System.Drawing.Point(9, 39)
        Me.lbl_PathContains.Name = "lbl_PathContains"
        Me.lbl_PathContains.Size = New System.Drawing.Size(145, 13)
        Me.lbl_PathContains.TabIndex = 3
        Me.lbl_PathContains.Text = "Path contains ROM files for..."
        '
        'cmb_System
        '
        Me.cmb_System.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_System.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_System.FormattingEnabled = True
        Me.cmb_System.Location = New System.Drawing.Point(167, 36)
        Me.cmb_System.Name = "cmb_System"
        Me.cmb_System.Size = New System.Drawing.Size(558, 21)
        Me.cmb_System.TabIndex = 4
        '
        'btn_ScanNow
        '
        Me.btn_ScanNow.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_ScanNow.Location = New System.Drawing.Point(12, 208)
        Me.btn_ScanNow.Name = "btn_ScanNow"
        Me.btn_ScanNow.Size = New System.Drawing.Size(713, 46)
        Me.btn_ScanNow.TabIndex = 5
        Me.btn_ScanNow.Text = "Scan now!"
        Me.btn_ScanNow.UseVisualStyleBackColor = True
        '
        'txt_Log
        '
        Me.txt_Log.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Log.Location = New System.Drawing.Point(12, 260)
        Me.txt_Log.Multiline = True
        Me.txt_Log.Name = "txt_Log"
        Me.txt_Log.ReadOnly = True
        Me.txt_Log.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txt_Log.Size = New System.Drawing.Size(713, 51)
        Me.txt_Log.TabIndex = 6
        Me.txt_Log.WordWrap = False
        '
        'chk_RefreshMetadata
        '
        Me.chk_RefreshMetadata.AutoSize = True
        Me.chk_RefreshMetadata.Location = New System.Drawing.Point(167, 63)
        Me.chk_RefreshMetadata.Name = "chk_RefreshMetadata"
        Me.chk_RefreshMetadata.Size = New System.Drawing.Size(106, 17)
        Me.chk_RefreshMetadata.TabIndex = 7
        Me.chk_RefreshMetadata.Text = "refresh Metadata"
        Me.chk_RefreshMetadata.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(650, 63)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'grp_ToDo
        '
        Me.grp_ToDo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_ToDo.Controls.Add(Me.btn_ToDo_SetPath)
        Me.grp_ToDo.Controls.Add(Me.txt_ToDo_Path)
        Me.grp_ToDo.Controls.Add(Me.rad_ToDo_CreateRetroarchPlaylist)
        Me.grp_ToDo.Controls.Add(Me.rad_ToDo_MoveTo)
        Me.grp_ToDo.Controls.Add(Me.rad_ToDo_CopyTo)
        Me.grp_ToDo.Location = New System.Drawing.Point(12, 86)
        Me.grp_ToDo.Name = "grp_ToDo"
        Me.grp_ToDo.Size = New System.Drawing.Size(713, 116)
        Me.grp_ToDo.TabIndex = 9
        Me.grp_ToDo.TabStop = False
        Me.grp_ToDo.Text = "To Do"
        '
        'btn_ToDo_SetPath
        '
        Me.btn_ToDo_SetPath.Location = New System.Drawing.Point(6, 87)
        Me.btn_ToDo_SetPath.Name = "btn_ToDo_SetPath"
        Me.btn_ToDo_SetPath.Size = New System.Drawing.Size(143, 23)
        Me.btn_ToDo_SetPath.TabIndex = 5
        Me.btn_ToDo_SetPath.Text = "set Destination Path"
        Me.btn_ToDo_SetPath.UseVisualStyleBackColor = True
        '
        'txt_ToDo_Path
        '
        Me.txt_ToDo_Path.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_ToDo_Path.Location = New System.Drawing.Point(155, 89)
        Me.txt_ToDo_Path.Name = "txt_ToDo_Path"
        Me.txt_ToDo_Path.ReadOnly = True
        Me.txt_ToDo_Path.Size = New System.Drawing.Size(552, 20)
        Me.txt_ToDo_Path.TabIndex = 4
        '
        'rad_ToDo_CreateRetroarchPlaylist
        '
        Me.rad_ToDo_CreateRetroarchPlaylist.AutoSize = True
        Me.rad_ToDo_CreateRetroarchPlaylist.Location = New System.Drawing.Point(6, 66)
        Me.rad_ToDo_CreateRetroarchPlaylist.Name = "rad_ToDo_CreateRetroarchPlaylist"
        Me.rad_ToDo_CreateRetroarchPlaylist.Size = New System.Drawing.Size(276, 17)
        Me.rad_ToDo_CreateRetroarchPlaylist.TabIndex = 2
        Me.rad_ToDo_CreateRetroarchPlaylist.TabStop = True
        Me.rad_ToDo_CreateRetroarchPlaylist.Text = "Create Retroarch Playlist for ROMs with Cheevos in..."
        Me.rad_ToDo_CreateRetroarchPlaylist.UseVisualStyleBackColor = True
        '
        'rad_ToDo_MoveTo
        '
        Me.rad_ToDo_MoveTo.AutoSize = True
        Me.rad_ToDo_MoveTo.Location = New System.Drawing.Point(6, 43)
        Me.rad_ToDo_MoveTo.Name = "rad_ToDo_MoveTo"
        Me.rad_ToDo_MoveTo.Size = New System.Drawing.Size(173, 17)
        Me.rad_ToDo_MoveTo.TabIndex = 1
        Me.rad_ToDo_MoveTo.TabStop = True
        Me.rad_ToDo_MoveTo.Text = "Move ROMs with Cheevos to..."
        Me.rad_ToDo_MoveTo.UseVisualStyleBackColor = True
        '
        'rad_ToDo_CopyTo
        '
        Me.rad_ToDo_CopyTo.AutoSize = True
        Me.rad_ToDo_CopyTo.Location = New System.Drawing.Point(6, 20)
        Me.rad_ToDo_CopyTo.Name = "rad_ToDo_CopyTo"
        Me.rad_ToDo_CopyTo.Size = New System.Drawing.Size(170, 17)
        Me.rad_ToDo_CopyTo.TabIndex = 0
        Me.rad_ToDo_CopyTo.TabStop = True
        Me.rad_ToDo_CopyTo.Text = "Copy ROMs with Cheevos to..."
        Me.rad_ToDo_CopyTo.UseVisualStyleBackColor = True
        '
        'sstr_Strip
        '
        Me.sstr_Strip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssl_Status, Me.tssl_ScannedFiles, Me.tspb_Progress, Me.tssl_ROMsWithCheevos})
        Me.sstr_Strip.Location = New System.Drawing.Point(0, 544)
        Me.sstr_Strip.Name = "sstr_Strip"
        Me.sstr_Strip.Size = New System.Drawing.Size(737, 24)
        Me.sstr_Strip.TabIndex = 10
        Me.sstr_Strip.Text = "StatusStrip1"
        '
        'tssl_Status
        '
        Me.tssl_Status.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.tssl_Status.Name = "tssl_Status"
        Me.tssl_Status.Size = New System.Drawing.Size(65, 19)
        Me.tssl_Status.Text = "tssl_Status"
        '
        'tssl_ScannedFiles
        '
        Me.tssl_ScannedFiles.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.tssl_ScannedFiles.Name = "tssl_ScannedFiles"
        Me.tssl_ScannedFiles.Size = New System.Drawing.Size(101, 19)
        Me.tssl_ScannedFiles.Text = "tssl_ScannedFiles"
        '
        'tssl_ROMsWithCheevos
        '
        Me.tssl_ROMsWithCheevos.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.tssl_ROMsWithCheevos.Name = "tssl_ROMsWithCheevos"
        Me.tssl_ROMsWithCheevos.Size = New System.Drawing.Size(135, 19)
        Me.tssl_ROMsWithCheevos.Text = "tssl_ROMsWithCheevos"
        '
        'dgv_ScanResults
        '
        Me.dgv_ScanResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_ScanResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_ScanResults.Location = New System.Drawing.Point(12, 317)
        Me.dgv_ScanResults.Name = "dgv_ScanResults"
        Me.dgv_ScanResults.Size = New System.Drawing.Size(713, 224)
        Me.dgv_ScanResults.TabIndex = 12
        '
        'tspb_Progress
        '
        Me.tspb_Progress.Name = "tspb_Progress"
        Me.tspb_Progress.Size = New System.Drawing.Size(100, 18)
        '
        'frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 568)
        Me.Controls.Add(Me.dgv_ScanResults)
        Me.Controls.Add(Me.sstr_Strip)
        Me.Controls.Add(Me.grp_ToDo)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.chk_RefreshMetadata)
        Me.Controls.Add(Me.txt_Log)
        Me.Controls.Add(Me.btn_ScanNow)
        Me.Controls.Add(Me.cmb_System)
        Me.Controls.Add(Me.lbl_PathContains)
        Me.Controls.Add(Me.btnPathToCheck)
        Me.Controls.Add(Me.txt_PathToCheck)
        Me.Name = "frm_Main"
        Me.Text = "HasCheevos"
        Me.grp_ToDo.ResumeLayout(False)
        Me.grp_ToDo.PerformLayout()
        Me.sstr_Strip.ResumeLayout(False)
        Me.sstr_Strip.PerformLayout()
        CType(Me.dgv_ScanResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_PathToCheck As TextBox
    Friend WithEvents btnPathToCheck As Button
    Friend WithEvents lbl_PathContains As Label
    Friend WithEvents cmb_System As ComboBox
    Friend WithEvents btn_ScanNow As Button
    Friend WithEvents txt_Log As TextBox
    Friend WithEvents chk_RefreshMetadata As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents grp_ToDo As GroupBox
    Friend WithEvents btn_ToDo_SetPath As Button
    Friend WithEvents txt_ToDo_Path As TextBox
    Friend WithEvents rad_ToDo_CreateRetroarchPlaylist As RadioButton
    Friend WithEvents rad_ToDo_MoveTo As RadioButton
    Friend WithEvents rad_ToDo_CopyTo As RadioButton
    Friend WithEvents sstr_Strip As StatusStrip
    Friend WithEvents tssl_Status As ToolStripStatusLabel
    Friend WithEvents tssl_ScannedFiles As ToolStripStatusLabel
    Friend WithEvents tssl_ROMsWithCheevos As ToolStripStatusLabel
    Friend WithEvents dgv_ScanResults As DataGridView
    Friend WithEvents tspb_Progress As ToolStripProgressBar
End Class
