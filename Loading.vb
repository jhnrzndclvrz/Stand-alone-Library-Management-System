Imports MySql.Data.MySqlClient

Public Class Loading
    Dim db As New DB

    Public Sub checkReturnDate()
        Dim getAllReturnDates As New MySqlDataAdapter("SELECT Date_of_return,BookID FROM borrow_log", DB.conn)
        Dim datesDT As New DataTable
        getAllReturnDates.Fill(datesDT)

        Dim today As Date = Date.Now.ToString("dd/MM/yyyy")

        db.conn.Open()

        For Each el As DataRow In datesDT.Rows
            Dim toDate As Date = el(0).ToString
            If today > toDate.ToString("dd/MM/yyyy") Then
                Using actioncmd As New MySqlCommand("INSERT INTO reports(ID_Number,Name_of_books,Category,Name,Grade_Level,Strand_Course,Staff_Student_Teacher,Date_of_borrow,Date_of_return,Status) SELECT ID_Number,Name_of_books,Category,Name,Grade_Level,Strand_Course,Staff_Student_Teacher,Date_of_borrow,Date_of_return,'MISSING' FROM borrow_log WHERE BookID=@bookid", db.conn)
                    With actioncmd
                        .Parameters.AddWithValue("@bookid", el(1))
                        .ExecuteNonQuery()
                    End With
                End Using
                Using cmd As New MySqlCommand("DELETE FROM borrow_log WHERE BookID=@bookid", db.conn)
                    With cmd
                        .Parameters.AddWithValue("@bookid", el(1))
                        .ExecuteNonQuery()
                    End With
                End Using
            End If
        Next

        db.conn.Close()

        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub Loading_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        checkReturnDate()
    End Sub

    Private Sub Loading_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub Loading_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class