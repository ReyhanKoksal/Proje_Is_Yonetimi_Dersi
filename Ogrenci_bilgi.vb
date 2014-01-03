Imports System.Data.SqlClient
Public Class personel_bilgi
    Private personel_nosu As Integer
    Private personel_adi As String
    Private personel_soyadi As String
    Private personel_adresi As String
    Private personel_dogum_yeri As String
    Private personel_dogum_tarihi As String
    Private personel_gorevi As String
    Private personel_meb_sicil_nosu As String
    Private personel_sigorta_sicil_nosu As String
    Private personel_ev_telefonu As String
    Private personel_cep_telefonu As String
    Private personel_ogrenım_durumu As String
    Private personel_ucreti As String
    Private personel_grubu As String
    Private personel_giris_tarihi As String
    Private personel_tc_nosu As String
    Private personel_baba_adi As String
    Private personel_ana_adi As String
    Private personel_dini As String
    Private personel_medeni_hali As String
    Private personel_ili As String
    Private personel_ilcesi As String
    Private personel_mahallesi As String
    Private personel_hane_sıra_nosu As String
    Private personel_cilt_nosu As String
    Private personel_sayfa_nosu As String
    
    
    Private sql As String
    Private baglanti As New SqlConnection("server=.\SQLEXPRESS; database=proje_dershane; trusted_connection=yes;")
    Private com As New SqlCommand()


    Sub kontrol()
        ogrenci_frm.bilgi_ata()
        no = CInt(personel_frm.p_no_txt.Text)
        sql = "select * from personel_tbl where no = '" & no & "'"
        baglan()
        Dim satir1 As DataRow
        Dim adapt As New SqlDataAdapter(sql, baglanti)
        Dim ds As New DataSet("ds")
        adapt.Fill(ds, "Kontrol")
        Try
            satir1 = ds.Tables("Kontrol").Rows(0)
            MsgBox("Bu no da bir kayıt zaten var!")
            personel_frm.p_no_txt.Focus()
        Catch
        If ogrenci_frm.sicil_email_txt.Text = "" Then
            ekle()
            Else
                If ogrenci_frm.et = 1 And ogrenci_frm.nokta = 1 Then
                    ekle()
                Else
                    MsgBox("Geçersiz E-Mail Adresi! Lütfen Kontrol Ediniz")
                End If
            End If
        End Try
    End Sub
    

    Sub baglan()
        com.Connection = baglanti
        com.CommandText = sql
        baglanti.Open()
        com.ExecuteNonQuery()
        baglanti.Close()
    End Sub
    
    
    Sub listele()
        sql = "select * from ogrenci_sicil_tbl"
        Dim adapt As New SqlDataAdapter(sql, baglanti)
        Dim ds As New DataSet()
        adapt.Fill(ds, "ogr_liste")
        
        
        //çağrı
        
    End Sub
    
        Sub guncelle()
        sql = "update personel_tbl set ad='" & personel_adi & "', soyad='" & personel_soyadi & "', dog_yeri='" & personel_dogum_yeri & "',dog_tar='" & personel_dogum_tarihi & "',gorev='" & personel_gorevi & "',meb_s_no='" & personel_meb_sicil_nosu & "',sig_s_no='" & personel_sigorta_sicil_nosu & "',ev_tel='" & personel_ev_telefonu & "',cep_tel='" & personel_cep_telefonu & "',ogr_durum='" & personel_ogrenım_durumu & "',ucret='" & personel_ucreti & "',grup='" & personel_grubu & "',gir_tar='" & personel_giris_tarihi & "',tc_no='" & personel_tc_nosu & "',baba_ad='" & personel_baba_adi & "',ana_ad='" & personel_ana_adi & "',din='" & personel_dini & "',medeni_hal='" & personel_medeni_hali & "',il='" & personel_ili & "',ilce='" & personel_ilce & "',mah='" & personel_mahallesi & "',hane_s_no='" & personel_hane_sıra_nosu & "',cilt_no='" & personel_cilt_nosu & "',sayfa_no='" & personel_sayfa_nosu & "'"
        baglan()
        listele()
        
    End Sub
    
  
    Sub ara()
       sql = "select * from ogrenci_sicil_tbl where numarasi='" & no & "'"
        Dim adapt As New SqlDataAdapter(sql, baglanti)
        Dim ds As New DataSet()
        adapt.Fill(ds, "Ogrenci Listesi")
        ogrenci_frm.ogrenci_sicil_grd.DataSource = ds.Tables("Ogrenci Listesi")
        ogrenci_frm.ogrenci_sicil_grd.Refresh()
    End Sub
    
    Sub sil()
        sql = "delete from ogrenci_sicil_tbl where numarasi='" & no & "'"
        baglan()
        listele()
    End Sub
    
    Sub cikis()
        End
    End Sub
    
    Sub ekle()
        sql = "INSERT INTO ogrenci_sicil_tbl(numarasi,adi,soyadi,cinsiyeti,d_tarihi,adresi,ili,ilcesi,p_kodu,ev_tel,cep_tel,email,b_kodu) values ('" & no & "','" & ad & "','" & soyad & "','" & cinsiyet & "','" & dogtar & "','" & adres & "','" & il & "','" & ilce & "','" & postakodu & "','" & evtel & "','" & ceptel & "','" & email & "','" & bolum & "')"
        baglan()
        listele()
        temizle()
    End Sub
    
    Sub temizle()
       
       
       //çağrı
       
       
    End Sub

    
    //çağrı değişken atamaları
    
    
End Class
