Imports MySql.Data.MySqlClient
Public Class ADD_BOOKS
    Dim db As New DB
    Private Sub ADD_BOOKS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Textbox1.Text = "" Or TextBox4.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Please fill up all needed information", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

        Else
            db.conn.Open()
            Dim add As New MySqlCommand("INSERT INTO books(Book_Title,Book_Publisher,book_shelf,Number_of_books,category) VALUES(@title,@publisher,@shelf,@Number_of_books,@category)", db.conn)
            With add

                .Parameters.AddWithValue("@title", Textbox1.Text)
                .Parameters.AddWithValue("@publisher", TextBox4.Text)
                .Parameters.AddWithValue("@shelf", TextBox2.Text)
                .Parameters.AddWithValue("@Number_of_books", TextBox3.Text)
                .Parameters.AddWithValue("@category", ComboBox1.Text)
                .ExecuteNonQuery()
            End With
            db.conn.Close()
            Textbox1.Text = ""
            TextBox4.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            ComboBox1.Text = ""
            Main.Data1()
            Me.Close()
            MsgBox("Successfully Added!", MsgBoxStyle.Information, "Notice")
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 

    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        e.Handled = True
    End Sub

    Private Sub ADD_BOOKS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
End Class