using System;
using System.Windows.Forms;

namespace MayınTarlası
{
    public partial class Form2 : Form
    {
        public string PlayerName { get; set; }
        public int GridSize { get; set; }
        public int MineCount { get; set; }

        private Label developerInfoLabel; // Geliştirici bilgisi için Label

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Geliştirici bilgileri etiketini ekleyelim
            developerInfoLabel = new Label
            {
                Location = new System.Drawing.Point(10, 10), 
                AutoSize = true,
                Text = " Muhsin Eren Özdemir  -  210229028" 
            };
            this.Controls.Add(developerInfoLabel);

            // Label'lar için metin ekleyin
            labelPlayerName.Text = "Kullanıcı Adı";
            labelGridSize.Text = "Oyun Alanı  ";
            labelMineCount.Text = "Mayın Sayısı";

            // Varsayılan değerler ekleyelim
            textBoxPlayerName.Text = "misafir"; // Varsayılan oyuncu adı
            textBoxGridSize.Text = "10"; // Varsayılan grid boyutu
            textBoxMineCount.Text = "10"; // Varsayılan mayın sayısı
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // TextBox'lardan değerleri al
            PlayerName = textBoxPlayerName.Text;

            // Grid boyutu ve mayın sayısını sayısal olarak alalım
            if (int.TryParse(textBoxGridSize.Text, out int gridSize) && int.TryParse(textBoxMineCount.Text, out int mineCount))
            {
                // Grid boyutunun 30'dan fazla olmaması gerektiğini kontrol et
                if (gridSize > 30)
                {
                    MessageBox.Show("Oyun alanı 30'dan fazla olamaz!");
                    return;
                }

                // Mayın sayısının 10'dan az olmaması gerektiğini kontrol et
                if (mineCount < 10)
                {
                    MessageBox.Show("Mayın sayısı 10'dan az olamaz!");
                    return;
                }

                GridSize = gridSize;
                MineCount = mineCount;
            }
            else
            {
                MessageBox.Show("Lütfen geçerli sayılar girin!");
                return;
            }

            // Seçimleri onayla ve formu kapat
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
