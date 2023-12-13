
Imports System.ComponentModel
Imports System.Net
Imports MySql.Data.MySqlClient
Public Class Main
    Dim db As New DB
    Public selected As String
    Public selectecNameOfBooks As String
    Public viewReportSelected As String


    Public Sub Data3()
        Dim adpt As New MySqlDataAdapter("SELECT * FROM reports", db.conn)
        Dim dt3 As New DataTable
        adpt.Fill(dt3)
        DataGridView1.DataSource = dt3
        DataGridView1.Columns(0).Visible = False
    End Sub
    Public Sub Data2()
        Dim adpt As New MySqlDataAdapter("SELECT ID_Number,Name_of_books,Name,Grade_Level,Strand_Course,Staff_Student_Teacher,Category,DATE_FORMAT(Date_of_borrow, '%M %e, %Y') AS Borrow_Date,DATE_FORMAT(Date_of_return, '%M %e, %Y') AS Return_Date FROM borrow_log", db.conn)
        Dim dt2 As New DataTable
        adpt.Fill(dt2)
        DataGridView3.DataSource = dt2


    End Sub

    Public Sub Data1()
        Dim adpt As New MySqlDataAdapter("SELECT * FROM books", db.conn)
        Dim dt2 As New DataTable
        adpt.Fill(dt2)
        DataGridView2.DataSource = dt2
        DataGridView2.Columns(0).Visible = False
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DataGridView2.Show()
        Button5.Hide()
        Button8.Hide()
        Button9.Visible = False




    End Sub

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button2.Show()
        Button3.Show()
        DataGridView2.Hide()
        Button1.Hide()
        Button4.Hide()
        Button5.Hide()
        DataGridView3.Hide()
        Button8.Hide()
        Data2()
        TextBox1.Hide()
        Button6.Hide()
        TextBox2.Hide()
        DataGridView1.Hide()
        Button11.Hide()
        TextBox3.Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DataGridView2.Show()
        DataGridView3.Hide()
        DataGridView1.Hide()
        Button5.Show()
        Button8.Hide()
        Button9.Visible = False
        Button1.Show()
        Data1()
        Data2()
        Button9.Show()
        TextBox1.Show()
        Button6.Show()
        TextBox2.Hide()
        Button4.Hide()
        Button11.Hide()
        TextBox3.Hide()

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        ADD_BOOKS.Show()

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If MsgBox("Are you sure you want to exit?", MsgBoxStyle.Information + MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Application.Exit()
        End If


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        DataGridView3.Show()
        DataGridView2.Hide()
        DataGridView1.Hide()
        Button5.Hide()
        Button8.Show()
        Button9.Visible = False
        Data2()
        Data1()
        Button1.Hide()
        Button4.Show()
        Button6.Show()
        TextBox1.Hide()
        TextBox2.Show()
        Button11.Hide()
        TextBox3.Hide()








    End Sub


    Private Sub Button9_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        If selected = Nothing Then
            MsgBox("Choose book to delete", MsgBoxStyle.Information)
        Else
            If MsgBox("Are you sure you want to delete this book?", MsgBoxStyle.OkCancel + MsgBoxStyle.Exclamation) = MsgBoxResult.Ok Then
                db.conn.Open()
                Dim dlt As New MySqlCommand("DELETE FROM books WHERE Book_Title=@param", db.conn)
                With dlt
                    .Parameters.AddWithValue("@param", selected)
                    .ExecuteNonQuery()
                End With
                db.conn.Close()
                selected = Nothing
                Data1()
            End If
        End If
    End Sub

    Private Sub DataGridView2_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellClick

        Try
            Dim row As DataGridViewRow = DataGridView2.CurrentRow
            selected = row.Cells("Book_Title").Value.ToString
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataGridView3_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView3.CellClick
        Try
            Dim row As DataGridViewRow = DataGridView3.CurrentRow
            Using adpt As New MySqlDataAdapter($"SELECT BookID FROM borrow_log WHERE ID_Number='{row.Cells(0).Value.ToString()}' AND Name_of_books='{row.Cells(1).Value.ToString()}'", db.conn)
                Using dt As New DataTable
                    adpt.Fill(dt)
                    selected = dt.Rows(0)(0).ToString
                End Using
            End Using
            selectecNameOfBooks = row.Cells("Name_of_books").Value.ToString
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If selected = Nothing Then
            MsgBox("Choose book to return", MsgBoxStyle.Exclamation)
        Else
            db.conn.Open()

            Using toreport As New MySqlCommand("INSERT INTO reports SELECT BookID,ID_Number,Name_of_books,Category,Name,Grade_Level,Strand_Course,Staff_Student_Teacher,Date_of_borrow,Date_of_return,'RETURNED' FROM borrow_log WHERE BookID=@bookid", db.conn)
                With toreport
                    .Parameters.AddWithValue("@bookid", selected)
                    .ExecuteNonQuery()
                End With
            End Using


            Dim dlt1 As New MySqlCommand("UPDATE books SET Number_of_books=Number_of_books+1 WHERE Book_Title=@title", db.conn)
            With dlt1
                .Parameters.AddWithValue("@title", selectecNameOfBooks)
                .ExecuteNonQuery()
            End With
            Dim dlt As New MySqlCommand("DELETE FROM borrow_log WHERE BookID=@id", db.conn)
            With dlt
                .Parameters.AddWithValue("@id", selected)
                .ExecuteNonQuery()
            End With


            db.conn.Close()
            selected = Nothing
            selectecNameOfBooks = Nothing
            MsgBox("Book Returned", MsgBoxStyle.Information, "Notice")
            Data2()
            Data1()
        End If
    End Sub



    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If selected = Nothing Then
            MsgBox("Choose book to borrow")
        Else
            MsgBox("Borrowed", vbOKOnly, "Successful")
            db.conn.Open()

            Dim dlt As New MySqlCommand("INSERT INTO borrow_log SELECT * FROM books WHERE Book_Title=@param", db.conn)
            With dlt
                .Parameters.AddWithValue("@param", selected)
                .ExecuteNonQuery()
            End With

            Dim dlt1 As New MySqlCommand("DELETE FROM books WHERE Book_Title=@param", db.conn)
            With dlt1
                .Parameters.AddWithValue("@param", selected)
                .ExecuteNonQuery()
            End With

            db.conn.Close()
            Data2()
            selected = Nothing
            db.conn.Close()
            selected = Nothing
        End If

    End Sub


    Private Sub ComboBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.bookid = DataGridView2.CurrentRow.Cells("BookID").Value.ToString()
        Form1.TextBox1.Text = DataGridView2.CurrentRow.Cells(1).Value.ToString()
        Form1.TextBox2.Text = DataGridView2.CurrentRow.Cells(2).Value.ToString()
        Form1.TextBox3.Text = DataGridView2.CurrentRow.Cells(3).Value.ToString()
        Form1.TextBox4.Text = DataGridView2.CurrentRow.Cells(4).Value.ToString()
        Form1.ComboBox1.Text = DataGridView2.CurrentRow.Cells(5).Value.ToString()
        Form1.Show()

    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

    End Sub

    Private Sub DataGridView2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentDoubleClick

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView2_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView2.CellMouseDoubleClick
        Dim cmd As New MySqlCommand("INSERT INTO borrow_log(ID_Number,Name_of_books,name,Grade&Level,Stand&Course&Section,Staff&Student&Teacher,Date_of_borrow,Date_of_borrow) VALUES(@idnumber,@name_of_books,@Name,@Grade&Level,@Strand&Course&Section,@Staff&Student&Teacher,@Date_of_borrow,@Date_of_return)", db.conn)
        With cmd

            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
                Dim selectedrow = DataGridView2.Rows(e.RowIndex)
            End If
            Dim selected As DataGridViewRow

            selected = DataGridView2.Rows(e.RowIndex)
            Borrow_form.Textbox2.Text = selected.Cells(0).Value.ToString()
            Borrow_form.TextBox1.Text = selected.Cells(1).Value.ToString()
            Borrow_form.ComboBox4.Text = selected.Cells(5).Value.ToString()
            Borrow_form.Show()

        End With
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Dim bookid As String
        Form5.TextBox3.Text = DataGridView3.CurrentRow.Cells(0).Value.ToString()
        Form5.TextBox1.Text = DataGridView3.CurrentRow.Cells(1).Value.ToString()
        Form5.TextBox2.Text = DataGridView3.CurrentRow.Cells(2).Value.ToString()
        Form5.ComboBox2.Text = DataGridView3.CurrentRow.Cells(3).Value.ToString()
        Form5.ComboBox3.Text = DataGridView3.CurrentRow.Cells(4).Value.ToString()
        Form5.ComboBox4.Text = DataGridView3.CurrentRow.Cells(5).Value.ToString()
        Form5.ComboBox1.Text = DataGridView3.CurrentRow.Cells(6).Value.ToString()

        Using adpt As New MySqlDataAdapter($"SELECT BookID FROM borrow_log WHERE ID_Number='{DataGridView3.CurrentRow.Cells(0).Value.ToString()}' AND Name_of_books='{DataGridView3.CurrentRow.Cells(1).Value.ToString()}'", db.conn)
            Using dt As New DataTable
                adpt.Fill(dt)
                Form5.bookid = dt.Rows(0)(0).ToString
                bookid = dt.Rows(0)(0).ToString
            End Using
        End Using

        'MsgBox(selected)

        Using adpt As New MySqlDataAdapter($"SELECT Date_of_borrow,Date_of_return FROM borrow_log WHERE BookID={bookid}", db.conn)
            Using dt As New DataTable
                adpt.Fill(dt)
                Form5.DateTimePicker1.Value = Convert.ToDateTime(dt.Rows(0)(0).ToString).ToString("d/M/yyyy")
                Form5.DateTimePicker2.Value = Convert.ToDateTime(dt.Rows(0)(1).ToString).ToString("d/M/yyyy")
            End Using
        End Using
        Form5.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = Nothing Or TextBox1.Text = "Search" Then
            Data1()
        Else
            Dim adpt As New MySqlDataAdapter("SELECT * FROM books WHERE Book_Title LIKE '%" & TextBox1.Text & "%' OR Book_Publisher LIKE '%" & TextBox1.Text & "%' OR Book_Shelf LIKE '%" & TextBox1.Text & "%' OR Number_of_books LIKE '%" & TextBox1.Text & "%' OR Category LIKE '%" & TextBox1.Text & "%'", db.conn)
            Dim dt As New DataTable
            adpt.Fill(dt)
            DataGridView2.DataSource = dt
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text = Nothing Or TextBox2.Text = "Search" Then
            Data2()
        Else
            Dim adpt As New MySqlDataAdapter("SELECT * FROM borrow_log WHERE ID_Number LIKE '%" & TextBox2.Text & "%' OR Name_of_books LIKE '%" & TextBox2.Text & "%' OR Name LIKE '%" & TextBox2.Text & "%' OR Grade_Level LIKE  '%" & TextBox2.Text & "%' OR Strand_Course LIKE '%" & TextBox2.Text & "%' OR Staff_Student_Teacher LIKE '%" & TextBox2.Text & "%' OR Category LIKE '%" & TextBox2.Text & "%'", db.conn)
            Dim dt As New DataTable
            adpt.Fill(dt)
            DataGridView3.DataSource = dt
        End If
    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim dialog As DialogResult
        dialog = MessageBox.Show("Do you really want to close the app?", "Exit", MessageBoxButtons.YesNo)
        If dialog = DialogResult.No Then
            e.Cancel = True
        Else
            Application.ExitThread()
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Button2.Show()
        Button3.Show()
        Button5.Hide()
        Button4.Hide()
        Button1.Hide()
        Button7.Hide()
        Button9.Hide()
        Button8.Hide()
        Data3()
        DataGridView1.Show()
        Button11.Show()
        TextBox2.Hide()
        TextBox1.Hide()
        Button6.Show()
        TextBox3.Show()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If viewReportSelected = Nothing Then
            MsgBox("Choose a book to return", MsgBoxStyle.Exclamation)
        Else
            db.conn.Open()

            Using checkIfReturned As New MySqlDataAdapter($"SELECT status FROM reports WHERE BorrowID='{viewReportSelected}'", db.conn)
                Using checkDT As New DataTable
                    checkIfReturned.Fill(checkDT)

                    If checkDT.Rows(0)(0) = "RETURNED" Then
                        MsgBox("Book already returned")
                        db.conn.Close()
                        Exit Sub
                    End If

                End Using
            End Using

            Using toreport As New MySqlCommand("UPDATE reports SET status='RETURNED' WHERE BorrowID=@borrowid", db.conn)
                With toreport
                    .Parameters.AddWithValue("@borrowid", viewReportSelected)
                    .ExecuteNonQuery()
                End With
            End Using


            Dim dlt1 As New MySqlCommand("UPDATE books SET Number_of_books=Number_of_books+1 WHERE Book_Title=@title", db.conn)
            With dlt1
                .Parameters.AddWithValue("@title", selectecNameOfBooks)
                .ExecuteNonQuery()
            End With


            db.conn.Close()
            selected = Nothing
            selectecNameOfBooks = Nothing
            viewReportSelected = Nothing
            MsgBox("Book Returned", MsgBoxStyle.Information, "Notice")
            Data2()
            Data1()
            Data3()
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim row As DataGridViewRow = DataGridView1.CurrentRow
            viewReportSelected = row.Cells("BorrowID").Value.ToString
            selectecNameOfBooks = row.Cells("Name_of_books").Value.ToString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If TextBox3.Text = Nothing Or TextBox3.Text = "Search" Then
            Data3()
        Else
            Dim adpt As New MySqlDataAdapter("SELECT * FROM reports WHERE BorrowID LIKE '%" & TextBox3.Text & "%' OR Name_of_books Like '%" & TextBox3.Text & "%' OR Category LIKE '%" & TextBox3.Text & "%' OR Name LIKE '%" & TextBox3.Text & "%' OR Grade_Level LIKE '%" & TextBox3.Text & "%' OR Strand_Course LIKE '%" & TextBox3.Text & "%' OR Staff_Student_Teacher LIKE '%" & TextBox3.Text & "%' OR Status LIKE '%" & TextBox3.Text & "%'", db.conn)
            Dim dt3 As New DataTable
            adpt.Fill(dt3)
            DataGridView1.DataSource = dt3
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) 

    End Sub
End Class