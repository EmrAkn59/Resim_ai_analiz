namespace Ar_Ge_Görüntü_Tespiti
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            btnAnaliz = new Button();
            openFileDialog1 = new OpenFileDialog();
            cbalgoritma = new ComboBox();
            btnYapayZekaTest = new Button();
            label1 = new Label();
            label2 = new Label();
            cbyapayzeka = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 78);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1279, 627);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnAnaliz
            // 
            btnAnaliz.BackColor = Color.PaleTurquoise;
            btnAnaliz.Font = new Font("Segoe UI", 16F);
            btnAnaliz.Location = new Point(337, 9);
            btnAnaliz.Name = "btnAnaliz";
            btnAnaliz.Size = new Size(214, 60);
            btnAnaliz.TabIndex = 1;
            btnAnaliz.Text = "Analiz";
            btnAnaliz.UseVisualStyleBackColor = false;
            btnAnaliz.Click += btnAnaliz_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // cbalgoritma
            // 
            cbalgoritma.FormattingEnabled = true;
            cbalgoritma.Items.AddRange(new object[] { "ORB", "SIFT", "AKAZE" });
            cbalgoritma.Location = new Point(169, 46);
            cbalgoritma.Name = "cbalgoritma";
            cbalgoritma.Size = new Size(162, 23);
            cbalgoritma.TabIndex = 2;
            // 
            // btnYapayZekaTest
            // 
            btnYapayZekaTest.BackColor = Color.PaleTurquoise;
            btnYapayZekaTest.Font = new Font("Segoe UI", 16F);
            btnYapayZekaTest.Location = new Point(882, 9);
            btnYapayZekaTest.Name = "btnYapayZekaTest";
            btnYapayZekaTest.Size = new Size(214, 60);
            btnYapayZekaTest.TabIndex = 3;
            btnYapayZekaTest.Text = "Yapay Zeka Test";
            btnYapayZekaTest.UseVisualStyleBackColor = false;
            btnYapayZekaTest.Click += btnYapayZekaTest_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(169, 28);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 4;
            label1.Text = "Algoritma";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(714, 28);
            label2.Name = "label2";
            label2.Size = new Size(128, 15);
            label2.TabIndex = 6;
            label2.Text = "Yapay Zeka Seçenekleri";
            // 
            // cbyapayzeka
            // 
            cbyapayzeka.FormattingEnabled = true;
            cbyapayzeka.Items.AddRange(new object[] { "Özel CNN Modeli (Hızlı)", "Xception Modeli (Gelişmiş)" });
            cbyapayzeka.Location = new Point(714, 46);
            cbyapayzeka.Name = "cbyapayzeka";
            cbyapayzeka.Size = new Size(162, 23);
            cbyapayzeka.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(1303, 717);
            Controls.Add(label2);
            Controls.Add(cbyapayzeka);
            Controls.Add(label1);
            Controls.Add(btnYapayZekaTest);
            Controls.Add(cbalgoritma);
            Controls.Add(btnAnaliz);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "AR-GE Görüntü Sahteciliği Tespiti";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnAnaliz;
        private OpenFileDialog openFileDialog1;
        private ComboBox cbalgoritma;
        private Button btnYapayZekaTest;
        private Label label1;
        private Label label2;
        private ComboBox cbyapayzeka;
    }
}
