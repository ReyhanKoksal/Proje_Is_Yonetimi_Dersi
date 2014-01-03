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
    Private baglanti As New SqlConnection("server=.\SQLEXPRESS; database=proje_dershane; trusted_connection=yes;")
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
    
   Sub isim_ata()
        Dim a As Integer
        a = (ogrenci_frm.dev_sinifii_no_txt.Text)
        If a = 1 Then g = "EA1"
        If a = 2 Then g = "SAY1"
        If a = 3 Then g = "SOZ1"
        If a = 4 Then g = "EA2"
        If a = 5 Then g = "SAY2"
        If a = 6 Then g = "SOZ2"
        ogrenci_frm.dev_sinifi_txt.Text = g
    End Sub
    
    Sub listele()
        sql = "select * from devamsizlik_tbl"
        Dim adapt As New SqlDataAdapter(sql, baglanti)
        Dim ds As New DataSet()
        adapt.Fill(ds, "Devamsizlik")
        ogrenci_frm.dev_liste.DataSource = ds.Tables("Devamsizlik")
        ogrenci_frm.dev_liste.Refresh()
        ogrenci_frm.dev_liste.Columns(0).HeaderText = "Numarası"
        ogrenci_frm.dev_liste.Columns(1).HeaderText = "Adı"
        ogrenci_frm.dev_liste.Columns(2).HeaderText = "Soyadı"
        ogrenci_frm.dev_liste.Columns(3).HeaderText = "Sınıfı"
        ogrenci_frm.dev_liste.Columns(4).HeaderText = "Tarihi"
        ogrenci_frm.dev_liste.Columns(5).HeaderText = "Türü"
      
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
    
        Sub cikis()
        End
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
        ogrenci_frm.dev_adi_txt.Text = ad
            ogrenci_frm.dev_soyadi_txt.Text = soyad
            ogrenci_frm.dev_sinifii_no_txt.Text = derskodu
        Catch
            ogrenci_frm.dev_adi_txt.Text = ""
            ogrenci_frm.dev_soyadi_txt.Text = ""
            ogrenci_frm.dev_sinifii_no_txt.Text = ""
            ogrenci_frm.dev_sinifi_txt.Text = ""
            MsgBox("Lütfen geçerli değerler giriniz!")
            ogrenci_frm.dev_ogr_no_txt.Focus()
        Finally
            baglan()
        End Try
    End Sub
    Public Property ogrenci_nosu()
        Get
            Return o_no
        End Get
        Set(ByVal value)
            o_no = value
        End Set
    End Property
    Public Property devamsizlik_tarihi()
        Get
            Return dev_tarihi
        End Get
        Set(ByVal value)
            dev_tarihi = value
        End Set
    End Property
    Public Property devamsizlik_turu()
        Get
            Return dev_turu
        End Get
        Set(ByVal value)
            dev_turu = value
        End Set
    End Property
    Public Property adi()
        Get
            Return ad
        End Get
        Set(ByVal value)
            ad = value
        End Set
    End Property
    Public Property soyadi()
        Get
            Return soyad
        End Get
        Set(ByVal value)
            soyad = value
        End Set
    End Property
    Public Property sinifi()
        Get
            Return g
        End Get
        Set(ByVal value)
            g = value
        End Set
    End Property
End Class

    
    
