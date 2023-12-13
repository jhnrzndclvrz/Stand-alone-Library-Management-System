Imports MySql.Data.MySqlClient
Public Class Form3
    Dim db As New DB
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Please Fill up all information")
            Exit Sub
        End If
        Using adpt As New MySqlDataAdapter("SELECT * FROM users WHERE Password='" & TextBox1.Text & "'", db.conn)
            Using dt As New DataTable
                adpt.Fill(dt)

                If dt.Rows.Count >= 1 Then
                    MsgBox("You have entered your old password")
                    Exit Sub
                End If
            End Using
        End Using

        If TextBox1.Text = TextBox3.Text Then
            db.conn.Open()
            Dim adpt As New MySqlCommand("UPDATE users SET Password=@pass", db.conn)
            With adpt
                .Parameters.AddWithValue("@pass", TextBox1.Text)
                .ExecuteNonQuery()
            End With
            db.conn.Close()
            MsgBox("Change Succesful", vbOKOnly, "Alert!")
            Me.Hide()
            Form2.Show()
        Else
            MsgBox("Password not matched")
        End If

        TextBox1.Text = ""
        TextBox3.Text = ""
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox1.UseSystemPasswordChar = False
            TextBox3.UseSystemPasswordChar = False

        Else
            TextBox1.UseSystemPasswordChar = True
            TextBox3.UseSystemPasswordChar = True
        End If
    End Sub
End Class