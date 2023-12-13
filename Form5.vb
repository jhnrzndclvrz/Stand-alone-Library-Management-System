Imports MySql.Data.MySqlClient
Public Class Form5
    Dim db As New DB
    Public bookid As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        db.conn.Open()
        Dim borrowDateFormat As Date = DateTimePicker1.Text
        Dim returnDateFormat As Date = DateTimePicker2.Text
        Dim updt As New MySqlCommand("UPDATE borrow_log SET ID_Number=@idnumber,Name=@name,Grade_Level=@Gradelevel,Strand_Course=@StrandCourse,Staff_Student_Teacher=@StaffStudentTeacher,Category=@Category,Date_of_borrow=@Date_of_borrow,Date_of_return=@Date_of_return WHERE BookID=@id", db.conn)
        With updt
            updt.Parameters.AddWithValue("@idnumber", TextBox3.Text)
            updt.Parameters.AddWithValue("@name", TextBox2.Text)
            updt.Parameters.AddWithValue("@GradeLevel", ComboBox2.Text)
            updt.Parameters.AddWithValue("@StrandCourse", ComboBox3.Text)
            updt.Parameters.AddWithValue("@StaffStudentTeacher", ComboBox4.Text)
            updt.Parameters.AddWithValue("@Category", ComboBox1.Text)
            updt.Parameters.AddWithValue("@id", bookid)
            updt.Parameters.AddWithValue("@Date_of_borrow", borrowDateFormat.ToString("yyyy-MM-d"))
            updt.Parameters.AddWithValue("@Date_of_return", returnDateFormat.ToString("yyyy-MM-d"))
            updt.ExecuteNonQuery()
        End With
        db.conn.Close()
        Main.Data2()
        Main.Data1()
        Me.Close()
        MsgBox("Update Successfully", MsgBoxStyle.Information)
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
    End Sub

    Private Sub ComboBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox2.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox3.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox4.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        e.Handled = True
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.Enabled = False
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class