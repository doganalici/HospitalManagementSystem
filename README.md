# 🏥 Hospital Management System (Console App)

Bu proje, C# Console Application kullanılarak geliştirilmiş basit bir Hastane Yönetim Sistemi uygulamasıdır.
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

### ⌨️ Kullanıcı Girişi Kontrolleri
- Hatalı girişlerde tekrar isteme
- Tarih ve saat formatı doğrulama
- Sayısal veri kontrolü
  
### 📋 Menü Sistemi
- Kullanıcı dostu konsol menüsü
- Hatalı girişlerde uyarı sistemi

---

## 🏗️ Proje Mimarisi

Proje 3 ana katmandan oluşmaktadır:

HospitalManagementSystem<br>
│<br>
├── Entities       → Varlık sınıfları (Patient, Doctor, Appointment)<br>
├── Business       → İş kuralları ve servisler<br>
├── Helpers        → Input kontrol yardımcıları<br>
├── UI             → Menü ve kullanıcı arayüzü<br>
└── Program.cs     → Uygulama başlangıç noktası<br>

---

### 📁 Katmanlar

#### 📌Entities
Veri modellerini içerir

- Patient
- Doctor
- Department
- Appointment

#### 📌Business
CRUD işlemlerinin yapıldığı servis katmanıdır

- PatientService
- DoctorService
- DepartmentService
- AppointmentService

 #### 📌UI
Kullanıcı arayüzü ve menü yönetimi

- MenuManager

#### 📌Program
Uygulama başlangıç noktasıdır

- Menü başlatma
- Servislerin oluşturulması
- Program akışı

#### 📌Helpers
Kullanıcı giriş kontrolleri

- InputHelper
- Tarih / sayı doğrulama
- Hatalı giriş kontrolü

---

## ⚙️ Kullanılan Teknolojiler

- C#
- .NET Console Application
- OOP (Object Oriented Programming)
- LINQ
- Katmanlı Mimari

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
📅 TARİH FORMATI<br><br>
dd.MM.yyyy HH:mm<br>
Örnek: 15.02.2026 14:30

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

- [x] Katmanlı mimari kurulumu  
- [x] Hasta/Doktor/Randevu sistemi  
- [x] Menü sistemi  
- [ ] Departman yönetimi  
- [ ] Dosya/Veritabanı kayıt sistemi  
- [ ] ADO.NET entegrasyonu  
- [ ] SQL Server bağlantısı  


---
