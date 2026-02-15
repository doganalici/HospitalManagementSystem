# 🏥 Hospital Management System (Console App)

Bu proje, C# Console uygulaması olarak geliştirilmiş basit bir **Hastane Yönetim Sistemi**dir.  
Hasta ve doktor kayıtlarının yönetilmesini sağlar.

---

## 🚀 Özellikler

Uygulama aşağıdaki işlemleri destekler:

### 👨‍⚕️ Doktor Yönetimi
- Doktor ekleme (Otomatik ID)
- Doktor listeleme
- Doktor güncelleme
- Doktor silme
- Departman ID ile ilişkilendirme

### 🧑‍🦱 Hasta Yönetimi
- Hasta ekleme (Otomatik ID)
- Hasta listeleme
- Hasta güncelleme
- Hasta silme
- Doğum tarihi özel formatla girilir (dd.MM.yyyy)

### 📅 Randevu İşlemleri
- Randevu ekleme
- Randevu listeleme
- Randevu güncelleme
- Randevu silme
- Aynı doktor ve saat için çakışma kontrolü
- Hasta ve doktor kontrolü
- Tarih formatı: dd.MM.yyyy HH:mm

### 🏢 Departman İşlemleri
- Departman ekleme
- Departman listeleme
- Departman güncelleme
- Departman silme
  
### 📋 Menü Sistemi
- Kullanıcı dostu konsol menüsü
- Hatalı girişlerde uyarı sistemi

---

## 🏗️ Proje Mimarisi

Proje 3 ana katmandan oluşmaktadır:

HospitalManagementSystem<br>
│<br>
├── Entities → Veri modelleri<br>
├── Business → İş kuralları (Service sınıfları)<br>
└── Program.cs → Menü ve kullanıcı arayüzü<br>

### 📁 Katmanlar

#### Entities
Veri modellerini içerir.

- Patient
- Doctor
- Department
- Appointment

#### Business
CRUD işlemlerinin yapıldığı servis katmanıdır.

- PatientService
- DoctorService
- DepartmentService
- AppointmentService

#### Program
- Menü sistemi
- Kullanıcıdan veri alma
- Validasyonlar
- Servislerle iletişim

---

## ⚙️ Kullanılan Teknolojiler

- C#
- .NET Console Application
- LINQ
- OOP

---

📌 Örnek Menü

1 - Hasta Ekle<br>
2 - Hastaları Listele<br>
3 - Hasta Güncelle<br>
4 - Hasta Sil<br><br>

5 - Doktor Ekle<br>
6 - Doktorları Listele<br>
7 - Doktor Güncelle<br>
8 - Doktor Sil<br><br>

9 - Randevu Ekle<br>
10 - Randevuları Listele<br>
11 - Randevu Güncelle<br>
12 - Randevu Sil<br><br>

13 - Çıkış

---

Kullanıcıdan alınan tarihler `DateTime.TryParseExact` ile doğrulanmaktadır.

---

## 🛠️ Teknik Özellikler

- ✔️ OOP (Nesne Tabanlı Programlama)
- ✔️ Katmanlı Mimari
- ✔️ List<T> ile geçici veri saklama
- ✔️ ID otomatik üretme
- ✔️ Giriş doğrulama (TryParse)
- ✔️ Randevu çakışma kontrolü
- ✔️ Servisler arası bağımlılık yönetimi

---

## 🎯 Gelecek Planlar

İlerleyen aşamalarda yapılması planlananlar:

- [ ] Departman seçim ekranı
- [ ] Hasta/Doktor ID doğrulama geliştirme
- [ ] Randevu detaylı kontrol sistemi
- [ ] ADO.NET ile SQL Server bağlantısı
- [ ] Veritabanı CRUD işlemleri
- [ ] MVC/Web arayüz entegrasyonu

---
