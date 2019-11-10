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
        Me.lbl_PathToCheck = New System.Windows.Forms.Label()
        Me.txt_PathToCheck = New System.Windows.Forms.TextBox()
        Me.btnPathToCheck = New System.Windows.Forms.Button()
        Me.lbl_PathContains = New System.Windows.Forms.Label()
        Me.cmb_System = New System.Windows.Forms.ComboBox()
        Me.btn_ScanNow = New System.Windows.Forms.Button()
        Me.txt_Log = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lbl_PathToCheck
        '
        Me.lbl_PathToCheck.AutoSize = True
        Me.lbl_PathToCheck.Location = New System.Drawing.Point(12, 9)
        Me.lbl_PathToCheck.Name = "lbl_PathToCheck"
        Me.lbl_PathToCheck.Size = New System.Drawing.Size(74, 13)
        Me.lbl_PathToCheck.TabIndex = 0
        Me.lbl_PathToCheck.Text = "Path to check"
        '
        'txt_PathToCheck
        '
        Me.txt_PathToCheck.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_PathToCheck.Location = New System.Drawing.Point(167, 6)
        Me.txt_PathToCheck.Name = "txt_PathToCheck"
        Me.txt_PathToCheck.ReadOnly = True
        Me.txt_PathToCheck.Size = New System.Drawing.Size(247, 20)
        Me.txt_PathToCheck.TabIndex = 1
        '
        'btnPathToCheck
        '
        Me.btnPathToCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPathToCheck.Location = New System.Drawing.Point(420, 4)
        Me.btnPathToCheck.Name = "btnPathToCheck"
        Me.btnPathToCheck.Size = New System.Drawing.Size(88, 23)
        Me.btnPathToCheck.TabIndex = 2
        Me.btnPathToCheck.Text = "set Path"
        Me.btnPathToCheck.UseVisualStyleBackColor = True
        '
        'lbl_PathContains
        '
        Me.lbl_PathContains.AutoSize = True
        Me.lbl_PathContains.Location = New System.Drawing.Point(12, 39)
        Me.lbl_PathContains.Name = "lbl_PathContains"
        Me.lbl_PathContains.Size = New System.Drawing.Size(136, 13)
        Me.lbl_PathContains.TabIndex = 3
        Me.lbl_PathContains.Text = "Path contains ROM files for"
        '
        'cmb_System
        '
        Me.cmb_System.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_System.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_System.FormattingEnabled = True
        Me.cmb_System.Location = New System.Drawing.Point(167, 36)
        Me.cmb_System.Name = "cmb_System"
        Me.cmb_System.Size = New System.Drawing.Size(341, 21)
        Me.cmb_System.TabIndex = 4
        '
        'btn_ScanNow
        '
        Me.btn_ScanNow.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_ScanNow.Location = New System.Drawing.Point(12, 89)
        Me.btn_ScanNow.Name = "btn_ScanNow"
        Me.btn_ScanNow.Size = New System.Drawing.Size(496, 46)
        Me.btn_ScanNow.TabIndex = 5
        Me.btn_ScanNow.Text = "Scan now!"
        Me.btn_ScanNow.UseVisualStyleBackColor = True
        '
        'txt_Log
        '
        Me.txt_Log.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Log.Location = New System.Drawing.Point(12, 141)
        Me.txt_Log.Multiline = True
        Me.txt_Log.Name = "txt_Log"
        Me.txt_Log.Size = New System.Drawing.Size(496, 232)
        Me.txt_Log.TabIndex = 6
        '
        'frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 385)
        Me.Controls.Add(Me.txt_Log)
        Me.Controls.Add(Me.btn_ScanNow)
        Me.Controls.Add(Me.cmb_System)
        Me.Controls.Add(Me.lbl_PathContains)
        Me.Controls.Add(Me.btnPathToCheck)
        Me.Controls.Add(Me.txt_PathToCheck)
        Me.Controls.Add(Me.lbl_PathToCheck)
        Me.Name = "frm_Main"
        Me.Text = "HasCheevos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_PathToCheck As Label
    Friend WithEvents txt_PathToCheck As TextBox
    Friend WithEvents btnPathToCheck As Button
    Friend WithEvents lbl_PathContains As Label
    Friend WithEvents cmb_System As ComboBox
    Friend WithEvents btn_ScanNow As Button
    Friend WithEvents txt_Log As TextBox
End Class
