Imports System.Data.SqlClient
Public Class dersler
    Private kod As Integer
    Private sql As String
    Private baglanti As New SqlConnection("server=.\SQLEXPRESS; database=proje_dershane; trusted_connection=yes;")
    Private com As New SqlCommand()
    
    Sub baglan()
        com.Connection = baglanti
        com.CommandText = sql
        baglanti.Open()
        com.ExecuteNonQuery()
        baglanti.Close()
    End Sub
    
    Sub listele()
        kod = CInt(ogrenci_frm.prog_kodu_txt.Text)
        sql = "select * from dersler_tbl where prog_kodu='" & kod & "'"
        Dim adapt As New SqlDataAdapter(sql, baglanti)
        Dim ds As New DataSet()
        adapt.Fill(ds, "Ders Programı")
        ogrenci_frm.program_grd.DataSource = ds.Tables("Ders Programı")
        ogrenci_frm.program_grd.Refresh()
    End Sub
    
    Public Property kodu()
        Get
            Return kod
        End Get
        Set(ByVal value)
            kod = value
        End Set
    End Property
    
    
    End Class
