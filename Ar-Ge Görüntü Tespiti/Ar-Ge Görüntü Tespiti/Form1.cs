using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.Features2D;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace Ar_Ge_Görüntü_Tespiti
{
    public partial class Form1 : Form
    {
        
        private string yuklenenResimYolu = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAnaliz_Click(object sender, EventArgs e)
        {
            if (cbalgoritma.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen önce bir algoritma seçin (ORB, SIFT veya AKAZE)!", "Uyarı");
                return;
            }

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                //resim yolu kaydetme
                yuklenenResimYolu = openFile.FileName;

                Mat originalImage = Cv2.ImRead(openFile.FileName);
                KeyPoint[] keyPoints = new KeyPoint[0];
                string secilenAlgoritma = cbalgoritma.Text;

                if (secilenAlgoritma == "ORB")
                {
                    var orb = ORB.Create();
                    keyPoints = orb.Detect(originalImage);
                }
                else if (secilenAlgoritma == "SIFT")
                {
                    var sift = SIFT.Create();
                    keyPoints = sift.Detect(originalImage);
                }
                else if (secilenAlgoritma == "AKAZE")
                {
                    var akaze = AKAZE.Create();
                    keyPoints = akaze.Detect(originalImage);
                }

                //noktaları ekrana çiz
                if (keyPoints.Length > 0)
                {
                    Mat outputImage = new Mat();
                    Cv2.DrawKeypoints(originalImage, keyPoints, outputImage, Scalar.LightGreen, DrawMatchesFlags.DrawRichKeypoints);
                    pictureBox1.Image = outputImage.ToBitmap();
                    MessageBox.Show($"{secilenAlgoritma} Algoritması ile {keyPoints.Length} adet anahtar nokta bulundu!", "Başarılı");
                }
            }
        }

        private Tensor<float> ResmiTensoreCevir(Bitmap orjinalResim)
        {
            int genislik = 128;
            int yukseklik = 128;

            Bitmap kucukResim = new Bitmap(orjinalResim, new System.Drawing.Size(genislik, yukseklik));
            var tensor = new DenseTensor<float>(new[] { 1, yukseklik, genislik, 3 });

            for (int y = 0; y < yukseklik; y++)
            {
                for (int x = 0; x < genislik; x++)
                {
                    Color piksel = kucukResim.GetPixel(x, y);
                    tensor[0, y, x, 0] = (piksel.R / 127.5f) - 1f;
                    tensor[0, y, x, 1] = (piksel.G / 127.5f) - 1f;
                    tensor[0, y, x, 2] = (piksel.B / 127.5f) - 1f;
                }
            }
            return tensor;
        }

        
        private string GorselSahtecilikAnaliziYap(string resimYolu, string secilenModel)
        {
            try
            {
                using (Bitmap resim = new Bitmap(resimYolu))
                {
                    var tensor = ResmiTensoreCevir(resim);

                    //yapay zeka seçme
                    string modelYolu = "";
                    if (secilenModel == "Özel CNN Modeli (Hızlı)")
                    {
                        modelYolu = "forgery_model.onnx";
                    }
                    else if (secilenModel == "Xception Modeli (Gelişmiş)")
                    {
                        modelYolu = "xception_forgery_model.onnx";
                    }

                    using (var session = new InferenceSession(modelYolu))
                    {
                        var inputs = new List<NamedOnnxValue>
                        {
                            NamedOnnxValue.CreateFromTensor("input_layer", tensor)
                        };

                        using (var results = session.Run(inputs))
                        {
                            var outputTensor = results.First().AsTensor<float>();
                            float sahtecilikSkoru = outputTensor.First();

                            if (sahtecilikSkoru >= 0.5f)
                            {
                                return $"DİKKAT: %{(sahtecilikSkoru * 100).ToString("0.0")} ihtimalle SAHTE (FORGED) resim!\nKullanılan Model: {secilenModel}";
                            }
                            else
                            {
                                return $"GÜVENLİ: %{((1f - sahtecilikSkoru) * 100).ToString("0.0")} ihtimalle ORİJİNAL (PRISTINE) resim.\nKullanılan Model: {secilenModel}";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "Yapay Zeka Hatası: " + ex.Message;
            }
        }

        private void btnYapayZekaTest_Click(object sender, EventArgs e)
        {
            //resmi kontrol ediyor
            if (string.IsNullOrEmpty(yuklenenResimYolu))
            {
                MessageBox.Show("Lütfen önce bir resim yükleyin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //ai modeli seçme
            if (cbyapayzeka.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen analiz için bir Yapay Zeka modeli seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //sahtelik analizi 
            string secilenModel = cbyapayzeka.Text;
            string sonuc = GorselSahtecilikAnaliziYap(yuklenenResimYolu, secilenModel);
            MessageBox.Show(sonuc, "Ar-Ge AI Analiz Sonucu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}