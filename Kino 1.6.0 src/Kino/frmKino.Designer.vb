<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKino
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKino))
        Me.btnNextInstance = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnMinimize = New System.Windows.Forms.Button()
        Me.tlpControlBox = New System.Windows.Forms.TableLayoutPanel()
        Me.btnUpdates = New System.Windows.Forms.Button()
        Me.btnWorkingArea = New System.Windows.Forms.Button()
        Me.tbOpacity = New System.Windows.Forms.TrackBar()
        Me.btnChangeShape = New System.Windows.Forms.Button()
        Me.tlp1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblKino = New System.Windows.Forms.Label()
        Me.tlpErase = New System.Windows.Forms.Panel()
        Me.tmrFadeControls = New System.Windows.Forms.Timer(Me.components)
        Me.tmrKeys = New System.Windows.Forms.Timer(Me.components)
        Me.ttMinimize = New System.Windows.Forms.ToolTip(Me.components)
        Me.tmrCross = New System.Windows.Forms.Timer(Me.components)
        Me.tlpControlBox.SuspendLayout()
        CType(Me.tbOpacity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlp1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnNextInstance
        '
        Me.btnNextInstance.BackgroundImage = Global.Kino.My.Resources.Resources.nextScreens
        Me.btnNextInstance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tlpControlBox.SetColumnSpan(Me.btnNextInstance, 2)
        Me.btnNextInstance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNextInstance.Location = New System.Drawing.Point(3, 186)
        Me.btnNextInstance.Name = "btnNextInstance"
        Me.btnNextInstance.Size = New System.Drawing.Size(76, 26)
        Me.btnNextInstance.TabIndex = 8
        Me.btnNextInstance.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.BackgroundImage = Global.Kino.My.Resources.Resources.X
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.Location = New System.Drawing.Point(44, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(35, 31)
        Me.btnClose.TabIndex = 4
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnMinimize
        '
        Me.btnMinimize.BackColor = System.Drawing.SystemColors.Control
        Me.btnMinimize.BackgroundImage = Global.Kino.My.Resources.Resources.min
        Me.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMinimize.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnMinimize.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMinimize.ForeColor = System.Drawing.Color.Black
        Me.btnMinimize.Location = New System.Drawing.Point(3, 3)
        Me.btnMinimize.Name = "btnMinimize"
        Me.btnMinimize.Size = New System.Drawing.Size(35, 31)
        Me.btnMinimize.TabIndex = 5
        Me.ttMinimize.SetToolTip(Me.btnMinimize, "Pause" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Break")
        Me.btnMinimize.UseVisualStyleBackColor = False
        '
        'tlpControlBox
        '
        Me.tlpControlBox.ColumnCount = 3
        Me.tlpControlBox.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpControlBox.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpControlBox.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.tlpControlBox.Controls.Add(Me.btnUpdates, 0, 4)
        Me.tlpControlBox.Controls.Add(Me.btnNextInstance, 0, 3)
        Me.tlpControlBox.Controls.Add(Me.btnWorkingArea, 0, 1)
        Me.tlpControlBox.Controls.Add(Me.btnClose, 1, 0)
        Me.tlpControlBox.Controls.Add(Me.btnMinimize, 0, 0)
        Me.tlpControlBox.Controls.Add(Me.tbOpacity, 2, 0)
        Me.tlpControlBox.Controls.Add(Me.btnChangeShape, 0, 2)
        Me.tlpControlBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpControlBox.Location = New System.Drawing.Point(801, 4)
        Me.tlpControlBox.Name = "tlpControlBox"
        Me.tlpControlBox.RowCount = 5
        Me.tlp1.SetRowSpan(Me.tlpControlBox, 2)
        Me.tlpControlBox.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.tlpControlBox.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73.0!))
        Me.tlpControlBox.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73.0!))
        Me.tlpControlBox.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpControlBox.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73.0!))
        Me.tlpControlBox.Size = New System.Drawing.Size(111, 549)
        Me.tlpControlBox.TabIndex = 0
        '
        'btnUpdates
        '
        Me.btnUpdates.BackColor = System.Drawing.Color.Black
        Me.btnUpdates.BackgroundImage = Global.Kino.My.Resources.Resources.updates
        Me.btnUpdates.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tlpControlBox.SetColumnSpan(Me.btnUpdates, 2)
        Me.btnUpdates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnUpdates.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnUpdates.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple
        Me.btnUpdates.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.btnUpdates.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdates.ForeColor = System.Drawing.Color.Black
        Me.btnUpdates.Location = New System.Drawing.Point(3, 479)
        Me.btnUpdates.Name = "btnUpdates"
        Me.btnUpdates.Size = New System.Drawing.Size(76, 67)
        Me.btnUpdates.TabIndex = 9
        Me.btnUpdates.UseVisualStyleBackColor = False
        '
        'btnWorkingArea
        '
        Me.btnWorkingArea.BackColor = System.Drawing.Color.Black
        Me.btnWorkingArea.BackgroundImage = Global.Kino.My.Resources.Resources.WorkingArea
        Me.btnWorkingArea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tlpControlBox.SetColumnSpan(Me.btnWorkingArea, 2)
        Me.btnWorkingArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnWorkingArea.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnWorkingArea.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple
        Me.btnWorkingArea.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.btnWorkingArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWorkingArea.ForeColor = System.Drawing.Color.Black
        Me.btnWorkingArea.Location = New System.Drawing.Point(3, 40)
        Me.btnWorkingArea.Name = "btnWorkingArea"
        Me.btnWorkingArea.Size = New System.Drawing.Size(76, 67)
        Me.btnWorkingArea.TabIndex = 2
        Me.btnWorkingArea.Tag = "WorkingArea"
        Me.btnWorkingArea.UseVisualStyleBackColor = False
        '
        'tbOpacity
        '
        Me.tbOpacity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbOpacity.Location = New System.Drawing.Point(85, 3)
        Me.tbOpacity.Maximum = 100
        Me.tbOpacity.Minimum = 10
        Me.tbOpacity.Name = "tbOpacity"
        Me.tbOpacity.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tlpControlBox.SetRowSpan(Me.tbOpacity, 5)
        Me.tbOpacity.Size = New System.Drawing.Size(23, 543)
        Me.tbOpacity.SmallChange = 0
        Me.tbOpacity.TabIndex = 2
        Me.tbOpacity.TickFrequency = 5
        Me.tbOpacity.TickStyle = System.Windows.Forms.TickStyle.None
        Me.ttMinimize.SetToolTip(Me.tbOpacity, "Page Up/Page Down")
        Me.tbOpacity.Value = 50
        '
        'btnChangeShape
        '
        Me.btnChangeShape.BackColor = System.Drawing.Color.Black
        Me.btnChangeShape.BackgroundImage = CType(resources.GetObject("btnChangeShape.BackgroundImage"), System.Drawing.Image)
        Me.btnChangeShape.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tlpControlBox.SetColumnSpan(Me.btnChangeShape, 2)
        Me.btnChangeShape.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnChangeShape.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnChangeShape.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple
        Me.btnChangeShape.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.btnChangeShape.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangeShape.ForeColor = System.Drawing.Color.Black
        Me.btnChangeShape.Location = New System.Drawing.Point(3, 113)
        Me.btnChangeShape.Name = "btnChangeShape"
        Me.btnChangeShape.Size = New System.Drawing.Size(76, 67)
        Me.btnChangeShape.TabIndex = 1
        Me.btnChangeShape.UseVisualStyleBackColor = False
        '
        'tlp1
        '
        Me.tlp1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.tlp1.ColumnCount = 2
        Me.tlp1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117.0!))
        Me.tlp1.Controls.Add(Me.lblKino, 0, 0)
        Me.tlp1.Controls.Add(Me.tlpErase, 0, 1)
        Me.tlp1.Controls.Add(Me.tlpControlBox, 1, 0)
        Me.tlp1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp1.Location = New System.Drawing.Point(0, 0)
        Me.tlp1.Name = "tlp1"
        Me.tlp1.RowCount = 2
        Me.tlp1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlp1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp1.Size = New System.Drawing.Size(916, 557)
        Me.tlp1.TabIndex = 0
        '
        'lblKino
        '
        Me.lblKino.BackColor = System.Drawing.Color.Black
        Me.lblKino.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblKino.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKino.ForeColor = System.Drawing.Color.Silver
        Me.lblKino.Location = New System.Drawing.Point(4, 1)
        Me.lblKino.Name = "lblKino"
        Me.lblKino.Size = New System.Drawing.Size(790, 40)
        Me.lblKino.TabIndex = 9
        Me.lblKino.Text = "Kino"
        Me.lblKino.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tlpErase
        '
        Me.tlpErase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpErase.Location = New System.Drawing.Point(4, 45)
        Me.tlpErase.Name = "tlpErase"
        Me.tlpErase.Size = New System.Drawing.Size(790, 508)
        Me.tlpErase.TabIndex = 12
        '
        'tmrFadeControls
        '
        Me.tmrFadeControls.Enabled = True
        Me.tmrFadeControls.Interval = 1
        '
        'tmrKeys
        '
        Me.tmrKeys.Enabled = True
        Me.tmrKeys.Interval = 10
        '
        'tmrCross
        '
        Me.tmrCross.Interval = 1
        '
        'frmKino
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(916, 557)
        Me.Controls.Add(Me.tlp1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmKino"
        Me.Opacity = 0.5R
        Me.Text = "Kino"
        Me.TopMost = True
        Me.tlpControlBox.ResumeLayout(False)
        Me.tlpControlBox.PerformLayout()
        CType(Me.tbOpacity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlp1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnMinimize As System.Windows.Forms.Button
    Friend WithEvents tlpControlBox As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnChangeShape As System.Windows.Forms.Button
    Friend WithEvents tlp1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tmrFadeControls As System.Windows.Forms.Timer
    Friend WithEvents tmrKeys As System.Windows.Forms.Timer
    Friend WithEvents ttMinimize As System.Windows.Forms.ToolTip
    Friend WithEvents tmrCross As System.Windows.Forms.Timer
    Friend WithEvents btnNextInstance As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents tbOpacity As System.Windows.Forms.TrackBar
    Friend WithEvents btnWorkingArea As System.Windows.Forms.Button
    Friend WithEvents lblKino As System.Windows.Forms.Label
    Friend WithEvents tlpErase As System.Windows.Forms.Panel
    Friend WithEvents btnUpdates As System.Windows.Forms.Button
    ' Friend WithEvents cbxScreens As System.Windows.Forms.ComboBox

End Class
