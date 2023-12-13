Imports MySql.Data.MySqlClient
Public Class Form1
    Dim db As New DB
    Public bookid As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        db.conn.Open()
        Dim updt As New MySqlCommand("UPDATE books SET Book_Title=@title,Book_Publisher=@publisher,Book_Shelf=@shelf,Number_of_books=@nob,Category=@category WHERE BookID=@id", db.conn)
        With updt
            updt.Parameters.AddWithValue("@title", TextBox1.Text)
            updt.Parameters.AddWithValue("@publisher", TextBox2.Text)
            updt.Parameters.AddWithValue("@shelf", TextBox3.Text)
            updt.Parameters.AddWithValue("@nob", TextBox4.Text)
            updt.Parameters.AddWithValue("@category", ComboBox1.Text)
            updt.Parameters.AddWithValue("@id", bookid)
            updt.ExecuteNonQuery()
        End With
        db.conn.Close()
        Main.Data1()
        Me.Close()
        MsgBox("Updated successfully", MsgBoxStyle.Information)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        e.Handled = True
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class