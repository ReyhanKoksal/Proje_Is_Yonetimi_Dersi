 Public Class ogrenci_bilgi
    Private no As Integer
    Private ad As String
    Private soyad As String
    Private cinsiyet As String
    Private dogtar As String
    Private il As String
    Private ilce As String
    Private postakodu As String
    Private evtel As String
    Private ceptel As String
    Private email As String
    Private adres As String
    Private bolum As Integer
    
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
    Sub listele()
        sql = "select * from ogrenci_sicil_tbl"
        Dim adapt As New SqlDataAdapter(sql, baglanti)
        Dim ds As New DataSet()
        adapt.Fill(ds, "ogr_liste")
        ogrenci_frm.ogrenci_sicil_grd.DataSource = ds.Tables("ogr_liste")
        
        
        //çağrı
        
    End Sub
     Sub ekle()
        sql = "INSERT INTO ogrenci_sicil_tbl(numarasi,adi,soyadi,cinsiyeti,d_tarihi,adresi,ili,ilcesi,p_kodu,ev_tel,cep_tel,email,b_kodu) values ('" & no & "','" & ad & "','" & soyad & "','" & cinsiyet & "','" & dogtar & "','" & adres & "','" & il & "','" & ilce & "','" & postakodu & "','" & evtel & "','" & ceptel & "','" & email & "','" & bolum & "')"
        //çağrı
    End Sub

    Sub guncelle()
        sql = "update ogrenci_sicil_tbl set numarasi = '" & no & "', adi='" & ad & "', soyadi='" & soyad & "', cinsiyeti='" & cinsiyet & "', d_tarihi='" & dogtar & "', adresi='" & adres & "', ili='" & il & "', ilcesi='" & ilce & "', p_kodu='" & postakodu & "', ev_tel='" & evtel & "', cep_tel='" & ceptel & "', email='" & email & "',b_kodu='" & bolum & "' where numarasi = '" & no & "'"
        //çağrı
    End Sub

    Sub sil()
        sql = "delete from ogrenci_sicil_tbl where numarasi='" & no & "'"
        //çağrı
    End Sub

    Sub ara()
        sql = "select * from ogrenci_sicil_tbl where numarasi='" & no & "'"
        Dim adapt As New SqlDataAdapter(sql, baglanti)
        Dim ds As New DataSet()
        adapt.Fill(ds, "Ogrenci Listesi")
        ogrenci_frm.ogrenci_sicil_grd.DataSource = ds.Tables("Ogrenci Listesi")
        ogrenci_frm.ogrenci_sicil_grd.Refresh()

    End Sub
