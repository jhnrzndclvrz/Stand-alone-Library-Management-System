Imports MySql.Data.MySqlClient
Public Class DB
    'Public conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\dawns\OneDrive\Documents\Studentlog.accdb")
    Public conn As New MySqlConnection("host=localhost;database=library;user=root;pwd=;port=3306")
End Class
