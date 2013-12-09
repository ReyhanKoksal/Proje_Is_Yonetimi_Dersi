Public Class ogrenci_frm
    Dim ogrenci As New ogrenci_bilgi
    Dim veli As New veli_bilgileri
    Dim dp As New prog
    Dim sp As New senet
    Dim devam As New Devamsizlik
    Dim op As New odemeler
    Public senetno As Integer
    Public et As Integer
    Public nokta As Integer
    Public et1 As Integer
    Public nokta1 As Integer
    Sub v_bilgi_ata()
        veli.o_no = CInt(veli_ogr_no_txt.Text)
        veli.v_no = tc_txt.Text
        veli.v_ad = veli_ad_txt.Text
        veli.v_soyad = veli_soyad_txt.Text
        veli.v_adres = veli_adres_txt.Text
        veli.v_cep_tel = veli_cep_txt.Text
        veli.v_geliri = veli_geliri_txt.Text
        veli.v_il = veli_il_txt.Text
        veli.v_ilce = veli_ilce_txt.Text
        veli.v_posta = veli_posta_kodu_txt.Text
        veli.v_yakinligi = yakinlik_txt.Text
        veli.v_mail = veli_email_txt.Text
        veli.v_is_il = veli_is_ili_txt.Text
        veli.v_is_ilce = veli_is_ilce_txt.Text
        veli.v_is_posta = veli_is_posta_kodu_txt.Text
        veli.v_is_fax = veli_is_fax_txt.Text
        veli.v_is_adres = veli_is_adresi_txt.Text
        veli.v_meslegi = veli_meslek_txt.Text
        veli.v_tel = veli_ev_tel_txt.Text
        veli.v_is_tel = veli_is_tel_txt.Text
    End Sub
    Sub s_bilgi_ata()
        sp.senet_ogr_nosu = CInt(senet_ogr_no_txt.Text)
        sp.k_ucreti = CInt(senet_k_ucret_txt.Text)
        sp.senet_indirimi = CInt(senet_indirim_txt.Text)
        sp.top_senet_tutari = Val(CInt(sp.k_ucreti) - CInt(sp.senet_indirimi))
        sp.tarihi = DateTimePicker1.Value.ToString
        sp.i_v_tarihi = DateTimePicker2.Value.ToString
        sp.v_sayisi = CInt(senet_vadesay_txt.Text)
        sp.tutar = Val(CInt(sp.top_senet_tutari) / CInt(sp.v_sayisi))
    End Sub

Sub bilgi_ata()
        ogrenci.o_numarası = CInt(sicil_no_txt.Text)
        ogrenci.o_adi = sicil_ad_txt.Text
        ogrenci.o_soyadi = sicil_soyad_txt.Text
        If sicil_erkek_rd.Checked Then
            ogrenci.o_cinsiyeti = "Erkek"
        Else
            ogrenci.o_cinsiyeti = "Kız"
        End If
        ogrenci.o_dogumtarihi = sicil_dog_tar_dtp.Value.ToString
        ogrenci.o_adresi = sicil_adres_txt.Text
        ogrenci.o_ili = sicil_il_txt.Text
        ogrenci.o_ilcesi = sicil_ilcesi_txt.Text
        ogrenci.o_posta_kodu = sicil_posta_txt.Text
        ogrenci.o_evtelefonu = sicil_evtel_txt.Text
        ogrenci.o_ceptelefonu = sicil_ceptel_txt.Text
        ogrenci.o_email = sicil_email_txt.Text
        ogrenci.o_bolumu = CInt(ogr_sicil_bolum_txt.SelectedItem)
    End Sub
    Sub d_bilgi_ata()
        devam.ogrenci_nosu = CInt(dev_ogr_no_txt.Text)
        devam.adi = dev_adi_txt.Text
        devam.soyadi = dev_soyadi_txt.Text
        devam.sinifi = dev_sinifi_txt.Text
        devam.devamsizlik_tarihi = devamsizlik_tarihi_dtp.Value.ToString
        devam.devamsizlik_turu = devamsizlik_turu_cmb.SelectedItem.ToString
    End Sub
    Private Sub prog_kodu_txt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles prog_kodu_txt.TextChanged
        If prog_kodu_txt.Text = "" Then
        Else
            dp.isim_ata()
        End If
    End Sub


 Private Sub ogr_sicil_ekle_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ogr_sicil_ekle_btn.Click
        If sicil_no_txt.Text = "" Then
            MsgBox("Öğrenci Numarası Boş Geçilemez!!!", MsgBoxStyle.Exclamation)
            sicil_no_txt.Focus()

        ElseIf sicil_ad_txt.Text = "" Then
            MsgBox("Öğrenci Adı Boş Geçilemez!!!")
            sicil_ad_txt.Focus()

        ElseIf sicil_soyad_txt.Text = "" Then
            MsgBox("Öğrenci Soyadı Boş Geçilemez!!!", MsgBoxStyle.Exclamation)
            sicil_soyad_txt.Focus()

        ElseIf IsNumeric(sicil_no_txt.Text) = False And sicil_no_txt.Text <> "" Then
            MsgBox("Lütfen Geçerli Bir Öğrenci Numarası Giriniz!!!", MsgBoxStyle.Exclamation)
            sicil_no_txt.Text = ""
            sicil_no_txt.Focus()

        ElseIf IsNumeric(sicil_ad_txt.Text) = True And sicil_ad_txt.Text <> "" Then
            MsgBox("Lütfen Geçerli Bir Öğrenci Adı Giriniz!!!", MsgBoxStyle.Exclamation)
            sicil_ad_txt.Text = ""
            sicil_ad_txt.Focus()

        ElseIf IsNumeric(sicil_soyad_txt.Text) = True And sicil_soyad_txt.Text <> "" Then
            MsgBox("Lütfen Geçerli Bir Öğrenci SoyAdı Giriniz!!!", MsgBoxStyle.Exclamation)
            sicil_soyad_txt.Text = ""
            sicil_soyad_txt.Focus()

        ElseIf IsNumeric(sicil_il_txt.Text) = True And sicil_il_txt.Text <> "" Then
            MsgBox("Lütfen İl Bölümüne Geçerli Bir Değer Giriniz!!!", MsgBoxStyle.Exclamation)
            sicil_il_txt.Text = ""
            sicil_il_txt.Focus()
        ElseIf IsNumeric(sicil_ilcesi_txt.Text) = True And sicil_ilcesi_txt.Text <> "" Then
            MsgBox("Lütfen İlçe Bölümüne Geçerli Bir Değer Giriniz!!!", MsgBoxStyle.Exclamation)
            sicil_ilcesi_txt.Text = ""
            sicil_ilcesi_txt.Focus()

        ElseIf IsNumeric(sicil_posta_txt.Text) = False And sicil_posta_txt.Text <> "" Then
            MsgBox("Lütfen Posta Kodu Bölümüne Geçerli Bir Değer Giriniz!!!", MsgBoxStyle.Exclamation)
            sicil_posta_txt.Text = ""
            sicil_posta_txt.Focus()

        ElseIf IsNumeric(sicil_posta_txt.Text) = False And sicil_posta_txt.Text <> "" Then
            MsgBox("Lütfen Posta Kodu Bölümüne Geçerli Bir Değer Giriniz!!!", MsgBoxStyle.Exclamation)
            sicil_posta_txt.Text = ""
            sicil_posta_txt.Focus()

        ElseIf IsNumeric(sicil_evtel_txt.Text) = False And sicil_evtel_txt.Text <> "" Then
            MsgBox("Lütfen Ev Telefonu Bölümüne Geçerli Bir Değer Giriniz!!!", MsgBoxStyle.Exclamation)
            sicil_evtel_txt.Text = ""
            sicil_evtel_txt.Focus()

        ElseIf IsNumeric(sicil_ceptel_txt.Text) = False And sicil_ceptel_txt.Text <> "" Then
            MsgBox("Lütfen Cep Telefonu Bölümüne Geçerli Bir Değer Giriniz!!!", MsgBoxStyle.Exclamation)
            sicil_ceptel_txt.Text = ""
            sicil_ceptel_txt.Focus()
        Else
            ogrenci.kontrol()

        End If
    End Sub
    Private Sub ogr_sicil_sil_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ogr_sicil_sil_btn.Click
        If (sicil_no_txt.Text = "") Then
            MsgBox("Lütfen kaydı silinecek öğrencinin numarası giriniz", MsgBoxStyle.Exclamation)
            sicil_no_txt.Focus()
            Return
        End If
        ogrenci.o_numarası = CInt(sicil_no_txt.Text)
        ogrenci.sil()
    End Sub
    Private Sub ogr_sicil_ara_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ogr_sicil_ara_btn.Click
        If (sicil_no_txt.Text = "") Then
            MsgBox("Lütfen aranacak bir öğrenci numarası giriniz", MsgBoxStyle.Exclamation)
            sicil_no_txt.Focus()
            Return
        End If
        bilgi_ata()
        ogrenci.ara()

    End Sub

    Private Sub ogr_sicil_listele_btn_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ogr_sicil_listele_btn.Click
        ogrenci.listele()
    End Sub

    Private Sub ogr_sicil_guncelle_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ogr_sicil_guncelle_btn.Click
        If sicil_no_txt.Text = "" Then
            MsgBox("Lütfen güncellenecek olan öğrencinin numarasını giriniz", MsgBoxStyle.Exclamation)
            sicil_no_txt.Focus()
            Return
        End If
        bilgi_ata()
        ogrenci.guncelle()
    End Sub

    Private Sub ogr_sicil_temizle_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ogr_sicil_temizle_btn.Click
        ogrenci.temizle()
    End Sub

    Private Sub ogr_sicil_cikis_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ogr_sicil_cikis_btn.Click
        ogrenci.cikis()
    End Sub

Private Sub veli_ekle_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles veli_ekle_btn.Click
        If IsNumeric(veli_ogr_no_txt.Text) = False Then
            MsgBox("Lütfen geçerli bir öğrenci numarası giriniz!")
        ElseIf tc_txt.Text = "" Then
            MsgBox("TC numarası boş geçilemez!!!", MsgBoxStyle.Exclamation)
            tc_txt.Focus()
            tc_txt.Text = ""
        ElseIf (veli_ad_txt.Text = "") Then
            MsgBox("Veli Ad Alanı Boş Geçilemez!!!", MsgBoxStyle.Exclamation)
            veli_ad_txt.Focus()
            veli_ad_txt.Text = ""
        ElseIf (veli_soyad_txt.Text = "") Then
            MsgBox("Veli SoyAd Alanı Boş Geçilemez!!!", MsgBoxStyle.Exclamation)
            veli_soyad_txt.Focus()
            veli_soyad_txt.Text = ""


        ElseIf IsNumeric(tc_txt.Text) = False Then
            MsgBox("Lütfen TC No Alanına Geçerli Değer Giriniz!!!", MsgBoxStyle.Exclamation)
            tc_txt.Focus()
            tc_txt.Text = ""


        ElseIf IsNumeric(veli_ad_txt.Text) = True Then
            MsgBox("Lütfen Veli Ad Alanına Geçerli Değer Giriniz!!!", MsgBoxStyle.Exclamation)
            veli_ad_txt.Focus()
            veli_ad_txt.Text = ""

        ElseIf IsNumeric(veli_soyad_txt.Text) = True Then
            MsgBox("Lütfen Veli Ad Alanına Geçerli Değer Giriniz!!!", MsgBoxStyle.Exclamation)
            veli_soyad_txt.Focus()
            veli_soyad_txt.Text = ""

        ElseIf IsNumeric(yakinlik_txt.Text) = True And yakinlik_txt.Text <> "" Then
            MsgBox("Lütfen Yakınlığı Alanına Geçerli Değer Giriniz!!!", MsgBoxStyle.Exclamation)
            yakinlik_txt.Focus()
            yakinlik_txt.Text = ""

        ElseIf IsNumeric(veli_meslek_txt.Text) = True And veli_meslek_txt.Text <> "" Then
            MsgBox("Lütfen Meslek Alanına Geçerli Değer Giriniz!!!", MsgBoxStyle.Exclamation)
            veli_meslek_txt.Focus()
            veli_meslek_txt.Text = ""

        ElseIf IsNumeric(veli_geliri_txt.Text) = False And veli_geliri_txt.Text <> "" Then
            MsgBox("Lütfen Gelir Alanına Geçerli Değer Giriniz!!!", MsgBoxStyle.Exclamation)
            veli_geliri_txt.Focus()
            veli_geliri_txt.Text = ""

        ElseIf IsNumeric(veli_ilce_txt.Text) = True And veli_ilce_txt.Text <> "" Then
            MsgBox("Lütfen İlçe Alanına Geçerli Değer Giriniz!!!", MsgBoxStyle.Exclamation)
            veli_ilce_txt.Focus()
            veli_ilce_txt.Text = ""

        ElseIf IsNumeric(veli_il_txt.Text) = True And veli_il_txt.Text <> "" Then
            MsgBox("Lütfen İl Alanına Geçerli Değer Giriniz!!!", MsgBoxStyle.Exclamation)
            veli_il_txt.Focus()
            veli_il_txt.Text = ""

        ElseIf IsNumeric(veli_posta_kodu_txt.Text) = False And veli_posta_kodu_txt.Text <> "" Then
            MsgBox("Lütfen Ev_Posta Kodu Alanına Geçerli Değer Giriniz!!!", MsgBoxStyle.Exclamation)
            veli_posta_kodu_txt.Focus()
            veli_posta_kodu_txt.Text = ""

        ElseIf IsNumeric(veli_ev_tel_txt.Text) = False And veli_ev_tel_txt.Text <> "" Then
            MsgBox("Lütfen Veli Ev Telefonu Alanına Geçerli Değer Giriniz!!!", MsgBoxStyle.Exclamation)
            veli_ev_tel_txt.Focus()
            veli_ev_tel_txt.Text = ""

        ElseIf IsNumeric(veli_cep_txt.Text) = False And veli_cep_txt.Text <> "" Then
            MsgBox("Lütfen Veli Cep Telefonu Alanına Geçerli Değer Giriniz!!!", MsgBoxStyle.Exclamation)
            veli_cep_txt.Focus()
            veli_cep_txt.Text = ""

        ElseIf IsNumeric(veli_is_ilce_txt.Text) = True And veli_is_ilce_txt.Text <> "" Then
            MsgBox("Lütfen Veli'nin İş İlçe Alanına Geçerli Değer Giriniz!!!", MsgBoxStyle.Exclamation)
            veli_is_ilce_txt.Focus()
            veli_is_ilce_txt.Text = ""

        ElseIf IsNumeric(veli_is_ili_txt.Text) = True And veli_is_ili_txt.Text <> "" Then
            MsgBox("Lütfen Veli'nin İş İl Alanına Geçerli Değer Giriniz!!!", MsgBoxStyle.Exclamation)
            veli_is_ili_txt.Focus()
            veli_is_ili_txt.Text = ""

        ElseIf IsNumeric(veli_is_tel_txt.Text) = False And veli_is_tel_txt.Text <> "" Then
            MsgBox("Lütfen Veli'nin İş Telefon Alanına Geçerli Değer Giriniz!!!", MsgBoxStyle.Exclamation)
            veli_is_tel_txt.Focus()
            veli_is_tel_txt.Text = ""

        ElseIf IsNumeric(veli_is_fax_txt.Text) = False And veli_is_fax_txt.Text <> "" Then
            MsgBox("Lütfen Veli'nin İş Fax Alanına Geçerli Değer Giriniz!!!", MsgBoxStyle.Exclamation)
            veli_is_fax_txt.Focus()
            veli_is_fax_txt.Text = ""

        ElseIf IsNumeric(veli_is_posta_kodu_txt.Text) = False And veli_is_posta_kodu_txt.Text <> "" Then
            MsgBox("Lütfen Veli'nin İş posta Koduna Alanına Geçerli Değer Giriniz!!!", MsgBoxStyle.Exclamation)
            veli_is_posta_kodu_txt.Focus()
            veli_is_posta_kodu_txt.Text = ""

        Else
            veli.kontrol()
        End If
    End Sub

    Private Sub veli_sil_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles veli_sil_btn.Click
        veli.v_no = tc_txt.Text
        veli.sil()
    End Sub

    Private Sub veli_guncelle_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles veli_guncelle_btn.Click
        v_bilgi_ata()
        veli.guncelle()
    End Sub

    Private Sub veli_temizle_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles veli_temizle_btn.Click
        veli.temizle()
    End Sub

    Private Sub veli_cikis_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles veli_cikis_btn.Click
        veli.cikis()
    End Sub

    Private Sub veli_ara_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles veli_ara_btn.Click
        v_bilgi_ata()
        veli.ara()
    End Sub

    Private Sub veli_listele_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles veli_listele_btn.Click
        veli.listele()
    End Sub

Private Sub programi_goruntule_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles programi_goruntule_btn.Click
        If Not prog_gunler_txt.SelectedItem = "" Then
            If IsNumeric(prog_ogr_no_txt.Text) = True Then
                dp.listele()
            Else
                MsgBox("Lütfen geçerli bir öğrenci numarası giriniz!")
            End If
        Else
            MsgBox("Lütfen gün seçiniz!")

        End If
    End Sub


    Private Sub prog_kodu_txt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles prog_kodu_txt.TextChanged
        If prog_kodu_txt.Text = "" Then
        Else
            dp.isim_ata()
        End If
    End Sub
    
    Private Sub senet_ekle_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles senet_ekle_btn.Click
        If IsNumeric(senet_ogr_no_txt.Text) = True Then
            sp.kontrol()
        Else
            MsgBox("Lütfen geçerli bir öğrenci numarası giriniz!")
        End If
    End Sub

    Private Sub senet_cikis_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles senet_cikis_btn.Click
        sp.cikis()
    End Sub

    Private Sub senet_listele_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles senet_listele_btn.Click
        sp.listele()
    End Sub

    Private Sub senet_sil_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles senet_sil_btn.Click
        sp.sil()
    End Sub

    Private Sub senet_guncelle_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles senet_guncelle_btn.Click
        sp.guncelle()
    End Sub

    Private Sub senet_ara_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles senet_ara_btn.Click
        sp.ara()
    End Sub

    Private Sub senet_temizle_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles senet_temizle_btn.Click
        sp.temizle()
    End Sub

