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
    Private baglanti As New SqlConnection("server=.\SQLEXPRESS; database=proje_dershane; trusted_connection=yes;")
    Private com As New SqlCommand()
    
    Sub isim_ata()
        Dim a As Integer
        a = (ogrenci_frm.prog_kodu_txt.Text)
        If a = 1 Then g = "EA1"
        If a = 2 Then g = "SAY1"
        If a = 3 Then g = "SOZ1"
        If a = 4 Then g = "EA2"
        If a = 5 Then g = "SAY2"
        If a = 6 Then g = "SOZ2"
        ogrenci_frm.prog_adi_txt.Text = g
    End Sub
    
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
            
       ogrenci_frm.prog_ogr_adi_txt.Text = ad
            ogrenci_frm.prog_ogr_soyadi_txt.Text = soyad
            ogrenci_frm.prog_kodu_txt.Text = derskodu
        Catch
            ogrenci_frm.prog_ogr_adi_txt.Text = ""
            ogrenci_frm.prog_ogr_soyadi_txt.Text = ""
            ogrenci_frm.prog_kodu_txt.Text = ""
            ogrenci_frm.prog_adi_txt.Text = ""
            MsgBox("Lütfen geçerli değerler giriniz!")
            ogrenci_frm.prog_ogr_no_txt.Focus()
        Finally
            baglan()
        End Try


    End Sub


    Public Property ogrenci_nosu()
        Get
            Return prog_o_no
        End Get
        Set(ByVal value)
            prog_o_no = value
        End Set
    End Property

End Class

