Imports System.Net
Imports Ionic.Zip
Public Class frmKino
    Dim Check_Mouse As Boolean = False
    Private CurrentPosition As New System.Drawing.Point
    Private MouseButton As System.Windows.Forms.MouseButtons = Nothing
    Dim Screens As New List(Of Screen)
    Dim Point1 As New Point
    Dim point2 As New Point
    Dim ErasedArea As New Rectangle
    Dim AnimationRegion As New Rectangle
    Dim EraseOK As Boolean = False
    Dim Fade As Integer = 0
    Dim MousePos As New Point
    Dim MousePosCross As New Point
    Dim AreaMove As Boolean = False
    Dim Faktor As Single
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Keys) As Integer
    Dim KeyHistory As New List(Of String)
    Dim ControlKeyState As Integer = 0
    Dim LeftArrowState As Integer = 0
    Dim RightArrowState As Integer = 0
    Dim KeyCounter As Integer = 0
    Dim aScreen As Screen
    Dim AnimationsStatus As Byte = 0
    Dim Animation As Boolean = True
    Dim verschiebenMausPos As New Point
    Dim verschieben As Boolean = False
    Dim verschiebenSeite As String

    Dim Counter As Integer = 1

#Region " Form und Buttons formen "
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        'Ellipse_Form
        Dim shape As New System.Drawing.Drawing2D.GraphicsPath
        If EraseOK = True Then shape.AddRectangle(ErasedArea)
        shape.AddRectangle(New Rectangle(0, 0, Me.Width, Me.Height))
        Me.Region = New System.Drawing.Region(shape)

        'Fadenkreuz
        If (Not MousePosCross = MousePosition) And tmrCross.Enabled = False And AreaMove Then
            MousePosCross = MousePosition
            With tlpErase
                Dim gF As Graphics = .CreateGraphics
                gF.FillRectangle(Brushes.Black, New Rectangle(0, 0, .Width, .Height))
                gF.DrawLine(Pens.Red, New PointF(0, .PointToClient(MousePosition).Y), New PointF(.Width, .PointToClient(MousePosition).Y))
                gF.DrawLine(Pens.Red, New PointF(.PointToClient(MousePosition).X, 0), New PointF(.PointToClient(MousePosition).X, .Height))
            End With
        End If
    End Sub
#End Region
#Region " Updates"
    Dim Status As String
    Dim WithEvents WC1 As New WebClient
    Dim UpdateFilename As String = Application.UserAppDataPath & "\Setup\Version.txt"
    Private Sub Update_verfügbar()
        Try
            Dim Url As New Uri("https://sourceforge.net/projects/pskino/files/Setup/Version.txt")
            If IO.Directory.Exists(Application.UserAppDataPath & "\Setup\") Then IO.Directory.Delete(Application.UserAppDataPath & "\Setup\", True)
            IO.Directory.CreateDirectory(Application.UserAppDataPath & "\Setup\")
            tlpErase.CreateGraphics.Clear(Color.Black)
            WC1.DownloadFileAsync(Url, UpdateFilename)
            Status = "C"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub DownloadedUpdates(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles WC1.DownloadFileCompleted
        tlpControlBox.Enabled = False
        Select Case Status
            Case "C"
                Try
                    If IO.File.Exists(UpdateFilename) Then
                        Dim Content As String = OpenFileContent(UpdateFilename)
                        Dim sr As New IO.StreamReader(UpdateFilename)
                        If Not sr.ReadLine = Application.ProductVersion Then
                            tmrKeys.Enabled = False
                            Me.TopMost = False
                            If MsgBox("New update available!" & vbCrLf & "Do you want to install it?", vbYesNo) = vbYes Then
                                UpdatesDownloaden()
                            End If
                        Else
                            tlpErase.CreateGraphics.Clear(Color.Black)
                            tmrKeys.Enabled = False
                            Me.TopMost = False
                            MsgBox("No updates available")
                        End If
                        sr.Close()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Case "D"
                tlpErase.CreateGraphics.Clear(Color.Black)
                Try
                    ZipFile.Read(Application.UserAppDataPath & "\Setup\Kino_Setup.zip").ExtractAll(Application.UserAppDataPath & "\Setup\", ExtractExistingFileAction.OverwriteSilently)
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Exit Sub
                End Try
                Me.TopMost = False
                tlpErase.CreateGraphics.Clear(Color.Black)
                tlpErase.CreateGraphics.DrawString("installing", New Font("Arial", 72), Brushes.White, New Point(0, tlpErase.Height / 2 - 50))
                Try
                    Dim p As Process = Process.Start(Application.UserAppDataPath & "\Setup\setup.exe")
                    End
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
        End Select
        tlpErase.CreateGraphics.Clear(Color.Black)
        tmrKeys.Enabled = True
        tlpControlBox.Enabled = True
    End Sub

    Private Function OpenFileContent(ByVal Filename As String) As String
        Try
            Dim sr As System.IO.StreamReader = New IO.StreamReader(Filename)
            Dim Content As String
            Content = sr.ReadToEnd()
            sr.Close()
            Return Content
        Catch ex As IO.IOException
            MessageBox.Show(ex.Message.ToString(), "Info")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Info")
        End Try
        Return String.Empty
    End Function

    Private Function Download(ByVal Url As String, ByVal Filename As String) As String
        Try
            Dim wc As WebClient = New WebClient()
            wc.DownloadFile(Url, Filename)
        Catch ex As WebException
            MessageBox.Show(ex.Message.ToString(), "Info")
        Catch ex As UriFormatException
            MessageBox.Show(ex.Message.ToString(), "Info")
        End Try
        Return String.Empty
    End Function

    Private Sub UpdatesDownloaden()
        tlpErase.CreateGraphics.Clear(Color.Black)
        Try
            WC1.DownloadFileAsync(New Uri("http://sourceforge.net/projects/pskino/files/Setup/Kino_Setup.zip"), Application.UserAppDataPath & "\Setup\Kino_Setup.zip")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Status = "D"
    End Sub

    Private Sub Donwloading(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles WC1.DownloadProgressChanged
        Select Case Status
            Case "C"
                tlpErase.CreateGraphics.Clear(Color.Black)
                tlpErase.CreateGraphics.DrawString("checking for updates " & e.ProgressPercentage & "%", New Font("Arial", 72), Brushes.White, New Point(0, tlpErase.Height / 2 - 50))
            Case "D"
                tlpErase.CreateGraphics.Clear(Color.Black)
                tlpErase.CreateGraphics.DrawString("checking for updates " & e.ProgressPercentage & "%", New Font("Arial", 72), Brushes.White, New Point(0, tlpErase.Height / 2 - 50))
        End Select
    End Sub
#End Region

#Region " Basis"
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each Screen As Screen In Windows.Forms.Screen.AllScreens
            Screens.Add(Screen)
        Next
        Dim Params As String() = Environment.GetCommandLineArgs
        If Params.Length > 1 Then
            If IsNumeric(Params(1)) Then
                If Params(1) < Screens.Count Then
                    aScreen = Screens(Params(1))
                End If
            End If
        End If
        If aScreen Is Nothing Then aScreen = Screens(0)
        Me.Size = aScreen.WorkingArea.Size
        Me.Location = aScreen.WorkingArea.Location

        Me.TopLevel = True
        btnNextInstance.Visible = (Screens.Count > 1)
    End Sub



    Private Sub tmrFadeControls_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrFadeControls.Tick
        Static Fade As Integer
        If MousePosition = MousePos Then
            Fade += 1
        Else
            Dim pos As Point = MousePosition
            Dim EraseLoc As Point = PointToScreen(ErasedArea.Location)
            If _
                Not PointInRectangle(pos, New Rectangle(EraseLoc.X, EraseLoc.Y, ErasedArea.Width, ErasedArea.Height)) _
                And PointInRectangle(pos, New Rectangle(Me.Location, Me.Size)) Then

                Fade = 0
                MousePos = MousePosition
                tlpControlBox.Visible = True
                If Not tlp1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single Then
                    tlp1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
                    Cursor.Show()
                End If
            Else
                Fade += 1
            End If
        End If
        If Fade = 300 Then
            tlpControlBox.Visible = False
            Cursor.Hide()
            tlp1.CellBorderStyle = TableLayoutPanelCellBorderStyle.None
            tlpErase.CreateGraphics.Clear(Color.Black)
            tlpErase.CreateGraphics.Dispose()
            tlpErase.Focus()
        ElseIf Fade = Integer.MaxValue Then
            Fade = 301
        Else
        End If
    End Sub

    Private Sub tmrKeys_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrKeys.Tick
        If Not tbOpacity.Focused Then
            Try
                If GetAsyncKeyState(Keys.PageUp) <> 0 Then tbOpacity.Value += 1
                If GetAsyncKeyState(Keys.PageDown) <> 0 Then tbOpacity.Value -= 1
                tbOpacity_Scroll(tbOpacity, Nothing)
            Catch ex As Exception : End Try
        End If
        Static BreakKeyPressed As Boolean = False
        If GetAsyncKeyState(Keys.Pause) <> 0 Then
            If Not BreakKeyPressed Then
                BreakKeyPressed = True
                Me.WindowState = If(Me.WindowState = FormWindowState.Normal, FormWindowState.Minimized, FormWindowState.Normal)
            End If
        Else
            BreakKeyPressed = False
        End If
        If Not Me.WindowState = FormWindowState.Minimized Then
            Me.OnPaint(Nothing)
            Me.TopMost = True
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnMinimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub tbOpacity_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbOpacity.Scroll
        Me.Opacity = sender.value / 100
    End Sub

    Private Sub frmKino_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        tmrFadeControls.Enabled = True
    End Sub

    Private Sub frmKino_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        tmrFadeControls.Enabled = False
        tlpControlBox.Visible = False
        tlpControlBox.Visible = False
    End Sub
#End Region

    Private Sub tlpErase_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tlpErase.MouseDown
        If e.Button = MouseButtons.Left Then
            If Check_Mouse Then
                Point1 = e.Location
                AreaMove = True
                tmrCross.Enabled = False
            Else
                If ErasedArea.Width > 0 Then
                    Faktor = 1
                    verschiebenMausPos = e.Location
                    verschieben = True
                End If
            End If

        ElseIf e.Button = MouseButtons.Right Then
            If ErasedArea.Width > 0 Then
                Faktor = 0.5
                verschiebenMausPos = e.Location
                verschieben = True
            End If
        End If
    End Sub

    Private Sub tlpErase_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tlpErase.MouseMove
        Dim mousepos As Point = e.Location
        If AreaMove Then
            point2 = e.Location
            ErasedArea.X = IIf(Point1.X < point2.X, Point1.X, point2.X) + tlpErase.Left
            ErasedArea.Y = IIf(Point1.Y < point2.Y, Point1.Y, point2.Y) + tlpErase.Top
            ErasedArea.Width = IIf(Point1.X > point2.X, Point1.X - point2.X, point2.X - Point1.X)
            ErasedArea.Height = IIf(Point1.Y > point2.Y, Point1.Y - point2.Y, point2.Y - Point1.Y)
            EraseOK = True
            OnPaint(Nothing)
        ElseIf verschieben Then
            If Not verschiebenMausPos = mousepos Then
                Dim Verschiebung As New Point(mousepos.X - verschiebenMausPos.X, mousepos.Y - verschiebenMausPos.Y)
                Dim West = (Not (Verschiebung.X > 0 And ErasedArea.Width <= 1)) And (Not (Verschiebung.X < 0 And ErasedArea.Left - tlpErase.Left <= tlpErase.Left)), _
                    East = Not (Verschiebung.X > 0 And ErasedArea.Right - tlpErase.Left >= tlpErase.Right - 7), _
                    North = (Not (Verschiebung.Y > 0 And ErasedArea.Height <= 1)) And (Not (Verschiebung.Y < 0 And ErasedArea.Top - tlpErase.Top <= 7)), _
                    South As Boolean = Not (Verschiebung.Y > 0 And ErasedArea.Bottom - tlpErase.Top >= tlpErase.Height - 6)
                Select Case verschiebenSeite
                    Case "E"
                        If East Then
                            ErasedArea.Width += Verschiebung.X * Faktor
                            tlpErase.Cursor = Cursors.SizeWE
                        End If
                    Case "S"
                        If South Then
                            ErasedArea.Height += Verschiebung.Y * Faktor
                            tlpErase.Cursor = Cursors.SizeNS
                        End If
                    Case "W"
                        If West Then
                            ErasedArea.X += Verschiebung.X * Faktor
                            ErasedArea.Width -= Verschiebung.X * Faktor
                            tlpErase.Cursor = Cursors.SizeWE
                        End If
                    Case "N"
                        If North Then
                            ErasedArea.Y += Verschiebung.Y * Faktor
                            ErasedArea.Height -= Verschiebung.Y * Faktor
                            tlpErase.Cursor = Cursors.SizeNS
                        End If
                    Case "NE"
                        If North Then
                            ErasedArea.Y += Verschiebung.Y * Faktor
                            ErasedArea.Height -= Verschiebung.Y * Faktor
                        End If
                        If East Then
                            ErasedArea.Width += Verschiebung.X * Faktor
                        End If
                        If North Or East Then tlpErase.Cursor = Cursors.SizeNESW
                    Case "SE"
                        If South Then
                            ErasedArea.Height += Verschiebung.Y * Faktor
                        End If
                        If East Then
                            ErasedArea.Width += Verschiebung.X * Faktor
                        End If
                        If South Or East Then tlpErase.Cursor = Cursors.SizeNWSE
                    Case "SW"
                        If South Then
                            ErasedArea.Height += Verschiebung.Y * Faktor
                        End If
                        If West Then
                            ErasedArea.X += Verschiebung.X * Faktor
                            ErasedArea.Width -= Verschiebung.X * Faktor
                        End If
                        If South Or West Then tlpErase.Cursor = Cursors.SizeNESW
                    Case "NW"
                        If North Then
                            ErasedArea.Y += Verschiebung.Y * Faktor
                            ErasedArea.Height -= Verschiebung.Y * Faktor
                        End If
                        If West Then
                            ErasedArea.X += Verschiebung.X * Faktor
                            ErasedArea.Width -= Verschiebung.X * Faktor
                        End If
                        If North Or West Then tlpErase.Cursor = Cursors.SizeNWSE
                End Select
                If ErasedArea.Width < 1 Then ErasedArea.Width = 1
                If ErasedArea.Height < 1 Then ErasedArea.Height = 1
                OnPaint(Nothing)

            End If
        Else
            If tmrCross.Enabled = False And ErasedArea.Width > 0 Then
                If e.Location.X <= ErasedArea.X - tlpErase.Left And e.Location.Y <= ErasedArea.Top - tlpErase.Top Then
                    tlpErase.Cursor = Cursors.PanNW
                    verschiebenSeite = "NW"
                ElseIf e.Location.X >= ErasedArea.X + ErasedArea.Width - tlpErase.Left And e.Location.Y <= ErasedArea.Top - tlpErase.Top Then
                    tlpErase.Cursor = Cursors.PanNE
                    verschiebenSeite = "NE"
                ElseIf e.Location.X >= ErasedArea.X + ErasedArea.Width - tlpErase.Left And e.Location.Y >= ErasedArea.Top + ErasedArea.Height - tlpErase.Top Then
                    tlpErase.Cursor = Cursors.PanSE
                    verschiebenSeite = "SE"
                ElseIf e.Location.X <= ErasedArea.X - tlpErase.Left And e.Location.Y >= ErasedArea.Top + ErasedArea.Height - tlpErase.Top Then
                    tlpErase.Cursor = Cursors.PanSW
                    verschiebenSeite = "SW"
                ElseIf e.Location.X <= ErasedArea.X - tlpErase.Left Then
                    tlpErase.Cursor = Cursors.PanWest
                    verschiebenSeite = "W"
                ElseIf e.Location.X >= ErasedArea.X + ErasedArea.Width - tlpErase.Left Then
                    tlpErase.Cursor = Cursors.PanEast
                    verschiebenSeite = "E"
                ElseIf e.Location.Y <= ErasedArea.Top - tlpErase.Top Then
                    tlpErase.Cursor = Cursors.PanNorth
                    verschiebenSeite = "N"
                ElseIf e.Location.Y >= ErasedArea.Top + ErasedArea.Height - tlpErase.Top Then
                    tlpErase.Cursor = Cursors.PanSouth
                    verschiebenSeite = "S"
                Else
                    ' tlpErase.Cursor = Cursors.Default
                End If
            End If
        End If
        'If (Not mousepos = verschiebenMausPos) And (Not tlp1.CellBorderStyle = BorderStyle.None) And (Not tmrCross.Enabled = True) Then
        '    Dim g As Graphics = tlpErase.CreateGraphics
        '    If PointInRectangle(mousepos, New Rectangle(ErasedArea.X - tlpErase.Left - 20, ErasedArea.Y - tlpErase.Top - 20, ErasedArea.Width + 40, ErasedArea.Height + 40)) _
        '    And (Not PointInRectangle(mousepos, New Rectangle(ErasedArea.X - tlpErase.Left, ErasedArea.Y - tlpErase.Top, ErasedArea.Width, ErasedArea.Height))) Then
        '        g.FillRectangle(New SolidBrush(Color.FromArgb(255, 200, 200, 200)), ErasedArea.X - tlpErase.Left - 20, ErasedArea.Y - tlpErase.Top - 20, ErasedArea.Width + 40, ErasedArea.Height + 40)
        '    Else
        '        g.Clear(Color.Black)
        '        tlpErase.Cursor = Cursors.Default
        '    End If
        '    g.Dispose()
        'End If
        verschiebenMausPos = e.Location
    End Sub

    Private Function PointInRectangle(ByVal Point As Point, ByVal Rect As Rectangle) As Boolean
        Dim Value As Boolean
        If (Point.X >= Rect.X) And (Point.Y >= Rect.Y) And (Point.X <= Rect.X + Rect.Width) And (Point.Y <= Rect.Y + Rect.Height) Then Value = True Else Value = False
        Return Value
    End Function

    Private Sub btnChangeShape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeShape.Click
        Me.Opacity = 0.5
        Check_Mouse = True
        EraseOK = False
        OnPaint(Nothing)
        Windows.Forms.Cursor.Clip = New Rectangle(PointToScreen(tlpErase.Location), tlpErase.Size)
        tlpErase.Cursor = Cursors.Cross
        tlpErase.Focus()
        tmrCross.Enabled = True
    End Sub

    Private Sub tlpErase_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tlpErase.MouseUp
        If e.Button = MouseButtons.Left Then
            If Check_Mouse Then
                Check_Mouse = False
                Windows.Forms.Cursor.Clip = Nothing
                AreaMove = False
                Me.Opacity = tbOpacity.Value / 100
                tlpErase.Cursor = Cursors.Default
                Dim gF As Graphics = tlpErase.CreateGraphics
                gF.Clear(Color.Transparent)
            Else
                verschieben = False
            End If
        ElseIf e.Button = MouseButtons.Right Then
            verschieben = False
        End If
    End Sub

    Private Sub btnNextInstance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextInstance.Click
        System.Diagnostics.Process.Start(Application.ExecutablePath,
                                         Screens.IndexOf(aScreen) + 1)
    End Sub

    Private Sub tmrCross_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCross.Tick
        If Not MousePosCross = MousePosition Then
            MousePosCross = MousePosition
            With tlpErase
                Dim gF As Graphics = .CreateGraphics
                'gF.Clear(Color.Transparent)
                gF.FillRectangle(Brushes.Black, New Rectangle(0, 0, .Width, .Height))
                gF.DrawLine(Pens.Red, New PointF(0, .PointToClient(MousePosition).Y), New PointF(.Width, .PointToClient(MousePosition).Y))
                gF.DrawLine(Pens.Red, New PointF(.PointToClient(MousePosition).X, 0), New PointF(.PointToClient(MousePosition).X, .Height))
            End With
        End If
    End Sub

    Private Sub frmKino_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Windows.Forms.Cursor.Clip = Nothing
        ErasedArea = Nothing
    End Sub

    Private Sub btnWorkingArea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWorkingArea.Click
        Select Case btnWorkingArea.Tag
            Case "WorkingArea"
                btnWorkingArea.BackgroundImage = My.Resources.nWorkingArea
                btnWorkingArea.Tag = "nWorkingArea"
                Me.Size = aScreen.Bounds.Size
                Me.Location = aScreen.Bounds.Location
            Case "nWorkingArea"
                btnWorkingArea.BackgroundImage = My.Resources.WorkingArea
                btnWorkingArea.Tag = "WorkingArea"
                Me.Size = aScreen.WorkingArea.Size
                Me.Location = aScreen.WorkingArea.Location
        End Select
        OnPaint(Nothing)
    End Sub

   
    Private Sub btnUpdates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdates.Click
        Try
            Update_verfügbar()
        Catch ex As Exception
            MsgBox("check failed")
        End Try
    End Sub
End Class
