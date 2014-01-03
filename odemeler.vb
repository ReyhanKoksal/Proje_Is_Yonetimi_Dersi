Imports System.Data.SqlClient
Public Class odemeler
    Private odeme_o_no As Integer

    Private ad As String
    Private soyad As String
    
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
    Sub odeme_update()
        sql = "update senet_tbl set durum='ödendi' where ogr_no = '" & odeme_o_no & "' and senet_no='" & ogrenci_frm.senetno & "'"
        baglan()
        vericek()
    End Sub
    
     Sub vericek()
        Dim durum As String = "ödenmedi"
        sql = "select * from senet_tbl where ogr_no='" & odeme_o_no & "' and durum='" & durum & "'"
        Dim adapt As New SqlDataAdapter(sql, baglanti)
        Dim ds As New DataSet()
        adapt.Fill(ds, "odemeler_liste")
        ogrenci_frm.odemeler_liste.DataSource = ds.Tables("odemeler_liste")
        ogrenci_frm.odemeler_liste.Refresh()

        // çağrı 
        
    End Sub
    
    
    Sub textaktar()
       
            sql = "SELECT * from ogrenci_sicil_tbl WHERE numarasi = " & odeme_o_no & ""
            Dim satir1 As DataRow
            Dim adapt As New SqlDataAdapter(sql, baglanti)
            Dim ds As New DataSet("ds")
            adapt.Fill(ds, "ogrenci")
            satir1 = ds.Tables("ogrenci").Rows(0)
            ad = satir1("adi").ToString
            soyad = satir1("soyadi").ToString

     
        
            baglan()
        
        // çağrı try catch kontrolleri


    End Sub
    
    // çağrı değişken atama
    
    End Class
