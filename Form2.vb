Imports System.Runtime.CompilerServices
Imports MySql.Data.MySqlClient
Public Class Form2
    Dim conn As New MySqlConnection
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim db As New DB
        Dim adaptor As New MySqlDataAdapter("SELECT * from users where Username='" & TextBox1.Text & "' AND Password='" & TextBox2.Text & "'", db.conn)
        Dim dt As New DataTable
        adaptor.Fill(dt)
        If dt.Rows.Count() > 0 Then
            Main.Show()
            Me.Hide()
        Else
            Txtatt.Text = Val(Txtatt.Text) + 1
            Timer1.Enabled = True
            MsgBox("Invalid Username/Password", MsgBoxStyle.Exclamation, "Alert!")
            TextBox1.Text = ""
            TextBox2.Text = ""
        End If
        If Txtatt.Text = 3 Then
            MsgBox("Wait for 30 seconds and try again", MsgBoxStyle.Information, "Warning!")

        End If
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Form4.Show()
        Me.Hide()

    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Txtatt.Text = 3 Then

            Txtcount.Text = Val(Txtcount.Text) - 1
            TextBox1.Enabled = False
            TextBox2.Enabled = False

        End If
        If Txtcount.Text = 0 Then
            Timer1.Enabled = False
            Txtatt.Text = 0
            Txtcount.Text = 30
            TextBox1.Enabled = True
            TextBox2.Enabled = True
        End If
    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        If MsgBox("Are you sure you want to exit?", MsgBoxStyle.OkCancel, "Warning") = MsgBoxResult.Ok Then
            Application.ExitThread()
        End If


    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.UseSystemPasswordChar = True

        Else
            TextBox2.UseSystemPasswordChar = False

        End If
    End Sub
End Class