Imports System.Data.SqlClient

Public Class Devamsizlik
    Private dev_tarihi As String
    Private dev_turu As String
    Private g As String
    Private o_no As Integer
    
    Public ad As String
    Public derskodu As Integer
    Public no As integer
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
Sub kontrol()
        no = CInt(ogrenci_frm.dev_ogr_no_txt.Text)
        sql = "select * from devamsizlik_tbl where ogr_no = '" & o_no & "'"
        baglan()
        Dim satir1 As DataRow
        Dim adapt As New SqlDataAdapter(sql, baglanti)
        Dim ds As New DataSet("ds")
        adapt.Fill(ds, "Kontrol")
        Try
            satir1 = ds.Tables("Kontrol").Rows(0)
            MsgBox("Bu numaraya sahip bir kayıt zaten var!")
            ogrenci_frm.dev_ogr_no_txt.Focus()
        Catch
            ekle()
        End Try
    End Sub
    
    
    Sub listele()
        sql = "select * from devamsizlik_tbl"
        Dim adapt As New SqlDataAdapter(sql, baglanti)
        Dim ds As New DataSet()
        adapt.Fill(ds, "Devamsizlik")
        ogrenci_frm.dev_liste.DataSource = ds.Tables("Devamsizlik")
        
        
        
      //çağrı
      
      
    End Sub
    
    Sub ara()
        sql = "select * from devamsizlik_tbl where ogr_no='" & o_no & "'"
        Dim adapt As New SqlDataAdapter(sql, baglanti)
        Dim ds As New DataSet()
        adapt.Fill(ds, "Devamsızlık Listesi")
        ogrenci_frm.dev_liste.DataSource = ds.Tables("Devamsızlık Listesi")
        ogrenci_frm.dev_liste.Refresh()

    End Sub

    Sub ekle()
        sql = "INSERT INTO devamsizlik_tbl(ogr_no,adi,soyadi,sinifi,dev_tarihi,dev_turu) values ('" & o_no & "','" & ad & "','" & soyad & "','" & g & "','" & dev_tarihi & "','" & dev_turu & "')"
        baglan()
        listele()
    End Sub
    
     Sub textaktar()
       
            sql = "SELECT * from ogrenci_sicil_tbl WHERE numarasi = " & o_no & ""
            Dim satir1 As DataRow
            Dim adapt As New SqlDataAdapter(sql, baglanti)
            Dim ds As New DataSet("ds")
            adapt.Fill(ds, "ogrenci")
            satir1 = ds.Tables("ogrenci").Rows(0)
            ad = satir1("adi").ToString
            soyad = satir1("soyadi").ToString
            derskodu = satir1("b_kodu").ToString
           
            baglan()
        
        
        
        // çağrı 
        
        
    End Sub
    
    
    End Class
    
    
    
