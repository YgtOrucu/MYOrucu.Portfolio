# 🚀 MuhsinYigitOrucu - Portfolio Project

Bu proje, modern yazılım mimarilerine uygun olarak geliştirilmiş, dinamik içerik yönetimine sahip kişisel bir **Portfolyo ve Yönetim Sistemi** uygulamasıdır. Proje, istemci ve sunucu rollerini birbirinden ayıran **API-First** yaklaşımıyla ve N-Tier (Çok Katmanlı) mimari prensipleriyle inşa edilmiştir.

---

<p align="center">
  <img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=.net&logoColor=white" />
  <img src="https://img.shields.io/badge/ASP.NET%20CORE-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img src="https://img.shields.io/badge/ENTITY%20FRAMEWORK-CORE-68217A?style=for-the-badge" />
  <img src="https://img.shields.io/badge/SQL%20SERVER-0078D4?style=for-the-badge&logo=microsoft-sql-server&logoColor=white" />
  <img src="https://img.shields.io/badge/FLUENT%20VALIDATION-VALIDATION-F16436?style=for-the-badge" />
  <br>
  <img src="https://img.shields.io/badge/AUTOMAPPER-MAPPING-E0442C?style=for-the-badge" />
  <img src="https://img.shields.io/badge/MAILKIT-E--MAIL-007ACC?style=for-the-badge" />
  <img src="https://img.shields.io/badge/OPENAI-AI-000000?style=for-the-badge&logo=openai&logoColor=white" />
</p>

---

## 📸 Proje Galerisi (Arayüz Tasarımı)

<details>
  <summary><b>🔍 Ekran Görüntülerini İncelemek İçin Tıklayın</b></summary>
  <br>
  <p align="center">
<img width="100%" alt="Ekran görüntüsü 2026-06-15 093923" src="https://github.com/user-attachments/assets/1e2ed607-61ea-4360-82cb-21ebc06ec735" />
     <br><br>
<img width="100%" alt="Ekran görüntüsü 2026-06-14 181040" src="https://github.com/user-attachments/assets/0fe65ebb-525c-4de9-b172-8e735e746585" />
     <br><br>
<img width="100%" alt="Ekran görüntüsü 2026-06-14 180958" src="https://github.com/user-attachments/assets/262653ef-81be-41df-8a24-8e0435b54a84" />
     <br><br>
<img width="100%" alt="Ekran görüntüsü 2026-06-14 180931" src="https://github.com/user-attachments/assets/67ea21cf-fe37-4e4a-b324-34a97b9e1902" />
     <br><br>
<img width="100%" alt="Ekran görüntüsü 2026-06-14 180909" src="https://github.com/user-attachments/assets/b2d5898f-8a26-47ef-85be-a3469ab58818" />
     <br><br>
<img width="100%" alt="Ekran görüntüsü 2026-06-14 180858" src="https://github.com/user-attachments/assets/b45a79a7-8a17-4e7c-946e-522430601a00" />
     <br><br>
<img width="100%" alt="Ekran görüntüsü 2026-06-14 180840" src="https://github.com/user-attachments/assets/ef5b6903-b8aa-40ef-9ec1-e19fba6f3433" />
     <br><br>
<img width="100%" alt="Ekran görüntüsü 2026-06-14 180828" src="https://github.com/user-attachments/assets/9df15eb3-c65d-4a55-b6fa-547245354bb2" />
     <br><br>
<img width="100%" alt="Ekran görüntüsü 2026-06-14 180813" src="https://github.com/user-attachments/assets/5e427976-6207-4a00-9fcd-0c6041a375e1" />
     <br><br>
<img width="100%" alt="Ekran görüntüsü 2026-06-14 180804" src="https://github.com/user-attachments/assets/3ffc99d2-26bf-4461-bebb-95958f73568a" />
     <br><br>
<img width="100%" alt="Ekran görüntüsü 2026-06-14 180721" src="https://github.com/user-attachments/assets/68f6393d-8bc2-4d5a-82d1-7e73719ad321" />
     <br><br>
 </p>
</details>

---

## 🛠️ Teknolojik Altyapı

### Backend & Core
* **Framework:** .NET 8.0 (ASP.NET Core)
* **Veritabanı & ORM:** SQL Server & Entity Framework Core
* **Güvenlik & Kimlik:** ASP.NET Core Identity (Rol tabanlı yetkilendirme altyapısı)
* **Validasyon:** FluentValidation (Merkezi iş kuralı ve girdi doğrulamaları)
* **Nesne Eşleme:** AutoMapper (DTO ve Entity dönüşümleri)

### Frontend (UI)
* **Arayüz:** ASP.NET Core MVC (Razor Views)
* **Haberleşme:** `HttpClient` ile asenkron API tüketimi (`PortfolioClient`)
* **Tasarım:** HTML5, CSS3, JavaScript & Responsive Admin Layout

### Entegrasyonlar & Servisler
* **E-Posta Servisi:** MailKit & MimeKit entegrasyonu (SMTP üzerinden güvenli e-posta iletimi)
* **Yapay Zeka:** OpenAI API bağlantısı (`OpenAIClient` entegrasyon altyapısı)

---

## ✨ Modüller ve Özellikler

* 👤 **Ana Sayfa / Hakkımda:** Kişisel özet, unvan bilgileri ve dinamik biyografi yönetimi.
* 💼 **Deneyim Yönetimi:** Kronolojik iş geçmişi listeleme, ekleme ve güncelleme modülleri.
* 📊 **Yetenekler:** Teknik yetkinliklerin ve yetenek yüzdelerinin dinamik arayüz gösterimi.
* 🚀 **Projeler:** Geliştirilen projelerin detayları, kullanılan teknolojiler ve ilgili linklerin yönetimi.
* ✉️ **İletişim & Mesaj Sistemi:** Ziyaretçilerin gönderdiği mesajların API üzerinden veritabanına kaydedilmesi.
* 📬 **MailKit Entegrasyonu:** Sistem üzerinden dinamik şablonlarla e-posta gönderimi ve iletişim formu bildirimleri.
* 🔐 **Rol Tabanlı Yetkilendirme (RBAC):** `Admin`, `User` ve `Admin Yardımcısı` rolleriyle gelişmiş panel yetkilendirmesi.
* 🤖 **AI Desteği (OpenAI):** Yönetim panelinde mesaj yanıtlama ve içerik optimizasyonu için entegre yapay zeka altyapısı.

---

## 📁 Proje Mimarisi (N-Tier Architecture)

Proje, sorumlulukların net bir şekilde ayrılması amacıyla **6 ana katmandan** oluşan Katmanlı Mimari prensipleriyle geliştirilmiştir:

```text
Solution 'MYOrucu.Portfolio'
├── 📁 Core/
│   ├── 📄 MuhsinYigitOrucu.DtoLayer        # Data Transfer Objects (DTO'lar ve validasyon nesneleri)
│   └── 📄 MuhsinYigitOrucu.EntityLayer     # Veritabanı tablo modelleri ve core varlıklar
├── 📁 Presentation/
│   ├── 🌐 MuhsinYigitOrucu.WebApi          # Kimlik, Yapay Zeka ve Mail altyapısını barındıran ana API katmanı
│   └── 🖥️ MuhsinYigitOrucu.WebUI           # API'yi tüketen (PortfolioClient), arayüzü sunan MVC katmanı
├── ⚙️ MuhsinYigitOrucu.BusinessLayer       # İş kuralları (Services), AutoMapper profilleri ve FluentValidation kuralları
└── 🗄️ MuhsinYigitOrucu.DataAccessLayer     # DbContext (`MYOrucuPortfolioContext`), Migrations ve Repositories
```

---

# ⚙️ Kurulum ve Yapılandırma

## Repository Klonlama

```bash
git clone https://github.com/YgtOrucu/MYOrucu.Portfolio.git
```

---

## API Yapılandırması (appsettings.json)

```bash
 {
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=DB_ADRES;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "OpenAIAddress": {
    "DefaultAdress": "https://api.openai.com/v1/"
  },
  "MailSettings": {
   "Server": "smtp.gmail.com",
   "Port": 587,
   "SenderName": "Admin",
   "SenderEmail": "admin@gmail.com",
   "Password": ""
},
  "API_KEY": "YOUR_OPENAI_API_KEY",
  "DefaultAdminEmail": "admin@yourdomain.com"
}
```

---

## UI Katmanı Ayarları (appsettings.json)

```bash
{
  "SwaggerAddress": {
    "AddressPath": "https://localhost:portnumber/api/" 
  }
}
```

---
