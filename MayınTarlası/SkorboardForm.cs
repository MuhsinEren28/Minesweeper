using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MayınTarlası
{
    public partial class SkorboardForm : Form
    {
        private Skorboard skorboard;

        public SkorboardForm(Skorboard skorboard)
        {
            InitializeComponent();
            this.skorboard = skorboard;
            LoadTopScores(); // Skorları yükle
        }

        // Skorları yüklemek için metod
        private void LoadTopScores()
        {
            var topScores = skorboard.GetTopScores();

            int yOffset = 10; // Başlangıç yüksekliği
            int rank = 1;

            this.Controls.Clear(); // Önceki skorları temizle, her defasında yenile

            // Skorları ekleyelim
            foreach (var playerScore in topScores)
            {
                if (rank > 10) break; // Sadece en iyi 10 skoru göster

                Label scoreLabel = new Label
                {
                    Text = $"{rank}. {playerScore.PlayerName}: {playerScore.Score}",
                    Location = new System.Drawing.Point(10, yOffset),
                    AutoSize = true
                };
                this.Controls.Add(scoreLabel);
                yOffset += 25; // Her skordan sonra biraz boşluk bırak
                rank++;
            }

            // Kapatma butonunu ekleyelim
            Button closeButton = new Button
            {
                Text = "Kapat",
                Location = new System.Drawing.Point(10, yOffset + 10),
                AutoSize = true
            };
            closeButton.Click += closeButton_Click;
            this.Controls.Add(closeButton);

            // Skor tablosunu sıfırlamak için buton ekleyelim
            Button resetButton = new Button
            {
                Text = "Skor Tablosunu Sıfırla",
                Location = new System.Drawing.Point(100, yOffset + 10),
                AutoSize = true
            };
            resetButton.Click += resetButton_Click;
            this.Controls.Add(resetButton);
        }

        // Kapatma butonunun click eventi
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close(); // Skorboard formunu kapat
        }

        // Skor tablosunu sıfırlama butonunun click eventi
        private void resetButton_Click(object sender, EventArgs e)
        {
            // Skorları sıfırlıyoruz
            skorboard.ResetScores();

            // Skorları yeniden yükle ve göster
            LoadTopScores();

            // Kullanıcıya bilgilendirme mesajı göster
            MessageBox.Show("Skor tablosu sıfırlandı!");
        }
    }
}
