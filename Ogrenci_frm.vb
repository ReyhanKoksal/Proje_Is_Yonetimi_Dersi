

Public Class ogrenci_frm
    Dim ogrenci As New ogrenci_bilgi


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


