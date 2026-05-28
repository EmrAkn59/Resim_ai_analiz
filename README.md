# Görüntü Sahteciliği Tespiti (Ar-Ge ve Yazılım Proje Yönetimi Dönem Projesi)

Bu proje, dijital görüntülerin üzerinde oynama (manipülasyon/sahtecilik) yapılıp yapılmadığını hem klasik bilgisayarlı görü algoritmalarıyla hem de modern derin öğrenme (AI) modelleriyle tespit eden bir masaüstü (WinForms) uygulamasıdır. Proje geliştirme sürecinde Çevik (Agile/Scrum) proje yönetimi metodolojileri uygulanmıştır.

## 🚀 Özellikler ve Proje İsterleri (User Stories)

* **User Story-1 (Dosya Format Desteği):** Uygulama; `.jpg`, `.jpeg`, `.png`, `.gif` ve `.bmp` formatındaki resim verilerini destekler ve güvenli bir şekilde sisteme yükler.
* **User Story-2 (Klasik Görüntü İşleme):** OpenCV kütüphanesi entegrasyonu ile görüntüler üzerinde **SIFT**, **ORB** ve **AKAZE** algoritmalarını koşturarak anahtar özellik noktalarını (keypoints) çıkarır ve görselleştirir.
* **User Story-3 (Yapay Zeka Entegrasyonu):** Görüntü sahteciliğinin tespiti için en az 2 farklı derin öğrenme algoritması mimarisi kullanılmıştır:
    * **Özel CNN Modeli:** Sıfırdan tasarlanıp eğitilen hızlı analiz modeli.
    * **Xception Gelişmiş CNN Modeli:** Transfer Learning yöntemiyle adapte edilmiş yüksek başarımlı derin öğrenme modeli.
    * Modeller C# ortamında yüksek performansla çalışabilmesi adına **ONNX** formatına dönüştürülerek projeye gömülmüştür.

## 🛠️ Kullanılan Teknolojiler ve Kütüphaneler

* **Arayüz / Masaüstü:** C# WinForms (.NET 8.0)
* **Görüntü İşleme:** OpenCvSharp4 & OpenCvSharp4.Extensions
* **Yapay Zeka Çalıştırma Motoru:** Microsoft.ML.OnnxRuntime & Microsoft.ML.OnnxRuntime.Tensors
* **Model Eğitimi (Arka Plan):** Python, TensorFlow, Keras, OpenCV

## 📊 Proje Yönetimi ve Kod Kalitesi Araçları

Projenin yönetim, efor ve kalite standartlarını doğrulamak adına aşağıdaki mühendislik araçları ve yöntemleri kullanılmıştır:
* **GitHub Task Board:** Proje görevleri ve User Story takipleri Kanban panosu (Todo, In Progress, Done) üzerinde yönetilmiştir.
* **FSM (Functional Size Measurement):** Projenin efor ve iş yükü hesabı **Use Case Points (UCP)** yöntemi kullanılarak yapılmış ve toplam emek **adam-saat** cinsinden bilimsel olarak hesaplanmıştır.
* **SonarQube (SonarCloud):** Kod kalitesi, güvenlik açıkları ve kod kokuları (code smells) SonarQube bulut arayüzü ile taranmış, proje sıfır hata ile kalite kapısını (Quality Gate) geçmiştir.
* **Doxygen & Graphviz:** Projenin kaynak kod mimarisi otomatik olarak dökümante edilmiş, sınıf ilişkileri ve kod haritası grafiksel olarak (Graph) üretilmiştir.

## 💻 Kurulum ve Çalıştırma

1. Bu depoyu bilgisayarınıza klonlayın:
   ```bash
   git clone https://github.com/EmrAkn59/Resim_ai_analiz
