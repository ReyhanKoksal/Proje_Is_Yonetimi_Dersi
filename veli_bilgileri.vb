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
    Private baglanti As New SqlConnection("server=.\SQLEXPRESS; database=proje_dershane; trusted_connection=yes;")
    Private com As New SqlCommand()
    
    Sub baglan()
        com.Connection = baglanti
        com.CommandText = sql
        baglanti.Open()
        com.ExecuteNonQuery()
        baglanti.Close()
    End Sub
    
    Sub temizle() 
    
 ogrenci_frm.ogrenci_adi_txt.Text = ""
        ogrenci_frm.ogrenci_soyadi_txt.Text = ""
        ogrenci_frm.veli_ogr_no_txt.Text = ""
        ogrenci_frm.tc_txt.Text = ""
        ogrenci_frm.veli_ad_txt.Text = ""
        ogrenci_frm.veli_soyad_txt.Text = ""
        ogrenci_frm.veli_adres_txt.Text = ""
        ogrenci_frm.veli_cep_txt.Text = ""
        ogrenci_frm.veli_geliri_txt.Text = ""
        ogrenci_frm.veli_il_txt.Text = ""
        ogrenci_frm.veli_ilce_txt.Text = ""
        ogrenci_frm.veli_posta_kodu_txt.Text = ""
        ogrenci_frm.yakinlik_txt.Text = ""
        ogrenci_frm.veli_email_txt.Text = ""
        ogrenci_frm.veli_is_ili_txt.Text = ""
        ogrenci_frm.veli_is_ilce_txt.Text = ""
        ogrenci_frm.veli_is_posta_kodu_txt.Text = ""
        ogrenci_frm.veli_is_fax_txt.Text = ""
        ogrenci_frm.veli_is_adresi_txt.Text = ""
        ogrenci_frm.veli_meslek_txt.Text = ""
        ogrenci_frm.veli_ev_tel_txt.Text = ""
        ogrenci_frm.veli_is_tel_txt.Text = ""
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

             ogrenci_frm.ogrenci_adi_txt.Text = ad
            ogrenci_frm.ogrenci_soyadi_txt.Text = soyad
        Catch
            MsgBox("Lütfen geçerli değerler giriniz!")
            ogrenci_frm.ogrenci_adi_txt.Text = ""
            ogrenci_frm.ogrenci_soyadi_txt.Text = ""
            ogrenci_frm.veli_ogr_no_txt.Focus()
        Finally
            baglan()
        End Try
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
        ogrenci_frm.veli_sicil_grd.DataSource = ds.Tables("VeliListesi")
        ogrenci_frm.veli_sicil_grd.Refresh()
        ogrenci_frm.veli_sicil_grd.Columns(0).HeaderText = "Öğrenci Numarası"
        ogrenci_frm.veli_sicil_grd.Columns(1).HeaderText = "Veli TC NO"
        ogrenci_frm.veli_sicil_grd.Columns(2).HeaderText = "Veli Adı"
        ogrenci_frm.veli_sicil_grd.Columns(3).HeaderText = "Veli Soyadı"
        ogrenci_frm.veli_sicil_grd.Columns(4).HeaderText = "Yakınlığı"
        ogrenci_frm.veli_sicil_grd.Columns(5).HeaderText = "Mesleği"
        ogrenci_frm.veli_sicil_grd.Columns(6).HeaderText = "Geliri"
        ogrenci_frm.veli_sicil_grd.Columns(7).HeaderText = "Ev Adresi"
        ogrenci_frm.veli_sicil_grd.Columns(8).HeaderText = "Ev İlçesi"
        ogrenci_frm.veli_sicil_grd.Columns(9).HeaderText = "Ev İli"
        ogrenci_frm.veli_sicil_grd.Columns(10).HeaderText = "Ev Posta Kodu"
        ogrenci_frm.veli_sicil_grd.Columns(11).HeaderText = "Ev Telefonu"
        ogrenci_frm.veli_sicil_grd.Columns(12).HeaderText = "Cep Telefonu"
        ogrenci_frm.veli_sicil_grd.Columns(13).HeaderText = "İş Telefonu"
        ogrenci_frm.veli_sicil_grd.Columns(14).HeaderText = "Fax"
        ogrenci_frm.veli_sicil_grd.Columns(15).HeaderText = "İş Adresi"
        ogrenci_frm.veli_sicil_grd.Columns(16).HeaderText = "İş İlçesi"
        ogrenci_frm.veli_sicil_grd.Columns(17).HeaderText = "İş İli"
        ogrenci_frm.veli_sicil_grd.Columns(18).HeaderText = "İş Posta Kodu"
        ogrenci_frm.veli_sicil_grd.Columns(19).HeaderText = "E-Mail"
        

        
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
    
       Sub cikis()
        End
    End Sub
    
   Public Property o_no()
        Get
            Return ogr_no
        End Get
        Set(ByVal value)
            ogr_no = value
        End Set
    End Property

    Public Property v_no()
        Get
            Return veli_tcno
        End Get
        Set(ByVal value)
            veli_tcno = value
        End Set
    End Property

    Public Property v_ad()
        Get
            Return veli_ad
        End Get
        Set(ByVal value)
            veli_ad = value
        End Set
    End Property

    Public Property v_soyad()
        Get
            Return veli_soyad
        End Get
        Set(ByVal value)
            veli_soyad = value
        End Set
    End Property

    Public Property v_yakinligi()
        Get
            Return veli_yakinligi
        End Get
        Set(ByVal value)
            veli_yakinligi = value
        End Set
    End Property

    Public Property v_meslegi()
        Get
            Return veli_meslegi
        End Get
        Set(ByVal value)
            veli_meslegi = value
        End Set
    End Property

    Public Property v_geliri()
        Get
            Return veli_geliri
        End Get
        Set(ByVal value)
            veli_geliri = value
        End Set
    End Property

    Public Property v_mail()
        Get
            Return veli_mail
        End Get
        Set(ByVal value)
            veli_mail = value
        End Set
    End Property

    Public Property v_adres()
        Get
            Return veli_adres
        End Get
        Set(ByVal value)
            veli_adres = value
        End Set
    End Property

    Public Property v_il()
        Get
            Return veli_il
        End Get
        Set(ByVal value)
            veli_il = value
        End Set
    End Property


    Public Property v_ilce()
        Get
            Return veli_ilce
        End Get
        Set(ByVal value)
            veli_ilce = value
        End Set
    End Property

    Public Property v_posta()
        Get
            Return veli_posta
        End Get
        Set(ByVal value)
            veli_posta = value
        End Set
    End Property

    Public Property v_tel()
        Get
            Return veli_tel
        End Get
        Set(ByVal value)
            veli_tel = value
        End Set
    End Property

    Public Property v_is_adres()
        Get
            Return veli_is_adres
        End Get
        Set(ByVal value)
            veli_is_adres = value
        End Set
    End Property

    Public Property v_is_il()
        Get
            Return veli_is_il
        End Get
        Set(ByVal value)
            veli_is_il = value
        End Set
    End Property


    Public Property v_is_ilce()
        Get
            Return veli_is_ilce
        End Get
        Set(ByVal value)
            veli_is_ilce = value
        End Set
    End Property

    Public Property v_is_posta()
        Get
            Return veli_is_posta
        End Get
        Set(ByVal value)
            veli_is_posta = value
        End Set
    End Property

    Public Property v_is_tel()
        Get
            Return veli_is_tel
        End Get
        Set(ByVal value)
            veli_is_tel = value
        End Set
    End Property
    Public Property v_is_fax()
        Get
            Return veli_is_fax
        End Get
        Set(ByVal value)
            veli_is_fax = value
        End Set
    End Property

    Public Property v_cep_tel()
        Get
            Return veli_cep_tel
        End Get
        Set(ByVal value)
            veli_cep_tel = value
        End Set
    End Property
End Class



