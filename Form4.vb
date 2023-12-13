Imports System.Deployment.Application
Imports System.Drawing.Drawing2D
Imports System.Windows.Data
Imports System.Windows.Media.Animation
Imports MySql.Data.MySqlClient
Public Class Form4
    Dim db As New DB
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim adpt As New MySqlDataAdapter("SELECT * FROM users WHERE Username='" + TextBox1.Text + "'", db.conn)
        Dim dt As New DataTable
        adpt.Fill(dt)

        If dt.Rows.Count >= 1 Then
            If TextBox2.Text = dt.Rows(0)("answer1").ToString And TextBox3.Text = dt.Rows(0)("answer2").ToString Then
                Form3.Show()
                Me.Hide()
                Exit Sub
            End If
            MsgBox("Wrong security answers")
        Else
            MsgBox("Username not found", MsgBoxStyle.Information)
        End If
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Form2.Show()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class