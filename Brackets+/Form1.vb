Public Class Form1

    Dim cr_cd = ""
    Dim rn_sc = "0"

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click, WindowToolStripMenuItem.Click
        If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable Then
            Me.WindowState = FormWindowState.Normal
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.WindowState = FormWindowState.Maximized
            Button2.Text = "Window:Maximum"
            Exit Sub
        Else
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            Me.WindowState = FormWindowState.Normal
            Button2.Text = "Window:Normal"
            Exit Sub
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, SaveToolStripMenuItem.Click, Save2ToolStripMenuItem.Click
        get_cd()
        If Me.Tag = "" Then
            SaveFileDialog1.ShowDialog()
        Else
            My.Computer.FileSystem.WriteAllText(Me.Tag, cr_cd, False)
        End If
        Me.Text = "Bracket Master Plus"
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        get_cd()
        If Me.Tag = "" Then
        Else
            System.Diagnostics.Process.Start(Me.Tag)
        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.Tag = "" Then
        Else
            Dim saved_data As String = My.Computer.FileSystem.ReadAllText(Me.Tag)
            get_cd()
            If cr_cd = saved_data Then
            Else
                If TextBox1.Text = "" Then
                Else
                    If MsgBox("Do you want to save changes to Document ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        My.Computer.FileSystem.WriteAllText(Me.Tag, cr_cd, False)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub HideToolsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideToolsToolStripMenuItem.Click
        If rn_sc = "0" Then
            If Panel3.Height < 20 Then
                Panel3.Enabled = True
                Timer2.Start()
            Else
                Timer1.Start()
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        rn_sc = "u"
        If Panel3.Height = 0 Then
            Panel3.Enabled = False
            Timer1.Stop()
            rn_sc = "0"

        Else
            If Panel3.Height > 20 Then
                Panel3.Height -= 8
                Timer1.Start()
            Else
                Panel3.Height -= 1
                Timer1.Start()
            End If
        End If


        If Panel2.Height >= 0 Then
            Panel2.Height -= 1
        End If
        If Panel4.Width >= 0 Then
            Panel4.Width -= 1
        End If
        If Panel5.Width >= 0 Then
            Panel5.Width -= 1
        End If

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        rn_sc = "d"
        If Panel3.Height >= 43 Then
            Timer2.Stop()
            rn_sc = "0"

        Else
            If Panel3.Height < 30 Then
                Panel3.Height += 4
                Timer2.Start()
            Else
                Panel3.Height += 1
                Timer2.Start()
            End If
        End If


        If Panel2.Height <= 9 Then
            Panel2.Height += 1
        End If
        If Panel4.Width <= 9 Then
            Panel4.Width += 1
        End If
        If Panel5.Width <= 9 Then
            Panel5.Width += 1
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Developed by Deshan Nawanjana" & Form3.Label1.Text & "www.deshanblogs.blogspot.com", MsgBoxStyle.Information, "About")
        System.Diagnostics.Process.Start("http://www.deshanblogs.blogspot.com/")
    End Sub

    Private Sub About2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles About2ToolStripMenuItem.Click
        TextBox1.SelectAll()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FontDialog1.Font = TextBox1.Font
    End Sub

    Private Sub get_cd()
        cr_cd = TextBox1.Text
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If FontDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then

            TextBox1.Font = FontDialog1.Font
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Me.Text = "Bracket Master Plus [unsaved]"
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        TextBox1.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
        Me.Tag = OpenFileDialog1.FileName
    End Sub

    Private Sub SaveFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, TextBox1.Text, False)
        Me.Tag = SaveFileDialog1.FileName
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
        SaveFileDialog1.ShowDialog()
    End Sub
End Class
