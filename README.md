# 🏥 Hospital Management System (Console App)

Bu proje, C# Console uygulaması olarak geliştirilmiş basit bir **Hastane Yönetim Sistemi**dir.  
Hasta ve doktor kayıtlarının yönetilmesini sağlar.

Proje, katmanlı mimari kullanılarak geliştirilmiştir.

---

## 🚀 Özellikler

### 👨‍⚕️ Doktor Yönetimi
- Doktor ekleme
- Doktor listeleme
- Doktor güncelleme
- Doktor silme

### 🧑‍🦱 Hasta Yönetimi
- Hasta ekleme
- Hasta listeleme
- Hasta güncelleme
- Hasta silme

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
Konsol menüsünün bulunduğu ana dosyadır.

---

## ⚙️ Kullanılan Teknolojiler

- C#
- .NET Console Application
- List<T> veri yapısı
- LINQ

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

9 - Çıkış

---

🛠️ Geliştirme Planı

 * Randevu sistemi geliştirme

 * Veritabanı entegrasyonu (SQL Server)

 * ADO.NET kullanımı

 * Exception handling

 * Validation işlemleri

 * Repository Pattern
