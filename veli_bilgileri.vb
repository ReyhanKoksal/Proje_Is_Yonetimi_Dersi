Imports System.Data.SqlClient

Public Class veli_bilgileri
    Private ogr_no As Integer
    Private veli_tcno As String
    Private veli_ad As String
    Private veli_soyad As String
    Private veli_yakinligi As String
    Private veli_meslegi As String
    Private veli_geliri As String
    Private veli_adres As String
    Private veli_ilce As String
    Private veli_il As String
    Private veli_posta As String
    Private veli_tel As String
    Private veli_cep_tel As String
    Private veli_is_tel As String
    Private veli_is_fax As String
    Private veli_is_adres As String
    Private veli_is_ilce As String
    Private veli_is_il As String
    Private veli_is_posta As String
    Private veli_mail As String

    Public no As String
    Public ad As String
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

    Sub textaktar()
        Try
            sql = "SELECT * from ogrenci_sicil_tbl WHERE numarasi = " & ogr_no & ""
            Dim satir1 As DataRow
            Dim adapt As New SqlDataAdapter(sql, baglanti)
            Dim ds As New DataSet("ds")
            adapt.Fill(ds, "ogrenci")
            satir1 = ds.Tables("ogrenci").Rows(0)
            ad = satir1("adi").ToString
            soyad = satir1("soyadi").ToString

           
            baglan()
        
        
        //çağrı
        
    End Sub
    
     Sub kontrol()
        ogrenci_frm.v_bilgi_ata()
        no = ogrenci_frm.tc_txt.Text
        sql = "select * from veli_sicil_tbl where tc = '" & no & "'"
        baglan()
        Dim satir1 As DataRow
        Dim adapt As New SqlDataAdapter(sql, baglanti)
        Dim ds As New DataSet("ds")
        adapt.Fill(ds, "Kontrol")
        Try
            satir1 = ds.Tables("Kontrol").Rows(0)
            MsgBox("Bu tc ye sahip bir kayıt zaten var!")
            ogrenci_frm.tc_txt.Focus()
        Catch
            ogrenci_frm.v_bilgi_ata()
            no = ogrenci_frm.tc_txt.Text
            sql = "select * from veli_sicil_tbl where  ogr_no = '" & ogr_no & "'"
            baglan()
            Dim satir As DataRow
            Dim a As New SqlDataAdapter(sql, baglanti)
            Dim data As New DataSet("data")
            a.Fill(data, "Kontrol")
            Try
                satir = data.Tables("Kontrol").Rows(0)
                MsgBox("Bu ogrenciye ait bir kayıt zaten var!")
                ogrenci_frm.veli_ogr_no_txt.Focus()
            Catch
                If ogrenci_frm.veli_email_txt.Text = "" Then
                    ekle()
                Else
                    If ogrenci_frm.et1 = 1 And ogrenci_frm.nokta1 = 1 Then
                        ekle()
                    Else
                        MsgBox("Geçersiz E-Mail Adresi! Lütfen Kontrol Ediniz")
                    End If
                End If

            End Try
        End Try
    End Sub
    
    Sub listele()
        sql = "select * from veli_sicil_tbl"
        Dim adapt As New SqlDataAdapter(sql, baglanti)
        Dim ds As New DataSet()
        adapt.Fill(ds, "VeliListesi")
        
        
        //çağrı
        
        
    End Sub
    
    
     Sub ekle()
        sql = "insert into veli_sicil_tbl(ogr_no,tc,ad,soyad,yakinlik,meslek,gelir,e_adres,e_ilce,e_il,e_p_kod,ev_tel,cep_tel,is_tel,fax,i_adres,i_ilce,i_il,i_p_kod,email) values ('" & ogr_no & "','" & veli_tcno & "','" & veli_ad & "','" & veli_soyad & "','" & veli_yakinligi & "','" & veli_meslegi & "','" & veli_geliri & "','" & veli_adres & "','" & veli_ilce & "','" & veli_il & "','" & veli_posta & "','" & veli_tel & "','" & veli_cep_tel & "','" & veli_is_tel & "','" & veli_is_fax & "','" & veli_is_adres & "','" & veli_is_ilce & "','" & veli_is_il & "','" & veli_is_posta & "','" & veli_mail & "')"
        baglan()
        listele()
    End Sub
    Sub guncelle()
        sql = "update veli_sicil_tbl set ogr_no='" & ogr_no & "', tc='" & veli_tcno & "',ad='" & veli_ad & "',soyad='" & veli_soyad & "',yakinlik='" & veli_yakinligi & "',meslek='" & veli_meslegi & "',gelir='" & veli_geliri & "',e_adres='" & veli_adres & "',e_ilce='" & veli_ilce & "',e_il='" & veli_il & "',e_p_kod='" & veli_posta & "',ev_tel='" & veli_tel & "',cep_tel='" & veli_cep_tel & "',is_tel='" & veli_is_tel & "',fax='" & veli_is_fax & "',i_adres='" & veli_is_adres & "',i_ilce='" & veli_is_ilce & "',i_il='" & veli_is_il & "',i_p_kod='" & veli_is_posta & "',email='" & veli_mail & "' where ogr_no='" & ogr_no & "'"
        baglan()
        listele()
    End Sub
    Sub sil()
        sql = "delete from veli_sicil_tbl where ogr_no='" & ogr_no & "'"
        baglan()
        listele()
    End Sub
    Sub ara()
        sql = "select * from veli_sicil_tbl where ogr_no='" & ogr_no & "'"
        Dim adapt As New SqlDataAdapter(sql, baglanti)
        Dim ds As New DataSet()
        adapt.Fill(ds, "Veli Listesi")
        ogrenci_frm.veli_sicil_grd.DataSource = ds.Tables("Veli Listesi")
        ogrenci_frm.veli_sicil_grd.Refresh()
    End Sub
    
    End Class
