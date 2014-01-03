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
    Public no As Integer
    Private sql As String
    Private baglanti As New SqlConnection("server=.\SQLEXPRESS; database=proje; trusted_connection=yes;")
    Private com As New SqlCommand()


    Sub kontrol()
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
            ekle()
        End Try
    End Sub
    

    Sub baglan()
        com.Connection = baglanti
        com.CommandText = sql
        baglanti.Open()
        com.ExecuteNonQuery()
        baglanti.Close()
    End Sub
    Sub guncelle()
        sql = "update personel_tbl set ad='" & personel_adi & "', soyad='" & personel_soyadi & "', dog_yeri='" & personel_dogum_yeri & "',dog_tar='" & personel_dogum_tarihi & "',gorev='" & personel_gorevi & "',meb_s_no='" & personel_meb_sicil_nosu & "',sig_s_no='" & personel_sigorta_sicil_nosu & "',ev_tel='" & personel_ev_telefonu & "',cep_tel='" & personel_cep_telefonu & "',ogr_durum='" & personel_ogrenım_durumu & "',ucret='" & personel_ucreti & "',grup='" & personel_grubu & "',gir_tar='" & personel_giris_tarihi & "',tc_no='" & personel_tc_nosu & "',baba_ad='" & personel_baba_adi & "',ana_ad='" & personel_ana_adi & "',din='" & personel_dini & "',medeni_hal='" & personel_medeni_hali & "',il='" & personel_ili & "',ilce='" & personel_ilce & "',mah='" & personel_mahallesi & "',hane_s_no='" & personel_hane_sıra_nosu & "',cilt_no='" & personel_cilt_nosu & "',sayfa_no='" & personel_sayfa_nosu & "'"
        baglan()
        listele()
    End Sub
    Sub listele()
        sql = "select * from personel_tbl"
        Dim adapt As New SqlDataAdapter(sql, baglanti)
        Dim ds As New DataSet()
        adapt.Fill(ds, "personel_liste")
        personel_frm.p_grd.DataSource = ds.Tables("personel_liste")
        personel_frm.p_grd.Refresh()
    End Sub
    Sub ara()
        sql = "select * from personel_tbl where no='" & personel_nosu & "' or ad='" & personel_adi & "'"
        Dim adapt As New SqlDataAdapter(sql, baglanti)
        Dim ds As New DataSet()
        adapt.Fill(ds, "personel_liste")
        personel_frm.p_grd.DataSource = ds.Tables("personel_liste")
        personel_frm.p_grd.Refresh()
    End Sub
    Sub sil()
        sql = "delete from personel_tbl where no='" & personel_nosu & "'"
        baglan()
        listele()
    End Sub
    Sub cikis()
        End
    End Sub
    Sub ekle()
        sql = "insert into personel_tbl(no,ad,soyad,adres,dog_yeri,dog_tar,gorev,meb_s_no,sig_s_no,ev_tel,cep_tel,ogr_durum,ucret,grup,gir_tar,tc_no,baba_ad,ana_ad,din,medeni_hal,il,ilce,mah,hane_s_no,cilt_no,sayfa_no) values('" & personel_nosu & "','" & personel_adi & "','" & personel_soyadi & "','" & personel_adresi & "','" & personel_dogum_yeri & "','" & personel_dogum_tarihi & "','" & personel_gorevi & "','" & personel_meb_sicil_nosu & "','" & personel_sigorta_sicil_nosu & "','" & personel_ev_telefonu & "','" & personel_cep_telefonu & "','" & personel_ogrenım_durumu & "','" & personel_ucreti & "','" & personel_grubu & "','" & personel_giris_tarihi & "','" & personel_tc_nosu & "','" & personel_baba_adi & "','" & personel_ana_adi & "','" & personel_dini & "','" & personel_medeni_hali & "','" & personel_ili & "','" & personel_ilcesi & "','" & personel_mahallesi & "','" & personel_hane_sıra_nosu & "','" & personel_cilt_nosu & "','" & personel_sayfa_nosu & "')"
        baglan()
        listele()
        temizle()
    End Sub
    Sub temizle()
        personel_frm.p_no_txt.Text = ""
        personel_frm.p_adi_txt.Text = ""
        personel_frm.p_soyadi_txt.Text = ""
        personel_frm.p_adresi_txt.Text = ""
        personel_frm.p_dogum_yeri_txt.Text = ""
        personel_frm.p_dogum_tarihi_txt.Text = ""
        personel_frm.p_gorevi_txt.Text = ""
        personel_frm.p_meb_s_no_txt.Text = ""
        personel_frm.p_sig_no_txt.Text = ""
        personel_frm.p_ev_tel_txt.Text = ""
        personel_frm.p_cep_tel_txt.Text = ""
        personel_frm.p_ucreti_txt.Text = ""
        personel_frm.p_giris_tar_txt.Text = ""
        personel_frm.p_tc_txt.Text = ""
        personel_frm.p_baba_adi_txt.Text = ""
        personel_frm.p_ana_adi_txt.Text = ""
        personel_frm.p_dini_txt.Text = ""
        personel_frm.p_medeni_hali_txt.Text = ""
        personel_frm.p_ili_txt.Text = ""
        personel_frm.p_ilcesi_txt.Text = ""
        personel_frm.p_mah_txt.Text = ""
        personel_frm.p_kutukno_txt.Text = ""
        personel_frm.p_ciltno_txt.Text = ""
        personel_frm.p_sayfano_txt.Text = ""

    End Sub

    Public Property personel_no()
        Get
            Return personel_nosu
        End Get
        Set(ByVal value)
            personel_nosu = value
        End Set
    End Property
    Public Property personel_ad()
        Get
            Return personel_adi
        End Get
        Set(ByVal value)
            personel_adi = value
        End Set
    End Property
    Public Property personel_soyad()
        Get
            Return personel_soyadi
        End Get
        Set(ByVal value)
            personel_soyadi = value
        End Set
    End Property
    Public Property personel_adres()
        Get
            Return personel_adresi
        End Get
        Set(ByVal value)
            personel_adresi = value
        End Set
    End Property
    Public Property personel_dogum_yer()
        Get
            Return personel_dogum_yeri
        End Get
        Set(ByVal value)
            personel_dogum_yeri = value
        End Set
    End Property
    Public Property personel_dogum_tarih()
        Get
            Return personel_dogum_tarihi
        End Get
        Set(ByVal value)
            personel_dogum_tarihi = value
        End Set
    End Property
    Public Property personel_gorev()
        Get
            Return personel_gorevi
        End Get
        Set(ByVal value)
            personel_gorevi = value
        End Set
    End Property
    Public Property personel_meb_sicil_no()
        Get
            Return personel_meb_sicil_nosu
        End Get
        Set(ByVal value)
            personel_meb_sicil_nosu = value
        End Set
    End Property
    Public Property personel_sigorta_sicil_no()
        Get
            Return personel_sigorta_sicil_nosu
        End Get
        Set(ByVal value)
            personel_sigorta_sicil_nosu = value
        End Set
    End Property
    Public Property personel_ev_telefon()
        Get
            Return personel_ev_telefonu
        End Get
        Set(ByVal value)
            personel_ev_telefonu = value
        End Set
    End Property
    Public Property personel_cep_telefon()
        Get
            Return personel_cep_telefonu
        End Get
        Set(ByVal value)
            personel_cep_telefonu = value
        End Set
    End Property
    Public Property personel_ogrenım_durum()
        Get
            Return personel_ogrenım_durumu
        End Get
        Set(ByVal value)
            personel_ogrenım_durumu = value
        End Set
    End Property
    Public Property personel_ucret()
        Get
            Return personel_ucreti
        End Get
        Set(ByVal value)
            personel_ucreti = value
        End Set
    End Property
    Public Property personel_grub()
        Get
            Return personel_grubu
        End Get
        Set(ByVal value)
            personel_grubu = value
        End Set
    End Property
    Public Property personel_giris_tarih()
        Get
            Return personel_giris_tarihi
        End Get
        Set(ByVal value)
            personel_giris_tarihi = value
        End Set
    End Property
    Public Property personel_tc_no()
        Get
            Return personel_tc_nosu
        End Get
        Set(ByVal value)
            personel_tc_nosu = value
        End Set
    End Property
    Public Property personel_baba_ad()
        Get
            Return personel_baba_adi
        End Get
        Set(ByVal value)
            personel_baba_adi = value
        End Set
    End Property
    Public Property personel_ana_ad()
        Get
            Return personel_ana_adi
        End Get
        Set(ByVal value)
            personel_ana_adi = value
        End Set
    End Property
    Public Property personel_din()
        Get
            Return personel_dini
        End Get
        Set(ByVal value)
            personel_dini = value
        End Set
    End Property
    Public Property personel_medeni_hal()
        Get
            Return personel_medeni_hali
        End Get
        Set(ByVal value)
            personel_medeni_hali = value
        End Set
    End Property
    Public Property personel_il()
        Get
            Return personel_ili
        End Get
        Set(ByVal value)
            personel_ili = value
        End Set
    End Property
    Public Property personel_ilce()
        Get
            Return personel_ilcesi
        End Get
        Set(ByVal value)
            personel_ilcesi = value
        End Set
    End Property
    Public Property personel_mahalle()
        Get
            Return personel_mahallesi
        End Get
        Set(ByVal value)
            personel_mahallesi = value
        End Set
    End Property
    Public Property personel_hane_sıra_no()
        Get
            Return personel_hane_sıra_nosu
        End Get
        Set(ByVal value)
            personel_hane_sıra_nosu = value
        End Set
    End Property
    Public Property personel_cilt_no()
        Get
            Return personel_cilt_nosu
        End Get
        Set(ByVal value)
            personel_cilt_nosu = value
        End Set
    End Property
    Public Property personel_sayfa_no()
        Get
            Return personel_sayfa_nosu
        End Get
        Set(ByVal value)
            personel_sayfa_nosu = value
        End Set
    End Property
End Class
