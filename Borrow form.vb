Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Window
Imports MySql.Data.MySqlClient
Public Class Borrow_form
    Dim db As New DB
    Public Shared selectedrow As Object

    Public Sub ClearInput()
        Textbox2.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        TextBox4.Text = ""
        ComboBox4.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox3.Text = "" Or Textbox2.Text = "" Or TextBox4.Text = "" Or ComboBox3.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox4.Text = "" Or DateTimePicker1.Text = "" Or DateTimePicker1.Text = "" Then
            MsgBox("Please fill up all needed information", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

        Else
            Using adptCheck As New MySqlDataAdapter("SELECT Number_of_books FROM books WHERE Book_Title='" & Main.selected & "'", db.conn)
                Using dtCheck As New DataTable
                    adptCheck.Fill(dtCheck)
                    If Val(dtCheck.Rows(0)("Number_of_books")) <= 0 Then
                        MsgBox("NO MORE BOOKS AVAILABLE", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                End Using


                If MsgBox("Are you sure you want this books?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                Else
                    db.conn.Open()
                    Using updateCmd As New MySqlCommand("UPDATE books SET Number_of_books=Number_of_books-1 WHERE Book_Title=@title", db.conn)
                        updateCmd.Parameters.AddWithValue("@title", Main.selected)
                        updateCmd.ExecuteNonQuery()
                    End Using

                    Dim borrowDateFormat As Date = DateTimePicker1.Text
                    Dim returnDateFormat As Date = DateTimePicker2.Text

                    Dim cmd As New MySqlCommand("INSERT INTO borrow_log(ID_Number,Name_of_books,Name,Grade_Level,Strand_Course,Staff_Student_Teacher,category,Date_of_borrow,Date_of_return) VALUES(@idnumber,@Name_of_books,@Name,@Grade_Level,@Strand_Course,@Staff_Student_Teacher,@category,@Date_of_borrow,@Date_of_return);", db.conn)
                    With cmd
                        .Parameters.AddWithValue("@idnumber", TextBox3.Text)
                        .Parameters.AddWithValue("@Name_of_books", TextBox1.Text)
                        .Parameters.AddWithValue("@Name", TextBox4.Text)
                        .Parameters.AddWithValue("@Grade_Level", ComboBox3.Text)
                        .Parameters.AddWithValue("@Strand_Course", ComboBox1.Text)
                        .Parameters.AddWithValue("@Staff_Student_Teacher", ComboBox2.Text)
                        .Parameters.AddWithValue("@category", ComboBox4.Text)
                        .Parameters.AddWithValue("@Date_of_borrow", borrowDateFormat.ToString("yyyy-MM-d"))
                        .Parameters.AddWithValue("@Date_of_return", returnDateFormat.ToString("yyyy-MM-d"))
                        .ExecuteNonQuery()
                    End With
                    db.conn.Close()
                    ClearInput()
                    MsgBox("Borrowed Successful", MsgBoxStyle.Information)
                    Main.Data1()
                    Main.Data2()
                    TextBox1.Text = ""
                    TextBox4.Text = ""
                    TextBox3.Text = ""
                    ComboBox3.Text = ""
                    ComboBox1.Text = ""
                    ComboBox2.Text = ""
                    ComboBox4.Text = ""
                    Me.Close()
                End If
            End Using
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()

    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged

    End Sub

    Private Sub Borrow_form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Textbox2.TextChanged
        Textbox2.Enabled = False
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        ComboBox4.Enabled = False

    End Sub

    Private Sub ComboBox4_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox4.KeyPress
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.Enabled = False
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub ComboBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox3.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox2.KeyPress
        e.Handled = True
    End Sub
End Class