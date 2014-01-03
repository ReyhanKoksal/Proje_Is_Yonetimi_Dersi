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

        ogrenci_frm.odemeler_liste.Columns(0).HeaderText = "Ögrenci Numarası"
        ogrenci_frm.odemeler_liste.Columns(1).HeaderText = "Kurs Ücreti"
        ogrenci_frm.odemeler_liste.Columns(2).HeaderText = "İndirim"
        ogrenci_frm.odemeler_liste.Columns(3).HeaderText = "Toplam Tutar"
        ogrenci_frm.odemeler_liste.Columns(4).HeaderText = "Senet Ödeme Tarihi"
        ogrenci_frm.odemeler_liste.Columns(5).HeaderText = "Senet Numarası"
        ogrenci_frm.odemeler_liste.Columns(6).HeaderText = "Kayıt Tarihi"
        ogrenci_frm.odemeler_liste.Columns(7).HeaderText = "Vade Sayısı"
        ogrenci_frm.odemeler_liste.Columns(8).HeaderText = "Aylık Ödeme Miktarı"
        ogrenci_frm.odemeler_liste.Columns(9).HeaderText = "Ödenme Durumu"
    End Sub

    Sub textaktar()
        Try
            sql = "SELECT * from ogrenci_sicil_tbl WHERE numarasi = " & odeme_o_no & ""
            Dim satir1 As DataRow
            Dim adapt As New SqlDataAdapter(sql, baglanti)
            Dim ds As New DataSet("ds")
            adapt.Fill(ds, "ogrenci")
            satir1 = ds.Tables("ogrenci").Rows(0)
            ad = satir1("adi").ToString
            soyad = satir1("soyadi").ToString

            ogrenci_frm.odeme_ogr_adi_txt.Text = ad
            ogrenci_frm.odeme_ogr_soyadi_txt.Text = soyad
        Catch
            MsgBox("Lütfen geçerli değerler giriniz!")
            ogrenci_frm.odeme_ogr_adi_txt.Text = ""
            ogrenci_frm.odeme_ogr_soyadi_txt.Text = ""
            ogrenci_frm.odemeler_ogr_no_txt.Focus()
        Finally
            baglan()
        End Try

    End Sub
    Public Property odeme_ogr_nosu()
        Get
            Return odeme_o_no
        End Get
        Set(ByVal value)
            odeme_o_no = value
        End Set
    End Property
End Class
