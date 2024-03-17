# .NET Core Developer - Bilinmesi Gereken Kütüphaneler Kursu

Bu repository, Fatih Çakıroğlu'nun 16 saatlik .NET Core Developer - Bilinmesi Gereken Kütüphaneler kursunu tamamladığımı göstermektedir. Bu kurs boyunca SOLID prensipleri üzerine odaklandık ve çeşitli kütüphaneleri kullanarak gerçek senaryolar üzerinde uygulamalar geliştirdik.

## SOLID Prensipleri

Bu kurs boyunca SOLID prensiplerini öğrendik ve gerçek senaryolar üzerinde uyguladık:

- **Single Responsibility Principle (Tek Sorumluluk Prensibi)**
  - Bir sınıfın sadece tek bir sorumluluğu olmalıdır.
- **Open Closed Principle (Açık Kapalı Prensibi)**
  - Bir sınıf, yeni davranışlar ekleyebilmelidir ancak mevcut kodu değiştirmemelidir.
- **Liskov Substitution Principle (Liskov Yerine Geçme Prensibi)**
  - Üst sınıflar, türeyen sınıflar tarafından yerine geçilebilir olmalıdır.
- **Interface Segregation Principle (Arayüz Ayırma Prensibi)**
  - İstemciler, ihtiyaç duymadıkları özellikleri içeren büyük arayüzler yerine daha özelleştirilmiş arayüzleri kullanmalıdır.
- **Dependency Inversion Principle (Bağımlılıkları Tersine Çevirme Prensibi)**
  - Yüksek seviyeli modüller, düşük seviyeli modüllere bağımlı olmamalıdır.

## Kullanılan Kütüphaneler

Bu kurs kapsamında çeşitli kütüphanelerle çalıştık ve bunları gerçek senaryolar üzerinde uyguladık. İşte bazı kullanılan kütüphaneler:

- **FluentValidation**
  - Giriş verilerinin doğrulamasını kolaylaştıran bir kütüphane.
- **AutoMapper**
  - Nesneler arasında kolay veri eşleştirmesi sağlayan bir kütüphane.
- **AspNetCoreRateLimit**
  - API isteklerini sınırlayan ve hız sınırlaması sağlayan bir kütüphane.
- **Swagger**
  - API'lar için ayrıntılı belgeleme oluşturan bir kütüphane.
- **NLog**
  - Loglama için kullanılan bir kütüphane.

## Hata Yönetimi ve Sayfaları

AspNet Core web uygulamalarında hata yönetimi ve hata sayfaları, kullanıcı deneyimini iyileştirmek için önemlidir. Bu kurs boyunca aşağıdaki konuları öğrendik:

- Hata yönetimi için ASP.NET Core Middleware kullanımı
- Özelleştirilmiş hata sayfalarının oluşturulması
- Hata loglama ve izleme

## Loglama

AspNet Core web uygulamalarında loglama işlemi, uygulamanın performansını ve güvenilirliğini sağlar. Bu kurs kapsamında aşağıdaki konuları öğrendik:

- Loglama temel kavramları ve seviyeleri (Debug, Info, Error, vb.)
- Loglama kütüphanelerinin kullanımı (NLog gibi)
- Loglama çeşitleri: dosya tabanlı loglama, veritabanı tabanlı loglama
- Üçüncü taraf loglama servislerinin kullanımı

## Swagger ile Ayrıntılı Dökümantasyon

AspNet Core Web API uygulamalarında Swagger, API'larınızı ayrıntılı bir şekilde belgelemek için kullanabilirsiniz. Bu kurs boyunca aşağıdaki konuları öğrendik:

- Swagger'ın nasıl entegre edileceği ve yapılandırılacağı
- Swagger UI'nin nasıl kullanılacağı
- Ayrıntılı API belgelerinin nasıl oluşturulacağı
- API'lar için parametrelerin, dönüş tiplerinin ve durum kodlarının nasıl belgelendirileceği

## Environment Ortamları

AspNet Core Web uygulamalarında environment ortamları, farklı ortamlarda (geliştirme, test, canlı vb.) çalışmak için kullanılır. Bu kurs kapsamında aşağıdaki konuları öğrendik:

- Hazır environment ortamlarının nasıl kullanılacağı (Development, Staging, Production)
- Özelleştirilmiş environment ortamlarının nasıl oluşturulacağı
- Canlıda environment ortamının nasıl değiştirileceği

## Kurs Detayları

Bu kurs aşağıdaki konuları içermektedir:

- SOLID Prensipleri
- Kullanılan Kütüphaneler
- Hata Yönetimi ve Sayfaları
- Loglama
- Swagger ile Ayrıntılı Dökümantasyon
- Environment Ortamları
