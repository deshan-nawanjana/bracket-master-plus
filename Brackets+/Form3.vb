Public Class Form3

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If My.Computer.FileSystem.FileExists("www\res\css\" & TextBox1.Text) Then
            MsgBox("Class already exist : " & TextBox1.Text, MsgBoxStyle.Exclamation)
        Else
            Dim err As String = ""
            Try
                My.Computer.FileSystem.WriteAllText("www\res\css\" & TextBox1.Text, "", False)
            Catch ex As Exception
                err = ex.Message
            End Try
            If err = "" Then
                Me.Tag = TextBox1.Text
                Me.Close()
            Else
                MsgBox("Something went wrong with class name." & Label1.Text & "Change the name to resolve problem.", MsgBoxStyle.Exclamation)
            End If

        End If
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = ""
        Me.Tag = ""
    End Sub
End Class