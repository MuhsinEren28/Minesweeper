using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MayınTarlası
{
    public partial class Form1 : Form
    {
        private Oyun oyun;
        private Skorboard skorboard;
        private Timer gameTimer;
        private int moveCount; // Hamle sayacı değişkeni
        private Label moveCounterLabel; // Hamle sayacı etiketi
       
        public Form1()
        {
            InitializeComponent();
            skorboard = new Skorboard(); // Skorboard nesnesi oluşturuluyor
            moveCount = 0; // İlk hamle sayısını sıfırla
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PromptForPlayerInfo();
            oyun = new Oyun(oyun.PlayerName, oyun.GridSize, oyun.MineCount, skorboard);
            InitializeGame();

            // Timer Label'ı oluştur
            timerLabel = new Label
            {
                Location = new Point(10, oyun.GridSize * 30 + 10), // Gridin altında süre göstergesi
                Size = new Size(150, 30),
                Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                Text = "Süre: 0"
            };
            this.Controls.Add(timerLabel);

            // Hamle sayacı etiketi oluştur
            moveCounterLabel = new Label
            {
                Location = new Point(10, oyun.GridSize * 30 + 50), // Timer'ın altında hamle sayacı
                Size = new Size(150, 30),
                Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                Text = "Hamle Sayısı: 0"
            };
            this.Controls.Add(moveCounterLabel);

            // Timer başlatma
            gameTimer = new Timer();
            gameTimer.Interval = 1000; // 1 saniye
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (!oyun.GameOver)
            {
                // Süreyi güncelle
                timerLabel.Text = "Süre: " + oyun.GetElapsedTime().ToString("0") + " sn";
            }
        }

        private void PromptForPlayerInfo()
        {
            using (Form2 inputForm = new Form2())
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    oyun = new Oyun(inputForm.PlayerName, inputForm.GridSize, inputForm.MineCount, skorboard);
                }
                else
                {
                    oyun = new Oyun("Misafir", 10, 10, skorboard);
                }
            }
        }

        private void InitializeGame()
        {
            this.Controls.Clear(); // Önceki kontrolleri temizleyin
            this.ClientSize = new Size(oyun.GridSize * 30, oyun.GridSize * 30 + 100);

            for (int i = 0; i < oyun.GridSize; i++)
            {
                for (int j = 0; j < oyun.GridSize; j++)
                {
                    oyun.Buttons[i, j] = new Button
                    {
                        Size = new Size(30, 30),
                        Location = new Point(i * 30, j * 30),
                        BackColor = Color.LightGray,
                        Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)
                    };
                    oyun.Buttons[i, j].Click += Button_Click;
                    oyun.Buttons[i, j].MouseDown += Button_MouseDown; // Sağ tıklama için event ekleyin
                    this.Controls.Add(oyun.Buttons[i, j]);
                }
            }

            // Timer ve Hamle sayacı etiketlerini yeniden ekleyin
            this.Controls.Add(timerLabel);
            this.Controls.Add(moveCounterLabel);
           
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (oyun.GameOver) return;

            Button clickedButton = sender as Button;

            if (clickedButton.Text == "🚩") return;

            int x = clickedButton.Location.X / 30;
            int y = clickedButton.Location.Y / 30;

            if (oyun.Mines[x, y])
            {
                clickedButton.BackColor = Color.Red;
                clickedButton.Text = "💣";
                oyun.EndGame(false);
                gameTimer.Stop(); // Oyun bittiğinde Timer'ı durdur
                RevealAllMines(); // Mayınları göster
                ShowScoreboardButton(); // Skorboard'a erişim butonu
            }
            else
            {
                oyun.RevealCell(x, y);
                UpdateButtonDisplay(x, y);
                IncrementMoveCount(); // Hamle sayısını güncelle
                ShowScoreboardButton();
            }

        }

        private void IncrementMoveCount()
        {
            moveCount++;
            moveCounterLabel.Text = "Hamle Sayısı: " + moveCount;
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            if (oyun.GameOver) return;

            Button clickedButton = sender as Button;
            int x = clickedButton.Location.X / 30;
            int y = clickedButton.Location.Y / 30;

            if (oyun.Revealed[x, y]) return;

            if (e.Button == MouseButtons.Right) // Sağ tıklama
            {
                if (clickedButton.Text == "🚩")
                {
                    clickedButton.Text = "";
                    clickedButton.BackColor = Color.LightGray;
                    oyun.DecrementCorrectFlagCount();
                }
                else
                {
                    clickedButton.Text = "🚩";
                    clickedButton.BackColor = Color.Orange;
                    oyun.IncrementCorrectFlagCount(true, x, y);
                }
            }
        }
       
        private void ShowScoreboardButton()
        {
            Button scoreboardButton = new Button
            {
                Text = "Skorboard",
                Location = new Point(200, oyun.GridSize * 30 + 50),
                Size = new Size(150, 30)
            };
            scoreboardButton.Click += ScoreboardButton_Click;
            this.Controls.Add(scoreboardButton);
        }

        private void ScoreboardButton_Click(object sender, EventArgs e)
        {
            SkorboardForm scoreboardForm = new SkorboardForm(skorboard);
            scoreboardForm.ShowDialog();
        }
        private void UpdateButtonDisplay(int x, int y)
        {
            int mineCount = oyun.CountAdjacentMines(x, y);
            oyun.Buttons[x, y].Text = mineCount == 0 ? "" : mineCount.ToString();
            oyun.Buttons[x, y].BackColor = Color.White;
        }

        private void RevealAllMines()
        {
            for (int i = 0; i < oyun.GridSize; i++)
            {
                for (int j = 0; j < oyun.GridSize; j++)
                {
                    if (oyun.Mines[i, j])
                    {
                        oyun.Buttons[i, j].BackColor = Color.Red;
                        oyun.Buttons[i, j].Text = "💣";
                    }
                    else if (oyun.Buttons[i, j].Text == "🚩" && !oyun.Mines[i, j])
                    {
                        oyun.Buttons[i, j].BackColor = Color.Green; // Bayrağı doğru konmuş olan hücreyi yeşil renkle işaretle
                    }
                }
            }
        }

       
    }
}
