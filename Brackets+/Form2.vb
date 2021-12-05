Public Class Form2

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form3.ShowDialog()
        resr_clz()
        ListBox1.SelectedItem = Form3.Tag
    End Sub

    Private Sub resr_clz()
        ListBox1.Items.Clear()
        For Each ffx As String In My.Computer.FileSystem.GetFiles( _
            "www\res\css\", _
            FileIO.SearchOption.SearchTopLevelOnly, "*.*")
            Dim ff As New IO.FileInfo(ffx)
            ListBox1.Items.Add(ff.Name)
        Next
        TextBox1.Text = ""

        If ListBox1.SelectedItem = "" Then
            TextBox1.Enabled = False
        Else
            TextBox1.Enabled = True
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedItem = "" Then
            TextBox1.Enabled = False
        Else
            TextBox1.Enabled = True
            TextBox1.Text = My.Computer.FileSystem.ReadAllText("www\res\css\" & ListBox1.SelectedItem)
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If ListBox1.SelectedItem = "" Then
        Else
            My.Computer.FileSystem.WriteAllText("www\res\css\" & ListBox1.SelectedItem, TextBox1.Text, False)
        End If
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        resr_clz()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ListBox1.SelectedItem = "" Then
        Else
            If MsgBox("Sure to remove class : " & ListBox1.SelectedItem & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                My.Computer.FileSystem.DeleteFile("www\res\css\" & ListBox1.SelectedItem)
                ListBox1.Items.Remove(ListBox1.SelectedItem)
                resr_clz()
            End If
        End If
    End Sub
End Class