Imports System.Data.SqlClient

Public Class prog
    Private g As String
    Private gun As String
    Public prog_o_no As Integer
    Public kod As String
    Public ad As String
    Public derskodu As Integer
    Public soyad As String
    Private sql As String
    Private baglanti As New SqlConnection("server=.\SQLEXPRESS; database=proje; trusted_connection=yes;")
    Private com As New SqlCommand()
    
    Sub baglan()
        com.Connection = baglanti
        com.CommandText = sql
        baglanti.Open()
        com.ExecuteNonQuery()
        baglanti.Close()

    End Sub
    
    Sub listele()
        gun = ogrenci_frm.prog_gunler_txt.SelectedItem.ToString
        sql = "select ders_adi, ders_saati from dersler_tbl where prog_kodu=" & derskodu & " and gun='" & gun & "'"
        Dim adapt As New SqlDataAdapter(sql, baglanti)
        Dim ds As New DataSet()
        adapt.Fill(ds, "DersProgrami")
        ogrenci_frm.program_grd.DataSource = ds.Tables("DersProgrami")
        ogrenci_frm.program_grd.Refresh()
    End Sub
    
    
    Sub textaktar()
        
            sql = "SELECT * from ogrenci_sicil_tbl WHERE numarasi = " & prog_o_no & ""
            Dim satir1 As DataRow
            Dim adapt As New SqlDataAdapter(sql, baglanti)
            Dim ds As New DataSet("ds")
            adapt.Fill(ds, "ogrenci")
            satir1 = ds.Tables("ogrenci").Rows(0)
            ad = satir1("adi").ToString
            soyad = satir1("soyadi").ToString
            derskodu = satir1("b_kodu").ToString

            //çağrı

        End Try


    End Sub
