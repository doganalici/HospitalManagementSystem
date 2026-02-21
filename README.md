# 🏥 Hospital Management System (Console App)

Bu proje, C# Console Application kullanılarak geliştirilmiş basit bir Hastane Yönetim Sistemi uygulamasıdır.<br>
Hasta, doktor, departman ve randevu kayıtlarının yönetilmesini sağlar.<br>
Uygulama gerçek bir randevu sistemi mantığına uygun olarak zaman aralığı çakışma kontrolü, çalışma saatleri, öğle arası ve geçmiş tarih filtreleme gibi iş kurallarını içerir.<br>

---

## 🚀 Özellikler

Uygulama aşağıdaki işlemleri destekler:

### 👨‍⚕️ Doktor Yönetimi
- Doktor ekleme (Otomatik ID – Max + 1 mantığı)
- Doktor listeleme (Departman adı ile birlikte)
- Doktor güncelleme
- Doktor silme
- Departman ID ile ilişkilendirme
- Aktif / Pasif doktor kontrolü (IsActive)
- Silme sırasında bağlı randevu kontrolü
- JSON dosyasına kalıcı kayıt

### 🧑‍🦱 Hasta Yönetimi
- Hasta ekleme (Otomatik ID – Max + 1 mantığı)
- Hasta listeleme
- Hasta güncelleme
- Hasta silme
- Doğum tarihi özel formatla girilir (dd.MM.yyyy)
- JSON dosyasına kalıcı kayıt

### 📅 Randevu İşlemleri
- Randevu ekleme
- Randevu listeleme (Hasta, Doktor ve Departman bilgileriyle)
- Randevu güncelleme
- Randevu silme
- 15 dakikalık zaman dilimi zorunluluğu (00, 15, 30, 45)
- Hafta içi randevu kısıtı (Cumartesi & Pazar kapalı)
- Çalışma saatleri kısıtı (09:00 - 17:00)
- Aynı doktor için zaman aralığı çakışma kontrolü
- Aynı hasta için zaman aralığı çakışma kontrolü
- Güncelleme sırasında çakışma kontrolü
- Geçmiş tarihler için randevu engeli
- Bugün için geçmiş saat filtreleme
- Doktor için otomatik uygun saat listeleme sistemi
- Aktif / Pasif randevu durumu (Status kontrolü)
- Tarih formatı: dd.MM.yyyy HH:mm
- Randevu listesinde ad-soyad bilgileri büyük harflerle gösterilir
- JSON dosyasına kalıcı kayıt

### 🏢 Departman İşlemleri
- Departman ekleme
- Departman listeleme
- Departman güncelleme
- Departman silme
- Bağlı doktor kontrolü

### ⌨️ Kullanıcı Girişi Kontrolleri
- Hatalı girişlerde tekrar isteme
- Tarih ve saat formatı doğrulama
- Sayısal veri kontrolü
  
### 📋 Menü Sistemi
- Kullanıcı dostu konsol menüsü
- Hatalı girişlerde uyarı sistemi

🕒 Zaman Kuralları
- 15 dakikalık zaman dilimi zorunluluğu (00, 15, 30, 45)
- Hafta içi randevu kısıtı (Cumartesi & Pazar kapalı)
- Çalışma saatleri kısıtı (09:00 - 17:00)
- Öğle arası molası (11:45 - 13:00 arası randevu alınamaz)
- Geçmiş tarihlere randevu engeli
- Bugün için geçmiş saatleri otomatik gizleme
- Güncelleme sırasında tüm kurallar tekrar kontrol edilir

⏰ Akıllı Slot Üretim Sistemi
- Dinamik 15 dakikalık slot üretimi (09:00 - 17:00)
- Öğle arası slotları otomatik filtrelenir
- Hafta sonu slot üretmez
- Geçmiş saatleri listelemez
- Mevcut randevulara göre dolu saatleri gizler

🏢 Departman İşlemleri
- Departman ekleme
- Departman listeleme
- Departman Güncelleme
- Departman Silme
- Bağlı doktor kontrolü
- Doktor listelerinde departman adı gösterimi

💾 Veri Kalıcılığı (Persistence)
- JSON dosyadı kullanılarak veri saklama
- Program kapatılsa bile veriler korunur
- Otomatik ID üretimi JSON' daki maksimum ID' ye göre hesaplanır
- Her işlem sonrası dosya güncellenir

⌨️ Kullanıcı Girişi Kontrolleri
- Hatalı girişlerde tekrar isteme
- Tarih ve saat formatı doğrulama
- Null / boş veri kontrolü

---

## 🏗️ Proje Mimarisi

Proje 3 ana katmandan oluşmaktadır:

HospitalManagementSystem<br>
│<br>
├── Entities       → Varlık sınıfları (Patient, Doctor, Department, Appointment)<br>
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
  - Tüm iş kuralları burada kontrol edilir

 #### 📌UI
Kullanıcı arayüzü ve menü yönetimi

- MenuManager  
- AppointmentMenu  
- PatientMenu  
- DoctorMenu  
- DepartmentMenu  

#### 📌Program
Uygulama başlangıç noktasıdır

- Menü başlatma
- Servislerin oluşturulması
- Program akışı

#### 📌Helpers
Kullanıcı giriş kontrolleri

- InputHelper
- JSON Helper
- TryParse validasyonları

---

## ⚙️ Kullanılan Teknolojiler

- C#
- .NET Console Application
- OOP (Object Oriented Programming)
- LINQ
- Katmanlı Mimari (UI, Business, Entities, Data)
- JSON Serialization

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
- ✔️ Null kontrolü (boş veri önleme)
- ✔️ Update sırasında güvenli çakışma kontrolü
- ✔️ 15 dakikalık slot üretim algoritması
- ✔️ Interval (zaman aralığı) çakışma kontrolü
- ✔️ Dinamik slot üretimi (09:00 - 17:00)
- ✔️ Hafta sonu engelleme
- ✔️ Geçmiş tarih ve saat filtreleme
- ✔️ Uygun saat hesaplama motoru
- ✔️ JSON ile veri kalıcılığı
- ✔️ Öğle arası filtreleme
- ✔️ Geçmiş tarih ve saat engelleme
- ✔️ Geçmiş tarih ve saat engelleme
  
---
