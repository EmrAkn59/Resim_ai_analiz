import tensorflow as tf
from tensorflow.keras.applications import Xception
from tensorflow.keras import layers, models, Input
import os
import sys

print("TensorFlow Versiyonu:", tf.__version__)

IMAGE_SIZE = (128, 128)

def build_xception_model():
    #1. Xception'ın "Okumuş Beynini" internetten çekiyoruz
    #include_top=False: "Kendi son katmanımızı ekleyeceğiz, senin orijinal sınıflandırmanı istemiyoruz" demek.
    base_model = Xception(weights='imagenet', include_top=False, input_shape=(IMAGE_SIZE[0], IMAGE_SIZE[1], 3))
    
    # Şimdilik ana beyni donduruyoruz
    base_model.trainable = False 

    # 2. Xception'ı kendi modelimize bağlıyoruz
    model = models.Sequential([
        Input(shape=(IMAGE_SIZE[0], IMAGE_SIZE[1], 3), name="input_layer"),
        base_model,
        layers.GlobalAveragePooling2D(), # Xception'dan gelen karmaşık veriyi düzleştirir
        layers.Dense(64, activation='relu'),
        layers.Dense(1, activation='sigmoid', name="output_layer") #Sahte/Gerçek çıktısı
    ])
    
    model.compile(optimizer='adam', loss='binary_crossentropy', metrics=['accuracy'])
    return model

model = build_xception_model()

print("\n--- Xception Tabanlı Model Mimarisi ---")
model.summary()

temp_model_path = "temp_tf_model"
print("\n1. Adım: Xception Modeli TensorFlow formatında diske kaydediliyor...")
model.export(temp_model_path) 

print("2. Adım: Diskteki Xception modeli ONNX formatına dönüştürülüyor...")
output_path = "xception_forgery_model.onnx" #isim karışmasın diye adını değiştirdim

komut = f'"{sys.executable}" -m tf2onnx.convert --saved-model {temp_model_path} --output {output_path} --opset 13'
os.system(komut)

print(f"\nİşlem bitti! Klasörünüzü kontrol edin, '{output_path}' oluşmuş olmalı.")